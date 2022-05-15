/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2012/02/06
 * 時刻: 15:50
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using Dustin.Utils;
using Dustin.Drawing;
using Dustin.Graph;
using System.Drawing.Drawing2D;

namespace CharacomImagerPro
{
	/// <summary>
	/// Description of FeatureForm.
	/// </summary>
	public partial class FeatureForm : Form
	{
		Bitmap srcBitmapSmall;
		Bitmap viewImageBmp;
		Bitmap viewFeatureBmp;
		Bitmap viewGraphBmp;
		
		double [] kajyu = new double[256];
		double [] kajyuView = new double[256];
		
		//親フォームの参照
		private MainForm mf;
		
		//private string fileName;
		/**
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
		**/
		public Bitmap SrcBitmapSmall {
			get { return srcBitmapSmall; }
			set { srcBitmapSmall = value; }
		}
		
		ImageEffect imageEffect = new ImageEffect();
		public FeatureForm(MainForm mainForm)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			mf = mainForm;
			srcBitmapSmall = new Bitmap(CharaImageForm.SmallWidth, CharaImageForm.SmallHeight);
			viewImageBmp = new Bitmap(imageBox.Width, imageBox.Height);
			viewFeatureBmp = new Bitmap(featureBox.Width, featureBox.Height);
			viewGraphBmp = new Bitmap(graphImage.Width, graphImage.Height);
			
			//FileNameのChanged イベントを追加
			//this.FileNameChanged += new EventHandler(this.OnFileNameChanged);
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		/*
		#region ファイル名が変更されたら
		void OnFileNameChanged(object sender, EventArgs e)
		{
			MainForm mf = (MainForm)this.MdiParent;
			mf.ChangeWindowListName(windowID, fileName);
			this.Text = mf.GetWindowTitle(windowID);
		}
		#endregion
		*/
		#region 無題をつける
		public void SetNonTitle()
		{
			//タイトル文にファイル名を反映
			//MainForm mf = (MainForm)this.MdiParent;
			//FileName = "無題" + mf.GetTitleNo(this.Name).ToString() + ".cfk";
			
		}
		#endregion
		
		#region グラフ作成
		double GetAllMax()
		{
			double max = 0.0;
			double sum;
			for(int n=0; n<4; n++){
				sum=0.0;
				for(int i=0; i<64; i++){
					sum += kajyu[n*64 + i];
					
				}
				if(max < sum) max = sum;
			}
			
			return(max);
		}
		
		void MakeYAxis(IGraphPainter graph)
		{
			IAxis  axis;
			double Max = 0.0;
			double MinorInterval, MajorInterval;
			double ScaleMax;
			Max = GetAllMax();
			
			MajorInterval = 500.0;
			MinorInterval = 100.0;
			
			ScaleMax = Math.Floor((Max / MinorInterval)+1) * MinorInterval;
			axis = graph.YAxis;
			axis.Scale.Min =  0.0;
			axis.Scale.Max =  ScaleMax;
			axis.Scale.Base = 0.0;
			axis.Ticks.Labels.LabelFormat = "0";
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
			XScale = 4;
			
			ST_TickLabelPoint [] labelPoints = new ST_TickLabelPoint [XScale];
			string [] houkou = new string[] {"(―)","(／)","(｜)","(＼)"};
			for(int i=0; i<XScale; i++){
				labelPoints[i] = new ST_TickLabelPoint(i, "方向" + (i+1).ToString() + houkou[i]);
			}
			
			IAxis  axis;
			
			axis = graph.XAxis;
			axis.Ticks.Labels.LabelFormat = "0";
			axis.Ticks.Labels.Interval    = 1;
			axis.Ticks.Major.Interval   = 1;
			axis.Ticks.Side             = DusGraph.eTickSide.Bottom;
			axis.Ticks.Labels.Points.AddRange( labelPoints );
			axis.Ticks.Labels.Font        = new Font( "ＭＳ ゴシック", 8, FontStyle.Bold );
			///axis.Ticks.Direction        = DusGraph.eTickDirection.Outside;
			axis.Grid.Major.Visible     = false;
			axis.Grid.Major.Interval    = 1;
			axis.Scale.Min =  0;
			axis.Scale.Max = XScale - 1;
			axis.Scale.Base = 0;
			
		}
		
