/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2012/03/26
 * 時刻: 11:38
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace CharacomImagerPro
{
	/// <summary>
	/// Description of DebugForm.
	/// </summary>
	public partial class DebugForm : Form
	{
		string _viewTxt = "";
		public string ViewTxt {
			get { return _viewTxt; }
			set { _viewTxt = value; }
		}
		public DebugForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void DebugFormLoad(object sender, EventArgs e)
		{
			/***
			DirectoryInfo di = new DirectoryInfo(Environment.CurrentDirectory);
			textBox1.Text = di.FullName.ToString() + "\r\n";
			
			FileInfo [] fi = di.GetFiles();
			foreach(FileInfo fiTemp in fi){
				textBox1.Text += fiTemp.Name + "\r\n";
			}
			textBox1.Text += "Version:" + System.Environment.Version.ToString() + "\r\n";
			***/
			textBox1.Text = ViewTxt;
		}
		
		void BtnCloseClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
