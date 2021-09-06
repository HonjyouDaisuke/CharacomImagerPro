/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2012/03/12
 * 時刻: 11:18
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using Dustin.Utils;
using Dustin.Drawing;
using Dustin.Graph;
using System.Runtime.Serialization.Formatters.Binary;

namespace CharacomImagerPro
{
	/// <summary>
	/// Description of IntraindividualVariationForm.
	/// </summary>
	public partial class IntraindividualVariationForm : Form
	{
		private const string VersionName = "CharacomImagerPro IntraindividualVer3.00";
		ImageEffect imageEffect = new ImageEffect();
		Bitmap GraphBmp = new Bitmap(600,360);
		MathClass mathClass = new MathClass();
		private SetupClass _setup;		
		public SetupClass Setup {
			get { return _setup; }
			set { _setup = value; }
		}
		
		private int _copyNumber = 0;
		private int _curPageNumber = 0;
		private string printingText = "";
		//親フォームの参照
		private MainForm mf;
		
		//private ArrayList feature = new ArrayList();
		private ArrayList features = new ArrayList();
		private ArrayList DataGridViews = new ArrayList();
		private ArrayList chkDeletes = new ArrayList();
		private ArrayList txtCharas = new ArrayList();
		private ArrayList lblCharas = new ArrayList();
		private ArrayList btnDeletes = new ArrayList();
		private ArrayList btnUps = new ArrayList();
		private ArrayList btnDowns = new ArrayList();
		private ArrayList btnLefts = new ArrayList();
		private ArrayList btnRights = new ArrayList();
		
		public CommandManager undoManager = new CommandManager();
		private string fileName = "";
		private int windowID;
		
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
		private int GroupNum = 0;
		
		public ArrayList Features {
			get { return features; }
			set { features = value; }
		}
		public ArrayList TxtCharas {
			get { return txtCharas; }
			set { txtCharas = value; }
		}
		public System.Windows.Forms.DataGridView DgvLegend {
			get { return dgvLegend; }
			set { dgvLegend = value; }
		}
		
		public IntraindividualVariationForm(MainForm mainForm)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			BtnAddClick(null, null);
			BtnAddClick(null, null);
			BtnAddClick(null, null);
			BtnAddClick(null, null);
			
			mf = mainForm;
			//FileNameのChanged イベントを追加
			this.FileNameChanged += new System.EventHandler(this.OnFileNameChanged);
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
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
			FileName = "無題" + mf.GetTitleNo(this.Name).ToString() + ".civ";
		}
		#endregion
		
		#region タイトルを右クリックしたらドラッグ開始
		protected override void WndProc(ref Message m)
		{
			if(m.Msg == 0xa4 && m.WParam == (System.IntPtr)0x2){
				this.DoDragDrop(this, DragDropEffects.All);
			}
			base.WndProc(ref m);
		}
		#endregion
		