		void MakePlotData(IGraphPainter graph)
		{
			ISeriesXYPlot  sr;		//棒グラフ用
			Color c;
			
			
			//棒グラフ
			c = Color.Blue;
			//棒グラフを作成
			sr = graph.CreateSeries( DusGraph.ePlotType.Bar).asXYPlot;
			sr.Title = "方向データ合計";
			sr.asBar.Brush = Brushes.Blue;
			sr.asBar.Border.Pen = Pens.Blue;
			sr.asBar.BarWidth = 20;
			Pen linePen = new Pen(c, 2);
			
			double sum;
			for(int n=0; n<4; n++){
				sum=0.0;
				for(int i=0; i<64; i++){
					sum += kajyu[n*64 + i];
				}
				sr.Data.Add( new ST_PlotPoint(n, sum) );
			}
			graph.Series.Add(sr);
		}
		public void MakeGraph()
		{
			imageEffect.BitmapWhitening(viewGraphBmp);
			
			IGraphPainter  graph = DusGraph.CreateGraph( viewGraphBmp.Width, viewGraphBmp.Height );
			
			#region グラフエリアの設定
			graph.SmoothingMode     = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			///graph.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
			graph.BackBrush = new LinearGradientBrush( graph.GetBounds(), Color.White, Color.LemonChiffon, LinearGradientMode.Vertical );
			graph.Border.Pen = new Pen( Color.Gray, 1 );
			graph.PlotArea.BackBrush = new LinearGradientBrush( graph.GetBounds(), Color.LightBlue, Color.White, LinearGradientMode.Vertical);
			graph.PlotArea.Border.Top.Pen       = Pens.Transparent;
			graph.PlotArea.Border.Right.Pen     = Pens.Silver;
			graph.PlotArea.Margin.Left   = 40;
			graph.PlotArea.Margin.Right  = 10;
			graph.PlotArea.Margin.Top    = 10;
			graph.PlotArea.Margin.Bottom = 20;
			graph.PlotArea.InnerMargin.Left  = 40;
			graph.PlotArea.InnerMargin.Right = 40;
			#endregion
			
			#region 凡例の設定
			graph.Legend.Visible = false;
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
			Graphics g = Graphics.FromImage(viewGraphBmp);
			g.FillRectangle(Brushes.White, 0, 0, viewGraphBmp.Width, viewGraphBmp.Height);
			g.DrawImage(graph.Image,0,0);
			
			g.Dispose();
			
			graphImage.Invalidate();
		}
		#endregion
		
		#region 特徴抽出実行(加重方向ヒストグラム特徴)
		public void MakeFeature()
		{
				
			imageEffect.Normalize(SrcBitmapSmall, 38.0);
			imageEffect.Noize(SrcBitmapSmall);
			imageEffect.BitmapCopy(srcBitmapSmall, viewImageBmp);
			imageEffect.GetKajyu(SrcBitmapSmall, kajyu, kajyuView, mf.Setup.CharaR);
			imageEffect.DrawEdgeFollowing(viewImageBmp, viewImageBmp, Color.Red);
			int i,j,k,n;
			int w,h;
			
			w = viewFeatureBmp.Width;
			h = viewFeatureBmp.Height;
			
			imageEffect.BitmapWhitening(viewFeatureBmp);
			for(i=0; i<4; i++){
				for(j=0; j<8; j++){
					if(i==0)dgvData1.Rows.Add();
					if(i==1)dgvData2.Rows.Add();
					if(i==2)dgvData3.Rows.Add();
					if(i==3)dgvData4.Rows.Add();
					for(k=0; k<8; k++){
						if(i==0){
							dgvData1.Rows[dgvData1.Rows.Count - 1].Cells[k].Value = kajyu[i*64 + j*8 + k].ToString("F2");
							for(n=0; n<kajyuView[i*64 + j*8 + k]; n++){
								viewFeatureBmp.SetPixel(k*w/8 + w/8/2 + n, j*h/8 + h/8/2, Color.Red);
							}
						}
						if(i==1){
							dgvData2.Rows[dgvData2.Rows.Count - 1].Cells[k].Value = kajyu[i*64 + j*8 + k].ToString("F2");
							for(n=0; n<kajyuView[i*64 + j*8 + k]; n++){
								viewFeatureBmp.SetPixel(k*w/8 + w/8/2 + n, j*h/8 + h/8/2 - n, Color.Red);
							}
						}
						if(i==2){
							dgvData3.Rows[dgvData3.Rows.Count - 1].Cells[k].Value = kajyu[i*64 + j*8 + k].ToString("F2");
							for(n=0; n<kajyuView[i*64 + j*8 + k]; n++){
								viewFeatureBmp.SetPixel(k*w/8 + w/8/2, j*h/8 + h/8/2 - n, Color.Red);
							}
						}
						if(i==3){
							dgvData4.Rows[dgvData4.Rows.Count - 1].Cells[k].Value = kajyu[i*64 + j*8 + k].ToString("F2");
							for(n=0; n<kajyuView[i*64 + j*8 + k]; n++){
								viewFeatureBmp.SetPixel(k*w/8 + w/8/2 - n, j*h/8 + h/8/2 - n, Color.Red);
							}
						}
					}
				}
			}
		}
		#endregion
		
