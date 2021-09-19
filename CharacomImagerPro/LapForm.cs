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
		double [] zoom = {4.0, 3.0, 2.0, 1.5, 1.0, 0.5};
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
			AddControl();
			

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

			DataGridView dgv = new DataGridView();
			dgv.AllowDrop = true;
			dgv.AllowUserToAddRows = false;
			dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv.Columns.AddRange(new DataGridViewColumn[] {
									Nos,
									Images,
									Addresses,
									Checks});
			dgv.Location = new Point(3 + GroupNum * 230 - panel1.HorizontalScroll.Value, 23 - panel1.VerticalScroll.Value);
			dgv.Name = "dgvGroup" + (GroupNum + 1).ToString();
			dgv.RowHeadersVisible = false;
			dgv.RowTemplate.Height = 80;
			dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgv.Size = new Size(225, panel1.Height - 80);
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
			chkDelete.Location = new Point(30 + GroupNum * 230 - panel1.HorizontalScroll.Value, 2 - panel1.VerticalScroll.Value);
			chkDeletes.Add(chkDelete);
			panel2.Controls.Add(chkDelete);
			#endregion

			#region 表示色を追加する
			Label label = new Label();
			label.Text = "選択色" + (GroupNum + 1).ToString();
			label.Name = "lblChara" + (GroupNum + 1).ToString();
			label.Size = new Size(51, 13);
			label.Location = new Point(68 + GroupNum * 230 - panel1.HorizontalScroll.Value, 5 - panel1.VerticalScroll.Value);
			lblCharas.Add(label);
			panel2.Controls.Add(label);

			Panel panel = new Panel();
			panel.Name = "colorPanel" + (GroupNum + 1).ToString();
			panel.Size = new Size(50, 19);
			panel.Location = new Point(125 + GroupNum * 230 - panel1.HorizontalScroll.Value, 2 - panel1.VerticalScroll.Value);
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
			btnDelete.Location = new System.Drawing.Point(84 + GroupNum * 230 - panel1.HorizontalScroll.Value, panel1.Height - 50 - panel1.VerticalScroll.Value);
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
			btnDown.Location = new System.Drawing.Point(153 + GroupNum * 230 - panel1.HorizontalScroll.Value, panel1.Height - 50 - panel1.VerticalScroll.Value);
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
			btnUp.Location = new System.Drawing.Point(3 + GroupNum * 230 - panel1.HorizontalScroll.Value, panel1.Height - 50 - panel1.VerticalScroll.Value);
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
				btnLeft.Location = new System.Drawing.Point(3 + GroupNum * 230 - panel1.HorizontalScroll.Value, 2 - panel1.VerticalScroll.Value);
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
			btnRight.Location = new System.Drawing.Point(207+GroupNum*230 - panel1.HorizontalScroll.Value, 2 - panel1.VerticalScroll.Value);
			btnRight.Name = "btnRight" + (GroupNum+1).ToString();
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
			features.Add(new ArrayList());
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
		void MakeR(ArrayList feature, DataGridView dgv)
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

				if (dgv.Rows.Count > num)
				{
					dgv[0, num].Value = (num + 1).ToString();
					dgv[3, num].Value = fc.R.ToString("F4");
					//System.Diagnostics.Debug.WriteLine("R = " + fc.R.ToString("f4") + " : R2 = " + fc.R2.ToString("f4"));
				}
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
			IntoDataGridView(NewRow, cif.ImageData.ProcImage, cif.ImageData.Filename, dgv.Rows.Count + 1);
			ImageArray.Add(cif.ImageData);

			
			//特徴クラスを作成してデータを挿入
			FeatureClass thisFeature = new FeatureClass();
			imageEffect.GetKajyu(cif.SrcBitmapSmall, thisFeature.Kajyu, thisFeature.KajyuView, mf.Setup.CharaR);
			imageEffect.GetHaikei(cif.SrcBitmapSmall, thisFeature.Haikei, thisFeature.HaikeiView, mf.Setup.CharaR);

			thisFeature.SrcBitmap = cif.SrcBitmapSmall;
			thisFeature.FileName = cif.FileName;

			//コマンドマネージャへ
			//CheckUpDragInCommand command = new CheckUpDragInCommand(dgv.Rows, NewRow, feature[num], thisFeature);
			//undoManager.Action(command);
			dgv.Rows.Add(NewRow);
			
			System.Diagnostics.Debug.WriteLine(int.Parse(dgv.Name.Substring(8)).ToString());
			((ArrayList)features[num]).Add(thisFeature);
			
			System.Diagnostics.Debug.WriteLine("特徴[" + num.ToString() + "]の個数は" + ((ArrayList)features[num]).Count.ToString());
			MakeR((ArrayList)features[num], dgv);
			System.Diagnostics.Debug.WriteLine("ColorNo = " + mf.Setup.GetColorNo(cif.dispColor.Name).ToString());
			System.Diagnostics.Debug.WriteLine("Title = " + cif.Text);
			//dgvLegendUpDownCheck(mf.Setup.GetColorNo(cif.dispColor.Name), System.IO.Path.GetFileNameWithoutExtension(cif.FileName));
		}

		void DragDropAverage(AverageMaker avf, DataGridView dgv, int num)
		{
			//DataGridView用のデータを作成
			DataGridViewRow NewRow = new DataGridViewRow();
			NewRow.CreateCells(dgv);
			IntoDataGridView(NewRow, avf.SrcBmpSmall, avf.FileName, dgv.Rows.Count + 1);
			
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
			dgv.Rows.Add(NewRow);

			((ArrayList)features[num]).Add(thisFeature);

			MakeR((ArrayList)features[num], dgv);

			//dgvLegendUpDownCheck(0, "");
		}
		void DgvGroupDragDrop(object sender, DragEventArgs e)
		{
			int num = int.Parse(((DataGridView)sender).Name.Substring(8));
			num = num - 1;
			System.Diagnostics.Debug.WriteLine("Num=" + num.ToString());
			if (e.Data.GetDataPresent(typeof(CharaImageForm)))
			{
				MultiInputDialog mid = new MultiInputDialog();
				mid.ShowDialog();
				if (mid.DialogResult == DialogResult.Yes)
				{
					DragDropProc((CharaImageForm)e.Data.GetData(typeof(CharaImageForm)), (DataGridView)sender, num);
				}
				else if (mid.DialogResult == DialogResult.No)
				{
					CharaImageForm cif;
					cif = (CharaImageForm)e.Data.GetData(typeof(CharaImageForm));
					System.Diagnostics.Debug.WriteLine("Window個数="+mf.MdiChildren.Length.ToString());
					foreach (Form cdif in mf.MdiChildren)
					{
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

		//2021.09.19 D.Honjyou
		//重ね合わせグラフのため削除
		public void InputLapForm(CharaImageForm cif)
				{
					/****
					if (CheckLapList(cif.ImageData.Filename)) return;
					//DataGridView用のデータを作成
					DataGridViewRow NewRow = new DataGridViewRow();
					//NewRow.CreateCells(dgvLap);
					IntoDataGridView(NewRow, cif.ImageData.ProcImage, cif.ImageData.Filename);
						
					//コマンドを実行
					//LapDragInCommand command = new LapDragInCommand(dgvLap.Rows, NewRow, ImageArray, cif.ImageData);
					//undoManager.Action(command);
						
					CheckUndoRedo();
					AddLapArray(cif.ImageData);
					MakeViewBitmap();
						
					LapImageBox.Invalidate();
					**/
				}

		//2021.09.19 D.Honjyou
		//重ね合わせグラフのため削除
		void LapFormDragDrop(object sender, DragEventArgs e)
		{
			/**
			CharaImageForm cif;
			MultiInputDialog mid = new MultiInputDialog();
			
			mid.ShowDialog();
			if( mid.DialogResult == DialogResult.Yes ){
				if(e.Data.GetDataPresent(typeof(CharaImageForm))){
					cif = (CharaImageForm)e.Data.GetData(typeof(CharaImageForm));
					if(CheckLapList(cif.ImageData.Filename)) return;
					//DataGridView用のデータを作成
					DataGridViewRow NewRow = new DataGridViewRow();
					//NewRow.CreateCells(dgvLap);
					IntoDataGridView(NewRow, cif.ImageData.ProcImage, cif.ImageData.Filename);
					
					//コマンドを実行
					//LapDragInCommand command = new LapDragInCommand(dgvLap.Rows, NewRow, ImageArray, cif.ImageData);
					//undoManager.Action(command);
					
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
									//NewRow.CreateCells(dgvLap);
									IntoDataGridView(NewRow, m_cif.ImageData.ProcImage, m_cif.ImageData.Filename);
									
									//コマンドを実行
									//LapDragInCommand command = new LapDragInCommand(dgvLap.Rows, NewRow, ImageArray, m_cif.ImageData);
									//undoManager.Action(command);
									
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
						//NewRow.CreateCells(dgvLap);
						IntoDataGridView(NewRow, m_cif.ImageData.ProcImage, m_cif.ImageData.Filename);
						
						//コマンドを実行
						//LapDragInCommand command = new LapDragInCommand(dgvLap.Rows, NewRow, ImageArray, m_cif.ImageData);
						//undoManager.Action(command);
									
						CheckUndoRedo();
						//AddLapArray(cif.ImageData);
						MakeViewBitmap();
						System.Diagnostics.Debug.WriteLine(m_cif.Text);
					}
				}
			}
			LapImageBox.Invalidate();
			**/
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

			/**
			for(int j=0; j<GroupNum; j++)
            {
				for(int i=0; i < ((DataGridView)DataGridViews[j]).RowCount; i++)
                {

                }
				((DataGridView)DataGridViews)[1,i]
            }
			**/
			for(int i=ImageArray.Count - 1; i >=0; i--){
				idc = (ImageDataClass)ImageArray[i];
				if(btnChara.Checked) imageEffect.BitmapImposeCopy(viewBitmap, idc.ProcImage);
				//imageEffect.BitmapImposeCopy((Bitmap)dgvLap[0, i].Value, idc.ProcImage);
				//dgvLap[1, i].Value = Path.GetFileName(idc.Filename);
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
		void IntoDataGridView(DataGridViewRow dgvRow, Bitmap bmp, string FileName, int num)
		{
			Bitmap inBmp = new Bitmap(bmp.Width, bmp.Height);
			imageEffect.BitmapWhitening(inBmp);
			imageEffect.BitmapCopy(bmp, inBmp);
			dgvRow.Height = 80;
			dgvRow.Cells[0].Value = num.ToString();
			dgvRow.Cells[1].Value = inBmp;
			dgvRow.Cells[2].Value = Path.GetFileName(FileName);
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

		#region ひとつ上へボタン処理
		void UpDownButtonProc(DataGridView dgv, ArrayList feature, int CurrentIndex, int NextIndex)
		{
			//DataGridViewを入れ替え
			string _filename;
			Bitmap _bmp;
			string _r;

			_bmp = (Bitmap)dgv.Rows[CurrentIndex].Cells[1].Value;
			_filename = (string)dgv.Rows[CurrentIndex].Cells[2].Value;
			_r = (string)dgv.Rows[CurrentIndex].Cells[3].Value;

			dgv.Rows[CurrentIndex].Cells[1].Value = dgv.Rows[NextIndex].Cells[1].Value;
			dgv.Rows[CurrentIndex].Cells[2].Value = dgv.Rows[NextIndex].Cells[2].Value;
			dgv.Rows[CurrentIndex].Cells[3].Value = dgv.Rows[NextIndex].Cells[3].Value;

			dgv.Rows[NextIndex].Cells[1].Value = _bmp;
			dgv.Rows[NextIndex].Cells[2].Value = _filename;
			dgv.Rows[NextIndex].Cells[3].Value = _r;

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
			if(((DataGridView)DataGridViews[num]).CurrentRow != null){
				if(((DataGridView)DataGridViews[num]).CurrentRow.Index > 0){
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
			if(((DataGridView)DataGridViews[num]).CurrentRow != null){
				if(((DataGridView)DataGridViews[num]).CurrentRow.Index < ((DataGridView)DataGridViews[num]).Rows.Count - 1){
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
		void DeleteButtonProc(DataGridView dgv, ArrayList feature, int CurrentIndex)
		{
			//DataGridViewを削除
			dgv.Rows.RemoveAt(CurrentIndex);
			//featureを削除
			feature.RemoveAt(CurrentIndex);
			MakeR(feature, dgv);
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
				DeleteButtonProc((DataGridView)DataGridViews[num], (ArrayList)features[num], ((DataGridView)DataGridViews[num]).CurrentRow.Index);
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
			/**
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
			**/
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
			
				

			
			/**
			ISeriesCandleChart sr;      //対照資料最大最小ボックス
										//ISeriesXYPlot  sr2;		
			ISeriesCandleChart sr2; //対照資料生データプロット
			ISeriesXYPlot sr3;          //対照資料平均値プロット
			ISeriesCandleChart sr4; //対照資料平均除外生データプロット
			double max, min;
			Color c;
			Pen linePen = new Pen(Color.Blue, 2);

			//対照資料
			if (cmbReferenceColor.SelectedIndex < 0)
			{
				c = Color.Red;
			}
			else
			{
				c = setup.DisplayColor[cmbReferenceColor.SelectedIndex];
			}
			sr = graph.CreateSeries(DusGraph.ePlotType.CandleChart).asCandleChart;
			sr.NegativeBrush = new SolidBrush(Color.FromArgb(128, c));
			sr.PositiveBrush = new SolidBrush(Color.FromArgb(128, c));
			sr.BarWidth = 30;
			sr.Pen = new Pen(c);
			sr3 = graph.CreateSeries(DusGraph.ePlotType.Line).asXYPlot;
			if (chkReferenceAve.Checked)
			{
				//平均グラフを作成
				sr3.Mark.Visible = true;
				sr3.Mark.Type = DusGraph.ePlotMarkType.Star;
				sr3.Mark.Brush = new SolidBrush(c);
				sr3.Mark.Width = 8;
				sr3.Mark.Height = 8;
				sr3.Title = _referene.Title;
				//sr2.Mark.NumCorners = 8;

			}

			int i = 0;
			foreach (RRangeClass rc in _referene.Charas)
			{

				//最大最少を表示
				if (rc.MinR != 500.0 || rc.MaxR != 0.00)
				{
					min = rc.MinR;
					max = rc.MaxR;
					// new ST_CandlePoint( Ｘ値, 始値, 終値, 高値, 安値 )
					sr.Data.Add(new ST_CandlePoint(i, min, max, min, min));
				}
				sr2 = graph.CreateSeries(DusGraph.ePlotType.CandleChart).asCandleChart;
				sr2.BarWidth = 3;
				sr2.Pen = new Pen(c, 3);
				//平均グラフにプロットを挿入
				if (chkReferenceAve.Checked)
				{
					linePen = new Pen(c, 2);
					linePen.DashStyle = DashStyle.Solid;
					sr3.Mark.Border.Pen = new Pen(c, 1);
					sr3.asLine.Pen = linePen;
					sr3.Data.Add(new ST_PlotPoint(i, rc.AveR2));
				}
				foreach (double R in rc.ItemsR)
				{
					sr2.Data.Add(new ST_CandlePoint(i, R, R, R, R));
				}
				i++;
				
			}
			//if(chkReferenceRange.Checked == true) graph.Series.Add( sr );
			//if (chkReferenceAve.Checked) graph.Series.Add(sr3);

			/****
			if (chkReferenceData.Checked)
			{
				//
				// 三崎さんからの要望により、キャンドルグラフに変更 2012.06.05
				// →三崎さんからの要望により、平均除外をプロットするに変更 2013.11.04
				// 
				//R2グラフを作成
				for (i = 0; i < _referene.MaxLength; i++)
				{
					sr4 = graph.CreateSeries(DusGraph.ePlotType.CandleChart).asCandleChart;
					int j = 0;
					foreach (RRangeClass rc in _referene.Charas)
					{
						if (i < rc.ItemsR2.Count)
						{
							//sr4.Title = rc.DocumentTitles[i].ToString() + "(平均除外)";
							//c = (Color)rc.CharaColors[i];
							//sr4.Data.Add( new ST_PlotPoint(j, (double)rc.ItemsR2[i]) );
							sr4.Data.Add(new ST_CandlePoint(j, (double)rc.ItemsR2[i], (double)rc.ItemsR2[i], (double)rc.ItemsR2[i], (double)rc.ItemsR2[i]));
						}
						j++;
					}
					sr4.BarWidth = 3;
					sr4.Pen = new Pen(c, 3);

					
					graph.Series.Add(sr4);
				}
			}

			if (chkReferenceRange.Checked)
			{
				sr = graph.CreateSeries(DusGraph.ePlotType.CandleChart).asCandleChart;
				sr.NegativeBrush = new SolidBrush(Color.FromArgb(64, c));
				sr.PositiveBrush = new SolidBrush(Color.FromArgb(64, c));
				sr.BarWidth = 30;
				sr.Pen = new Pen(c);
				i = 0;
				foreach (RRangeClass rc in _referene.Charas)
				{
					if (rc.MinR2 != 500.0 || rc.MaxR2 != 0.0)
					{
						min = rc.MinR2;
						max = rc.MaxR2;
						// new ST_CandlePoint( Ｘ値, 始値, 終値, 高値, 安値 )
						sr.Data.Add(new ST_CandlePoint(i, min, max, min, min));
					}
					i++;
				}
				graph.Series.Add(sr);
			}
			//鑑定資料
			//平均のグラフ設定
			if (cmbJudgeColor.SelectedIndex < 0)
			{
				c = Color.Red;
			}
			else
			{
				c = setup.DisplayColor[cmbJudgeColor.SelectedIndex];
			}
			//if(cmbJudgeColor.Text == ""){
			//	c = Color.Blue;
			//}else{
			//	c = GetColorFromName(cmbJudgeColor.Text);
			//}
			//c = Color.DarkGoldenrod;
			if (chkJudgeAve.Checked)
			{
				sr3 = graph.CreateSeries(DusGraph.ePlotType.Line).asXYPlot;
				sr3.Mark.Visible = true;
				sr3.Mark.Type = DusGraph.ePlotMarkType.Star;
				sr3.Mark.Brush = new SolidBrush(c);
				sr3.Mark.Width = 8;
				sr3.Mark.Height = 8;
				sr3.Title = "鑑定資料平均";
				sr3.Mark.Border.Pen = new Pen(c, 1);
				linePen = new Pen(c, 2);
				linePen.DashStyle = DashStyle.Dot;
				sr3.asLine.Pen = linePen;
				//平均のグラフプロット
				i = 0;
				foreach (RRangeClass rrc in _judge.Charas)
				{
					//平均グラフにプロットを挿入
					sr3.Data.Add(new ST_PlotPoint(i, rrc.AveR));
					i++;
				}
			}
			if (chkJudgeAve.Checked) graph.Series.Add(sr3);
			//最大最小ボックスをプロット
			if (chkJudgeRange.Checked == true)
			{
				sr = graph.CreateSeries(DusGraph.ePlotType.CandleChart).asCandleChart;
				sr.NegativeBrush = new SolidBrush(Color.FromArgb(128, c));
				sr.PositiveBrush = new SolidBrush(Color.FromArgb(128, c));
				sr.BarWidth = 30;
				sr.Pen = new Pen(c);
				i = 0;
				foreach (RRangeClass rc in _judge.Charas)
				{
					if (rc.MinR != 500.0 && rc.MaxR != 0.0)
					{
						min = rc.MinR;
						max = rc.MaxR;
						// new ST_CandlePoint( Ｘ値, 始値, 終値, 高値, 安値 )
						sr.Data.Add(new ST_CandlePoint(i, min, max, min, min));
					}
					i++;
				}
				graph.Series.Add(sr);
			}

			//生データをプロット
			if (chkJudgeData.Checked)
			{
				for (i = 0; i < _judge.MaxLength; i++)
				{
					sr3 = graph.CreateSeries(DusGraph.ePlotType.Line).asXYPlot;
					foreach (RRangeClass rrc in _judge.Charas)
					{
						if (rrc.ItemsR.Count > i)
						{
							sr3.Title = (string)rrc.DocumentTitles[i];
							c = (Color)rrc.CharaColors[i];
							//System.Diagnostics.Debug.WriteLine(c.ToString());
							sr3.Mark.Brush = new SolidBrush(c);
							sr3.Mark.Border.Pen = new Pen(c, 1);
							sr3.asLine.Pen = new Pen(c, 2);
						}
					}
					sr3.Mark.Visible = true;
					sr3.Mark.Type = DusGraph.ePlotMarkType.Star;
					sr3.Mark.Brush = new SolidBrush(c);
					sr3.Mark.Width = 8;
					sr3.Mark.Height = 8;

					//sr3.Title = (string)((RRangeClass)_judge.Charas[0]).DocumentTitles[i];
					sr3.Mark.Border.Pen = new Pen(c, 1);
					sr3.asLine.Pen = new Pen(c, 2);

					int j = 0;
					foreach (RRangeClass rrc in _judge.Charas)
					{
						if (i < rrc.ItemsR.Count)
						{
							sr3.Data.Add(new ST_PlotPoint(j, (double)rrc.ItemsR[i]));
							//System.Diagnostics.Debug.WriteLine(rrc.ItemsR[i].ToString());
						}
						j++;
					}
					graph.Series.Add(sr3);
				}
			}
			***/
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
			GraphImage.Invalidate();
		}
		#endregion

		#region GraphImageBoxのペイント処理
		void GraphImagePaint(object sender, PaintEventArgs e)
		{
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImage(GraphBmp, 0, 0, GraphImage.Width, GraphImage.Height);
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
			/**
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
			**/
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
