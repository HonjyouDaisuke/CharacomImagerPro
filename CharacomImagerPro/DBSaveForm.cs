/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2013/11/27
 * 時刻: 20:59
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CharacomImagerPro
{
	/// <summary>
	/// Description of DBSaveForm.
	/// </summary>
	public partial class DBSaveForm : Form
	{
		//ビットマップ変数
		Bitmap srcBitmap;
		Bitmap viewBitmap = new Bitmap(160, 160);
		ImageEffect imgEffect = new ImageEffect();
		private MainForm mf;
		
		public DBSaveForm(MainForm mainForm,Bitmap bmp)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			mf = mainForm;
			MojiFolderRefresh();
			HitoFolderRefresh();
			KaiFolderRefresh();
			srcBitmap = new Bitmap(bmp.Width, bmp.Height);
			imgEffect.BitmapStretchCopyHQ(bmp, viewBitmap);
			imgEffect.BitmapCopy(bmp, srcBitmap);
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		#region 文字フォルダリフレッシュ
		void MojiFolderRefresh()
		{
			if(mf == null) return;
			string[] subFolders = System.IO.Directory.GetDirectories(mf.Setup.StrDBDir, "*", System.IO.SearchOption.TopDirectoryOnly);
			cmbMojiFolder.Items.Clear();
			for(int i=0; i<subFolders.Length; i++){
				cmbMojiFolder.Items.Add(System.IO.Path.GetFileName(subFolders[i]));
			}
			cmbMojiFolder.SelectedIndex = 0;
			//cmbMojiFolder.Text = "";
		}
		#endregion
		
		#region 人フォルダのリフレッシュ
		void HitoFolderRefresh()
		{
			if(cmbMojiFolder.Text == "")return;
			if(System.IO.Directory.Exists(mf.Setup.StrDBDir + @"\" + cmbMojiFolder.Text) == false) return;
			string[] subFolders = System.IO.Directory.GetDirectories(mf.Setup.StrDBDir + @"\" + cmbMojiFolder.Text, "*", System.IO.SearchOption.TopDirectoryOnly);
			cmbHitoFolder.Items.Clear();
			for(int i=0; i<subFolders.Length; i++){
				cmbHitoFolder.Items.Add(System.IO.Path.GetFileName(subFolders[i]));
			}
			cmbHitoFolder.SelectedIndex = 0;
			//cmbHitoFolder.Text = "";
		}
		#endregion
		
		#region 回数フォルダのリフレッシュ
		void KaiFolderRefresh()
		{
			if(cmbMojiFolder.Text == "" || cmbHitoFolder.Text == "")return;
			if(System.IO.Directory.Exists(mf.Setup.StrDBDir + @"\" + cmbMojiFolder.Text + @"\" + cmbHitoFolder.Text) == false) return;
			
			string[] subFolders = System.IO.Directory.GetFiles(mf.Setup.StrDBDir + @"\" + cmbMojiFolder.Text + @"\" + cmbHitoFolder.Text, "*", System.IO.SearchOption.TopDirectoryOnly);
			cmbImgFile.Items.Clear();
			for(int i=0; i<subFolders.Length; i++){
				string ext = System.IO.Path.GetExtension(subFolders[i]).ToLower();
				if(ext == ".jpeg" || ext == ".jpg" || ext == ".png" || ext == ".bmp"){
					cmbImgFile.Items.Add(System.IO.Path.GetFileName(subFolders[i]));
				}	
			}
			cmbImgFile.SelectedIndex = 0;
			//cmbImgFile.Text = "";
		}
		#endregion
		
		#region ImageBoxペイント処理
		void ImageBoxPaint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawImage(viewBitmap, 0, 0);
		}
		#endregion
		
		void BtnOKClick(object sender, EventArgs e)
		{
			if(cmbMojiFolder.Text == "" || cmbHitoFolder.Text == "" || cmbImgFile.Text == "")return;
			string strExt = "";
			
			if(imgEffect.IsImageFile(cmbImgFile.Text) == false){
				strExt = ".jpeg";
			}
			string strFileName = mf.Setup.StrDBDir + @"\" + cmbMojiFolder.Text + @"\" + cmbHitoFolder.Text + @"\" + cmbImgFile.Text + strExt;
			
			if(System.IO.File.Exists(strFileName)){
				if(MessageBox.Show("同一名のファイルが存在します。\n上書きしますか？","Characom Imager Pro", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK){
					srcBitmap.Save(strFileName);
				}else{
					return;
				}
			}else{
				System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(mf.Setup.StrDBDir + @"\" + cmbMojiFolder.Text + @"\" + cmbHitoFolder.Text);
				di.Create();
				srcBitmap.Save(strFileName);
			}
			this.Close();
		}
		
		
		void CmbMojiFolderTextUpdate(object sender, EventArgs e)
		{
			HitoFolderRefresh();
			KaiFolderRefresh();
		}
		
		void CmbHitoFolderTextUpdate(object sender, EventArgs e)
		{
			KaiFolderRefresh();
		}
		
		void CmbImgFileTextUpdate(object sender, EventArgs e)
		{
			
		}
		
		void CmbMojiFolderSelectedIndexChanged(object sender, EventArgs e)
		{
			HitoFolderRefresh();
			KaiFolderRefresh();
		}
		
		void CmbHitoFolderSelectedIndexChanged(object sender, EventArgs e)
		{
			KaiFolderRefresh();
		}
		
		void CmbImgFileSelectedIndexChanged(object sender, EventArgs e)
		{
			
		}
	}
}