		#region CSVまたはテキストへの出力
		void CSVorTXTSave(string FileName, bool isCSV)
		{
			string Split;
			System.Text.Encoding enc = System.Text.Encoding.GetEncoding("Shift_JIS");
			System.IO.StreamWriter sr = new System.IO.StreamWriter(FileName, false, enc);
			int i,j;
			if(isCSV == true) Split = ",";
			else			  Split = "\t";
			int lastColIndex = dgvData1.Columns.Count - 1;
			
			sr.WriteLine("Characom Imager Pro Export File for CSV(加重方向指数ヒストグラム特徴)");
			//改行する
			sr.Write("\r\n");
			
			//レコードを書き込む
			sr.WriteLine("方向1 (―)");
			for(i=0; i<dgvData1.Rows.Count; i++){
				for(j=0; j<dgvData1.Columns.Count; j++){
					string field = dgvData1.Rows[i].Cells[j].Value.ToString();
					//"で囲む必要があるか調べる
    				if(isCSV){
    					if (field.IndexOf('"') > -1 || field.IndexOf(',') > -1 || field.IndexOf('\r') > -1 || field.IndexOf('\n') > -1 || field.StartsWith(" ") || field.StartsWith("\t") || field.EndsWith(" ") || field.EndsWith("\t")){
        					if (field.IndexOf('"') > -1){
            					//"を""とする
            					field = field.Replace("\"", "\"\"");
        					}
     	   					field = "\"" + field + "\"";
    					}
    				}
    				//フィールドを書き込む
    				sr.Write(field);
    				//カンマを書き込む
    				if (lastColIndex > j){
        				sr.Write(Split);
    				}
				}
				//改行する
				sr.Write("\r\n");
			}
			sr.Write("\r\n");
			//レコードを書き込む
			sr.WriteLine("方向2 (／)");
			for(i=0; i<dgvData2.Rows.Count; i++){
				for(j=0; j<dgvData2.Columns.Count; j++){
					string field = dgvData2.Rows[i].Cells[j].Value.ToString();
					//"で囲む必要があるか調べる
    				if(isCSV){
    					if (field.IndexOf('"') > -1 || field.IndexOf(',') > -1 || field.IndexOf('\r') > -1 || field.IndexOf('\n') > -1 || field.StartsWith(" ") || field.StartsWith("\t") || field.EndsWith(" ") || field.EndsWith("\t")){
        					if (field.IndexOf('"') > -1){
            					//"を""とする
            					field = field.Replace("\"", "\"\"");
        					}
     	   					field = "\"" + field + "\"";
    					}
    				}
    				//フィールドを書き込む
    				sr.Write(field);
    				//カンマを書き込む
    				if (lastColIndex > j){
        				sr.Write(Split);
    				}
				}
				//改行する
				sr.Write("\r\n");
			}
			sr.Write("\r\n");
			//レコードを書き込む
			sr.WriteLine("方向3 (｜)");
			for(i=0; i<dgvData3.Rows.Count; i++){
				for(j=0; j<dgvData3.Columns.Count; j++){
					string field = dgvData3.Rows[i].Cells[j].Value.ToString();
					//"で囲む必要があるか調べる
    				if(isCSV){
    					if (field.IndexOf('"') > -1 || field.IndexOf(',') > -1 || field.IndexOf('\r') > -1 || field.IndexOf('\n') > -1 || field.StartsWith(" ") || field.StartsWith("\t") || field.EndsWith(" ") || field.EndsWith("\t")){
        					if (field.IndexOf('"') > -1){
            					//"を""とする
            					field = field.Replace("\"", "\"\"");
        					}
     	   					field = "\"" + field + "\"";
    					}
    				}
    				//フィールドを書き込む
    				sr.Write(field);
    				//カンマを書き込む
    				if (lastColIndex > j){
        				sr.Write(Split);
    				}
				}
				//改行する
				sr.Write("\r\n");
			}
			sr.Write("\r\n");
			//レコードを書き込む
			sr.WriteLine("方向4 (＼)");
			for(i=0; i<dgvData4.Rows.Count; i++){
				for(j=0; j<dgvData4.Columns.Count; j++){
					string field = dgvData4.Rows[i].Cells[j].Value.ToString();
					//"で囲む必要があるか調べる
    				if(isCSV){
    					if (field.IndexOf('"') > -1 || field.IndexOf(',') > -1 || field.IndexOf('\r') > -1 || field.IndexOf('\n') > -1 || field.StartsWith(" ") || field.StartsWith("\t") || field.EndsWith(" ") || field.EndsWith("\t")){
        					if (field.IndexOf('"') > -1){
            					//"を""とする
            					field = field.Replace("\"", "\"\"");
        					}
     	   					field = "\"" + field + "\"";
    					}
    				}
    				//フィールドを書き込む
    				sr.Write(field);
    				//カンマを書き込む
    				if (lastColIndex > j){
        				sr.Write(Split);
    				}
				}
				//改行する
				sr.Write("\r\n");
			}
			sr.Write("\r\n");
			sr.Close();
		}
		#endregion
		
