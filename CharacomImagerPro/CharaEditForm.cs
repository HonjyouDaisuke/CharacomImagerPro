/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2012/01/23
 * 時刻: 17:20
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CharacomImagerPro
{
	/// <summary>
	/// Description of CharaEditForm.
	/// </summary>
	public partial class CharaEditForm : Form
	{
		
		ImageEffect imageEffect = new ImageEffect();
		/// <summary>原画像用ビットマップ</summary>
		public Bitmap srcBitmap;
		/// <summary>作業用ビットマップ</summary>
		public Bitmap workBitmap;
		/// <summary>表示用ビットマップ</summary>
		public Bitmap viewBitmap;
		Bitmap wideBitmap;
		double [] zoom = {4.0, 3.0, 2.0, 1.5, 1.0, 0.5};
		Point mP,sP;
		/// <summary>表示色</summary>
		public Color imageForeColor;
		private FrameDataClass frameData;
		private Point startPosition;
		
		private Size frameSize;
		
		/// <summary>フレームデータ</summary>
		public FrameDataClass FrameData {
			get { return frameData; }
			set { frameData = value; }
		}
		
		public int maxScroll()
		{
			return(panel1.HorizontalScroll.Maximum);
		}
		public CharaEditForm(int width, int height, int start_X, int start_Y)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			

			
			frameData = new FrameDataClass(width, height);
			frameSize = new Size();
			frameSize.Height = height;
			frameSize.Width = width;
			imageBox.Size = frameSize;
			
			//スクロールバーの調整
			startPosition = new Point( start_X, start_Y);
			
			InitBitmaps();
			cmbZoom.SelectedIndex = 4;
			
			SetFirstProperty();
			
			this.cmbLineSize.ComboBox.DrawMode = DrawMode.OwnerDrawFixed;
			this.cmbLineSize.ComboBox.DrawItem += new DrawItemEventHandler(CmbLineSizeDrawItem);
			cmbLineSize.SelectedIndex = 1;
			
			this.Cursor = Cursors.Hand;
			//frameData.Frame.Y = 10;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		#region 最初のプロパティセット
		void SetFirstProperty()
		{
			CharaEditFormProperties cefp = new CharaEditFormProperties();
			this.Size = cefp.Form.Size;
			
			panel1.Location = cefp.Panel1.Location;
			panel1.Size = cefp.Panel1.Size;
			
			btnOK.Location = cefp.BtnOK.Location;
			btnOK.Size = cefp.BtnOK.Size;
			
			btnCancel.Location = cefp.BtnCancel.Location;
			btnCancel.Size = cefp.BtnCancel.Size;
			
			cmbZoom.Size = cefp.CmbZoom.Size;
			cmbLineSize.Size = cefp.CmbLineSize.Size;
		}
		#endregion
		
		#region Bitmapの初期化処理
		private void InitBitmaps()
		{
			//Bitmapの作成
			srcBitmap = new Bitmap(frameSize.Width, frameSize.Height);
			viewBitmap = new Bitmap(frameSize.Width, frameSize.Height);
			workBitmap = new Bitmap(frameSize.Width, frameSize.Height);
			
			
			//Bitmapを白で初期化
			imageEffect.BitmapWhitening(srcBitmap);
			imageEffect.BitmapWhitening(viewBitmap);
			imageEffect.BitmapWhitening(workBitmap);
		}
		#endregion
		
		#region サイズコンボボックスのオーナー描画
		void CmbLineSizeDrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
		{
			int size;
			//背景を描画する
    		//項目が選択されている時は強調表示される
    		e.DrawBackground();

    		ComboBox cmb = (ComboBox) sender;
    		
    		size = e.Index > -1 ? int.Parse(cmb.Items[e.Index].ToString()) : int.Parse(cmb.Text);
    		
    		//使用するブラシ
    		Brush b = new SolidBrush(Color.Black);
    		
    		e.Graphics.FillRectangle(b, e.Bounds.X + 5, e.Bounds.Y + e.Bounds.Height / 2 - size / 2, e.Bounds.Width - 10, size);
    		
    		//フォーカスを示す四角形を描画
    		e.DrawFocusRectangle();
		}
		#endregion
		
		#region ImageBoxペイント処理
		void ImageBoxPaint(object sender, PaintEventArgs e)
		{
			Bitmap vBmp = new Bitmap(viewBitmap.Width, viewBitmap.Height);
			imageEffect.BitmapCopy(viewBitmap, vBmp);
			
			Size a = new Size();
			
			wideBitmap =  new Bitmap((int)((double)vBmp.Width * zoom[cmbZoom.SelectedIndex]), (int)((double)vBmp.Height * zoom[cmbZoom.SelectedIndex]));
			a.Width = wideBitmap.Width;
			a.Height = wideBitmap.Height;
			imageBox.Size = a;
			imageEffect.BitmapStretchCopy(vBmp, wideBitmap);
			e.Graphics.DrawImage(wideBitmap,0,0);
		}
		#endregion
		
		#region ズームコンボボックスの変更処理
		void CmbZoomSelectedIndexChanged(object sender, EventArgs e)
		{
			imageBox.Invalidate();
		}
		#endregion
		
		#region ペンボタンが押されたとき
		void BtnPencilCheckedChanged(object sender, EventArgs e)
		{
			if(btnPencil.Checked == true){
				btnEraser.Checked = false;
			}
		}
		#endregion
		
		#region 消しゴムボタンが押されたとき
		void BtnEraserCheckedChanged(object sender, EventArgs e)
		{
			if(btnEraser.Checked == true){
				btnPencil.Checked = false;
			}
		}
		#endregion
		
		#region マウスの位置がキャンバス内かどうかのチェック
		Point InCanvasCheck(Point p)
		{
			Point rPoint;
			rPoint = p;
			
			if(p.X < 0) rPoint.X = 0;
			if(p.Y < 0) rPoint.Y = 0;
			if(p.X >= imageBox.Width) rPoint.X = imageBox.Width - 1;
			if(p.Y >= imageBox.Height) rPoint.Y = imageBox.Height - 1;
			
			return(rPoint);
		}
		#endregion
		
		void ImageBoxMouseMove(object sender, MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left){
				if(btnPencil.Checked == true || btnEraser.Checked == true){
					Graphics g = Graphics.FromImage(viewBitmap);
					//Graphics g = imageBox.CreateGraphics();
					Point pp = new Point();
					Point nowp = new Point();
			
					Pen p = new Pen(btnPencil.Checked == true ? imageForeColor : Color.White, int.Parse(cmbLineSize.Text));
					//Pen p = new Pen(btnPencil.Checked == true ? imageForeColor : Color.White, (float)zoom[cmbZoom.SelectedIndex] * int.Parse(cmbLineSize.Text));
					
					pp.X = mP.X;
					pp.Y = mP.Y;
					//pp.X = (int)(mP.X * zoom[cmbZoom.SelectedIndex] + panel1.AutoScrollOffset.X);
					//pp.Y = (int)(mP.Y * zoom[cmbZoom.SelectedIndex] + panel1.AutoScrollOffset.Y);
					
					p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
					p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
					p.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;
					//g.DrawLine(p, pp, e.Location);
					nowp = new Point((int)(panel1.AutoScrollOffset.X / zoom[cmbZoom.SelectedIndex] + e.X / zoom[cmbZoom.SelectedIndex]),
					                 (int)(panel1.AutoScrollOffset.Y / zoom[cmbZoom.SelectedIndex] + e.Y / zoom[cmbZoom.SelectedIndex]));
					g.DrawLine(p, pp, nowp);
					
					g.Dispose();
					mP.X = (int)((e.X + panel1.AutoScrollOffset.X) / zoom[cmbZoom.SelectedIndex]);
					mP.Y = (int)((e.Y + panel1.AutoScrollOffset.Y) / zoom[cmbZoom.SelectedIndex]);
					mP = InCanvasCheck(mP);
					sP= mP;
					
					imageBox.Invalidate();
				}
			}
		}
		
		void ImageBoxMouseDown(object sender, MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left){
				mP.X = (int)((e.X + panel1.AutoScrollOffset.X) / zoom[cmbZoom.SelectedIndex]);
				mP.Y = (int)((e.Y + panel1.AutoScrollOffset.Y) / zoom[cmbZoom.SelectedIndex]);
				mP = InCanvasCheck(mP);
			}
		}
		
		Rectangle Clipping(Bitmap bmp, Color ForeColor)
		{
			int maxx, maxy, minx, miny;
			Rectangle frame = new Rectangle();
			
			//準備
			maxx = 0;
			maxy = 0;
			minx = 1000000;
			miny = 1000000;
			
			for(int j = 0; j < bmp.Height; j++){
				for(int i = 0; i < bmp.Width; i++){
					if(imageEffect.ColorCompare(bmp.GetPixel( i, j), ForeColor)){
						//outBmp.SetPixel(i, j, c);
						if(i < minx) minx = i;
						if(j < miny) miny = j;
						if(i > maxx) maxx = i;
						if(j > maxy) maxy = j;
					}
				}
			}
			
			frame = new Rectangle( minx, miny, maxx - minx, maxy - miny);
			
			return(frame);
		}
		
		void BtnOKClick(object sender, EventArgs e)
		{
			if(imageEffect.WhiteCanvasCheck(viewBitmap) == false){
				DialogResult = DialogResult.Abort;
			}else{
				FrameData.Frame = Clipping(viewBitmap, frameData.FrameColor);
				FrameData.Bmp = viewBitmap;
			}
			this.Close();
		}
		
		void BtnCancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void CharaEditFormShown(object sender, EventArgs e)
		{
			panel1.HorizontalScroll.Value = startPosition.X;
			panel1.Update();
			panel1.Refresh();
		}
		
		
	}
}
