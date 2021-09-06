/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2013/11/24
 * 時刻: 18:49
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
//using WinTabDotnet;

namespace CharacomImagerPro
{
	/// <summary>
	/// Description of InputCharaForm.
	/// </summary>
	public partial class InputCharaForm : Form
	{
		ImageEffect imageEffect = new ImageEffect();
		/// <summary>原画像用ビットマップ</summary>
		private Bitmap srcBitmap;
		/// <summary>作業用ビットマップ</summary>
		private Bitmap workBitmap;
		/// <summary>表示用ビットマップ</summary>
		private Bitmap viewBitmap;
		private Bitmap wideBitmap;
		private Bitmap cursorBitmap;
		Point mP,sP;
		/// <summary>表示色</summary>
		public Color imageForeColor;
		
		private MainForm mf;
		//WinTab用オブジェクト
		//private WinTabMessenger  m_wtMessenger;
        //private WinTabContext    m_wtContext;

		#region カーソルファイル
		System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
		Cursor PenSCur;
		Cursor PenMCur;
		Cursor PenLCur;
		Cursor PointCur;
		#endregion
		
		public InputCharaForm(MainForm mainForm)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			
			this.comboColor.SelectedIndexChanged -= new EventHandler(ComboColorSelectedIndexChanged);
			InitBitmaps();
			//cmbZoomTool.SelectedIndex = 4;
			//MessageBox.Show(asm.GetName().Name);
			PenSCur = new Cursor(asm.GetManifestResourceStream(asm.GetName().Name + ".pen_i.cur"));
			PenMCur = new Cursor(asm.GetManifestResourceStream(asm.GetName().Name + ".pen_im.cur"));
			PenLCur = new Cursor(asm.GetManifestResourceStream(asm.GetName().Name + ".pen_il.cur"));
			PointCur = new Cursor(asm.GetManifestResourceStream(asm.GetName().Name + ".cross_r.cur"));
		
			mf = mainForm;
			/***
			#region WinTabProgram
			//WinTabプログラム
			if (!WinTab.LoadWinTab()) {
                MessageBox.Show("ペンタブレットが見つかりません(WinTab32.dllが見つかりません)。","WinTab.NET");
                throw new WinTabException("WinTab.NETの初期化に失敗しました。");
            }

            m_wtMessenger = new WinTabMessenger();
            m_wtContext = new WinTabContext();

            //this.Text = WinTab.DeviceName + " Sample";
            lblWinTabID.Text     = WinTab.WinTabID;
            lblDeviceName.Text   = WinTab.DeviceName;
            prgPressuer.Maximum = WinTab.DeviceNPressure.axMax;

            //m_wtMessenger.CursorMove += new CursorMoveHandler(m_wtMessenger_CursorMove);
            //m_wtMessenger.NPressureChange += new NPressureChangeHandler(m_wtMessenger_NPressureChange);
			m_wtMessenger.CursorMove += delegate(PacketEventArgs e) {
            	lblPosition.Text = e.pkts.pkX.ToString() + "," + e.pkts.pkY.ToString() + "," + e.pkts.pkZ.ToString();
            	System.Diagnostics.Debug.WriteLine("kimasita");
            };
            m_wtMessenger.NPressureChange += delegate(PacketEventArgs e) { 
            	lblPressure.Text = e.pkts.pkNormalPressure.ToString(); 
            	prgPressuer.Value = e.pkts.pkNormalPressure; 
            	System.Diagnostics.Debug.WriteLine("Kimasita2");
            };
            //m_wtMessenger.CursorChange += delegate(PacketEventArgs e) { lblCursor.Text = e.pkts.pkCursor.ToString(); };
            m_wtContext.Open(this.Handle,true);
            #endregion
			****/
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		/***
		#region WinTab用 WndProcオーバーライド
		protected override void WndProc(ref Message m) {
			if (!m_wtMessenger.WndProc(ref m)) { 
				base.WndProc(ref m);
				System.Diagnostics.Debug.WriteLine("ttt"+m.Msg.ToString());
			}
        }
		#endregion
		
		void InputCharaFormActivated(object sender, EventArgs e)
		{
			m_wtContext.Overlap(true);
			System.Diagnostics.Debug.WriteLine("SwitchON");
		}
		
		void InputCharaFormDeactivate(object sender, EventArgs e)
		{
			m_wtContext.Overlap(false);
			System.Diagnostics.Debug.WriteLine("SwitchOFF");
		}
		
		#region WinTab用 筆圧変化イベント
		void m_wtMessenger_NPressureChange(PacketEventArgs e) {
			lblPosition.Text = e.pkts.pkNormalPressure.ToString();
            this.Invalidate();
        }
		#endregion
		
		#region WinTab用 筆圧変化イベント
        void m_wtMessenger_CursorMove(PacketEventArgs e) {
			lblPosition.Text = e.pkts.pkX.ToString() + ","+e.pkts.pkY.ToString()+","+e.pkts.pkZ.ToString();
			System.Diagnostics.Debug.WriteLine("きました");
			//px = e.pkts.pkX;
            //py = e.pkts.pkY;
            this.Invalidate();
        }
		#endregion
		****/
		
