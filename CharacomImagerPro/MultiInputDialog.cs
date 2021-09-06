/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2016/06/20
 * 時刻: 10:22
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CharacomImagerPro
{
	/// <summary>
	/// Description of MultiInputDialog.
	/// </summary>
	public partial class MultiInputDialog : Form
	{
		Bitmap bmp = new Bitmap(32,32);
		
		public MultiInputDialog()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void MultiInputDialogLoad(object sender, EventArgs e)
		{
			Graphics g = Graphics.FromImage(bmp);
			g.DrawIcon(SystemIcons.Question, 0, 0);
			g.Dispose();
			pictureBox1.Image = bmp;
		}
		void PictureBox1Paint(object sender, PaintEventArgs e)
		{
			//pictureBox1.Image = bmp;
		}
	}
}
