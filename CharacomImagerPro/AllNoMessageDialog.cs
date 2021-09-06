/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2016/06/23
 * 時刻: 11:14
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CharacomImagerPro
{
	/// <summary>
	/// Description of AllNoMessageDialog.
	/// </summary>
	public partial class AllNoMessageDialog : Form
	{
		private string _msg;
		public string Msg {
			get { return _msg; }
			set { _msg = value; }
		}
		Bitmap bmp = new Bitmap(32,32);
		public AllNoMessageDialog()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void AllNoMessageDialogLoad(object sender, EventArgs e)
		{
			Graphics g = Graphics.FromImage(bmp);
			g.DrawIcon(SystemIcons.Question, 0, 0);
			g.Dispose();
			pictureBox1.Image = bmp;
			
		}
		void AllNoMessageDialogShown(object sender, EventArgs e)
		{
			label1.Text = _msg;
		}
	}
}
