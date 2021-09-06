/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2012/04/04
 * 時刻: 11:26
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections;
using Dustin.Utils;
using Dustin.Drawing;
using Dustin.Graph;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CharacomImagerPro
{
	/// <summary>
	/// Description of RangeCompare.
	/// </summary>
	public partial class RangeCompare : Form
	{
		//private ArrayList _variations = new ArrayList();
		//private ArrayList _features = new ArrayList();
		//private ArrayList _txtCharas = new ArrayList();
		private ArrayList _ranges = new ArrayList();
		private IndividualClass _referene = new IndividualClass();	//対照資料
		private IndividualClass _judge = new IndividualClass();	//鑑定資料
		private const string VersionName = "CharacomImagerPro IntraindividualVer3.00";
		public SetupClass setup;

		private ImageEffect imageEffect = new ImageEffect();
		private MathClass math = new MathClass();
		
		private string fileName = "";
		//親フォームの参照
		private MainForm mf;
		
		
		Bitmap GraphBmp = new Bitmap(570, 360);
		Bitmap ListBmp = new Bitmap(500,500);
		Bitmap JudgeListBmp = new Bitmap(500,500);
		Bitmap ReferenceListBmp = new Bitmap(500,500);
		
		private int _copyNumber = 0;
		private int _curPageNumber = 0;
		private string printingText = "";
		private int windowID;
		
		//コマンドマネージャ
		public CommandManager undoManager = new CommandManager();
		
		#region プロパティ
		public string FileName {
			get { return fileName; }
			set {
				fileName = value;
				
				if (FileNameChanged != null) {
					FileNameChanged(this, EventArgs.Empty);
				}
			}
		}
		
		public event EventHandler FileNameChanged;
		#endregion
		
		#region 初期処理
		public RangeCompare(MainForm mainForm)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			mf = mainForm;
			InitializeComponent();
			RangeCompareSizeChanged(null, null);
			//UndoRedoのチェック
			CheckUndoRedo();
			
			//FileNameのChanged イベントを追加
			this.FileNameChanged += new System.EventHandler(this.OnFileNameChanged);
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		#endregion
		
		#region ファイル名が変更されたら
		void OnFileNameChanged(object sender, EventArgs e)
		{
			//MainForm mf = (MainForm)this.MdiParent;
			mf.ChangeWindowListName(windowID, fileName);
			this.Text = mf.GetWindowTitle(windowID);
		}
		#endregion
		
		#region 無題をつける
		public void SetNonTitle()
		{
			//タイトル文にファイル名を反映
			//MainForm mf = (MainForm)this.MdiParent;
			FileName = "無題" + mf.GetTitleNo(this.Name).ToString() + ".irc";
			
		}
		#endregion
		
		#region カラー選択テーブルの初期化
		void SetColorTbl(ComboBox combo)
		{
			if(combo.Items.Count >= setup.DisplayColor.Length) return;
			
			for(int i=0; i<setup.DisplayColor.Length; i++){
				combo.Items.Add(setup.DisplayColor[i].Name);
			}
		}
		#endregion
		
		#region コンボボックスのオーナー描画
		void ComboBoxOwnerPaint(object sender, DrawItemEventArgs e)
		{
			if(e.Index == -1){
				return;
			}
			ComboBox Combo = (ComboBox)sender;
			
			Rectangle TextRect = new Rectangle();
			Rectangle ColorRect = new Rectangle();
			
			TextRect.X = e.Bounds.X +31;
			TextRect.Y = e.Bounds.Y +1;
			TextRect.Width = e.Bounds.Width -2;
			TextRect.Height = e.Bounds.Height -2;
			
			ColorRect.X = e.Bounds.X +2;
			ColorRect.Y = e.Bounds.Y +2;
			ColorRect.Width = 25;
			ColorRect.Height = e.Bounds.Height -4;
			
			e.DrawBackground();
			
			Brush b = new SolidBrush(setup.DisplayColor[e.Index]);
			e.Graphics.DrawString(setup.DisplayColor[e.Index].Name, e.Font, Brushes.Black, TextRect);
			e.Graphics.FillRectangle(b, ColorRect);
			e.Graphics.DrawRectangle(Pens.Black, ColorRect);
			e.DrawFocusRectangle();
		}
		#endregion
		
		#region ドラッグアンドドロップ
		#region 対象資料へのドラッグ
		void DgvReferenceDragEnter(object sender, DragEventArgs e)
		{
			if(e.Data.GetDataPresent(typeof(IntraindividualVariationForm))){
				e.Effect = DragDropEffects.Copy;
			}else{
				e.Effect = DragDropEffects.None;
			}
		}
		void DgvReferenceDragDrop(object sender, DragEventArgs e)
		{
			if(e.Data.GetDataPresent(typeof(IntraindividualVariationForm))){
				IntraindividualVariationForm ivf;
				ivf = (IntraindividualVariationForm)e.Data.GetData(typeof(IntraindividualVariationForm));
				
				RRangeClass rrc = new RRangeClass();
				
				int i=0;
				_referene.Title = "対照資料";
				_referene.ViewColor = Color.Brown;
				_referene.Charas.Clear();
				foreach(ArrayList groupf in ivf.Features){
					rrc = new RRangeClass();
					rrc.Title = ((TextBox)ivf.TxtCharas[i]).Text;
					//rrc.ViewColor = Color.Brown;
					int j=0;
					
					foreach(FeatureClass fc in groupf){
						DataGridViewRow row = ivf.DgvLegend.Rows[j];
						string Title = "";
						Color c = Color.Blue;
						
						if(row.Cells[1].Value == null) Title = "";
						else 						   Title = row.Cells[1].Value.ToString();
						
						if(row.Cells[2].Value == null) c = Color.Blue;
						else                           c = setup.GetColorFromName(row.Cells[2].Value.ToString());
						
						//ここだーーー！　2016.10.24
						rrc.AddData(Title, c, fc.R, fc.R2, fc.Kajyu);
						//rrc.AddData(row.Cells[1].Value.ToString(), setup.GetColorFromName(row.Cells[2].Value.ToString()), fc.R, fc.R2, fc.Kajyu);
						j++;
					}
					_referene.AddChara(rrc);
					i++;
				}
				// メモ：
				//rrc(RRangeClass) -> 文字1つ分のばらつきデータ
				//_refarence -> 複数文字のrrcを集めた、ひとつの資料分のばらつきデータ
				
				//コマンドを実行
				//RangeCompareDragInCommand command = new RangeCompareDragInCommand(individual, _ranges);
				//undoManager.Action(command);
				//UndoRedoのチェック
				CheckUndoRedo();
				
				JudgeDataUpdate();
				//_ranges.Add(individual);
				//DataGridViewへ反映
				DataToDataGridView();
				
				MakeGraph();
			}
		}
		#endregion
		
		#region 鑑定資料のデータ更新
		void JudgeDataUpdate()
		{
			int i=0;
			foreach(RRangeClass rrc in _judge.Charas){
				for(int j=0; j<rrc.ItemsR.Count; j++){
					if(i < _referene.Charas.Count){
						rrc.ItemsR[j] = math.GetR((double [])rrc.ItemsKajyu[j], ((RRangeClass)_referene.Charas[i]).AveKajyu);
					}
				}
				i++;
			}
		}
		#endregion
		
		#region 鑑定資料へのドラッグ
		void DgvJudgeDragEnter(object sender, DragEventArgs e)
		{
			if(e.Data.GetDataPresent(typeof(IntraindividualVariationForm))){
				e.Effect = DragDropEffects.Copy;
			}else{
				e.Effect = DragDropEffects.None;
			}
		}
		
		void DgvJudgeDragDrop(object sender, DragEventArgs e)
		{
			if(e.Data.GetDataPresent(typeof(IntraindividualVariationForm))){
				IntraindividualVariationForm ivf;
				ivf = (IntraindividualVariationForm)e.Data.GetData(typeof(IntraindividualVariationForm));
				
				RRangeClass rrc = new RRangeClass();
				
				int i=0;
				_judge.Title = "資料";
				_judge.ViewColor = Color.Brown;
				_judge.Charas.Clear();
				System.Diagnostics.Debug.WriteLine("ivf.Features="+ ivf.Features.Count.ToString());
				foreach(ArrayList groupf in ivf.Features){
					rrc = new RRangeClass();
					rrc.Title = ((TextBox)ivf.TxtCharas[i]).Text;
					rrc.ViewColor = Color.Brown;
					int j=0;
					System.Diagnostics.Debug.WriteLine("groupf="+ groupf.ToString());
					foreach(FeatureClass fc in groupf){
						DataGridViewRow row = ivf.DgvLegend.Rows[j];
						System.Diagnostics.Debug.WriteLine("referene.Charas.Count="+ _referene.Charas.Count.ToString());
						if(i < _referene.Charas.Count){
							//ここだー！2016.10.24
							rrc.AddData(row.Cells[1].Value.ToString(), setup.GetColorFromName(row.Cells[2].Value.ToString()), math.GetR(fc.Kajyu, ((RRangeClass)_referene.Charas[i]).AveKajyu), math.GetR2(fc.Kajyu, ((RRangeClass)_referene.Charas[i]).AveKajyu, _referene.Charas.Count), fc.Kajyu);
							//rrc.AddData(row.Cells[1].Value.ToString(), setup.GetColorFromName(row.Cells[2].Value.ToString()), math.GetR(fc.Haikei, ((RRangeClass)_referene.Charas[i]).AveHaikei), math.GetR2(fc.Haikei, ((RRangeClass)_referene.Charas[i]).AveHaikei, _referene.Charas.Count), fc.Haikei);
							System.Diagnostics.Debug.WriteLine("ttt---!!!");
						}else{
							//ここだー！2016.10.24
							rrc.AddData(ivf.DgvLegend.Rows[j].Cells[1].Value.ToString(), setup.GetColorFromName(row.Cells[2].Value.ToString()), 0.0, 0.0, fc.Kajyu);
							//rrc.AddData(ivf.DgvLegend.Rows[j].Cells[1].Value.ToString(), setup.GetColorFromName(row.Cells[2].Value.ToString()), 0.0, 0.0, fc.Haikei);
						}
						j++;
					}
					
					_judge.AddChara(rrc);
					i++;
				}
				// メモ：
				//rrc(RRangeClass) -> 文字1つ分のばらつきデータ
				//individual -> 複数文字のrrcを集めた、ひとつの資料分のばらつきデータ
				
				//コマンドを実行
				//RangeCompareDragInCommand command = new RangeCompareDragInCommand(individual, _ranges);
				//undoManager.Action(command);
				//UndoRedoのチェック
				//CheckUndoRedo();
				
				//_ranges.Add(individual);
				//DataGridViewへ反映
				DataToDataGridView();
				
				MakeGraph();
				
			}
		}
		#endregion
		
		#endregion
		
		#region コンボボックスのオーナー描画用イベントトリガー
		void DgvJudgeEditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			ComboBox combo = e.Control as ComboBox;
			if(combo != null)
			{
				combo.DrawMode = DrawMode.OwnerDrawFixed;
				combo.DropDownStyle = ComboBoxStyle.DropDownList;
				combo.BackColor = Color.White;
				combo.DrawItem -= new DrawItemEventHandler(dgvDataComboBox_DrawItem);
				combo.DrawItem += new DrawItemEventHandler(dgvDataComboBox_DrawItem);
			}
		}
		#endregion
		
		#region コンボボックスのオーナー描画DataGridView
		void dgvDataComboBox_DrawItem(object sender, DrawItemEventArgs e)
		{
			if(e.Index == -1){
				return;
			}
			ComboBox Combo = (ComboBox)sender;
			
			Rectangle ColorRect = new Rectangle();
			
			ColorRect.X = e.Bounds.X + 2;
			ColorRect.Y = e.Bounds.Y + 2;
			ColorRect.Width = e.Bounds.Width - 4;
			ColorRect.Height = e.Bounds.Height - 4;
			e.DrawBackground();
			Brush b = new SolidBrush(setup.DisplayColor[e.Index]);
			e.Graphics.FillRectangle(b, ColorRect);
			e.DrawFocusRectangle();
		}
		#endregion
		
		#region DataGridViewのセルの内容が変更されたとき
		void DgvJudgeCellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if(e.ColumnIndex == 1 && e.RowIndex < dgvJudge.Rows.Count && e.RowIndex >= 0){
				//項目名が変更されたとき
				foreach(RRangeClass rrc in _judge.Charas){
					if(e.RowIndex < rrc.DocumentTitles.Count){
				       	rrc.DocumentTitles[e.RowIndex] = dgvJudge.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
				    }
				}
			}else if(e.ColumnIndex == 2 && e.RowIndex < dgvJudge.Rows.Count && e.RowIndex >= 0){
				//表示色が変更されたとき
				DataGridViewCell cell = dgvJudge.Rows[e.RowIndex].Cells[e.ColumnIndex];
				System.Diagnostics.Debug.WriteLine("CellValue=" + cell.Value.ToString());
				if(cell.Value == null || cell.Value.ToString() == ""){
					cell.Style.BackColor = Color.White;
				}else{
					cell.Style.BackColor = setup.GetColorFromName(cell.Value.ToString());
					cell.Style.ForeColor = cell.Style.BackColor;
					foreach(RRangeClass rrc in _judge.Charas){
						if(e.RowIndex < rrc.CharaColors.Count){
							rrc.CharaColors[e.RowIndex] = cell.Style.BackColor;
						}
					}
				}
			}
			MakeGraph();
		}
		#endregion
		
		#region DataGridViewが選択されたとき⇒クリック1発でコンボボックスを開く
		void DgvJudgeCellEnter(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView dgv = (DataGridView)sender;
			
			if(dgv.Columns[e.ColumnIndex].Name == "color" && dgv.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn){
				SendKeys.Send("{F4}");
				
			}
		}
		#endregion
		
		#region DataGridViewへの反映
		double GetAllMinimun()
		{
			double min = 500.0;
			foreach(RRangeClass rc in _referene.Charas){
				if(min > rc.MinR2) min = rc.MinR2;
			}
			foreach(RRangeClass rc in _judge.Charas){
				if(min > rc.MinR) min = rc.MinR;
			}
			return(min);
		}
		void DataToDataGridView()
		{
			//対照資料への反映
			dgvReference.Rows.Clear();
			dgvReference.Columns.Clear();
			
			dgvReference.Columns.Add("No.", "No");
			dgvReference.Columns[0].Width = 100;
			dgvReference.Columns[0].ReadOnly = true;
			
			int i = 0;
			foreach(RRangeClass rrc in _referene.Charas){
				dgvReference.Columns.Add("No." + (i+1).ToString(), rrc.Title);
				dgvReference.Columns[i+1].Width = 70;
				dgvReference.Columns[i+1].ReadOnly = true;
				int j=0;
				foreach(double R in rrc.ItemsR){
					if(dgvReference.Rows.Count <= j){
						dgvReference.Rows.Add();
					}
					j++;
				}
				i++;
			}
			i=0;
			foreach(RRangeClass rrc in _referene.Charas){
				int j=0;
				foreach(double R in rrc.ItemsR2){
					dgvReference.Rows[j].Cells[i+1].Value = R.ToString("f4");
					if(dgvReference.Rows[j].Cells[0].Value == null){
						dgvReference.Rows[j].Cells[0].Value = (j+1).ToString();
					}
					j++;
				}
				i++;
			}
			int maxIndex, minIndex, avgIndex;
			dgvReference.Rows.Add();
			maxIndex = dgvReference.Rows.Count - 1;
			dgvReference.Rows[maxIndex].Cells[0].Value = "最大";
			dgvReference.Rows.Add();
			minIndex = dgvReference.Rows.Count - 1;
			dgvReference.Rows[minIndex].Cells[0].Value = "最小";
			dgvReference.Rows.Add();
			avgIndex = dgvReference.Rows.Count - 1;
			dgvReference.Rows[avgIndex].Cells[0].Value = "平均";
			
			i = 0;
			foreach(RRangeClass rrc in _referene.Charas){
				if (rrc.MaxR2 == 0.0 && rrc.MinR2 == 500.0){
					dgvReference.Rows[maxIndex].Cells[i + 1].Value = "-";
					dgvReference.Rows[minIndex].Cells[i + 1].Value = "-";
					dgvReference.Rows[avgIndex].Cells[i + 1].Value = "-";
				}else{
					dgvReference.Rows[maxIndex].Cells[i + 1].Value = rrc.MaxR2.ToString("f4");
					dgvReference.Rows[minIndex].Cells[i + 1].Value = rrc.MinR2.ToString("f4");
					dgvReference.Rows[avgIndex].Cells[i + 1].Value = rrc.AveR.ToString("f4");
				}
				i++;
			}
			
			dgvJudge.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvJudgeCellValueChanged);
			//鑑定資料への反映
			dgvJudge.Rows.Clear();
			dgvJudge.Columns.Clear();
			
			dgvJudge.Columns.Add("No.", "No");
			dgvJudge.Columns[0].Width = 30;
			dgvJudge.Columns[0].ReadOnly = true;
			
			dgvJudge.Columns.Add("Name", "資料名");
			dgvJudge.Columns[1].Width = 100;
			
			DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
			
			col.HeaderText = "表示色";
			col.Name = "color";
			col.Width = 100;
			col.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
			col.DisplayStyleForCurrentCellOnly = true;
			col.FlatStyle = FlatStyle.Flat;
			
			for(i=0; i<setup.DisplayColor.Length; i++){
				col.Items.Add(setup.DisplayColor[i].Name);
			}
			dgvJudge.Columns.Add(col);
			//dgvJudge.Columns[2].Width = 100;
			//dgvJudge.Columns[2].CellType = DataGridViewComboBoxDisplayStyle.ComboBox;
			
			
			i = 0;
			foreach(RRangeClass rrc in _judge.Charas){
				int j=0;
				dgvJudge.Columns.Add("No." + (i+1).ToString(), rrc.Title);
				dgvJudge.Columns[i + 3].Width = 70;
				dgvJudge.Columns[i + 3].ReadOnly = true;
				foreach(double R in rrc.ItemsR){
					if(j >= dgvJudge.Rows.Count) dgvJudge.Rows.Add();
					dgvJudge.Rows[j].Cells[i+3].Value = R.ToString("f4");
					if(dgvJudge.Rows[j].Cells[0].Value == null){
						dgvJudge.Rows[j].Cells[0].Value = (j+1).ToString();
					}
					if(dgvJudge.Rows[j].Cells[1].Value == null){
						dgvJudge.Rows[j].Cells[1].Value = rrc.DocumentTitles[j];
					}
					if(dgvJudge.Rows[j].Cells[2].Value == null){
						dgvJudge.Rows[j].Cells[2].Value = setup.CheckColorName(((Color)rrc.CharaColors[j]).Name);
						dgvJudge.Rows[j].Cells[2].Style.BackColor = setup.GetColorFromName(((Color)rrc.CharaColors[j]).Name);
						dgvJudge.Rows[j].Cells[2].Style.ForeColor = dgvJudge.Rows[j].Cells[2].Style.BackColor;
					}
					j++;
				}
				i++;
			}
			dgvJudge.Rows.Add();
			maxIndex = 	dgvJudge.Rows.Count - 1;
			dgvJudge.Rows[maxIndex].Cells[1].Value = "最大";
			dgvJudge.Rows[maxIndex].Cells[1].ReadOnly = true;
			dgvJudge.Rows[maxIndex].Cells[2].ReadOnly = true;
			dgvJudge.Rows.Add();
			minIndex = 	dgvJudge.Rows.Count - 1;
			dgvJudge.Rows[minIndex].Cells[1].Value = "最小";
			dgvJudge.Rows[minIndex].Cells[1].ReadOnly = true;
			dgvJudge.Rows[minIndex].Cells[2].ReadOnly = true;
			dgvJudge.Rows.Add();
			avgIndex = dgvJudge.Rows.Count - 1;
			dgvJudge.Rows[avgIndex].Cells[1].Value = "平均";
			dgvJudge.Rows[avgIndex].Cells[1].ReadOnly = true;
			dgvJudge.Rows[avgIndex].Cells[2].ReadOnly = true;
			
			i = 0;
			foreach(RRangeClass rrc in _judge.Charas){
				if (rrc.MaxR == 0.0 && rrc.MinR == 500.0){
					dgvJudge.Rows[maxIndex].Cells[i + 3].Value = "-";
					dgvJudge.Rows[minIndex].Cells[i + 3].Value = "-";
					dgvJudge.Rows[avgIndex].Cells[i + 3].Value = "-";
				}else{
					dgvJudge.Rows[maxIndex].Cells[i + 3].Value = rrc.MaxR.ToString("f4");
					dgvJudge.Rows[minIndex].Cells[i + 3].Value = rrc.MinR.ToString("f4");
					dgvJudge.Rows[avgIndex].Cells[i + 3].Value = rrc.AveR.ToString("f4");
				}
				i++;
			}
			dgvJudge.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvJudgeCellValueChanged);
			
		}
		#endregion
		
		#region グラフ作成
		void MakeYAxis(IGraphPainter graph)
		{
			IAxis  axis;
			double Min = 0.0;
			double MinorInterval, MajorInterval;
			double ScaleMin;
			Min = GetAllMinimun();
			if(Min >= 0.95){
				MajorInterval = 0.02;
				MinorInterval = 0.01;
			}else if(Min >= 0.9){
				MajorInterval = 0.025;
				MinorInterval = 0.025;
			}else{
				MajorInterval = 0.05;
				MinorInterval = 0.05;
			}
			ScaleMin = Math.Floor(Min / MinorInterval) * MinorInterval;
			axis = graph.YAxis;
			axis.Scale.Min =  ScaleMin;
			axis.Scale.Max =  1.001;
			axis.Scale.Base = ScaleMin;
			axis.Ticks.Labels.LabelFormat = "0.000";
			axis.Ticks.Labels.Interval    = 1;
			axis.Ticks.Major.LineLength = 8;
			axis.Ticks.Major.Pen        = Pens.Black;
			axis.Ticks.Major.Interval   = MajorInterval;
			axis.Ticks.Minor.Visible    = true;
			axis.Ticks.Minor.Interval   = MinorInterval;
			axis.Grid.Major.Visible     = true;
			axis.Grid.Major.Interval    = MajorInterval;
			axis.Grid.Minor.Visible     = true;
			axis.Grid.Minor.Interval    = MinorInterval;
			
		}
		
		void MakeXAxis(IGraphPainter graph)
		{
			int XScale;
			XScale = _referene.Charas.Count;
			
			ST_TickLabelPoint [] labelPoints = new ST_TickLabelPoint [XScale];
			int j=0;
			foreach(RRangeClass rc in _referene.Charas){
				labelPoints[j] = new ST_TickLabelPoint(j, rc.Title);
				j++;
			}
			
			IAxis  axis;
			
			axis = graph.XAxis;
			axis.Ticks.Labels.LabelFormat = "0";
			axis.Ticks.Labels.Interval    = 1;
			axis.Ticks.Major.Interval   = 1;
			axis.Ticks.Side             = DusGraph.eTickSide.Bottom;
			axis.Ticks.Labels.Points.AddRange( labelPoints );
			axis.Ticks.Labels.Font        = new Font( "ＭＳ 明朝", 14, FontStyle.Bold );
			///axis.Ticks.Direction        = DusGraph.eTickDirection.Outside;
			axis.Grid.Major.Visible     = false;
			axis.Grid.Major.Interval    = 1;
			axis.Scale.Min =  0;
			axis.Scale.Max = XScale - 1;
			axis.Scale.Base = 0;
			
		}
		
		void MakePlotData(IGraphPainter graph)
		{
			ISeriesCandleChart  sr;		//対照資料最大最小ボックス
			//ISeriesXYPlot  sr2;		
			ISeriesCandleChart  sr2;	//対照資料生データプロット
			ISeriesXYPlot  sr3;			//対照資料平均値プロット
			ISeriesCandleChart  sr4;	//対照資料平均除外生データプロット
			double max, min;
			Color c;
			Pen linePen = new Pen(Color.Blue, 2);
			
			//対照資料
			if(cmbReferenceColor.SelectedIndex < 0){
				c = Color.Red;
			}else{
				c =setup.DisplayColor[cmbReferenceColor.SelectedIndex];
			}
			sr = graph.CreateSeries( DusGraph.ePlotType.CandleChart ).asCandleChart;
			sr.NegativeBrush = new SolidBrush(Color.FromArgb(128, c));
			sr.PositiveBrush = new SolidBrush(Color.FromArgb(128, c));
			sr.BarWidth = 30;
			sr.Pen = new Pen(c);
			sr3 = graph.CreateSeries( DusGraph.ePlotType.Line).asXYPlot;
			if(chkReferenceAve.Checked){
				//平均グラフを作成
				sr3.Mark.Visible    = true;
				sr3.Mark.Type       = DusGraph.ePlotMarkType.Star;
				sr3.Mark.Brush      = new SolidBrush(c);
				sr3.Mark.Width      = 8;
				sr3.Mark.Height     = 8;
				sr3.Title = _referene.Title;
				//sr2.Mark.NumCorners = 8;
				
			}
			
			int i=0;
			foreach(RRangeClass rc in _referene.Charas){
				
				//最大最少を表示
				if(rc.MinR != 500.0 || rc.MaxR != 0.00){
					min = rc.MinR;
					max = rc.MaxR;
					// new ST_CandlePoint( Ｘ値, 始値, 終値, 高値, 安値 )
					sr.Data.Add( new ST_CandlePoint( i, min, max, min, min));
				}
				sr2 = graph.CreateSeries( DusGraph.ePlotType.CandleChart).asCandleChart;
				sr2.BarWidth = 3;
				sr2.Pen = new Pen(c, 3);
				//平均グラフにプロットを挿入
				if(chkReferenceAve.Checked){
					linePen = new Pen(c, 2);
					linePen.DashStyle = DashStyle.Solid;
					sr3.Mark.Border.Pen = new Pen(c, 1);
					sr3.asLine.Pen      = linePen;
					sr3.Data.Add( new ST_PlotPoint(i, rc.AveR2 ));
				}
				foreach(double R in rc.ItemsR){
					sr2.Data.Add( new ST_CandlePoint( i, R, R, R, R));	
				}
				/**
				if(chkReferenceData.Checked){
					graph.Series.Add( sr2 );
				}
				***/
				i++;
			}
			//if(chkReferenceRange.Checked == true) graph.Series.Add( sr );
			if(chkReferenceAve.Checked) graph.Series.Add( sr3);
			
			if(chkReferenceData.Checked){
				/*****
				 * 三崎さんからの要望により、キャンドルグラフに変更 2012.06.05
				 * →三崎さんからの要望により、平均除外をプロットするに変更 2013.11.04
				 * ***/
				//R2グラフを作成
				for(i=0; i<_referene.MaxLength; i++){
					sr4 = graph.CreateSeries( DusGraph.ePlotType.CandleChart).asCandleChart;
					int j = 0;
					foreach(RRangeClass rc in _referene.Charas){
						if(i < rc.ItemsR2.Count){
							//sr4.Title = rc.DocumentTitles[i].ToString() + "(平均除外)";
							//c = (Color)rc.CharaColors[i];
							//sr4.Data.Add( new ST_PlotPoint(j, (double)rc.ItemsR2[i]) );
							sr4.Data.Add( new ST_CandlePoint(j, (double)rc.ItemsR2[i],(double)rc.ItemsR2[i],(double)rc.ItemsR2[i],(double)rc.ItemsR2[i]) );
						}
						j++;
					}
					sr4.BarWidth = 3;
					sr4.Pen = new Pen(c, 3);
				
					/**
					sr4.Mark.Visible    = true;
					sr4.Mark.Type       = DusGraph.ePlotMarkType.Star;
					sr4.Mark.Brush      = new SolidBrush(c);
					sr4.Mark.Width      = 8;
					sr4.Mark.Height     = 8;
					sr4.Mark.Border.Pen = new Pen(c, 1);
					linePen = new Pen(c,2);
					linePen.DashStyle = DashStyle.Dot;
					//linePen.Color = c;
					sr4.asLine.Pen      = linePen;
					//sr4.asLine.Pen.Color = c;
					***/
					graph.Series.Add(sr4);
				}
			}
			
			if(chkReferenceRange.Checked){
				sr = graph.CreateSeries( DusGraph.ePlotType.CandleChart ).asCandleChart;
				sr.NegativeBrush = new SolidBrush(Color.FromArgb(64, c));
				sr.PositiveBrush = new SolidBrush(Color.FromArgb(64, c));
				sr.BarWidth = 30;
				sr.Pen = new Pen(c);
				i=0;
				foreach(RRangeClass rc in _referene.Charas){
					if(rc.MinR2 != 500.0 || rc.MaxR2 != 0.0){
						min = rc.MinR2;
						max = rc.MaxR2;
						// new ST_CandlePoint( Ｘ値, 始値, 終値, 高値, 安値 )
						sr.Data.Add( new ST_CandlePoint( i, min, max, min, min));	
					}
					i++;
				}
				graph.Series.Add(sr);
			}
			//鑑定資料
			//平均のグラフ設定
			if(cmbJudgeColor.SelectedIndex < 0){
				c = Color.Red;
			}else{
				c = setup.DisplayColor[cmbJudgeColor.SelectedIndex];
			}
			//if(cmbJudgeColor.Text == ""){
			//	c = Color.Blue;
			//}else{
			//	c = GetColorFromName(cmbJudgeColor.Text);
			//}
			//c = Color.DarkGoldenrod;
			if(chkJudgeAve.Checked){
				sr3 = graph.CreateSeries( DusGraph.ePlotType.Line).asXYPlot;
				sr3.Mark.Visible    = true;
				sr3.Mark.Type       = DusGraph.ePlotMarkType.Star;
				sr3.Mark.Brush      = new SolidBrush(c);
				sr3.Mark.Width      = 8;
				sr3.Mark.Height     = 8;
				sr3.Title = "鑑定資料平均";
				sr3.Mark.Border.Pen = new Pen(c, 1);
				linePen = new Pen(c, 2);
				linePen.DashStyle = DashStyle.Dot;
				sr3.asLine.Pen      = linePen;
				//平均のグラフプロット
				i=0;
				foreach(RRangeClass rrc in _judge.Charas){
					//平均グラフにプロットを挿入
					sr3.Data.Add( new ST_PlotPoint(i, rrc.AveR));
					i++;
				}
			}
			if(chkJudgeAve.Checked) graph.Series.Add( sr3);
			//最大最小ボックスをプロット
			if(chkJudgeRange.Checked == true){
				sr = graph.CreateSeries( DusGraph.ePlotType.CandleChart ).asCandleChart;
				sr.NegativeBrush = new SolidBrush(Color.FromArgb(128, c));
				sr.PositiveBrush = new SolidBrush(Color.FromArgb(128, c));
				sr.BarWidth = 30;
				sr.Pen = new Pen(c);
				i=0;
				foreach(RRangeClass rc in _judge.Charas){
					if(rc.MinR != 500.0 && rc.MaxR != 0.0){
						min = rc.MinR;
						max = rc.MaxR;
						// new ST_CandlePoint( Ｘ値, 始値, 終値, 高値, 安値 )
						sr.Data.Add( new ST_CandlePoint( i, min, max, min, min));	
					}
					i++;
				}
				graph.Series.Add(sr);
			}
			
			//生データをプロット
			if(chkJudgeData.Checked){
			for(i = 0; i < _judge.MaxLength; i++){
				sr3 = graph.CreateSeries( DusGraph.ePlotType.Line).asXYPlot;
				foreach(RRangeClass rrc in _judge.Charas){
					if(rrc.ItemsR.Count > i){
						sr3.Title = (string)rrc.DocumentTitles[i];
						c = (Color)rrc.CharaColors[i];
						//System.Diagnostics.Debug.WriteLine(c.ToString());
						sr3.Mark.Brush = new SolidBrush(c);
						sr3.Mark.Border.Pen = new Pen(c, 1);
						sr3.asLine.Pen = new Pen(c, 2);
					}
				}
				sr3.Mark.Visible    = true;
				sr3.Mark.Type       = DusGraph.ePlotMarkType.Star;
				sr3.Mark.Brush      = new SolidBrush(c);
				sr3.Mark.Width      = 8;
				sr3.Mark.Height     = 8;
				
				//sr3.Title = (string)((RRangeClass)_judge.Charas[0]).DocumentTitles[i];
				sr3.Mark.Border.Pen = new Pen(c, 1);
				sr3.asLine.Pen      = new Pen(c, 2);
				
				int j=0;
				foreach(RRangeClass rrc in _judge.Charas){
					if(i < rrc.ItemsR.Count){
						sr3.Data.Add( new ST_PlotPoint(j, (double)rrc.ItemsR[i]));
						//System.Diagnostics.Debug.WriteLine(rrc.ItemsR[i].ToString());
					}
					j++;
				}
				graph.Series.Add(sr3);
			}
			}
			
		}
		void MakeGraph()
		{
			imageEffect.BitmapWhitening(GraphBmp);
			if(_referene.Charas.Count < 1){
				GraphImage.Invalidate();
				return;
			}
			IGraphPainter  graph = DusGraph.CreateGraph( 570, 360 );
			
			#region グラフエリアの設定
			graph.SmoothingMode     = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			///graph.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
			graph.BackBrush = new LinearGradientBrush( graph.GetBounds(), Color.White, Color.LemonChiffon, LinearGradientMode.Vertical );
			graph.Border.Pen = new Pen( Color.Gray, 1 );
			graph.PlotArea.BackBrush = new LinearGradientBrush( graph.GetBounds(), Color.LightBlue, Color.White, LinearGradientMode.Vertical);
			graph.PlotArea.Border.Top.Pen       = Pens.Transparent;
			graph.PlotArea.Border.Right.Pen     = Pens.Silver;
			graph.PlotArea.Margin.Left   = 40;
			graph.PlotArea.Margin.Right  = 160;
			graph.PlotArea.Margin.Top    = 40;
			graph.PlotArea.Margin.Bottom = 30;
			graph.PlotArea.InnerMargin.Left  = 40;
			graph.PlotArea.InnerMargin.Right = 40;
			#endregion
			
			#region 凡例の設定
			graph.Legend.Visible = true;
			graph.Legend.Location = new PointF( 415, 40 );
			graph.Legend.Size     = new SizeF( 150, 300 );
			graph.Legend.ItemArea.BaseLocation = new PointF( 5, 20 );
			graph.Legend.ItemArea.ItemSize     = new SizeF( 140, 20 );
			#endregion
			
			MakeXAxis(graph);
			
			MakeYAxis(graph);
			
			MakePlotData(graph);
			
			graph.Draw();
			
			//Graphics  g = graph.CreateGraphics();
			Graphics g = Graphics.FromImage(GraphBmp);
			g.FillRectangle(Brushes.White, 0, 0, GraphBmp.Width, GraphBmp.Height);
			g.DrawImage(graph.Image,0,0);
			
			g.Dispose();
			
			GraphImage.Invalidate();
		}
		#endregion
		
		#region GraphImageBoxのペイント処理
		void GraphImagePaint(object sender, PaintEventArgs e)
		{
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImage(GraphBmp, 0, 0, GraphImage.Width, GraphImage.Height);
		}
		#endregion
		
		#region 一覧表を画像にする
		void MakeList()
		{
			Font TitleFont = new Font("メイリオ", 14, FontStyle.Bold);
			Font HeaderFont = new Font("メイリオ", 12, FontStyle.Bold);
			Font DataFont = new Font("メイリオ", 10);
			const int NoWidth = 40;
			const int NameWidth = 100;
			const int ColorWidth = 70;
			const int DataWidth = 70;
			
			const int MarginX = 5;
			const int MarginY = 5;
			
			int x, y, by;
			int ex, ey;
			int wx, wy;
			Graphics g;
			RectangleF r;
			StringFormat sf = new StringFormat();
			int i;
			
			//全体の大きさ用
			int MaxX, MaxY;
			
			#region 鑑定資料の一覧表
			by=0;
			if(_judge.Charas.Count > 1){
				//全体の大きさを確認
				MaxX = MarginX + NoWidth + MarginX + NameWidth + MarginX + ColorWidth + MarginX + _judge.Charas.Count * (DataWidth + MarginX);
				MaxY = MarginY + TitleFont.Height + MarginY + HeaderFont.Height + MarginY + _judge.MaxLength * (DataFont.Height + MarginY) + (DataFont.Height + MarginY) * 3;
			
				//ビットマップを作成
				JudgeListBmp = new Bitmap(MaxX, MaxY);
				imageEffect.BitmapWhitening(JudgeListBmp);
				
				//グラフィックを作成
				g = Graphics.FromImage(JudgeListBmp);
				
				x = 0; y = 0;
				y = MarginY;
				
				//エンドポイントを算出
				ex = MaxX - MarginX / 2;
				ey = MaxY - MarginY / 2;
				
				//タイトルを表示
				x = MarginX / 2;
				y = MarginY / 2;
				g.DrawString("■鑑定資料数値解析結果", TitleFont, Brushes.Black, x, y);
				y += TitleFont.Height + MarginY;
				
				//罫線を引く
				//ヘッダー部
				g.DrawLine(Pens.Black, x, y, ex-1, y);
				y += HeaderFont.Height + MarginY;
				//データ部
				for(i=0; i<_judge.MaxLength; i++){
					g.DrawLine(Pens.Black, x, y, ex-1, y);
					y += DataFont.Height + MarginY;
				}
				//最大最小平均部
				for(i=0; i<3; i++){
					g.DrawLine(Pens.Black, x, y, ex-1, y);
					g.FillRectangle(Brushes.PaleTurquoise, x + 1, y + 1, ex - ( x + 1)- 1, DataFont.Height + MarginY);
					y += DataFont.Height + MarginY;
				}
				g.DrawLine(Pens.Black, x, y, ex-1, y);
				//縦線
				g.DrawLine(Pens.Black, x, MarginY/2+TitleFont.Height + MarginY, x, ey-1);
				x += NoWidth + MarginX;
				g.DrawLine(Pens.Black, x, MarginY/2+TitleFont.Height + MarginY, x, ey-1);
				x += NameWidth + MarginX;
				g.DrawLine(Pens.Black, x, MarginY/2+TitleFont.Height + MarginY, x, ey-1);
				x += ColorWidth + MarginX;
				foreach(RRangeClass rrc in _judge.Charas){
					g.DrawLine(Pens.Black, x, MarginY/2+TitleFont.Height + MarginY, x, ey-1);
					x += DataWidth + MarginX;
				}
				g.DrawLine(Pens.Black, x, MarginY/2+TitleFont.Height + MarginY, x, ey-1);
				
				//ヘッダー部の作成
				x = MarginX;
				y = MarginY + TitleFont.Height + MarginY;
				sf.Alignment = StringAlignment.Center;
				sf.LineAlignment = StringAlignment.Center;
				r = new RectangleF(x, y, NoWidth, HeaderFont.Height);
				g.DrawString("No.", HeaderFont, Brushes.Black, r, sf);
				x += NoWidth + MarginX;
				r = new RectangleF(x, y, NameWidth, HeaderFont.Height);
				g.DrawString("資料名", HeaderFont, Brushes.Black, r, sf);
				x += NameWidth + MarginX;
				r = new RectangleF(x, y, ColorWidth, HeaderFont.Height);
				g.DrawString("表示色", HeaderFont, Brushes.Black, r, sf);
				x += ColorWidth + MarginX;
				foreach(RRangeClass rrc in _judge.Charas){
					r = new RectangleF(x, y, DataWidth, HeaderFont.Height);
					g.DrawString(rrc.Title, HeaderFont, Brushes.Black, r, sf);
					x += DataWidth + MarginX;
				}
				y += HeaderFont.Height + MarginY;
				wy = y;
				wx = MarginX + NoWidth + MarginX;
				//データ部の作成
				for( i=0; i<_judge.MaxLength; i++){
					//No.の作成
					x = MarginX;
					r = new RectangleF(x, y, NoWidth, DataFont.Height);
					g.DrawString((i+1).ToString(), DataFont, Brushes.Black, r, sf);
					x += NoWidth + MarginX;
					wx = x;
					//資料名・表示色の作成
					foreach(RRangeClass rrc in _judge.Charas){
						x = wx;
						if(rrc.CharaColors.Count > i){
							r = new RectangleF(x, y, NameWidth, DataFont.Height);
							g.DrawString((string)rrc.DocumentTitles[i], DataFont, Brushes.Black, r, sf);
							x += NameWidth + MarginX;
							r = new RectangleF(x, y, ColorWidth, DataFont.Height);
							g.FillRectangle(new SolidBrush((Color)rrc.CharaColors[i]), r);
							
						}
						
					}
					y += DataFont.Height + MarginY;
				}
				//データの作成
				x = wx + NameWidth + MarginX + ColorWidth + MarginX;
				foreach(RRangeClass rrc in _judge.Charas){
					y = wy;
					foreach(double itemR in rrc.ItemsR){
						r = new RectangleF(x, y, DataWidth, DataFont.Height);
						g.DrawString(itemR.ToString("f4"), DataFont, Brushes.Black, r, sf);
						y += DataFont.Height + MarginY;
						if(by < y){
							by = y;
						}
					}
					x += DataWidth + MarginX;
				}
				//平均最大最小の作成
				//最大の作成
				x = wx;
				y = by;
				r = new RectangleF(x, y, NameWidth, DataFont.Height);
				g.DrawString("最大", DataFont, Brushes.Black, r, sf);
				x += NameWidth + MarginX + ColorWidth + MarginX;
				foreach(RRangeClass rrc in _judge.Charas){
					r = new RectangleF(x, y, DataWidth, DataFont.Height);
					g.DrawString(rrc.MaxR.ToString("f4"), DataFont, Brushes.Black, r, sf);
					x += DataWidth + MarginX;
				}
				y += DataFont.Height + MarginY;
				
				//最小の作成
				x = wx;
				r = new RectangleF(x, y, NameWidth, DataFont.Height);
				g.DrawString("最小", DataFont, Brushes.Black, r, sf);
				x += NameWidth + MarginX + ColorWidth + MarginX;
				foreach(RRangeClass rrc in _judge.Charas){
					r = new RectangleF(x, y, DataWidth, DataFont.Height);
					g.DrawString(rrc.MinR.ToString("f4"), DataFont, Brushes.Black, r, sf);
					x += DataWidth + MarginX;
				}
				y += DataFont.Height + MarginY;
				
				//平均の作成
				x = wx;
				r = new RectangleF(x, y, NameWidth, DataFont.Height);
				g.DrawString("平均", DataFont, Brushes.Black, r, sf);
				x += NameWidth + MarginX + ColorWidth + MarginX;
				foreach(RRangeClass rrc in _judge.Charas){
					r = new RectangleF(x, y, DataWidth, DataFont.Height);
					g.DrawString(rrc.AveR.ToString("f4"), DataFont, Brushes.Black, r, sf);
					x += DataWidth + MarginX;
				}
				
				g.Dispose();
			}
			#endregion
			
			#region 対照資料の一覧表
			by=0;
			if(_referene.Charas.Count > 1){
				//全体の大きさを確認
				MaxX = MarginX + NoWidth + MarginX + _referene.Charas.Count * (DataWidth + MarginX);
				MaxY = MarginY + TitleFont.Height + MarginY + HeaderFont.Height + MarginY + _referene.MaxLength * (DataFont.Height + MarginY) + (DataFont.Height + MarginY) * 3;
			
				//ビットマップを作成
				ReferenceListBmp = new Bitmap(MaxX, MaxY);
				imageEffect.BitmapWhitening(ReferenceListBmp);
				
				//グラフィックを作成
				g = Graphics.FromImage(ReferenceListBmp);
				
				x = 0; y = 0;
				y = MarginY;
				
				//エンドポイントを算出
				ex = MaxX - MarginX / 2;
				ey = MaxY - MarginY / 2;
				
				//タイトルを表示
				x = MarginX / 2;
				y = MarginY / 2;
				g.DrawString("■対照資料数値解析結果", TitleFont, Brushes.Black, x, y);
				y += TitleFont.Height + MarginY;
				
				//罫線を引く
				//ヘッダー部
				g.DrawLine(Pens.Black, x, y, ex-1, y);
				y += HeaderFont.Height + MarginY;
				//データ部
				for(i=0; i<_referene.MaxLength; i++){
					g.DrawLine(Pens.Black, x, y, ex-1, y);
					y += DataFont.Height + MarginY;
				}
				
				//最大最小平均部
				for(i=0; i<3; i++){
					g.DrawLine(Pens.Black, x, y, ex-1, y);
					g.FillRectangle(Brushes.PaleTurquoise, x + 1, y + 1, ex - ( x + 1)- 1, DataFont.Height + MarginY);
					y += DataFont.Height + MarginY;
				}
				g.DrawLine(Pens.Black, x, y, ex-1, y);
				//縦線
				g.DrawLine(Pens.Black, x, MarginY/2+TitleFont.Height + MarginY, x, ey-1);
				x += NoWidth + MarginX;
				foreach(RRangeClass rrc in _referene.Charas){
					g.DrawLine(Pens.Black, x, MarginY/2+TitleFont.Height + MarginY, x, ey-1);
					x += DataWidth + MarginX;
				}
				g.DrawLine(Pens.Black, x, MarginY/2+TitleFont.Height + MarginY, x, ey-1);
				
				//ヘッダー部の作成
				x = MarginX;
				y = MarginY + TitleFont.Height + MarginY;
				sf.Alignment = StringAlignment.Center;
				sf.LineAlignment = StringAlignment.Center;
				r = new RectangleF(x, y, NoWidth, HeaderFont.Height);
				g.DrawString("No.", HeaderFont, Brushes.Black, r, sf);
				x += NoWidth + MarginX;
				foreach(RRangeClass rrc in _referene.Charas){
					r = new RectangleF(x, y, DataWidth, HeaderFont.Height);
					g.DrawString(rrc.Title, HeaderFont, Brushes.Black, r, sf);
					x += DataWidth + MarginX;
				}
				y += HeaderFont.Height + MarginY;
				wy = y;
				wx = MarginX + NoWidth + MarginX;
				//データ部の作成
				for( i=0; i<_referene.MaxLength; i++){
					//No.の作成
					x = MarginX;
					r = new RectangleF(x, y, NoWidth, DataFont.Height);
					g.DrawString((i+1).ToString(), DataFont, Brushes.Black, r, sf);
					x += NoWidth + MarginX;
					wx = x;
					
					y += DataFont.Height + MarginY;
				}
				//データの作成
				by = 0;
				x = wx;
				foreach(RRangeClass rrc in _referene.Charas){
					y = wy;
					foreach(double itemR in rrc.ItemsR2){
						r = new RectangleF(x, y, DataWidth, DataFont.Height);
						g.DrawString(itemR.ToString("f4"), DataFont, Brushes.Black, r, sf);
						y += DataFont.Height + MarginY;
						if(by < y){
							by = y;
						}
					}
					x += DataWidth + MarginX;
				}
				y = by;
				//平均最大最小の作成
				//最大の作成
				x = MarginX;
				r = new RectangleF(x, y, NoWidth, DataFont.Height);
				g.DrawString("最大", DataFont, Brushes.Black, r, sf);
				x += NoWidth + MarginX;
				foreach(RRangeClass rrc in _referene.Charas){
					r = new RectangleF(x, y, DataWidth, DataFont.Height);
					g.DrawString(rrc.MaxR2.ToString("f4"), DataFont, Brushes.Black, r, sf);
					x += DataWidth + MarginX;
				}
				y += DataFont.Height + MarginY;
				
				//最小の作成
				x = MarginX;
				r = new RectangleF(x, y, NoWidth, DataFont.Height);
				g.DrawString("最小", DataFont, Brushes.Black, r, sf);
				x += NoWidth + MarginX;
				foreach(RRangeClass rrc in _referene.Charas){
					r = new RectangleF(x, y, DataWidth, DataFont.Height);
					g.DrawString(rrc.MinR2.ToString("f4"), DataFont, Brushes.Black, r, sf);
					x += DataWidth + MarginX;
				}
				y += DataFont.Height + MarginY;
				
				//平均の作成
				x = MarginX;
				r = new RectangleF(x, y, NoWidth, DataFont.Height);
				g.DrawString("平均", DataFont, Brushes.Black, r, sf);
				x += NoWidth + MarginX;
				foreach(RRangeClass rrc in _referene.Charas){
					r = new RectangleF(x, y, DataWidth, DataFont.Height);
					g.DrawString(rrc.AveR2.ToString("f4"), DataFont, Brushes.Black, r, sf);
					x += DataWidth + MarginX;
				}
				
				g.Dispose();
			}
			#endregion
			
			//つなげる
			int maxx = 0;
			
			if(JudgeListBmp.Width >= ReferenceListBmp.Width) 	maxx = JudgeListBmp.Width;
			else												maxx = ReferenceListBmp.Width;
			ListBmp = new Bitmap(maxx, JudgeListBmp.Height + ReferenceListBmp.Height);
			imageEffect.BitmapWhitening(ListBmp);
			
			imageEffect.BitmapCopyXY(JudgeListBmp, ListBmp, 0, 0);
			imageEffect.BitmapCopyXY(ReferenceListBmp, ListBmp, 0, JudgeListBmp.Height + 1);
		}
		#endregion
		
		#region ファイルを開く(IRCファイル)
		public void OpenIRCFile()
		{
			if(fileName == "" || fileName == null)return;
			//個人内変動ファイルを開く
			FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
			BinaryFormatter bf = new BinaryFormatter();
			string VerName;
			string s1, s2;
			
			try{
				VerName = (string)bf.Deserialize(fs);
			}
			catch{
				MessageBox.Show("指定されたファイルを開くことができませんでした。ファイルが壊れているか、バージョンが違う可能性があります。\nファイルのバージョンを確認してください。",
				                "ファイルオープンエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				fs.Close();
				fs.Dispose();
				return;
			}
			if(VerName != VersionName){
				MessageBox.Show("指定されたファイルを開くことができませんでした。バージョンが違います。\nファイルのバージョンを確認してください。",
				                "ファイルオープンエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				fs.Close();
				fs.Dispose();
				return;
			}
			
			SetColorTbl(cmbReferenceColor);
			SetColorTbl(cmbJudgeColor);
			
			_judge = (IndividualClass)bf.Deserialize(fs);
			_referene = (IndividualClass)bf.Deserialize(fs);
			chkJudgeRange.Checked = (bool)bf.Deserialize(fs);
			chkReferenceRange.Checked = (bool)bf.Deserialize(fs);
			s1 = (string)bf.Deserialize(fs);
			cmbJudgeColor.SelectedIndex = setup.GetColorNo(s1);
			s2 = (string)bf.Deserialize(fs);
			cmbReferenceColor.SelectedIndex = setup.GetColorNo(s2);
			
			txtComment.Text = (string)bf.Deserialize(fs);
			
			fs.Close();
			
			DataToDataGridView();
			MakeGraph();
			
			//最近使ったファイルに追加してもらう
			//MainForm mf = (MainForm)this.MdiParent;
			mf.AddRecentlyFile(fileName);
		}
		#endregion
		
		#region ファイルを保存(IRCファイル)
		void SaveIRCFile()
		{
			if(fileName == "" || fileName == null)return;
			FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
			BinaryFormatter bf = new BinaryFormatter();
			string VerName = VersionName;
			
			bf.Serialize(fs, VerName);
			bf.Serialize(fs, _judge);
			bf.Serialize(fs, _referene);
			bf.Serialize(fs, chkJudgeRange.Checked);
			bf.Serialize(fs, chkReferenceRange.Checked);
			bf.Serialize(fs, cmbJudgeColor.Text);
			bf.Serialize(fs, cmbReferenceColor.Text);
			bf.Serialize(fs, txtComment.Text);
			System.Diagnostics.Debug.WriteLine("Save - cmbJudgeColor.Text = " + cmbJudgeColor.Text);
			System.Diagnostics.Debug.WriteLine("Save - cmbReferenceColor.Text = " + cmbReferenceColor.Text);
			fs.Close();
			//コマンドをクリア
			undoManager.UndoClear();
			undoManager.RedoClear();
			CheckUndoRedo();
			
			//最近使ったファイルに追加してもらう
			//MainForm mf = (MainForm)this.MdiParent;
			mf.AddRecentlyFile(fileName);
		}
		#endregion
		
		#region 画像保存用のビットマップを作成
		void MakeImageBmp(Bitmap bmp)
		{
			int width, height;
			
			width = GraphBmp.Width;
			if(width < ListBmp.Width) width = ListBmp.Width;
			height = GraphBmp.Height + ListBmp.Height;
			bmp = new Bitmap(width, height);
			
			imageEffect.BitmapWhitening(bmp);
			imageEffect.BitmapCopyXY(GraphBmp, bmp, 0, 0);
			imageEffect.BitmapCopyXY(ListBmp, bmp, 0, GraphBmp.Height + 1);
		}
		#endregion
		
		#region 画像ファイルかどうかの判定
		public bool IsImageFile(string str)
		{
			bool bRet = false;
			switch (Path.GetExtension(str).ToLower()) {
				case ".jpeg":
				case ".jpg":
				case ".jpe":
				case ".gif":
				case ".bmp":
				case ".png":
					bRet = true;
					break;
				default:
					bRet = false;
					break;
			}
			return(bRet);
		}
		#endregion
		
		#region ツールバーメニュー
		void BtnOpenClick(object sender, EventArgs e)
		{
			if(openFileDlg.ShowDialog() == DialogResult.OK){
				if(System.IO.Path.GetExtension(openFileDlg.FileName) == ".irc"){
					FileName = openFileDlg.FileName;
					OpenIRCFile();
				}else{
					MessageBox.Show("個人内変動データではありません。ファイルを確認してください", "CharacomImagerPro",MessageBoxButtons.OK, MessageBoxIcon.Error);
					
				}
			}
		}
		void BtnSaveAsClick(object sender, EventArgs e)
		{
			if(saveFileDlg.ShowDialog() == DialogResult.OK){
				this.FileName = saveFileDlg.FileName;
			}else{
				return;
			}
			SaveIRCFile();
		}
		
		void BtnSaveClick(object sender, EventArgs e)
		{
			if(this.FileName.IndexOf("無題") >= 0 || fileName == "" || fileName == null){
				if(saveFileDlg.ShowDialog() == DialogResult.OK){
					this.FileName = saveFileDlg.FileName;
				}else{
					return;
				}
			}
			SaveIRCFile();
		}
		
		void BtnImageSaveClick(object sender, EventArgs e)
		{
			if(saveImageFileDialog.ShowDialog() == DialogResult.OK){
				if(IsImageFile(saveImageFileDialog.FileName)){
					MakeGraph();
					MakeList();
					
					int width, height;
			
					width = GraphBmp.Width;
					if(width < ListBmp.Width) width = ListBmp.Width;
					height = GraphBmp.Height + ListBmp.Height;
					Bitmap bmp = new Bitmap(width, height);
			
					imageEffect.BitmapWhitening(bmp);
					imageEffect.BitmapCopyXY(GraphBmp, bmp, 0, 0);
					imageEffect.BitmapCopyXY(ListBmp, bmp, 0, GraphBmp.Height + 1);
					
					bmp.Save(saveImageFileDialog.FileName);
				}
			}
		}
		
		void BtnUndoClick(object sender, EventArgs e)
		{
			undoManager.Undo();
			//UndoRedoのチェック
			CheckUndoRedo();
			//DataGridViewへ反映
			DataToDataGridView();
				
			MakeGraph();
		}
		
		void BtnRedoClick(object sender, EventArgs e)
		{
			undoManager.Redo();
			//UndoRedoのチェック
			CheckUndoRedo();
			//DataGridViewへ反映
			DataToDataGridView();
				
			MakeGraph();
		}
		
		void BtnGraphClick(object sender, EventArgs e)
		{
			RangeCompareGraph rcg = new RangeCompareGraph();
			
			rcg.GraphUpdate(GraphBmp);
			rcg.StartPosition = FormStartPosition.CenterParent;
			rcg.ShowDialog();
		}
		
		void BtnGraphCopyClick(object sender, EventArgs e)
		{
			MakeGraph();
			Clipboard.SetImage(GraphBmp);
		}
		
		void BtnTableCopyClick(object sender, EventArgs e)
		{
			MakeList();
			Clipboard.SetImage(ListBmp);
		}
		
		void BtnPrintPreviewClick(object sender, EventArgs e)
		{
			printDocument.PrinterSettings.Copies = 1;
			printPreviewDialog.StartPosition = FormStartPosition.CenterParent;
			printPreviewDialog.ShowDialog();
		}
		
		void BtnPrintClick(object sender, EventArgs e)
		{
			if(printDialog.ShowDialog() == DialogResult.OK){
				printDocument.PrinterSettings.Copies = printDialog.PrinterSettings.Copies;
				printDocument.Print();
			}
		}
		#endregion
		
		#region コンテキストメニュー
		void MenuUndoClick(object sender, EventArgs e)
		{
			BtnUndoClick(sender, e);
		}
		
		void MenuRedoClick(object sender, EventArgs e)
		{
			BtnUndoClick(sender, e);
		}
		
		void MenuOpenClick(object sender, EventArgs e)
		{
			BtnOpenClick(sender, e);
		}
		
		void MenuSaveClick(object sender, EventArgs e)
		{
			BtnSaveClick(sender, e);
		}
		
		void MenuSaveAsClick(object sender, EventArgs e)
		{
			if(saveFileDlg.ShowDialog() == DialogResult.OK){
				this.fileName = saveFileDlg.FileName;
			}else{
				return;
			}
			SaveIRCFile();
		}
		
		void MenuImageSaveClick(object sender, EventArgs e)
		{
			BtnImageSaveClick(sender, e);
		}
		
		void MenuGraphCopyClick(object sender, EventArgs e)
		{
			BtnGraphCopyClick(sender, e);
		}
		
		void MenuListCopyClick(object sender, EventArgs e)
		{
			BtnTableCopyClick(sender, e);
		}
		
		void MenuPrintPreviewClick(object sender, EventArgs e)
		{
			BtnPrintPreviewClick(sender, e);
		}
		
		void MenuPrintClick(object sender, EventArgs e)
		{
			BtnPrintClick(sender, e);
		}
		
		void MenuPageSetupClick(object sender, EventArgs e)
		{
			pageSetupDialog.ShowDialog();
		}
		
		void MenuCloseClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void MenuDeleteClick(object sender, EventArgs e)
		{
			/**
			if(dgvData.CurrentRow == null) return;
			if(dgvData.CurrentRow.Index < 0)return;
			if(dgvData.CurrentRow.Index >= dgvData.Rows.Count)return;
			
			//コマンドを実行
			RangeCompareDeleteCommand command = new RangeCompareDeleteCommand(_ranges, dgvData.CurrentRow.Index);
			undoManager.Action(command);
			//UndoRedoのチェック
			CheckUndoRedo();
				
			//_ranges.Add(individual);
			//DataGridViewへ反映
			DataToDataGridView();
				
			MakeGraph();
			**/
		}
		#endregion
		
		#region ウィンドウのサイズが変わったら
		void RangeCompareSizeChanged(object sender, EventArgs e)
		{
			int kijyun = 0;
			int kijyunY = 0;
			
			
			dgvJudge.Width = this.Width - 12 - 28;
			dgvReference.Width = this.Width - 12 - 28;
			
			kijyun = (this.Width - 12 - 28 - 12) / 5;
			kijyunY = (this.Height - 50 - 30 - 24*3) / 3;
			
			txtComment.Width = kijyun * 3;
			txtComment.Height = kijyunY;
			txtComment.Location = new Point(12, 30 + 24 + kijyunY + 24 + kijyunY + 24);
			
			dgvJudge.Height = kijyunY;
			dgvJudge.Location = new Point(12, 30 + 24);
			
			dgvReference.Height = kijyunY;
			dgvReference.Location = new Point(12, 30 + 24 + kijyunY + 24);
			
			panel1.Width = kijyun * 2;
			panel1.Height = kijyunY;
			panel1.Location = new Point(12+txtComment.Width+12, 30 + 24 + kijyunY + 24 + kijyunY + 24);
			
			//ラベルの座標あわせ
			pJudgeB.Location = new Point(dgvJudge.Location.X+dgvJudge.Width - pJudgeB.Width, pJudgeB.Location.Y);
			pReferenceA.Location =new Point(12, dgvReference.Location.Y - pReferenceA.Height);
			pReferenceB.Location = new Point(dgvReference.Location.X +dgvReference.Width-pReferenceB.Width, pReferenceA.Location.Y);
			/***
			lblJudgeTitle.Location = new Point(12, 30);
			lblReferenceTitle.Location = new Point(12, 30 + 24 + kijyunY);
			
			//chkReferenceData.Location = new Point(chkReferenceData.Location.X - 56, 30 + 24 + kijyunY);
			//chkReferenceAve.Location = new Point(chkReferenceData.Location.X + chkReferenceData.Width , chkReferenceData.Location.Y);
			//chkR2.Location = new Point(chkReferenceAve.Location.X+chkReferenceAve.Width , chkReferenceData.Location.Y);
			//chkReferenceRange.Location = new Point(chkR2.Location.X+chkR2.Width , chkReferenceData.Location.Y);
			//lblReferenceColor.Location = new Point(chkReferenceRange.Location.X + chkReferenceRange.Width , chkReferenceData.Location.Y);
			//cmbReferenceColor.Location = new Point(lblReferenceColor.Location.X + lblReferenceColor.Width , chkReferenceData.Location.Y);
			
			chkJudgeRange.Location = new Point(this.Width - 28 - cmbJudgeColor.Width - lblJudgeColor.Width - chkJudgeRange.Width, 30);
			chkReferenceRange.Location = new Point(this.Width - 28 - cmbReferenceColor.Width - lblReferenceColor.Width - chkReferenceRange.Width, 30 + 24 + kijyunY);
			chkR2.Location = new Point(chkReferenceRange.Location.X - 107, chkReferenceRange.Location.Y);
			chkJudgeAve.Location = new Point(chkR2.Location.X, chkJudgeRange.Location.Y);
			chkJudgeData.Location = new Point(chkR2.Location.X - 56, chkJudgeRange.Location.Y);
			chkReferenceAve.Location = new Point(chkReferenceData.Location.X - 56, chkReferenceRange.Location.Y);
			
			lblJudgeColor.Location = new Point(this.Width - 28 - cmbJudgeColor.Width - lblJudgeColor.Width, 30);
			lblReferenceColor.Location = new Point(this.Width - 28 - cmbReferenceColor.Width - lblReferenceColor.Width, 30 + 24 + kijyunY);
			
			cmbJudgeColor.Location = new Point(this.Width - 28 - cmbJudgeColor.Width, 32);
			//cmbReferenceColor.Location = new Point(this.Width - 28 - cmbReferenceColor.Width, 32 + 24 + kijyunY);
			***/
			
			lblComment.Location = new Point(12, 30 + 24 + kijyunY + 24 + kijyunY);
			lblPreView.Location = new Point(12 + kijyun*3 + 12, 30 + 24 + kijyunY + 24 + kijyunY);
		}
		#endregion
				
		#region 印刷処理
		void PrintDocumentPrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			printDocument.DocumentName = "CharacomPro[変動比較]";
			Font HeaderF = new Font("メイリオ", 8, FontStyle.Bold);
			Font FooterF = new Font("メイリオ", 8, FontStyle.Bold);
			//int MarginX = 5;
			int MarginY = 5;
			
			Font f = new Font("メイリオ", 10, FontStyle.Bold);
			int x, y;
			int sx, sy, ex, ey;
			int BodySY, BodyEY;
			//int ChartSY, ChartEY;
			x = e.MarginBounds.X; y = e.MarginBounds.Y;
			
			sx = e.MarginBounds.X; sy = e.MarginBounds.Y;
			ex = e.MarginBounds.Right; ey = e.MarginBounds.Bottom;
			
			BodySY = sy + f.Height + MarginY;
			BodyEY = ey - f.Height - MarginY;
			
			//ヘッダーの作成
			e.Graphics.DrawString("CharacomImagerPro", HeaderF, Brushes.Black, sx, sy);
			e.Graphics.DrawString(DateTime.Now.ToString("yyyy.MM.dd"), HeaderF, Brushes.Black, ex - HeaderF.Size * 10, sy);
			e.Graphics.DrawLine(Pens.Black, sx, sy + HeaderF.Height + MarginY, ex, sy + HeaderF.Height + MarginY);
			
			//フッターの作成
			e.Graphics.DrawLine(Pens.Black, sx, ey - HeaderF.Height - MarginY, ex, ey - HeaderF.Height - MarginY);
			e.Graphics.DrawString("Copyright (c) 2012 CharacomImagerPro", HeaderF, Brushes.Black, sx, ey - HeaderF.Height);
			
			if(_curPageNumber > 0){
				PrintComment(e, f, sx, x, y, MarginY, BodySY, BodyEY);
				if(_curPageNumber == 0){
					_copyNumber++;
					if(_copyNumber < e.PageSettings.PrinterSettings.Copies){
						e.HasMorePages = true;
					}else{
						e.HasMorePages = false;
						_copyNumber = 0;
					}
			    }
				return;
			}
			//グラフと一覧表を作成
			MakeGraph();
			MakeList();
			
			//タイトルを作成
			Font TitleF = new Font("メイリオ", 16, FontStyle.Bold);
			e.Graphics.DrawString("■数値解析処理結果報告書", TitleF, Brushes.Black, sx, BodySY + MarginY);
			
			//グラフを作成
			x = sx; y = BodySY+MarginY+TitleF.Height+MarginY;
			e.Graphics.DrawImage(GraphBmp, x, y, GraphBmp.Width, GraphBmp.Height);
			
			//表を作成
			x = sx; y += GraphBmp.Height + MarginY;
			//e.Graphics.DrawString("■数値一覧", f, Brushes.Black, sx, y);
			//y += f.Height + MarginY;
			e.Graphics.DrawImage(ListBmp, x, y, ListBmp.Width, ListBmp.Height);
			y += ListBmp.Height + MarginY;
			
			if(_curPageNumber == 0){
				printingText = "";
				printingText = txtComment.Text;
				printingText = printingText.Replace("\r\n", "\n");
        		printingText = printingText.Replace("\r", "\n");
			}
			
			if(txtComment.Text.Length > 0){
				PrintComment(e, f, sx, x, y, MarginY, BodySY, BodyEY);
			}
			
		   	if(_curPageNumber == 0){
				_copyNumber++;
				if(_copyNumber < e.PageSettings.PrinterSettings.Copies){
					e.HasMorePages = true;
				}else{
					e.HasMorePages = false;
					_copyNumber = 0;
				}
		   	}
		}
		#endregion
		
		#region コメントを印刷
		void PrintComment(System.Drawing.Printing.PrintPageEventArgs e, Font f, int sx, int x, int y, int MarginY, int BodySY, int BodyEY)
		{
			if(_curPageNumber > 0){
				y = BodySY;
			}else{
				e.Graphics.DrawString("■コメント", f, Brushes.Black, sx, y);
				y += f.Height + MarginY;
			}
			int printingPosition = 0;
			
			//1ページに収まらなくなるか、印刷する文字がなくなるかまでループ
		    while (BodyEY > y + f.Height && printingPosition < printingText.Length)
		    {
		        string line = "";
		        for (;;)
		        {
		            //印刷する文字がなくなるか、
		            //改行の時はループから抜けて印刷する
		            if (printingPosition >= printingText.Length || printingText[printingPosition] == '\n')
		            {
		                printingPosition++;
		                break;
		            }
		            //一文字追加し、印刷幅を超えるか調べる
		            line += printingText[printingPosition];
		            if (e.Graphics.MeasureString(line, f).Width
		                > e.MarginBounds.Width)
		            {
		                //印刷幅を超えたため、折り返す
		                line = line.Substring(0, line.Length - 1);
		                break;
		            }
		            //印刷文字位置を次へ
		            printingPosition++;
		        }
		        //一行書き出す
		        e.Graphics.DrawString(line, f, Brushes.Black, x, y);
		        //次の行の印刷位置を計算
		        y += f.Height;
		    }
		    
		    if(BodyEY > y && printingPosition < printingText.Length){
		    	e.HasMorePages = true;
		    	_curPageNumber++;
		    	printingText = printingText.Substring(printingPosition);
		    }else{
		    	e.HasMorePages = false;
		    	_curPageNumber = 0;
		    }
		    if(printingText.Length < 1){
		    	e.HasMorePages = false;
		    	_curPageNumber = 0;
		    }
		}
		#endregion
		
		#region Undoのチェック
		void CheckUndoRedo()
		{
			btnUndo.Enabled = undoManager.CanUndo();
			menuUndo.Enabled = undoManager.CanUndo();
			
			btnRedo.Enabled = undoManager.CanRedo();
			menuRedo.Enabled = undoManager.CanRedo();
		}
		#endregion
		
		#region コンテキストメニューが呼ばれたら
		void SubMenuOpened(object sender, EventArgs e)
		{
			/**
			Point p = new Point(0, 0);
			p = dgvData.PointToClient(Cursor.Position);
			if(p.X > 0 && p.X < dgvData.Width && p.Y > 0 && p.Y < dgvData.Height && dgvData.CurrentRow != null){
				menuDelete.Enabled = true;
			}else{
				menuDelete.Enabled = false;
			}
			**/
		}
		#endregion
		
		#region フォームが閉じられようとしたら
		void RangeCompareFormClosing(object sender, FormClosingEventArgs e)
		{
			if(undoManager.CanRedo() == true || undoManager.CanUndo() == true){
				DialogResult d;
				d = MessageBox.Show("この資料は変更されています。閉じる前に保存しますか？", "CharacomImagerPro", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
				if(d == DialogResult.Yes){
					BtnSaveClick(sender, e);
				}else if(d == DialogResult.Cancel){
					return;
				}
			}
			//MainForm mf = (MainForm)this.MdiParent;
			mf.RemoveWindowAtID(windowID);
		}
		#endregion
		
		#region フォームが開かれようとしたら
		void RangeCompareShown(object sender, EventArgs e)
		{
			//メインフォームにウィンドウリストを追加してもらう
			//MainForm mf = (MainForm)MdiParent;
			string titleName = "";
			windowID = mf.AddWindowList(this.Name, fileName);
			titleName = mf.GetWindowTitle(windowID);
			this.Text = titleName;
		}
		#endregion
		
		#region 対照資料色選択コンボボックスのオーナー描画イベント
		void CmbReferenceColorDrawItem(object sender, DrawItemEventArgs e)
		{
			ComboBoxOwnerPaint(sender, e);
		}
		#endregion
		
		#region 鑑定資料色選択コンボボックスのオーナー描画イベント
		void CmbJudgeColorDrawItem(object sender, DrawItemEventArgs e)
		{
			ComboBoxOwnerPaint(sender, e);
		}
		#endregion
		
		#region 鑑定資料色選択コンボボックスの選択変更
		void CmbJudgeColorSelectedIndexChanged(object sender, EventArgs e)
		{
			MakeGraph();
		}
		#endregion
		
		#region 対照資料色選択コンボボックスの選択変更
		void CmbReferenceColorSelectedIndexChanged(object sender, EventArgs e)
		{
			MakeGraph();
		}
		#endregion
		
		#region 対照資料の表示チェックボックス変更
		void ChkReferenceRangeCheckedChanged(object sender, EventArgs e)
		{
			MakeGraph();
		}
		#endregion
		
		#region 鑑定資料の表示チェックボックス変更
		void ChkJudgeRangeCheckedChanged(object sender, EventArgs e)
		{
			MakeGraph();
		}
		#endregion
		
		#region R2表示チェックボックスの変更
		void ChkR2CheckedChanged(object sender, EventArgs e)
		{
			MakeGraph();
		}
		#endregion
		
		#region 鑑定資料 平均のチェックボックス変更
		void ChkJudgeAveCheckedChanged(object sender, EventArgs e)
		{
			MakeGraph();
		}
		#endregion
		
		#region 鑑定資料 データのチェックボックス変更
		void ChkJudgeDataCheckedChanged(object sender, EventArgs e)
		{
			MakeGraph();
		}
		#endregion
		
		#region 対照資料 データのチェックボックス変更
		void ChkReferenceDataCheckedChanged(object sender, EventArgs e)
		{
			MakeGraph();
		}
		#endregion
		
		#region 対照資料 平均のチェックボックス変更
		void ChkReferenceAveCheckedChanged(object sender, EventArgs e)
		{
			MakeGraph();
		}
		#endregion
		
		void RangeCompareLoad(object sender, EventArgs e)
		{
			SetColorTbl(cmbReferenceColor);
			SetColorTbl(cmbJudgeColor);
			
		}
		
		void DgvJudgeDataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			if (e.Exception != null)
		    {
				

		    }
		}
		
		#region ウィンドウをコピー
		// 2020.08.30 D.Honjyou 三崎さんからの要望により追加
		void CopyWindowMenuItemClick(object sender, EventArgs e)
		{
			//フォームからスクリーンショットを撮る　
			Bitmap clipBmp = new Bitmap(this.Width, this.Height);
			this.DrawToBitmap(clipBmp, new Rectangle(0, 0, this.Width, this.Height));
			Clipboard.SetImage(clipBmp);
			
			clipBmp.Dispose();
		}
		void BtnCopyWindowClick(object sender, EventArgs e)
		{
			CopyWindowMenuItemClick(sender, e);
		}
		#endregion
		
		
		
		
	}
}
