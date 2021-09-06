/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2011/10/17
 * 時刻: 10:14
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;
using System.Diagnostics;

namespace CharacomImagerPro
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
			// ThreadExceptionイベント・ハンドラを登録する
	       	Application.ThreadException += new
	         		ThreadExceptionEventHandler(Application_ThreadException);
	 
	      	// UnhandledExceptionイベント・ハンドラを登録する
	       	Thread.GetDomain().UnhandledException += new
	         		UnhandledExceptionEventHandler(Application_UnhandledException);
	 
	      	// メイン・スレッド以外の例外はUnhandledExceptionでハンドル
	       	//string buffer = "1"; char error = buffer[2];
	 		
	       	Application.Run(new MainForm());
		}
		// 未処理例外をキャッチするイベント・ハンドラ
     	// （Windowsアプリケーション用）
     	public static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
     	{
     		ShowErrorMessage(e.Exception, "システムエラーの通知です。");
     	}
     	// 未処理例外をキャッチするイベント・ハンドラ
     	// （主にコンソール・アプリケーション用）
     	public static void Application_UnhandledException(object sender, UnhandledExceptionEventArgs e)
     	{
     		Exception ex = e.ExceptionObject as Exception;
       		if (ex != null){
     			ShowErrorMessage(ex, "システムエラーの通知です。");
     		}
     	}
     	public static string ConvertEncoding(string src, System.Text.Encoding destEnc)
		{
			byte[] src_temp = System.Text.Encoding.ASCII.GetBytes(src);
			byte[] dest_temp = System.Text.Encoding.Convert(System.Text.Encoding.ASCII, destEnc, src_temp);
			string ret = destEnc.GetString(dest_temp);
			return ret;
		}

     	// ユーザー・フレンドリなダイアログを表示するメソッド
     	public static void ShowErrorMessage(Exception ex, string extraMessage)
     	{
     		string strError = extraMessage + " \r\n――――――――\r\n\r\n" +
         		"エラーが発生しました。開発者にお知らせください\r\n\r\n" +
         		"【エラー内容】\r\n" + ex.Message + "\r\n\r\n" +
         		"【スタックトレース】\r\n" + ex.StackTrace;
     		
     		string url = "http://characom.sakuraweb.com/insertErrorLog.php";

			System.Net.ServicePointManager.Expect100Continue = false;
			System.Net.WebClient wc = new System.Net.WebClient();
			//NameValueCollectionの作成
			System.Collections.Specialized.NameValueCollection ps =
			    new System.Collections.Specialized.NameValueCollection();
			//送信するデータ（フィールド名と値の組み合わせ）を追加
			ps.Add("StartDateTime", DateTime.Now.ToString());
			ps.Add("UserID", "user");
			
			//ビルド情報
			Assembly asm = Assembly.GetExecutingAssembly();
			Version ver = asm.GetName().Version;
			DateTime StartDate,StartTime;
			StartDate = DateTime.Parse("2000/01/01");
			StartTime = DateTime.Parse("0:0");
			string lblBuild = StartDate.AddDays(ver.Build).ToShortDateString() + "@" + StartTime.AddSeconds((double)ver.Revision * 2).ToShortTimeString();
			
			ps.Add("VersionInfo", ver.ToString());
			ps.Add("BuildDate", lblBuild);
			ps.Add("extraMessage", extraMessage);
			ps.Add("Message", ex.Message);
			ps.Add("StackTrace", ex.StackTrace);
			
			try{
				//データを送信し、また受信する
				byte[] resData = wc.UploadValues(url, ps);
			}catch{
				//Network = false;
			}
			wc.Dispose();
			
			//受信したデータを表示する
			//string resText = System.Text.Encoding.UTF8.GetString(resData);
			//Console.WriteLine(resText);
			//MessageBox.Show(resText);
			
     		DebugForm df = new DebugForm();
     		df.ViewTxt = strError;
     		df.ShowDialog();
     	}    	
	}
}
