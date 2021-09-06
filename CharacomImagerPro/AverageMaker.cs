/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2012/03/19
 * 時刻: 16:37
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;

namespace CharacomImagerPro
{
	/// <summary>
	/// Description of AverageMaker.
	/// </summary>
	public partial class AverageMaker : Form
	{
		ArrayList features = new ArrayList();
		public FeatureClass AverageFeature = new FeatureClass();
		Bitmap viewBmp;
		Bitmap viewFeatureBmp;
		public Bitmap SrcBmpSmall;
		private string fileName = "平均";
		private int windowID;
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
		ImageEffect imageEffect = new ImageEffect();
		MathClass mathClass = new MathClass();
		
		public AverageMaker(MainForm mainForm)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			
			mf = mainForm;
			InitializeComponent();
			BitmapInit();
			imageEffect.BitmapWhitening(viewBmp);
			imageEffect.BitmapWhitening(SrcBmpSmall);
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
			FileName = "無題" + mf.GetTitleNo(this.Name).ToString() + ".cfa";
			
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
		
		#region ビットマップの初期化
		void BitmapInit()
		{
			viewBmp = new Bitmap(ImageBox.Width, ImageBox.Height);
			SrcBmpSmall = new Bitmap(CharaImageForm.SmallWidth, CharaImageForm.SmallHeight);
			viewFeatureBmp = new Bitmap(featureBox.Width, featureBox.Height);
		}
		
		void IntoDataGridViewRow(DataGridViewRow Row, Bitmap bmp, string FileName, int num)
		{
			Bitmap b = new Bitmap(bmp.Width, bmp.Height);
			
			imageEffect.BitmapWhitening(b);
			imageEffect.BitmapCopy(bmp, b);
			Row.Height = 50;
			Row.Cells[0].Value = num.ToString();
			Row.Cells[1].Value = b;
			Row.Cells[2].Value = Path.GetFileName(FileName);
			//dgv[3, dgv.Rows.Count - 1].Value = imglCheck.Images[0];
			
		}
		#endregion
		
		#region 特徴の平均の作成
		void GetFeatureAverage(double [] kajyuAvg, double [] kajyuViewAvg, ArrayList feature)
		{
			double [] sum = new double[256];
			double [] sumView = new double[256];
			int num;
			int i;
			
			for(i=0; i<sum.Length; i++){
				sum[i]=0.0;
				sumView[i]=0.0;
			}
			num = feature.Count;
			foreach(FeatureClass fc in feature){
				for(i=0; i<fc.Kajyu.Length; i++){
					sum[i] += fc.Kajyu[i];
					sumView[i] += fc.KajyuView[i];
					//if(i>0 && i<110)System.Diagnostics.Debug.WriteLine(string.Format("{0}:k={1:f1} sum={2:f1} ",i, fc.Kajyu[i], sum[i]));
				}
			}
			
			for(i=0; i<256; i++){
				kajyuAvg[i] = sum[i] / num;
				kajyuViewAvg[i] = sumView[i] / num;
			}
		}
		#endregion
		
		#region 類似度を作成
		void MakeR(ArrayList feature, DataGridView dgv)
		{
			//MainForm mf = new MainForm();
			//mf = (MainForm)this.MdiParent;
			int jigen;
			if(mf.Setup.Kajyu){
				jigen = 256;
			}else{
				jigen = 512;
			}
			double [] kajyu = new double[jigen];
			double [] kajyuView = new double[jigen];
			
			GetFeatureAverage(kajyu, kajyuView, feature);
			
			//グループ内の平均特徴と入力したパターンでの類似度を出す。
			//2012.01.20 D.Honjyou
			double R;
			
			int num = 0;
			foreach(FeatureClass fc in feature){
				if(mf.Setup.Kajyu){
					R = mathClass.GetR(kajyu, fc.Kajyu);
				}else{
					R = mathClass.GetR(kajyu, fc.Haikei);
				}
				fc.R = R;
				if(dgv.Rows.Count > num){
					dgv[0, num].Value = (num + 1).ToString();
					dgv[3, num].Value = fc.R.ToString("F4");
					
				}
				num++;
			}
			if(mf.Setup.Kajyu){
				for(int i=0; i<AverageFeature.Kajyu.Length; i++){
					AverageFeature.Kajyu[i] = kajyu[i];
					AverageFeature.KajyuView[i] = kajyuView[i];
					//System.Diagnostics.Debug.WriteLine(AverageFeature.Kajyu[i].ToString("F4"));
				}
			}else{
				for(int i=0; i<AverageFeature.Haikei.Length; i++){
					AverageFeature.Haikei[i] = kajyu[i];
					AverageFeature.HaikeiView[i] = kajyuView[i];
					//System.Diagnostics.Debug.WriteLine(AverageFeature.Kajyu[i].ToString("F4"));
				}

			}
			
		}
		#endregion
		