		#region コンボボックスのオーナー描画用イベントトリガー
		void DgvLegendEditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			ComboBox combo = e.Control as ComboBox;
			if(combo != null)
			{
				combo.DrawMode = DrawMode.OwnerDrawFixed;
				combo.DropDownStyle = ComboBoxStyle.DropDownList;
				combo.DrawItem -= new DrawItemEventHandler(dgvLegendComboBox_DrawItem);
				combo.DrawItem += new DrawItemEventHandler(dgvLegendComboBox_DrawItem);
			}
		}
		#endregion
		
		#region コンボボックスのオーナー描画
		void dgvLegendComboBox_DrawItem(object sender, DrawItemEventArgs e)
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
			
			Brush b = new SolidBrush(Setup.DisplayColor[e.Index]);
			e.Graphics.FillRectangle(b, ColorRect);
			e.DrawFocusRectangle();
		}
		#endregion
		
		#region コンボボックスの初期化
		void SetColorTbl()
		{
			if(Column3.Items.Count < Setup.DisplayColor.Length){
				for(int i=0; i<Setup.DisplayColor.Length; i++){
					Column3.Items.Add(Setup.DisplayColor[i].Name);
				}
			}
			if(Column4.Items.Count < Setup.DisplayColor.Length){
				for(int i=0; i<Setup.DisplayColor.Length; i++){
					Column4.Items.Add(Setup.DisplayColor[i].Name);
				}
			}
			
			//combo.DrawItem += new System.Windows.Forms.DrawItemEventHandler(ComboDraw);
		}
		#endregion
		
		#region DataGridViewに行を追加
		void IntoDataGridViewRow(DataGridViewRow Row, Bitmap bmp, string FileName, int num)
		{
			Row.Height = 50;
			Row.Cells[0].Value = num.ToString();
			Row.Cells[1].Value = bmp;
			Row.Cells[2].Value = Path.GetFileName(FileName);
			//dgv[3, dgv.Rows.Count - 1].Value = imglCheck.Images[0];
			
		}
		#endregion
		
		#region 特徴の平均の作成
		void GetFeatureAverage(double [] kajyuAvg, double [] kajyuViewAvg, ArrayList feature)
		{
			double [] sum = new double[kajyuAvg.Length];
			double [] sumView = new double[kajyuViewAvg.Length];
			int num;
			int i;
			
			for(i=0; i<sum.Length; i++){
				sum[i]=0.0;
				sumView[i]=0.0;
			}
			num = feature.Count;
			//MainForm mf = new MainForm();
			//mf = (MainForm)this.MdiParent;
			
			foreach(FeatureClass fc in feature){
				if(mf.Setup.Kajyu){
					//加重の場合
					for(i=0; i<fc.Kajyu.Length; i++){
						sum[i] += fc.Kajyu[i];
						sumView[i] += fc.KajyuView[i];
						//if(i>100 && i<110)System.Diagnostics.Debug.WriteLine(string.Format("{0}:k={1:f1} sum={2:f1} ",i, fc.Kajyu[i], sum[i]));
					}
				}else{
					//背景伝搬の場合
					for(i=0; i<fc.Haikei.Length; i++){
						sum[i] += fc.Haikei[i];
						sumView[i] += fc.HaikeiView[i];
						//if(i>100 && i<110)System.Diagnostics.Debug.WriteLine(string.Format("{0}:k={1:f1} sum={2:f1} ",i, fc.Kajyu[i], sum[i]));
					}
				}
			}
			
			for(i=0; i<sum.Length; i++){
				kajyuAvg[i] = sum[i] / num;
				kajyuViewAvg[i] = sumView[i] / num;
			}
		}
		#endregion
		
		#region 類似度を作成
		void MakeR(ArrayList feature, DataGridView dgv)
		{
			double [] kajyuAvg = new double[256];
			double [] kajyuViewAvg = new double[256];
			double [] haikeiAvg = new double[512];
			double [] haikeiViewAvg = new double[512];
			//MainForm mf = new MainForm();
			//mf = (MainForm)this.MdiParent;
			if(mf.Setup.Kajyu){
				//加重方向指数ヒストグラム特徴の場合
				GetFeatureAverage(kajyuAvg, kajyuViewAvg, feature);
			}else{
				//背景伝搬法の場合
				GetFeatureAverage(haikeiAvg, haikeiViewAvg, feature);
			}
			
			//グループ内の平均特徴と入力したパターンでの類似度を出す。
			//2012.01.20 D.Honjyou
			double R, R2;
			
			int num = 0;
			foreach(FeatureClass fc in feature){
				if(mf.Setup.Kajyu){
					R = mathClass.GetR(kajyuAvg, fc.Kajyu);
					R2 = mathClass.GetR2(kajyuAvg, fc.Kajyu, feature.Count);
				}else{
					R = mathClass.GetR(haikeiAvg, fc.Haikei);
					R2 = mathClass.GetR2(haikeiAvg, fc.Haikei, feature.Count);
				}
				fc.R = R;
				fc.R2 = R2;
				
				if(dgv.Rows.Count > num){
					dgv[0, num].Value = (num + 1).ToString();
					dgv[3, num].Value = fc.R.ToString("F4");
					//System.Diagnostics.Debug.WriteLine("R = " + fc.R.ToString("f4") + " : R2 = " + fc.R2.ToString("f4"));
				}
				num++;
			}	
		}
		#endregion
		
		#region ドラッグアンドドロップ処理
		void DragDropProc(CharaImageForm cif, DataGridView dgv, int num)
		{
			//前処理をして特徴抽出に使う準備をする
			imageEffect.Normalize(cif.SrcBitmapSmall, mf.Setup.CharaR);
			imageEffect.Noize(cif.SrcBitmapSmall);
			//imageEffect.DrawTinning(cif.SrcBitmapSmall, cif.SrcBitmapSmall, Color.Black);
				
			//DataGridView用のデータを作成
			DataGridViewRow NewRow = new DataGridViewRow();
			NewRow.CreateCells(dgv);
			IntoDataGridViewRow(NewRow, cif.SrcBitmapSmall, cif.FileName, dgv.Rows.Count + 1);
				
			//特徴クラスを作成してデータを挿入
			FeatureClass thisFeature = new FeatureClass();
			imageEffect.GetKajyu(cif.SrcBitmapSmall, thisFeature.Kajyu, thisFeature.KajyuView, mf.Setup.CharaR);
			imageEffect.GetHaikei(cif.SrcBitmapSmall, thisFeature.Haikei, thisFeature.HaikeiView, mf.Setup.CharaR);
			
			thisFeature.SrcBitmap = cif.SrcBitmapSmall;
			thisFeature.FileName = cif.FileName;
			
			//コマンドマネージャへ
			//CheckUpDragInCommand command = new CheckUpDragInCommand(dgv.Rows, NewRow, feature[num], thisFeature);
			//undoManager.Action(command);
			dgv.Rows.Add(NewRow);
			System.Diagnostics.Debug.WriteLine(int.Parse(dgv.Name.Substring(8)).ToString());
			((ArrayList)features[num]).Add(thisFeature);
			System.Diagnostics.Debug.WriteLine("特徴["+num.ToString()+"]の個数は"+((ArrayList)features[num]).Count.ToString());
			MakeR((ArrayList)features[num], dgv);
			
			System.Diagnostics.Debug.WriteLine("ColorNo = " + mf.Setup.GetColorNo(cif.dispColor.Name).ToString());
			System.Diagnostics.Debug.WriteLine("Title = " + cif.Text);
			dgvLegendUpDownCheck(mf.Setup.GetColorNo(cif.dispColor.Name), System.IO.Path.GetFileNameWithoutExtension( cif.FileName) );
		}
		
		void DragDropAverage(AverageMaker avf, DataGridView dgv, int num)
		{
			//DataGridView用のデータを作成
			DataGridViewRow NewRow = new DataGridViewRow();
			NewRow.CreateCells(dgv);
			IntoDataGridViewRow(NewRow, avf.SrcBmpSmall, avf.FileName, dgv.Rows.Count + 1);
				
			//特徴クラスを作成してデータを挿入
			FeatureClass thisFeature = new FeatureClass();
			for(int i=0; i<thisFeature.Kajyu.Length; i++){
				thisFeature.Kajyu[i] = avf.AverageFeature.Kajyu[i];
				thisFeature.KajyuView[i] = avf.AverageFeature.KajyuView[i];
				//System.Diagnostics.Debug.WriteLine(i.ToString() + "," + thisFeature.Kajyu[i].ToString("F4"));
			}
			
			thisFeature.SrcBitmap = avf.SrcBmpSmall;
			thisFeature.FileName = avf.FileName;
			
			//コマンドマネージャへ
			//CheckUpDragInCommand command = new CheckUpDragInCommand(dgv.Rows, NewRow, feature[num], thisFeature);
			//undoManager.Action(command);
			dgv.Rows.Add(NewRow);
			
			((ArrayList)features[num]).Add(thisFeature);
			
			MakeR((ArrayList)features[num], dgv);
			
			dgvLegendUpDownCheck(0, "");
		}
		void DgvGroupDragDrop(object sender, DragEventArgs e)
		{
			int num = int.Parse(((DataGridView)sender).Name.Substring(8));
			num = num - 1;
			System.Diagnostics.Debug.WriteLine("Num="+num.ToString());
			if(e.Data.GetDataPresent(typeof(CharaImageForm))){
				MultiInputDialog mid = new MultiInputDialog();
				mid.ShowDialog();
				if( mid.DialogResult == DialogResult.Yes ){
					DragDropProc((CharaImageForm)e.Data.GetData(typeof(CharaImageForm)), (DataGridView)sender, num);
				}else if( mid.DialogResult == DialogResult.No){
					CharaImageForm cif;
					cif = (CharaImageForm)e.Data.GetData(typeof(CharaImageForm));
					//System.Diagnostics.Debug.WriteLine("Window個数="+mf.MdiChildren.Length.ToString());
					foreach (Form cdif in mf.MdiChildren) {
						if(cdif.Name == "CharaImageForm"){
							if(cif.Left == cdif.Left){
								CharaImageForm m_cif;
								m_cif = (CharaImageForm)cdif;
								DragDropProc(m_cif, (DataGridView)sender, num);
							}
						}
					}
				}
			}
			if(e.Data.GetDataPresent(typeof(AverageMaker))){
				DragDropAverage((AverageMaker)e.Data.GetData(typeof(AverageMaker)), (DataGridView)sender, num);
			}
		}
		
		void DgvGroupDragEnter(object sender, DragEventArgs e)
		{
			if(e.Data.GetDataPresent(typeof(CharaImageForm)) || e.Data.GetDataPresent(typeof(AverageMaker))){
				e.Effect = DragDropEffects.Copy;
			}else{
				e.Effect = DragDropEffects.None;
			}
			
		}
		#endregion
		
		#region ひとつ上へボタン処理
		void UpDownButtonProc(DataGridView dgv, ArrayList feature, int CurrentIndex, int NextIndex)
		{
			//DataGridViewを入れ替え
			string _filename;
			Bitmap _bmp;
			string _r;
				
			_bmp = (Bitmap)dgv.Rows[CurrentIndex].Cells[1].Value;
			_filename = (string)dgv.Rows[CurrentIndex].Cells[2].Value;
			_r = (string)dgv.Rows[CurrentIndex].Cells[3].Value;
			
			dgv.Rows[CurrentIndex].Cells[1].Value = dgv.Rows[NextIndex].Cells[1].Value;
			dgv.Rows[CurrentIndex].Cells[2].Value = dgv.Rows[NextIndex].Cells[2].Value;
			dgv.Rows[CurrentIndex].Cells[3].Value = dgv.Rows[NextIndex].Cells[3].Value;
				
			dgv.Rows[NextIndex].Cells[1].Value = _bmp;
			dgv.Rows[NextIndex].Cells[2].Value = _filename;
			dgv.Rows[NextIndex].Cells[3].Value = _r;
			
			dgv.CurrentCell = dgv[0, NextIndex];
			//featuresを入れ替え
			FeatureClass fc = new FeatureClass();
			fc = (FeatureClass)feature[CurrentIndex];
			feature[CurrentIndex] = feature[NextIndex];
			feature[NextIndex] = fc;
		}
		#endregion
		
		#region 削除ボタン処理
		void DeleteButtonProc(DataGridView dgv, ArrayList feature, int CurrentIndex)
		{
			//DataGridViewを削除
			dgv.Rows.RemoveAt(CurrentIndex);
			//featureを削除
			feature.RemoveAt(CurrentIndex);
			MakeR(feature, dgv);
			dgvLegendUpDownCheck(0, "");
		}
		#endregion
		
		#region ひとつ上へボタン
		void BtnUpClick(object sender, EventArgs e)
		{
			int num = int.Parse(((Button)sender).Name.Substring(5));
			num = num - 1;
			if(((DataGridView)DataGridViews[num]).CurrentRow != null){
				if(((DataGridView)DataGridViews[num]).CurrentRow.Index > 0){
					UpDownButtonProc((DataGridView)DataGridViews[num], (ArrayList)features[num], ((DataGridView)DataGridViews[num]).CurrentRow.Index, ((DataGridView)DataGridViews[num]).CurrentRow.Index - 1);
				}
			}
		}
		
		#endregion
		
		#region ひとつ下へボタン
		void BtnDownClick(object sender, EventArgs e)
		{
			int num = int.Parse(((Button)sender).Name.Substring(7));
			num = num - 1;
			if(((DataGridView)DataGridViews[num]).CurrentRow != null){
				if(((DataGridView)DataGridViews[num]).CurrentRow.Index < ((DataGridView)DataGridViews[num]).Rows.Count - 1){
					UpDownButtonProc((DataGridView)DataGridViews[num], (ArrayList)features[num], ((DataGridView)DataGridViews[num]).CurrentRow.Index, ((DataGridView)DataGridViews[num]).CurrentRow.Index + 1);
				}
			}
			
		}
		#endregion
		
		#region 削除ボタン
		void BtnDeleteClick(object sender, EventArgs e)
		{
			int num = int.Parse(((Button)sender).Name.Substring(9));
			num = num - 1;
			if(((DataGridView)DataGridViews[num]).CurrentRow != null){
				DeleteButtonProc((DataGridView)DataGridViews[num], (ArrayList)features[num],  ((DataGridView)DataGridViews[num]).CurrentRow.Index);
			}
		}
		#endregion
		
		#region 左へボタン
		void BtnLeftClick(object sender, EventArgs e)
		{
			int num = int.Parse(((Button)sender).Name.Substring(7));
			num = num - 1;
			if(num < 1){
				return;
			}
			TextBox tmpTxtChara;
			Label tmpLblChara;
			CheckBox tmpChkDelete;
			DataGridView tmpDgv;
			ArrayList tmpFeature;
			
			//Tmpに退避
			tmpTxtChara = (TextBox)txtCharas[num];
			tmpLblChara = (Label)lblCharas[num];
			tmpChkDelete = (CheckBox)chkDeletes[num];
			tmpDgv = (DataGridView)DataGridViews[num];
			tmpFeature = (ArrayList)features[num];
			
			//左のグループを右へ
			txtCharas[num] = txtCharas[num - 1];
			lblCharas[num] = lblCharas[num - 1];
			chkDeletes[num] = chkDeletes[num - 1];
			DataGridViews[num] = DataGridViews[num - 1];
			features[num] = features[num - 1];
						
			//Tmpを左のグループへ
			txtCharas[num - 1] = tmpTxtChara;
			lblCharas[num - 1] = tmpLblChara;
			chkDeletes[num - 1] = tmpChkDelete;
			DataGridViews[num - 1] = tmpDgv;
			features[num - 1] = tmpFeature;
			
			//Location,Nameを元に戻す
			Point lcTxtCharas;
			Point lcLblCharas;
			Point lcChkDeletes;
			Point lcDgv;
			string tmpTxtCharaName;
			string tmpLblCharaName;
			string tmpLblCharaText;
			string tmpChkDeleteName;
			string tmpDgvName;
			
			//tmpに退避
			string lbl1Name = ((Label)lblCharas[num-1]).Name;
			string lbl1Text = ((Label)lblCharas[num-1]).Text;
			string lbl2Name = ((Label)lblCharas[num]).Name;
			string lbl2Text = ((Label)lblCharas[num]).Text;
			
			System.Diagnostics.Debug.WriteLine(lbl1Text + "[" + lbl1Name +"]  →  "+lbl2Text+"["+lbl2Name+"]");
			lcTxtCharas = ((TextBox)txtCharas[num]).Location;
			lcLblCharas = ((Label)lblCharas[num]).Location;
			lcChkDeletes = ((CheckBox)chkDeletes[num]).Location;
			lcDgv = ((DataGridView)DataGridViews[num]).Location;
			tmpTxtCharaName = ((TextBox)txtCharas[num]).Name;
			tmpLblCharaName = ((Label)lblCharas[num]).Name;
			tmpLblCharaText = ((Label)lblCharas[num]).Text;
			tmpChkDeleteName = ((CheckBox)chkDeletes[num]).Name;
			tmpDgvName = ((DataGridView)DataGridViews[num]).Name;
			
			//左のグループを右へ
			((TextBox)txtCharas[num]).Location = ((TextBox)txtCharas[num - 1]).Location;
			((Label)lblCharas[num]).Location = ((Label)lblCharas[num - 1]).Location;
			((CheckBox)chkDeletes[num]).Location = ((CheckBox)chkDeletes[num - 1]).Location;
			((DataGridView)DataGridViews[num]).Location = ((DataGridView)DataGridViews[num - 1]).Location;
			((TextBox)txtCharas[num]).Name = ((TextBox)txtCharas[num - 1]).Name;
			((Label)lblCharas[num]).Name = ((Label)lblCharas[num - 1]).Name;
			((Label)lblCharas[num]).Text = ((Label)lblCharas[num - 1]).Text;
			((CheckBox)chkDeletes[num]).Name = ((CheckBox)chkDeletes[num - 1]).Name;
			((DataGridView)DataGridViews[num]).Name = ((DataGridView)DataGridViews[num - 1]).Name;
			
			//tmpを左のグループへ
			((TextBox)txtCharas[num - 1]).Location = lcTxtCharas;
			((Label)lblCharas[num - 1]).Location = lcLblCharas;
			((CheckBox)chkDeletes[num - 1]).Location = lcChkDeletes;
			((DataGridView)DataGridViews[num - 1]).Location = lcDgv;
			((TextBox)txtCharas[num - 1]).Name = tmpTxtCharaName;
			((Label)lblCharas[num - 1]).Name = tmpLblCharaName;
			((Label)lblCharas[num - 1]).Text = tmpLblCharaText;
			((CheckBox)chkDeletes[num - 1]).Name = tmpChkDeleteName;
			((DataGridView)DataGridViews[num - 1]).Name = tmpDgvName;
		}
		#endregion
		
		void DgvLegendCellEnter(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView dgv = (DataGridView)sender;
			
			if(dgv.Columns[e.ColumnIndex].Name == "Column3" && dgv.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn){
				SendKeys.Send("{F4}");
				
			}
			if(dgv.Columns[e.ColumnIndex].Name == "Column4" && dgv.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn){
				SendKeys.Send("{F4}");
			}
		}
		
		void DgvLegendCellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if(e.ColumnIndex > 1 && e.RowIndex < dgvLegend.Rows.Count && e.RowIndex >= 0){
				DataGridViewCell cell = dgvLegend.Rows[e.RowIndex].Cells[e.ColumnIndex];
				if(cell.Value == null || cell.Value.ToString() == ""){
					cell.Style.BackColor = Color.White;
				}else{
					cell.Style.BackColor = Setup.GetColorFromName(cell.Value.ToString());
					cell.Style.ForeColor = cell.Style.BackColor;
					
				}
			}
		}
		
		void dgvLegendUpDownCheck(int colorIndex,string DataName)
		{
			int max = 0;
			
			for(int j=0; j<GroupNum; j++){
				if(((DataGridView)DataGridViews[j]).Rows.Count > max) max = ((DataGridView)DataGridViews[j]).Rows.Count;
			}
			if(dgvLegend.Rows.Count > max){
				for(int i=0; i<dgvLegend.Rows.Count - max; i++){
					dgvLegend.Rows.RemoveAt(dgvLegend.Rows.Count - 1);
				}
			}
			
			if(dgvLegend.Rows.Count < max){
				for(int i=0; i<max - dgvLegend.Rows.Count; i++){
					
					dgvLegend.Rows.Add();
					/******ここですよ！！****/
					dgvLegend.Rows[dgvLegend.Rows.Count - 1].Cells[1].Value = DataName;
					
					DataGridViewComboBoxCell cbc1 = (DataGridViewComboBoxCell)dgvLegend.Rows[dgvLegend.Rows.Count - 1].Cells[2];
					DataGridViewComboBoxCell cbc2 = (DataGridViewComboBoxCell)dgvLegend.Rows[dgvLegend.Rows.Count - 1].Cells[3];
					cbc1.Value = cbc1.Items[colorIndex];
					cbc2.Value = cbc2.Items[colorIndex];
				}
			}
			for(int i=0; i<dgvLegend.Rows.Count; i++) dgvLegend.Rows[i].Cells[0].Value = (i+1).ToString();
		}
		
		#region グラフを作成
		void MakePlotData(IGraphPainter graph)
		{
			int i,j;
			for(i=0; i<dgvLegend.Rows.Count; i++){
				ISeriesLinePlot sr = graph.CreateSeries( DusGraph.ePlotType.Line ).asLine;
				if(dgvLegend.Rows[i].Cells[2].Value == null){
					sr.Pen = new Pen(Color.Blue, 5);
				}else{
					sr.Pen = new Pen(Setup.GetColorFromName(dgvLegend.Rows[i].Cells[2].Value.ToString()), 5);
				}
				sr.Mark.Visible = true;
				sr.Mark.Type    = DusGraph.ePlotMarkType.Circle;
				sr.Mark.Border.Visible = true;
				sr.Mark.Border.Pen = new Pen(Color.Black,2);
				if(dgvLegend.Rows[i].Cells[3].Value == null){
					sr.Mark.Brush   = new SolidBrush(Color.Blue);
				}else{
					sr.Mark.Brush   = new SolidBrush(Setup.GetColorFromName(dgvLegend.Rows[i].Cells[3].Value.ToString()));
				}
				sr.Mark.Width   = 12;
				sr.Mark.Height  = 12;
				if(dgvLegend.Rows[i].Cells[1].Value == null){
					sr.Title = "";
				}else{
					sr.Title = dgvLegend.Rows[i].Cells[1].Value.ToString();
				}
				int num = 0;
				for(j=0; j<GroupNum; j++){
					//System.Diagnostics.Debug.WriteLine("Count:" + ((ArrayList)features[j]).Count.ToString() + " --- " + j.ToString() + "," + i.ToString());
					if(((ArrayList)features[j]).Count > i){
						FeatureClass fcd = new FeatureClass();
						fcd = (FeatureClass)((ArrayList)features[j])[i];
						sr.Data.Add( new ST_PlotPoint( num, fcd.R));
						//System.Diagnostics.Debug.WriteLine("[" + num.ToString() + "]" + fcd.R.ToString());
						num++;
						
					}
				}
				graph.Series.Add(sr);
			}
		}
		
		private double GetMinimun()
		{
			int j;
			double min = 100.0;
			for(j=0; j<GroupNum; j++){
				foreach(FeatureClass fcd in (ArrayList)features[j]){
					if(fcd.R < min) min = fcd.R;
				}
			}
			return(min);
		}
		//Y軸の設定
		void MakeYAxis(IGraphPainter graph)
		{
			double Min;
			double MinorInterval, MajorInterval;
			double ScaleMin;
			Min = GetMinimun();
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
			//System.Diagnostics.Debug.WriteLine("MajorInterval:" + MajorInterval.ToString());
			//System.Diagnostics.Debug.WriteLine("MinorInterval:" + MinorInterval.ToString());
			//System.Diagnostics.Debug.WriteLine("ScaleMin:" + ScaleMin.ToString());
			IAxis axis;
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
			int i;
			XScale = 0;
			foreach(ArrayList f in features){
				if(f.Count > 0)XScale++;
			}
			
			ST_TickLabelPoint [] labelPoints = new ST_TickLabelPoint [XScale];
			
			i = 0;
			for(int j=0; j<GroupNum; j++){
				if(((ArrayList)(features[j])).Count > 1){
					if(((TextBox)txtCharas[j]).Text == null) labelPoints[i] = new ST_TickLabelPoint(j, "");
					else labelPoints[j] = new ST_TickLabelPoint(j, ((TextBox)txtCharas[j]).Text);
				}
			}
			
			IAxis  axis;
			axis = graph.XAxis;
			axis.Ticks.Labels.LabelFormat = "0";
			axis.Ticks.Labels.Interval    = 1;
			axis.Ticks.Labels.Points.AddRange( labelPoints );
			axis.Ticks.Labels.Font        = new Font( "ＭＳ 明朝", 14, FontStyle.Bold );
			axis.Ticks.Major.Visible    = false;
			axis.Ticks.Major.Interval   = 1;
			axis.Grid.Major.Visible     = false;
			axis.Grid.Major.Interval    = 1;
			axis.Scale.Min =  0;
			axis.Scale.Max =  XScale - 1;
			axis.Scale.Base = 0;
			//System.Diagnostics.Debug.WriteLine((XScale-1).ToString());
		}
		void MakeGraph()
		{
			
			imageEffect.BitmapWhitening(GraphBmp);
			
			IGraphPainter  graph = DusGraph.CreateGraph( 570, 360 );

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
			
			graph.Legend.Visible = true;
			graph.Legend.Location = new PointF( 415, 40 );
			graph.Legend.Size     = new SizeF( 150, 300 );
			graph.Legend.ItemArea.BaseLocation = new PointF( 5, 20 );
			graph.Legend.ItemArea.ItemSize     = new SizeF( 140, 20 );
			
			//Y軸の設定
			MakeYAxis(graph);
			
			//X軸の設定
			MakeXAxis(graph);
			
			//データをプロット
			MakePlotData(graph);
			
			//グラフを生成
			graph.Draw();
			
			Graphics g = Graphics.FromImage(GraphBmp);
			g.DrawImage(graph.Image, 0, 0);
			g.Dispose();
		}
		#endregion
		
		#region グラフウィンドウを生成する
		void ShowGraphWindow()
		{
			//グラフ表示画面を出力
			IntraindividualGraph igf = new IntraindividualGraph();
			igf.MdiParent = this.MdiParent;
			igf.Ivf = this;
			imageEffect.BitmapCopy(GraphBmp, igf.ViewBitmap);
			
			
			//データ表の出力
			int i;
			igf.dgvColsAdd("色", 20);
			igf.dgvColsAdd("項目名", 70);
			for(i=0; i<dgvLegend.Rows.Count; i++){
				string Title;
				Color c;
				if(dgvLegend.Rows[i].Cells[1].Value == null){
					Title = "";
				}else{
					Title = (string)dgvLegend.Rows[i].Cells[1].Value;
				}
				if(dgvLegend.Rows[i].Cells[2].Value == null){
					c = Color.Blue;
				}else{
					c = Setup.GetColorFromName((string)dgvLegend.Rows[i].Cells[2].Value);
				}
				igf.dgvRowsAdd(Title, c);
				igf.dgvCellBackColor(i, 0, c);
			}
			int num = 0;
			for(i=0; i<GroupNum; i++){
				if(((ArrayList)features[i]).Count > 0){
					string Title = ((TextBox)txtCharas[i]).Text;
					igf.dgvColsAdd(Title, 70);
					int j = 0;
					foreach(FeatureClass fcd in (ArrayList)features[i]){
						Color c;
						if(dgvLegend.Rows[j].Cells[2].Value == null){
							c = Color.Blue;
						}else{
							c = Setup.GetColorFromName((string)dgvLegend.Rows[j].Cells[2].Value);
						}
						igf.dgvDataAdd(j, num + 2, fcd.R.ToString("F4"), c);
						j++;
					}
					num++;
				}
			}
			igf.SetFirstActiveCell();
			igf.TxtCommentSet(txtComment.Text);
			igf.Show();
			
		}
		#endregion
		
		#region グラフ作成ボタン
		void BtnMakeGraphClick(object sender, EventArgs e)
		{
			MakeGraph();
			ShowGraphWindow();
		}
		#endregion
		
		#region 名前をつけて保存
		void BtnSaveAsClick(object sender, EventArgs e)
		{
			if(saveFileDlg.ShowDialog() == DialogResult.OK){
				fileName = saveFileDlg.FileName;
				SaveCIVFile();
			}
		}
		#endregion
		
		#region 保存処理
		void SaveCIVFile()
		{
			if(fileName == "" || fileName == null)return;
			FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
			BinaryFormatter bf = new BinaryFormatter();
			string VerName = VersionName;
			
			bf.Serialize(fs, VerName);
			bf.Serialize(fs, txtComment.Text);
			bf.Serialize(fs, features);
			bf.Serialize(fs, dgvLegend.Rows.Count);
			for(int i=0; i<dgvLegend.Rows.Count; i++){
				for(int j=0; j<dgvLegend.Columns.Count; j++){
					if(dgvLegend.Rows[i].Cells[j].Value == null) bf.Serialize(fs, "");
					else bf.Serialize(fs, dgvLegend.Rows[i].Cells[j].Value);
				}
			}
			bf.Serialize(fs, GroupNum);
			for(int i=0; i<txtCharas.Count; i++){
				bf.Serialize(fs, ((TextBox)txtCharas[i]).Text);
			}
			
			fs.Close();
			
			//最近使ったファイルに追加してもらう
			//MainForm mf = (MainForm)this.MdiParent;
			mf.AddRecentlyFile(fileName);
		}
		#endregion
		
		#region featuresをDataGridViewに反映
		void ArrayToGridView()
		{
			//System.Diagnostics.Debug.WriteLine("features.count = " + features.Count.ToString());
			for(int i=0; i<features.Count; i++){
				//DataGridViewに追加
				//System.Diagnostics.Debug.WriteLine("features.count = " + ((ArrayList)features[i]).Count.ToString());
				foreach(FeatureClass fc in (ArrayList)features[i]){
					((DataGridView)DataGridViews[i]).Rows.Add();
					((DataGridView)DataGridViews[i]).Rows[((DataGridView)DataGridViews[i]).Rows.Count - 1].Height = 50;				
					((DataGridView)DataGridViews[i]).Rows[((DataGridView)DataGridViews[i]).Rows.Count - 1].Cells[0].Value = ((DataGridView)DataGridViews[i]).Rows.Count.ToString();
					((DataGridView)DataGridViews[i]).Rows[((DataGridView)DataGridViews[i]).Rows.Count - 1].Cells[1].Value = fc.SrcBitmap;
					((DataGridView)DataGridViews[i]).Rows[((DataGridView)DataGridViews[i]).Rows.Count - 1].Cells[2].Value = Path.GetFileName(fc.FileName);
					((DataGridView)DataGridViews[i]).Rows[((DataGridView)DataGridViews[i]).Rows.Count - 1].Cells[3].Value = fc.R.ToString("F4");
				}
			}
			
		}
		#endregion
		
		#region 読み込み処理
		public void OpenCIVFile()
		{
    		if(fileName == "" || fileName == null)return;
			//個人内変動ファイルを開く
			FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
			BinaryFormatter bf = new BinaryFormatter();
			string VerName;
			string sComment;
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
			
			sComment = (string)bf.Deserialize(fs);
			txtComment.Text = sComment;
			//panel内をきれいにする
			for(int i=0; i<chkDeletes.Count; i++){
				((CheckBox)chkDeletes[i]).Checked = true;
			}
			DeleteControl();
			
			features.Clear();
			
			int Count;
			features = (ArrayList)bf.Deserialize(fs);
			Count = (int)bf.Deserialize(fs);
			dgvLegend.Rows.Clear();
			for(int i=0; i<Count; i++){
				dgvLegend.Rows.Add();
				for(int j=0; j<dgvLegend.Columns.Count; j++){
					if(j > 1){
						dgvLegend.Rows[i].Cells[j].Value = Setup.CheckColorName((string)bf.Deserialize(fs));
					}else{
						dgvLegend.Rows[i].Cells[j].Value = (object)bf.Deserialize(fs);
					}
					
				}
			}
			
			int num = (int)bf.Deserialize(fs);
			for(int i=0; i<num; i++){
				AddControl();
				((TextBox)txtCharas[i]).Text = (string)bf.Deserialize(fs);
			}
			
			fs.Close();
			
			ArrayToGridView();
			
			//最近使ったファイルに追加してもらう
			//MainForm mf = (MainForm)this.MdiParent;
			mf.AddRecentlyFile(fileName);
		}
		#endregion
		
		#region ツールバーボタン軍
		void BtnOpenClick(object sender, EventArgs e)
		{
			if(openFileDlg.ShowDialog() == DialogResult.OK){
				if(System.IO.Path.GetExtension(openFileDlg.FileName) == ".civ"){
					FileName = openFileDlg.FileName;
					OpenCIVFile();
				}else{
					MessageBox.Show("個人内変動データではありません。ファイルを確認してください", "CharacomImagerPro",MessageBoxButtons.OK, MessageBoxIcon.Error);
					
				}
			}
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
			SaveCIVFile();
		}
		
		void BtnUndoClick(object sender, EventArgs e)
		{
			
		}
		
		void BtnRedoClick(object sender, EventArgs e)
		{
			
		}
		
		public void BtnPrintClick(object sender, EventArgs e)
		{
			if(printDlg.ShowDialog() == DialogResult.OK){
				printDocument.PrinterSettings.Copies = printDlg.PrinterSettings.Copies;
				printDocument.Print();
			}
		}
		
		public void BtnPreviewClick(object sender, EventArgs e)
		{
			printDocument.PrinterSettings.Copies = 1;
			printPreviewDlg.StartPosition = FormStartPosition.CenterParent;
			printPreviewDlg.ShowDialog();
		}
		#endregion
		
		#region ウィンドウサイズの変更
		void IntraindividualVariationFormSizeChanged(object sender, EventArgs e)
		{
			panel1.Width = this.Width - 300 - 20;
			panel1.Height = this.Height - 75 - 100;
			txtComment.Location = new Point(txtComment.Location.X, this.Height - 145);
		}
		#endregion
		
		#region パネルサイズの変更
		void Panel1SizeChanged(object sender, EventArgs e)
		{
			btnMakeGraph.Location = new Point(btnMakeGraph.Location.X, this.Height - 195);
			dgvLegend.Height = panel1.Height - 80;
			for(int i=0; i<GroupNum; i++){
				((Button)btnUps[i]).Location = new Point(((Button)btnUps[i]).Location.X, panel1.Height - 50);
				((Button)btnDowns[i]).Location = new Point(((Button)btnDowns[i]).Location.X, panel1.Height - 50);
				((Button)btnDeletes[i]).Location = new Point(((Button)btnDeletes[i]).Location.X, panel1.Height - 50);
				((DataGridView)DataGridViews[i]).Height = panel1.Height - 80;
			}
		}
		#endregion
		
		#region DataGridViewを追加する
		void AddControl()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntraindividualVariationForm));
			this.panel1.SizeChanged -= new System.EventHandler(this.Panel1SizeChanged);
			
			#region DataGridViewを追加する
			DataGridViewTextBoxColumn Nos = new DataGridViewTextBoxColumn();
			DataGridViewImageColumn Images = new DataGridViewImageColumn();
			DataGridViewTextBoxColumn Addresses = new DataGridViewTextBoxColumn();
			DataGridViewTextBoxColumn Checks = new DataGridViewTextBoxColumn();
			// No
			Nos.HeaderText = "No.";
			Nos.Name = "No";
			Nos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			Nos.Width = 30;
			// Image
			Images.HeaderText = "イメージ";
			Images.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
			Images.Name = "Image";
			Images.Width = 50;
			// Address
			Addresses.HeaderText = "ファイル名";
			Addresses.Name = "Address";
			Addresses.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			Addresses.Width = 90;
			// Check
			Checks.HeaderText = "類似度";
			Checks.Name = "Check";
			Checks.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			Checks.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			Checks.Width = 50;
			
			DataGridView dgv = new DataGridView();
			dgv.AllowDrop = true;
			dgv.AllowUserToAddRows = false;
			dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									Nos,
									Images,
									Addresses,
									Checks});
			dgv.Location = new System.Drawing.Point(3+GroupNum*230 - panel1.HorizontalScroll.Value, 23 - panel1.VerticalScroll.Value);
			dgv.Name = "dgvGroup" + (GroupNum+1).ToString();
			dgv.RowHeadersVisible = false;
			dgv.RowTemplate.Height = 80;
			dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			dgv.Size = new System.Drawing.Size(225, panel1.Height - 80);
			dgv.TabIndex = 1;
			dgv.DragEnter += new System.Windows.Forms.DragEventHandler(this.DgvGroupDragEnter);
			dgv.DragDrop += new System.Windows.Forms.DragEventHandler(this.DgvGroupDragDrop);
			panel1.Controls.Add(dgv);
			DataGridViews.Add(dgv);
			#endregion
			
			#region チェックボックスを追加する
			CheckBox chkDelete = new CheckBox();
			chkDelete.Text = "";
			chkDelete.Name = "chkDelete" + (GroupNum + 1).ToString();
			chkDelete.Size = new Size(19, 19);
			chkDelete.Location = new Point(30+GroupNum*230 - panel1.HorizontalScroll.Value, 2 - panel1.VerticalScroll.Value);
			chkDeletes.Add(chkDelete);
			panel1.Controls.Add(chkDelete);
			#endregion
			
			#region テキストボックスを追加する
			Label label = new Label();
			label.Text = "文字種" + (GroupNum+1).ToString();
			label.Name = "lblChara" + (GroupNum+1).ToString();
			label.Size = new Size(51, 13);
			label.Location = new Point(68+GroupNum*230 - panel1.HorizontalScroll.Value, 5 - panel1.VerticalScroll.Value);
			lblCharas.Add(label);
			panel1.Controls.Add(label);
			
			TextBox txtChara = new TextBox();
			txtChara.Size = new Size(50, 19);
			txtChara.Location = new Point(125+GroupNum*230 - panel1.HorizontalScroll.Value, 2 - panel1.VerticalScroll.Value);
			panel1.Controls.Add(txtChara);
			txtCharas.Add(txtChara);
			#endregion
			
			#region ボタン類(上へ、削除、下へ、右へ、左へ)を追加する
			//2013.11.10 右へ左へを追加
			//D.Honjyou
			Button btnUp = new Button();
			Button btnDown = new Button();
			Button btnDelete = new Button();
			Button btnLeft = new Button();
			Button btnRight = new Button();
			
			// btnDelete
			//btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
			btnDelete.Image = imageList1.Images[2];
			btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btnDelete.Location = new System.Drawing.Point(84+GroupNum*230 - panel1.HorizontalScroll.Value, panel1.Height - 50 - panel1.VerticalScroll.Value);
			btnDelete.Name = "btnDelete" + (GroupNum+1).ToString();
			btnDelete.Size = new System.Drawing.Size(63, 23);
			btnDelete.TabIndex = 8;
			btnDelete.Text = "削除";
			btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			btnDelete.UseVisualStyleBackColor = true;
			btnDelete.Click += new System.EventHandler(this.BtnDeleteClick);
			btnDeletes.Add(btnDelete);
			// btnDown
			//btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
			btnDown.Image = imageList1.Images[1];
			btnDown.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			btnDown.Location = new System.Drawing.Point(153+GroupNum*230 - panel1.HorizontalScroll.Value, panel1.Height - 50 - panel1.VerticalScroll.Value);
			btnDown.Name = "btnDown" + (GroupNum+1).ToString();
			btnDown.Size = new System.Drawing.Size(75, 23);
			btnDown.TabIndex = 7;
			btnDown.Text = "ひとつ下へ";
			btnDown.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btnDown.UseVisualStyleBackColor = true;
			btnDown.Click += new System.EventHandler(this.BtnDownClick);
			btnDowns.Add(btnDown);
			// btnUp
			//btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
			btnUp.Image = imageList1.Images[0];
			btnUp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btnUp.Location = new System.Drawing.Point(3+GroupNum*230 - panel1.HorizontalScroll.Value, panel1.Height - 50 - panel1.VerticalScroll.Value);
			btnUp.Name = "btnUp" + (GroupNum+1).ToString();
			btnUp.Size = new System.Drawing.Size(75, 23);
			btnUp.TabIndex = 6;
			btnUp.Text = "ひとつ上へ";
			btnUp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			btnUp.UseVisualStyleBackColor = true;
			btnUp.Click += new System.EventHandler(this.BtnUpClick);
			btnUps.Add(btnUp);
			// btnLeft
			if(GroupNum != 0){
				btnLeft.Image = imageList1.Images[3];
				btnLeft.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
				btnLeft.Location = new System.Drawing.Point(3+GroupNum*230 - panel1.HorizontalScroll.Value, 2 - panel1.VerticalScroll.Value);
				btnLeft.Name = "btnLeft" + (GroupNum+1).ToString();
				btnLeft.Size = new System.Drawing.Size(20, 20);
				btnLeft.TabIndex = 9;
				btnLeft.Text = "";
				btnLeft.UseVisualStyleBackColor = true;
				btnLeft.Click += new System.EventHandler(this.BtnLeftClick);
				btnLefts.Add(btnLeft);
			}
			/**
			// btnRight
			btnRight.Image = imageList1.Images[4];
			btnRight.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			btnRight.Location = new System.Drawing.Point(207+GroupNum*230 - panel1.HorizontalScroll.Value, 2 - panel1.VerticalScroll.Value);
			btnRight.Name = "btnRight" + (GroupNum+1).ToString();
			btnRight.Size = new System.Drawing.Size(20, 20);
			btnRight.TabIndex = 10;
			btnRight.Text = "";
			btnRight.UseVisualStyleBackColor = true;
			btnRight.Click += new System.EventHandler(this.BtnRightClick);
			btnRights.Add(btnRight);
			**/
			
			panel1.Controls.Add(btnUp);
			panel1.Controls.Add(btnDown);
			panel1.Controls.Add(btnDelete);
			if(GroupNum != 0 )panel1.Controls.Add(btnLeft);
			//panel1.Controls.Add(btnRight);
			#endregion
			
			GroupNum++;
			this.panel1.SizeChanged += new System.EventHandler(this.Panel1SizeChanged);
			
		}
		#endregion
		
		#region DataGridViewを削除する
		void DeleteControl()
		{
			if(GroupNum < 1)return;
			//2013.11.10 チェックボックスを作り、チェックボックスの付いた欄を削除するように変更
			//D.Honjyou
			this.panel1.SizeChanged -= new System.EventHandler(this.Panel1SizeChanged);
			int i,j;
			
			for(i=GroupNum -1; i>=0; i--){
				if(((CheckBox)chkDeletes[i]).Checked == true){
					//MessageBox.Show( i.ToString() );
					for(j=GroupNum-1; j>i; j--){
						//そこから後ろのchk,lbl,txt,dgvを左に移動
						((CheckBox)chkDeletes[j]).Location = ((CheckBox)chkDeletes[j - 1]).Location;
						((Label)lblCharas[j]).Location = ((Label)lblCharas[j - 1]).Location;
						((TextBox)txtCharas[j]).Location = ((TextBox)txtCharas[j - 1]).Location;
						((DataGridView)DataGridViews[j]).Location = ((DataGridView)DataGridViews[j - 1]).Location;
						//Name,Textをひとつずつ右のものに変更
						((CheckBox)chkDeletes[j]).Name = ((CheckBox)chkDeletes[j - 1]).Name;
						((Label)lblCharas[j]).Name = ((Label)lblCharas[j - 1]).Name;
						((Label)lblCharas[j]).Text = ((Label)lblCharas[j - 1]).Text;
						((TextBox)txtCharas[j]).Name = ((TextBox)txtCharas[j - 1]).Name;
						((DataGridView)DataGridViews[j]).Name = ((DataGridView)DataGridViews[j - 1]).Name;
						
					}	
					//もともとの位置のchk,lbl,txt,dgvを削除
					((CheckBox)chkDeletes[i]).Dispose();
					chkDeletes.RemoveAt(i);
					((Label)lblCharas[i]).Dispose();
					lblCharas.RemoveAt(i);
					((TextBox)txtCharas[i]).Dispose();
					txtCharas.RemoveAt(i);
					((DataGridView)DataGridViews[i]).Dispose();
					DataGridViews.RemoveAt(i);
					//特徴データを削除
					features.RemoveAt(i);
			
					//ボタン類を削除
					((Button)btnUps[btnUps.Count - 1]).Dispose();
					btnUps.RemoveAt(btnUps.Count - 1);
					((Button)btnDowns[btnDowns.Count - 1]).Dispose();
					btnDowns.RemoveAt(btnDowns.Count - 1);
					((Button)btnDeletes[btnDeletes.Count - 1]).Dispose();
					btnDeletes.RemoveAt(btnDeletes.Count - 1);
					if(btnLefts.Count > 0){
						((Button)btnLefts[btnLefts.Count - 1]).Dispose();
						btnLefts.RemoveAt(btnLefts.Count - 1);
					}
					//((Button)btnRights[btnRights.Count - 1]).Dispose();
					//btnRights.RemoveAt(btnRights.Count - 1);
					
					GroupNum--;
				}
			}
			/**
			//DataGridViewを削除
			((DataGridView)DataGridViews[DataGridViews.Count - 1]).Dispose();
			DataGridViews.RemoveAt(DataGridViews.Count - 1);
			//特徴データを削除
			features.RemoveAt(features.Count - 1);
			//テキストボックスを削除
			((TextBox)txtCharas[txtCharas.Count - 1]).Dispose();
			txtCharas.RemoveAt(txtCharas.Count - 1);
			
			//ラベルを削除
			((Label)lblCharas[lblCharas.Count - 1]).Dispose();
			lblCharas.RemoveAt(lblCharas.Count - 1);
			
			//ボタン類を削除
			((Button)btnUps[btnUps.Count - 1]).Dispose();
			btnUps.RemoveAt(btnUps.Count - 1);
			((Button)btnDowns[btnDowns.Count - 1]).Dispose();
			btnDowns.RemoveAt(btnDowns.Count - 1);
			((Button)btnDeletes[btnDeletes.Count - 1]).Dispose();
			btnDeletes.RemoveAt(btnDeletes.Count - 1);
			GroupNum--;
			
			**/
			this.panel1.SizeChanged += new System.EventHandler(this.Panel1SizeChanged);
			
		}
		#endregion
		
		
		void BtnAddClick(object sender, EventArgs e)
		{
			AddControl();
			features.Add(new ArrayList());
			
		}
		
		void BtnDelClick(object sender, EventArgs e)
		{
			DeleteControl();
		}
		
		
		//コメントを印刷
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
		    
		    System.Diagnostics.Debug.WriteLine("[" + printingText + "]");
		    System.Diagnostics.Debug.WriteLine("printingText.Length = " + printingText.Length.ToString());
		    System.Diagnostics.Debug.WriteLine("printingPosition = " + printingPosition.ToString());
		    
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
		
		#region 印刷処理
		void PrintDocumentPrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			printDocument.DocumentName = "CharacomPro[個人内変動]";
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
			
			PrintParts pp = new PrintParts();
			Rectangle rhf = pp.HeaderFooterDraw(e);
			BodySY = rhf.Y;
			BodyEY = rhf.Bottom;
			
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
			//タイトルを作成
			Font TitleF = new Font("メイリオ", 16, FontStyle.Bold);
			e.Graphics.DrawString("■数値解析処理結果報告書", TitleF, Brushes.Black, sx, BodySY + MarginY);
			
			//グラフ画像を作成
			MakeGraph();
			Bitmap b = new Bitmap(GraphBmp.Width, GraphBmp.Height);
			imageEffect.BitmapCopy(GraphBmp, b);
			//imageEffect.BitmapDrawFrame(b);
			x = sx; y = BodySY+MarginY+TitleF.Height+MarginY;
			e.Graphics.DrawImage(b, x, y, b.Width, b.Height);
			//e.Graphics.DrawRectangle(Pens.Blue, 0, 0, ViewBitmap.Width, ViewBitmap.Height);
			
			//表を作成
			x = sx; y += b.Height + MarginY;
			e.Graphics.DrawString("■数値一覧", f, Brushes.Black, sx, y);
			y += f.Height + MarginY;			
			
			//列タイトル作成
			RectangleF rf;
			Rectangle r;
			int CharaNum = txtCharas.Count;
			int ColWidth = (ex - x)/(CharaNum * 2 + 4);
			StringFormat sf = new StringFormat();
			sf.Alignment = StringAlignment.Center;
			rf = new RectangleF( x + ColWidth*0, y, ColWidth*1, f.Height);
			r = new Rectangle( x + ColWidth*0, y, ColWidth*1, f.Height);
			e.Graphics.DrawString("色", f, Brushes.Black, rf, sf);
			e.Graphics.DrawRectangle(Pens.Black, r);
			rf = new RectangleF( x + ColWidth*1, y, ColWidth*3, f.Height);
			r = new Rectangle( x + ColWidth*1, y, ColWidth*3, f.Height);
			e.Graphics.DrawString("項目名", f, Brushes.Black, rf, sf);
			e.Graphics.DrawRectangle(Pens.Black, r);
			int i = 0;
			foreach(TextBox tChara in txtCharas){
				rf = new RectangleF( x + ColWidth*(4+i*2), y, ColWidth*2, f.Height);
				r  = new Rectangle( x + ColWidth*(4+i*2), y, ColWidth*2, f.Height);
				e.Graphics.DrawString(tChara.Text, f, Brushes.Black, rf, sf);
				e.Graphics.DrawRectangle(Pens.Black, r);
				//System.Diagnostics.Debug.WriteLine(i.ToString() + "," + tChara.Text);
				i++;
			}
			y += f.Height;
			//内容の作成
			Color c;
			for(int j=0; j<dgvLegend.Rows.Count; j++){
				//色
				rf = new RectangleF( x + ColWidth*0, y, ColWidth*1, f.Height);
				r = new Rectangle( x + ColWidth*0, y, ColWidth*1, f.Height);
				if(dgvLegend.Rows[j].Cells[2].Value == null){
					c = Color.Blue;
				}else{
					c = Setup.GetColorFromName(dgvLegend.Rows[j].Cells[2].Value.ToString());
				}
				Brush brush = new SolidBrush(c);
				e.Graphics.FillRectangle(brush, rf);
				e.Graphics.DrawRectangle(Pens.Black, r);
				
				//項目名
				rf = new RectangleF( x + ColWidth*1, y, ColWidth*3, f.Height);
				r = new Rectangle( x + ColWidth*1, y, ColWidth*3, f.Height);
				e.Graphics.DrawString(dgvLegend.Rows[j].Cells[1].Value.ToString(), f, Brushes.Black, rf, sf);
				e.Graphics.DrawRectangle(Pens.Black, r);
				
				//個別文字のデータ
				for(i=0; i<GroupNum; i++){
					rf = new RectangleF( x + ColWidth*(4+i*2), y, ColWidth*2, f.Height);
					r  = new Rectangle( x + ColWidth*(4+i*2), y, ColWidth*2, f.Height);
					e.Graphics.DrawString(((DataGridView)DataGridViews[i]).Rows[j].Cells[3].Value.ToString(), f, Brushes.Black, rf, sf);
					e.Graphics.DrawRectangle(Pens.Black, r);
				}
				y += f.Height;
				
			}
			y += MarginY;
			
			if(_curPageNumber == 0){
				printingText = "";
				printingText = txtComment.Text;
				printingText = printingText.Replace("\r\n", "\n");
        		printingText = printingText.Replace("\r", "\n");
			}
			
			//コメントを印刷
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
		
		#region 特徴抽出法ラベルを表示
		void FeatureLabelPaint()
		{
			//MainForm mf = new MainForm();
			//mf = (MainForm)this.MdiParent;
			if(mf.Setup.Kajyu) label2.Text = "加重方向指数ヒストグラム特徴";
			else			   label2.Text = "背景伝搬法";
		}
		#endregion
		
		void Button1Click(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("features.count=" + features.Count.ToString());
			System.Diagnostics.Debug.WriteLine("GroupNum=" + GroupNum.ToString());

		}
		
		#region ウィンドウが開かれたら
		void IntraindividualVariationFormShown(object sender, EventArgs e)
		{
			//メインフォームにウィンドウリストを追加してもらう
			//MainForm mf = (MainForm)MdiParent;
			windowID = mf.AddWindowList(this.Name, fileName);
			this.Text = mf.GetWindowTitle(windowID);
		}
		#endregion
		
		#region ウィンドウが閉じられるときに
		void IntraindividualVariationFormFormClosing(object sender, FormClosingEventArgs e)
		{
			//メインフォームにウィンドウリストから削除してもらう
			//MainForm mf = (MainForm)this.MdiParent;
			mf.RemoveWindowAtID(windowID);
		}
		#endregion
		
		void IntraindividualVariationFormPaint(object sender, PaintEventArgs e)
		{
			FeatureLabelPaint();
		}
		
		void IntraindividualVariationFormLoad(object sender, EventArgs e)
		{
			SetColorTbl();
			
		}
		
		#region ウィンドウをコピー
		// 2020.08.30 D.Honjyou 三崎さんからの要望により追加
		void BtnCopyWindowClick(object sender, EventArgs e)
		{
			//フォームからスクリーンショットを撮る　
			Bitmap clipBmp = new Bitmap(this.Width, this.Height);
			this.DrawToBitmap(clipBmp, new Rectangle(0, 0, this.Width, this.Height));
			Clipboard.SetImage(clipBmp);
			
			clipBmp.Dispose();
		}
		#endregion
	}
}