		#region CSVファイルに保存
		void BtnCSVSaveClick(object sender, EventArgs e)
		{
			if(saveCSVFileDlg.ShowDialog() == DialogResult.OK){
				if(System.IO.Path.GetExtension(saveCSVFileDlg.FileName) == ".csv"){
					CSVorTXTSave(saveCSVFileDlg.FileName, true);
				}else if(System.IO.Path.GetExtension(saveCSVFileDlg.FileName) == ".txt"){
					CSVorTXTSave(saveCSVFileDlg.FileName, false);
				}
			}
		}
		#endregion
		
		void ImageBoxPaint(object sender, PaintEventArgs e)
		{
			Bitmap dBmp = new Bitmap(viewImageBmp.Width, viewImageBmp.Height);
			imageEffect.BitmapWhitening(dBmp);
			imageEffect.BitmapCopy(viewImageBmp, dBmp);
			imageEffect.BitmapDrawFrame(dBmp);
			if(btnGridLine.Checked == true) { 
				imageEffect.Draw8x8Line(dBmp, Color.LightGray);
				imageEffect.DrawCenterLine(dBmp, Color.Blue);
			}

			e.Graphics.DrawImage(dBmp,0,0);
			
		}
		
		void FeatureBoxPaint(object sender, PaintEventArgs e)
		{
			Bitmap dBmp = new Bitmap(viewFeatureBmp.Width, viewFeatureBmp.Height);
			imageEffect.BitmapWhitening(dBmp);
			imageEffect.BitmapCopy(viewFeatureBmp, dBmp);
			imageEffect.BitmapDrawFrame(dBmp);
			if (btnGridLine.Checked == true)
			{
				imageEffect.Draw8x8Line(dBmp, Color.LightGray);
				imageEffect.DrawCenterLine(dBmp, Color.Blue);
			}
			e.Graphics.DrawImage(dBmp, 0,0);
		}
		
		#region ウィンドウが開かれたら
		void FeatureFormLoad(object sender, EventArgs e)
		{
			//メインフォームにウィンドウリストを追加してもらう
			//MainForm mf = (MainForm)MdiParent;
			//windowID = mf.AddWindowList(this.Name, fileName);
			//this.Text = mf.GetWindowTitle(windowID);
		}
		#endregion
		
		#region ウィンドウが閉じられるときに
		void FeatureFormFormClosing(object sender, FormClosingEventArgs e)
		{
			//メインフォームにウィンドウリストから削除してもらう
			//MainForm mf = (MainForm)this.MdiParent;
			//mf.RemoveWindowAtID(windowID);
		}
		#endregion
		
		#region グラフエリアのペイント処理
		void GraphImagePaint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawImage(viewGraphBmp,0,0);
		}
        #endregion

		//2022.05.15 D.Honjyou
		//グリッドラインの表示、CSVボタンのメニュー化、画面コピーに対応
        private void btnCopyWindow_Click(object sender, EventArgs e)
        {
			//フォームからスクリーンショットを撮る　
			Bitmap clipBmp = new Bitmap(this.Width, this.Height);
			this.DrawToBitmap(clipBmp, new Rectangle(0, 0, this.Width, this.Height));
			Clipboard.SetImage(clipBmp);
			clipBmp.Dispose();
		}

        private void btnGridLine_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveToCSV_Click(object sender, EventArgs e)
        {
			BtnCSVSaveClick(sender, e);

		}

        private void btnGridLine_CheckedChanged(object sender, EventArgs e)
        {
			imageBox.Invalidate();
			featureBox.Invalidate();
        }
    }
}
