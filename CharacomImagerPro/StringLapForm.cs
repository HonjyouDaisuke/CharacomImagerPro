/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2013/02/10
 * 時刻: 16:46
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CharacomImagerPro
{
	/// <summary>
	/// Description of StringLapForm.
	/// </summary>
	public partial class StringLapForm : Form
	{
		//親フォームの参照
		private MainForm mf;
		private int windowID;
		ImageEffect imageEffect = new ImageEffect();
		//private ArrayList lapArray = new ArrayList();
		private ArrayList ImageArray = new ArrayList();
		Bitmap viewBitmap = new Bitmap(1280, 320);
		Bitmap wideBitmap;
		Bitmap ListBmp;
		
		double [] zoom = {4.0, 3.0, 2.0, 1.5, 1.0, 0.5};
		
		private string fileName;
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
		//コマンドマネージャ
		public CommandManager undoManager = new CommandManager();
		
		public StringLapForm(MainForm mainForm)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			mf = mainForm;
			imageEffect.BitmapWhitening(viewBitmap);
			comboZoom.SelectedIndex = 4;
			CheckUndoRedo();
			
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
			FileName = "無題" + mf.GetTitleNo(this.Name).ToString() + ".csl";
			
		}
		#endregion
		
		#region ドラッグアンドドロップ
		void StringLapFormDragEnter(object sender, DragEventArgs e)
		{
			if(e.Data.GetDataPresent(typeof(StringImageForm))){
				e.Effect = DragDropEffects.Copy;
			}else{
				e.Effect = DragDropEffects.None;
			}
		}
		
		bool CheckLapList(string file_name)
		{
			bool res = false;
			
			foreach(ImageDataClass idc in ImageArray){
				//System.Diagnostics.Debug.WriteLine("ファイル名比較：LapList[" + idc.Filename + "]⇔inData[" + file_name + "]");
				if(idc.Filename == file_name){
					res = true;
					break;
				}
			}
			return(res);
		}
		
		void StringLapFormDragDrop(object sender, DragEventArgs e)
		{
			StringImageForm sif;
			if(e.Data.GetDataPresent(typeof(StringImageForm))){
				sif = (StringImageForm)e.Data.GetData(typeof(StringImageForm));
				if(CheckLapList(sif.ImageData.Filename)) return;
				//DataGridView用のデータを作成
				DataGridViewRow NewRow = new DataGridViewRow();
				NewRow.CreateCells(dgvLap);
				IntoDataGridView(NewRow, sif.ImageData.ProcImage, sif.ImageData.Filename);
				
				//コマンドを実行
				LapDragInCommand command = new LapDragInCommand(dgvLap.Rows, NewRow, ImageArray, sif.ImageData);
				undoManager.Action(command);
				
				CheckUndoRedo();
				//AddLapArray(cif.ImageData);
				MakeViewBitmap();
				
			}
			LapImageBox.Invalidate();
		}
		#endregion
		
		
		#region 矩形を描画
		void DrawFrame(Bitmap bmp, ImageDataClass idc)
		{
			foreach(FrameDataClass fdc in idc.FrameData){
				imageEffect.DrawFrameAtColor(bmp, fdc.Frame, fdc.FrameColor);
			}
		}
		#endregion
		
		#region 重心線を描画
		void DrawGravityLine(Bitmap bmp, ImageDataClass idc)
		{
			Point BeforeP = new Point(0,0);
			int i=0;
			
			foreach(FrameDataClass fdc in idc.FrameData){
				if(btnGraviHou.Checked == true || btnGraviJun.Checked == true){
					imageEffect.DrawFrameGravityPoint(bmp, fdc.Gravity, idc.GravityColor);
				}
				if(btnGraviHou.Checked == true){
					imageEffect.DrawFrameGravityLine(bmp, fdc.Gravity, idc.AllGravity, idc.GravityColor);
				}
				if(btnGraviJun.Checked == true && i > 0){
					imageEffect.DrawFrameGravityLine(bmp, fdc.Gravity, BeforeP, idc.GravityColor);
				}
				BeforeP = fdc.Gravity;
				i++;		
			}
		}
		#endregion
		
		#region 射影を描画
		void DrawProjection(Bitmap bmp, ImageDataClass idc)
		{
			imageEffect.DrawProjection(idc.SrcImage, bmp, Color.Black);
			foreach(FrameDataClass fdc in idc.FrameData){
				imageEffect.DrawProjection(fdc.Bmp, bmp, fdc.FrameColor);
			}
		}
		#endregion
		
		#region Viewの作成（実際の重ね合わせ）
		public void MakeViewBitmap()
		{
			//LapClass lc = new LapClass();
			ImageDataClass idc = new ImageDataClass(1280, 320);
			Bitmap white_image = new Bitmap(1280,320);
			
			imageEffect.BitmapWhitening(viewBitmap);
			for(int i=ImageArray.Count - 1; i >=0; i--){
				idc = (ImageDataClass)ImageArray[i];
				if(btnChara.Checked) imageEffect.BitmapImposeCopy(viewBitmap, idc.ProcImage);
				imageEffect.BitmapImposeCopy((Bitmap)dgvLap[0, i].Value, idc.ProcImage);
				dgvLap[1, i].Value = Path.GetFileName(idc.Filename);
				if(btnDrawFrame.Checked)DrawFrame(viewBitmap, idc);
				if(btnGraviHou.Checked || btnGraviJun.Checked)DrawGravityLine(viewBitmap, idc);
				if(btnSyaei.Checked)DrawProjection(viewBitmap, idc);
			}
		}
		#endregion
		
		#region 重ね合わせリストへ追加
		void AddLapArray(ImageDataClass imageData)
		{
			ImageArray.Add(imageData);
			//IntoDataGridView(dgvLap.Rows, imageData.ProcImage, imageData.Filename);
		}
		#endregion
		
		#region DataGridViewへの追加データを作成
		void IntoDataGridView(DataGridViewRow dgvRow, Bitmap bmp, string FileName)
		{
			Bitmap inBmp = new Bitmap(bmp.Width, bmp.Height);
			imageEffect.BitmapWhitening(inBmp);
			imageEffect.BitmapCopy(bmp, inBmp);
			dgvRow.Height = 80;
			dgvRow.Cells[0].Value = inBmp;
			dgvRow.Cells[1].Value = Path.GetFileName(FileName);
		}
		#endregion
		
		#region 枠の描画
		private void DrawWaku(Bitmap bmp)
		{
			//MainForm mf = new MainForm();
			//mf = (MainForm)this.MdiParent;
			
			if(mf.Setup.EightLineVisible) imageEffect.Draw8x8x4Line(bmp, mf.Setup.EightLineColor);
			if(mf.Setup.CenterLineVisible) imageEffect.DrawCenterLine(bmp, mf.Setup.CenterLineColor);
		}
		#endregion
		
		#region Undo、Redoのチェック
		void CheckUndoRedo()
		{
			btnUndo.Enabled = undoManager.CanUndo();
			menuUndo.Enabled = undoManager.CanUndo();
			
			btnRedo.Enabled = undoManager.CanRedo();
			menuRedo.Enabled = undoManager.CanRedo();
		}
		#endregion
		
		#region ウィンドウが開かれたら
		void StringLapFormLoad(object sender, EventArgs e)
		{
			//メインフォームにウィンドウリストを追加してもらう
			//MainForm mf = (MainForm)MdiParent;
			string titleName = "";
			System.Diagnostics.Debug.WriteLine("windowName,TitleName:"+this.Name + "," + FileName);
			windowID = mf.AddWindowList(this.Name, fileName);
			titleName = mf.GetWindowTitle(windowID);
			System.Diagnostics.Debug.WriteLine("titleName = " +titleName);
			this.Text = titleName;
		}
		#endregion
		
		#region ウィンドウが閉じられるときに
		void StringLapFormFormClosing(object sender, FormClosingEventArgs e)
		{
			//メインフォームにウィンドウリストから削除してもらう
			//MainForm mf = (MainForm)this.MdiParent;
			mf.RemoveWindowAtID(windowID);
		}
		#endregion
		
		#region ペイント処理
		void LapImageBoxPaint(object sender, PaintEventArgs e)
		{
			DrawWaku(viewBitmap);
			Size a = new Size();
			
			wideBitmap =  new Bitmap((int)((double)viewBitmap.Width * zoom[comboZoom.SelectedIndex]), (int)((double)viewBitmap.Height * zoom[comboZoom.SelectedIndex]));
			a.Width = wideBitmap.Width;
			a.Height = wideBitmap.Height;
			LapImageBox.Size = a;
			imageEffect.BitmapStretchCopy(viewBitmap, wideBitmap);
			e.Graphics.DrawImage(wideBitmap, 0, 0);
		}
		#endregion
		
		#region 保存処理
		void SaveCSLFile()
		{
			if(fileName == "" || fileName == null)return;
			FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
			BinaryFormatter bf = new BinaryFormatter();
			
			bf.Serialize(fs, ImageArray);
			
			fs.Close();
			
			//最近使ったファイルに追加してもらう
			//MainForm mf = (MainForm)this.MdiParent;
			mf.AddRecentlyFile(fileName);
		}
		#endregion
		
		#region 読み込み処理
		public void OpenCSLFile()
		{
    		if(fileName == "" || fileName == null)return;
			//個人内変動ファイルを開く
			FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
			BinaryFormatter bf = new BinaryFormatter();
			
			ImageArray.Clear();
			
			ImageArray = (ArrayList)bf.Deserialize(fs);
			
			dgvLap.Rows.Clear();
			
			foreach(ImageDataClass idc in ImageArray){
				//DataGridView用のデータを作成
				DataGridViewRow NewRow = new DataGridViewRow();
				NewRow.CreateCells(dgvLap);
				IntoDataGridView(NewRow, idc.ProcImage, idc.Filename);
				dgvLap.Rows.Add(NewRow);
			}
			MakeViewBitmap();
			LapImageBox.Invalidate();
			
			//最近使ったファイルに追加してもらう
			//MainForm mf = (MainForm)this.MdiParent;
			mf.AddRecentlyFile(fileName);
		}
		#endregion
				
		#region コンテキストメニュー
		void MenuFileOpenClick(object sender, EventArgs e)
		{
			if(openFileDlg.ShowDialog() == DialogResult.OK){
				if(System.IO.Path.GetExtension(openFileDlg.FileName) == ".csl"){
					FileName = openFileDlg.FileName;
					OpenCSLFile();
				}else{
					MessageBox.Show("重ねあわせ画像のデータではありません。ファイルを確認してください", "CharacomImagerPro",MessageBoxButtons.OK, MessageBoxIcon.Error);
					
				}
			}
		}
		
		void MenuFileSaveClick(object sender, EventArgs e)
		{
			if(this.FileName.IndexOf("無題") >= 0 || fileName == "" || fileName == null){
				if(saveFileDlg.ShowDialog() == DialogResult.OK){
					this.FileName = saveFileDlg.FileName;
				}else{
					return;
				}
			}
			SaveCSLFile();
		}
		
		void MenuCopyClick(object sender, EventArgs e)
		{
			Bitmap clipBmp = new Bitmap(viewBitmap);
	
			imageEffect.BitmapDrawFrame(clipBmp);
			Clipboard.SetImage(clipBmp);
			
			clipBmp.Dispose();
		}
		
		void MenuSaveImageClick(object sender, EventArgs e)
		{
			if(saveImageDialog.ShowDialog() == DialogResult.OK){
				if(imageEffect.IsImageFile(saveImageDialog.FileName)){
					Bitmap clipBmp = new Bitmap(viewBitmap);
	
					imageEffect.BitmapDrawFrame(clipBmp);
					clipBmp.Save(saveImageDialog.FileName, imageEffect.GetImageFormat(saveImageDialog.FileName));
				}
			}
		}
		
		void MenuUndoClick(object sender, EventArgs e)
		{
			undoManager.Undo();
			CheckUndoRedo();
			MakeViewBitmap();
			LapImageBox.Invalidate();
		}
		
		void MenuRedoClick(object sender, EventArgs e)
		{
			undoManager.Redo();
			CheckUndoRedo();
			MakeViewBitmap();
			LapImageBox.Invalidate();
		}
		
		void MenuPreviewClick(object sender, EventArgs e)
		{
			printPreviewDlg.StartPosition = FormStartPosition.CenterParent;
			printPreviewDlg.ShowDialog();
		}
		
		void MenuPrintClick(object sender, EventArgs e)
		{
			if(printDlg.ShowDialog() == DialogResult.OK){
				printDoc.PrinterSettings.Copies = printDlg.PrinterSettings.Copies;
				printDoc.Print();
			}
		}
		
		void MenuPageSetupClick(object sender, EventArgs e)
		{
			pageSetupDlg.ShowDialog();
		}
		
		void MenuZoomClick(object sender, EventArgs e)
		{
			ZoomSelectPanel zsl = new ZoomSelectPanel();
			zsl.StartPosition = FormStartPosition.CenterParent;
			
			if(zsl.ShowDialog() == DialogResult.OK){
				comboZoom.SelectedIndex = zsl.Wide;
			}
			zsl.Dispose();
			
			LapImageBox.Invalidate();
		}
		
		void MenuNewWindowClick(object sender, EventArgs e)
		{
			mf.MenuSLapClick(sender, e);
		}
		
		void MenuUpDownAlignClick(object sender, EventArgs e)
		{
			this.MdiParent.LayoutMdi(MdiLayout.TileHorizontal);
		}
		
		void MenuLRAlignClick(object sender, EventArgs e)
		{
			this.MdiParent.LayoutMdi(MdiLayout.TileVertical);
		}
		
		void MenuOverAlignClick(object sender, EventArgs e)
		{
			this.MdiParent.LayoutMdi(MdiLayout.Cascade);
		}
		
		void MenuCloseClick(object sender, EventArgs e)
		{
			this.Close();
		}
		#endregion
		
		#region ツールバーボタン
		void BtnSyaeiCheckedChanged(object sender, EventArgs e)
		{
			MakeViewBitmap();
			LapImageBox.Invalidate();
		}
		
		void BtnGraviJunCheckedChanged(object sender, EventArgs e)
		{
			MakeViewBitmap();
			LapImageBox.Invalidate();
		}
		
		void BtnGraviHouCheckedChanged(object sender, EventArgs e)
		{
			MakeViewBitmap();
			LapImageBox.Invalidate();
		}
		
		void BtnCharaCheckedChanged(object sender, EventArgs e)
		{
			MakeViewBitmap();
			LapImageBox.Invalidate();
		}
		
		void BtnFileSaveClick(object sender, EventArgs e)
		{
			MenuFileSaveClick(sender, e);
		}
		
		void BtnDrawFrameCheckedChanged(object sender, EventArgs e)
		{
			MakeViewBitmap();
			LapImageBox.Invalidate();
		}
		
		void BtnZoomClick(object sender, EventArgs e)
		{
			MenuZoomClick( sender, e);
		}
		
		void BtnFileOpenClick(object sender, EventArgs e)
		{
			MenuFileOpenClick( sender, e);
		}
		
		void BtnCopyClick(object sender, EventArgs e)
		{
			MenuCopyClick( sender, e);
		}
		
		void BtnSaveClick(object sender, EventArgs e)
		{
			MenuSaveImageClick( sender, e);
		}
		
		void BtnUndoClick(object sender, EventArgs e)
		{
			MenuUndoClick( sender, e);
		}
		
		void BtnRedoClick(object sender, EventArgs e)
		{
			MenuRedoClick( sender, e);
		}
		
		void BtnPreviewClick(object sender, EventArgs e)
		{
			MenuPreviewClick( sender, e);
		}
		
		void BtnPrintClick(object sender, EventArgs e)
		{
			MenuPrintClick( sender, e);
		}
		
		void ComboZoomSelectedIndexChanged(object sender, EventArgs e)
		{
			LapImageBox.Invalidate();
		}
		#endregion
		
		#region ひとつ上へボタン
		void BtnUpClick(object sender, EventArgs e)
		{
			if(dgvLap.Rows.Count > 0){
				if(dgvLap.CurrentRow.Index > 0){
					LapExchangeCommand command = new LapExchangeCommand(dgvLap, ImageArray, dgvLap.CurrentRow.Index, dgvLap.CurrentRow.Index - 1, 320, 320);
					undoManager.Action(command);
					
					//dgvChangeData(dgvLap, dgvLap.CurrentRow.Index, dgvLap.CurrentRow.Index - 1);
					//ImageDataChangeData(dgvLap.CurrentRow.Index, dgvLap.CurrentRow.Index - 1);
					//dgvLap.CurrentCell = dgvLap[0, dgvLap.CurrentRow.Index - 1];
					MakeViewBitmap();
					LapImageBox.Invalidate();
				}
			}
		}
		#endregion
		
		#region ひとつ下へボタン
		void BtnDownClick(object sender, EventArgs e)
		{
			if(dgvLap.Rows.Count > 0){
				if(dgvLap.CurrentRow.Index < dgvLap.Rows.Count - 1){
					LapExchangeCommand command = new LapExchangeCommand(dgvLap, ImageArray, dgvLap.CurrentRow.Index, dgvLap.CurrentRow.Index + 1, 320, 320);
					undoManager.Action(command);
					//dgvChangeData(dgvLap, dgvLap.CurrentRow.Index, dgvLap.CurrentRow.Index + 1);
					//ImageDataChangeData(dgvLap.CurrentRow.Index, dgvLap.CurrentRow.Index + 1);
					//dgvLap.CurrentCell = dgvLap[0, dgvLap.CurrentRow.Index + 1];
					MakeViewBitmap();
					LapImageBox.Invalidate();
				}
			}
		}
		#endregion
		
		#region 削除ボタン
		void BtnDeleteClick(object sender, EventArgs e)
		{
			if(dgvLap.Rows.Count > 0){
				LapDeleteCommand command = new LapDeleteCommand(dgvLap.Rows, ImageArray, dgvLap.CurrentRow.Index);
				undoManager.Action(command);
				CheckUndoRedo();
				//ImageArray.RemoveAt(dgvLap.CurrentRow.Index);
				//dgvLap.Rows.RemoveAt(dgvLap.CurrentRow.Index);
				MakeViewBitmap();
				LapImageBox.Invalidate();
			}
		}
		#endregion
		
		#region リスト画像を作成
		void MakeList(int ex)
		{
			Font f = new Font("メイリオ", 10);
			Font TitleF = new Font("メイリオ", 12, FontStyle.Bold);
			Graphics g;
			
			const int MarginX = 5;
			const int MarginY = 5;
			int bbHeight = 80;
			int bbWidth = 320;
			
			//全体の大きさ用
			int MaxX, MaxY;
			int x, y;
			//int ey;
			
			//全体の大きさの確認
			MaxX = ex;
			MaxY = TitleF.Height + MarginY + ( bbHeight + MarginY) * dgvLap.Rows.Count;
			ListBmp = new Bitmap(MaxX, MaxY);
			imageEffect.BitmapWhitening(ListBmp);
			//グラフィックを作成
			g = Graphics.FromImage(ListBmp);
			
			
			x=0; y=0;
			//矩形リスト
			//g.DrawString("☆入力画像", TitleF, Brushes.Black, x, y);
			//y += TitleF.Height + MarginY;
			for(int i=0; i<dgvLap.Rows.Count; i++){
				Bitmap bb = new Bitmap(((Bitmap)dgvLap[0, i].Value).Width, ((Bitmap)dgvLap[0, i].Value).Height);
				imageEffect.BitmapCopy((Bitmap)dgvLap[0, i].Value, bb);
				imageEffect.BitmapDrawFrame(bb);
				System.Diagnostics.Debug.WriteLine("bb.Size="+bb.Width.ToString()+"*"+bb.Height.ToString());
				System.Diagnostics.Debug.WriteLine((x+bb.Width+MarginX).ToString()+","+y.ToString()+":"+bbWidth.ToString()+"*"+bbHeight.ToString());
				g.DrawImage(bb, x, y, bbWidth, bbHeight);
				RectangleF r = new RectangleF(x + bbWidth + MarginX, y, ex - (bbWidth + MarginX), bbHeight);
				StringFormat sf = new StringFormat();
				sf.Alignment = StringAlignment.Near;
				sf.LineAlignment = StringAlignment.Center;
				g.DrawString((string)dgvLap[1, i].Value, f, Brushes.Black, r, sf);
				y += bbHeight + MarginY;
			}
			g.Dispose();
		}
		#endregion
		
		#region 印刷処理
		void PrintDocPrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			printDoc.DocumentName = "文字列重ね合わせ[" + System.IO.Path.GetFileName(FileName) + "]";
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
			e.Graphics.DrawString("■文字列 重ね合わせ処理", TitleF, Brushes.Black, sx, BodySY + MarginY);
			
			//画像を作成
			Bitmap b = new Bitmap(viewBitmap.Width, viewBitmap.Height);
			imageEffect.BitmapCopy(viewBitmap, b);
			//DrawFrame(b);
			//DrawWaku(b);
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
			
			e.Graphics.DrawString("☆入力画像", TitleF, Brushes.Black, x, y);
			y += TitleF.Height + MarginY;
			
			MakeList(ey);
			
			resizeHeight = ListBmp.Height;
			resizeWidth = ListBmp.Width;
			
			if(ListBmp.Height > e.MarginBounds.Height - HeaderF.Height*2 - MarginY*2 - resizeBmp.Height - TitleF.Height*2 - MarginY*2){
				resizeHeight = e.MarginBounds.Height - HeaderF.Height*2 - MarginY*2 - resizeBmp.Height - TitleF.Height*2 - MarginY*2;
				resizeWidth = (int)(ListBmp.Width * ((double)resizeHeight / (double)ListBmp.Height));
			}
			Bitmap resizeListBmp = new Bitmap(resizeWidth, resizeHeight);
			g = Graphics.FromImage(resizeListBmp);

			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

			g.DrawImage(ListBmp, 0, 0, resizeWidth, resizeHeight);

			e.Graphics.DrawImage(resizeListBmp, x, y, resizeListBmp.Width, resizeListBmp.Height);
			g.Dispose();
		}
		#endregion
	}
}