		#region フォームの呼び出し
		void InputCharaFormLoad(object sender, EventArgs e)
		{
			this.comboColor.ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.comboColor.ComboBox.DrawItem += new DrawItemEventHandler(comboColorDrawItem);
			SetColorTbl(comboColor.ComboBox);
			comboColor.SelectedIndex = 40;
			cmbLineSize.SelectedIndex = 2;
			ChangeMouseCursor();
			
			btnString.Checked = false;
		}
		#endregion
		
		#region Bitmapの初期化処理
		private void InitBitmaps()
		{
			//Bitmapの作成
			//srcBitmap = new Bitmap(frameSize.Width, frameSize.Height);
			//viewBitmap = new Bitmap(frameSize.Width, frameSize.Height);
			//workBitmap = new Bitmap(frameSize.Width, frameSize.Height);
			srcBitmap = new Bitmap(320, 320);
			viewBitmap = new Bitmap(320, 320);
			workBitmap = new Bitmap(320, 320);
			cursorBitmap = new Bitmap( 10, 10);
			
			//Bitmapを白で初期化
			imageEffect.BitmapWhitening(srcBitmap);
			imageEffect.BitmapWhitening(viewBitmap);
			imageEffect.BitmapWhitening(workBitmap);
			imageEffect.BitmapWhitening(cursorBitmap);
		}
		#endregion
		
		#region 枠の描画
		private void DrawWaku(Bitmap bmp)
		{
			//MainForm mf = new MainForm();
			//mf = (MainForm)this.MdiParent;
			
			if(mf.Setup.EightLineVisible){
				if(btnString.Checked)	imageEffect.Draw8x8x4Line(bmp, mf.Setup.EightLineColor);
				else					imageEffect.Draw8x8Line(bmp, mf.Setup.EightLineColor);
			}
			if(mf.Setup.CenterLineVisible) imageEffect.DrawCenterLine(bmp, mf.Setup.CenterLineColor);
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
			ColorRect.Width = 50;
			ColorRect.Height = e.Bounds.Height -4;
			
			e.DrawBackground();
			
			Brush b = new SolidBrush(mf.Setup.DisplayColor[e.Index]);
			//e.Graphics.DrawString(mf.Setup.DisplayColor[e.Index].Name, e.Font, Brushes.Black, TextRect);
			e.Graphics.FillRectangle(b, ColorRect);
			e.Graphics.DrawRectangle(Pens.Black, ColorRect);
			e.DrawFocusRectangle();
		}
		#endregion
		