		#region 平均特徴をDataGridViewへ
		public void FeatureToDGV()
		{
			int i,j,k,n;
			int w,h;
			
			w = viewFeatureBmp.Width;
			h = viewFeatureBmp.Height;
			
			imageEffect.BitmapWhitening(viewFeatureBmp);
			
			//DataGridViewを初期化
			dgvData1.Rows.Clear();
			dgvData2.Rows.Clear();
			dgvData3.Rows.Clear();
			dgvData4.Rows.Clear();
			
			for(i=0; i<4; i++){
				for(j=0; j<8; j++){
					if(i==0)dgvData1.Rows.Add();
					if(i==1)dgvData2.Rows.Add();
					if(i==2)dgvData3.Rows.Add();
					if(i==3)dgvData4.Rows.Add();
					for(k=0; k<8; k++){
						if(i==0){
							dgvData1.Rows[dgvData1.Rows.Count - 1].Cells[k].Value = AverageFeature.Kajyu[i*64 + j*8 + k].ToString("F2");
							for(n=0; n<AverageFeature.KajyuView[i*64 + j*8 + k]; n++){
								viewFeatureBmp.SetPixel(k*w/8 + w/8/2 + n, j*h/8 + h/8/2, Color.Red);
							}
						}
						if(i==1){
							dgvData2.Rows[dgvData2.Rows.Count - 1].Cells[k].Value = AverageFeature.Kajyu[i*64 + j*8 + k].ToString("F2");
							for(n=0; n<AverageFeature.KajyuView[i*64 + j*8 + k]; n++){
								viewFeatureBmp.SetPixel(k*w/8 + w/8/2 + n, j*h/8 + h/8/2 - n, Color.Red);
							}
						}
						if(i==2){
							dgvData3.Rows[dgvData3.Rows.Count - 1].Cells[k].Value = AverageFeature.Kajyu[i*64 + j*8 + k].ToString("F2");
							for(n=0; n<AverageFeature.KajyuView[i*64 + j*8 + k]; n++){
								viewFeatureBmp.SetPixel(k*w/8 + w/8/2, j*h/8 + h/8/2 - n, Color.Red);
							}
						}
						if(i==3){
							dgvData4.Rows[dgvData4.Rows.Count - 1].Cells[k].Value = AverageFeature.Kajyu[i*64 + j*8 + k].ToString("F2");
							for(n=0; n<AverageFeature.KajyuView[i*64 + j*8 + k]; n++){
								viewFeatureBmp.SetPixel(k*w/8 + w/8/2 - n, j*h/8 + h/8/2 - n, Color.Red);
							}
						}
					}
				}
			}
			featureBox.Invalidate();
		}
		#endregion
		
		#region 重ねあわせ画像を作成
		void MakeSrcBmp()
		{
			imageEffect.BitmapWhitening(SrcBmpSmall);
			foreach(FeatureClass fc in features){
				imageEffect.BitmapImposeCopy(SrcBmpSmall, fc.SrcBitmap);
			}
			imageEffect.BitmapStretchCopy(SrcBmpSmall, viewBmp);
			ImageBox.Invalidate();
		}
		#endregion
		
		void DragDropProc(CharaImageForm cif, DataGridView dgv, int num)
		{
			//前処理をして特徴抽出に使う準備をする
			Bitmap SrcBmp = new Bitmap(cif.SrcBitmapSmall.Width, cif.SrcBitmapSmall.Height);
			imageEffect.BitmapCopy(cif.SrcBitmapSmall, SrcBmp);
			imageEffect.Normalize(cif.SrcBitmapSmall, mf.Setup.CharaR);
			imageEffect.Noize(cif.SrcBitmapSmall);
			
			//DataGridView用のデータを作成
			DataGridViewRow NewRow = new DataGridViewRow();
			NewRow.CreateCells(dgv);
			IntoDataGridViewRow(NewRow, SrcBmp, cif.FileName, dgv.Rows.Count + 1);
			
			//特徴クラスを作成してデータを挿入
			FeatureClass thisFeature = new FeatureClass();
			imageEffect.GetKajyu(cif.SrcBitmapSmall, thisFeature.Kajyu, thisFeature.KajyuView, mf.Setup.CharaR);
			imageEffect.GetHaikei(cif.SrcBitmapSmall, thisFeature.Haikei, thisFeature.HaikeiView, mf.Setup.CharaR);
			
			thisFeature.SrcBitmap = SrcBmp;
			thisFeature.FileName = cif.FileName;
			
			//コマンドマネージャへ
			//CheckUpDragInCommand command = new CheckUpDragInCommand(dgv.Rows, NewRow, feature[num], thisFeature);
			//undoManager.Action(command);
			dgv.Rows.Add(NewRow);
			
			features.Add(thisFeature);
			
			MakeSrcBmp();
			MakeR(features, dgv);
			FeatureToDGV();
		}
		
