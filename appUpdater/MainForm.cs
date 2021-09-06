/*
 * SharpDevelopによって生成
 * ユーザ: 大介
 * 日付: 2020/01/23
 * 時刻: 22:29
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Text;
using System.Reflection;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO.Compression;

namespace appUpdater
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private string appVersion; 
		private bool bFouce;
		const string sVersionURL = @"http://characom.sakuraweb.com/Software/CharacomImagerPro/version.ini";
		const string sProgramURL = @"http://characom.sakuraweb.com/Software/CharacomImagerPro/CharacomImagerPro.zip";
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		#region PC名、IPアドレス取得
		string GetIPAddress()
		{
			string ipaddress = "";
			
			ipaddress = Dns.GetHostName();
			
			IPHostEntry ipentry = Dns.GetHostEntry(Dns.GetHostName());
			
			foreach(IPAddress ip in ipentry.AddressList){
				if(ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
					ipaddress += "(" + ip.ToString() +")";
			}
			
			return ipaddress;
		}
		#endregion
		
		#region updateログ送信
		void UpdateLog_Send(string sComment)
		{
			string url = "http://characom.sakuraweb.com/insertUpdateLog.php";

			System.Net.ServicePointManager.Expect100Continue = false;
			System.Net.WebClient wc = new System.Net.WebClient();
			//NameValueCollectionの作成
			System.Collections.Specialized.NameValueCollection ps =
			    new System.Collections.Specialized.NameValueCollection();
			//送信するデータ（フィールド名と値の組み合わせ）を追加
			ps.Add("StartDateTime", DateTime.Now.ToString());
			ps.Add("IPAddr", GetIPAddress());
			string user_name = "misaki";
			if(File.Exists("user.ini")){
				StreamReader sr = new StreamReader("user.ini");
				user_name = sr.ReadToEnd();
    			sr.Close();
			}
			
    		ps.Add("UserID", user_name);
			
			//ビルド情報
			Assembly asm = Assembly.GetExecutingAssembly();
			Version ver = asm.GetName().Version;
			DateTime StartDate,StartTime;
			StartDate = DateTime.Parse("2000/01/01");
			StartTime = DateTime.Parse("0:0");
			string lblBuild = StartDate.AddDays(ver.Build).ToShortDateString() + "@" + StartTime.AddSeconds((double)ver.Revision * 2).ToShortTimeString();
			
			ps.Add("VersionInfo", ver.ToString());
			//MessageBox.Show(sComment);
			ps.Add("Comment", sComment.ToString());
			try{
				//データを送信し、また受信する
				byte[] resData = wc.UploadValues(url, ps);
				//受信したデータを表示する
				string resText = System.Text.Encoding.UTF8.GetString(resData);
				//MessageBox.Show(resText);
			}catch{
				//Network = false;
			}
			wc.Dispose();
			
			
		}
		#endregion

		private bool UpdateCheck(string serverVersion, string localVersion)
		{
			string[] sVersion;
			string[] lVersion;
			
			if(serverVersion.Substring(0,1) != "v"){
				MessageBox.Show("バージョン情報読み込みに失敗しました。" + serverVersion + ":"  + serverVersion.Substring(0,1),
				                "CharacomImagerPro更新プログラム", 
			                     MessageBoxButtons.OK,
			                     MessageBoxIcon.Exclamation,
			                     MessageBoxDefaultButton.Button1);
				return false;
			}
			sVersion = serverVersion.Substring(1).Split('.');
			lVersion = localVersion.Split('.');
			
			for(int i=0; i<4; i++){
				if(Int32.Parse(sVersion[i]) > Int32.Parse(lVersion[i])){
					return true;
				}else if(Int32.Parse(sVersion[i]) < Int32.Parse(lVersion[i])){
					return false;
				}
			}
			
			return false;
		}
		static DirectoryInfo CreateDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                return null;
            }

            return Directory.CreateDirectory(path);
        }
		
		/// <summary>
		/// ディレクトリをコピーする
		/// </summary>
		/// <param name="sourceDirName">コピーするディレクトリ</param>
		/// <param name="destDirName">コピー先のディレクトリ</param>
		public static void CopyDirectory(
		    string sourceDirName, string destDirName)
		{
		    //コピー先のディレクトリがないときは作る
		    if (!System.IO.Directory.Exists(destDirName))
		    {
		        System.IO.Directory.CreateDirectory(destDirName);
		        //属性もコピー
		        System.IO.File.SetAttributes(destDirName, 
		            System.IO.File.GetAttributes(sourceDirName));
		    }
		
		    //コピー先のディレクトリ名の末尾に"\"をつける
		    if (destDirName[destDirName.Length - 1] !=
		            System.IO.Path.DirectorySeparatorChar)
		        destDirName = destDirName + System.IO.Path.DirectorySeparatorChar;
		
		    //コピー元のディレクトリにあるファイルをコピー
		    string[] files = System.IO.Directory.GetFiles(sourceDirName);
		    foreach (string file in files){
		    	File.Copy(file, destDirName + Path.GetFileName(file), true);
		    }
		    //コピー元のディレクトリにあるディレクトリについて、再帰的に呼び出す
		    //string[] dirs = System.IO.Directory.GetDirectories(sourceDirName);
		    //foreach (string dir in dirs)
		    //    CopyDirectory(dir, destDirName + System.IO.Path.GetFileName(dir));
		}
		private bool VersionCheck()
        {
            WebClient wc = new WebClient();
			bool bUpdate = true;
			
			if(NetworkInterface.GetIsNetworkAvailable() == false){
				return(false);
			}
			
            try{
				
		    	Stream st = wc.OpenRead(sVersionURL);
		
		    	Encoding enc = Encoding.GetEncoding("Shift_JIS");
		    	StreamReader sr = new StreamReader(st, enc);
		    	string html = sr.ReadToEnd();
			    sr.Close();
			    st.Close();
			
			    if(bFouce == false){
			    	bUpdate = UpdateCheck(html, appVersion);
			    	if(bUpdate == true){
			    		DialogResult dlgRes = MessageBox.Show("新しいプログラムが発行されています。更新しますか？",
			                    							"CharacomImagerPro更新プログラム", 
			                     							MessageBoxButtons.YesNo,
			                     							MessageBoxIcon.Question,
			                     							MessageBoxDefaultButton.Button1);
			    		if(dlgRes == DialogResult.No){
			    			bUpdate = false;
			    		}
			    	}
			    }
			    	
			    //Updateの必要があった場合
			    if(bUpdate == true){
			    	//ダウンロード準備
			    	UpdateLog_Send("Ready to update...");
            		Directory.CreateDirectory("updatetmp");
					// CharacomImagerProのプロセスを強制終了する。
					var processes = Process.GetProcessesByName("CharacomImagerPro");
					foreach (var process in processes)
					{
    					process.Kill();
					}
					
					//プログラムをダウンロード
					//WebClient wc = new System.Net.WebClient();
					const string zipPath = @"updatetmp\Characom.zip";
					wc.DownloadFile( sProgramURL, zipPath);
					wc.Dispose();
					
					UpdateLog_Send("Download compleate...");
            		
					//プログラムを解凍
					const string extractPath = @"updatetmp";
            		bool overwrite = true;
		
		            using (ZipArchive archive = ZipFile.OpenRead(zipPath))
		            {
		                foreach (ZipArchiveEntry entry in archive.Entries)
		                {
		                    // 完全なファイル名/ ディレクトリ名
		                    String combineFilePath = Path.Combine(extractPath + "\\" , entry.FullName);
		                    combineFilePath = combineFilePath.Replace("/", "\\");
		                    UpdateLog_Send("unComp..." + combineFilePath);
		                    // ディレクトリを作成する
		                    if (entry.Name == "") {
		                        CreateDirectory(combineFilePath);
		                        continue;
		                    }
		
		                    // ディレクトリの有無を調べる
		                    DirectoryInfo di = Directory.GetParent(combineFilePath);
		                    if (!di.Exists)
		                    {
		                        CreateDirectory(di.FullName);
		                    }
		
		                    // ファイルを解凍する
		                    entry.ExtractToFile(combineFilePath, overwrite);
		                }
		            }
					
		            UpdateLog_Send("uncomp Archive compleate...");
            		
		            //解凍したファイルをコピー
		            CopyDirectory(@"updatetmp\packageTmp", ".\\");
		            
					UpdateLog_Send("Copy exe Files compleate...");
            				            
					MessageBox.Show("自動更新が完了しました。CharacomImagerProを起動します。",
			                    	"CharacomImagerPro更新プログラム", 
			                     	MessageBoxButtons.OK,
			                     	MessageBoxIcon.Information,
			                     	MessageBoxDefaultButton.Button1);
					// CharacomImagerProを起動
					ProcessStartInfo pInfo = new ProcessStartInfo();
            		pInfo.FileName = "CharacomImagerPro.exe";
 					pInfo.Arguments = "true";
            		Process.Start(pInfo);
            		
            		UpdateLog_Send("Program is version uped " + appVersion + "-->New Version");
            		Directory.Delete("updatetmp", true);
            		this.Close();
			    	return true;
			    }else{
			    	UpdateLog_Send("Program is NOT version uped" + appVersion + "-->stay...");
			    	this.Close();
			    	return true;
			    }
            }catch{
				wc.Dispose();
            	return false;
            }
			
        }
		
		void MainFormShown(object sender, System.EventArgs e)
		{
			VersionCheck();
			this.Close();
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			string[] Commands = System.Environment.GetCommandLineArgs();
			appVersion = Commands[1];
			
			bFouce = false;
			if(Commands[2] == "true" || Commands[2] == "True"){
				bFouce = true;
				MessageBox.Show("強制アップデートを開始します。",
			                    	"CharacomImagerPro更新プログラム", 
			                     	MessageBoxButtons.OK,
			                     	MessageBoxIcon.Information,
			                     	MessageBoxDefaultButton.Button1);
			}
		}
	}
}
