/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2013/12/01
 * 時刻: 15:54
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CharacomImagerPro
{
	/// <summary>
	/// Description of StanderdImageForm.
	/// </summary>
	public partial class StanderdImageForm : Form
	{
		MainForm mf;
		ImageEffect imgEffect = new ImageEffect();
		
		string fileName;
		public string FileName {
			get { return fileName; }
			set { fileName = value; }
		}
		Bitmap srcBitmap = new Bitmap(320, 320);
		int _standard_or_stroke;		
		public int Standard_or_stroke {
			get { return _standard_or_stroke; }
			set { _standard_or_stroke = value; }
		}
		
		public StanderdImageForm(MainForm mainForm)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			mf = mainForm;
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		#region 画像ファイルの読み込み
		void BitmapLoad()
		{
			if(System.IO.File.Exists(FileName) == false) return;
			Bitmap bmp = new Bitmap(FileName);
			imgEffect.BitmapStretchCopyHQ(bmp, srcBitmap);
			
			ImageBox.Invalidate();
		}
		#endregion
		
		#region 初期処理
		void StanderdImageFormLoad(object sender, EventArgs e)
		{
			if(Standard_or_stroke == 0) this.Text = "【標準書体】" + System.IO.Path.GetFileNameWithoutExtension(fileName);
			else					   this.Text = "【筆順】" + System.IO.Path.GetFileNameWithoutExtension(fileName);
			if(fileName != "")BitmapLoad();
			CharaComboReflesh(System.IO.Path.GetFileNameWithoutExtension(fileName));
		}
		#endregion
		
		#region 文字種コンボボックスのリフレッシュ
		void CharaComboReflesh(string Moji)
		{
			string DataDir;
			if(Standard_or_stroke == 0){
				DataDir = mf.Setup.StrStandardDir;
			}else{
				DataDir = mf.Setup.StrStrokeDir;
			}
			if(DataDir == "" || DataDir == null){
				MessageBox.Show("データの格納場所を設定してください。\n表示メニューから設定を開いて設定して下さい。","CharacomImagerPro エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			/***
				MessageBox.Show("これから実験を行います。\nOKボタンを押した後に出てくるウィンドウの中の文字をすべてコピーしてメールで送ってください。", "CharacomImagerPro デバッグ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				System.Diagnostics.Process p = new System.Diagnostics.Process();
				
				p.StartInfo.FileName = System.Environment.GetEnvironmentVariable("ComSpec");
				
				p.StartInfo.UseShellExecute = false;
				p.StartInfo.RedirectStandardOutput = true;
				p.StartInfo.RedirectStandardInput = false;
				
				p.StartInfo.CreateNoWindow = true;
				p.StartInfo.Arguments = @"/c dir " + DataDir + " /w";
				
				p.Start();
				
				//出力
				string results = p.StandardOutput.ReadToEnd();
				
				p.WaitForExit();
				p.Close();
				
				DebugForm df = new DebugForm();
				df.StartPosition = FormStartPosition.CenterParent;
				df.ViewTxt = DataDir + "\n";
				df.ViewTxt += results;
				df.ShowDialog();
			***/
			this.cmbChara.TextChanged -= new System.EventHandler(this.CmbCharaTextChanged);
			string[] subFolders = System.IO.Directory.GetFiles(DataDir, "*", System.IO.SearchOption.TopDirectoryOnly);
			cmbChara.Items.Clear();
			for(int i=0; i<subFolders.Length; i++){
				string ext = System.IO.Path.GetExtension(subFolders[i]).ToLower();
				if(ext == ".jpeg" || ext == ".jpg" || ext == ".png" || ext == ".bmp"){
					cmbChara.Items.Add(System.IO.Path.GetFileNameWithoutExtension(subFolders[i]));
				}	
			}
			this.cmbChara.TextChanged += new EventHandler(this.CmbCharaTextChanged);
			cmbChara.SelectedIndex = 0;
			
			for(int i=0; i<cmbChara.Items.Count; i++){
				if(cmbChara.Items[i].ToString() == Moji){
					cmbChara.SelectedIndex = i;
				}
			}
			//cmbImgFile.Text = "";
			
		}
		#endregion
		
		#region imageBox ペイント処理
		void ImageBoxPaint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawImage(srcBitmap, 0, 0);
		}
		#endregion
		
		#region 取り込むボタン
		void BtnInputClick(object sender, EventArgs e)
		{
			MainForm mf = (MainForm)this.MdiParent;
			
			mf.DBImport(fileName);
		}
		#endregion
		
		#region コピーボタン
		void BtnCopyClick(object sender, EventArgs e)
		{
			Bitmap clipBmp = new Bitmap(srcBitmap);
	
			imgEffect.BitmapDrawFrame(clipBmp);
			Clipboard.SetImage(clipBmp);
			
			clipBmp.Dispose();
		}
		#endregion
		
		#region キャンセルボタン
		void BtnCancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		#endregion
		
		#region 取込むボタンメニュー
		void ToolBtnInputClick(object sender, EventArgs e)
		{
			BtnInputClick(sender, e);
		}
		#endregion
		
		#region コピーボタンメニュー
		void ToolBtnCopyClick(object sender, EventArgs e)
		{
			BtnCopyClick(sender, e);
		}
		#endregion
		
		#region コンボボックスの値が変更されたとき
		void CmbCharaTextChanged(object sender, EventArgs e)
		{
			string DataDir;
			if(Standard_or_stroke == 0){
				DataDir = mf.Setup.StrStandardDir;
			}else{
				DataDir = mf.Setup.StrStrokeDir;
			}
			if(DataDir == ""){
				MessageBox.Show("データの格納場所を設定してください。\n表示メニューから設定を開いて設定して下さい。","CharacomImagerPro エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if(System.IO.File.Exists(DataDir + @"\" + cmbChara.Text + ".jpg") == false){
				MessageBox.Show("ファイルが見つかりません。\n設定を確認して下さい。\n"+DataDir + @"\" + cmbChara.Text + ".jpg","CharacomImagerPro エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			fileName = DataDir + @"\" + cmbChara.Text + ".jpg";
			
			BitmapLoad();
			
		}
		#endregion
	}
}
