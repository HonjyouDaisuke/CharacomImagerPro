/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2012/11/08
 * 時刻: 14:15
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace CharacomImagerPro
{
	/// <summary>
	/// Description of StringImageForm.
	/// </summary>
	public partial class StringImageForm : Form
	{
		//コマンドマネージャー
		public CommandManager undoManager = new CommandManager();
		//定数
		public const int BitmapWidth = 1280;
		public const int BitmapHeight = 320;
		public const int SmallWidth = 640;
		public const int SmallHeight = 160;
		public const int BitmapLong = 1280;
		public const int BitmapShort = 320;
		public const int FormSmallHeight = 403;
		public const int FormBigHeight = 550;
		
		private SetupClass _setup;
		//親フォームの参照
		private MainForm mf;
		private string _importFileName;
		public string ImportFileName {
			get { return _importFileName; }
			set { _importFileName = value; }
		}

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
		Bitmap viewBitmap;
		Bitmap procBitmap;
		Bitmap pictBitmap;
		Bitmap wideBitmap;
		Bitmap ListBmp;
		
		//イメージデータ
		private ImageDataClass imageData = new ImageDataClass(1280, 320);
		
		public ImageDataClass ImageData {
			get { return imageData; }
			set { imageData = value; }
		}
		
		#region ビットマッププロパティ
		public Bitmap SrcBitmap {
			get { return srcBitmap; }
			set { srcBitmap = value; }
		}
		
		public Bitmap PictBitmap {
			get { return pictBitmap; }
			set { pictBitmap = value; }
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
		
		Point mP,sP;
		ArrayList Points = new ArrayList();
		//ArrayList Frames = new ArrayList();
		int ActiveFrameNo = -1;
		double [] zoom = {4.0, 3.0, 2.0, 1.5, 1.0, 0.5};
		
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
		
		#region 最初のプロパティセット
		void SetFirstProperty()
		{
			StringImageFormProperties sifp = new StringImageFormProperties();
			this.Size = sifp.Form.Size;
			panel1.Location = sifp.Panel.Location;
			panel1.Size = sifp.Panel.Size;
			
			groupBox1.Location = sifp.GroupBox.Location;
			groupBox1.Size = sifp.GroupBox.Size;
			
			dgvFrameData.Location = sifp.DgvFrame.Location;
			dgvFrameData.Size = sifp.DgvFrame.Size;
			
			btnCSV.Location = sifp.BtnCSV.Location;
			btnCSV.Size = sifp.BtnCSV.Size;
		}
		#endregion
		
		#region 初期処理
		public StringImageForm(MainForm mainForm)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			this.comboColor.SelectedIndexChanged -= new EventHandler(ComboColorSelectedIndexChanged);
			this.comboColor.SelectedIndexChanged -= new EventHandler(ComboGColorSelectedIndexChanged);
			mf = mainForm;
			InitBitmaps(1280,320);
			cmbZoomTool.SelectedIndex = 4;
			
			SetFirstProperty();
			
			CheckUndoRedo();
			
			this.FileNameChanged += new System.EventHandler(this.OnFileNameChanged);
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		#endregion
		
		#region ファイル名が変更されたとき
		void OnFileNameChanged(object sender, EventArgs e)
		{
			//MainForm mf = (MainForm)this.MdiParent;
			mf.ChangeWindowListName(windowID, fileName);
			this.Text = mf.GetWindowTitle(windowID);
			//mf.ChangeWindowListName(windowID, fileName);
		}
		#endregion
		
		#region Bitmapの初期化処理
		private void InitBitmaps(int BitmapWidth, int BitmapHeight)
		{
			//Bitmapの作成
			srcBitmapSmall = new Bitmap(SmallWidth, SmallHeight);
			srcBitmap = new Bitmap(BitmapWidth, BitmapHeight);
			viewBitmap = new Bitmap(BitmapWidth, BitmapHeight);
			procBitmap = new Bitmap(BitmapWidth, BitmapHeight);
			pictBitmap = new Bitmap(BitmapWidth, BitmapHeight);
			wideBitmap = new Bitmap(BitmapWidth, BitmapHeight);
			
			//Bitmapを白で初期化
			imageEffect.BitmapWhitening(srcBitmapSmall);
			imageEffect.BitmapWhitening(srcBitmap);
			imageEffect.BitmapWhitening(viewBitmap);
			imageEffect.BitmapWhitening(procBitmap);
			imageEffect.BitmapWhitening(pictBitmap);
			imageEffect.BitmapWhitening(wideBitmap);
			
			panel1.Width = BitmapWidth;
			panel1.Height = BitmapHeight;
		}
		#endregion
		
		#region 無題をセット
		public void SetNonTitle()
		{
			//MainForm mf = (MainForm)this.MdiParent;
			FileName = "無題" + mf.GetTitleNo(this.Name).ToString() + ".csi";
		}
		#endregion
		
		public void ImageSizeChange(int width, int height)
		{
			if(width > height){
				InitBitmaps(BitmapLong, BitmapShort);
			}else{
				InitBitmaps(BitmapShort, BitmapLong);
			}
		}
				
		#region 画像のペースト
		public void PicturePaste()
		{
			IDataObject data = Clipboard.GetDataObject();
			
			if(data.GetDataPresent(DataFormats.Bitmap)){
				Bitmap OriginalBmp = new Bitmap((Image)data.GetData(DataFormats.Bitmap));
				if(OriginalBmp.Height > OriginalBmp.Width){
					InitBitmaps(BitmapShort, BitmapLong);
				}else{
					InitBitmaps(BitmapLong, BitmapShort);
				}
				//imageEffect.BitmapStretchCopy(PictBmp, thermoBitmap);
				
				//読み込んだ原画像を小さなソース画像にストレッチコピー
				imageEffect.BitmapStretchCopy(OriginalBmp, srcBitmapSmall);
				imageEffect.BitmapStretchCopy(OriginalBmp, pictBitmap);
				
				//2値化(判別分析法)
				imageEffect.ChrMonotoneProc(srcBitmapSmall);
				//前処理(大きさ変換)
	    		if(mf.Setup.StringNormalize == true){
	    			imageEffect.Normalize(srcBitmapSmall, mf.Setup.StringR);
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
	    		System.Diagnostics.Debug.WriteLine("imageData.Filename["+FileName+"]");
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
			if(OriginalBmp.Height > OriginalBmp.Width){
				InitBitmaps(BitmapShort, BitmapLong);
			}else{
				InitBitmaps(BitmapLong, BitmapShort);
			}
			//imageEffect.BitmapStretchCopy(PictBmp, thermoBitmap);
			
			//読み込んだ原画像を小さなソース画像にストレッチコピー
			imageEffect.BitmapStretchCopy(OriginalBmp, srcBitmapSmall);
			imageEffect.BitmapStretchCopy(OriginalBmp, pictBitmap);
			
			//2値化(判別分析法)
			imageEffect.ChrMonotoneProc(srcBitmapSmall);
			//前処理(大きさ変換)
    		if(mf.Setup.StringNormalize == true){
    			imageEffect.Normalize(srcBitmapSmall, mf.Setup.StringR);
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
    		System.Diagnostics.Debug.WriteLine("imageData.Filename["+FileName+"]");
    		imageData.AllRect = imageEffect.ImageClipping(srcBitmap, Points, work, Color.Black);
    		imageData.AllGravity = imageEffect.GetGravityPoint(srcBitmap);
    		imageData.PixelCount = imageEffect.GetPixelPoint(srcBitmap, 2);
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
    		
    		//TitleBarString();
		}
		#endregion
		
		#region 枠の描画
		void DrawWaku(Bitmap bmp)
		{
			if(Setup.EightLineVisible) imageEffect.Draw8x8x4Line(bmp, Setup.EightLineColor);
			if(Setup.CenterLineVisible) imageEffect.DrawCenterLine(bmp, Setup.CenterLineColor);
		}
		#endregion
		
		#region フレームを描画
		void DrawFrame(Bitmap bmp)
		{
			Point BeforeP = new Point(0, 0);
			Point BeforeTP = new Point(0, 0);
			Point BeforeBP = new Point(0, 0); 
			int i;
			i=0;
			foreach(FrameDataClass fdc in imageData.FrameData){
				if(imageData.FrameData.IndexOf(fdc) == ActiveFrameNo){
					imageEffect.DrawFrameActiveFrame(bmp, fdc.Frame, fdc.FrameColor);
				}else{
					imageEffect.DrawFrameAtColor(bmp, fdc.Frame, fdc.FrameColor);
				}
				if(btnGraviHou.Checked == true || btnGraviJun.Checked == true){
					imageEffect.DrawFrameGravityPoint(bmp, fdc.Gravity, imageData.GravityColor);
					//2021.10.03 D.Honjyou 頂点と底点を追加
					imageEffect.DrawFrameGravityPoint(bmp, fdc.TopPoint, imageData.GravityColor);
					imageEffect.DrawFrameGravityPoint(bmp, fdc.BottomPoint, imageData.GravityColor);
				}
				if(btnGraviHou.Checked == true){
					imageEffect.DrawFrameGravityLine(bmp, fdc.Gravity, imageData.AllGravity, imageData.GravityColor);
				}
				if(btnGraviJun.Checked == true && i > 0){
					imageEffect.DrawFrameGravityLine(bmp, fdc.Gravity, BeforeP, imageData.GravityColor);
					//2021.10.03 D.Honjyou 頂点と底点を追加
					imageEffect.DrawFrameGravityLine(bmp, fdc.TopPoint, BeforeTP, imageData.GravityColor);
					imageEffect.DrawFrameGravityLine(bmp, fdc.BottomPoint, BeforeBP, imageData.GravityColor);
				}
				BeforeP = fdc.Gravity;
				//2021.10.03 D.Honjyou 頂点と底点を追加
				BeforeTP = fdc.TopPoint;
				BeforeBP = fdc.BottomPoint;
				i++;		
			}
		}
		#endregion
		
		#region ペイント処理
		void ImageBoxPaint(object sender, PaintEventArgs e)
		{
			Bitmap vBmp = new Bitmap(viewBitmap.Width, viewBitmap.Height);
			imageEffect.BitmapCopy(viewBitmap, vBmp);
			DrawFrame(vBmp);
			DrawWaku(vBmp);
			e.Graphics.DrawImage(vBmp,0,0);
			
		}
		#endregion
		
		#region 画像データ配列を更新
		public void UpdateImageData()
		{
			//MainForm mf = (MainForm)this.MdiParent;
			
			System.Diagnostics.Debug.WriteLine(ImageData.SrcImage.ToString());
			//System.Diagnostics.Debug.WriteLine(imageData.SrcImageSmall.ToString());
			imageEffect.BitmapCopy(srcBitmap, imageData.SrcImage);
			//imageEffect.BitmapCopy(srcBitmapSmall, imageData.SrcImageSmall);
			imageEffect.BitmapCopy(viewBitmap, imageData.ViewImage);
			imageEffect.BitmapCopy(procBitmap, imageData.ProcImage);
			imageData.Filename = this.FileName;
			if(mf != null){
				mf.UpdateLapForm();
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
		
		#region 位置がキャンバス内かどうかのチェック
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
		
		#region マウスが離されたとき
		void ImageBoxMouseUp(object sender, MouseEventArgs e)
		{
			if(btnPencil.Checked == true && imageProc != CharaImageForm.ProcThermo){
				if(Points.Count > 2){
					FrameDataClass fdc = new FrameDataClass(1280, 320);
				
					fdc.FrameColor = mf.Setup.DisplayColor[comboColor.SelectedIndex];
					fdc.Frame =	imageEffect.ImageClipping(procBitmap, Points, fdc.Bmp, fdc.FrameColor);
					if(imageEffect.WhiteCanvasCheck(fdc.Bmp)){
						//エディット画面を表示する
						int startx = 0;
						Point g;
						g = imageEffect.GetGravityPoint(fdc.Bmp);
						System.Diagnostics.Debug.WriteLine("Gravity = " + g.ToString());
						if(g.X - 160 > 0){
							startx = g.X -160;
						}else{
							startx = 0;
						}
						CharaEditForm cef = new CharaEditForm(1280, 320, startx, 0);
						
						imageEffect.BitmapCopy(fdc.Bmp, cef.srcBitmap);
						imageEffect.BitmapCopy(fdc.Bmp, cef.viewBitmap);
						cef.imageForeColor = fdc.FrameColor;
						cef.FrameData = fdc;
						
						DialogResult dr;
						cef.StartPosition = FormStartPosition.CenterParent;
						dr = cef.ShowDialog();
						if(dr == DialogResult.OK){
							//矩形データを作成
							fdc = cef.FrameData;
							fdc.Gravity = imageEffect.GetGravityPoint(fdc.Bmp);
							Point [] tmp = new Point[2];
							tmp = imageEffect.GetTopBotomPoint(fdc.Bmp);
							System.Diagnostics.Debug.WriteLine($"最大点({tmp[1].X},{tmp[1].Y}) 最小点({tmp[0].X},{tmp[0].Y})");
							fdc.TopPoint = tmp[0];
							fdc.BottomPoint = tmp[1];
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
							NewRow.Cells[6].Value = "(" + fdc.TopPoint.X.ToString("#,0") + ", " + fdc.TopPoint.Y.ToString("#,0") + ")";
							NewRow.Cells[7].Value = "(" + fdc.BottomPoint.X.ToString("#,0") + ", " + fdc.BottomPoint.Y.ToString("#,0") + ")";
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
		
		#region Undo、Redoのメニューをチェック
		void CheckUndoRedo()
		{
			RedoMenuItem.Enabled = undoManager.CanRedo();
			UndoMenuItem.Enabled = undoManager.CanUndo();
			btnUndo.Enabled = undoManager.CanUndo();
			btnRedo.Enabled = undoManager.CanRedo();
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
		
		#region コンボボックスのオーナー描画
		void StringImageFormLoad(object sender, EventArgs e)
		{
			this.comboColor.ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.comboColor.ComboBox.DrawItem += new DrawItemEventHandler(comboColorDrawItem);
			SetColorTbl(comboColor.ComboBox);
			comboColor.SelectedIndex = 0;
			
			this.comboGColor.ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.comboGColor.ComboBox.DrawItem += new DrawItemEventHandler(comboColorDrawItem);
			SetColorTbl(comboGColor.ComboBox);
			
			comboGColor.SelectedIndex = GetSelectIndexFromColor(imageData.GravityColor);
		}
		
		#region カラー情報からのコンボボックス選択インデックス
		int GetSelectIndexFromColor(Color c)
		{
			int rsi = 1;
			Color sc;
			System.Diagnostics.Debug.WriteLine("c="+c.ToString());
			for(int i=0; i<mf.Setup.DisplayColor.Length; i++){
				sc = mf.Setup.DisplayColor[i];
				//System.Diagnostics.Debug.WriteLine("Setup:"+sc.ToString());
				if(sc.R == c.R && sc.G == c.G && sc.B == c.B){
					rsi = i;
				}
			}
			return(rsi);
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
		#endregion
		
		#region 重心線 放射状？連結？
		void BtnGraviHouCheckedChanged(object sender, EventArgs e)
		{
			ImageBox.Invalidate();
		}
		
		void BtnGraviJunCheckedChanged(object sender, EventArgs e)
		{
			ImageBox.Invalidate();
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
		
		#region ウィンドウが開かれたとき
		void StringImageFormShown(object sender, EventArgs e)
		{
			string titleName = "";
			windowID = mf.AddWindowList(this.Name, fileName);
			titleName = mf.GetWindowTitle(windowID);
			this.Text = titleName;
			this.Height = FormBigHeight;
			this.comboColor.SelectedIndexChanged += new EventHandler(ComboColorSelectedIndexChanged);
			this.comboColor.SelectedIndexChanged += new EventHandler(ComboGColorSelectedIndexChanged);
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
      					Bitmap bbb = new Bitmap(StringImageForm.SmallWidth, StringImageForm.SmallHeight);
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
					
				//case CharaImageForm.ProcFeature:
				//	FeatureForm ff = new FeatureForm();
				//	imageEffect.BitmapStretchCopy(srcBitmap, ff.SrcBitmapSmall);
				//	ff.MakeFeature();
				//	ff.MakeGraph();
				//	ff.MdiParent = this.MdiParent;
				//	ff.SetNonTitle();
				//	ff.Show();
				//	break;
					
				//case CharaImageForm.ProcHaikei:
				//	HaikeiDenpanForm hf = new HaikeiDenpanForm();
				//	imageEffect.BitmapStretchCopy(srcBitmap, hf.SrcBitmapSmall);
				//	hf.MakeFeature();
				//	hf.MakeGraph();
				//	hf.MdiParent = this.MdiParent;
				//	hf.SetNonTitle();
				//	hf.Show();
				//	break;
					
				default:
					imageEffect.BitmapCopy(srcBitmap, procBitmap);
					break;
			}
			imageEffect.BitmapCopy(procBitmap, viewBitmap);
			UpdateImageData();
		}
		#endregion
		
		#region ウィンドウサイズの変更
		void ChangeFormSize()
		{
			if(btnProperty.Checked == true){
				this.Height = FormBigHeight;
			}else{
				this.Height = FormBigHeight;
			}
		}
		#endregion
		
		#region csiデータ保存処理
		void SaveCSIData(string filename)
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
		
		#region csiデータ開く処理
		public bool OpenCSIData(string filename)
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
				dgvFrameData.Rows[dgvFrameData.Rows.Count - 1].Cells[6].Value = "(" + fdc.TopPoint.X.ToString("#,0") + ", " + fdc.TopPoint.Y.ToString("#,0") + ")";
				dgvFrameData.Rows[dgvFrameData.Rows.Count - 1].Cells[7].Value = "(" + fdc.BottomPoint.X.ToString("#,0") + ", " + fdc.BottomPoint.Y.ToString("#,0") + ")";

			}

			mf.AddRecentlyFile(filename);
			return(true);
		}
		#endregion
		
		#region リスト画像を作成
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
			int hx = MarginX / 2;
			int hy = MarginY / 2;
				
			//ヘッダー部
			if(imageData.FrameData.Count > 0){
				g.DrawLine(Pens.Black, x, y, ex-1, y);
				g.DrawLine(Pens.Black, x, y, x, ey-1);
				g.DrawString("色", DataFont, Brushes.Black, workx+hx, y+hy);
				workx += ColorWidth+MarginX;
				g.DrawLine(Pens.Black, workx, y, workx, ey-1);
				g.DrawString("高さ", DataFont, Brushes.Black, workx+hx, y+hy);
				workx += HeightWidth+MarginX;
				g.DrawLine(Pens.Black, workx, y, workx, ey-1);
				g.DrawString("幅", DataFont, Brushes.Black, workx+hx, y+hy);
				workx += WidthWidth+MarginX;
				g.DrawLine(Pens.Black, workx, y, workx, ey-1);
				g.DrawString("面積", DataFont, Brushes.Black, workx+hx, y+hy);
				workx += SizeWidth+MarginX;
				g.DrawLine(Pens.Black, workx, y, workx, ey-1);
				g.DrawString("重心", DataFont, Brushes.Black, workx+hx, y+hy);
				workx += GravityWidth+MarginX;
				g.DrawLine(Pens.Black, workx, y, workx, ey-1);
				g.DrawString("重心との距離", DataFont, Brushes.Black, workx+hx, y+hy);
				workx += DistanceWidth+MarginX;
				g.DrawLine(Pens.Black, workx, y, workx, ey-1);
			
				//データ部
				y += DataFont.Height + MarginY;
				g.DrawLine(Pens.Black, x, y, ex-1, y);
				
				foreach(FrameDataClass fdc in imageData.FrameData){
					workx = x;
					g.FillRectangle(new SolidBrush(fdc.FrameColor), workx+2+hx, y+2+hy, ColorWidth-4, DataFont.Height-4);
					workx += ColorWidth + MarginX;
					g.DrawString(fdc.Height.ToString("#,0"), DataFont, Brushes.Black, workx+hx, y+hy);
					workx += HeightWidth + MarginX;
					g.DrawString(fdc.Width.ToString("#,0"), DataFont, Brushes.Black, workx+hx, y+hy);
					workx += WidthWidth + MarginX;
					g.DrawString(fdc.Area.ToString("#,0"), DataFont, Brushes.Black, workx+hx, y+hy);
					workx += SizeWidth + MarginX;
					g.DrawString("("+fdc.Gravity.X.ToString("#,0")+","+fdc.Gravity.Y.ToString("#,0")+")", DataFont, Brushes.Black, workx+hx, y+hy);
					workx += GravityWidth + MarginX;
					double dist;
					int x1, x2, y1, y2;
					x1 = imageData.AllGravity.X;  x2 = fdc.Gravity.X;
					y1 = imageData.AllGravity.Y;  y2 = fdc.Gravity.Y;
					dist = Math.Sqrt((double)(((x1 - x2)*(x1 - x2)) + ((y1 - y2)*(y1 - y2))));
					g.DrawString(dist.ToString("#,0"), DataFont, Brushes.Black, workx+hx, y+hy);
				
					y += DataFont.Height + MarginY;
					g.DrawLine(Pens.Black, x, y, ex-1, y);
				}
			}
			g.Dispose();
		}
		#endregion
		
		#region コンテキストメニュー
		void CopyMenuItemClick(object sender, EventArgs e)
		{
			Bitmap clipBmp = new Bitmap(viewBitmap);
	
			DrawFrame(clipBmp);
			DrawWaku(clipBmp);
			
			imageEffect.BitmapDrawFrame(clipBmp);
			Clipboard.SetImage(clipBmp);
			
			clipBmp.Dispose();
		}
		void DataCopyMenuItemClick(object sender, EventArgs e)
		{
			Bitmap imageBmp = new Bitmap(viewBitmap);
	
			DrawFrame(imageBmp);
			DrawWaku(imageBmp);
			
			imageEffect.BitmapDrawFrame(imageBmp);
			
			MakeList();
			
			//つなげる
			Bitmap clipBmp = new Bitmap(imageBmp.Width, imageBmp.Height + ListBmp.Height);
			imageEffect.BitmapWhitening(clipBmp);
			
			imageEffect.BitmapCopyXY(imageBmp, clipBmp, 0, 0);
			imageEffect.BitmapCopyXY(ListBmp, clipBmp, 0, imageBmp.Height + 1);
			Clipboard.SetImage(clipBmp);
		}
		
		void UndoMenuItemClick(object sender, EventArgs e)
		{
			undoManager.Undo();
			ActiveFrameNo = -1;
			RefleshImageWindow();
			//imageEffect.BitmapCopy(procBitmap, viewBitmap);
			//ImageBox.Invalidate();
			dgvFrameData.Refresh();
		}
		
		void RedoMenuItemClick(object sender, EventArgs e)
		{
			undoManager.Redo();
			ActiveFrameNo = -1;
			RefleshImageWindow();
			//imageEffect.BitmapCopy(procBitmap, viewBitmap);
			//ImageBox.Invalidate();
			dgvFrameData.Refresh();
		}
		
		void OpenMenuItemClick(object sender, EventArgs e)
		{
			if(openCCIDialog.ShowDialog() == DialogResult.OK){
				//MainForm mf = (MainForm)this.MdiParent;
				if(mf.IsOpened(openCCIDialog.FileName)){
					this.Close();
				}else{
					FileName = openCCIDialog.FileName;
					OpenCSIData(openCCIDialog.FileName);
				}
			}
		}
		
		void ImportMenuItemClick(object sender, EventArgs e)
		{
			if(openImageDialog.ShowDialog() == DialogResult.OK){
				_importFileName = openImageDialog.FileName;
				FileName = System.IO.Path.GetDirectoryName(openImageDialog.FileName) + "\\" + System.IO.Path.GetFileNameWithoutExtension(openImageDialog.FileName) + ".csi";
				PictureFileRead();
				ImageBox.Invalidate();
			}
		}
		
		void PasteMenuItemClick(object sender, EventArgs e)
		{
			PicturePaste();
			ImageBox.Invalidate();
		}
		
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
		void SaveMenuItemClick(object sender, EventArgs e)
		{
			if(HasString(FileName, "無題")){
				SaveAtMenuItemClick(sender, e);
			}else{
				SaveCSIData(FileName);
			}
		}
		
		void SaveAtMenuItemClick(object sender, EventArgs e)
		{
			if(saveCCIDialog.ShowDialog() == DialogResult.OK){
				FileName = saveCCIDialog.FileName;
				SaveCSIData(FileName);
				if(this.MdiParent != null){
					//MainForm mf = (MainForm)this.MdiParent;
					mf.UpdateLapForm();
				}
			}
		}
		
		void PreViewMenuItemClick(object sender, EventArgs e)
		{
			printPreviewDlg.StartPosition = FormStartPosition.CenterParent;
			printPreviewDlg.ShowDialog();
		}
		
		void PrintMenuItemClick(object sender, EventArgs e)
		{
			if(printDlg.ShowDialog() == DialogResult.OK){
				printDoc.PrinterSettings.Copies = printDlg.PrinterSettings.Copies;
				printDoc.Print();
			}
		}
		
		void PageSetupMenuIteClick(object sender, EventArgs e)
		{
			pageSetupDlg.ShowDialog();
		}
		
		void OpenNewMenuItemClick(object sender, EventArgs e)
		{
			mf.MenuStringNewClick(sender, e);
		}
		
		void UpDownArignMenuItemClick(object sender, EventArgs e)
		{
			this.MdiParent.LayoutMdi(MdiLayout.TileHorizontal);
		}
		
		void LRAlignMenuItemClick(object sender, EventArgs e)
		{
			this.MdiParent.LayoutMdi(MdiLayout.TileVertical);
		}
		
		void OverAlignMenuItemClick(object sender, EventArgs e)
		{
			this.MdiParent.LayoutMdi(MdiLayout.Cascade);
		}
		
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
		
		void CloseMenuItemClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void ImageSaveMenuItemClick(object sender, EventArgs e)
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
		
		#region ツールバーメニュー
		void BtnCopyToolClick(object sender, EventArgs e)
		{
			CopyMenuItemClick(sender, e);
		}
		
		void BtnDataCopyClick(object sender, EventArgs e)
		{
			DataCopyMenuItemClick(sender, e);
		}
		
		void BtnPropertyCheckedChanged(object sender, EventArgs e)
		{
			ChangeFormSize();
		}
		
		void BtnSaveToolClick(object sender, EventArgs e)
		{
			SaveMenuItemClick(sender, e);
		}
		
		void CmbZoomToolSelectedIndexChanged(object sender, EventArgs e)
		{
			ImageBox.Invalidate();
		}
		
		#region 色選択の変更
		void ComboColorSelectedIndexChanged(object sender, EventArgs e)
		{
			//ImageProcessSwitcher();
			System.Diagnostics.Debug.WriteLine("ColorChange");
			comboColor.ComboBox.SelectedIndexChanged -= new EventHandler(ComboColorSelectedIndexChanged);
			Bitmap bmp = new Bitmap(35, 16);
			imageEffect.BitmapWhitening(bmp);
			//if(btnPencil.Checked == false){
				if(ActiveFrameNo >= 0){
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
					}
					
					
				}else{
					Regex r = new Regex("System.Windows.Forms.ToolStripComboBox*");
					Match m = r.Match(sender.ToString());
					if(!m.Success){
						//コマンドマネージャでUndo実装
						//2012.02.13 D.Honjyou
						ImageColorChangeCommand command = new ImageColorChangeCommand(procBitmap, mf.Setup.DisplayColor[comboColor.SelectedIndex]);
						undoManager.Action(command);
						imageEffect.BitmapCopy(procBitmap, viewBitmap);
						ImageBox.Invalidate();
						CheckUndoRedo();
					}
				}
			//}
			
			UpdateImageData();
			ImageBox.Invalidate();
			comboColor.ComboBox.SelectedIndexChanged += new EventHandler(ComboColorSelectedIndexChanged);
		}
		#endregion
		
		void BtnUndoClick(object sender, EventArgs e)
		{
			UndoMenuItemClick(sender, e);
		}
		
		void BtnRedoClick(object sender, EventArgs e)
		{
			RedoMenuItemClick(sender, e);
		}
		#endregion
		
		#region フォームが閉じられるときに
		void StringImageFormFormClosing(object sender, FormClosingEventArgs e)
		{
			if(undoManager.CanUndo()){
				DialogResult dr;
				dr = MessageBox.Show("[" + System.IO.Path.GetFileName(FileName) + "] は変更されています。閉じる前に保存しますか？", "Characom Imager Pro", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
				if(dr == DialogResult.Yes){
					SaveAtMenuItemClick(sender, e);
				}else if(dr == DialogResult.Cancel){
					e.Cancel = true;
					return;
				}
			}
			
			
			//メインフォームにウィンドウリストから削除してもらう
			//MainForm mf = (MainForm)MdiParent;
			mf.RemoveWindowAtID(windowID);
		}
		#endregion
		
		#region フォームのサイズが変わったら
		void StringImageFormResize(object sender, EventArgs e)
		{
			if(this.Height - 416 > 0){
				dgvFrameData.Height = this.Height - 436;
			}else{
				dgvFrameData.Height = 0;
			}
		}
		#endregion 
		
		void ComboGColorSelectedIndexChanged(object sender, EventArgs e)
		{
			comboGColor.ComboBox.SelectedIndexChanged -= new EventHandler(ComboGColorSelectedIndexChanged);
			imageData.GravityColor = mf.Setup.DisplayColor[comboGColor.SelectedIndex];
			ImageBox.Invalidate();
			comboGColor.ComboBox.SelectedIndexChanged += new EventHandler(ComboGColorSelectedIndexChanged);
		}
		
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
		
		void PrintDocPrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			printDoc.DocumentName = "文字列処理画像[" + System.IO.Path.GetFileName(FileName) + "]";
			Font HeaderF = new Font("メイリオ", 8, FontStyle.Bold);
			Font FooterF = new Font("メイリオ", 8, FontStyle.Bold);
			//int MarginX = 5;
			int MarginY = 5;
			
			Font f = new Font("メイリオ", 10, FontStyle.Bold);
			int x, y;
			int sx, sy, ex, ey;
			int BodySY, BodyEY;
			
			x = e.MarginBounds.X; y = e.MarginBounds.Y;
			
			sx = e.MarginBounds.X; sy = e.MarginBounds.Y;
			ex = e.MarginBounds.Right; ey = e.MarginBounds.Bottom;
			
			PrintParts pp = new PrintParts();
			Rectangle r = pp.HeaderFooterDraw(e);
			BodySY = r.Y;
			BodyEY = r.Bottom;
			
			//タイトルを作成
			Font TitleF = new Font("メイリオ", 12, FontStyle.Bold);
			e.Graphics.DrawString("■文字列 処理画像 [" + System.IO.Path.GetFileName(FileName) + "]", TitleF, Brushes.Black, sx, BodySY + MarginY);
			
			//画像を作成
			Bitmap b = new Bitmap(ViewBitmap.Width, ViewBitmap.Height);
			imageEffect.BitmapCopy(viewBitmap, b);
			DrawFrame(b);
			DrawWaku(b);
			imageEffect.BitmapDrawFrame(b);
			
			int resizeWidth = e.MarginBounds.Width;
			int resizeHeight = (int)(b.Height * ((double)resizeWidth / (double)b.Width));
			Bitmap resizeBmp = new Bitmap(resizeWidth, resizeHeight);
			
			Graphics g = Graphics.FromImage(resizeBmp);

			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

			g.DrawImage(b, 0, 0, resizeWidth, resizeHeight);

			x = sx; y = BodySY+MarginY+TitleF.Height+MarginY;
			e.Graphics.DrawImage(resizeBmp, x, y, resizeBmp.Width, resizeBmp.Height);
			y += resizeBmp.Height;
			
			
			MakeList();
			
			resizeHeight = ListBmp.Height;
			resizeWidth = ListBmp.Width;
			
			if(ListBmp.Height > e.MarginBounds.Height - HeaderF.Height*2 - MarginY*2 - resizeBmp.Height - TitleF.Height*2 - MarginY*2){
				resizeHeight = e.MarginBounds.Height - HeaderF.Height*2 - MarginY*2 - resizeBmp.Height - TitleF.Height*2 - MarginY*2;
				resizeWidth = (int)(ListBmp.Width * ((double)resizeHeight / (double)ListBmp.Height));
			}
			System.Diagnostics.Debug.WriteLine("e.MarginBounds.Height:" + e.MarginBounds.Height.ToString());
			System.Diagnostics.Debug.WriteLine("resizeHeight:" + resizeHeight.ToString());
			Bitmap resizeListBmp = new Bitmap(resizeWidth, resizeHeight);
			g = Graphics.FromImage(resizeListBmp);

			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

			g.DrawImage(ListBmp, 0, 0, resizeWidth, resizeHeight);

			e.Graphics.DrawImage(resizeListBmp, x, y, resizeListBmp.Width, resizeListBmp.Height);
			g.Dispose();
		}

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

		void BtnPrintToolClick(object sender, EventArgs e)
		{
			PrintMenuItemClick(sender, e);
		}
	}
	public class StringImageFormProperties
	{
		LocationSize _form = new LocationSize(0, 0, 1300, 571);
		
		public LocationSize Form {
			get { return _form; }
		}
		LocationSize _panel = new LocationSize(0, 35, 1280, 320);
		
		public LocationSize Panel {
			get { return _panel; }
		}
		LocationSize _groupBox = new LocationSize(12, 362, 335, 90);
		
		public LocationSize GroupBox {
			get { return _groupBox; }
		}
		LocationSize _btnCSV = new LocationSize(272, 448, 75, 26);
		
		public LocationSize BtnCSV {
			get { return _btnCSV; }
		}
		LocationSize _dgvFrame = new LocationSize(353, 362, 470, 126);
		
		public LocationSize DgvFrame {
			get { return _dgvFrame; }
		}
		
		public StringImageFormProperties()
		{
		
		}
	}
	
}
