/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2013/02/28
 * 時刻: 10:05
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Reflection;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Drawing;

namespace CharacomImagerPro
{
	/// <summary>
	/// Description of PrintParts.
	/// </summary>
	public class PrintParts
	{
		public PrintParts()
		{
		}
		public const int MarginY = 5;
		public const int MarginX = 5;
		
		public Rectangle HeaderFooterDraw(PrintPageEventArgs e)
		{
			Font HeaderF = new Font("メイリオ", 8, FontStyle.Bold);	//ヘッダー用フォント
			Font FooterF = new Font("メイリオ", 8, FontStyle.Bold);	//フッター用フォント
			
			//ヘッダーフッター用の文字列作成
			AssemblyTitleAttribute asmttl = (AssemblyTitleAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyTitleAttribute));
			string title = asmttl.Title;
			AssemblyCopyrightAttribute asmcpy = (AssemblyCopyrightAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyCopyrightAttribute));
			AssemblyCompanyAttribute asmcmp = (AssemblyCompanyAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(),typeof(AssemblyCompanyAttribute));
			string Copyright = asmcpy.Copyright + " " + asmcmp.Company;
			
			//ヘッダーの作成
			e.Graphics.DrawString(title, HeaderF, Brushes.Black, e.MarginBounds.X, e.MarginBounds.Y);
			e.Graphics.DrawString(DateTime.Now.ToString("yyyy.MM.dd"), HeaderF, Brushes.Black, e.MarginBounds.Right - HeaderF.Size * 10, e.MarginBounds.Y);
			e.Graphics.DrawLine(Pens.Black, e.MarginBounds.X, e.MarginBounds.Y + HeaderF.Height + MarginY, e.MarginBounds.Right, e.MarginBounds.Y + HeaderF.Height + MarginY);
			
			//フッターの作成
			e.Graphics.DrawLine(Pens.Black, e.MarginBounds.X, e.MarginBounds.Bottom - FooterF.Height - MarginY, e.MarginBounds.Right, e.MarginBounds.Bottom - FooterF.Height - MarginY);
			
			e.Graphics.DrawString(Copyright, FooterF, Brushes.Black, e.MarginBounds.X, e.MarginBounds.Bottom - FooterF.Height);
			
			Rectangle r = new Rectangle(e.MarginBounds.X, e.MarginBounds.Y + HeaderF.Height + MarginY, e.MarginBounds.Width, e.MarginBounds.Height - HeaderF.Height - FooterF.Height - (MarginY*2));
			return(r);
		}
	}
}