		#region 画像ファイル読み込み(インポート)
		public void PictureFileRead(string FileName)
		{
			//System.Diagnostics.Debug.WriteLine(ImportFileName + "を開きますぞ");
			//ファイルの存在確認
			if(System.IO.File.Exists(FileName) == false){
				MessageBox.Show("ファイルが存在しません。\n画像ファイルを確認してください。\n\n"+FileName, "画像ファイル オープンエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
						
			//画像ファイルかどうかのチェック
			if(imageEffect.IsImageFile(FileName) == false){
				MessageBox.Show("画像ファイルではありません。\n画像ファイルを確認してください。\n\n"+FileName, "画像ファイル オープンエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			Bitmap OriginalBmp = new Bitmap(FileName);
			
			//読み込んだ原画像をソース画像にストレッチコピー
			imageEffect.BitmapStretchCopy(OriginalBmp, srcBitmap);
			
			imageEffect.BitmapCopy(srcBitmap, viewBitmap);
			imageEffect.BitmapWhitening(workBitmap);
		}
		#endregion
		
		#region ファイルを開くボタン
		void BtnOpenClick(object sender, EventArgs e)
		{
			if(openFileDlg.ShowDialog() == DialogResult.OK){
				PictureFileRead(openFileDlg.FileName);
				ImageBox.Invalidate();
			}
		}
		#endregion
		
		#region 画像として保存ボタン
		void BtnSaveImageClick(object sender, EventArgs e)
		{
			if(saveFileDlg.ShowDialog() == DialogResult.OK){
				if(imageEffect.IsImageFile(saveFileDlg.FileName)){
					Bitmap clipBmp = new Bitmap(srcBitmap);
					//DrawFrame(clipBmp);
					//DrawWaku(clipBmp);
			
					//imageEffect.BitmapDrawFrame(clipBmp);
					clipBmp.Save(saveFileDlg.FileName, imageEffect.GetImageFormat(saveFileDlg.FileName));
				}
			}
		}
		#endregion
		
		#region マウスカーソル変更
		private void ChangeMouseCursor()
		{
			if(btnEraser.Checked == true){
				ImageBox.Cursor = PointCur;
			}else{
				if(cmbLineSize.SelectedIndex < 2){
					ImageBox.Cursor = PenSCur;
				}else if(cmbLineSize.SelectedIndex < 3){
					ImageBox.Cursor = PenMCur;
				}else{
					ImageBox.Cursor = PenLCur;
				}
			}
		}
		#endregion
		
		#region DB保存ボタン
		void BtnSaveDBClick(object sender, EventArgs e)
		{
			DBSaveForm dbs = new DBSaveForm(mf, srcBitmap);
			dbs.StartPosition = FormStartPosition.CenterParent;
			dbs.ShowDialog();
		}
		#endregion
		
		#region えんぴつボタン
		void BtnPenClick(object sender, EventArgs e)
		{
			btnPen.Checked = true;
			btnEraser.Checked = false;
			ChangeMouseCursor();
		}
		#endregion
		
		#region 消しゴムボタン
		void BtnEraserClick(object sender, EventArgs e)
		{
			btnEraser.Checked = true;
			btnPen.Checked = false;
			ChangeMouseCursor();
		}
		#endregion
		
		#region ImageBoxのペイント処理
		void ImageBoxPaint(object sender, PaintEventArgs e)
		{
			Bitmap vBmp = new Bitmap(viewBitmap.Width, viewBitmap.Height);
			imageEffect.BitmapCopy(viewBitmap, vBmp);
			DrawWaku(vBmp);
			
			
			Size a = new Size();
			
			wideBitmap =  new Bitmap((int)((double)vBmp.Width), (int)((double)vBmp.Height));
			//wideBitmap =  new Bitmap((int)((double)vBmp.Width * zoom[cmbZoomTool.SelectedIndex]), (int)((double)vBmp.Height * zoom[cmbZoomTool.SelectedIndex]));
			a.Width = wideBitmap.Width;
			a.Height = wideBitmap.Height;
			ImageBox.Size = a;
			imageEffect.BitmapStretchCopy(vBmp, wideBitmap);
			e.Graphics.DrawImage(wideBitmap,0,0);
		}
		#endregion
		
		#region 色コンボボックスの値が変更されたとき
		void ComboColorSelectedIndexChanged(object sender, EventArgs e)
		{
			
		}
		#endregion
		
		#region ImageBox上でマウスが動いたとき
		void ImageBoxMouseMove(object sender, MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left){
				if(btnPen.Checked == true || btnEraser.Checked == true){
					Graphics g = Graphics.FromImage(viewBitmap);
					Graphics g2 = Graphics.FromImage(workBitmap);
					//Graphics g = imageBox.CreateGraphics();
					Point pp = new Point();
					Point nowp = new Point();
					
					imageForeColor = mf.Setup.DisplayColor[comboColor.SelectedIndex];
					Pen p = new Pen(btnPen.Checked == true ? imageForeColor : Color.White, int.Parse(cmbLineSize.Text));
					//Pen p = new Pen(btnPencil.Checked == true ? imageForeColor : Color.White, (float)zoom[cmbZoom.SelectedIndex] * int.Parse(cmbLineSize.Text));
					
					pp.X = mP.X;
					pp.Y = mP.Y;
					//pp.X = (int)(mP.X * zoom[cmbZoom.SelectedIndex] + panel1.AutoScrollOffset.X);
					//pp.Y = (int)(mP.Y * zoom[cmbZoom.SelectedIndex] + panel1.AutoScrollOffset.Y);
					
					p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
					p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
					p.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;
					//g.DrawLine(p, pp, e.Location);
					//nowp = new Point((int)(panel1.AutoScrollOffset.X / zoom[cmbZoomTool.SelectedIndex] + e.X / zoom[cmbZoomTool.SelectedIndex]),
					//                 (int)(panel1.AutoScrollOffset.Y / zoom[cmbZoomTool.SelectedIndex] + e.Y / zoom[cmbZoomTool.SelectedIndex]));
					nowp = new Point((int)(panel1.AutoScrollOffset.X  + e.X ),
					                 (int)(panel1.AutoScrollOffset.Y  + e.Y ));
					g.DrawLine(p, pp, nowp);
					g2.DrawLine(p, pp, nowp);
					
					g.Dispose();
					//mP.X = (int)((e.X + panel1.AutoScrollOffset.X) / zoom[cmbZoomTool.SelectedIndex]);
					//mP.Y = (int)((e.Y + panel1.AutoScrollOffset.Y) / zoom[cmbZoomTool.SelectedIndex]);
					mP.X = (int)(e.X + panel1.AutoScrollOffset.X);
					mP.Y = (int)(e.Y + panel1.AutoScrollOffset.Y);
					//mP = InCanvasCheck(mP);
					sP= mP;
					imageEffect.BitmapCopyXYSize(viewBitmap, cursorBitmap, mP.X - 5, mP.Y - 5, 10, 10);
				
					ImageBox.Invalidate();
				}
			}else{
				//ImageBox.Invalidate();
				imageEffect.BitmapCopyXY(cursorBitmap, viewBitmap, mP.X - 5, mP.Y - 5);
				mP.X = (int)(e.X + panel1.AutoScrollOffset.X);
				mP.Y = (int)(e.Y + panel1.AutoScrollOffset.Y);
				imageEffect.BitmapCopyXYSize(viewBitmap, cursorBitmap, mP.X - 5, mP.Y - 5, 10, 10);
				Brush b = new SolidBrush(mf.Setup.DisplayColor[comboColor.SelectedIndex]);
				Graphics g = Graphics.FromImage(viewBitmap);
				g.FillEllipse(b, mP.X - int.Parse(cmbLineSize.Text)/2, mP.Y - int.Parse(cmbLineSize.Text)/2, int.Parse(cmbLineSize.Text), int.Parse(cmbLineSize.Text));
				ImageBox.Invalidate();
				
			}
		}
		#endregion
		
		#region ImageBox上でマウスが押されたとき
		void ImageBoxMouseDown(object sender, MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left){
				//mP.X = (int)((e.X + panel1.AutoScrollOffset.X) / zoom[cmbZoomTool.SelectedIndex]);
				//mP.Y = (int)((e.Y + panel1.AutoScrollOffset.Y) / zoom[cmbZoomTool.SelectedIndex]);
				mP.X = (int)(e.X + panel1.AutoScrollOffset.X);
				mP.Y = (int)(e.Y + panel1.AutoScrollOffset.Y);
				//mP = InCanvasCheck(mP);
			}
		}
		#endregion
		
		#region ImageBox上でマウスが放されたとき
		void ImageBoxMouseUp(object sender, MouseEventArgs e)
		{
			if(btnPen.Checked){
				imageEffect.BitmapImposeCopy(srcBitmap, workBitmap);
				imageEffect.BitmapCopy(srcBitmap, viewBitmap);
				imageEffect.BitmapWhitening(workBitmap);
			}else{
				imageEffect.BitmapImposeCopy(srcBitmap, workBitmap);
				imageEffect.BitmapCopy(viewBitmap, srcBitmap);
				imageEffect.BitmapWhitening(workBitmap);
			}
		}
		#endregion
		
		#region 線幅が変更されたとき
		void CmbLineSizeSelectedIndexChanged(object sender, EventArgs e)
		{
			ChangeMouseCursor();
		}
		#endregion
		
		#region ウィンドウサイズの変更
		void WindowSizeChange()
		{
			if(btnString.Checked){
				panel1.Width = 320*4;
				//ImageBox.Width = 320*4;
				this.Width = 320*4+40;
			}else{
				panel1.Width = 320;
				//ImageBox.Width = 320;
				this.Width = 320+40;
			}
		}
		#endregion
		
		#region ビットマップのサイズ変更
		void BitmapSizeChange()
		{
			if(btnString.Checked){
				srcBitmap = new Bitmap(320*4, 320);
				workBitmap = new Bitmap(320*4, 320);
				viewBitmap = new Bitmap(320*4, 320);
			}else{
				srcBitmap = new Bitmap(320, 320);
				workBitmap = new Bitmap(320, 320);
				viewBitmap = new Bitmap(320, 320);
			}
			imageEffect.BitmapWhitening(srcBitmap);
			imageEffect.BitmapWhitening(workBitmap);
			imageEffect.BitmapWhitening(viewBitmap);
		}
		#endregion
		
		#region 文字列・個別文字ボタン
		void BtnStringCheckedChanged(object sender, EventArgs e)
		{
			if(btnString.Checked){
				btnString.Text = "個別文字";
				btnString.ToolTipText = "個別文字";
				
			}else{
				btnString.Text = "文字列";
				btnString.Text = "文字列";
			}
			WindowSizeChange();
			BitmapSizeChange();
			ImageBox.Invalidate();
		}
		#endregion
		
		#region 白紙ボタン
		void BtnNewClick(object sender, EventArgs e)
		{
			imageEffect.BitmapWhitening(srcBitmap);
			imageEffect.BitmapWhitening(workBitmap);
			imageEffect.BitmapWhitening(viewBitmap);
			ImageBox.Invalidate();
		}
		#endregion
		
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
