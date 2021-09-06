/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2011/10/19
 * 時刻: 15:40
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CharacomImagerPro
{
	/// <summary>
	/// Description of ZoomSelectPanel.
	/// </summary>
	public partial class ZoomSelectPanel : Form
	{
		private int wide = 1;
		
		public int Wide {
			get { return wide; }
			set { wide = value; }
		}
		
		public ZoomSelectPanel()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void BtnOKClick(object sender, EventArgs e)
		{
			if(btn400.Checked) wide = 0;
			if(btn300.Checked) wide = 1;
			if(btn200.Checked) wide = 2;
			if(btn150.Checked) wide = 3;
			if(btn100.Checked) wide = 4;
			if(btn50.Checked) wide = 5;
		}
	}
}
