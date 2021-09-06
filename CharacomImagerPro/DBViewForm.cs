/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2013/11/12
 * 時刻: 12:18
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Drawing2D;
namespace CharacomImagerPro
{
	/// <summary>
	/// Description of DBViewForm.
	/// </summary>
	public partial class DBViewForm : Form
	{
		//ビットマップ変数
		Bitmap srcBitmap = new Bitmap(320, 320);
		ImageEffect imgEffect = new ImageEffect();
		private MainForm mf;
		
		public DBViewForm(MainForm mainForm)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			imgEffect.BitmapWhitening(srcBitmap);
			Bitmap bmp= new Bitmap(160,160);
			imgEffect.BitmapStretchCopy(bmp, srcBitmap);
			
			this.TopMost = true;
			mf = mainForm;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		
		#region 閉じる
		void BtnCancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		#endregion
		
		#region 画像ファイルの読み込み
		void BitmapLoad(string FileName)
		{
			if(System.IO.File.Exists(FileName) == false) return;
			Bitmap bmp = new Bitmap(FileName);
			imgEffect.BitmapStretchCopyHQ(bmp, srcBitmap);
			
			ImageBox.Invalidate();
		}
		#endregion
		
		#region イメージボックスのペイント処理
		void ImageBoxPaint(object sender, PaintEventArgs e)
		{
			e.Graphics.InterpolationMode = InterpolationMode.High;
			e.Graphics.DrawImage(srcBitmap, 0, 0);
		}
		#endregion
		
		#region 文字フォルダリフレッシュ
		void MojiFolderRefresh()
		{
			if(mf == null) return;
			string[] subFolders = System.IO.Directory.GetDirectories(mf.Setup.StrDBDir, "*", System.IO.SearchOption.TopDirectoryOnly);
			cmbMojiFolder.Items.Clear();
			for(int i=0; i<subFolders.Length; i++){
				cmbMojiFolder.Items.Add(System.IO.Path.GetFileName(subFolders[i]));
			}
			if(cmbMojiFolder.Items.Count > 0)cmbMojiFolder.SelectedIndex = 0;
			//cmbMojiFolder.Text = "";
		}
		#endregion
		
