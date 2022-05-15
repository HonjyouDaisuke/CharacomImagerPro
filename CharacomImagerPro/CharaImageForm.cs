/*
/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2011/10/17
 * 時刻: 10:42
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Reflection;

namespace CharacomImagerPro
{
	/// <summary>
	/// Description of CharaImageForm.
	/// </summary>
	public partial class CharaImageForm : Form
	{
		//コマンドマネージャー
		public CommandManager undoManager = new CommandManager();
		//定数
		public const int BitmapWidth = 320;
		public const int BitmapHeight = 320;
		public const int SmallWidth = 160;
		public const int SmallHeight = 160;
		public const int ProcSource = 0;
		public const int ProcSaisen = 1;
		public const int ProcSyaei = 2;
		public const int ProcThermo = 3;
		public const int ProcFeature = 4;
		public const int ProcHaikei = 5;
		public const int FormSmallWidth = 330;
		//public const int FormBigWidth = 548;
		public const int FormBigWidth = 675;
		private int _copyNumber = 0;
		public bool lineClose = false;
		
		private SetupClass _setup;
		//親フォームの参照
		private MainForm mf;
		public Color dispColor;
		public SetupClass Setup {
			get { return _setup; }
			set { _setup = value; }
		}
		
		string [] rowDataDisplay = {"Blue","Green","Red","Yellow","Purple","Orange","SkyBlue","Pink","Brown","Gray","Black"};
		Color [] rowDataColor = {Color.Blue, Color.Green, Color.Red, Color.Gold, Color.MediumPurple, Color.OrangeRed,
								Color.LightSkyBlue, Color.Pink, Color.SaddleBrown, Color.DimGray, Color.Black};
		
		//画像処理クラス
		ImageEffect imageEffect = new ImageEffect();
		
		//ビットマップ変数
		Bitmap srcBitmap;
		Bitmap srcBitmapSmall;
		Bitmap pictBitmap;
		Bitmap viewBitmap;
		Bitmap procBitmap;
		Bitmap wideBitmap;
		
		Bitmap ListBmp;
		double [] zoom = {4.0, 3.0, 2.0, 1.5, 1.0, 0.5};
			
		Point mP,sP;
		ArrayList Points = new ArrayList();
		//ArrayList Frames = new ArrayList();
		int ActiveFrameNo = -1;
		
		//イメージデータ
		private ImageDataClass imageData = new ImageDataClass(320, 320);
		
		public ImageDataClass ImageData {
			get { return imageData; }
			set { imageData = value; }
		}
		
		#region ビットマッププロパティ
		public Bitmap SrcBitmap {
			get { return srcBitmap; }
			set { srcBitmap = value; }
		}
		
		public Bitmap SrcBitmapSmall {
			get { return srcBitmapSmall; }
			set { srcBitmapSmall = value; }
		}
		
		public Bitmap ViewBitmap {
			get { return viewBitmap; }
			set { viewBitmap = value; }
		}
		
		public Bitmap ProcBitmap {
			get { return procBitmap; }
			set { procBitmap = value; }
		}
		#endregion
		
		//プロパティ
		private int imageProc;
		public int ImageProc {
			get { return imageProc; }
			set { imageProc = value; }
		}
		
		private int windowID = -1;
		private string fileName;
		/// <summary>ファイル名です。</summary>
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
		
		
		private string importFileName;
		
		public string ImportFileName {
			get { return importFileName; }
			set { importFileName = value; }
		}
		
		#region ウィンドウサイズの変更
		void ChangeFormSize()
		{
			if(btnProperty.Checked == true){
				this.Width = FormBigWidth;
			}else{
				this.Width = FormSmallWidth;
			}
		}
		#endregion
		
		/// <summary>
		/// 初期インスタンスの作成
		/// </summary>
		/// <param name="mainForm"></param>
		public CharaImageForm(MainForm mainForm)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			this.comboColor.SelectedIndexChanged -= new EventHandler(ComboColorSelectedIndexChanged);
			this.comboGColor.SelectedIndexChanged -= new EventHandler(ComboGColorSelectedIndexChanged);
			InitBitmaps();
			cmbZoomTool.SelectedIndex = 4;
			
			SetFirstProperty();
			
			ChangeFormSize();
			CheckUndoRedo();
			
			
			this.FileNameChanged += new System.EventHandler(this.OnFileNameChanged);
			mf = mainForm;
			
			// 
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

		#region 最初のプロパティセット
		void SetFirstProperty()
		{
			CharaImageFormProperties cifp = new CharaImageFormProperties();
			this.Size = cifp.Form.Size;
			panel1.Location = cifp.Panel1.Location;
			panel1.Size = cifp.Panel1.Size;
			
			groupBox1.Location = cifp.GroupBox1.Location;
			groupBox1.Size = cifp.GroupBox1.Size;
			
			label1.Location = cifp.Label1.Location;
			label1.Size = cifp.Label1.Size;
			
			label2.Location = cifp.Label2.Location;
			label2.Size = cifp.Label2.Size;
			
			label3.Location = cifp.Label3.Location;
			label3.Size = cifp.Label3.Size;
			
			label4.Location = cifp.Label4.Location;
			label4.Size = cifp.Label4.Size;
			
			txtHeight.Location = cifp.TxtHeight.Location;
			txtHeight.Size = cifp.TxtHeight.Size;
			
			txtWidth.Location = cifp.TxtWidth.Location;
			txtWidth.Size = cifp.TxtWidth.Size;
			
			txtGravity.Location = cifp.TxtGravity.Location;
			txtGravity.Size = cifp.TxtGravity.Size;
			
			txtArea.Location = cifp.TxtArea.Location;
			txtArea.Size = cifp.TxtArea.Size;
			
			dgvFrameData.Location = cifp.DgvFrameData.Location;
			dgvFrameData.Size = cifp.DgvFrameData.Size;
			
			btnCSV.Location = cifp.BtnCSV.Location;
			btnCSV.Size = cifp.BtnCSV.Size;
			
			cmbZoomTool.Size = cifp.CmbZoomTool.Size;
			comboColor.Size = cifp.ComboColor.Size;
		}
		#endregion
		
		#region ファイル名が変更されたらWindowListの名称を変更
		void OnFileNameChanged(object sender, EventArgs e)
		{
			//MainForm mf = (MainForm)this.MdiParent;
			mf.ChangeWindowListName(windowID, fileName);
			this.Text = mf.GetWindowTitle(windowID);
			//mf.ChangeWindowListName(windowID, fileName);
		}
		#endregion
		
		#region 無題をセット
		public void SetNonTitle()
		{
			//MainForm mf = (MainForm)this.MdiParent;
			FileName = "無題" + mf.GetTitleNo(this.Name).ToString() + ".cci";
		}
		#endregion
		
		#region ウィンドウ外から色を変える
		public void SetColor(Color c)
		{
			int cindx;
			cindx = GetSelectIndexFromColor(c);
			comboColor.SelectedIndex = cindx;
			ComboColorSelectedIndexChanged(this.comboColor, null);
		}
		#endregion
		
		#region カラー選択テーブルの初期化
		void SetColorTbl(ComboBox combo)
		{
			if(combo.Items.Count >= mf.Setup.DisplayColor.Length) return;
			
			for(int i=0; i<mf.Setup.DisplayColor.Length; i++){
				combo.Items.Add(mf.Setup.DisplayColor[i].Name);
			}
		}
		#endregion
		
		#region カラー情報からのコンボボックス選択インデックス
		int GetSelectIndexFromColor(Color c)
		{
			int rsi = 1;
			Color sc;
			System.Diagnostics.Debug.WriteLine("c="+c.Name);
			dispColor = c;
			for(int i=0; i<mf.Setup.DisplayColor.Length; i++){
				sc = mf.Setup.DisplayColor[i];
				if(sc.R == c.R && sc.G == c.G && sc.B == c.B){
					rsi = i;
				}
			}
			System.Diagnostics.Debug.WriteLine("カラー番号="+rsi.ToString());
			return(rsi);
		}
		#endregion
		
		#region 色変更コンボボックスのオーナー描画
		void comboColorDrawItem(object sender, DrawItemEventArgs e)
		{
			if(e.Index == -1){
				return;
			}
			
			ComboBox Combo = (ComboBox)sender;
			
			Rectangle TextRect = new Rectangle();
			Rectangle ColorRect = new Rectangle();
			
			TextRect.X = e.Bounds.X +26;
			TextRect.Y = e.Bounds.Y +1;
			TextRect.Width = e.Bounds.Width -2;
			TextRect.Height = e.Bounds.Height -2;
			
			ColorRect.X = e.Bounds.X +2;
			ColorRect.Y = e.Bounds.Y +2;
			ColorRect.Width = 25;
			ColorRect.Height = e.Bounds.Height -4;
			
			e.DrawBackground();
			
			Brush b = new SolidBrush(mf.Setup.DisplayColor[e.Index]);
			e.Graphics.DrawString(mf.Setup.DisplayColor[e.Index].Name, e.Font, Brushes.Black, TextRect);
			e.Graphics.FillRectangle(b, ColorRect);
			e.Graphics.DrawRectangle(Pens.Black, ColorRect);
			e.DrawFocusRectangle();
		}
		#endregion
		
		#region Bitmapの初期化処理
		private void InitBitmaps()
		{
			//Bitmapの作成
			srcBitmapSmall = new Bitmap(SmallWidth, SmallHeight);
			srcBitmap = new Bitmap(BitmapWidth, BitmapHeight);
			viewBitmap = new Bitmap(BitmapWidth, BitmapHeight);
			procBitmap = new Bitmap(BitmapWidth, BitmapHeight);
			pictBitmap = new Bitmap(BitmapWidth, BitmapWidth);
			
			//Bitmapを白で初期化
			imageEffect.BitmapWhitening(srcBitmap);
			imageEffect.BitmapWhitening(viewBitmap);
			imageEffect.BitmapWhitening(procBitmap);
			imageEffect.BitmapWhitening(pictBitmap);
		}
		#endregion
		
		#region 画像のペースト
		public void PicturePaste()
		{
			IDataObject data = Clipboard.GetDataObject();
			
			if(data.GetDataPresent(DataFormats.Bitmap)){
				Bitmap OriginalBmp = new Bitmap((Image)data.GetData(DataFormats.Bitmap));
			
				//imageEffect.BitmapStretchCopy(PictBmp, thermoBitmap);
				
				//読み込んだ原画像を小さなソース画像にストレッチコピー
				imageEffect.BitmapStretchCopy(OriginalBmp, srcBitmapSmall);
				imageEffect.BitmapStretchCopy(OriginalBmp, pictBitmap);
				//2値化(判別分析法)
				imageEffect.ChrMonotoneProc(srcBitmapSmall);
				
				//前処理(大きさ変換)
	    		if(mf.Setup.CharaNormalize == true){
	    			imageEffect.Normalize(srcBitmapSmall, mf.Setup.CharaR);
	    		}
	    		imageEffect.BitmapStretchCopy(srcBitmapSmall, srcBitmap);
	    		imageEffect.BitmapCopy(srcBitmap, procBitmap);
	    		imageEffect.BitmapCopy(srcBitmap, viewBitmap);
	    		Bitmap work = new Bitmap(srcBitmap.Width, srcBitmap.Height);
	    		Point P;
	    		ArrayList Points = new ArrayList();
	    		P = new Point(0,0);
	    		Points.Add(P);
	    		P = new Point(srcBitmap.Width, 0);
	    		Points.Add(P);
	    		P = new Point(srcBitmap.Width, srcBitmap.Height);
	    		Points.Add(P);
	    		P = new Point(0, srcBitmap.Height);
	    		Points.Add(P);
	    		imageData.AllRect = imageEffect.ImageClipping(srcBitmap, Points, work, Color.Black);
	    		imageData.AllGravity = imageEffect.GetGravityPoint(srcBitmap);
	    		imageData.PixelCount = imageEffect.GetPixelPoint(srcBitmap, 2);
	    		//imageData.Filename = FileName;
	    		imageData.Updatetime = System.DateTime.Now;
	    		imageData.SrcImage = srcBitmap;
	    		imageData.SrcImageSmall = srcBitmapSmall;
	    		imageData.ProcImage = srcBitmap;
	    		imageData.JpegImage = OriginalBmp;
	    		
	    		txtHeight.Text = imageData.AllRect.Height.ToString("#,0");
	    		txtWidth.Text = imageData.AllRect.Width.ToString("#,0");
	    		txtArea.Text = (imageData.AllRect.Height * imageData.AllRect.Width).ToString("#,0");
	    		txtGravity.Text = "("+imageData.AllGravity.X.ToString("#,0")+","+imageData.AllGravity.Y.ToString("#,0")+")";
			}
		}
		#endregion
		
		#region 画像ファイル読み込み(インポート)
		public void PictureFileRead()
		{
			//System.Diagnostics.Debug.WriteLine(ImportFileName + "を開きますぞ");
			//ファイルの存在確認
			if(System.IO.File.Exists(ImportFileName) == false){
				MessageBox.Show("ファイルが存在しません。\n画像ファイルを確認してください。\n\n"+ImportFileName, "画像ファイル オープンエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
						
			//画像ファイルかどうかのチェック
			if(imageEffect.IsImageFile(ImportFileName) == false){
				MessageBox.Show("画像ファイルではありません。\n画像ファイルを確認してください。\n\n"+ImportFileName, "画像ファイル オープンエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			//this.fileAddress = FileName;
			
			Bitmap OriginalBmp = new Bitmap(ImportFileName);
			
			
			//imageEffect.BitmapStretchCopy(PictBmp, thermoBitmap);
			
			//読み込んだ原画像を小さなソース画像にストレッチコピー
			imageEffect.BitmapStretchCopy(OriginalBmp, srcBitmapSmall);
			imageEffect.BitmapStretchCopy(OriginalBmp, pictBitmap);
			
			
			//2値化(判別分析法)
			imageEffect.ChrMonotoneProc(srcBitmapSmall);

			//2022.05.02 D.Honjyou
			//ノイズ除去
			imageEffect.Median(srcBitmapSmall);
			
			//前処理(大きさ変換)
    		if(mf.Setup.CharaNormalize == true){
    			imageEffect.Normalize(srcBitmapSmall, mf.Setup.CharaR);
    		}
    		imageEffect.BitmapStretchCopy(srcBitmapSmall, srcBitmap);
    		imageEffect.BitmapCopy(srcBitmap, procBitmap);
    		imageEffect.BitmapCopy(srcBitmap, viewBitmap);
    		Bitmap work = new Bitmap(srcBitmap.Width, srcBitmap.Height);
    		Point P;
    		ArrayList Points = new ArrayList();
    		P = new Point(0,0);
    		Points.Add(P);
    		P = new Point(srcBitmap.Width, 0);
    		Points.Add(P);
    		P = new Point(srcBitmap.Width, srcBitmap.Height);
    		Points.Add(P);
    		P = new Point(0, srcBitmap.Height);
    		Points.Add(P);
    		imageData.AllRect = imageEffect.ImageClipping(srcBitmap, Points, work, Color.Black);
    		imageData.AllGravity = imageEffect.GetGravityPoint(srcBitmap);
    		imageData.PixelCount = imageEffect.GetPixelPoint(srcBitmap, 2);
    		imageEffect.DotChange(srcBitmap, Color.Aqua);
    		imageData.Filename = FileName;
    		imageData.Updatetime = System.DateTime.Now;
    		imageData.SrcImage = srcBitmap;
    		imageData.SrcImageSmall = srcBitmapSmall;
    		imageData.ProcImage = srcBitmap;
    		imageData.JpegImage = OriginalBmp;
    		
    		txtHeight.Text = imageData.AllRect.Height.ToString("#,0");
    		txtWidth.Text = imageData.AllRect.Width.ToString("#,0");
    		txtArea.Text = (imageData.AllRect.Height * imageData.AllRect.Width).ToString("#,0");
    		txtGravity.Text = "("+imageData.AllGravity.X.ToString("#,0")+","+imageData.AllGravity.Y.ToString("#,0")+")";
    		
		}
		#endregion
		
		#region 枠の描画
		private void DrawWaku(Bitmap bmp)
		{
			//MainForm mf = new MainForm();
			//mf = (MainForm)this.MdiParent;
			
			if(mf.Setup.EightLineVisible) imageEffect.Draw8x8Line(bmp, mf.Setup.EightLineColor);
			if(mf.Setup.CenterLineVisible) imageEffect.DrawCenterLine(bmp, mf.Setup.CenterLineColor);
		}
		#endregion
		
		#region ペイント処理
		private void ImageBoxPaint(object sender, PaintEventArgs e)
		{
			Bitmap vBmp = new Bitmap(viewBitmap.Width, viewBitmap.Height);
			imageEffect.BitmapCopy(viewBitmap, vBmp);
			DrawFrame(vBmp);
			DrawWaku(vBmp);
			
			
			Size a = new Size();
			
			wideBitmap =  new Bitmap((int)((double)vBmp.Width * zoom[cmbZoomTool.SelectedIndex]), (int)((double)vBmp.Height * zoom[cmbZoomTool.SelectedIndex]));
			a.Width = wideBitmap.Width;
			a.Height = wideBitmap.Height;
			ImageBox.Size = a;
			imageEffect.BitmapStretchCopy(vBmp, wideBitmap);
			e.Graphics.DrawImage(wideBitmap,0,0);
		}
		#endregion
		
		#region 画像データ配列を更新
		public void UpdateImageData()
		{
			//MainForm mf = (MainForm)this.MdiParent;
			
			imageEffect.BitmapCopy(srcBitmap, imageData.SrcImage);
			imageEffect.BitmapCopy(srcBitmapSmall, imageData.SrcImageSmall);
			imageEffect.BitmapCopy(viewBitmap, imageData.ViewImage);
			imageEffect.BitmapCopy(procBitmap, imageData.ProcImage);
			imageData.DispColor = dispColor;
			imageData.Filename = this.FileName;
			if(mf != null){
				mf.UpdateLapForm();
			}
		}
		#endregion
		
		#region 画像処理スイッチャー
		public void ImageProcessSwitcher()
		{
			switch (ImageProc) {
				case CharaImageForm.ProcSource:
					imageEffect.BitmapStretchCopy(srcBitmapSmall, srcBitmap);
					imageEffect.BitmapCopy(srcBitmap, procBitmap);
					lblProcess.Text = "標準";
					break;
					
				case CharaImageForm.ProcSyaei:
					imageEffect.BitmapStretchCopy(srcBitmapSmall, srcBitmap);
					//imageEffect.DrawProjection(srcBitmap, procBitmap, rowDataColor[comboColor.SelectedIndex]);
					imageEffect.DrawProjection(srcBitmap, procBitmap, Color.Black);
					foreach(FrameDataClass fd in imageData.FrameData){
						imageEffect.DrawProjection(fd.Bmp, procBitmap, fd.FrameColor);
					}
					lblProcess.Text = "射影";
					break;
				
				case CharaImageForm.ProcSaisen:
					//imageEffect.DrawTinning(srcBitmapSmall, procBitmap, mf.Setup.DisplayColor[comboColor.SelectedIndex]);
     				imageEffect.DrawTinning(srcBitmapSmall, procBitmap, Color.Black);
     				//矩形の分細線化するから処理が遅い！
     				/**ここを変更2014.01.08**/
     				foreach(FrameDataClass fd in imageData.FrameData){
      					Bitmap bbb = new Bitmap(CharaImageForm.SmallWidth, CharaImageForm.SmallHeight);
      					Bitmap ccc = new Bitmap(fd.Bmp.Width, fd.Bmp.Height);
      					imageEffect.BitmapWhitening(bbb);
      					imageEffect.BitmapWhitening(ccc);
      					imageEffect.BitmapStretchCopy(fd.Bmp, bbb);
      					imageEffect.DrawTinning(bbb, ccc, fd.FrameColor);
      					imageEffect.BitmapStretchCopy(ccc, fd.Bmp);
      					imageEffect.BitmapImposeCopy(procBitmap, ccc);
     				}
					/**ここまで**/
					lblProcess.Text = "細線化";
					break;
				
				case CharaImageForm.ProcThermo:
					lblProcess.Text = "サーモグラフィ";
					imageEffect.DrawThermoGraphy(pictBitmap, procBitmap);
					break;
					
				case CharaImageForm.ProcFeature:
					FeatureForm ff = new FeatureForm((MainForm)this.MdiParent);
					imageEffect.BitmapStretchCopy(srcBitmapSmall, ff.SrcBitmapSmall);
					ff.MakeFeature();
					ff.MakeGraph();
					ff.MdiParent = this.MdiParent;
					ff.SetNonTitle();
					ff.Show();
					break;
					
				case CharaImageForm.ProcHaikei:
					HaikeiDenpanForm hf = new HaikeiDenpanForm((MainForm)this.MdiParent);
					imageEffect.BitmapStretchCopy(srcBitmapSmall, hf.SrcBitmapSmall);
					hf.MakeFeature();
					hf.MakeGraph();
					hf.MdiParent = this.MdiParent;
					hf.SetNonTitle();
					hf.Show();
					break;
					
				default:
					imageEffect.BitmapCopy(srcBitmap, procBitmap);
					break;
			}
			imageEffect.BitmapCopy(procBitmap, viewBitmap);
			UpdateImageData();
		}
		#endregion
		
		#region タイトルを右クリックしたらドラッグ開始
		protected override void WndProc(ref Message m)
		{
			if(m.Msg == 0xa4 && m.WParam == (System.IntPtr)0x2){
				ImageBox.DoDragDrop(this, DragDropEffects.All);
			}
			base.WndProc(ref m);
		}
		#endregion
		
		#region コンテキストメニュー
		#region 元に戻す(Undo)
		public void UndoMenuItemClick(object sender, EventArgs e)
		{
			undoManager.Undo();
			ActiveFrameNo = -1;
			RefleshImageWindow();
			//imageEffect.BitmapCopy(procBitmap, viewBitmap);
			//ImageBox.Invalidate();
			dgvFrameData.Refresh();
		}
		#endregion
		
		#region やり直し(Redo)
		public void RedoMenuItemClick(object sender, EventArgs e)
		{
			undoManager.Redo();
			ActiveFrameNo = -1;
			RefleshImageWindow();
			//imageEffect.BitmapCopy(procBitmap, viewBitmap);
			//ImageBox.Invalidate();
			dgvFrameData.Refresh();
		}
		#endregion
		
		#region 矩形リストの作成
		void MakeList()
		{
			Font TitleFont = new Font("メイリオ", 14, FontStyle.Bold);
			Font HeaderFont = new Font("メイリオ", 12, FontStyle.Bold);
			Font DataFont = new Font("メイリオ", 10);
			Graphics g;
			const int HeightWidth = 70;
			const int WidthWidth = 70;
			const int SizeWidth = 100;
			const int GravityWidth = 100;
			const int DistanceWidth = 100;
			const int ColorWidth = 70;
			
			const int MarginX = 5;
			const int MarginY = 5;
			
			//全体の大きさ用
			int MaxX, MaxY;
			int x, y;
			int ex, ey;
			
			//全体の大きさの確認
			MaxX = MarginX + ColorWidth + MarginX + HeightWidth + MarginX + WidthWidth + MarginX + SizeWidth + MarginX + GravityWidth + MarginX + DistanceWidth + MarginX;
			MaxY = MarginY + TitleFont.Height + MarginY + (DataFont.Height + MarginY)*2 + TitleFont.Height + MarginY + (ImageData.FrameData.Count+1) * (DataFont.Height + MarginY)+MarginY;
			
			//ビットマップを作成
			System.Diagnostics.Debug.WriteLine(MaxX.ToString()+","+MaxY.ToString());
			ListBmp = new Bitmap(MaxX, MaxY);
			imageEffect.BitmapWhitening(ListBmp);
				
			//グラフィックを作成
			g = Graphics.FromImage(ListBmp);
			
			x = 0; y = 0;
			y = MarginY;
				
			//エンドポイントを算出
			ex = MaxX - MarginX / 2;
			ey = MaxY - MarginY / 2;
				
			//全体の隣接矩形
			x = MarginX / 2;
			y = MarginY / 2;
			g.DrawString("★全体の隣接矩形", TitleFont, Brushes.Black, x, y);
			y += TitleFont.Height + MarginY;
			
			//全体のデータ部
			g.DrawString("高さ", DataFont, Brushes.Black, x, y);
			g.DrawString(ImageData.AllRect.Height.ToString("#,0"), DataFont, Brushes.Black, x + SizeWidth + MarginX, y);
			g.DrawString("面積", DataFont, Brushes.Black, MaxX / 2, y);
			g.DrawString((imageData.AllRect.Height * imageData.AllRect.Width).ToString("#,0"), DataFont, Brushes.Black, MaxX/2 + SizeWidth, y);
			g.DrawString("幅", DataFont, Brushes.Black, x, y + MarginY + DataFont.Height);
			g.DrawString(ImageData.AllRect.Width.ToString("#,0"), DataFont, Brushes.Black, x + SizeWidth + MarginX, y + MarginY + DataFont.Height);
			g.DrawString("重心", DataFont, Brushes.Black, MaxX / 2, y + MarginY + DataFont.Height);
			g.DrawString("(" + imageData.AllGravity.X.ToString("#,0") + "," + imageData.AllGravity.Y.ToString("#,0") + ")", DataFont, Brushes.Black, MaxX/2 + SizeWidth, y + MarginY + DataFont.Height);
			
			y += MarginY + DataFont.Height*2 + MarginY*2;
			
			//矩形リスト
			g.DrawString("★矩形リスト", TitleFont, Brushes.Black, x, y);
			y += TitleFont.Height + MarginY;
			int workx = x;
				
			//ヘッダー部
			if(imageData.FrameData.Count > 0){
				g.DrawLine(Pens.Black, x, y, ex-1, y);
				g.DrawLine(Pens.Black, x, y, x, ey-1);
				g.DrawString("色", DataFont, Brushes.Black, workx, y);
				workx += ColorWidth+MarginX;
				g.DrawLine(Pens.Black, workx, y, workx, ey-1);
				g.DrawString("高さ", DataFont, Brushes.Black, workx, y);
				workx += HeightWidth+MarginX;
				g.DrawLine(Pens.Black, workx, y, workx, ey-1);
				g.DrawString("幅", DataFont, Brushes.Black, workx, y);
				workx += WidthWidth+MarginX;
				g.DrawLine(Pens.Black, workx, y, workx, ey-1);
				g.DrawString("面積", DataFont, Brushes.Black, workx, y);
				workx += SizeWidth+MarginX;
				g.DrawLine(Pens.Black, workx, y, workx, ey-1);
				g.DrawString("重心", DataFont, Brushes.Black, workx, y);
				workx += GravityWidth+MarginX;
				g.DrawLine(Pens.Black, workx, y, workx, ey-1);
				g.DrawString("重心との距離", DataFont, Brushes.Black, workx, y);
				workx += DistanceWidth+MarginX;
				g.DrawLine(Pens.Black, workx, y, workx, ey-1);
			
				//データ部
				y += DataFont.Height + MarginY;
				g.DrawLine(Pens.Black, x, y, ex-1, y);
				
				foreach(FrameDataClass fdc in imageData.FrameData){
					workx = x;
					g.FillRectangle(new SolidBrush(fdc.FrameColor), workx+2, y+2, ColorWidth, DataFont.Height);
					workx += ColorWidth + MarginX;
					g.DrawString(fdc.Height.ToString("#,0"), DataFont, Brushes.Black, workx, y);
					workx += HeightWidth + MarginX;
					g.DrawString(fdc.Width.ToString("#,0"), DataFont, Brushes.Black, workx, y);
					workx += WidthWidth + MarginX;
					g.DrawString(fdc.Area.ToString("#,0"), DataFont, Brushes.Black, workx, y);
					workx += SizeWidth + MarginX;
					g.DrawString("("+fdc.Gravity.X.ToString("#,0")+","+fdc.Gravity.Y.ToString("#,0")+")", DataFont, Brushes.Black, workx, y);
					workx += GravityWidth + MarginX;
					double dist;
					int x1, x2, y1, y2;
					x1 = imageData.AllGravity.X;  x2 = fdc.Gravity.X;
					y1 = imageData.AllGravity.Y;  y2 = fdc.Gravity.Y;
					dist = Math.Sqrt((double)(((x1 - x2)*(x1 - x2)) + ((y1 - y2)*(y1 - y2))));
					g.DrawString(dist.ToString("#,0"), DataFont, Brushes.Black, workx, y);
				
					y += DataFont.Height + MarginY;
					g.DrawLine(Pens.Black, x, y, ex-1, y);
				}
			}
			g.Dispose();
		}
		#endregion
		
		#region 【メニュー】コピー
		public void CopyMenuItemClick(object sender, EventArgs e)
		{
			Bitmap clipBmp = new Bitmap(viewBitmap);
	
			DrawFrame(clipBmp);
			DrawWaku(clipBmp);
			
			imageEffect.BitmapDrawFrame(clipBmp);
			Clipboard.SetImage(clipBmp);
			
			clipBmp.Dispose();
		}
		#endregion
		
		#region 【メニュー】画像とデータをコピー
		void DataCopyMenuItemClick(object sender, EventArgs e)
		{
			// clipBmp = new Bitmap(10,10);
			Bitmap imageBmp = new Bitmap(viewBitmap);
	
			DrawFrame(imageBmp);
			DrawWaku(imageBmp);
			
			imageEffect.BitmapDrawFrame(imageBmp);
			
			MakeList();
			
			//つなげる
			int maxy = 0;
			
			if(ListBmp.Height >= imageBmp.Height) 	maxy = ListBmp.Height;
			else									maxy = imageBmp.Height;
			
			Bitmap clipBmp = new Bitmap(imageBmp.Width + ListBmp.Width, maxy);
			imageEffect.BitmapWhitening(clipBmp);
			
			imageEffect.BitmapCopyXY(imageBmp, clipBmp, 0, 0);
			imageEffect.BitmapCopyXY(ListBmp, clipBmp, imageBmp.Width, 0);
			Clipboard.SetImage(clipBmp);
		}
		#endregion
		
		#region 【メニュー】ウィンドウをコピー
		// 2020.08.24 D.Honjyou 三崎さんからの要望により追加
		void CopyWindowMenuItemClick(object sender, EventArgs e)
		{
			//フォームからスクリーンショットを撮る　
			Bitmap clipBmp = new Bitmap(this.Width, this.Height);
			this.DrawToBitmap(clipBmp, new Rectangle(0, 0, this.Width, this.Height));
			Clipboard.SetImage(clipBmp);
			clipBmp.Dispose();
		}
		#endregion
		
		#region 【メニュー】貼り付け
		void PasteMenuItemClick(object sender, EventArgs e)
		{
			PicturePaste();
			ImageBox.Invalidate();
		}
		#endregion
		
		#region cciデータ保存処理
		void SaveCCIData(string filename)
		{
			imageData.ProcImage = procBitmap;
			imageData.ViewImage = viewBitmap;
			imageData.Filename = filename;
			imageData.Updatetime = System.DateTime.Now;
			FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
			BinaryFormatter bf = new BinaryFormatter();
			
			bf.Serialize(fs, imageData);
			fs.Close();
			//コマンド履歴を消去
			undoManager.UndoClear();
			undoManager.RedoClear();
		}
		#endregion
		
		#region cciデータ開く処理
		public bool OpenCCIData(string filename)
		{
			//MainForm mf = (MainForm)this.MdiParent;
			
			if(!System.IO.File.Exists(filename)){
				MessageBox.Show("ファイルが存在しません。ファイルが削除されたり、移動されていないか確認してください。\n" + filename, "CharacomImagerPro", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return(false);
			}
			FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
			BinaryFormatter bf = new BinaryFormatter();
			
			imageData = (ImageDataClass)bf.Deserialize(fs);
			fs.Close();
			
			imageEffect.BitmapCopy(imageData.SrcImage, srcBitmap);
			imageEffect.BitmapCopy(imageData.ProcImage, procBitmap);
			imageEffect.BitmapCopy(imageData.ViewImage, viewBitmap);
			imageEffect.BitmapCopy(imageData.SrcImageSmall, srcBitmapSmall);
			imageEffect.BitmapStretchCopy(imageData.JpegImage, pictBitmap);
			ImageBox.Invalidate();
			if(imageData.GravityColor.IsEmpty){
				imageData.GravityColor = Color.Maroon;
			}
			//ImageProcessSwitcher();
			txtHeight.Text = imageData.AllRect.Height.ToString("#,0");
    		txtWidth.Text = imageData.AllRect.Width.ToString("#,0");
    		txtArea.Text = (imageData.AllRect.Height * imageData.AllRect.Width).ToString("#,0");
    		txtGravity.Text = "("+imageData.AllGravity.X.ToString("#,0")+","+imageData.AllGravity.Y.ToString("#,0")+")";
    		
    		//フレームデータグリッドビューに追加
			//2012.01.18 D.Honjyou
			foreach(FrameDataClass fdc in imageData.FrameData){
				dgvFrameData.Rows.Add();
				
				Bitmap bmp = new Bitmap(35,16);
				imageEffect.BitmapColoring(bmp, fdc.FrameColor);
				dgvFrameData.Rows[dgvFrameData.Rows.Count - 1].Cells[0].Value = bmp;
								
				dgvFrameData.Rows[dgvFrameData.Rows.Count - 1].Cells[1].Value = fdc.Height.ToString("#,0");
				dgvFrameData.Rows[dgvFrameData.Rows.Count - 1].Cells[2].Value = fdc.Width.ToString("#,0");
				dgvFrameData.Rows[dgvFrameData.Rows.Count - 1].Cells[3].Value = fdc.Area.ToString("#,0");
				dgvFrameData.Rows[dgvFrameData.Rows.Count - 1].Cells[4].Value = "(" + fdc.Gravity.X.ToString("#,0") + ", " + fdc.Gravity.Y.ToString("#,0") + ")";
				double dist;
				int x1, x2, y1, y2;
				x1 = imageData.AllGravity.X;  x2 = fdc.Gravity.X;
				y1 = imageData.AllGravity.Y;  y2 = fdc.Gravity.Y;
				dist = Math.Sqrt((double)(((x1 - x2)*(x1 - x2)) + ((y1 - y2)*(y1 - y2))));
				dgvFrameData.Rows[dgvFrameData.Rows.Count - 1].Cells[5].Value = dist.ToString("#,0");			
			}
							
    		mf.AddRecentlyFile(filename);
			return(true);
		}
		#endregion
		
		#region 【メニュー】開く
		public void OpenMenuItemClick(object sender, EventArgs e)
		{
			if(openCCIDialog.ShowDialog() == DialogResult.OK){
				if(mf.IsOpened(openCCIDialog.FileName)){
					this.Close();
				}else{
					FileName = openCCIDialog.FileName;
					OpenCCIData(openCCIDialog.FileName);
				}
			}
		}
		#endregion
		
		#region 【メニュー】画像データのインポート
		public void ImportMenuItemClick(object sender, EventArgs e)
		{
			if(openImageDialog.ShowDialog() == DialogResult.OK){
				importFileName = openImageDialog.FileName;
				FileName = System.IO.Path.GetDirectoryName(openImageDialog.FileName) + "\\" + System.IO.Path.GetFileNameWithoutExtension(openImageDialog.FileName) + ".cci";
				PictureFileRead();
				ImageBox.Invalidate();
			}
		}
		#endregion
		
		#region 【メニュー】上書き保存
		static bool HasString(string target, string word)
		{
    		if (word == "")
      			return false;
    		if (target.IndexOf(word) >= 0) {
      			return true;
    		} else {
      			return false;
    		}
  		}
		public void SaveMenuItemClick(object sender, EventArgs e)
		{
			if(HasString(FileName, "無題")){
				SaveAtMenuItemClick(sender, e);
			}else{
				SaveCCIData(FileName);
			}
		}
		#endregion
		
		#region 【メニュー】画像として保存
		public void ImageSaveMenuItemClick(object sender, EventArgs e)
		{
			if(saveImageDialog.ShowDialog() == DialogResult.OK){
				if(imageEffect.IsImageFile(saveImageDialog.FileName)){
					Bitmap clipBmp = new Bitmap(viewBitmap);
					DrawFrame(clipBmp);
					DrawWaku(clipBmp);
			
					imageEffect.BitmapDrawFrame(clipBmp);
					clipBmp.Save(saveImageDialog.FileName, imageEffect.GetImageFormat(saveImageDialog.FileName));
				}
			}
		}
		#endregion
		
		#region 【メニュー】名前をつけて保存
		public void SaveAtMenuItemClick(object sender, EventArgs e)
		{
			if(saveCCIDialog.ShowDialog() == DialogResult.OK){
				FileName = saveCCIDialog.FileName;
				SaveCCIData(FileName);
				if(this.MdiParent != null){
					//MainForm mf = (MainForm)this.MdiParent;
					mf.UpdateLapForm();
				}
			}
		}
		#endregion
		
		#region 【メニュー】印刷プレビュー
		public void PreViewMenuItemClick(object sender, EventArgs e)
		{
			printPreviewDlg.StartPosition = FormStartPosition.CenterParent;
			printPreviewDlg.ShowDialog();
		}
		#endregion
		
		#region 【メニュー】印刷
		public void PrintMenuItemClick(object sender, EventArgs e)
		{
			if(printDlg.ShowDialog() == DialogResult.OK){
				printDoc.PrinterSettings.Copies = printDlg.PrinterSettings.Copies;
				printDoc.Print();
			}
		}
		#endregion
		
		#region 【メニュー】ページ設定
		public void PageSetupMenuIteClick(object sender, EventArgs e)
		{
			pageSetupDlg.ShowDialog();
		}
		#endregion
		
		#region 【メニュー】新しいウィンドウ
		void OpenNewMenuItemClick(object sender, EventArgs e)
		{
			mf.MenuCharaNewClick(sender, e);
		}
		#endregion
		
		#region 【メニュー】上下に並べて表示
		void UpDownArignMenuItemClick(object sender, EventArgs e)
		{
			this.MdiParent.LayoutMdi(MdiLayout.TileHorizontal);
		}
		#endregion
		
		#region 【メニュー】左右に並べて表示
		void LRAlignMenuItemClick(object sender, EventArgs e)
		{
			this.MdiParent.LayoutMdi(MdiLayout.TileVertical);
		}
		#endregion
		
		#region 【メニュー】重ねて表示
		void OverAlignMenuItemClick(object sender, EventArgs e)
		{
			this.MdiParent.LayoutMdi(MdiLayout.Cascade);
		}
		#endregion
		
		#region 【メニュー】ズーム
		void ZoomMenuItemClick(object sender, EventArgs e)
		{
			ZoomSelectPanel zsl = new ZoomSelectPanel();
			zsl.StartPosition = FormStartPosition.CenterParent;
			if(zsl.ShowDialog() == DialogResult.OK){
				cmbZoomTool.SelectedIndex = zsl.Wide;
			}
			zsl.Dispose();
			
			ImageBox.Invalidate();
		}
		#endregion
		
		#region 【メニュー】閉じる
		void CloseMenuItemClick(object sender, EventArgs e)
		{
			this.Close();
		}
		#endregion
		
		#region 【メニュー】一列閉じる
		// 2020.01.15 一列閉じる機能を追加
		void LineCloseMenuItemClick(object sender, EventArgs e)
		{
			//現在選択中の個別文字ウィンドウ
			Form cif = new Form();
			cif =  (CharaImageForm)this;
			int x_back, width_back;
			
			x_back = cif.Left;
			width_back = cif.Width;
			
			foreach (Form cdif in mf.MdiChildren) {
				//System.Diagnostics.Debug.WriteLine("Window個数="+mf.MdiChildren.Length.ToString());
				//個別文字ウィンドウの子フォーム群を検索
				if(cdif.Name == "CharaImageForm"){
					if(cif.Left == cdif.Left && cif != cdif){
						//左の位置が一緒だったら閉じる
						CharaImageForm cifc = (CharaImageForm)cdif;
						cifc.lineClose = true;
						cifc.Close();
					}
				}	
			}
			//最後に選択しているウィンドウを閉じる
			cif.Close();
			
			mf.AllNo = false;
			
			//2020.01.18
			//一列消したら、右側のウィンドウをすべて左に詰める
			foreach (Form cdif in mf.MdiChildren) {
				//System.Diagnostics.Debug.WriteLine("Window個数="+mf.MdiChildren.Length.ToString());
				//個別文字ウィンドウの子フォーム群を検索
				if(cdif.Name == "CharaImageForm"){
					if(cdif.Left > x_back){
						//左に詰める
						cdif.Left -= width_back;
					}
				}	
			}
		}
		#endregion
		
		#endregion
		
		#region ズームコンボボックスが変更されたとき
		void ComboZoomSelectedIndexChanged(object sender, EventArgs e)
		{
			ImageBox.Invalidate();
		}
		#endregion	
		
		#region ツールバーメニュー
		void BtnCopyToolClick(object sender, EventArgs e)
		{
			CopyMenuItemClick(sender, e);
		}
		
		void BtnSaveToolClick(object sender, EventArgs e)
		{
			SaveMenuItemClick(sender, e);
		}
		
		void BtnPreviewToolClick(object sender, EventArgs e)
		{
			PreViewMenuItemClick(sender, e);
		}
		
		void BtnPrintToolClick(object sender, EventArgs e)
		{
			PrintMenuItemClick(sender, e);
		}
		
		void BtnZoomToolClick(object sender, EventArgs e)
		{
			ZoomMenuItemClick(sender, e);
		}
		
		void CmbZoomToolSelectedIndexChanged(object sender, EventArgs e)
		{
			ImageBox.Invalidate();
		}
		
		public void StopComboBox()
        {
			System.Diagnostics.Debug.WriteLine($"停止--{this.Text} :: {this.Name}");
			comboColor.ComboBox.SelectedIndexChanged -= new EventHandler(ComboColorSelectedIndexChanged);
		}
		public void StartComboBox()
        {
			System.Diagnostics.Debug.WriteLine($"開始--{this.Text}");
			comboColor.ComboBox.SelectedIndexChanged += new EventHandler(ComboColorSelectedIndexChanged);
		}
		void ComboColorSelectedIndexChanged(object sender, EventArgs e)
		{
			//ImageProcessSwitcher();
			comboColor.ComboBox.SelectedIndexChanged -= new EventHandler(ComboColorSelectedIndexChanged);
			System.Diagnostics.Debug.WriteLine($"--Frame = {ActiveFrameNo}");
			Bitmap bmp = new Bitmap(35, 16);
			imageEffect.BitmapWhitening(bmp);
								
			//if(btnPencil.Checked == false){
			if(ActiveFrameNo >= 0){
				//フレームを選択されているとき（鉛筆マークがONの時）
				Regex r = new Regex("System.Windows.Forms.ToolStripComboBox*");
				Match m = r.Match(sender.ToString());
				if(!m.Success){
					FrameDataClass fdc = (FrameDataClass)imageData.FrameData[ActiveFrameNo];
					//コマンドマネージャでUndo実装
					imageEffect.BmpColorChange(bmp, mf.Setup.DisplayColor[comboColor.SelectedIndex]);
					//FrameColorChangeCommand command = new FrameColorChangeCommand(procBitmap, fdc, mf.Setup.DisplayColor[comboColor.SelectedIndex], (Bitmap)dgvFrameData.Rows[ActiveFrameNo].Cells[0].Value, (Bitmap)colorImageList.Images[comboColor.SelectedIndex]);
					FrameColorChangeCommand command = new FrameColorChangeCommand(procBitmap, fdc, mf.Setup.DisplayColor[comboColor.SelectedIndex], (Bitmap)dgvFrameData.Rows[ActiveFrameNo].Cells[0].Value, bmp);
					undoManager.Action(command);
					imageEffect.BitmapCopy(procBitmap, viewBitmap);
					dgvFrameData.Refresh();
					CheckUndoRedo();
					dispColor = mf.Setup.DisplayColor[comboColor.SelectedIndex];
					System.Diagnostics.Debug.WriteLine("ColorChange="+dispColor.Name);
				}
					
			}else{
				Regex r = new Regex("System.Windows.Forms.ToolStripComboBox*");
				Match m = r.Match(sender.ToString());
				if(!m.Success){
					// 2022.05.08 色変更で一列全て変更できるようにする。
					bool bAll = false;
					if(mf.CheckSameX(this.Text, this.Name, this.Left) && mf.AllColorChanging == false)
                    {
						System.Diagnostics.Debug.WriteLine($"x = {this.Left}  mf.check = {mf.CheckSameX(this.Text, this.Name, this.Left)} -- Name {this.Text} e={e.ToString()}");
						//白キャンバスがあった場合
						DialogResult msg;
						msg = MessageBox.Show("一列全ての色を変更しますか？", "Characom Imager Pro", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
						if (msg == DialogResult.Yes)
						{
							bAll = true;
						}
						else if (msg == DialogResult.Cancel)
						{
							return;
						}
					}
					//コマンドマネージャでUndo実装
					//2012.02.13 D.Honjyou
					ImageColorChangeCommand command = new ImageColorChangeCommand(procBitmap, mf.Setup.DisplayColor[comboColor.SelectedIndex]);
					undoManager.Action(command);
					imageEffect.BitmapCopy(procBitmap, viewBitmap);
					ImageBox.Invalidate();
					dispColor = mf.Setup.DisplayColor[comboColor.SelectedIndex];
					CheckUndoRedo();

                    if (bAll)
                    {
						System.Diagnostics.Debug.WriteLine("全ての色変更スタート");
						mf.AllColorChanging = true;
						mf.ChangeAllCharaImageFormColor(this.Text, this.Name, this.Left, dispColor);
						System.Diagnostics.Debug.WriteLine("全ての色変更終了・・・");
						mf.AllColorChanging = false;
					}

				}
			}
			//}
			
			UpdateImageData();
			ImageBox.Invalidate();
			comboColor.ComboBox.SelectedIndexChanged += new EventHandler(ComboColorSelectedIndexChanged);
		}
		
		void ComboGColorSelectedIndexChanged(object sender, EventArgs e)
		{
			comboGColor.ComboBox.SelectedIndexChanged -= new EventHandler(ComboGColorSelectedIndexChanged);
			imageData.GravityColor = mf.Setup.DisplayColor[comboGColor.SelectedIndex];
			ImageBox.Invalidate();
			comboGColor.ComboBox.SelectedIndexChanged += new EventHandler(ComboGColorSelectedIndexChanged);
		}
		
		void BtnUndoClick(object sender, EventArgs e)
		{
			UndoMenuItemClick(sender, e);
		}
		
		void BtnRedoClick(object sender, EventArgs e)
		{
			RedoMenuItemClick(sender, e);
		}
		#endregion
		
		#region マウスの位置がキャンバス内かどうかのチェック
		Point InCanvasCheck(Point p)
		{
			Point rPoint;
			rPoint = p;
			
			if(p.X < 0) rPoint.X = 0;
			if(p.Y < 0) rPoint.Y = 0;
			if(p.X >= ImageBox.Width) rPoint.X = ImageBox.Width - 1;
			if(p.Y >= ImageBox.Height) rPoint.Y = ImageBox.Height - 1;
			
			return(rPoint);
		}
		#endregion
		
		#region マウスが動いたとき
		void ImageBoxMouseMove(object sender, MouseEventArgs e)
		{
			lblCoord.Text = string.Format("({0,3},{1,3})", (int)((e.X + panel1.AutoScrollOffset.X)/zoom[cmbZoomTool.SelectedIndex]), (int)((e.Y + panel1.AutoScrollOffset.Y)/zoom[cmbZoomTool.SelectedIndex]));
			if(btnPencil.Checked == true && imageProc != CharaImageForm.ProcThermo){
				if(e.Button == MouseButtons.Left){
					Graphics g = ImageBox.CreateGraphics();
					Point pp = new Point();
					Pen p = new Pen(Color.Blue, (float)zoom[cmbZoomTool.SelectedIndex]);
					
					pp.X = (int)(mP.X * zoom[cmbZoomTool.SelectedIndex] + panel1.AutoScrollOffset.X);
					pp.Y = (int)(mP.Y * zoom[cmbZoomTool.SelectedIndex] + panel1.AutoScrollOffset.Y);
					g.DrawLine(p, pp, e.Location);
					
					g.Dispose();
					mP.X = (int)((e.X + panel1.AutoScrollOffset.X) / zoom[cmbZoomTool.SelectedIndex]);
					mP.Y = (int)((e.Y + panel1.AutoScrollOffset.Y) / zoom[cmbZoomTool.SelectedIndex]);
					mP = InCanvasCheck(mP);
					Points.Add(mP);
				}
			}
		}
		#endregion	
		
		#region 矩形の中かどうかのチェック
		int InFrameCheck(Point p)
		{
			int iRet = 0;
			bool InFrame = false;
			
			foreach(FrameDataClass n in imageData.FrameData){
				if(p.X > n.Frame.X && p.Y > n.Frame.Y && p.X < n.Frame.Right && p.Y < n.Frame.Bottom){
					iRet = imageData.FrameData.IndexOf(n);
					InFrame = true;
				}
			}
			
			if(InFrame == false) iRet = -1;
			
			return(iRet);
		}
		#endregion
		
		#region マウスが押されたとき
		void ImageBoxMouseDown(object sender, MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left){
				if(InFrameCheck(e.Location) >= 0){
					if(ActiveFrameNo == InFrameCheck(e.Location)){
						ActiveFrameNo = -1;
					}else{
						ActiveFrameNo = InFrameCheck(e.Location);
						//DataGridViewをアクティブにする
						this.dgvFrameData.SelectionChanged -= new System.EventHandler(this.DgvFrameDataSelectionChanged);
						for(int i=0; i<dgvFrameData.Rows.Count; i++){
							dgvFrameData.Rows[i].Selected = false;
						}
						dgvFrameData.Rows[ActiveFrameNo].Selected = true;
						this.dgvFrameData.SelectionChanged += new System.EventHandler(this.DgvFrameDataSelectionChanged);
					}
					ImageBox.Invalidate();
					//System.Diagnostics.Debug.WriteLine("矩形" + ActiveFrameNo.ToString() + "番をアクティブにしました");
				
				}else{
					if(btnPencil.Checked == true && imageProc != CharaImageForm.ProcThermo){
						mP.X = (int)((e.X + panel1.AutoScrollOffset.X) / zoom[cmbZoomTool.SelectedIndex]);
						mP.Y = (int)((e.Y + panel1.AutoScrollOffset.Y) / zoom[cmbZoomTool.SelectedIndex]);
						mP = InCanvasCheck(mP);
						sP= mP;
						Points.Add(mP);
					}
				}
			}
		}
		#endregion
		
		#region カラーコードからカラーテーブルのインデックスを返す
		int GetColorNo(Color c)
		{
			int i,ret;
			
			ret = -1;
			
			for(i=0; i<rowDataColor.Length; i++){
				if(rowDataColor[i] == c){
					ret = i;
				}
			}
			return(ret);
		}
		#endregion
		
		#region マウスが放されたとき
		void ImageBoxMouseUp(object sender, MouseEventArgs e)
		{
			if(btnPencil.Checked == true && imageProc != CharaImageForm.ProcThermo){
				if(Points.Count > 2){
					FrameDataClass fdc = new FrameDataClass(320, 320);
				
					fdc.FrameColor = mf.Setup.DisplayColor[comboColor.SelectedIndex];
					imageEffect.BitmapWhitening(fdc.Bmp);
					fdc.Frame =	imageEffect.ImageClipping(procBitmap, Points, fdc.Bmp, fdc.FrameColor);
					if(imageEffect.WhiteCanvasCheck(fdc.Bmp)){
						//エディット画面を表示する
						CharaEditForm cef = new CharaEditForm(320, 320, 0, 0);
						
						imageEffect.BitmapCopy(fdc.Bmp, cef.srcBitmap);
						imageEffect.BitmapCopy(fdc.Bmp, cef.viewBitmap);
						cef.imageForeColor = fdc.FrameColor;
						cef.FrameData = fdc;
						cef.StartPosition = FormStartPosition.CenterParent;
						
						DialogResult dr;
						cef.StartPosition = FormStartPosition.CenterParent;
						dr = cef.ShowDialog();
						if(dr == DialogResult.OK){
							//矩形データを作成
							fdc = cef.FrameData;
							fdc.Gravity = imageEffect.GetGravityPoint(fdc.Bmp);
							//DataGridView用のデータを作成------------------------------------------------------------
							DataGridViewRow NewRow = new DataGridViewRow();
							NewRow.CreateCells(dgvFrameData);
							//if(GetColorNo(fdc.FrameColor) >=0){
								Bitmap bmp = new Bitmap(35,16);
								imageEffect.BitmapColoring(bmp, fdc.FrameColor);
								NewRow.Cells[0].Value = bmp;
								//NewRow.Cells[0].Value = colorImageList.Images[GetColorNo(fdc.FrameColor)];
							//}
							NewRow.Cells[1].Value = fdc.Height.ToString("#,0");
							NewRow.Cells[2].Value = fdc.Width.ToString("#,0");
							NewRow.Cells[3].Value = fdc.Area.ToString("#,0");
							NewRow.Cells[4].Value = "(" + fdc.Gravity.X.ToString("#,0") + ", " + fdc.Gravity.Y.ToString("#,0") + ")";
							double dist;
							int x1, x2, y1, y2;
							x1 = imageData.AllGravity.X;  x2 = fdc.Gravity.X;
							y1 = imageData.AllGravity.Y;  y2 = fdc.Gravity.Y;
							dist = Math.Sqrt((double)(((x1 - x2)*(x1 - x2)) + ((y1 - y2)*(y1 - y2))));
							NewRow.Cells[5].Value = dist.ToString("#,0");
							//DataGridView用のデータを作成end---------------------------------------------------------
							
							FrameMakeCommand command = new FrameMakeCommand(dgvFrameData.Rows, procBitmap, imageData, NewRow, fdc);
							undoManager.Action(command);
							
							dgvFrameData.Refresh();
							ActiveFrameNo = -1;
							RefleshImageWindow();
							ImageBox.Invalidate();
							CheckUndoRedo();
							//imageData.FrameData_Add(fdc);
							//ImageDataProperty.SelectedObject = imageData;
							//imageEffect.BitmapImposeCopy(procBitmap, fdc.Bmp);
							//imageEffect.BitmapCopy(procBitmap, viewBitmap);
							//ActiveFrameNo = imageData.FrameData.IndexOf(fdc);
						
							//フレームデータグリッドビューに追加
							//2012.01.18 D.Honjyou
							//dgvFrameData.Rows.Add();
							
						}else if(dr == DialogResult.Abort){
							//MessageBox.Show("キャンバスが真っ白だ！","さよなら");
						}
					}
					Points.Clear();
					ImageBox.Invalidate();
					UpdateImageData();
				}
			}
		}
		#endregion
		
		#region フレームを描画
		void DrawFrame(Bitmap bmp)
		{
			Point BeforeP = new Point(0, 0);
			int i;
			i=0;
			foreach(FrameDataClass fdc in imageData.FrameData){
				if(imageData.FrameData.IndexOf(fdc) == ActiveFrameNo){
					imageEffect.DrawFrameActiveFrame(bmp, fdc.Frame, fdc.FrameColor);
				}else{
					imageEffect.DrawFrameAtColor(bmp, fdc.Frame, fdc.FrameColor);
				}
				System.Diagnostics.Debug.WriteLine("GraviColor="+imageData.GravityColor.ToString());
				if(btnGraviHou.Checked == true || btnGraviJun.Checked == true){
					System.Diagnostics.Debug.WriteLine(ImageData.GravityColor.ToString());
					imageEffect.DrawFrameGravityPoint(bmp, fdc.Gravity, ImageData.GravityColor);
				}
				if(btnGraviHou.Checked == true){
					imageEffect.DrawFrameGravityLine(bmp, fdc.Gravity, imageData.AllGravity, ImageData.GravityColor);
				}
				if(btnGraviJun.Checked == true && i > 0){
					imageEffect.DrawFrameGravityLine(bmp, fdc.Gravity, BeforeP, ImageData.GravityColor);
				}
				BeforeP = fdc.Gravity;
				i++;		
			}
		}
		#endregion
		
		#region プロパティボタンが押されたとき
		void BtnPropertyCheckedChanged(object sender, EventArgs e)
		{
			ChangeFormSize();
		}
		#endregion
		
		#region ウィンドウが開かれたときに
		void CharaImageFormShown(object sender, EventArgs e)
		{
			//メインフォームにウィンドウリストを追加してもらう
			//MainForm mf = (MainForm)MdiParent;
			string titleName = "";
			windowID = mf.AddWindowList(this.Name, fileName);
			titleName = mf.GetWindowTitle(windowID);
			this.Text = titleName;
			
			this.comboColor.SelectedIndexChanged += new EventHandler(ComboColorSelectedIndexChanged);
			this.comboGColor.SelectedIndexChanged += new EventHandler(ComboGColorSelectedIndexChanged);
			//ComboColorSelectedIndexChanged(sender, e);
		}
		#endregion
				
		#region ウィンドウが閉じられるときに
		public void CharaImageFormFormClosing(object sender, FormClosingEventArgs e)
		{
			if(mf.AllNo == false){
				if(undoManager.CanUndo()){
					DialogResult dr;
					if(e.CloseReason == CloseReason.MdiFormClosing || lineClose == true){
						AllNoMessageDialog aMsgBox = new AllNoMessageDialog();
						aMsgBox.Msg = "[" + System.IO.Path.GetFileName(FileName) + "] は変更されています。閉じる前に保存しますか？";
						dr = aMsgBox.ShowDialog();
					}else{
						dr = MessageBox.Show("[" + System.IO.Path.GetFileName(FileName) + "] は変更されています。閉じる前に保存しますか？", "Characom Imager Pro", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
					}
					if(dr == DialogResult.Yes){
						SaveAtMenuItemClick(sender, e);
					}else if(dr == DialogResult.Cancel){
						e.Cancel = true;
						//mf.AllNo = true;
						return;
					}else if(dr == DialogResult.Ignore){
						mf.AllNo = true;
					}
				}	
			}
			//メインフォームにウィンドウリストから削除してもらう
			//MainForm mf = (MainForm)MdiParent;
			mf.RemoveWindowAtID(windowID);
		}
		#endregion
		
		#region FrameのDataGridViewの選択が変更されたら？
		void DgvFrameDataSelectionChanged(object sender, EventArgs e)
		{
			if(dgvFrameData.CurrentRow == null){
				ActiveFrameNo = -1;
				return;
			}
			ActiveFrameNo = dgvFrameData.CurrentRow.Index;
			ImageBox.Invalidate();
		}
		#endregion
		
		#region CSVまたはテキストへの出力
		void CSVorTXTSave(string FileName, bool isCSV)
		{
			string Split;
			System.Text.Encoding enc = System.Text.Encoding.GetEncoding("Shift_JIS");
			System.IO.StreamWriter sr = new System.IO.StreamWriter(saveCSVDialog.FileName, false, enc);
			int lastColIndex = dgvFrameData.Columns.Count - 1;
			if(isCSV == true) Split = ",";
			else			  Split = "\t";
			
			//ヘッダを書き込む
			for(int i=0; i<dgvFrameData.Columns.Count; i++){
				if(i == 0) sr.Write("No."+Split);
				else{
					string field = dgvFrameData.Columns[i].HeaderText.ToString();
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
    				if (lastColIndex > i){
        				sr.Write(Split);
    				}
				}
			}
			//改行する
			sr.Write("\r\n");
			
			//レコードを書き込む
			for(int j=0; j<dgvFrameData.Rows.Count; j++){
				for(int i=0; i<dgvFrameData.Columns.Count; i++){
					if(i == 0) sr.Write((j+1).ToString()+Split);
					else{
						string field = dgvFrameData.Rows[j].Cells[i].Value.ToString();
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
    					if (lastColIndex > i){
        					sr.Write(Split);
    					}
					}
				}
				//改行する
				sr.Write("\r\n");
			}
			sr.Close();
		}
		#endregion
		
		#region CSVへ出力ボタン
		void BtnCSVClick(object sender, EventArgs e)
		{
			if(dgvFrameData.Rows.Count < 1){
				//データがないのに何を出力するねーん！
				return;
			}
			if(saveCSVDialog.ShowDialog() == DialogResult.OK){
				if(Path.GetExtension(saveCSVDialog.FileName) == ".csv"){
					CSVorTXTSave(saveCSVDialog.FileName, true);
				}else if(Path.GetExtension(saveCSVDialog.FileName) == ".txt"){
					CSVorTXTSave(saveCSVDialog.FileName, false);
				}
			}
		}
		#endregion
		
		#region Undo、Redoのメニューをチェック
		void CheckUndoRedo()
		{
			RedoMenuItem.Enabled = undoManager.CanRedo();
			UndoMenuItem.Enabled = undoManager.CanUndo();
			btnUndo.Enabled = undoManager.CanUndo();
			btnRedo.Enabled = undoManager.CanRedo();
		}
		#endregion
		
		#region コンテキストメニューが開かれたときの処理
		void SubMenuOpened(object sender, EventArgs e)
		{
			if(ActiveFrameNo >= 0){
				CutMenuItem.Enabled = true;
			}else{
				CutMenuItem.Enabled = false;
			}
			
			CheckUndoRedo();
			//RedoMenuItem.Enabled = undoManager.CanRedo();
			//UndoMenuItem.Enabled = undoManager.CanUndo();
		}
		#endregion
		
		#region コンテキストメニュー 矩形の切り取り
		void RefleshImageWindow()
		{
			//imageEffect.BitmapStretchCopy(srcBitmapSmall, srcBitmap);
			//imageEffect.BitmapCopy(srcBitmap, procBitmap);
			foreach(FrameDataClass fdc in imageData.FrameData){
				imageEffect.BitmapImposeCopy(procBitmap, fdc.Bmp);
			}
			imageEffect.BitmapCopy(procBitmap, viewBitmap);
			ImageBox.Invalidate();
		}
		void CutMenuItemClick(object sender, EventArgs e)
		{
			this.dgvFrameData.SelectionChanged -= new System.EventHandler(this.DgvFrameDataSelectionChanged);
			//dgvFrameData.Rows.
			//コマンドマネージャで実装
			FrameDeleteCommand command = new FrameDeleteCommand(dgvFrameData.Rows, imageData, ActiveFrameNo);
			undoManager.Action(command);
			
			dgvFrameData.Refresh();
			ActiveFrameNo = -1;
			RefleshImageWindow();
			ImageBox.Invalidate();
			CheckUndoRedo();
			this.dgvFrameData.SelectionChanged += new System.EventHandler(this.DgvFrameDataSelectionChanged);
			
		}
		#endregion
		
		#region 印刷処理
		void PrintDocPrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			printDoc.DocumentName = "個別文字処理画像[" + System.IO.Path.GetFileName(FileName) + "]";
			Font HeaderF = new Font("メイリオ", 8, FontStyle.Bold);
			Font FooterF = new Font("メイリオ", 8, FontStyle.Bold);
			int MarginX = 5;
			int MarginY = 5;
			
			Font f = new Font("メイリオ", 10, FontStyle.Bold);
			int x, y;
			int sx, sy, ex, ey;
			int BodySY, BodyEY;
			int ChartSY, ChartEY;
			
			x = e.MarginBounds.X; y = e.MarginBounds.Y;
			
			sx = e.MarginBounds.X; sy = e.MarginBounds.Y;
			ex = e.MarginBounds.Right; ey = e.MarginBounds.Bottom;
			
			/**
			BodySY = sy + f.Height + MarginY;
			BodyEY = ey - f.Height - MarginY;
			
			//ヘッダーフッター用の文字列作成
			AssemblyTitleAttribute asmttl = (AssemblyTitleAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyTitleAttribute));
			string title = asmttl.Title;
			AssemblyCopyrightAttribute asmcpy = (AssemblyCopyrightAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyCopyrightAttribute));
			AssemblyCompanyAttribute asmcmp = (AssemblyCompanyAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(),typeof(AssemblyCompanyAttribute));
			string Copyright = asmcpy.Copyright + " " + asmcmp.Company;
			
			//ヘッダーの作成
			e.Graphics.DrawString(title, HeaderF, Brushes.Black, sx, sy);
			e.Graphics.DrawString(DateTime.Now.ToString("yyyy.MM.dd"), HeaderF, Brushes.Black, ex - HeaderF.Size * 10, sy);
			e.Graphics.DrawLine(Pens.Black, sx, sy + HeaderF.Height + MarginY, ex, sy + HeaderF.Height + MarginY);
			
			//フッターの作成
			e.Graphics.DrawLine(Pens.Black, sx, ey - HeaderF.Height - MarginY, ex, ey - HeaderF.Height - MarginY);
			
			e.Graphics.DrawString(Copyright, HeaderF, Brushes.Black, sx, ey - HeaderF.Height);
			***/
			
			PrintParts pp = new PrintParts();
			Rectangle r = pp.HeaderFooterDraw(e);
			BodySY = r.Y;
			BodyEY = r.Bottom;
			
			//タイトルを作成
			Font TitleF = new Font("メイリオ", 12, FontStyle.Bold);
			e.Graphics.DrawString("■個別文字 処理画像 [" + System.IO.Path.GetFileName(FileName) + "]", TitleF, Brushes.Black, sx, BodySY + MarginY);
			
			//画像を作成
			Bitmap b = new Bitmap(ViewBitmap.Width, ViewBitmap.Height);
			imageEffect.BitmapCopy(viewBitmap, b);
			DrawFrame(b);
			DrawWaku(b);
			imageEffect.BitmapDrawFrame(b);
			x = sx; y = BodySY+MarginY+TitleF.Height+MarginY;
			e.Graphics.DrawImage(b, x, y, b.Width, b.Height);
			//e.Graphics.DrawRectangle(Pens.Blue, 0, 0, ViewBitmap.Width, ViewBitmap.Height);
			
			//全体情報の作成
			x = sx + b.Width + MarginX;
			e.Graphics.DrawString("☆全体の矩形", f, Brushes.Black, x, y);
			y += f.Height+MarginY;
			e.Graphics.DrawString("高さ：" + imageData.AllRect.Height.ToString(), f, Brushes.Black, x, y);
			y += f.Height+MarginY;
			e.Graphics.DrawString("面積:" + (imageData.AllRect.Height * imageData.AllRect.Width).ToString("N0"), f, Brushes.Black, x, y);
			y += f.Height+MarginY;
			e.Graphics.DrawString("幅：" + imageData.AllRect.Width.ToString(), f, Brushes.Black, x, y);
			y += f.Height+MarginY;
			e.Graphics.DrawString("重心:" + "("+imageData.AllGravity.X.ToString()+","+imageData.AllGravity.Y.ToString()+")", f, Brushes.Black, x, y);
			y += f.Height+MarginY;
			e.Graphics.DrawLine( Pens.Black, x, y, ex, y);
			
			//切り出し矩形情報の作成
			y = BodySY + MarginY + TitleF.Height + MarginY + b.Height + MarginY;
			x = sx;
			e.Graphics.DrawString("☆切り出し矩形", f, Brushes.Black, x, y);
			RectangleF rf;
			StringFormat sf = new StringFormat();
			StringFormat sfc = new StringFormat();
			
			e.Graphics.DrawLine(Pens.Black, sx, y+f.Height+MarginY/2, ex, y+f.Height+MarginY/2);
			ChartSY = y+f.Height+MarginY/2;
			//列名作成
			y += f.Height + MarginY;
			sf.Alignment = StringAlignment.Center;
			rf = new RectangleF( x + (ex - x)/31*0, y, (ex - x)/31*2, f.Height);
			e.Graphics.DrawString("色", f, Brushes.Black, rf, sf);
			rf = new RectangleF( x + (ex - x)/31*2, y, (ex - x)/31*4, f.Height);
			e.Graphics.DrawString("高さ", f, Brushes.Black, rf, sf);
			rf = new RectangleF( x + (ex - x)/31*6, y, (ex - x)/31*4, f.Height);
			e.Graphics.DrawString("幅", f, Brushes.Black, rf, sf);
			rf = new RectangleF( x + (ex - x)/31*10, y, (ex - x)/31*6, f.Height);
			e.Graphics.DrawString("面積", f, Brushes.Black, rf, sf);
			rf = new RectangleF( x + (ex - x)/31*16, y, (ex - x)/31*6, f.Height);
			e.Graphics.DrawString("重心", f, Brushes.Black, rf, sf);
			rf = new RectangleF( x + (ex - x)/31*22, y, (ex - x)/31*9, f.Height);
			e.Graphics.DrawString("全重心との距離", f, Brushes.Black, rf, sf);
			e.Graphics.DrawLine(Pens.Black, sx, y+f.Height+MarginY/2, ex, y+f.Height+MarginY/2);
			
			sf.Alignment = StringAlignment.Far;
			sfc.Alignment = StringAlignment.Center;
			foreach(FrameDataClass fd in imageData.FrameData){
				y += f.Height + MarginY;
				Brush br = new SolidBrush(fd.FrameColor);
				rf = new RectangleF(x + (ex - x)/31*0, y, (ex - x)/31*2, f.Height);
				e.Graphics.DrawString("■", f, br, rf, sfc);
				e.Graphics.DrawString(fd.Height.ToString(), f, Brushes.Black, x + (ex - x)/31*6, y, sf);
				e.Graphics.DrawString(fd.Width.ToString(), f, Brushes.Black, x + (ex - x)/31*10, y, sf);
				e.Graphics.DrawString(fd.Area.ToString("N0"), f, Brushes.Black, x + (ex - x)/31*16, y, sf);
				rf = new RectangleF(x + (ex - x)/31*16, y, (ex - x)/31*6, f.Height);
				e.Graphics.DrawString("("+fd.Gravity.X.ToString() + "," + fd.Gravity.Y.ToString() +")", f, Brushes.Black, rf, sfc);
				double dist;
				int x1, x2, y1, y2;
				x1 = imageData.AllGravity.X;  x2 = fd.Gravity.X;
				y1 = imageData.AllGravity.Y;  y2 = fd.Gravity.Y;
				dist = Math.Sqrt((double)(((x1 - x2)*(x1 - x2)) + ((y1 - y2)*(y1 - y2))));
				e.Graphics.DrawString(dist.ToString("#,0"), f, Brushes.Black, x + (ex - x)/31*31, y, sf);
				e.Graphics.DrawLine(Pens.Black, sx, y+f.Height+MarginY/2, ex, y+f.Height+MarginY/2);
			
			}
			ChartEY = y + f.Height + MarginY/2;
			e.Graphics.DrawLine(Pens.Black, x + (ex - x)/31*0, ChartSY, x + (ex - x)/31*0, ChartEY);
			e.Graphics.DrawLine(Pens.Black, x + (ex - x)/31*2, ChartSY, x + (ex - x)/31*2, ChartEY);
			e.Graphics.DrawLine(Pens.Black, x + (ex - x)/31*6, ChartSY, x + (ex - x)/31*6, ChartEY);
			e.Graphics.DrawLine(Pens.Black, x + (ex - x)/31*10, ChartSY, x + (ex - x)/31*10, ChartEY);
			e.Graphics.DrawLine(Pens.Black, x + (ex - x)/31*16, ChartSY, x + (ex - x)/31*16, ChartEY);
			e.Graphics.DrawLine(Pens.Black, x + (ex - x)/31*22, ChartSY, x + (ex - x)/31*22, ChartEY);
			e.Graphics.DrawLine(Pens.Black, ex, ChartSY, ex, ChartEY);
			
			_copyNumber++;
			if(_copyNumber < e.PageSettings.PrinterSettings.Copies){
				e.HasMorePages = true;
			}else{
				e.HasMorePages = false;
				_copyNumber = 0;
			}
		}
		#endregion
		
		#region 重心線(放射線状)が押されたとき
		void BtnGraviHouCheckedChanged(object sender, EventArgs e)
		{
			ImageBox.Invalidate();
		}
		#endregion
		
		#region 重心線(連結)が押されたとき
		void BtnGraviJunCheckedChanged(object sender, EventArgs e)
		{
			ImageBox.Invalidate();
		}
		#endregion
		
		#region 初期処理
		void CharaImageFormLoad(object sender, EventArgs e)
		{
			this.comboColor.ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.comboColor.ComboBox.DrawItem += new DrawItemEventHandler(comboColorDrawItem);
			SetColorTbl(comboColor.ComboBox);
			comboColor.SelectedIndex = 0;
			
			this.comboGColor.ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.comboGColor.ComboBox.DrawItem += new DrawItemEventHandler(comboColorDrawItem);
			SetColorTbl(comboGColor.ComboBox);
			comboGColor.SelectedIndex = 0;
			comboGColor.SelectedIndex = GetSelectIndexFromColor(imageData.GravityColor);
			
		}
		#endregion
		
		void CharaImageFormResize(object sender, EventArgs e)
		{
			//panel1.Width = this.Width - 349;
			//ImageBox.Invalidate();
		}
		
		
		void BtnDataCopyClick(object sender, EventArgs e)
		{
			DataCopyMenuItemClick(sender, e);
		}
		
		#region windowの順番を並び替え
		static int CompareWindow(WindowSort x, WindowSort y){
			if(x.X > y.X)		return 1;
			else if(x.X < y.X)	return -1;
			else{
				//キーが同じだったら
				if(x.Y > y.Y)		return 1;
				else if(x.Y < y.Y)	return -1;
				else 				return 0;
			}
		}
		#endregion 
		
		#region 右画の列と入れ替える
		//2020.01.18 D.Honjyou
		void ChangeRightMenuItemClick(object sender, EventArgs e)
		{
			List<WindowSort> winList = new List<WindowSort>(new WindowSort[0] );
			CharaImageForm cif = this;
			int i=0;
			int currentX = 0;
			int RightX = 0;
			bool check = false;
			//現在画面に表示されている、子ウィンドウから、CharaImageFormをすべてWindowSortに入れる。
			foreach (Form cdif in mf.MdiChildren) {
				if(cdif.Name == "CharaImageForm"){
					winList.Add(new WindowSort(i, cdif.Left, cdif.Top, cdif.Name, cdif.Text));
				}
				i++;
			}
								
			//比較関数を指定してソート
			winList.Sort(CompareWindow);
			
			currentX = cif.Left;
			foreach (WindowSort s in winList) {
				if(s.X > currentX){
					RightX = s.X;
					check = true;
					break;
				}
			}
			if(check){
				foreach (WindowSort s in winList) {
					if(s.X == currentX){
						CharaImageForm m_cif;
						m_cif = (CharaImageForm)mf.MdiChildren[s.ID];
						m_cif.Left = RightX;
					}
					if(s.X == RightX){
						CharaImageForm m_cif;
						m_cif = (CharaImageForm)mf.MdiChildren[s.ID];
						m_cif.Left = currentX;
					}
				}
			}
		}
		#endregion

		#region ウィンドウが移動したとき
		//ウィンドウが移動したとき（その他の子ウィンドウに近い場合は、x座標を合わせる）
		private void CharaImageForm_ResizeEnd(object sender, EventArgs e)
        {
			this.Left = mf.GetNearLeftFromMdiChildren(this.Left, this.Text);
		}
        #endregion

        #region 右画の列と入れ替える
        //2020.01.18 D.Honjyou
        void ChangeLeftMenuItemClick(object sender, EventArgs e)
		{
			List<WindowSort> winList = new List<WindowSort>(new WindowSort[0] );
			CharaImageForm cif = this;
			int i=0;
			int currentX = 0;
			int LeftX = 0;
			bool check = false;
			//現在画面に表示されている、子ウィンドウから、CharaImageFormをすべてWindowSortに入れる。
			foreach (Form cdif in mf.MdiChildren) {
				if(cdif.Name == "CharaImageForm"){
					winList.Add(new WindowSort(i, cdif.Left, cdif.Top, cdif.Name, cdif.Text));
				}
				i++;
			}
								
			//比較関数を指定してソート
			winList.Sort(CompareWindow);
			
			currentX = cif.Left;
			winList.Reverse();
						
			foreach (WindowSort s in winList) {
				if(s.X < currentX){
					LeftX = s.X;
					check = true;
					break;
				}
			}
			if(check){
				foreach (WindowSort s in winList) {
					if(s.X == currentX){
						CharaImageForm m_cif;
						m_cif = (CharaImageForm)mf.MdiChildren[s.ID];
						m_cif.Left = LeftX;
					}
					if(s.X == LeftX){
						CharaImageForm m_cif;
						m_cif = (CharaImageForm)mf.MdiChildren[s.ID];
						m_cif.Left = currentX;
					}
				}
			}	
		}
		
		#endregion
	}
}
