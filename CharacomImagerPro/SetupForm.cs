/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2011/11/29
 * 時刻: 12:05
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace CharacomImagerPro
{
	/// <summary>
	/// Description of SetupForm.
	/// </summary>
	public partial class SetupForm : Form
	{
		//Color [] rowDataColor = {Color.AliceBlue, Color.AntiqueWhite, Color.Aquamarine, Color.LightCyan, Color.LightCoral, Color.LightGreen,
		//							Color.LightPink, Color.LimeGreen, Color.Magenta, Color.MediumBlue, Color.MediumSeaGreen, Color.Red, Color.Blue, Color.Black};
		public SetupClass setup;
		//Color [] rowDataColor = new Color[SetupClass.ColorNum];

		public SetupForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		#region カラー選択テーブルの初期化
		void SetColorTbl(ComboBox combo)
		{
			for(int i=0; i<setup.DisplayColor.Length; i++){
				combo.Items.Add(setup.DisplayColor[i].Name);
			}
		}
		#endregion
		
		#region コンボボックスのオーナー描画
		void ComboBoxOwnerPaint(object sender, DrawItemEventArgs e)
		{
			if(e.Index == -1){
				return;
			}
			System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
			sw.Start();
			
			ComboBox Combo = (ComboBox)sender;
			
			Rectangle TextRect = new Rectangle();
			Rectangle ColorRect = new Rectangle();
			
			TextRect.X = e.Bounds.X +31;
			TextRect.Y = e.Bounds.Y +1;
			TextRect.Width = e.Bounds.Width -2;
			TextRect.Height = e.Bounds.Height -2;
			
			ColorRect.X = e.Bounds.X +2;
			ColorRect.Y = e.Bounds.Y +2;
			ColorRect.Width = 25;
			ColorRect.Height = e.Bounds.Height -4;
			
			e.DrawBackground();
			
			Brush b = new SolidBrush(setup.DisplayColor[e.Index]);
			e.Graphics.DrawString(setup.DisplayColor[e.Index].Name, e.Font, Brushes.Black, TextRect);
			e.Graphics.FillRectangle(b, ColorRect);
			e.Graphics.DrawRectangle(Pens.Black, ColorRect);
			e.DrawFocusRectangle();
			sw.Stop();
			System.Diagnostics.Debug.WriteLine(sw.Elapsed);
		}
		void ComboBoxOwnerPaint_mini(object sender, DrawItemEventArgs e)
		{
			if(e.Index == -1){
				return;
			}
			
			ComboBox Combo = (ComboBox)sender;
			
			Rectangle ColorRect = new Rectangle();
			
			ColorRect.X = e.Bounds.X + 2;
			ColorRect.Y = e.Bounds.Y + 2;
			ColorRect.Width = e.Bounds.Width - 4;
			ColorRect.Height = e.Bounds.Height - 4;
			
			e.DrawBackground();
			
			Brush b = new SolidBrush(setup.DisplayColor[e.Index]);
			e.Graphics.FillRectangle(b, ColorRect);
			e.DrawFocusRectangle();
		}
		#endregion
		
		#region センターライン色選択コンボボックスオーナー描画
		void CmbCenterLineDrawItem(object sender, DrawItemEventArgs e)
		{
			ComboBoxOwnerPaint(sender, e);
		}
		#endregion
		
		#region 8x8領域ライン色選択コンボボックスオーナー描画
		void Cmb8LineDrawItem(object sender, DrawItemEventArgs e)
		{
			ComboBoxOwnerPaint(sender, e);
		}
		#endregion
		
		#region コメント色の色選択コンボボックスオーナー描画
		void CmbCommentColor1DrawItem(object sender, DrawItemEventArgs e)
		{
			ComboBoxOwnerPaint_mini(sender, e);
		}
		
		void CmbCommentColor2DrawItem(object sender, DrawItemEventArgs e)
		{
			ComboBoxOwnerPaint_mini(sender, e);
		}
		
		void CmbCommentColor3DrawItem(object sender, DrawItemEventArgs e)
		{
			ComboBoxOwnerPaint_mini(sender, e);
		}
		
		void CmbCommentColor4DrawItem(object sender, DrawItemEventArgs e)
		{
			ComboBoxOwnerPaint_mini(sender, e);
		}
		
		void CmbCommentColor5DrawItem(object sender, DrawItemEventArgs e)
		{
			ComboBoxOwnerPaint_mini(sender, e);
		}
		
		void CmbCommentColor6DrawItem(object sender, DrawItemEventArgs e)
		{
			ComboBoxOwnerPaint_mini(sender, e);
		}
		#endregion
		
		#region OKボタンが押されたとき
		void BtnOKClick(object sender, EventArgs e)
		{
			setup.CenterLineVisible = chkCenterLine.Checked;
			setup.CenterLineColor = setup.DisplayColor[cmbCenterLine.SelectedIndex];
			setup.EightLineVisible = chk8Area.Checked;
			setup.EightLineColor = setup.DisplayColor[cmb8Line.SelectedIndex];
			
			setup.RecentlyFileNum = (int)updownRecentlyList.Value;
			setup.WindowListNum = (int)updownWindowList.Value;
			
			//閾値表
			setup.Threshold[0,0] = double.Parse(txtRThreshold1.Text);		setup.Threshold[1,0] = double.Parse(txtDThreshold1.Text);
			setup.Threshold[0,1] = double.Parse(txtRThreshold2.Text);		setup.Threshold[1,1] = double.Parse(txtDThreshold2.Text);
			setup.Threshold[0,2] = double.Parse(txtRThreshold3.Text);		setup.Threshold[1,2] = double.Parse(txtDThreshold3.Text);
			setup.Threshold[0,3] = double.Parse(txtRThreshold4.Text);		setup.Threshold[1,3] = double.Parse(txtDThreshold4.Text);
			setup.Threshold[0,4] = double.Parse(txtRThreshold5.Text);		setup.Threshold[1,4] = double.Parse(txtDThreshold5.Text);
			
			//コメント
			setup.Comment[0] = txtComment1.Text;
			setup.Comment[1] = txtComment2.Text;
			setup.Comment[2] = txtComment3.Text;
			setup.Comment[3] = txtComment4.Text;
			setup.Comment[4] = txtComment5.Text;
			setup.Comment[5] = txtComment6.Text;
			
			//コメント表示色
			setup.CommColor[0] = setup.DisplayColor[cmbCommentColor1.SelectedIndex];
			setup.CommColor[1] = setup.DisplayColor[cmbCommentColor2.SelectedIndex];
			setup.CommColor[2] = setup.DisplayColor[cmbCommentColor3.SelectedIndex];
			setup.CommColor[3] = setup.DisplayColor[cmbCommentColor4.SelectedIndex];
			setup.CommColor[4] = setup.DisplayColor[cmbCommentColor5.SelectedIndex];
			setup.CommColor[5] = setup.DisplayColor[cmbCommentColor6.SelectedIndex];
			
			//コメント太字
			setup.CommBold[0] = chkBold1.Checked;
			setup.CommBold[1] = chkBold2.Checked;
			setup.CommBold[2] = chkBold3.Checked;
			setup.CommBold[3] = chkBold4.Checked;
			setup.CommBold[4] = chkBold5.Checked;
			setup.CommBold[5] = chkBold6.Checked;
			
			//前処理
			setup.Noize = chkNoize.Checked;
			setup.Normalize = chkNormalize.Checked;
			
			//判別手法
			setup.HonninCheckUp = cmbCheckHon.SelectedIndex;
			setup.TaninCheckup = cmbCheckTa.SelectedIndex;
			
			//特徴抽出法
			setup.Kajyu = rdoKajyu.Checked;
			setup.Haikei = rdoHaikei.Checked;
			
			//画面投入位置
			setup.LeftIn = rdoLeftIn.Checked;
			setup.RightIn = rdoRightIn.Checked;
			
			setup.CharaNormalize = rdoCharaNormalize.Checked;
			setup.StringNormalize = rdoStringNormalize.Checked;
			double r;
			
			if(double.TryParse(txtCharaR.Text, out r)){
				setup.CharaR = r;
			}else{
				setup.CharaR = 38.0;
			}
			
			if(double.TryParse(txtStringR.Text, out r)){
				setup.StringR = r;
			}else{
				setup.StringR = 152.0;
			}
			//表示色
			foreach(PictureBox pi in panel1.Controls){
				setup.DisplayColor[int.Parse(pi.Name)] = pi.BackColor;
			}
			
			//データベース保存場所
			setup.StrDBDir = txtDBDir.Text;
			
			//標準書体格納場所
			setup.StrStandardDir = txtStandard.Text;
			
			//筆順格納場所
			setup.StrStrokeDir = txtStroke.Text;
			
			//自動更新2020.05.31
			setup.BAutoUpdate = ckbAutoUpdate.Checked;
			setup.BForceUpdate = ckbForceUpdate.Checked;
		}
		#endregion
		
		#region 色番号を返す
		int NumOfColorRow(Color c)
		{
			int ret = 0;
	
			for(int i=0; i<setup.DisplayColor.Length; i++){
				if(setup.DisplayColor[i] == c) ret = i;
			}
			return(ret);
		}
		#endregion
		
		#region 色テーブルを作る
		private void MakeColorTable()
		{
			
			for(int j=0; j<(int)(SetupClass.ColorNum / 10); j++){
				for(int i=0; i<10; i++){
					if(j*10 + i < SetupClass.ColorNum){
						PictureBox pi = new PictureBox();
						//色選択ピクチャボックスを追加
						pi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
						pi.Location = new System.Drawing.Point(3 + 36 * i, 3 + 28* j);
						pi.Name = (j*10 + i).ToString();
						pi.Size = new System.Drawing.Size(30, 22);
						pi.TabIndex = j*10 + i + 1;
						pi.TabStop = true;
						pi.MouseClick += new MouseEventHandler(this.ColorBoxClick);
						this.panel1.Controls.Add(pi);
					}
				}
			}
		}
		#endregion
		
		#region 設定フォームの初期セットアップ(setup(SetupClass)により初期化)
		void SetFormInit()
		{
			chkCenterLine.Checked = setup.CenterLineVisible;
			cmbCenterLine.SelectedIndex = NumOfColorRow(setup.CenterLineColor);
			chk8Area.Checked = setup.EightLineVisible;
			cmb8Line.SelectedIndex = NumOfColorRow(setup.EightLineColor);
			
			updownRecentlyList.Value = setup.RecentlyFileNum;
			updownWindowList.Value = setup.WindowListNum;
			
			//閾値表
			txtRThreshold1.Text = setup.Threshold[0,0].ToString();	txtDThreshold1.Text = setup.Threshold[1,0].ToString();
			txtRThreshold2.Text = setup.Threshold[0,1].ToString();	txtDThreshold2.Text = setup.Threshold[1,1].ToString();
			txtRThreshold3.Text = setup.Threshold[0,2].ToString();	txtDThreshold3.Text = setup.Threshold[1,2].ToString();
			txtRThreshold4.Text = setup.Threshold[0,3].ToString();	txtDThreshold4.Text = setup.Threshold[1,3].ToString();
			txtRThreshold5.Text = setup.Threshold[0,4].ToString();	txtDThreshold5.Text = setup.Threshold[1,4].ToString();
			
			//コメント
			txtComment1.Text = setup.Comment[0];
			txtComment2.Text = setup.Comment[1];
			txtComment3.Text = setup.Comment[2];
			txtComment4.Text = setup.Comment[3];
			txtComment5.Text = setup.Comment[4];
			txtComment6.Text = setup.Comment[5];
			
			//コメント表示色
			cmbCommentColor1.SelectedIndex = NumOfColorRow(setup.CommColor[0]);
			cmbCommentColor2.SelectedIndex = NumOfColorRow(setup.CommColor[1]);
			cmbCommentColor3.SelectedIndex = NumOfColorRow(setup.CommColor[2]);
			cmbCommentColor4.SelectedIndex = NumOfColorRow(setup.CommColor[3]);
			cmbCommentColor5.SelectedIndex = NumOfColorRow(setup.CommColor[4]);
			cmbCommentColor6.SelectedIndex = NumOfColorRow(setup.CommColor[5]);
			
			//コメント太字
			chkBold1.Checked = setup.CommBold[0];
			chkBold2.Checked = setup.CommBold[1];
			chkBold3.Checked = setup.CommBold[2];
			chkBold4.Checked = setup.CommBold[3];
			chkBold5.Checked = setup.CommBold[4];
			chkBold6.Checked = setup.CommBold[5];
			
			chkNoize.Checked = setup.Noize;
			chkNormalize.Checked = setup.Normalize;
			
			cmbCheckHon.SelectedIndex = setup.HonninCheckUp;
			cmbCheckTa.SelectedIndex = setup.TaninCheckup;
			
			rdoKajyu.Checked = setup.Kajyu;
			rdoHaikei.Checked = setup.Haikei;
			
			rdoLeftIn.Checked = setup.LeftIn;
			rdoRightIn.Checked = setup.RightIn;
			
			rdoCharaNormalize.Checked = setup.CharaNormalize;
			rdoStringNormalize.Checked = setup.StringNormalize;
			
			//2020.05.31 自動更新追加
			ckbAutoUpdate.Checked = setup.BAutoUpdate;
			ckbForceUpdate.Checked = setup.BForceUpdate;
				
			txtCharaR.Text = setup.CharaR.ToString();
			txtStringR.Text = setup.StringR.ToString();
			
			foreach(PictureBox pi in panel1.Controls){
				pi.BackColor = setup.DisplayColor[int.Parse(pi.Name)];
			}
			
			txtDBDir.Text = setup.StrDBDir;
			
			txtStandard.Text = setup.StrStandardDir;
			
			txtStroke.Text = setup.StrStrokeDir;
		}
		#endregion
		
		void SetupFormLoad(object sender, EventArgs e)
		{
			MakeColorTable();
			SetColorTbl(cmb8Line);
			SetColorTbl(cmbCenterLine);
			SetColorTbl(cmbCommentColor1);
			SetColorTbl(cmbCommentColor2);
			SetColorTbl(cmbCommentColor3);
			SetColorTbl(cmbCommentColor4);
			SetColorTbl(cmbCommentColor5);
			SetColorTbl(cmbCommentColor6);
			SetFormInit();
			
		}
		
		void ColorBoxClick(object sender, MouseEventArgs e)
		{
			PictureBox pi = (PictureBox)sender;
			ColorDialog cd = new ColorDialog();
			
			if(cd.ShowDialog() == DialogResult.OK){
				pi.BackColor = cd.Color;
			}
			//System.Diagnostics.Debug.WriteLine(cd.Color.ToString());
		}
		
		#region DBフォルダ参照ボタン
		void BtnFolderSelectClick(object sender, EventArgs e)
		{
			if(folderDlg.ShowDialog() == DialogResult.OK){
				txtDBDir.Text = folderDlg.SelectedPath;
			}
		}
		#endregion
		
		#region 標準書体参照ボタン
		void BtnStandardSelectClick(object sender, EventArgs e)
		{
			if(folderDlg.ShowDialog() == DialogResult.OK){
				txtStandard.Text = folderDlg.SelectedPath;
			}
		}
		#endregion
		
		#region 筆順参照ボタン
		void BtnStrokeSelectClick(object sender, EventArgs e)
		{
			if(folderDlg.ShowDialog() == DialogResult.OK){
				txtStroke.Text = folderDlg.SelectedPath;
			}
		}
		#endregion
	}
}