		void DgvGroupDragDrop(object sender, DragEventArgs e)
		{
			if(e.Data.GetDataPresent(typeof(CharaImageForm))){
				DragDropProc((CharaImageForm)e.Data.GetData(typeof(CharaImageForm)), dgvGroup, 0);
			}
		}
		
		void DgvGroupDragEnter(object sender, DragEventArgs e)
		{
			if(e.Data.GetDataPresent(typeof(CharaImageForm))){
				e.Effect = DragDropEffects.Copy;
			}else{
				e.Effect = DragDropEffects.None;
			}
		}
		
		#region ペイント処理
		//重ねあわせ画像ペイント
		void ImageBoxPaint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawImage(viewBmp, 0, 0);
		}
		//平均特徴ペイント
		void FeatureBoxPaint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawImage(viewFeatureBmp, 0, 0);
		}
		#endregion
		
		#region 削除ボタン
		void BtnDelete1Click(object sender, EventArgs e)
		{
			if(dgvGroup.CurrentRow == null)return;
			
			features.RemoveAt(dgvGroup.CurrentRow.Index);
			dgvGroup.Rows.RemoveAt(dgvGroup.CurrentRow.Index);
			
			MakeSrcBmp();
			MakeR(features, dgvGroup);
			FeatureToDGV();
		}
		#endregion
		
		#region ウィンドウが開かれたら
		void AverageMakerLoad(object sender, EventArgs e)
		{
			//メインフォームにウィンドウリストを追加してもらう
			//MainForm mf = (MainForm)MdiParent;
			windowID = mf.AddWindowList(this.Name, fileName);
			this.Text = mf.GetWindowTitle(windowID);
		}
		#endregion
		
		#region ウィンドウが閉じられるときに
		void AverageMakerFormClosing(object sender, FormClosingEventArgs e)
		{
			//メインフォームにウィンドウリストから削除してもらう
			//MainForm mf = (MainForm)this.MdiParent;
			mf.RemoveWindowAtID(windowID);
		}
		#endregion
		
		#region ファイルを開く(CFAファイル)
		public void OpenCFAFile()
		{
			if(fileName == "" || fileName == null)return;
			//個人内変動ファイルを開く
			FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
			BinaryFormatter bf = new BinaryFormatter();
			
			features = (ArrayList)bf.Deserialize(fs);
			
			fs.Close();
			
			foreach(FeatureClass fc in features){
				//DataGridView用のデータを作成
				DataGridViewRow NewRow = new DataGridViewRow();
				NewRow.CreateCells(dgvGroup);
				IntoDataGridViewRow(NewRow, fc.SrcBitmap, fc.FileName, dgvGroup.Rows.Count + 1);
				dgvGroup.Rows.Add(NewRow);
			}
			
			MakeSrcBmp();
			MakeR(features, dgvGroup);
			FeatureToDGV();
			
			//最近使ったファイルに追加してもらう
			//MainForm mf = (MainForm)this.MdiParent;
			mf.AddRecentlyFile(fileName);
		}
		#endregion
		
		#region ファイルを保存(CFAファイル)
		void SaveCFAFile()
		{
			if(fileName == "" || fileName == null)return;
			FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
			BinaryFormatter bf = new BinaryFormatter();
			
			bf.Serialize(fs, features);
			
			fs.Close();
			
			//最近使ったファイルに追加してもらう
			//MainForm mf = (MainForm)this.MdiParent;
			mf.AddRecentlyFile(fileName);
		}
		#endregion
		
		#region ツールバーメニュー
		#region 開く
		void BtnOpenClick(object sender, EventArgs e)
		{
			
			if(openFileDlg.ShowDialog() == DialogResult.OK){
				if(System.IO.Path.GetExtension(openFileDlg.FileName) == ".cfa"){
					FileName = openFileDlg.FileName;
					OpenCFAFile();
				}else{
					MessageBox.Show("個人内変動データではありません。ファイルを確認してください", "CharacomImagerPro",MessageBoxButtons.OK, MessageBoxIcon.Error);
					
				}
			}
		}
		#endregion
		
		#region 保存
		void BtnSaveClick(object sender, EventArgs e)
		{
			if(this.FileName.IndexOf("無題") >= 0 || fileName == "" || fileName == null){
				if(saveFileDlg.ShowDialog() == DialogResult.OK){
					this.FileName = saveFileDlg.FileName;
				}else{
					return;
				}
			}
			SaveCFAFile();
		}
		#endregion
		#endregion
		
		#region 特徴抽出ラベル表示
		void ToolStripLabel1Paint(object sender, PaintEventArgs e)
		{
			//MainForm mf = new MainForm();
			//mf = (MainForm)this.MdiParent;
			if(mf.Setup.Kajyu)  toolStripLabel1.Text = "特徴抽出法：加重方向指数ヒストグラム";
			else				toolStripLabel1.Text = "特徴抽出法：背景伝搬法";
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