		#region 人フォルダのリフレッシュ
		void HitoFolderRefresh()
		{
			if(cmbMojiFolder.Text == "")return;
			
			string[] subFolders = System.IO.Directory.GetDirectories(mf.Setup.StrDBDir + @"\" + cmbMojiFolder.Text, "*", System.IO.SearchOption.TopDirectoryOnly);
			cmbHitoFolder.Items.Clear();
			for(int i=0; i<subFolders.Length; i++){
				cmbHitoFolder.Items.Add(System.IO.Path.GetFileName(subFolders[i]));
			}
			if(cmbHitoFolder.Items.Count > 0)cmbHitoFolder.SelectedIndex = 0;
			//cmbHitoFolder.Text = "";
		}
		#endregion
		
		#region 回数フォルダのリフレッシュ
		void KaiFolderRefresh()
		{
			if(cmbMojiFolder.Text == "" || cmbHitoFolder.Text == "")return;
			
			string[] subFolders = System.IO.Directory.GetFiles(mf.Setup.StrDBDir + @"\" + cmbMojiFolder.Text + @"\" + cmbHitoFolder.Text, "*", System.IO.SearchOption.TopDirectoryOnly);
			cmbImgFile.Items.Clear();
			for(int i=0; i<subFolders.Length; i++){
				string ext = System.IO.Path.GetExtension(subFolders[i]).ToLower();
				if(ext == ".jpeg" || ext == ".jpg" || ext == ".png" || ext == ".bmp"){
					cmbImgFile.Items.Add(System.IO.Path.GetFileName(subFolders[i]));
				}	
			}
			if(cmbImgFile.Items.Count > 0) cmbImgFile.SelectedIndex = 0;
			//cmbImgFile.Text = "";
		}
		#endregion
		
		void CmbMojiFolderTextChanged(object sender, EventArgs e)
		{
			bool r = false;
			for(int i=0; i<cmbMojiFolder.Items.Count; i++){
				if(cmbMojiFolder.Text == cmbMojiFolder.Items[i].ToString()){
					cmbMojiFolder.SelectedIndex = i;
					r = true;
				}
			}
			if(r == false){
				cmbMojiFolder.SelectedIndex = 0;
				cmbMojiFolder.Text = "";
			}
			//MojiFolderRefresh();
		}
		
		void CmbHitoFolderTextChanged(object sender, EventArgs e)
		{
			bool r = false;
			for(int i=0; i<cmbHitoFolder.Items.Count; i++){
				if(cmbHitoFolder.Text == cmbHitoFolder.Items[i].ToString()){
					cmbHitoFolder.SelectedIndex = i;
					r = true;
				}
			}
			if(r == false){
				cmbHitoFolder.SelectedIndex = 0;
				cmbHitoFolder.Text = "";
			}
			//MojiFolderRefresh();
		}
		
		void CmbImgFileTextChanged(object sender, EventArgs e)
		{
			bool r = false;
			for(int i=0; i<cmbImgFile.Items.Count; i++){
				if(cmbImgFile.Text == cmbImgFile.Items[i].ToString()){
					cmbImgFile.SelectedIndex = i;
					r = true;
				}
			}
			if(r == false){
				cmbImgFile.SelectedIndex = 0;
				cmbImgFile.Text = "";
			}
			if(cmbMojiFolder.Text == "" || cmbHitoFolder.Text == "" || cmbImgFile.Text == "")return;
			BitmapLoad(mf.Setup.StrDBDir + @"\" + cmbMojiFolder.Text + @"\" + cmbHitoFolder.Text + @"\" + cmbImgFile.Text);
			
			//MojiFolderRefresh();
		}
		
		void CmbMojiFolderSelectedIndexChanged(object sender, EventArgs e)
		{
			if(cmbMojiFolder.Text == "")return;
			HitoFolderRefresh();
			KaiFolderRefresh();
		}
		
		void CmbHitoFolderSelectedIndexChanged(object sender, EventArgs e)
		{
			if(cmbMojiFolder.Text == "" || cmbHitoFolder.Text == "")return;
			KaiFolderRefresh();
		}
		
		void CmbImgFileSelectedIndexChanged(object sender, EventArgs e)
		{
				
		}
		
		void BtnMojiLeftClick(object sender, EventArgs e)
		{
			if(cmbMojiFolder.SelectedIndex > 0){
				cmbMojiFolder.SelectedIndex--;
				HitoFolderRefresh();
				KaiFolderRefresh();
			}
		}
		
		void BtnHitoLeftClick(object sender, EventArgs e)
		{
			if(cmbHitoFolder.SelectedIndex > 0){
				cmbHitoFolder.SelectedIndex--;
				KaiFolderRefresh();
			}
		}
		
		void BtnImgLeftClick(object sender, EventArgs e)
		{
			if(cmbImgFile.SelectedIndex > 0){
				cmbImgFile.SelectedIndex--;
				//KaiFolderRefresh();
			}
		}
		
		void BtnMojiRightClick(object sender, EventArgs e)
		{
			if(cmbMojiFolder.SelectedIndex < cmbMojiFolder.Items.Count - 1){
				cmbMojiFolder.SelectedIndex++;
				HitoFolderRefresh();
				KaiFolderRefresh();
			}
		}
		
		void BtnHitoRightClick(object sender, EventArgs e)
		{
			if(cmbHitoFolder.SelectedIndex < cmbHitoFolder.Items.Count - 1){
				cmbHitoFolder.SelectedIndex++;
				KaiFolderRefresh();
			}
		}
		
		void BtnImgRightClick(object sender, EventArgs e)
		{
			if(cmbImgFile.SelectedIndex < cmbImgFile.Items.Count - 1){
				cmbImgFile.SelectedIndex++;
				//KaiFolderRefresh();
			}
		}
		
		#region 取り込むボタン
		void BtnOKClick(object sender, EventArgs e)
		{
			MainForm mf = (MainForm)this.MdiParent;
			
			mf.DBImport(mf.Setup.StrDBDir + @"\" + cmbMojiFolder.Text + @"\" + cmbHitoFolder.Text + @"\" + cmbImgFile.Text);
		}
		#endregion
		
		void DBViewFormShown(object sender, EventArgs e)
		{
			MojiFolderRefresh();
		}
		
		#region 標準書体ボタン
		void BtnStandardClick(object sender, EventArgs e)
		{
			if(mf.Setup.StrStandardDir == ""){
				MessageBox.Show("標準書体の格納場所を設定してください。\n表示メニューから設定を開いて設定して下さい。","CharacomImagerPro エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if(System.IO.File.Exists(mf.Setup.StrStandardDir + @"\" + cmbMojiFolder.Text + ".jpg") == false){
				MessageBox.Show("標準書体のファイルが見つかりません。\n標準書体の格納場所を確認してください。","CharacomImagerPro エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			StanderdImageForm sif = new StanderdImageForm((MainForm)this.MdiParent);
			sif.FileName = mf.Setup.StrStandardDir + @"\" + cmbMojiFolder.Text + ".jpg";
			sif.MdiParent = this.MdiParent;
			sif.Standard_or_stroke = 0;
			sif.Show();
			//"C:\Dドライブ\Characom\SharpDevelop\CharacomImagerPro\Documents\筆順\鮎.jpg"
		}
		#endregion
		
		#region 筆順ボタン
		void BtnStrokeClick(object sender, EventArgs e)
		{
			if(mf.Setup.StrStrokeDir == ""){
				MessageBox.Show("筆順画像の格納場所を設定してください。\n表示メニューから設定を開いて設定して下さい。","CharacomImagerPro エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if(System.IO.File.Exists(mf.Setup.StrStrokeDir + @"\" + cmbMojiFolder.Text + ".jpg") == false){
				MessageBox.Show("筆順画像のファイルが見つかりません。\n筆順画像の格納場所を確認してください。","CharacomImagerPro エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			StanderdImageForm sif = new StanderdImageForm((MainForm)this.MdiParent);
			sif.FileName = mf.Setup.StrStrokeDir + @"\" + cmbMojiFolder.Text + ".jpg";
			sif.MdiParent = this.MdiParent;
			sif.Standard_or_stroke = 1;
			sif.Show();
		}
		#endregion
	}
}
