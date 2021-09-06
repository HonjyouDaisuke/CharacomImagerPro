/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2011/10/21
 * 時刻: 15:00
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

namespace CharacomImagerPro
{
	/**
	class WindowSort{
		public int ID;
		public int X;
		public int Y;
		
		public WindowSort(int id, int x, int y){
			this.ID = id;
			this.X = x;
			this.Y = y;
		}
	}
	**/
	/// <summary>
	/// Description of LapForm.
	/// </summary>
	public partial class LapForm : Form
	{
		ImageEffect imageEffect = new ImageEffect();
		//private ArrayList lapArray = new ArrayList();
		private ArrayList ImageArray = new ArrayList();
		Bitmap viewBitmap = new Bitmap(320, 320);
		Bitmap wideBitmap;
		double [] zoom = {4.0, 3.0, 2.0, 1.5, 1.0, 0.5};
		private string fileName;
		//親フォームの参照
		private MainForm mf;
		
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
		private int windowID;
		
		//コマンドマネージャ
		public CommandManager undoManager = new CommandManager();
		
		public LapForm(MainForm mainForm)
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
			FileName = "無題" + mf.GetTitleNo(this.Name).ToString() + ".ccl";
			
		}
		#endregion
		
		#region ドラッグアンドドロップ
		//windowの順番を並び替え
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
		
		void LapFormDragEnter(object sender, DragEventArgs e)
		{
			if(e.Data.GetDataPresent(typeof(CharaImageForm))){
				e.Effect = DragDropEffects.Copy;
			}else{
				e.Effect = DragDropEffects.None;
			}
		}
		
		bool CheckLapList(string file_name)
		{
			bool res = false;
			
			foreach(ImageDataClass idc in ImageArray){
				System.Diagnostics.Debug.WriteLine("ファイル名比較：LapList[" + idc.Filename + "]⇔inData[" + file_name + "]");
				if(idc.Filename == file_name){
					res = true;
					break;
				}
			}
			return(res);
		}
		
