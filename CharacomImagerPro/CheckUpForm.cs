/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2011/10/17
 * 時刻: 13:04
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
	/// Description of CheckUpForm.
	/// </summary>
	public partial class CheckUpForm : Form
	{
		//コマンドマネージャ
		public CommandManager undoManager = new CommandManager();
		ImageEffect imageEffect = new ImageEffect();
		MathClass mathClass = new MathClass();
		Bitmap ViewDispersionGraphA;
		Bitmap ViewDispersionGraphB;
		//親フォームの参照
		private MainForm mf;
		
		Point MousePos;
		
		private ArrayList featureA = new ArrayList();
		private ArrayList featureB = new ArrayList();
		
		
		//平均特徴を置いておく
		double [] kajyuA = new double[256];
		public double[] KajyuA {
			get { return kajyuA; }
			set { kajyuA = value; }
		}
		double [] kajyuViewA = new double[256];
		double [] kajyuB = new double[256];
		public double[] KajyuB {
			get { return kajyuB; }
			set { kajyuB = value; }
		}
		double [] kajyuViewB = new double[256];
		
		double [] haikeiA = new double[512];
		public double[] HaikeiA {
			get { return haikeiA; }
			set { haikeiA = value; }
		}
		double [] haikeiViewA = new double[512];
		double [] haikeiB = new double[512];
		public double[] HaikeiB {
			get { return haikeiB; }
			set { haikeiB = value; }
		}
		double [] haikeiViewB = new double[512];
		
		//照合結果を残す
		double ruijido;
		public double Ruijido {
			get { return ruijido; }
			set { ruijido = value; }
		}
		double distance;
		public double Distance {
			get { return distance; }
			set { distance = value; }
		}
		bool isCheckUp = false;
		public bool IsCheckUp {
			get { return isCheckUp; }
			set { isCheckUp = value; }
		}
		//保存用ファイル名
		string fileName;
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
		
		public CheckUpForm(MainForm mainFrom)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			
			mf = mainFrom;
			InitializeComponent();
			BitmapInit();
			InitDispersionGraph(ViewDispersionGraphA);
			InitDispersionGraph(ViewDispersionGraphB);
			ChangeCanUndoBtn();
			
			this.FileNameChanged += new EventHandler(this.OnFileNameChanged);
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
		
		#region Undo Redoのチェックをしてツールバーを変更
		void ChangeCanUndoBtn()
		{
			btnUndo.Enabled = undoManager.CanUndo();
			btnRedo.Enabled = undoManager.CanRedo();
			UndoMenu.Enabled = undoManager.CanUndo();
			RedoMenu.Enabled = undoManager.CanRedo();
		}
		#endregion
		
		#region 無題をつける
		public void SetNonTitle()
		{
			//タイトル文にファイル名を反映
			//MainForm mf = (MainForm)this.MdiParent;
			FileName = "無題" + mf.GetTitleNo(this.Name).ToString() + ".cki";
			
		}
		#endregion
		
		#region Bitmapの初期化
		void BitmapInit()
		{
			ViewDispersionGraphA = new Bitmap(DispersionGraphA.Width, DispersionGraphA.Height);
			ViewDispersionGraphB = new Bitmap(DispersionGraphB.Width, DispersionGraphB.Height);
			
			imageEffect.BitmapWhitening(ViewDispersionGraphA);
			imageEffect.BitmapWhitening(ViewDispersionGraphB);
		}
		#endregion
		
		#region DataGridViewへ追加
		void IntoDataGridView(DataGridView dgv, Bitmap bmp, string FileName)
		{
			dgv.Rows.Add();
			dgv[0, dgv.Rows.Count - 1].Value = dgv.Rows.Count.ToString();
			dgv[1, dgv.Rows.Count - 1].Value = bmp;
			dgv[2, dgv.Rows.Count - 1].Value = Path.GetFileName(FileName);
			//dgv[3, dgv.Rows.Count - 1].Value = imglCheck.Images[0];
			
		}
		void IntoDataGridViewRow(DataGridViewRow Row, Bitmap bmp, string FileName, int num)
		{
			Row.Height = 80;
			Row.Cells[0].Value = num.ToString();
			Row.Cells[1].Value = bmp;
			Row.Cells[2].Value = Path.GetFileName(FileName);
			//dgv[3, dgv.Rows.Count - 1].Value = imglCheck.Images[0];
			
		}
		#endregion
		
		#region 分散の算出
		void MakeVarLabel(ArrayList feature, Label lbl)
		{
			double Var;
			int mode;
			//MainForm mf = new MainForm();
			//mf = (MainForm)this.MdiParent;
			
			if(mf.Setup.Kajyu){
				//特徴抽出法が加重方向指数ヒストグラム特徴の場合
				mode = 0;
			}else{
				//特徴抽出法が背景伝搬法の場合
				mode = 1;
			}
			Var = mathClass.GetVar(feature, mode);
			lbl.Text = Var.ToString("F2");
		}
		#endregion
		
		#region DataGridViewへ類似度の反映
		void UpdateDataGridViewR(DataGridView dgv, int Index, double R)
		{
			dgv[3, Index].Value = R.ToString("F4");
		}
		#endregion
		
		#region タイトルを右クリックしたらドラッグ開始
		protected override void WndProc(ref Message m)
		{
			if(m.Msg == 0xa4 && m.WParam == (System.IntPtr)0x2){
				this.DoDragDrop(this, DragDropEffects.All);
				//ImageBox.DoDragDrop(this, DragDropEffects.All);
			}
			base.WndProc(ref m);
		}
		#endregion
		
		#region 分散表示グラフ
		//類似度から表示グラフのX座標を算出
		int GetDispViewPoint(double r){
			//MainForm mf = new MainForm();
			//mf = (MainForm)this.MdiParent;
			int x2;
			double w;
			w = (double)ViewDispersionGraphA.Width / 6.0;
			int iRes;
			if(r > mf.Setup.Threshold[0, 0]){
				//右端
				x2 = (int)w * 5;
				iRes = (int)(w / (1.0 - mf.Setup.Threshold[0, 0]) * (r - mf.Setup.Threshold[0, 0]) + (double)x2);
				
			}else if(r > mf.Setup.Threshold[0, 1]){
				//右端
				x2 = (ViewDispersionGraphA.Width / 6) * 4;
				iRes = (int)(w / (mf.Setup.Threshold[0, 0] - mf.Setup.Threshold[0, 1]) * (r - mf.Setup.Threshold[0, 1]) + (double)x2);
			}else if(r > mf.Setup.Threshold[0, 2]){
				//右端
				x2 = (ViewDispersionGraphA.Width / 6) * 3;
				iRes = (int)(w / (mf.Setup.Threshold[0, 1] - mf.Setup.Threshold[0, 2]) * (r - mf.Setup.Threshold[0, 2]) + (double)x2);
			}else if(r > mf.Setup.Threshold[0, 3]){
				//右端
				x2 = (ViewDispersionGraphA.Width / 6) * 2;
				iRes = (int)(w / (mf.Setup.Threshold[0, 2] - mf.Setup.Threshold[0, 3]) * (r - mf.Setup.Threshold[0, 3]) + (double)x2);
			}else if(r > mf.Setup.Threshold[0, 4]){
				//右端
				x2 = (ViewDispersionGraphA.Width / 6) * 1;
				iRes = (int)(w / (mf.Setup.Threshold[0, 3] - mf.Setup.Threshold[0, 4]) * (r - mf.Setup.Threshold[0, 4]) + (double)x2);
			}else{
				//右端
				x2 = 0;
				iRes = (int)(w / (mf.Setup.Threshold[0, 4] - 0.0) * (r - 0.0));
			}
			return(iRes);
		}
		#endregion
		
		#region グラフ表示（お試し版)
		void MakeGraph(double [] kajyu, Bitmap bmp, Pen p)
		{
			Graphics g = Graphics.FromImage(bmp);
			
			for(int i=1; i<kajyu.Length; i++){
				g.DrawLine(p, (float)i-1, (float)((double)bmp.Height - (bmp.Height / 20.0) * kajyu[i-1]), (float)i, (float)((double)bmp.Height - (bmp.Height / 20.0) * kajyu[i]));
			}
			g.Dispose();
			
		}
		#endregion
		
		#region 特徴の平均の作成
		void MakeFeatureAverage(double [] kajyuAvg, double [] kajyuViewAvg, int AorB /*0:A 1:B*/)
		{
			//MainForm mf = new MainForm();
			//mf = (MainForm)this.MdiParent;
			
			int jigen;
			if(mf.Setup.Kajyu){
				jigen = 256;
			}else{
				jigen = 512;
			}
			
			double [] sum = new double[jigen];
			double [] sumView = new double[jigen];
			int num;
			int i;
			
			for(i=0; i<sum.Length; i++){
				sum[i]=0.0;
				sumView[i]=0.0;
			}
			if(AorB == 0){
				num = featureA.Count;
				foreach(FeatureClass fc in featureA){
					if(mf.Setup.Kajyu){
						for(i=0; i<fc.Kajyu.Length; i++){
							sum[i] += fc.Kajyu[i];
							sumView[i] += fc.KajyuView[i];
							//if(i>100 && i<110)System.Diagnostics.Debug.WriteLine(string.Format("{0}:k={1:f1} sum={2:f1} ",i, fc.Kajyu[i], sum[i]));
						}
					}else{
						for(i=0; i<fc.Kajyu.Length; i++){
							sum[i] += fc.Haikei[i];
							sumView[i] += fc.HaikeiView[i];
							//if(i>100 && i<110)System.Diagnostics.Debug.WriteLine(string.Format("{0}:k={1:f1} sum={2:f1} ",i, fc.Kajyu[i], sum[i]));
						}
					}
				}
			}else{
				num = featureB.Count;
				foreach(FeatureClass fc in featureB){
					if(mf.Setup.Kajyu){
						for(i=0; i<fc.Kajyu.Length; i++){
							sum[i] += fc.Kajyu[i];
							sumView[i] += fc.KajyuView[i];
							//if(i>100 && i<110)System.Diagnostics.Debug.WriteLine(string.Format("{0}:k={1:f1} sum={2:f1} ",i, fc.Kajyu[i], sum[i]));
						}
					}else{
						for(i=0; i<fc.Kajyu.Length; i++){
							sum[i] += fc.Haikei[i];
							sumView[i] += fc.HaikeiView[i];
							//if(i>100 && i<110)System.Diagnostics.Debug.WriteLine(string.Format("{0}:k={1:f1} sum={2:f1} ",i, fc.Kajyu[i], sum[i]));
						}
					}
				}
			}
			
			for(i=0; i<sum.Length; i++){
				kajyuAvg[i] = sum[i] / num;
				kajyuViewAvg[i] = sumView[i] / num;
				
			}
			//System.Diagnostics.Debug.WriteLine("");
		}
		void GetFeatureAverage(double [] kajyuAvg, double [] kajyuViewAvg, ArrayList feature)
		{
			//MainForm mf = new MainForm();
			//mf = (MainForm)this.MdiParent;
			
			int jigen;
			if(mf.Setup.Kajyu){
				jigen = 256;
			}else{
				jigen = 512;
			}
			
			double [] sum = new double[jigen];
			double [] sumView = new double[jigen];
			int num;
			int i;
			
			for(i=0; i<sum.Length; i++){
				sum[i]=0.0;
				sumView[i]=0.0;
			}
			num = feature.Count;
			foreach(FeatureClass fc in feature){
				if(mf.Setup.Kajyu){
					for(i=0; i<fc.Kajyu.Length; i++){
						sum[i] += fc.Kajyu[i];
						sumView[i] += fc.KajyuView[i];
						//if(i>100 && i<110)System.Diagnostics.Debug.WriteLine(string.Format("{0}:k={1:f1} sum={2:f1} ",i, fc.Kajyu[i], sum[i]));
					}
				}else{
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
		
		#region 類似度ばらつきグラフを作成
		void MakeDispersionGraph(Bitmap bmp, ArrayList feature, Label lbl, DataGridView dgv)
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
			double R,MaxR,MinR;
			//double D,MaxD,MinD;
			MaxR = 0.0; MinR = 5.0;
			//MaxD = 0.0; MinD = 100000000.0;
			
			InitDispersionGraph(bmp);
			int num = 0;
			foreach(FeatureClass fc in feature){
				if(mf.Setup.Kajyu){
					R = mathClass.GetR(kajyu, fc.Kajyu);
				}else{
					R = mathClass.GetR(kajyu, fc.Haikei);
				}
					//D = mathClass.GetDistance(kajyu, fc.Kajyu);
				if(MaxR < R) MaxR = R;
				if(MinR > R) MinR = R;
				//if(MaxD < D) MaxD = D;
				//if(MinD > D) MinD = D;
				fc.R = R;
				if(dgv.Rows.Count > num){
					dgv[0, num].Value = (num + 1).ToString();
					dgv[3, num].Value = fc.R.ToString("F4");
				}
				//UpdateDataGridViewR(dgvGroupA, num, fc.R);
				num++;
			}
			MaxMinDispersionGraph(bmp, MinR, MaxR);
			int k=0;
			bool bCurrent = false;
			int iCurrent;
			
			iCurrent = dgv.CurrentRow == null ? -1 : dgv.CurrentRow.Index;
			foreach(FeatureClass fc in feature){
				bCurrent = iCurrent == k ? true : false;
				if(mf.Setup.Kajyu){
					PointDispersionGraph(bmp, mathClass.GetR(kajyu, fc.Kajyu), bCurrent);
				}else{
					PointDispersionGraph(bmp, mathClass.GetR(kajyu, fc.Haikei), bCurrent);
				}
				k++;
			}
			lbl.Text = (MinR).ToString("F4")+"～"+(MaxR).ToString("F4");	
		}
		#endregion
		
		#region ばらつきグラフを初期化
		void InitDispersionGraph(Bitmap bmp)
		{
			Graphics g = Graphics.FromImage(bmp);
			Brush b;
			Rectangle r;
			Color [] backC = new Color[6];
			
			imageEffect.BitmapWhitening(bmp);
			backC[0] = Color.FromArgb(255, 255, 255, 255);
			backC[1] = Color.FromArgb(255, 223, 245, 255);
			backC[2] = Color.FromArgb(255, 187, 235, 255);
			backC[3] = Color.FromArgb(255, 140, 221, 255);
			backC[4] = Color.FromArgb(255, 102, 209, 255);
			backC[5] = Color.FromArgb(255,  55, 196, 255);
			
			for(int i=0; i<6; i++){
				r = new Rectangle((bmp.Width / 6 * i), 10, bmp.Width / 6, 30);
				b = new SolidBrush(backC[i]);
				
				g.FillRectangle(b, r);
			}
			g.Dispose();
		}
		#endregion
		
		#region ばらつきグラフに最大最小を表示
		void MaxMinDispersionGraph(Bitmap bmp, double min, double max)
		{
			int x1, x2;
			
			x1 = GetDispViewPoint(min);
			x2 = GetDispViewPoint(max);
			
			Graphics g = Graphics.FromImage(bmp);
			Brush b = new SolidBrush(Color.LawnGreen);
			Rectangle r;
			
			r = new Rectangle(x1, 15, x2 - x1, 20);
			g.FillRectangle(b, r);
			
			g.Dispose();
		}
		#endregion
		
		#region ばらつきグラフに類似度ポジションを表示
		void PointDispersionGraph(Bitmap bmp, double r, bool isCurrent){
			int size;
			int y;
			Graphics g = Graphics.FromImage(bmp);
			Brush b = new SolidBrush(Color.Red);
			size = isCurrent ? 6 : 3;
			y = isCurrent ? -3 : -2;
			b = isCurrent ? new SolidBrush(Color.Blue) : new SolidBrush(Color.Red);
			Rectangle rect = new Rectangle(GetDispViewPoint(r), 25 + y, size, size);
			g.FillRectangle(b, rect);
			g.Dispose();
		}
		#endregion
		
		#region ドラッグアンドドロップ入力A
		void DgvGroupADragDrop(object sender, DragEventArgs e)
		{
			CharaImageForm cif;
			if(e.Data.GetDataPresent(typeof(CharaImageForm))){
				//フォームの情報を拾う
				cif = (CharaImageForm)e.Data.GetData(typeof(CharaImageForm));
				//前処理をして特徴抽出に使う準備をする
				imageEffect.Normalize(cif.SrcBitmapSmall, mf.Setup.CharaR);
				imageEffect.Noize(cif.SrcBitmapSmall);
				//imageEffect.DrawTinning(cif.SrcBitmapSmall, cif.SrcBitmapSmall, Color.Black);
				
				//DataGridView用のデータを作成
				DataGridViewRow NewRow = new DataGridViewRow();
				NewRow.CreateCells(dgvGroupA);
				IntoDataGridViewRow(NewRow, cif.SrcBitmapSmall, cif.FileName, dgvGroupA.Rows.Count + 1);
				
				//特徴クラスを作成してデータを挿入
				FeatureClass thisFeature = new FeatureClass();
				imageEffect.GetKajyu(cif.SrcBitmapSmall, thisFeature.Kajyu, thisFeature.KajyuView, mf.Setup.CharaR);
				imageEffect.GetHaikei(cif.SrcBitmapSmall, thisFeature.Haikei, thisFeature.HaikeiView, mf.Setup.CharaR);
				
				thisFeature.SrcBitmap = cif.SrcBitmapSmall;
				thisFeature.FileName = cif.FileName;
				//featureA.Add(thisFeature);
				
				//コマンドマネージャへ
				CheckUpDragInCommand command = new CheckUpDragInCommand(dgvGroupA.Rows, NewRow, featureA, thisFeature);
				undoManager.Action(command);
				ChangeCanUndoBtn();
			
				//分散を作成
				MakeVarLabel(featureA, lblVarA);
				
				//ばらつきグラフと類似度表記を作成
				MakeDispersionGraph(ViewDispersionGraphA, featureA, lblRuijiAMax, dgvGroupA);
				DispersionGraphA.Invalidate();
			}
			
		}
		
		void DgvGroupADragEnter(object sender, DragEventArgs e)
		{
			if(e.Data.GetDataPresent(typeof(CharaImageForm))){
				e.Effect = DragDropEffects.Copy;
			}else{
				e.Effect = DragDropEffects.None;
			}
		}
		#endregion
		
		#region ドラッグアンドドロップ入力B
		void DgvGroupBDragEnter(object sender, DragEventArgs e)
		{
			if(e.Data.GetDataPresent(typeof(CharaImageForm))){
				e.Effect = DragDropEffects.Copy;
			}else{
				e.Effect = DragDropEffects.None;
			}
		}
		
		void DgvGroupBDragDrop(object sender, DragEventArgs e)
		{
			CharaImageForm cif;
			if(e.Data.GetDataPresent(typeof(CharaImageForm))){
				//フォームの情報を拾う
				cif = (CharaImageForm)e.Data.GetData(typeof(CharaImageForm));
				//前処理をして特徴抽出に使う準備をする
				imageEffect.Normalize(cif.SrcBitmapSmall, mf.Setup.CharaR);
				imageEffect.Noize(cif.SrcBitmapSmall);
				//imageEffect.DrawTinning(cif.SrcBitmapSmall, cif.SrcBitmapSmall, Color.Black);
				
				//DataGridView用のデータを作成
				DataGridViewRow NewRow = new DataGridViewRow();
				NewRow.CreateCells(dgvGroupB);
				IntoDataGridViewRow(NewRow, cif.SrcBitmapSmall, cif.FileName, dgvGroupB.Rows.Count + 1);
				
				//特徴クラスを作成してデータを挿入
				FeatureClass thisFeature = new FeatureClass();
				imageEffect.GetKajyu(cif.SrcBitmapSmall, thisFeature.Kajyu, thisFeature.KajyuView, mf.Setup.CharaR);
				imageEffect.GetHaikei(cif.SrcBitmapSmall, thisFeature.Haikei, thisFeature.HaikeiView, mf.Setup.CharaR);
				
				thisFeature.SrcBitmap = cif.SrcBitmapSmall;
				thisFeature.FileName = cif.FileName;
				//featureA.Add(thisFeature);
				
				//コマンドマネージャへ
				CheckUpDragInCommand command = new CheckUpDragInCommand(dgvGroupB.Rows, NewRow, featureB, thisFeature);
				undoManager.Action(command);
				ChangeCanUndoBtn();
			
				//分散を作成
				MakeVarLabel(featureB, lblVarB);
				
				//ばらつきグラフと類似度表記を作成
				MakeDispersionGraph(ViewDispersionGraphB, featureB, lblRuijiBMax, dgvGroupB);
				DispersionGraphB.Invalidate();
			}
		}
		#endregion
		
		#region 照合チェック(類似度)
		int GetCheckupR(double r)
		{
			//MainForm mf = new MainForm();
			//mf = (MainForm)this.MdiParent;
			
			int iRes;
			if(r > mf.Setup.Threshold[0, 0]) iRes = 0;
			else if(r > mf.Setup.Threshold[0, 1]) iRes = 1;
			else if(r > mf.Setup.Threshold[0, 2]) iRes = 2;
			else if(r > mf.Setup.Threshold[0, 3]) iRes = 3;
			else if(r > mf.Setup.Threshold[0, 4]) iRes = 4;
			else iRes = 5;
			return(iRes);
		}
		#endregion
		
		#region 照合チェック（距離)
		int GetCheckupD(double d)
		{
			//MainForm mf = new MainForm();
			//mf = (MainForm)this.MdiParent;
			
			int iRes;
			if(d < mf.Setup.Threshold[1, 0]) iRes = 0;
			else if(d < mf.Setup.Threshold[1, 1]) iRes = 1;
			else if(d < mf.Setup.Threshold[1, 2]) iRes = 2;
			else if(d < mf.Setup.Threshold[1, 3]) iRes = 3;
			else if(d < mf.Setup.Threshold[1, 4]) iRes = 4;
			else iRes = 5;
			return(iRes);
		}
		#endregion
		
		#region 照合チェック(類似度＋距離)
		int GetCheckupRD(double r, double d)
		{
			//MainForm mf = new MainForm();
			//mf = (MainForm)this.MdiParent;
			
			int iRes;
			if(r > mf.Setup.Threshold[0, 0] && d < mf.Setup.Threshold[1, 0]) iRes = 0;
			else if(r > mf.Setup.Threshold[0, 1] && d < mf.Setup.Threshold[1, 1]) iRes = 1;
			else if(r > mf.Setup.Threshold[0, 2] && d < mf.Setup.Threshold[1, 2]) iRes = 2;
			else if(r > mf.Setup.Threshold[0, 3] && d < mf.Setup.Threshold[1, 3]) iRes = 3;
			else if(r > mf.Setup.Threshold[0, 4] && d < mf.Setup.Threshold[1, 4]) iRes = 4;
			else iRes = 5;
			return(iRes);
		}
		#endregion
		
		#region 照合結果文字列を取得
		string GetString(int i)
		{
			//MainForm mf = new MainForm();
			//mf = (MainForm)this.MdiParent;
			
			string s = "";
			s = mf.Setup.Comment[i];
			return(s);
		}
		#endregion
		
		#region フォントの変更
		void LabelFontChange(Label l, int n)
		{
			//MainForm mf = new MainForm();
			//mf = (MainForm)this.MdiParent;
			
			Font f;
			if(mf.Setup.CommBold[n]){
				f = new Font("メイリオ",14,FontStyle.Bold);
			}else{
				f = new Font("メイリオ",14,FontStyle.Regular);
			}
			l.Font = f;
			l.ForeColor = mf.Setup.CommColor[n];	
		}
		#endregion
		
		#region ペイント処理
		void DispersionGraphAPaint(object sender, PaintEventArgs e)
		{
			Bitmap work = new Bitmap(DispersionGraphA.Width, DispersionGraphA.Height);
			
			imageEffect.BitmapStretchCopy(ViewDispersionGraphA, work);
			e.Graphics.DrawImage(work, 0, 0);
		}
		
		void DispersionGraphBPaint(object sender, PaintEventArgs e)
		{
			Bitmap work = new Bitmap(DispersionGraphB.Width, DispersionGraphB.Height);
			
			imageEffect.BitmapStretchCopy(ViewDispersionGraphB, work);
			e.Graphics.DrawImage(work, 0, 0);
		}
		#endregion
		
		#region 照合ボタンを押したとき
		void BtnCheckUpClick(object sender, EventArgs e)
		{
			//double [] GroupAKajyu = new double[256];
			//double [] GroupBKajyu = new double[256];
			double [] kajyuView = new double[256];
			//double R, D;
			
			//MainForm mf = new MainForm();
			//mf = (MainForm)this.MdiParent;
			if(mf.Setup.Kajyu){
				MakeFeatureAverage(KajyuA, kajyuView, 0);
				MakeFeatureAverage(KajyuB, kajyuView, 1);
				Ruijido = mathClass.GetR(KajyuA, KajyuB);
			}else{
				MakeFeatureAverage(HaikeiA, haikeiViewA, 0);
				MakeFeatureAverage(HaikeiB, haikeiViewB, 1);
				Ruijido = mathClass.GetR(HaikeiA, HaikeiB);
			}
			//Distance = mathClass.GetDistance(KajyuA, KajyuB);
			if(Double.IsNaN(Ruijido)){
				lblCheckupRuiji.Text = (0.0).ToString("p3");
			}else{
				lblCheckupRuiji.Text =Ruijido.ToString("p3");
			}
				//lblCheckupDistance.Text = Distance.ToString("F2");
			
			//照合
			int CheckUpR;//, CheckUpD;
			CheckUpR = GetCheckupR(Ruijido);
			//CheckUpD = GetCheckupD(Distance);
			LabelFontChange(lblRuijiLabel, CheckUpR);
			lblRuijiLabel.Text = GetString(CheckUpR);
			//LabelFontChange(lblDistanceLabel, CheckUpD);
			
			IsCheckUp = true;
				
		}
		#endregion
		
		#region DataGridViewの選択行が変更されたとき
		//グループA
		void DgvGroupASelectionChanged(object sender, EventArgs e)
		{
			if(dgvGroupA.CurrentRow == null) return;
			MakeDispersionGraph(ViewDispersionGraphA, featureA, lblRuijiAMax, dgvGroupA);
			DispersionGraphA.Invalidate();
		}		
		//グループB
		void DgvGroupBSelectionChanged(object sender, EventArgs e)
		{
			if(dgvGroupB.CurrentRow == null) return;
			MakeDispersionGraph(ViewDispersionGraphB, featureB, lblRuijiBMax, dgvGroupB);
			DispersionGraphB.Invalidate();
		}
		#endregion
		
		#region マウスポインタがコントロール上にあるかどうかの判定
		private bool GetControlContainState(Control ctrl, Point mouseScreenPos)
		{
			Rectangle rect = ctrl.ClientRectangle;
			// マウス座標（スクリーン座標系）の取得
		  	//Point mouseScreenPos = Control.MousePosition;
			// マウス座標をクライアント座標系へ変換
			Point mouseClientPos = ctrl.PointToClient(mouseScreenPos);
			// マウス座標（クライアント座標系）が領域内かどうか
			bool inside = rect.Contains(mouseClientPos);
			
			return(inside);
		}
		#endregion
		
		#region ツールバーメニュー
		#region 【開く】ボタン
		void BtnOpenClick(object sender, EventArgs e)
		{
			if(openFileDlg.ShowDialog() == DialogResult.OK){
				if(System.IO.Path.GetExtension(openFileDlg.FileName) == ".cki"){
					FileName = openFileDlg.FileName;
					OpenCKIFile();
				}else{
					MessageBox.Show("照合データではありません。ファイルを確認してください", "CharacomImagerPro",MessageBoxButtons.OK, MessageBoxIcon.Error);
					
				}
			}
		}
		#endregion
		
		#region 保存処理
		public void SaveAsCKIFile(object sender, EventArgs e)
		{
			if(saveFileDlg.ShowDialog() == DialogResult.OK){
				this.FileName = saveFileDlg.FileName;
				SaveCKIFile();
				
				//タイトルを変更
				SetTitleText();
				//最近使ったファイルに追加
				//MainForm mf = new MainForm();
				//mf = (MainForm)this.MdiParent;
				mf.AddRecentlyFile(fileName);
			}
		}
		#endregion
		
		#region 【保存】ボタン
		public void BtnSaveClick(object sender, EventArgs e)
		{
			if(this.FileName.IndexOf("無題") >= 0 || fileName == "" || fileName == null){
				if(saveFileDlg.ShowDialog() == DialogResult.OK){
					this.FileName = saveFileDlg.FileName;
				}else{
					return;
				}
			}
			SaveCKIFile();
			
			//タイトルを変更
			SetTitleText();
			//最近使ったファイルに追加
			//MainForm mf = new MainForm();
			//mf = (MainForm)this.MdiParent;
			mf.AddRecentlyFile(fileName);
		}
		#endregion
		
		#region タイトル文にファイル名を反映
		public void SetTitleText()
		{
			string before;
			
			before = this.Text;
			this.Text = "照合 - [" + System.IO.Path.GetFileName(fileName) + "]";
			//メインフォームにウィンドウリストを変更してもらう
			MainForm mf = (MainForm)MdiParent;
			mf.ChangeWindowName(before, this.Text);
			mf.UpdateWindowMenu();
		}
		#endregion
		
		#region ckiファイル(照合ファイル)を保存する
		public void SaveCKIFile()
		{
			if(fileName == "" || fileName == null)return;
			FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
			BinaryFormatter bf = new BinaryFormatter();
					
			bf.Serialize(fs, featureA);
			bf.Serialize(fs, featureB);
			fs.Close();
		}
		#endregion
		
		#region ckiファイル(照合ファイル)を開く
		public void OpenCKIFile()
		{
			if(fileName == "" || fileName == null) return;
			double Var;
			//照合ファイルを開く
			FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
			BinaryFormatter bf = new BinaryFormatter();
			
			featureA = (ArrayList)bf.Deserialize(fs);
			featureB = (ArrayList)bf.Deserialize(fs);
			fs.Close();
					
			//タイトル文にファイル名を反映
			SetTitleText();
			//DataGridViewに反映
			//グループA
			double MaxR, MinR;
			MaxR = 0.0; MinR = 100.0;
			dgvGroupA.Rows.Clear();
			int num=0;
			foreach(FeatureClass fc in featureA){
				if(MaxR < fc.R) MaxR = fc.R;
				if(MinR > fc.R) MinR = fc.R;
				IntoDataGridView(dgvGroupA, fc.SrcBitmap, fc.FileName);
				UpdateDataGridViewR(dgvGroupA, num, fc.R);
				num++;
			}
			lblRuijiAMax.Text = (MinR).ToString("F4")+"～"+(MaxR).ToString("F4");
			//分散を算出
			//MainForm mf = new MainForm();
			//mf = (MainForm)this.MdiParent;
			if(mf.Setup.Kajyu){
				Var = mathClass.GetVar(featureA, 0);
			}else{
				Var = mathClass.GetVar(featureA, 1);
			}
			lblVarA.Text = Var.ToString("F2");
				
			//グループB
			dgvGroupB.Rows.Clear();
			num = 0;
			MaxR = 0.0; MinR = 100.0;
			foreach(FeatureClass fc in featureB){
				if(MaxR < fc.R) MaxR = fc.R;
				if(MinR > fc.R) MinR = fc.R;
				IntoDataGridView(dgvGroupB, fc.SrcBitmap, fc.FileName);
				UpdateDataGridViewR(dgvGroupB, num, fc.R);
				num++;
			}
			lblRuijiBMax.Text = (MinR).ToString("F4")+"～"+(MaxR).ToString("F4");
			//分散を算出
			if(mf.Setup.Kajyu){
				Var = mathClass.GetVar(featureB, 0);
			}else{
				Var = mathClass.GetVar(featureB, 1);
			}
			lblVarB.Text = Var.ToString("F2");
			
			//最近使ったファイルに追加
			mf.AddRecentlyFile(fileName);
		}
		#endregion
		
		#region 【Undo】ボタン
		public void BtnUndoClick(object sender, EventArgs e)
		{
			undoManager.Undo();
			//分散を作成
			MakeVarLabel(featureA, lblVarA);	
			//ばらつきグラフと類似度表記を作成
			MakeDispersionGraph(ViewDispersionGraphA, featureA, lblRuijiAMax, dgvGroupA);
			MakeDispersionGraph(ViewDispersionGraphB, featureB, lblRuijiBMax, dgvGroupB);
			DispersionGraphA.Invalidate();
			DispersionGraphB.Invalidate();
			ChangeCanUndoBtn();
		}
		#endregion
		
		#region 【Redo】ボタン
		public void BtnRedoClick(object sender, EventArgs e)
		{
			undoManager.Redo();
			//分散を作成
			MakeVarLabel(featureA, lblVarA);	
			//ばらつきグラフと類似度表記を作成
			MakeDispersionGraph(ViewDispersionGraphA, featureA, lblRuijiAMax, dgvGroupA);
			MakeDispersionGraph(ViewDispersionGraphB, featureB, lblRuijiBMax, dgvGroupB);
			DispersionGraphA.Invalidate();
			DispersionGraphB.Invalidate();
			ChangeCanUndoBtn();
		}
		#endregion
		
		#region 【削除】ボタン
		void BtnDeleteClick(object sender, EventArgs e)
		{
			if(GetControlContainState(dgvGroupA, MousePos)){
				if(dgvGroupA.CurrentRow != null){
					CheckUpDeleteCommand command = new CheckUpDeleteCommand(dgvGroupA.Rows, featureA, dgvGroupA.CurrentRow.Index);
					undoManager.Action(command);
					ChangeCanUndoBtn();
					//分散を作成
					MakeVarLabel(featureA, lblVarA);
					//ばらつきグラフと類似度表記を作成
					MakeDispersionGraph(ViewDispersionGraphA, featureA, lblRuijiAMax, dgvGroupA);
					DispersionGraphA.Invalidate();
				}
			}else if(GetControlContainState(dgvGroupB, MousePos)){
				if(dgvGroupB.CurrentRow != null){
					CheckUpDeleteCommand command = new CheckUpDeleteCommand(dgvGroupB.Rows, featureB, dgvGroupB.CurrentRow.Index);
					undoManager.Action(command);
					ChangeCanUndoBtn();
					//分散を作成
					MakeVarLabel(featureB, lblVarB);
					//ばらつきグラフと類似度表記を作成
					MakeDispersionGraph(ViewDispersionGraphB, featureB, lblRuijiBMax, dgvGroupB);
					DispersionGraphB.Invalidate();
				}
			}
		}
		#endregion
		
		#region 【コピー】ボタン
		void BtnCopyClick(object sender, EventArgs e)
		{
			MessageBox.Show("ダミーです。フォーマットが確定するまで使えません","CharacomImagerPro",MessageBoxButtons.OK,MessageBoxIcon.Error);
		}
		#endregion
		
		#region 【印刷】ボタン
		void BtnPrintClick(object sender, EventArgs e)
		{
			MessageBox.Show("ダミーです。フォーマットが確定するまで使えません","CharacomImagerPro",MessageBoxButtons.OK,MessageBoxIcon.Error);
		}
		#endregion
		
		#region 【印刷プレビュー】ボタン
		void BtnPreViewClick(object sender, EventArgs e)
		{
			MessageBox.Show("ダミーです。フォーマットが確定するまで使えません","CharacomImagerPro",MessageBoxButtons.OK,MessageBoxIcon.Error);
		}
		#endregion
		
		#endregion
		
		#region ウィンドウが開かれたら
		void CheckUpFormShown(object sender, EventArgs e)
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
		void CheckUpFormFormClosing(object sender, FormClosingEventArgs e)
		{
			//メインフォームにウィンドウリストから削除してもらう
			//MainForm mf = (MainForm)this.MdiParent;
			mf.RemoveWindowAtID(windowID);
		}
		#endregion
		
		#region コンテキストメニュー
		void OpenMenuClick(object sender, EventArgs e)
		{
			BtnOpenClick(sender, e);
		}
		
		void SaveMenuClick(object sender, EventArgs e)
		{
			BtnSaveClick(sender, e);
		}
		
		void UndoMenuClick(object sender, EventArgs e)
		{
			BtnUndoClick(sender, e);
		}
		
		void RedoMenuClick(object sender, EventArgs e)
		{
			BtnRedoClick(sender, e);
		}
		
		void DeleteMenuClick(object sender, EventArgs e)
		{
			BtnDeleteClick(sender, e);
		}
		
		void CopyMenuClick(object sender, EventArgs e)
		{
			BtnCopyClick(sender, e);
		}
		
		void PrintMenuClick(object sender, EventArgs e)
		{
			BtnPrintClick(sender, e);
		}
		
		void PreViewMenuClick(object sender, EventArgs e)
		{
			BtnPreViewClick(sender, e);
		}
		#endregion
		
		#region コンテキストメニューが開いたとき
		void SubMenuOpened(object sender, EventArgs e)
		{
			MousePos = Control.MousePosition;
			if(GetControlContainState(dgvGroupA, MousePos)){
				if(dgvGroupA.CurrentRow == null){
					DeleteMenu.Enabled = false;
				}else{
					DeleteMenu.Enabled = true;
				}
			}else if(GetControlContainState(dgvGroupB, MousePos)){
				if(dgvGroupB.CurrentRow == null){
					DeleteMenu.Enabled = false;
				}else{
					DeleteMenu.Enabled = true;
				}
			}
			ChangeCanUndoBtn();
		}
		#endregion
		
		#region ウィンドウリサイズ対応
		void CheckUpFormSizeChanged(object sender, EventArgs e)
		{
			//グループのリサイズと配置変更
			groupA.Width = (this.Width - 30) / 2;
			groupB.Width = (this.Width - 30) / 2;
			groupA.Height = this.Height - 186;
			groupB.Height = this.Height - 186;
			groupB.Location = new Point(2+groupA.Width+6, 27);
			
			//画像入力DGVのリサイズ
			dgvGroupA.Width = groupA.Width - 12;
			dgvGroupB.Width = groupB.Width - 12;
			dgvGroupA.Height = groupA.Height - 151;
			dgvGroupB.Height = groupB.Height - 151;
			//ばらつきグループのリサイズと配置変更
			groupBox4.Width = groupA.Width;
			groupBox5.Width = groupB.Width;
			groupBox4.Location = new Point( 0, groupA.Height - 127);
			groupBox5.Location = new Point( 0, groupB.Height - 127);
			
			//ばらつきグラフのリサイズ
			DispersionGraphA.Width = groupBox4.Width - 12;
			DispersionGraphB.Width = groupBox5.Width - 12;
			
			//分散・類似度結果のリサイズ
			lblVarA.Width = groupBox4.Width - 71;
			lblVarB.Width = groupBox5.Width - 71;
			lblRuijiAMax.Width = groupBox4.Width - 71;
			lblRuijiBMax.Width = groupBox5.Width - 71;
			
			//結果グループのリサイズと配置変更
			groupBox6.Width = this.Width - 24;
			groupBox6.Location = new Point( 2, this.Height - 130);
			lblRuijiLabel.Width = groupBox6.Width - 300;
			//照合ボタンの配置変更
			btnCheckUp.Location = new Point( 5 + groupA.Width - 37, this.Height - 156);
		}
		#endregion
		
		void CheckUpFormLoad(object sender, EventArgs e)
		{
			CheckUpFormSizeChanged(sender, e);
		}
		
		#region 特徴抽出ラベル表示
		void ToolStripLabel1Paint(object sender, PaintEventArgs e)
		{
			//MainForm mf = new MainForm();
			//mf = (MainForm)this.MdiParent;
			if(mf.Setup.Kajyu)  toolStripLabel1.Text = "特徴抽出法：加重方向指数ヒストグラム";
			else				toolStripLabel1.Text = "特徴抽出法：背景伝搬法";
		}
		#endregion
	}
}
