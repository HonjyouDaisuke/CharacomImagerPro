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
using Dustin.Graph;
using System.Drawing.Drawing2D;

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
		MathClass mathClass = new MathClass();

		//private ArrayList lapArray = new ArrayList();
		private ArrayList ImageArray = new ArrayList();
		Bitmap viewBitmap = new Bitmap(320, 320);
		Bitmap wideBitmap;
		double[] zoom = { 4.0, 3.0, 2.0, 1.5, 1.0, 0.5 };
		private string fileName;
		//2021.09.06 D.Honjyou
		//重ね合わせ類似度表示のため追加
		private ArrayList chkDeletes = new ArrayList();
		private ArrayList colorPanels = new ArrayList();
		private ArrayList lblCharas = new ArrayList();
		private ArrayList btnDeletes = new ArrayList();
		private ArrayList btnUps = new ArrayList();
		private ArrayList btnDowns = new ArrayList();
		private ArrayList btnLefts = new ArrayList();
		private ArrayList btnRights = new ArrayList();
		private ArrayList DataGridViews = new ArrayList();
		private ArrayList features = new ArrayList();
		private int GroupNum = 0;
		//親フォームの参照
		private MainForm mf;

		//個人内変動グラフ用
		Bitmap GraphBmp = new Bitmap(113, 400);
		Bitmap GraphBmp2 = new Bitmap(113, 400);


		public string FileName {
			get { return fileName; }
			set {
				fileName = value;

				if (FileNameChanged != null) {
					FileNameChanged(this, EventArgs.Empty);
				}
			}
		}

		public ArrayList Features
		{
			get { return features; }
			set { features = value; }
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

			AddControl();
			features.Add(new ArrayList());
			ImageArray.Add(new ArrayList());
			AddControl();
			features.Add(new ArrayList());
			ImageArray.Add(new ArrayList());


			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

		#region DataGridViewを追加する
		/// <summary>
		/// 2021.09.06 D.Honjyou
		/// </summary>
		void AddControl()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntraindividualVariationForm));
			//this.panel2.SizeChanged -= new System.EventHandler(this.Panel2SizeChanged);

			#region DataGridViewを追加する
			DataGridViewTextBoxColumn Nos = new DataGridViewTextBoxColumn();
			DataGridViewImageColumn Images = new DataGridViewImageColumn();
			DataGridViewTextBoxColumn Addresses = new DataGridViewTextBoxColumn();
			DataGridViewTextBoxColumn Checks = new DataGridViewTextBoxColumn();
			DataGridViewTextBoxColumn HandW = new DataGridViewTextBoxColumn();
			// No
			Nos.HeaderText = "No.";
			Nos.Name = "No";
			Nos.SortMode = DataGridViewColumnSortMode.NotSortable;
			Nos.Width = 30;
			// Image
			Images.HeaderText = "イメージ";
			Images.ImageLayout = DataGridViewImageCellLayout.Stretch;
			Images.Name = "Image";
			Images.Width = 50;
			// Address
			Addresses.HeaderText = "ファイル名";
			Addresses.Name = "Address";
			Addresses.SortMode = DataGridViewColumnSortMode.NotSortable;
			Addresses.Width = 90;
			// Check
			Checks.HeaderText = "類似度";
			Checks.Name = "Check";
			Checks.Resizable = DataGridViewTriState.True;
			Checks.SortMode = DataGridViewColumnSortMode.NotSortable;
			Checks.Width = 50;
			// 縦横比
			HandW.HeaderText = "縦横比";
			HandW.Name = "HandW";
			HandW.Resizable = DataGridViewTriState.True;
			HandW.SortMode = DataGridViewColumnSortMode.NotSortable;
			HandW.Width = 50;

			DataGridView dgv = new DataGridView();
			dgv.AllowDrop = true;
			dgv.AllowUserToAddRows = false;
			dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv.Columns.AddRange(new DataGridViewColumn[] {
									Nos,
									Images,
									Addresses,
									Checks,
									HandW});
			dgv.Location = new Point(3 + GroupNum * 280 - panel1.HorizontalScroll.Value, 23 - panel1.VerticalScroll.Value);
			dgv.Name = "dgvGroup" + (GroupNum + 1).ToString();
			dgv.RowHeadersVisible = false;
			dgv.RowTemplate.Height = 80;
			dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgv.Size = new Size(275, panel1.Height - 80);
			dgv.TabIndex = 1;
			dgv.DragEnter += new DragEventHandler(this.DgvGroupDragEnter);
			dgv.DragDrop += new DragEventHandler(this.DgvGroupDragDrop);
			panel2.Controls.Add(dgv);
			DataGridViews.Add(dgv);
			#endregion

			#region チェックボックスを追加する
			CheckBox chkDelete = new CheckBox();
			chkDelete.Text = "";
			chkDelete.Name = "chkDelete" + (GroupNum + 1).ToString();
			chkDelete.Size = new Size(19, 19);
			chkDelete.Location = new Point(30 + GroupNum * 280 - panel1.HorizontalScroll.Value, 2 - panel1.VerticalScroll.Value);
			chkDeletes.Add(chkDelete);
			panel2.Controls.Add(chkDelete);
			#endregion

			#region 表示色を追加する
			Label label = new Label();
			label.Text = "選択色" + (GroupNum + 1).ToString();
			label.Name = "lblChara" + (GroupNum + 1).ToString();
			label.Size = new Size(51, 13);
			label.Location = new Point(68 + GroupNum * 280 - panel1.HorizontalScroll.Value, 5 - panel1.VerticalScroll.Value);
			lblCharas.Add(label);
			panel2.Controls.Add(label);

			Panel panel = new Panel();
			panel.Name = "colorPanel" + (GroupNum + 1).ToString();
			panel.Size = new Size(50, 19);
			panel.Location = new Point(125 + GroupNum * 280 - panel1.HorizontalScroll.Value, 2 - panel1.VerticalScroll.Value);
			panel.BorderStyle = BorderStyle.FixedSingle;
			panel2.Controls.Add(panel);
			colorPanels.Add(panel);
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
			btnDelete.Location = new System.Drawing.Point(84 + GroupNum * 280 - panel1.HorizontalScroll.Value, panel1.Height - 50 - panel1.VerticalScroll.Value);
			btnDelete.Name = "btnDelete" + (GroupNum + 1).ToString();
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
			btnDown.Location = new System.Drawing.Point(153 + GroupNum * 280 - panel1.HorizontalScroll.Value, panel1.Height - 50 - panel1.VerticalScroll.Value);
			btnDown.Name = "btnDown" + (GroupNum + 1).ToString();
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
			btnUp.Location = new System.Drawing.Point(3 + GroupNum * 280 - panel1.HorizontalScroll.Value, panel1.Height - 50 - panel1.VerticalScroll.Value);
			btnUp.Name = "btnUp" + (GroupNum + 1).ToString();
			btnUp.Size = new System.Drawing.Size(75, 23);
			btnUp.TabIndex = 6;
			btnUp.Text = "ひとつ上へ";
			btnUp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			btnUp.UseVisualStyleBackColor = true;
			btnUp.Click += new System.EventHandler(this.BtnUpClick);
			btnUps.Add(btnUp);
			// btnLeft
			if (GroupNum != 0)
			{
				btnLeft.Image = imageList1.Images[3];
				btnLeft.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
				btnLeft.Location = new System.Drawing.Point(3 + GroupNum * 280 - panel1.HorizontalScroll.Value, 2 - panel1.VerticalScroll.Value);
				btnLeft.Name = "btnLeft" + (GroupNum + 1).ToString();
				btnLeft.Size = new System.Drawing.Size(20, 20);
				btnLeft.TabIndex = 9;
				btnLeft.Text = "";
				btnLeft.UseVisualStyleBackColor = true;
				//btnLeft.Click += new System.EventHandler(this.BtnLeftClick);
				btnLefts.Add(btnLeft);
			}
			// btnRight
			btnRight.Image = imageList1.Images[4];
			btnRight.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			btnRight.Location = new System.Drawing.Point(207 + GroupNum * 280 - panel1.HorizontalScroll.Value, 2 - panel1.VerticalScroll.Value);
			btnRight.Name = "btnRight" + (GroupNum + 1).ToString();
			btnRight.Size = new System.Drawing.Size(20, 20);
			btnRight.TabIndex = 10;
			btnRight.Text = "";
			btnRight.UseVisualStyleBackColor = true;
			//btnRight.Click += new System.EventHandler(this.BtnRightClick);
			btnRights.Add(btnRight);

			panel2.Controls.Add(btnUp);
			panel2.Controls.Add(btnDown);
			panel2.Controls.Add(btnDelete);
			//if (GroupNum != 0) panel2.Controls.Add(btnLeft);
			//panel1.Controls.Add(btnRight);
			#endregion
			//features.Add(new ArrayList());
			GroupNum++;
			//this.panel1.SizeChanged += new System.EventHandler(this.Panel1SizeChanged);

		}
		#endregion

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



		#region 特徴の平均の作成
		void GetFeatureAverage(double[] kajyuAvg, double[] kajyuViewAvg, ArrayList feature)
		{
			double[] sum = new double[kajyuAvg.Length];
			double[] sumView = new double[kajyuViewAvg.Length];
			int num;
			int i;

			for (i = 0; i < sum.Length; i++)
			{
				sum[i] = 0.0;
				sumView[i] = 0.0;
			}
			num = feature.Count;
			//MainForm mf = new MainForm();
			//mf = (MainForm)this.MdiParent;

			foreach (FeatureClass fc in feature)
			{
				if (mf.Setup.Kajyu)
				{
					//加重の場合
					for (i = 0; i < fc.Kajyu.Length; i++)
					{
						sum[i] += fc.Kajyu[i];
						sumView[i] += fc.KajyuView[i];
						//if(i>100 && i<110)System.Diagnostics.Debug.WriteLine(string.Format("{0}:k={1:f1} sum={2:f1} ",i, fc.Kajyu[i], sum[i]));
					}
				}
				else
				{
					//背景伝搬の場合
					for (i = 0; i < fc.Haikei.Length; i++)
					{
						sum[i] += fc.Haikei[i];
						sumView[i] += fc.HaikeiView[i];
						//if(i>100 && i<110)System.Diagnostics.Debug.WriteLine(string.Format("{0}:k={1:f1} sum={2:f1} ",i, fc.Kajyu[i], sum[i]));
					}
				}
			}

			for (i = 0; i < sum.Length; i++)
			{
				kajyuAvg[i] = sum[i] / num;
				kajyuViewAvg[i] = sumView[i] / num;
			}
		}
		#endregion

		#region 類似度を作成
		void MakeR(ArrayList feature)
		{
			double[] kajyuAvg = new double[256];
			double[] kajyuViewAvg = new double[256];
			double[] haikeiAvg = new double[512];
			double[] haikeiViewAvg = new double[512];
			//MainForm mf = new MainForm();
			//mf = (MainForm)this.MdiParent;
			if (mf.Setup.Kajyu)
			{
				//加重方向指数ヒストグラム特徴の場合
				GetFeatureAverage(kajyuAvg, kajyuViewAvg, feature);
			}
			else
			{
				//背景伝搬法の場合
				GetFeatureAverage(haikeiAvg, haikeiViewAvg, feature);
			}
			//グループ内の平均特徴と入力したパターンでの類似度を出す。
			//2012.01.20 D.Honjyou
			double R, R2;

			int num = 0;
			foreach (FeatureClass fc in feature)
			{
				if (mf.Setup.Kajyu)
				{
					R = mathClass.GetR(kajyuAvg, fc.Kajyu);
					R2 = mathClass.GetR2(kajyuAvg, fc.Kajyu, feature.Count);
				}
				else
				{
					R = mathClass.GetR(haikeiAvg, fc.Haikei);
					R2 = mathClass.GetR2(haikeiAvg, fc.Haikei, feature.Count);
				}
				fc.R = R;
				fc.R2 = R2;
				/**
				if (dgv.Rows.Count > num)
				{
					dgv[0, num].Value = (num + 1).ToString();
					dgv[3, num].Value = fc.R.ToString("F4");
					//dgv[4, num].Value = "縦横";
					//System.Diagnostics.Debug.WriteLine("R = " + fc.R.ToString("f4") + " : R2 = " + fc.R2.ToString("f4"));
				}
				**/
				num++;
			}
		}
		#endregion



		#region ドラッグアンドドロップ
		//2021.09.09 D.Honjyou
		//ドラッグアンドドロップを作成したDataGridViewに対応
		//////////////////////////////////////////////////////////////////////////////////////////////////
		void DragDropProc(CharaImageForm cif, DataGridView dgv, int num)
		{
			//前処理をして特徴抽出に使う準備をする
			imageEffect.Normalize(cif.SrcBitmapSmall, mf.Setup.CharaR);
			imageEffect.Noize(cif.SrcBitmapSmall);
			//imageEffect.DrawTinning(cif.SrcBitmapSmall, cif.SrcBitmapSmall, Color.Black);


			//DataGridView用のデータを作成
			DataGridViewRow NewRow = new DataGridViewRow();
			NewRow.CreateCells(dgv);
			//IntoDataGridView(NewRow, cif.ImageData.ProcImage, cif.ImageData.Filename, dgv.Rows.Count + 1);
			((ArrayList)ImageArray[num]).Add(cif.ImageData);


			//特徴クラスを作成してデータを挿入
			FeatureClass thisFeature = new FeatureClass();
			imageEffect.GetKajyu(cif.SrcBitmapSmall, thisFeature.Kajyu, thisFeature.KajyuView, mf.Setup.CharaR);
			imageEffect.GetHaikei(cif.SrcBitmapSmall, thisFeature.Haikei, thisFeature.HaikeiView, mf.Setup.CharaR);

			thisFeature.SrcBitmap = cif.SrcBitmapSmall;
			thisFeature.FileName = cif.FileName;
			thisFeature.ViewColor = cif.dispColor;

			//コマンドマネージャへ
			//CheckUpDragInCommand command = new CheckUpDragInCommand(dgv.Rows, NewRow, feature[num], thisFeature);
			//undoManager.Action(command);
			
			System.Diagnostics.Debug.WriteLine(int.Parse(dgv.Name.Substring(8)).ToString());
			((ArrayList)features[num]).Add(thisFeature);

			System.Diagnostics.Debug.WriteLine("特徴[" + num.ToString() + "]の個数は" + ((ArrayList)features[num]).Count.ToString());
			MakeR((ArrayList)features[num]);
			System.Diagnostics.Debug.WriteLine("ColorNo = " + mf.Setup.GetColorNo(cif.dispColor.Name).ToString());
			System.Diagnostics.Debug.WriteLine("Title = " + cif.Text);
			IntoDataGridView(NewRow, cif.ImageData.ProcImage, cif.ImageData.Filename, (ArrayList)features[num], dgv.Rows.Count + 1);
			dgv.Rows.Add(NewRow);

			//dgvLegendUpDownCheck(mf.Setup.GetColorNo(cif.dispColor.Name), System.IO.Path.GetFileNameWithoutExtension(cif.FileName));
		}
        #endregion

        void PutRewriteR(DataGridView dgv, ArrayList fcs)
        {
			for(int i=0; i<fcs.Count; i++)
            {
				dgv.Rows[i].Cells[3].Value = ((FeatureClass)fcs[i]).R;
            }
			
        }

		void DragDropAverage(AverageMaker avf, DataGridView dgv, int num)
		{
			//DataGridView用のデータを作成
			DataGridViewRow NewRow = new DataGridViewRow();
			NewRow.CreateCells(dgv);
			
			//特徴クラスを作成してデータを挿入
			FeatureClass thisFeature = new FeatureClass();
			for (int i = 0; i < thisFeature.Kajyu.Length; i++)
			{
				thisFeature.Kajyu[i] = avf.AverageFeature.Kajyu[i];
				thisFeature.KajyuView[i] = avf.AverageFeature.KajyuView[i];
				//System.Diagnostics.Debug.WriteLine(i.ToString() + "," + thisFeature.Kajyu[i].ToString("F4"));
			}

			thisFeature.SrcBitmap = avf.SrcBmpSmall;
			thisFeature.FileName = avf.FileName;
			
			//コマンドマネージャへ
			//CheckUpDragInCommand command = new CheckUpDragInCommand(dgv.Rows, NewRow, feature[num], thisFeature);
			//undoManager.Action(command);

			((ArrayList)features[num]).Add(thisFeature);
			
			MakeR((ArrayList)features[num]);

			IntoDataGridView(NewRow, avf.SrcBmpSmall, avf.FileName, (ArrayList)features[num], dgv.Rows.Count + 1);
			dgv.Rows.Add(NewRow);

			//dgvLegendUpDownCheck(0, "");
		}
		void DgvGroupDragDrop(object sender, DragEventArgs e)
		{
			int num = int.Parse(((DataGridView)sender).Name.Substring(8));
			num--;
			System.Diagnostics.Debug.WriteLine("Num=" + num.ToString());
			if (e.Data.GetDataPresent(typeof(CharaImageForm)))
			{
				MultiInputDialog mid = new MultiInputDialog();
				mid.ShowDialog();
				if (mid.DialogResult == DialogResult.Yes)
				{
					DragDropProc((CharaImageForm)e.Data.GetData(typeof(CharaImageForm)), (DataGridView)sender, num);
					PutRewriteR((DataGridView)DataGridViews[num], (ArrayList)features[num]);

				}
				else if (mid.DialogResult == DialogResult.No)
				{
					CharaImageForm cif;
					cif = (CharaImageForm)e.Data.GetData(typeof(CharaImageForm));
					System.Diagnostics.Debug.WriteLine("Window個数=" + mf.MdiChildren.Length.ToString());
					toolStripProgressBar1.Minimum = 0;
					toolStripProgressBar1.Maximum = mf.MdiChildren.Length;
					toolStripProgressBar1.Value = 0;
					toolStripProgressBar1.Visible = true;
					foreach (Form cdif in mf.MdiChildren)
					{
						toolStripProgressBar1.Value += 1;
						if (cdif.Name == "CharaImageForm")
						{
							if (cif.Left == cdif.Left)
							{
								CharaImageForm m_cif;
								m_cif = (CharaImageForm)cdif;
								System.Diagnostics.Debug.WriteLine($"個別文字[{m_cif.Text}]");
								System.Diagnostics.Debug.WriteLine($"色：{m_cif.dispColor}");
								((Panel)colorPanels[num]).BackColor = m_cif.dispColor;
								DragDropProc(m_cif, (DataGridView)sender, num);

								//DataGridView用のデータを作成
								//DataGridViewRow NewRow = new DataGridViewRow();
								//NewRow.CreateCells(((DataGridView)sender));
								//IntoDataGridView(NewRow, m_cif.ImageData.ProcImage, m_cif.ImageData.Filename);
								//コマンドを実行
								//LapDragInCommand command = new LapDragInCommand(((DataGridView)sender).Rows, NewRow, ImageArray, m_cif.ImageData);
								//undoManager.Action(command);

								CheckUndoRedo();

								System.Diagnostics.Debug.WriteLine(m_cif.Text);


							}
						}
					}
					MakeViewBitmap();
					LapImageBox.Invalidate();
					MakeGraph();
					GraphImage.Invalidate();
					PutRewriteR((DataGridView)DataGridViews[num], (ArrayList)features[num]);
					toolStripProgressBar1.Value = 0;
					toolStripProgressBar1.Visible = false;
					/***
					foreach (WindowSort s in winList)
					{
						CharaImageForm m_cif;
						m_cif = (CharaImageForm)mf.MdiChildren[s.ID];
						//System.Diagnostics.Debug.WriteLine("WindowName = " + m_cif.Text);
						if (!CheckLapList(m_cif.ImageData.Filename))
						{
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
					***/


				}
			}
			if (e.Data.GetDataPresent(typeof(AverageMaker)))
			{
				DragDropAverage((AverageMaker)e.Data.GetData(typeof(AverageMaker)), (DataGridView)sender, num);
			}
		}

		void DgvGroupDragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(CharaImageForm)) || e.Data.GetDataPresent(typeof(AverageMaker)))
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}

		}
		//////////////////////////////////////////////////////////////////////////////////////////////////

		//windowの順番を並び替え
		static int CompareWindow(WindowSort x, WindowSort y) {
			if (x.X > y.X) return 1;
			else if (x.X < y.X) return -1;
			else {
				//キーが同じだったら
				if (x.Y > y.Y) return 1;
				else if (x.Y < y.Y) return -1;
				else return 0;
			}
		}

		void LapFormDragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(CharaImageForm))) {
				e.Effect = DragDropEffects.Copy;
			} else {
				e.Effect = DragDropEffects.None;
			}
		}

		bool CheckLapList(string file_name)
		{
			bool res = false;

			foreach (ImageDataClass idc in ImageArray) {
				System.Diagnostics.Debug.WriteLine("ファイル名比較：LapList[" + idc.Filename + "]⇔inData[" + file_name + "]");
				if (idc.Filename == file_name) {
					res = true;
					break;
				}
			}
			return (res);
		}

		#region 矩形を描画
		void DrawFrame(Bitmap bmp, ImageDataClass idc)
		{
			foreach (FrameDataClass fdc in idc.FrameData) {
				imageEffect.DrawFrameAtColor(bmp, fdc.Frame, fdc.FrameColor);
			}
		}
		#endregion

		#region 重心線を描画
		void DrawGravityLine(Bitmap bmp, ImageDataClass idc)
		{
			Point BeforeP = new Point(0, 0);
			int i = 0;

			foreach (FrameDataClass fdc in idc.FrameData) {
				if (btnGraviHou.Checked == true || btnGraviJun.Checked == true) {
					imageEffect.DrawFrameGravityPoint(bmp, fdc.Gravity, idc.GravityColor);
				}
				if (btnGraviHou.Checked == true) {
					imageEffect.DrawFrameGravityLine(bmp, fdc.Gravity, idc.AllGravity, idc.GravityColor);
				}
				if (btnGraviJun.Checked == true && i > 0) {
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
			foreach (FrameDataClass fdc in idc.FrameData) {
				imageEffect.DrawProjection(fdc.Bmp, bmp, fdc.FrameColor);
			}
		}
		#endregion

		#region Viewの作成（実際の重ね合わせ）
		public void MakeViewBitmap()
		{
			//LapClass lc = new LapClass();
			Bitmap white_image = new Bitmap(320, 320);
			Bitmap srcimg = new Bitmap(320, 320);

			imageEffect.BitmapWhitening(viewBitmap);

			for(int j=0; j<GroupNum; j++)
            {
				for(int i=0; i < ((ArrayList)ImageArray[j]).Count; i++)
                {

					ImageDataClass idc = (ImageDataClass)((ArrayList)ImageArray[j])[i];
                    if (btnChara.Checked)
                    {
                        if (btnProc.Checked)
                        {
							imageEffect.BitmapImposeCopy(viewBitmap, idc.ProcImage);
						}
						else
						{
							imageEffect.BitmapWhitening(srcimg);
							imageEffect.BitmapStretchCopy(idc.SrcImageSmall, srcimg);
							imageEffect.DotChange(srcimg, idc.DispColor);
							imageEffect.BitmapImposeCopy(viewBitmap, srcimg);
						}
					}
					if (btnDrawFrame.Checked) DrawFrame(viewBitmap, idc);
					if (btnGraviHou.Checked || btnGraviJun.Checked) DrawGravityLine(viewBitmap, idc);
					if (btnSyaei.Checked) DrawProjection(viewBitmap, idc);

				}
            }
			
			/**
			for (int i = ImageArray.Count - 1; i >= 0; i--) {
				idc = (ImageDataClass)ImageArray[i];
				//2021.09.25 D.Honjyou
				//原画像重ね合わせテスト
				//if(btnChara.Checked) imageEffect.BitmapImposeCopy(viewBitmap, idc.ProcImage);
				if (btnChara.Checked)
				{
					if (btnProc.Checked)
					{
						imageEffect.BitmapImposeCopy(viewBitmap, idc.ProcImage);
					}
					else
					{
						imageEffect.BitmapWhitening(srcimg);
						imageEffect.BitmapStretchCopy(idc.SrcImageSmall, srcimg);
						imageEffect.DotChange(srcimg, idc.DispColor);
						imageEffect.BitmapImposeCopy(viewBitmap, srcimg);
					}
				}

				//imageEffect.BitmapImposeCopy((Bitmap)dgvLap[0, i].Value, idc.ProcImage);
				//dgvLap[1, i].Value = Path.GetFileName(idc.Filename);
				if (btnDrawFrame.Checked) DrawFrame(viewBitmap, idc);
				if (btnGraviHou.Checked || btnGraviJun.Checked) DrawGravityLine(viewBitmap, idc);
				if (btnSyaei.Checked) DrawProjection(viewBitmap, idc);
			}
			**/
		}
		#endregion

		#region DataGridViewへの追加データを作成
		void IntoDataGridView(DataGridViewRow dgvRow, Bitmap bmp, string FileName, ArrayList fcs, int num)
		{
			Bitmap inBmp = new Bitmap(bmp.Width, bmp.Height);
			imageEffect.BitmapWhitening(inBmp);
			imageEffect.BitmapCopy(bmp, inBmp);
			dgvRow.Height = 80;
			dgvRow.Cells[0].Value = num.ToString();
			dgvRow.Cells[1].Value = inBmp;
			dgvRow.Cells[2].Value = Path.GetFileName(FileName);
			dgvRow.Cells[3].Value = ((FeatureClass)fcs[num-1]).R;
			dgvRow.Cells[4].Value = ((FeatureClass)fcs[num-1]).Ratio;

		}
		#endregion

		#region 枠の描画
		private void DrawWaku(Bitmap bmp)
		{
			//MainForm mf = new MainForm();
			//mf = (MainForm)this.MdiParent;

			if (mf.Setup.EightLineVisible) imageEffect.Draw8x8Line(bmp, mf.Setup.EightLineColor);
			if (mf.Setup.CenterLineVisible) imageEffect.DrawCenterLine(bmp, mf.Setup.CenterLineColor);
		}
		#endregion

		#region イメージボックスのペイント処理
		void LapImageBoxPaint(object sender, PaintEventArgs e)
		{
			DrawWaku(viewBitmap);
			Size a = new Size();

			wideBitmap = new Bitmap((int)((double)viewBitmap.Width * zoom[comboZoom.SelectedIndex]), (int)((double)viewBitmap.Height * zoom[comboZoom.SelectedIndex]));
			a.Width = wideBitmap.Width;
			a.Height = wideBitmap.Height;
			LapImageBox.Size = a;
			imageEffect.BitmapStretchCopy(viewBitmap, wideBitmap);
			e.Graphics.DrawImage(wideBitmap, 0, 0);
		}
		#endregion

		#region DataGridViewを削除する
		void DeleteControl()
		{
			if (GroupNum < 1) return;
			int i, j;

			for (i = GroupNum - 1; i >= 0; i--)
			{
				if (((CheckBox)chkDeletes[i]).Checked == true)
				{
					//MessageBox.Show( i.ToString() );
					for (j = GroupNum - 1; j > i; j--)
					{
						//そこから後ろのchk,lbl,txt,dgvを左に移動
						((CheckBox)chkDeletes[j]).Location = ((CheckBox)chkDeletes[j - 1]).Location;
						((Label)lblCharas[j]).Location = ((Label)lblCharas[j - 1]).Location;
						((Panel)colorPanels[j]).Location = ((Panel)colorPanels[j - 1]).Location;
						((DataGridView)DataGridViews[j]).Location = ((DataGridView)DataGridViews[j - 1]).Location;
						//Name,Textをひとつずつ右のものに変更
						((CheckBox)chkDeletes[j]).Name = ((CheckBox)chkDeletes[j - 1]).Name;
						((Label)lblCharas[j]).Name = ((Label)lblCharas[j - 1]).Name;
						((Label)lblCharas[j]).Text = ((Label)lblCharas[j - 1]).Text;
						((Panel)colorPanels[j]).Name = ((Panel)colorPanels[j - 1]).Name;
						((DataGridView)DataGridViews[j]).Name = ((DataGridView)DataGridViews[j - 1]).Name;

					}
					//もともとの位置のchk,lbl,txt,dgvを削除
					((CheckBox)chkDeletes[i]).Dispose();
					chkDeletes.RemoveAt(i);
					((Label)lblCharas[i]).Dispose();
					lblCharas.RemoveAt(i);
					((Panel)colorPanels[i]).Dispose();
					colorPanels.RemoveAt(i);
					((DataGridView)DataGridViews[i]).Dispose();
					DataGridViews.RemoveAt(i);
					//特徴データを削除
					features.RemoveAt(i);
					ImageArray.RemoveAt(i);

					//ボタン類を削除
					((Button)btnUps[btnUps.Count - 1]).Dispose();
					btnUps.RemoveAt(btnUps.Count - 1);
					((Button)btnDowns[btnDowns.Count - 1]).Dispose();
					btnDowns.RemoveAt(btnDowns.Count - 1);
					((Button)btnDeletes[btnDeletes.Count - 1]).Dispose();
					btnDeletes.RemoveAt(btnDeletes.Count - 1);
					if (btnLefts.Count > 0)
					{
						((Button)btnLefts[btnLefts.Count - 1]).Dispose();
						btnLefts.RemoveAt(btnLefts.Count - 1);
					}
					//((Button)btnRights[btnRights.Count - 1]).Dispose();
					//btnRights.RemoveAt(btnRights.Count - 1);

					GroupNum--;
				}
			}

			MakeViewBitmap();
			LapImageBox.Invalidate();
			MakeGraph();
			GraphImage.Invalidate();
		}
		#endregion

		#region ひとつ上へボタン処理
		void UpDownButtonProc(DataGridView dgv, ArrayList feature, int CurrentIndex, int NextIndex)
		{
			//DataGridViewを入れ替え
			string _filename;
			Bitmap _bmp;
			string _r;
			string _ratio;

			_bmp = (Bitmap)dgv.Rows[CurrentIndex].Cells[1].Value;
			_filename = dgv.Rows[CurrentIndex].Cells[2].Value.ToString();
			_r = dgv.Rows[CurrentIndex].Cells[3].Value.ToString();
			_ratio = dgv.Rows[CurrentIndex].Cells[4].Value.ToString();

			dgv.Rows[CurrentIndex].Cells[1].Value = dgv.Rows[NextIndex].Cells[1].Value;
			dgv.Rows[CurrentIndex].Cells[2].Value = dgv.Rows[NextIndex].Cells[2].Value;
			dgv.Rows[CurrentIndex].Cells[3].Value = dgv.Rows[NextIndex].Cells[3].Value;
			dgv.Rows[CurrentIndex].Cells[4].Value = dgv.Rows[NextIndex].Cells[4].Value;

			dgv.Rows[NextIndex].Cells[1].Value = _bmp;
			dgv.Rows[NextIndex].Cells[2].Value = _filename;
			dgv.Rows[NextIndex].Cells[3].Value = _r;
			dgv.Rows[NextIndex].Cells[4].Value = _ratio;

			dgv.CurrentCell = dgv[0, NextIndex];
			//featuresを入れ替え
			FeatureClass fc = new FeatureClass();
			fc = (FeatureClass)feature[CurrentIndex];
			feature[CurrentIndex] = feature[NextIndex];
			feature[NextIndex] = fc;
		}
		#endregion

		#region ひとつ上へボタン
		//2021.09.19 D.Honjyou
		//重ね合わせグラフのため削除
		void BtnUpClick(object sender, EventArgs e)
		{
			int num = int.Parse(((Button)sender).Name.Substring(5));
			num = num - 1;
			if (((DataGridView)DataGridViews[num]).CurrentRow != null) {
				if (((DataGridView)DataGridViews[num]).CurrentRow.Index > 0) {
					UpDownButtonProc((DataGridView)DataGridViews[num], (ArrayList)features[num], ((DataGridView)DataGridViews[num]).CurrentRow.Index, ((DataGridView)DataGridViews[num]).CurrentRow.Index - 1);
				}
			}
			/**
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
			**/
		}

		#endregion

		#region ひとつ下へボタン
		//2021.09.19 D.Honjyou
		//重ね合わせグラフのため削除
		void BtnDownClick(object sender, EventArgs e)
		{
			int num = int.Parse(((Button)sender).Name.Substring(7));
			num = num - 1;
			if (((DataGridView)DataGridViews[num]).CurrentRow != null) {
				if (((DataGridView)DataGridViews[num]).CurrentRow.Index < ((DataGridView)DataGridViews[num]).Rows.Count - 1) {
					UpDownButtonProc((DataGridView)DataGridViews[num], (ArrayList)features[num], ((DataGridView)DataGridViews[num]).CurrentRow.Index, ((DataGridView)DataGridViews[num]).CurrentRow.Index + 1);
				}
			}

			/**
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
			**/
		}
		#endregion

		#region 削除ボタン処理
		void DeleteButtonProc(DataGridView dgv, ArrayList feature, ArrayList images, int CurrentIndex)
		{
			//DataGridViewを削除
			dgv.Rows.RemoveAt(CurrentIndex);
			//featureを削除
			feature.RemoveAt(CurrentIndex);
			//2021.10.31 ImageArrayを削除
			images.RemoveAt(CurrentIndex);
			//類似度作り直し
			MakeR(feature);
			//dgvLegendUpDownCheck(0, "");
		}
		#endregion

		#region 削除ボタン
		//2021.09.19 D.Honjyou
		//重ね合わせグラフのため削除
		void BtnDeleteClick(object sender, EventArgs e)
		{
			int num = int.Parse(((Button)sender).Name.Substring(9));
			num = num - 1;
			if (((DataGridView)DataGridViews[num]).CurrentRow != null)
			{
				DeleteButtonProc((DataGridView)DataGridViews[num], (ArrayList)features[num], (ArrayList)ImageArray[num], ((DataGridView)DataGridViews[num]).CurrentRow.Index);
			}
			/**
			if (dgvLap.Rows.Count > 0){
				LapDeleteCommand command = new LapDeleteCommand(dgvLap.Rows, ImageArray, dgvLap.CurrentRow.Index);
				undoManager.Action(command);
				CheckUndoRedo();
				//ImageArray.RemoveAt(dgvLap.CurrentRow.Index);
				//dgvLap.Rows.RemoveAt(dgvLap.CurrentRow.Index);
				MakeViewBitmap();
				LapImageBox.Invalidate();
			}
			**/
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

		#region ズームボタン
		void BtnZoomClick(object sender, EventArgs e)
		{
			MenuZoomClick(sender, e);
		}
		#endregion

		#region ズームコンボボックス
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

		#region 画像処理・原画像の切り替えボタンが押されたとき
		private void btnProc_CheckedChanged(object sender, EventArgs e)
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
			if (fileName == "" || fileName == null) return;
			FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
			BinaryFormatter bf = new BinaryFormatter();

			bf.Serialize(fs, ImageArray);
			bf.Serialize(fs, Features);

			fs.Close();

			//最近使ったファイルに追加してもらう
			//MainForm mf = (MainForm)this.MdiParent;
			mf.AddRecentlyFile(fileName);
		}
		#endregion

		#region 読み込み処理
		public void OpenCCLFile()
		{
			if (fileName == "" || fileName == null) return;
			//個人内変動ファイルを開く
			FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
			BinaryFormatter bf = new BinaryFormatter();

			ImageArray.Clear();
			features.Clear();

			ImageArray = (ArrayList)bf.Deserialize(fs);
			features = (ArrayList)bf.Deserialize(fs);

			fs.Close();
			fs.Dispose();

			
			//2021.10.26 D.Honjyou
			//重ね合せのDataGridViewを一旦削除
			for (int i = GroupNum - 1; i >= 0; i--)
			{
				//もともとの位置のchk,lbl,txt,dgvを削除
				((CheckBox)chkDeletes[i]).Dispose();
				chkDeletes.RemoveAt(i);
				((Label)lblCharas[i]).Dispose();
				lblCharas.RemoveAt(i);
				((Panel)colorPanels[i]).Dispose();
				colorPanels.RemoveAt(i);
				((DataGridView)DataGridViews[i]).Dispose();
				DataGridViews.RemoveAt(i);
				
				//ボタン類を削除
				((Button)btnUps[i]).Dispose();
				btnUps.RemoveAt(i);
				((Button)btnDowns[i]).Dispose();
				btnDowns.RemoveAt(i);
				((Button)btnDeletes[i]).Dispose();
				btnDeletes.RemoveAt(i);
				
				//((Button)btnRights[btnRights.Count - 1]).Dispose();
				//btnRights.RemoveAt(btnRights.Count - 1);

				GroupNum--;
			}
			
			GroupNum = 0;
			System.Diagnostics.Debug.WriteLine($"FeaturesNum={features.Count} ImageArrayNum={ImageArray.Count}");
			for(int i = 0; i < features.Count; i++)
            {
				System.Diagnostics.Debug.WriteLine($"AddControl {i}, featuresCount={((ArrayList)features[i]).Count} ImageArrayCount={((ArrayList)ImageArray[i]).Count}");
				AddControl();
				int n = 1;

				//DataGridView用のデータを作成
				foreach (FeatureClass fc in (ArrayList)features[i])
				{
					System.Diagnostics.Debug.WriteLine($"AddRow Group={i}, num={n}");
					DataGridViewRow NewRow = new DataGridViewRow();
					NewRow.CreateCells((DataGridView)DataGridViews[i]);
					IntoDataGridView(NewRow, ((ImageDataClass)((ArrayList)ImageArray[i])[n-1]).ProcImage, Path.GetFileName(fc.FileName), (ArrayList)features[i], n);
					((DataGridView)DataGridViews[i]).Rows.Add(NewRow);
					((Panel)colorPanels[i]).BackColor = fc.ViewColor;
					
					n++;
				}

			}

			MakeViewBitmap();
			LapImageBox.Invalidate();
			MakeGraph();
			GraphImage.Invalidate();
			/****
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
			****/
		}
		#endregion

		#region グラフ作成
		void MakeYAxis(IGraphPainter graph)
		{
			IAxis axis;
			double Min = 0.0;
			double MinorInterval, MajorInterval;
			double ScaleMin;
			Min = GetAllMinimun();
			if (Min >= 0.95)
			{
				MajorInterval = 0.02;
				MinorInterval = 0.01;
			}
			else if (Min >= 0.9)
			{
				MajorInterval = 0.025;
				MinorInterval = 0.025;
			}
			else
			{
				MajorInterval = 0.05;
				MinorInterval = 0.05;
			}
			ScaleMin = Math.Floor(Min / MinorInterval) * MinorInterval;
			axis = graph.YAxis;
			
			axis.Scale.Min = ScaleMin;
			axis.Scale.Max = 1.001;
			axis.Scale.Base = ScaleMin;
			axis.Ticks.Labels.LabelFormat = "0.00";
			axis.Ticks.Labels.Interval = 1;
			axis.Ticks.Major.LineLength = 8;
			axis.Ticks.Major.Pen = Pens.Black;
			axis.Ticks.Major.Interval = MajorInterval;
			axis.Ticks.Minor.Visible = true;
			axis.Ticks.Minor.Interval = MinorInterval;
			axis.Grid.Major.Visible = true;
			axis.Grid.Major.Interval = MajorInterval;
			axis.Grid.Minor.Visible = true;
			axis.Grid.Minor.Interval = MinorInterval;

		}

		
		void MakeXAxis(IGraphPainter graph)
		{
			int XScale;
			XScale = 1;//_referene.Charas.Count;

			ST_TickLabelPoint[] labelPoints = new ST_TickLabelPoint[XScale];
			int j = 0;

			//foreach (RRangeClass rc in _referene.Charas)
			//{
			//	labelPoints[j] = new ST_TickLabelPoint(j, rc.Title);
			//	j++;
			//}
			labelPoints[0] = new ST_TickLabelPoint(0, "変動");
			IAxis axis;

			axis = graph.XAxis;
			axis.Ticks.Labels.LabelFormat = "0";
			axis.Ticks.Labels.Interval = 1;
			axis.Ticks.Major.Interval = 1;
			axis.Ticks.Side = DusGraph.eTickSide.Bottom;
            axis.Ticks.Labels.Points.AddRange(labelPoints);
			axis.Ticks.Labels.Font = new Font("ＭＳ 明朝", 14, FontStyle.Bold);
			axis.Ticks.Direction        = DusGraph.eTickDirection.Outside;
			axis.Grid.Major.Visible = false;
			axis.Grid.Major.Interval = 1;
			axis.Scale.Min = 0;
			axis.Scale.Max = XScale;
			axis.Scale.Base = 0;

		}

		static double [] GetFeatureMaxMinAve(ArrayList fet)
        {
			double max, min, ave, sum;
			double [] arr = new double [3];
			int i = 0;

			max = 0.0;
			min = 3.0;
			sum = 0.0;

			foreach (FeatureClass f in fet)
			{
				if (max < f.R) max = f.R;
				if (min > f.R) min = f.R;
				sum += f.R;
				i++;
				System.Diagnostics.Debug.WriteLine($"maxminave R = {f.R} R2 = {f.R2}");
			}
			ave = sum / i;

			arr[0] = max;
			arr[1] = min;
			arr[2] = ave;

			return (arr);
		}

		private double GetAllMinimun()
		{
			int j;
			double min = 100.0;
			for (j = 0; j < GroupNum; j++)
			{
				foreach (FeatureClass fcd in (ArrayList)features[j])
				{
					if (fcd.R < min) min = fcd.R;
				}
			}
			return (min);
		}

		void MakePlotData(IGraphPainter graph)
		{
			///2021.09.15　ここです！！！！
			System.Diagnostics.Debug.WriteLine($"GroupNum = {GroupNum}");
			for(int i=0; i<GroupNum; i++)
            {
				if(((ArrayList)features[i]).Count > 0) 
				{
					ISeriesCandleChart series;
					double[] MaxMinAve = GetFeatureMaxMinAve((ArrayList)features[i]);
					series = graph.CreateSeries(DusGraph.ePlotType.CandleChart).asCandleChart;
					series.NegativeBrush = new SolidBrush(Color.FromArgb(128, ((Panel)colorPanels[i]).BackColor));
					series.PositiveBrush = new SolidBrush(Color.FromArgb(128, ((Panel)colorPanels[i]).BackColor));
					series.BarWidth = 30;
					series.Pen = new Pen(Color.FromArgb(128, ((Panel)colorPanels[i]).BackColor));

					series.Data.Add(new ST_CandlePoint(0, MaxMinAve[1], MaxMinAve[0], MaxMinAve[1], MaxMinAve[1]));
					graph.Series.Add(series);

					System.Diagnostics.Debug.WriteLine($"max = {MaxMinAve[0]} min = {MaxMinAve[1]} ave = {MaxMinAve[2]}");

				}

			}
		}

		// 2021.10.24 D.Honjyou
		// 縦横比グラフ用のグラフ作成を追加
		void MakeYAxis2(IGraphPainter graph)
		{
			IAxis axis;
			double MinorInterval, MajorInterval;
			double[] MaxMinAve = GetAllRatioMaxMinAve(features);
			if (MaxMinAve[1] >= 0.95)
			{
				MajorInterval = 0.02;
				MinorInterval = 0.01;
			}
			else if (MaxMinAve[1] >= 0.9)
			{
				MajorInterval = 0.025;
				MinorInterval = 0.025;
			}
			else
			{
				MajorInterval = 0.05;
				MinorInterval = 0.05;
			}
			
			axis = graph.YAxis;
			axis.Scale.Min = MaxMinAve[1] - 0.1;
			axis.Scale.Max = MaxMinAve[0] + 0.1;
			//axis.Scale.Base = MaxMinAve[1];
			axis.Ticks.Labels.LabelFormat = "0.00";
			axis.Ticks.Labels.Interval = 1;
			axis.Ticks.Major.LineLength = 8;
			axis.Ticks.Major.Pen = Pens.Black;
			axis.Ticks.Major.Interval = MajorInterval;
			axis.Ticks.Minor.Visible = true;
			axis.Ticks.Minor.Interval = MinorInterval;
			axis.Grid.Major.Visible = true;
			axis.Grid.Major.Interval = MajorInterval;
			axis.Grid.Minor.Visible = true;
			axis.Grid.Minor.Interval = MinorInterval;

		}


		void MakeXAxis2(IGraphPainter graph)
		{
			int XScale;
			XScale = 1;//_referene.Charas.Count;

			ST_TickLabelPoint[] labelPoints = new ST_TickLabelPoint[XScale];
			int j = 0;

			//foreach (RRangeClass rc in _referene.Charas)
			//{
			//	labelPoints[j] = new ST_TickLabelPoint(j, rc.Title);
			//	j++;
			//}
			labelPoints[0] = new ST_TickLabelPoint(0, "縦横比");
			IAxis axis;

			axis = graph.XAxis;
			axis.Ticks.Labels.LabelFormat = "0";
			axis.Ticks.Labels.Interval = 1;
			axis.Ticks.Major.Interval = 1;
			axis.Ticks.Side = DusGraph.eTickSide.Bottom;
			axis.Ticks.Labels.Points.AddRange(labelPoints);
			axis.Ticks.Labels.Font = new Font("ＭＳ 明朝", 14, FontStyle.Bold);
			axis.Ticks.Direction = DusGraph.eTickDirection.Outside;
			axis.Grid.Major.Visible = false;
			axis.Grid.Major.Interval = 1;
			axis.Scale.Min = 0;
			axis.Scale.Max = XScale;
			axis.Scale.Base = 0;

		}

		static double[] GetRatioMaxMinAve(ArrayList fet)
		{
			double max, min, ave, sum;
			double[] arr = new double[3];
			int i = 0;

			max = 0.0;
			min = 9999.0;
			sum = 0.0;

			foreach (FeatureClass f in fet)
			{
				
				if (max < f.Ratio) max = f.Ratio;
				if (min > f.Ratio) min = f.Ratio;
				sum += f.Ratio;
				i++;
				System.Diagnostics.Debug.WriteLine($"maxminave Ratio = {f.Ratio}");
			}
			ave = sum / i;

			arr[0] = max;
			arr[1] = min;
			arr[2] = ave;

			return (arr);
		}

		private double[] GetAllRatioMaxMinAve(ArrayList fet)
		{
			double max, min, ave, sum;
			double[] arr = new double[3];
			int i = 0;

			max = 0.0;
			min = 9999.0;
			sum = 0.0;
			
			int j;
			for (j = 0; j < GroupNum; j++)
			{
				foreach (FeatureClass fcd in (ArrayList)fet[j])
				{
					if (max < fcd.Ratio) max = fcd.Ratio;
					if (min > fcd.Ratio) min = fcd.Ratio;
					sum += fcd.Ratio;
					i++;
					System.Diagnostics.Debug.WriteLine($"縦横比 Ratio = {fcd.Ratio} ({fcd.SrcBitmap.Width}/{fcd.SrcBitmap.Height}");

				}
			}

			ave = sum / i;

			arr[0] = max;
			arr[1] = min;
			arr[2] = ave;

			return (arr);
		}

		void MakePlotData2(IGraphPainter graph)
		{
			///2021.09.15　ここです！！！！
			System.Diagnostics.Debug.WriteLine($"GroupNum = {GroupNum}");
			for (int i = 0; i < GroupNum; i++)
			{
				if (((ArrayList)features[i]).Count > 0)
				{
					ISeriesCandleChart series;
					double[] MaxMinAve = GetRatioMaxMinAve((ArrayList)features[i]);
					series = graph.CreateSeries(DusGraph.ePlotType.CandleChart).asCandleChart;
					series.NegativeBrush = new SolidBrush(Color.FromArgb(128, ((Panel)colorPanels[i]).BackColor));
					series.PositiveBrush = new SolidBrush(Color.FromArgb(128, ((Panel)colorPanels[i]).BackColor));
					series.BarWidth = 30;
					series.Pen = new Pen(Color.FromArgb(128, ((Panel)colorPanels[i]).BackColor));

					series.Data.Add(new ST_CandlePoint(0, MaxMinAve[1], MaxMinAve[0], MaxMinAve[1], MaxMinAve[1]));
					graph.Series.Add(series);

					System.Diagnostics.Debug.WriteLine($"max = {MaxMinAve[0]} min = {MaxMinAve[1]} ave = {MaxMinAve[2]}");

				}

			}

		}

        void MakeGraph()
		{
			imageEffect.BitmapWhitening(GraphBmp);
			
			IGraphPainter graph = DusGraph.CreateGraph(113, 400);

			#region グラフエリアの設定
			graph.SmoothingMode = SmoothingMode.AntiAlias;
			graph.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
			graph.BackBrush = new LinearGradientBrush(graph.GetBounds(), Color.White, Color.LemonChiffon, LinearGradientMode.Vertical);
			graph.Border.Pen = new Pen(Color.Gray, 1);
			graph.PlotArea.BackBrush = new LinearGradientBrush(graph.GetBounds(), Color.LightBlue, Color.White, LinearGradientMode.Vertical);
			graph.PlotArea.Border.Top.Pen = Pens.Transparent;
			graph.PlotArea.Border.Right.Pen = Pens.Silver;
			graph.PlotArea.Margin.Left = 40;
			graph.PlotArea.Margin.Right = 0;
			graph.PlotArea.Margin.Top = 0;
			graph.PlotArea.Margin.Bottom = 0;
			graph.PlotArea.InnerMargin.Left = 40;
			graph.PlotArea.InnerMargin.Right = 40;
			#endregion

			#region 凡例の設定
			/***
			graph.Legend.Visible = true;
			graph.Legend.Location = new PointF(415, 40);
			graph.Legend.Size = new SizeF(150, 300);
			graph.Legend.ItemArea.BaseLocation = new PointF(5, 20);
			graph.Legend.ItemArea.ItemSize = new SizeF(140, 20);
			***/
			#endregion
			MakeXAxis(graph);
			MakeYAxis(graph);
			MakePlotData(graph);
			graph.Draw();
			//Graphics  g = graph.CreateGraphics();
			Graphics g = Graphics.FromImage(GraphBmp);
			g.FillRectangle(Brushes.White, 0, 0, GraphBmp.Width, GraphBmp.Height);
			g.DrawImage(graph.Image, 0, 0);

			g.Dispose();

			imageEffect.BitmapWhitening(GraphBmp2);

			IGraphPainter graph2 = DusGraph.CreateGraph(113, 400);

			#region グラフエリアの設定
			graph2.SmoothingMode = SmoothingMode.AntiAlias;
			graph2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
			graph2.BackBrush = new LinearGradientBrush(graph2.GetBounds(), Color.White, Color.LemonChiffon, LinearGradientMode.Vertical);
			graph2.Border.Pen = new Pen(Color.Gray, 1);
			graph2.PlotArea.BackBrush = new LinearGradientBrush(graph2.GetBounds(), Color.LightBlue, Color.White, LinearGradientMode.Vertical);
			graph2.PlotArea.Border.Top.Pen = Pens.Transparent;
			graph2.PlotArea.Border.Right.Pen = Pens.Silver;
			graph2.PlotArea.Margin.Left = 40;
			graph2.PlotArea.Margin.Right = 0;
			graph2.PlotArea.Margin.Top = 0;
			graph2.PlotArea.Margin.Bottom = 0;
			graph2.PlotArea.InnerMargin.Left = 40;
			graph2.PlotArea.InnerMargin.Right = 40;
			#endregion

			#region 凡例の設定
			/***
			graph.Legend.Visible = true;
			graph.Legend.Location = new PointF(415, 40);
			graph.Legend.Size = new SizeF(150, 300);
			graph.Legend.ItemArea.BaseLocation = new PointF(5, 20);
			graph.Legend.ItemArea.ItemSize = new SizeF(140, 20);
			***/
			#endregion
			MakeXAxis2(graph2);
			MakeYAxis2(graph2);
			MakePlotData2(graph2);
			graph2.Draw();
			g = graph.CreateGraphics();
			g = Graphics.FromImage(GraphBmp2);
			g.FillRectangle(Brushes.White, 0, 0, GraphBmp2.Width, GraphBmp2.Height);
			g.DrawImage(graph2.Image, 0, 0);

			g.Dispose();
			GraphImage.Invalidate();
			GraphImage2.Invalidate();
		}
		#endregion

		#region GraphImageBoxのペイント処理
		void GraphImagePaint(object sender, PaintEventArgs e)
		{
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImage(GraphBmp, 0, 0, GraphImage.Width, GraphImage.Height);
		}

		private void GraphImage2_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImage(GraphBmp2, 0, 0, GraphImage2.Width, GraphImage2.Height);
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

        private void dgvAddBtnClick(object sender, EventArgs e)
        {
			AddControl();
			features.Add(new ArrayList());
			ImageArray.Add(new ArrayList());

			MakeViewBitmap();
			LapImageBox.Invalidate();
			MakeGraph();
			GraphImage.Invalidate();
		}

        private void dgvDelBtnClick(object sender, EventArgs e)
        {
			DeleteControl();

			MakeViewBitmap();
			LapImageBox.Invalidate();
			MakeGraph();
			GraphImage.Invalidate();
		}
    }
}