		public void InputLapForm(CharaImageForm cif)
		{
			if(CheckLapList(cif.ImageData.Filename)) return;
			//DataGridView用のデータを作成
			DataGridViewRow NewRow = new DataGridViewRow();
			NewRow.CreateCells(dgvLap);
			IntoDataGridView(NewRow, cif.ImageData.ProcImage, cif.ImageData.Filename);
				
			//コマンドを実行
			LapDragInCommand command = new LapDragInCommand(dgvLap.Rows, NewRow, ImageArray, cif.ImageData);
			undoManager.Action(command);
				
			CheckUndoRedo();
			//AddLapArray(cif.ImageData);
			MakeViewBitmap();
				
			LapImageBox.Invalidate();
		}
		void LapFormDragDrop(object sender, DragEventArgs e)
		{
			CharaImageForm cif;
			MultiInputDialog mid = new MultiInputDialog();
			
			mid.ShowDialog();
			if( mid.DialogResult == DialogResult.Yes ){
				if(e.Data.GetDataPresent(typeof(CharaImageForm))){
					cif = (CharaImageForm)e.Data.GetData(typeof(CharaImageForm));
					if(CheckLapList(cif.ImageData.Filename)) return;
					//DataGridView用のデータを作成
					DataGridViewRow NewRow = new DataGridViewRow();
					NewRow.CreateCells(dgvLap);
					IntoDataGridView(NewRow, cif.ImageData.ProcImage, cif.ImageData.Filename);
					
					//コマンドを実行
					LapDragInCommand command = new LapDragInCommand(dgvLap.Rows, NewRow, ImageArray, cif.ImageData);
					undoManager.Action(command);
					
					CheckUndoRedo();
					//AddLapArray(cif.ImageData);
					MakeViewBitmap();
				}
			}else if( mid.DialogResult == DialogResult.No){
				if(e.Data.GetDataPresent(typeof(CharaImageForm))){
					cif = (CharaImageForm)e.Data.GetData(typeof(CharaImageForm));
					//System.Diagnostics.Debug.WriteLine("Window個数="+mf.MdiChildren.Length.ToString());
					foreach (Form cdif in mf.MdiChildren) {
						if(cdif.Name == "CharaImageForm"){
							//System.Diagnostics.Debug.WriteLine("WindowName = " + cdif.Text);
							if(cif.Left == cdif.Left){
								CharaImageForm m_cif;
								m_cif = (CharaImageForm)cdif;
								
								if(!CheckLapList(m_cif.ImageData.Filename)){
									//DataGridView用のデータを作成
									DataGridViewRow NewRow = new DataGridViewRow();
									NewRow.CreateCells(dgvLap);
									IntoDataGridView(NewRow, m_cif.ImageData.ProcImage, m_cif.ImageData.Filename);
									
									//コマンドを実行
									LapDragInCommand command = new LapDragInCommand(dgvLap.Rows, NewRow, ImageArray, m_cif.ImageData);
									undoManager.Action(command);
									
									CheckUndoRedo();
									//AddLapArray(cif.ImageData);
									MakeViewBitmap();
									System.Diagnostics.Debug.WriteLine(m_cif.Text);
								}
							}
						}
					}
				}
			}else if( mid.DialogResult == DialogResult.OK){
				List<WindowSort> winList = new List<WindowSort>(new WindowSort[0] );
				int i=0;
				//現在画面に表示されている、子ウィンドウから、CharaImageFormをすべてWindowSortに入れる。
				foreach (Form cdif in mf.MdiChildren) {
					if(cdif.Name == "CharaImageForm"){
						winList.Add(new WindowSort(i, cdif.Left, cdif.Top, cdif.Name, cdif.Text));
					}
					i++;
				}
								
				//比較関数を指定してソート
				winList.Sort(CompareWindow);
								
				foreach (WindowSort s in winList) {
					CharaImageForm m_cif;
					m_cif = (CharaImageForm)mf.MdiChildren[s.ID];
					//System.Diagnostics.Debug.WriteLine("WindowName = " + m_cif.Text);
					
					if(!CheckLapList(m_cif.ImageData.Filename)){
						//DataGridView用のデータを作成
						DataGridViewRow NewRow = new DataGridViewRow();
						NewRow.CreateCells(dgvLap);
						IntoDataGridView(NewRow, m_cif.ImageData.ProcImage, m_cif.ImageData.Filename);
						
						//コマンドを実行
						LapDragInCommand command = new LapDragInCommand(dgvLap.Rows, NewRow, ImageArray, m_cif.ImageData);
						undoManager.Action(command);
									
						CheckUndoRedo();
						//AddLapArray(cif.ImageData);
						MakeViewBitmap();
						System.Diagnostics.Debug.WriteLine(m_cif.Text);
					}
				}
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
			ImageDataClass idc = new ImageDataClass(320, 320);
			Bitmap white_image = new Bitmap(320,320);
			
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
			
			if(mf.Setup.EightLineVisible) imageEffect.Draw8x8Line(bmp, mf.Setup.EightLineColor);
			if(mf.Setup.CenterLineVisible) imageEffect.DrawCenterLine(bmp, mf.Setup.CenterLineColor);
		}
		#endregion
		
		#region イメージボックスのペイント処理
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
		
		#region ツールバーメニュー
		#region ファイルを開く
		void BtnFileOpenClick(object sender, EventArgs e)
		{
			MenuFileOpenClick(sender, e);
		}
		#endregion
		
		#region ファイルを保存
		void BtnFileSaveClick(object sender, EventArgs e)
		{
			MenuFileSaveClick(sender, e);
		}
		#endregion
		
		#region ウィンドウをコピー
		// 2020.08.24 D.Honjyou 三崎さんからの要望により追加
		void BtnCopyWindowClick(object sender, EventArgs e)
		{
			CopyWindowMenuItemClick(sender, e);
		}
		#endregion
		
		#region コピー
		void BtnCopyClick(object sender, EventArgs e)
		{
			MenuCopyClick(sender, e);
		}
		#endregion
		
		#region 画像として保存
		void BtnSaveClick(object sender, EventArgs e)
		{
			MenuSaveImageClick(sender, e);
		}
		#endregion
		
		#region 印刷プレビュー
		void BtnPreviewClick(object sender, EventArgs e)
		{
			MenuPreviewClick(sender, e);
		}
		#endregion
		
		#region 印刷
		void BtnPrintClick(object sender, EventArgs e)
		{
			MenuPrintClick(sender, e);
		}
		#endregion
		
		#region ズーム
		void BtnZoomClick(object sender, EventArgs e)
		{
			MenuZoomClick(sender, e);
		}
		#endregion
		
		#region ズーム
		void ComboZoomSelectedIndexChanged(object sender, EventArgs e)
		{
			LapImageBox.Invalidate();
		}
		#endregion
		
		#region 矩形を表示ボタンが変更されたとき
		void BtnDrawFrameCheckedChanged(object sender, EventArgs e)
		{
			MakeViewBitmap();
			LapImageBox.Invalidate();
		}
		#endregion
		
		#region 文字画像表示ボタンが変更されたとき
		void BtnCharaCheckedChanged(object sender, EventArgs e)
		{
			MakeViewBitmap();
			LapImageBox.Invalidate();		
		}
		#endregion
		
		#region 重心線ボタンが押されたとき
		void BtnGraviHouCheckedChanged(object sender, EventArgs e)
		{
			MakeViewBitmap();
			LapImageBox.Invalidate();	
		}
		
		void BtnGraviJunCheckedChanged(object sender, EventArgs e)
		{
			MakeViewBitmap();
			LapImageBox.Invalidate();	
		}
		#endregion
		
		#region 射影表示ボタンが変更されたとき
		void BtnSyaeiCheckedChanged(object sender, EventArgs e)
		{
			MakeViewBitmap();
			LapImageBox.Invalidate();
		}
		#endregion
		
		#region 元に戻す
		public void BtnUndoClick(object sender, EventArgs e)
		{
			MenuUndoClick(sender, e);
		}
		#endregion
		
		#region やり直し
		public void BtnRedoClick(object sender, EventArgs e)
		{
			MenuRedoClick(sender, e);
		}
		#endregion
		#endregion
		
		#region 保存処理
		void SaveCCLFile()
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
		public void OpenCCLFile()
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
		
		#region メニューコンテキスト
		#region ファイルを開く
		void MenuFileOpenClick(object sender, EventArgs e)
		{
			if(openFileDlg.ShowDialog() == DialogResult.OK){
				if(System.IO.Path.GetExtension(openFileDlg.FileName) == ".ccl"){
					FileName = openFileDlg.FileName;
					OpenCCLFile();
				}else{
					MessageBox.Show("重ねあわせ画像のデータではありません。ファイルを確認してください", "CharacomImagerPro",MessageBoxButtons.OK, MessageBoxIcon.Error);
					
				}
			}
		}
		#endregion
		
		#region ファイルを保存
		void MenuFileSaveClick(object sender, EventArgs e)
		{
			if(this.FileName.IndexOf("無題") >= 0 || fileName == "" || fileName == null){
				if(saveFileDlg.ShowDialog() == DialogResult.OK){
					this.FileName = saveFileDlg.FileName;
				}else{
					return;
				}
			}
			SaveCCLFile();
		}
		#endregion
	
		#region 元に戻す
		void MenuUndoClick(object sender, EventArgs e)
		{
			undoManager.Undo();
			CheckUndoRedo();
			MakeViewBitmap();
			LapImageBox.Invalidate();
		}
		#endregion
		
		#region やり直し
		void MenuRedoClick(object sender, EventArgs e)
		{
			undoManager.Redo();
			CheckUndoRedo();
			MakeViewBitmap();
			LapImageBox.Invalidate();
		}
		#endregion
		
		#region コピー
		public void MenuCopyClick(object sender, EventArgs e)
		{
			Bitmap clipBmp = new Bitmap(viewBitmap);
	
			imageEffect.BitmapDrawFrame(clipBmp);
			Clipboard.SetImage(clipBmp);
			
			clipBmp.Dispose();
		}
		#endregion
		
		#region ウィンドウをコピー
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
		
		#region 画像として保存
		public void MenuSaveImageClick(object sender, EventArgs e)
		{
			if(saveImageDialog.ShowDialog() == DialogResult.OK){
				if(imageEffect.IsImageFile(saveImageDialog.FileName)){
					Bitmap clipBmp = new Bitmap(viewBitmap);
	
					imageEffect.BitmapDrawFrame(clipBmp);
					clipBmp.Save(saveImageDialog.FileName, imageEffect.GetImageFormat(saveImageDialog.FileName));
				}
			}
		}
		#endregion
		
		#region 印刷プレビュー
		void MenuPreviewClick(object sender, EventArgs e)
		{
			printPreviewDlg.StartPosition = FormStartPosition.CenterParent;
			printPreviewDlg.ShowDialog();
		}
		#endregion
		
		#region 印刷
		void MenuPrintClick(object sender, EventArgs e)
		{
			if(printDlg.ShowDialog() == DialogResult.OK){
				printDoc.PrinterSettings.Copies = printDlg.PrinterSettings.Copies;
				printDoc.Print();
			}
		}
		#endregion
		
		#region ページ設定
		void MenuPageSetupClick(object sender, EventArgs e)
		{
			pageSetupDlg.ShowDialog();
		}
		#endregion
		
		#region ズーム
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
		#endregion
		
		#region 新しいウィンドウを開く
		void MenuNewWindowClick(object sender, EventArgs e)
		{
			mf.MenuLapNewClick(sender, e);
		}
		#endregion
		
		#region 上下に並べて表示
		void MenuUpDownAlignClick(object sender, EventArgs e)
		{
			this.MdiParent.LayoutMdi(MdiLayout.TileHorizontal);
		}
		#endregion
		
		#region 左右に並べて表示
		void MenuLRAlignClick(object sender, EventArgs e)
		{
			this.MdiParent.LayoutMdi(MdiLayout.TileVertical);
		}
		#endregion
		
		#region 重ねて表示
		void MenuOverAlignClick(object sender, EventArgs e)
		{
			this.MdiParent.LayoutMdi(MdiLayout.Cascade);
		}
		#endregion
		
		#region 閉じる
		void MenuCloseClick(object sender, EventArgs e)
		{
			this.Close();
		}
		#endregion
		#endregion
		
		#region 印刷処理
		void PrintDocPrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			Font HeaderF = new Font("メイリオ", 8, FontStyle.Bold);
			Font FooterF = new Font("メイリオ", 8, FontStyle.Bold);
			int MarginX = 5;
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
			
			//タイトルを作成
			Font TitleF = new Font("メイリオ", 12, FontStyle.Bold);
			e.Graphics.DrawString("■個別文字 重ね合わせ処理", TitleF, Brushes.Black, sx, BodySY + MarginY);
			
			//画像を作成
			Bitmap b = new Bitmap(viewBitmap.Width, viewBitmap.Height);
			imageEffect.BitmapCopy(viewBitmap, b);
			//DrawFrame(b);
			DrawWaku(b);
			imageEffect.BitmapDrawFrame(b);
			x = sx; y = BodySY+MarginY+TitleF.Height+MarginY;
			e.Graphics.DrawImage(b, x, y, b.Width, b.Height);
			//e.Graphics.DrawRectangle(Pens.Blue, 0, 0, ViewBitmap.Width, ViewBitmap.Height);
			
			//イメージリストを作成
			e.Graphics.DrawString("☆入力画像", f, Brushes.Black, x + b.Width + MarginX, y);
			y += f.Height + MarginY;
			int bbHeight = 80;
			int bbWidth = 80;
			for(int i=0; i<dgvLap.Rows.Count; i++){
				Bitmap bb = new Bitmap(((Bitmap)dgvLap[0, i].Value).Width, ((Bitmap)dgvLap[0, i].Value).Height);
				imageEffect.BitmapCopy((Bitmap)dgvLap[0, i].Value, bb);
				imageEffect.BitmapDrawFrame(bb);
				e.Graphics.DrawImage(bb, x + b.Width + MarginX, y, bbWidth, bbHeight);
				RectangleF r = new RectangleF(x + b.Width + MarginX + bbWidth + MarginX, y, ex - (x + b.Width + MarginX + bbWidth + MarginX), bbHeight);
				StringFormat sf = new StringFormat();
				sf.Alignment = StringAlignment.Near;
				sf.LineAlignment = StringAlignment.Center;
				e.Graphics.DrawString((string)dgvLap[1, i].Value, f, Brushes.Black, r, sf);
				y += bbHeight + MarginY;
			}
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
		void LapFormLoad(object sender, EventArgs e)
		{
			//メインフォームにウィンドウリストを追加してもらう
			//MainForm mf = (MainForm)MdiParent;
			string titleName = "";
			windowID = mf.AddWindowList(this.Name, fileName);
			titleName = mf.GetWindowTitle(windowID);
			this.Text = titleName;
		}
		#endregion
		
		#region ウィンドウが閉じられるときに
		void LapFormFormClosing(object sender, FormClosingEventArgs e)
		{
			//メインフォームにウィンドウリストから削除してもらう
			//MainForm mf = (MainForm)this.MdiParent;
			mf.RemoveWindowAtID(windowID);
		}
		
		
		#endregion
	}
}
