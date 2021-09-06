/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2011/12/22
 * 時刻: 14:49
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace CharacomImagerPro
{
	/// <summary>
	/// Description of VersionInfoForm.
	/// </summary>
	public partial class VersionInfoForm : Form
	{
		public VersionInfoForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void VersionInfoFormLoad(object sender, EventArgs e)
		{
			//タイトルの表示
			AssemblyTitleAttribute asmttl = (AssemblyTitleAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyTitleAttribute));
			lblTitle.Text = asmttl.Title;
			this.Text = asmttl.Title + "について";
			//日本語タイトルの表示
			AssemblyDescriptionAttribute asmdsc = (AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyDescriptionAttribute));
			lblDescription.Text = asmdsc.Description;
			//コピーライト
			AssemblyCopyrightAttribute asmcpy = (AssemblyCopyrightAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyCopyrightAttribute));
			AssemblyCompanyAttribute asmcmp = (AssemblyCompanyAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(),typeof(AssemblyCompanyAttribute));
			lblCopyright.Text = asmcpy.Copyright + " " + asmcmp.Company;
			//lblCopyright.Text = "幅:" + System.Windows.Forms.Screen.AllScreens[1].Bounds.Width.ToString() + " 高さ:"+System.Windows.Forms.Screen.AllScreens[1].Bounds.Height.ToString();
			//ビルド情報
			Assembly asm = Assembly.GetExecutingAssembly();
			Version ver = asm.GetName().Version;
			DateTime StartDate,StartTime;
			StartDate = DateTime.Parse("2000/01/01");
			StartTime = DateTime.Parse("0:0");
			lblVersion.Text = ver.ToString();
			lblBuild.Text = StartDate.AddDays(ver.Build).ToShortDateString() + "@" + StartTime.AddSeconds((double)ver.Revision * 2).ToShortTimeString();
		}
	}
}
