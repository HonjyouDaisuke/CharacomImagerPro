/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2011/10/17
 * 時刻: 10:14
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
//using WinTabDotnet;

namespace CharacomImagerPro
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		RecentlyClass recentlyFile = new RecentlyClass();
		private const string RecentlyIniFileName = "recently.ini";
		private const string SetupIniFileName = "setup.ini";
		ArrayList windows = new ArrayList();
		
		private SetupClass _setup = new SetupClass();
		private ImageEffect imageEffect = new ImageEffect();
		private WindowListClass windowsList = new WindowListClass();
		
		private bool _network = true;		
		public bool Network {
			get { return _network; }
			set { _network = value; }
		}
		
		private bool _allno = false;		
		public bool AllNo {
			get { return _allno; }
			set { _allno = value; }
		}
		
		public SetupClass Setup {
			get { return _setup; }
			set { _setup = value; }
		}
		
		public WinTabClass  wtWinTabData= new WinTabClass();
		
		//WinTab用オブジェクト
		//private WinTabMessenger  m_wtMessenger;
        //private WinTabContext    m_wtContext;

        private ArrayList wData = new ArrayList();
        
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			#region WinTabProgram
			//WinTabプログラム
			/**
			if (!WinTab.LoadWinTab()) {
                MessageBox.Show("ペンタブレットが見つかりません(WinTab32.dllが見つかりません)。","WinTab.NET");
                throw new WinTabException("WinTab.NETの初期化に失敗しました。");
            }
			**/
			
            //m_wtMessenger = new WinTabMessenger();
            //m_wtContext = new WinTabContext();
            //System.Diagnostics.Debug.WriteLine(WinTab.WinTabID);
            /**
			wtWinTabData.WinTabID = WinTab.WinTabID;
			wtWinTabData.DeviceName = WinTab.DeviceName;
			wtWinTabData.PressuerMax = WinTab.DeviceNPressure.axMax;
			lblWinTabID.Text     = wtWinTabData.WinTabID;
            lblDeviceName.Text   = wtWinTabData.DeviceName;
            prgPressuer.Maximum = wtWinTabData.PressuerMax;
            m_wtMessenger.CursorMove += delegate(PacketEventArgs e) {
            	wtWinTabData.X = e.pkts.pkX;
            	wtWinTabData.Y = e.pkts.pkY;
            	wtWinTabData.Z = e.pkts.pkZ;
				lblPosition.Text = wtWinTabData.X.ToString() + "," + wtWinTabData.Y.ToString() + "," + wtWinTabData.Z.ToString();
            	System.Diagnostics.Debug.WriteLine( e.pkts.pkX.ToString() + "," + e.pkts.pkY.ToString() + "," + e.pkts.pkZ.ToString());
            	System.Diagnostics.Debug.WriteLine("kimasita");
            };
            
            m_wtMessenger.NPressureChange += delegate(PacketEventArgs e) { 
            	wtWinTabData.Pressuer = e.pkts.pkNormalPressure;
            	prgPressuer.Value = wtWinTabData.Pressuer;
            	lblPressure.Text = wtWinTabData.Pressuer.ToString();
            	prgPressuer.Invalidate();
            	//System.Diagnostics.Debug.WriteLine(e.pkts.pkNormalPressure.ToString());
            	//prgPressuer.Value = e.pkts.pkNormalPressure; 
            	//System.Diagnostics.Debug.WriteLine("Kimasita2");
            };
            //m_wtMessenger.CursorChange += delegate(PacketEventArgs e) { lblCursor.Text = e.pkts.pkCursor.ToString(); };
          	m_wtContext.Open(this.Handle,true);
          	***/
        #endregion

			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			
			
		}
		
		/**
		#region WinTab用 WndProcオーバーライド
		protected override void WndProc(ref Message m) {
			//System.Diagnostics.Debug.WriteLine(m.ToString());
			if (!m_wtMessenger.WndProc(ref m)) {
				base.WndProc(ref m);
			}
        }
		#endregion
		***/
		
		#region カラー選択テーブルの初期化
		void SetColorTbl(ComboBox combo)
		{
			if(combo.Items.Count >= Setup.DisplayColor.Length) return;
			
			for(int i=0; i<Setup.DisplayColor.Length; i++){
				combo.Items.Add(Setup.DisplayColor[i].Name);
				System.Diagnostics.Debug.WriteLine("combo"+i.ToString()+":"+Setup.DisplayColor[i].Name);
			}
		}
		#endregion
		
		#region カラー情報からのコンボボックス選択インデックス
		int GetSelectIndexFromColor(Color c)
		{
			int rsi = 1;
			Color sc;
			System.Diagnostics.Debug.WriteLine("c="+c.ToString());
			for(int i=0; i<Setup.DisplayColor.Length; i++){
				sc = Setup.DisplayColor[i];
				if(sc.R == c.R && sc.G == c.G && sc.B == c.B){
					rsi = i;
				}
			}
			System.Diagnostics.Debug.WriteLine("カラー番号="+rsi.ToString());
			return(rsi);
		}
		#endregion
		
		#region 色変更コンボボックスのオーナー描画
		void comboColorDrawItem(object sender, DrawItemEventArgs e)
		{
			if(e.Index == -1){
				return;
			}
			
			ComboBox Combo = (ComboBox)sender;
			
			Rectangle TextRect = new Rectangle();
			Rectangle ColorRect = new Rectangle();
			
			TextRect.X = e.Bounds.X +26;
			TextRect.Y = e.Bounds.Y +1;
			TextRect.Width = e.Bounds.Width -2;
			TextRect.Height = e.Bounds.Height -2;
			
			ColorRect.X = e.Bounds.X +2;
			ColorRect.Y = e.Bounds.Y +2;
			ColorRect.Width = 25;
			ColorRect.Height = e.Bounds.Height -4;
			
			e.DrawBackground();
			
			Brush b = new SolidBrush(Setup.DisplayColor[e.Index]);
			e.Graphics.DrawString(Setup.DisplayColor[e.Index].Name, e.Font, Brushes.Black, TextRect);
			e.Graphics.FillRectangle(b, ColorRect);
			e.Graphics.DrawRectangle(Pens.Black, ColorRect);
			e.DrawFocusRectangle();
		}
		#endregion
		
		#region 子フォームの右端
		//子フォームの右端を返す
		private int CIF_ChildFormMaxRight()
		{
			//2020.01.15 ここを改良して左端が開いているときは左端に表示
			int maxRight = 0;
			if(this.MdiChildren.Length > 0){
				foreach(Form f in this.MdiChildren){
					if(f.Name == "CharaImageForm"){
						if(maxRight < f.Left + CharaImageForm.FormSmallWidth){
							maxRight = f.Left + CharaImageForm.FormSmallWidth;
						}
					}
				}
			}
			return(maxRight);
		}
		#endregion
		
		#region もし子ウィンドウに重ね合わせがあったら、更新
		public void UpdateLapForm()
		{
			if(this.MdiChildren.Length > 0){
				foreach(Form f in this.MdiChildren){
					if(f.Name == "LapForm"){
						LapForm lf = (LapForm)f;
						lf.MakeViewBitmap();
						lf.Refresh();
					}
				}
			}
		}
		#endregion
		
		#region 開いているフォームから新しい無題番号をGetする
		static bool HasString(string target, string word)
		{
    		if (word == "")
      			return false;
    		if (target.IndexOf(word) >= 0) {
      			return true;
    		} else {
      			return false;
    		}
  		}
		public int GetTitleNo(string WindowName)
		{
			return(windowsList.GetNonTitleNo(WindowName));
		}
		#endregion
		
		#region 【デバッグ用】カレントディレクトリの情報とフレームワークの取得
		void DebugDirectoryInfo()
		{
			DebugForm df = new DebugForm();
			df.MdiParent = this;
			df.Show();
		}
		#endregion
		
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
		
		#region 起動ログ送信
		void StartLog_Send()
		{
			const string url = @"http://characom.sakuraweb.com/insertLog.php";

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
			ps.Add("BuildDate", lblBuild);
			try{
				//データを送信し、また受信する
				byte[] resData = wc.UploadValues(url, ps);
			}catch{
				Network = false;
			}
			wc.Dispose();
			
			//受信したデータを表示する
			//string resText = System.Text.Encoding.UTF8.GetString(resData);
			//Console.WriteLine(resText);
		}
		#endregion

		#region バージョン確認
		//親となる呼び出しメソッドには非同期メソッドである必要があります(asyncが必要)
		private static async Task getrequest(string url)
		{
			System.Diagnostics.Debug.WriteLine("---------");
		    var client = new HttpClient();
		    System.Diagnostics.Debug.WriteLine("----1-----");
		    // タイムアウト時間の設定(3秒)
         	client.Timeout = TimeSpan.FromMilliseconds(300);

         	System.Diagnostics.Debug.WriteLine("----2-----");
		    try
            {
                // このブログへGETアクセス
                System.Diagnostics.Debug.WriteLine("----3-----");
		    	var response = await client.GetStringAsync(url);
            	System.Diagnostics.Debug.WriteLine("----4-----");
		       	System.Diagnostics.Debug.WriteLine("res = " +response);
		       	System.Diagnostics.Debug.WriteLine("----5-----");
		    
            }
            catch (TaskCanceledException e)
            {
                // タイムアウトの場合、TaskCancelExceptionがスローされる
                System.Diagnostics.Debug.WriteLine("----6-----");
		    	System.Diagnostics.Debug.WriteLine(e.Message);
                System.Diagnostics.Debug.WriteLine("----7-----");
		    	System.Diagnostics.Debug.WriteLine("タイムアウトです");
            }
            
            //awaitが前に必要、非同期処理であるという目印になります
		    //var response = await client.GetAsync(url);
		    //string result = response.Content.ReadAsStringAsync().Result;
		    //System.Diagnostics.Debug.WriteLine("aaa:" + result);
		    //return response;
		}
		void VersionCheck()
		{
			// Version情報を取得
			System.Reflection.Assembly     assembly = Assembly.GetExecutingAssembly();
			System.Reflection.AssemblyName asmName  = assembly.GetName();
			System.Version                 version  = asmName.Version;
 			
			bool updateStart = true;
			string text = version.ToString();
			string[] Commands = System.Environment.GetCommandLineArgs();
			if(Commands.Length > 1){
				if(Commands[1] == "true"){
					updateStart = false;
				}
			}
			if(updateStart){
				// CharacomUpdaterを起動
				ProcessStartInfo pInfo = new ProcessStartInfo();
            	pInfo.FileName = "appUpdater.exe";
            	pInfo.Arguments = text + " " + Setup.BForceUpdate;
    
            	Process p = Process.Start(pInfo);
            	p.WaitForExit();
			}
            
		}
		#endregion
		
		#region メインフォームロード時の処理
		void MainFormLoad(object sender, EventArgs e)
		{
			LoadSetup();
			LoadRecently();
			StartLog_Send();
			VersionCheck();
			
			
			this.comboColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.comboColor.DrawItem += new DrawItemEventHandler(comboColorDrawItem);
			SetColorTbl(comboColor);
			comboColor.SelectedIndex = 0;
			
			
			//2021.08.30 D.Honjyou ウィンドウの位置とサイズを指定
			System.Diagnostics.Debug.WriteLine("StartRect = " + Setup.RWindowBounds.ToString());
			this.Bounds = Setup.RWindowBounds;
			if(this.Height < 300 ) this.Height = 300;
			if(this.Width < 300) this.Width = 300;
			System.Diagnostics.Debug.WriteLine("StartRect(Form Load) = " + this.Bounds.ToString());
			/**
			string[] subFolders = System.IO.Directory.GetDirectories(@"C:\Dドライブ\Characom\SharpDevelop\CharacomImagerPro\Documents\筆跡データベース", "*", System.IO.SearchOption.TopDirectoryOnly);
			for(int i=0; i<subFolders.Length; i++){
				subFolders[i] = System.IO.Path.GetFileName(subFolders[i]);
			}
			MessageBox.Show(string.Join(",", subFolders));
			**/
			//DebugDirectoryInfo();
		}
		#endregion
		
		#region メインフォームクローズ時の処理
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			Setup.RWindowBounds = new Rectangle(this.Location.X, this.Location.Y, this.Size.Width, this.Size.Height);
			SaveSetup();
			SaveRecently();
		}
		#endregion
		
		#region ファイルが現在のフォームに存在するか
		public bool IsOpened(string FileName)
		{
			bool rRet = false;
			string ext;
			
			ext = System.IO.Path.GetExtension(FileName);
			if(ext == ".cci"){
				//個別文字
				foreach(Form f in this.MdiChildren){
					if(f.Name == "CharaImageForm"){
						CharaImageForm cif = (CharaImageForm)f;
						cif.Setup = this.Setup;
						if(cif.FileName == FileName){
							cif.Activate();
							rRet = true;
						}
					}
				}
			}else if(ext == ".cki"){
				//照合
				foreach(Form f in this.MdiChildren){
					if(f.Name == "CheckUpForm"){
						CheckUpForm cif = (CheckUpForm)f;
						if(cif.FileName == FileName){
							cif.Activate();
							rRet = true;
						}
					}
				}
			}else if(ext == ".ccl"){
				//重ね合わせ
				foreach(Form f in this.MdiChildren){
					if(f.Name == "LapForm"){
						LapForm cif = (LapForm)f;
						if(cif.FileName == FileName){
							cif.Activate();
							rRet = true;
						}
					}
				}
			}else if(ext == ".cfa"){
				//特徴平均
				foreach(Form f in this.MdiChildren){
					if(f.Name == "AverageMaker"){
						AverageMaker cif = (AverageMaker)f;
						if(cif.FileName == FileName){
							cif.Activate();
							rRet = true;
						}
					}
				}
			}else if(ext == ".civ"){
				//個人内変動
				foreach(Form f in this.MdiChildren){
					if(f.Name == "IntraindividualVariationForm"){
						IntraindividualVariationForm cif = (IntraindividualVariationForm)f;
						cif.Setup = this.Setup;
						if(cif.FileName == FileName){
							cif.Activate();
							rRet = true;
						}
					}
				}
			}else if(ext == ".irc"){
				//変動比較
				foreach(Form f in this.MdiChildren){
					if(f.Name == "RangeCompare"){
						RangeCompare cif = (RangeCompare)f;
						cif.setup = this.Setup;
						if(cif.FileName == FileName){
							cif.Activate();
							rRet = true;
						}
					}
				}
			}
			return(rRet);
		}
		#endregion

		#region ウィンドウリストへ追加する
		public void AddWindow(string Name)
		{
			windows.Add(Name);
		}
		#endregion
		
		#region ウィンドウリストへ追加する
		public int AddWindowList(string winName, string fileName)
		{
			System.Diagnostics.Debug.WriteLine("追加します::" + winName + ":" + fileName);
			return(windowsList.AddWindow(winName, fileName));
		}
		#endregion
		
		#region ウィンドウの名前を変更する
		public void ChangeWindowName(string beforName, string afterName)
		{
			int index = -1;
			foreach(string f in windows){
				if(f == beforName){
					index = windows.IndexOf(f);
				}
			}
			if(index != -1){
				windows[index] = afterName;
			}
		}
		#endregion
		
		#region ウィンドウリストのファイル名を変更する
		public void ChangeWindowListName(int winID, string fileName)
		{
			windowsList.ChangeWindowName(winID, fileName);
		}
		#endregion
		
		#region ウィンドウリストから自分のタイトル名を取得する
		public string GetWindowTitle(int winID)
		{
			return(windowsList.GetWindowTitle(winID));
		}
		#endregion
		
		#region ウィンドウリストから削除する
		public void RemoveWindow(string Name)
		{
			foreach(string f in windows){
				if(f == Name){
					windows.RemoveAt(windows.IndexOf(f));
					break;
				}
			}
		}
		#endregion
		
		#region ウィンドウリストから削除する
		public void RemoveWindowAtID(int id)
		{
			foreach(WindowNameClass wnc in windowsList.List){
				if(wnc.WindowID == id){
					windowsList.RemoveWindowAsID(id);
					break;
				}
			}
		}
		#endregion
		
		#region ウィンドウリストからアクティブにする
		void ActiveFromWindowList(object sender, EventArgs e)
		{
			foreach(Form f in this.MdiChildren){
				if(f.Text == ((ToolStripMenuItem)sender).Text.Substring(4))
					f.Activate();
			}
		}
		#endregion
		
		#region ウィンドウがアクティブかどうかをチェックする
		private bool WindowActiveCheck(string title)
		{
			bool bRet;
			//System.Diagnostics.Debug.WriteLine("ActiveTitle = " + this.ActiveMdiChild.Text + "->" + title);
			if(this.ActiveMdiChild.Text == title.Substring(4)){
				bRet = true;
			}else{
				bRet = false;
			}
			
			return(bRet);
		}
		#endregion
		
		#region ウィンドウリストをメニューに反映する
		public void UpdateWindowMenu()
		{
			int i;
			int count;
			//すべて消す
			count = WindowMenuItems.DropDownItems.Count;
			if(count > 4){
				for(i=0; i<count - 4; i++){
					this.WindowMenuItems.DropDownItems.RemoveAt(4);
				}
			}
			
			//すべて追加
			i = 1;
			foreach(WindowNameClass wnc in windowsList.List){
				ToolStripMenuItem tsm = new ToolStripMenuItem();
				tsm.Text = "&" + i.ToString() + ". " + wnc.TitleName;
				tsm.Click += new EventHandler(this.ActiveFromWindowList);
				tsm.Checked = WindowActiveCheck(tsm.Text);
				this.WindowMenuItems.DropDownItems.Add(tsm);
				i++;
			}
		}
		#endregion
		
		#region 設定ファイルを保存する
		void SaveSetup()
		{
			FileStream fs = new FileStream(MainForm.SetupIniFileName, FileMode.Create, FileAccess.Write);
			BinaryFormatter bf = new BinaryFormatter();
			
			bf.Serialize(fs, Setup);
			fs.Close();
		}
		#endregion
		
		#region 設定ファイルを読み込む
		void LoadSetup()
		{
			if(System.IO.File.Exists(MainForm.SetupIniFileName) == false){
				return;
			}
			FileStream fs = new FileStream(MainForm.SetupIniFileName, FileMode.Open, FileAccess.Read);
			BinaryFormatter bf = new BinaryFormatter();
			
			Setup = (SetupClass)bf.Deserialize(fs);
			fs.Close();
		}
		#endregion
		
		#region 最近使ったファイルを保存する
		void SaveRecently()
		{
			FileStream fs = new FileStream(MainForm.RecentlyIniFileName, FileMode.Create, FileAccess.Write);
			BinaryFormatter bf = new BinaryFormatter();
			
			bf.Serialize(fs, recentlyFile);
			fs.Close();
		}
		#endregion
		
		#region 最近使ったファイルを読み込む
		void LoadRecently()
		{
			if(System.IO.File.Exists(MainForm.RecentlyIniFileName) == false){
				return;
			}
			FileStream fs = new FileStream(MainForm.RecentlyIniFileName, FileMode.Open, FileAccess.Read);
			BinaryFormatter bf = new BinaryFormatter();
			
			recentlyFile = (RecentlyClass)bf.Deserialize(fs);
			fs.Close();
			
			RecentlyForMenu();
		}
		#endregion
		
		#region 最近使ったファイルを開く
		void RecentlyFileOpen(object sender, EventArgs e)
		{
			OpenDataFile(((ToolStripMenuItem)sender).Text.Substring(4));
		}
		#endregion
		
		#region 最近使ったファイルをメニューに反映
		void RecentlyForMenu()
		{
			int i;
			int count;
			//すべて消す
			count = FileMenuItems.DropDownItems.Count;
			if(count > 16){
				for(i=0; i<count - 16; i++){
					this.FileMenuItems.DropDownItems.RemoveAt(14);
				}
			}
			
			//すべて追加
			i = 1;
			foreach(string f in recentlyFile.Files){
				ToolStripMenuItem tsm = new ToolStripMenuItem();
				tsm.Text = "&" + i.ToString() + ". " + f;
				tsm.Click += new System.EventHandler(this.RecentlyFileOpen);
				this.FileMenuItems.DropDownItems.Insert(14, tsm);	
				i++;
			}
		}
		#endregion
		
		#region 最近使ったファイルに追加
		public void AddRecentlyFile(string FileName)
		{
			recentlyFile.AddFileList(FileName);
			RecentlyForMenu();
		}
		#endregion
		
		#region ドラッグアンドドロップ
		void MainFormDragEnter(object sender, DragEventArgs e)
		{
			if(e.Data.GetDataPresent(DataFormats.FileDrop)){
				e.Effect = DragDropEffects.Copy;
			}else{
				e.Effect = DragDropEffects.None;
			}
		}
		
		public int FileNameOverlapCheck(string FormName, string FileName)
		{
			int iRet = 0;
			foreach(Form f in this.MdiChildren){
				if(f.Name == FormName){
					if(FormName == "CharaImageForm"){
						//MatchCollection mc = Regex.Matches(FileName,
						CharaImageForm cif = new CharaImageForm(this);
						cif = (CharaImageForm)f;
						cif.Setup = this.Setup;
						if(cif.FileName == FileName){
							iRet = 1;
						}
						MatchCollection mc = Regex.Matches(cif.FileName, System.IO.Path.GetFileNameWithoutExtension(FileName) + @"-\((?<num>\d+)\).cci", RegexOptions.Singleline);
						foreach(Match m in mc){
							if(iRet < int.Parse(m.Groups["num"].Value)){
								iRet = int.Parse(m.Groups["num"].Value);
							}
						}
					}else if(FormName == "CheckUpForm"){
						MatchCollection mc = Regex.Matches(f.Text, @"- \[無題(?<num>\d+).cki\]", RegexOptions.Singleline);
						foreach(Match m in mc){
							if(iRet < int.Parse(m.Groups["num"].Value)){
								iRet = int.Parse(m.Groups["num"].Value);
							}
						}
					}
				}
			}
			return(iRet);
		}
		
		string FileExtCheck(string ExtName)
		{
			string rStr = "";
			
			if(ExtName == ".cci"){
				rStr = "cif";
			}
			if(ExtName == ".sci"){
				rStr = "sif";
			}
			return(rStr);
		}
		
		string FileBmpCheck(string FileName)
		{
			Bitmap bmp = new Bitmap(FileName);
			string rStr = "";
			
			if(bmp.Height*2 < bmp.Width){
				rStr = "sif";
			}else{
				rStr = "cif";
			}
			return(rStr);
		}
		
		Form FormWhiteCheck(string form_check)
		{
			foreach(Form forms in this.MdiChildren){
				if(form_check == "cif"){
					//個別文字の場合
					if(forms.Name == "CharaImageForm"){
						CharaImageForm work_form = (CharaImageForm)forms;
						if(imageEffect.WhiteCanvasCheck(work_form.SrcBitmap) == false){
							//すでに白いキャンバスのウィンドウがあった場合
							return(forms);
						}
					}
				}else{
					//文字列の場合
					if(forms.Name == "StringImageForm"){
						StringImageForm work_form = (StringImageForm)forms;
						if(imageEffect.WhiteCanvasCheck(work_form.SrcBitmap) == false){
							//すでに白いキャンバスのウィンドウがあった場合
							return(forms);
						}
					}
				}
			}
			return(null);
		}
		
		void MainFormDragDrop(object sender, DragEventArgs e)
		{
			//ドロップされたファイルの名称
			string[] FileName = (string[]) e.Data.GetData(DataFormats.FileDrop, false);
			int ChildNo = 0;
			int LeftPoint = 0;
			
			//2020.01.18 画面投入位置の設定を反映
			if(Setup.LeftIn == true){
				//左端から投入の場合
				//すべての子ウィンドウを右へずらす
				foreach (Form f in this.MdiChildren) {
					if(f.Name == "CharaImageForm"){
						f.Left += f.Width;
					}
				}
				LeftPoint = 0;
			}else{
				//右端から投入の場合
				LeftPoint = CIF_ChildFormMaxRight();
			}
			
			for(int i=0; i < FileName.Length; i++){
				if(imageEffect.IsImageFile(FileName[i])){
					//画像ファイルの場合
					if(FileBmpCheck(FileName[i]) == "cif"){
						//個別文字の画像である場合
						Form white_form = FormWhiteCheck("cif");
						CharaImageForm cif = new CharaImageForm(this);
						if(white_form != null){
							//白キャンバスがあった場合
							DialogResult msg;
							msg = MessageBox.Show("使われていないウィンドウがあります。このウィンドウに開きますか？\n※「いいえ」を選択すると新しいウィンドウに開きます。","Characom Imager Pro", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
							if(msg == DialogResult.Yes){
								cif = (CharaImageForm)white_form;
							}else if(msg == DialogResult.Cancel){
								return;
							}
						}
						cif.ImportFileName = FileName[i];
						string work_name = System.IO.Path.GetDirectoryName(FileName[i]) + "\\" + System.IO.Path.GetFileNameWithoutExtension(FileName[i]) + ".cci";
						int over_num;
						over_num = FileNameOverlapCheck("CharaImageForm", work_name);
						if(over_num > 0){
							work_name = System.IO.Path.GetDirectoryName(work_name) + "\\" + System.IO.Path.GetFileNameWithoutExtension(work_name) + "-(" + (over_num+1).ToString() +").cci";
						}
						//System.Diagnostics.Debug.WriteLine(work_name + "work");
						cif.FileName = work_name;
						cif.PictureFileRead();
						cif.MdiParent = this;
						cif.Setup = this.Setup;
						cif.Top = ChildNo * 30;
						cif.Left = LeftPoint;
						//if(isNewForm)cif.SetNonTitle();
						cif.Show();
						cif.UpdateImageData();
						//cif.Activate();
						//cif.BringToFront();
						cif.Refresh();
						if(chkAllThin.Checked == true){
							ImageProc(CharaImageForm.ProcSaisen);
							cif.SetColor(Setup.DisplayColor[comboColor.SelectedIndex]);
						}
						cif.SetColor(Setup.DisplayColor[comboColor.SelectedIndex]);
						//cif.Refresh();
						ChildNo++;
					}else{
						//文字列の画像である場合
						Form white_form = FormWhiteCheck("sif");
						StringImageForm sif = new StringImageForm(this);
						if(white_form != null){
							//白キャンバスがあった場合
							DialogResult msg;
							msg = MessageBox.Show("使われていないウィンドウがあります。このウィンドウに開きますか？\n※「いいえ」を選択すると新しいウィンドウに開きます。","Characom Imager Pro", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
							if(msg == DialogResult.Yes){
								sif = (StringImageForm)white_form;
							}else if(msg == DialogResult.Cancel){
								return;
							}
						}
						sif.ImportFileName = FileName[i];
						string work_name = System.IO.Path.GetDirectoryName(FileName[i]) + "\\" + System.IO.Path.GetFileNameWithoutExtension(FileName[i]) + ".cci";
						int over_num;
						over_num = FileNameOverlapCheck("StringImageForm", work_name);
						if(over_num > 0){
							work_name = System.IO.Path.GetDirectoryName(work_name) + "\\" + System.IO.Path.GetFileNameWithoutExtension(work_name) + "-(" + (over_num+1).ToString() +").cci";
						}
						sif.FileName = work_name;
						sif.PictureFileRead();
						sif.MdiParent = this;
						sif.Setup = this.Setup;
						sif.Show();
						sif.Activate();
						sif.UpdateImageData();
						sif.Refresh();
						if(chkAllThin.Checked == true){
							ImageProc(CharaImageForm.ProcSaisen);
							//sif.SetColor(Setup.DisplayColor[comboColor.SelectedIndex]);
						}
						
					}
				}
				if(System.IO.Path.GetExtension(FileName[i]) == ".cci"){
					//個別文字データファイルの場合
					Form white_form = FormWhiteCheck("cif");
					CharaImageForm cif = new CharaImageForm(this);
					if(white_form != null){
						//白キャンバスがあった場合
						DialogResult msg;
						msg = MessageBox.Show("使われていないウィンドウがあります。このウィンドウに開きますか？\n※「いいえ」を選択すると新しいウィンドウに開きます。","Characom Imager Pro", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
						if(msg == DialogResult.Yes){
							cif = (CharaImageForm)white_form;
						}else if(msg == DialogResult.Cancel){
							return;
						}
					}
					if(IsOpened(FileName[i]) == false){
						// cciデータファイルの場合
						cif.FileName = FileName[i];
						cif.MdiParent = this;
						cif.Setup = this.Setup;
						cif.OpenCCIData(FileName[i]);
						cif.Show();
						cif.Activate();
						cif.UpdateImageData();
						if(chkAllThin.Checked == true){
							ImageProc(CharaImageForm.ProcSaisen);
							cif.SetColor(Setup.DisplayColor[comboColor.SelectedIndex]);
						}
						
					}
				}
				if(System.IO.Path.GetExtension(FileName[i]) == ".csi"){
					//文字列データファイルの場合
					Form white_form = FormWhiteCheck("sif");
					StringImageForm sif = new StringImageForm(this);
					if(white_form != null){
						//白キャンバスがあった場合
						DialogResult msg;
						msg = MessageBox.Show("使われていないウィンドウがあります。このウィンドウに開きますか？\n※「いいえ」を選択すると新しいウィンドウに開きます。","Characom Imager Pro", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
						if(msg == DialogResult.Yes){
							sif = (StringImageForm)white_form;
						}else if(msg == DialogResult.Cancel){
							return;
						}
					}
					if(IsOpened(FileName[i]) == false){
						// csiデータファイルの場合
						System.Diagnostics.Debug.WriteLine("FileName[i]=" + FileName[i]);
						sif.FileName = FileName[i];
						sif.MdiParent = this;
						sif.Setup = this.Setup;
						sif.OpenCSIData(FileName[i]);
						sif.Show();
						sif.LayoutMdi(0);
						sif.Activate();
						sif.UpdateImageData();
						if(chkAllThin.Checked == true){
							ImageProc(CharaImageForm.ProcSaisen);
							//sif.SetColor(Setup.DisplayColor[comboColor.SelectedIndex]);
						}
						
					}
				}
			}
			//this.LayoutMdi(MdiLayout.Cascade);
		}
		#endregion
		
		#region 画像処理プロセスキッカー
		void ImageProc(int Process){
			if (this.ActiveMdiChild != null){
				if(this.ActiveMdiChild.Name == "CharaImageForm"){
					//個別文字の場合
					CharaImageForm cif;
					cif = (CharaImageForm)this.ActiveMdiChild;
					cif.ImageProc = Process;
					cif.Setup = this.Setup;
					cif.ImageProcessSwitcher();
				
					cif.ImageBox.Invalidate();
				}else if(this.ActiveMdiChild.Name == "StringImageForm"){
					//文字列の場合
					StringImageForm sif;
					sif = (StringImageForm)this.ActiveMdiChild;
					sif.ImageProc = Process;
					sif.Setup = this.Setup;
					sif.ImageProcessSwitcher();
					
					sif.ImageBox.Invalidate();
				}
			}
		}
		#endregion
		
		#region 画像処理ボタン
		void BtnSourceClick(object sender, EventArgs e)
		{
			ImageProc(CharaImageForm.ProcSource);
  		}
		
		void BtnSaisenkaClick(object sender, EventArgs e)
		{
			ImageProc(CharaImageForm.ProcSaisen);
		}
		
		void BtnSyaeiClick(object sender, EventArgs e)
		{
			ImageProc(CharaImageForm.ProcSyaei);
		}
		
		void BtnThermoClick(object sender, EventArgs e)
		{
			ImageProc(CharaImageForm.ProcThermo);
		}
		
		#region 照合
		void BtnCheckUpClick(object sender, EventArgs e)
		{
			CheckUpForm cuf = new CheckUpForm(this);
			
			cuf.MdiParent = this;
			
			cuf.SetNonTitle();
			cuf.Show();
		}
		#endregion
		
		#region 組合せ照合
		void BtnPluralCheckUpClick(object sender, EventArgs e)
		{
			PluralCheckUp pcu = new PluralCheckUp();
			pcu.MdiParent = this;
			pcu.Show();
		}
		#endregion
		
		#region 組合せ照合
		void BtnAverageClick(object sender, EventArgs e)
		{
			AverageMaker amf = new AverageMaker(this);
			amf.MdiParent = this;
			amf.SetNonTitle();
			amf.Show();
		}
		#endregion
		
		#region 個人内変動
		void BtnInteaindividualClick(object sender, EventArgs e)
		{
			IntraindividualVariationForm ivc = new IntraindividualVariationForm(this);
			ivc.MdiParent = this;
			ivc.Setup = this.Setup;
			ivc.SetNonTitle();
			ivc.Show();
		}
		#endregion
		
		void BtnLapClick(object sender, EventArgs e)
		{
			LapForm lpf = new LapForm(this);
			
			lpf.MdiParent = this;
			lpf.SetNonTitle();
			lpf.Show();
		}
		
		void BtnStringLapClick(object sender, EventArgs e)
		{
			StringLapForm slf = new StringLapForm(this);
			
			slf.MdiParent = this;
			slf.SetNonTitle();
			slf.Show();
		}
		
		void BtnFeatureClick(object sender, EventArgs e)
		{
			ImageProc(CharaImageForm.ProcFeature);
		}
		#endregion
		
		#region メインメニュー
		
		#region 各種ファイルを開く処理
		void OpenDataFile(string FileName)
		{
			bool isNewForm;
			System.Diagnostics.Debug.WriteLine("OpenDataFile:"+FileName);
			if(System.IO.Path.GetExtension(FileName) == ".cci"){
				CharaImageForm cif = new CharaImageForm(this);
				if(IsOpened(FileName) == false){
					//MdiChildrenにキャンバスのウィンドウがあるかどうかをチェック
					isNewForm = true;
					foreach(Form cifs in this.MdiChildren){
						if(cifs.Name == "CharaImageForm"){
							CharaImageForm work_cif = (CharaImageForm)cifs;
							if(imageEffect.WhiteCanvasCheck(work_cif.SrcBitmap) == false){
								//すでに白いキャンバスのウィンドウがあった場合は、確認する
								DialogResult msg;
								work_cif.Setup = this.Setup;
								msg = MessageBox.Show("使われていないウィンドウがあります。このウィンドウに開きますか？\n※「いいえ」を選択すると新しいウィンドウに開きます。","Characom Imager Pro", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
								if(msg == DialogResult.Yes){
									cif = work_cif;
									isNewForm = false;
								}else if(msg == DialogResult.Cancel){
									return;
								}
								break;
							}
						}
					}
					if(isNewForm)cif = new CharaImageForm(this);
					cif.MdiParent = this;
					cif.Setup = this.Setup;
					cif.FileName = FileName;
					cif.OpenCCIData(FileName);
					cif.Show();
				}
			}else if(System.IO.Path.GetExtension(FileName) == ".csi"){
				StringImageForm sif = new StringImageForm(this);
				if(IsOpened(FileName) == false){
					//MdiChildrenにキャンバスのウィンドウがあるかどうかをチェック
					isNewForm = true;
					foreach(Form cifs in this.MdiChildren){
						if(cifs.Name == "StringImageForm"){
							StringImageForm work_cif = (StringImageForm)cifs;
							if(imageEffect.WhiteCanvasCheck(work_cif.SrcBitmap) == false){
								//すでに白いキャンバスのウィンドウがあった場合は、確認する
								DialogResult msg;
								work_cif.Setup = this.Setup;
								msg = MessageBox.Show("使われていないウィンドウがあります。このウィンドウに開きますか？\n※「いいえ」を選択すると新しいウィンドウに開きます。","Characom Imager Pro", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
								if(msg == DialogResult.Yes){
									sif = work_cif;
									isNewForm = false;
								}else if(msg == DialogResult.Cancel){
									return;
								}
								break;
							}
						}
					}
					if(isNewForm)sif = new StringImageForm(this);
					sif.MdiParent = this;
					sif.Setup = this.Setup;
					sif.FileName = FileName;
					sif.OpenCSIData(FileName);
					sif.Show();
				}
			}else if(System.IO.Path.GetExtension(FileName) == ".cki"){
				//照合ファイル
				//すでに開いているかどうかチェックして、開いていたらアクティブにするだけ
				if(IsOpened(FileName) == false){
					//照合ファイルを開いて照合フォームをオープン
					CheckUpForm cuf = new CheckUpForm(this);
					cuf.MdiParent = this;
					cuf.FileName = FileName;
					cuf.OpenCKIFile();
					cuf.Show();
				}
			}else if(System.IO.Path.GetExtension(FileName) == ".ccl"){
				//重ね合わせファイル
				if(IsOpened(FileName) == false){
					LapForm cuf = new LapForm(this);
					cuf.MdiParent = this;
					cuf.FileName = FileName;
					cuf.OpenCCLFile();
					cuf.Show();
				}
			}else if(System.IO.Path.GetExtension(FileName) == ".csl"){
				//文字列重ね合わせファイル
				if(IsOpened(FileName) == false){
					StringLapForm cuf = new StringLapForm(this);
					cuf.MdiParent = this;
					cuf.FileName = FileName;
					cuf.OpenCSLFile();
					cuf.Show();
				}
			}else if(System.IO.Path.GetExtension(FileName) == ".cfa"){
				//特徴平均ファイル
				if(IsOpened(FileName) == false){
					AverageMaker cuf = new AverageMaker(this);
					cuf.MdiParent = this;
					cuf.FileName = FileName;
					cuf.OpenCFAFile();
					cuf.Show();
				}
			}else if(System.IO.Path.GetExtension(FileName) == ".civ"){
				//個人内変動ファイル
				if(IsOpened(FileName) == false){
					IntraindividualVariationForm cuf = new IntraindividualVariationForm(this);
					cuf.MdiParent = this;
					cuf.Setup = this.Setup;
					cuf.FileName = FileName;
					cuf.OpenCIVFile();
					cuf.Show();
				}
			}else if(System.IO.Path.GetExtension(FileName) == ".irc"){
				//変動比較ファイル
				if(IsOpened(FileName) == false){
					RangeCompare cuf = new RangeCompare(this);
					cuf.MdiParent = this;
					cuf.setup = this.Setup;
					cuf.FileName = FileName;
					cuf.OpenIRCFile();
					cuf.Show();
				}
			}
		}
		#endregion
		
		#region 【メニュー】開く
		void MenuOpenClick(object sender, EventArgs e)
		{
			CharaImageForm cif = new CharaImageForm(this);
			
			if(openCCIDialog.ShowDialog() == DialogResult.OK){
				OpenDataFile(openCCIDialog.FileName);
			}
		}
		#endregion
		
		#region DB用にデータインポート機能を追加
		public void DBImport(string importFileName)
		{
			//string importFileName = "";
			Bitmap workBmp = new Bitmap(100,100);
			
			/**
			if(openImageDlg.ShowDialog() == DialogResult.OK){
				importFileName = openImageDlg.FileName;
				workBmp = new Bitmap(importFileName);
			}else{
				return;
			}
			**/
			
			CharaImageForm cif = new CharaImageForm(this);
			cif.Setup = this.Setup;
			//MdiChildrenにキャンバスのウィンドウがあるかどうかをチェック
			foreach(Form cifs in this.MdiChildren){
				if(cifs.Name == "CharaImageForm"){
					CharaImageForm work_cif = (CharaImageForm)cifs;
					if(imageEffect.WhiteCanvasCheck(work_cif.SrcBitmap) == false){
						//すでに白いキャンバスのウィンドウがあった場合は、確認する
						DialogResult msg;
						msg = MessageBox.Show("使われていないウィンドウがあります。このウィンドウに開きますか？\n※「いいえ」を選択すると新しいウィンドウに開きます。","Characom Imager Pro", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
						if(msg == DialogResult.Yes){
							cif = work_cif;
						}else if(msg == DialogResult.Cancel){
							return;
						}
						break;
					}
				}
			}
			cif.ImportFileName = importFileName;
			cif.MdiParent = this;
			cif.FileName = System.IO.Path.GetDirectoryName(importFileName) + "\\" + System.IO.Path.GetFileNameWithoutExtension(importFileName) + ".cci";
			cif.PictureFileRead();
			cif.FileName = "";
			cif.SetNonTitle();
			cif.Show();
		}
		#endregion
		
		#region 【メニュー】画像データをインポート
		void MenuImportClick(object sender, EventArgs e)
		{
			string importFileName = "";
			Bitmap workBmp = new Bitmap(100,100);
			
			if(openImageDlg.ShowDialog() == DialogResult.OK){
				importFileName = openImageDlg.FileName;
				workBmp = new Bitmap(importFileName);
			}else{
				return;
			}
			
			if(workBmp.Width > workBmp.Height * 2){
				//横長文字列
				StringImageForm sif = new StringImageForm(this);
				//MdiChildrenにキャンバスのウィンドウがあるかどうかをチェック
				foreach(Form cifs in this.MdiChildren){
					if(cifs.Name == "StringImageForm"){
						StringImageForm work_sif = (StringImageForm)cifs;
						if(imageEffect.WhiteCanvasCheck(work_sif.SrcBitmap) == false){
							//すでに白いキャンバスのウィンドウがあった場合は、確認する
							DialogResult msg;
							msg = MessageBox.Show("使われていないウィンドウがあります。このウィンドウに開きますか？\n※「いいえ」を選択すると新しいウィンドウに開きます。","Characom Imager Pro", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
							if(msg == DialogResult.Yes){
								sif = work_sif;
							}else if(msg == DialogResult.Cancel){
								return;
							}
							break;
						}
					}
				}
				sif.ImportFileName = importFileName;
				sif.Setup = this.Setup;
				sif.MdiParent = this;
				sif.FileName = System.IO.Path.GetDirectoryName(importFileName) + "\\" + System.IO.Path.GetFileNameWithoutExtension(importFileName) + ".csi";
				sif.PictureFileRead();
				sif.Show();
			}
			/**
			else if(workBmp.Height > workBmp.Width * 2){
				//縦長文字列
				StringImageForm sif = new StringImageForm(this);
				
				sif.ImageSizeChange(workBmp.Width, workBmp.Height);
				sif.ImportFileName = importFileName;
				sif.MdiParent = this;
				sif.FileName = System.IO.Path.GetDirectoryName(importFileName) + "\\" + System.IO.Path.GetFileNameWithoutExtension(importFileName) + ".cci";
				sif.PictureFileRead();
				sif.Show();
			}
			**/
			else{
				CharaImageForm cif = new CharaImageForm(this);
				//MdiChildrenにキャンバスのウィンドウがあるかどうかをチェック
				foreach(Form cifs in this.MdiChildren){
					if(cifs.Name == "CharaImageForm"){
						CharaImageForm work_cif = (CharaImageForm)cifs;
						if(imageEffect.WhiteCanvasCheck(work_cif.SrcBitmap) == false){
							//すでに白いキャンバスのウィンドウがあった場合は、確認する
							DialogResult msg;
							msg = MessageBox.Show("使われていないウィンドウがあります。このウィンドウに開きますか？\n※「いいえ」を選択すると新しいウィンドウに開きます。","Characom Imager Pro", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
							if(msg == DialogResult.Yes){
								cif = work_cif;
							}else if(msg == DialogResult.Cancel){
								return;
							}
							break;
						}
					}
				}
				cif.ImportFileName = importFileName;
				cif.MdiParent = this;
				cif.FileName = System.IO.Path.GetDirectoryName(importFileName) + "\\" + System.IO.Path.GetFileNameWithoutExtension(importFileName) + ".cci";
				cif.PictureFileRead();
				cif.Show();
				//if(isNewForm)cif.SetNonTitle();
				//cif.ImportMenuItemClick(sender, e);
			}
		}
		#endregion
		
		#region 【メニュー】閉じる
		void MenuCloseClick(object sender, EventArgs e)
		{
			if(this.ActiveMdiChild != null){
				this.ActiveMdiChild.Close();
			}
		}
		#endregion
		
		#region 【メニュー】すべて閉じる
		void MenuCloseAllClick(object sender, EventArgs e)
		{
			foreach(Form mc in this.MdiChildren){
				mc.Close();
			}
		}
		#endregion
		
		#region 【メニュー】上書き保存
		void MenuSaveClick(object sender, EventArgs e)
		{
			if(this.ActiveMdiChild == null)return;
			if(this.ActiveMdiChild.Name == "CharaImageForm"){
				CharaImageForm cif = new CharaImageForm(this);
				cif = (CharaImageForm)this.ActiveMdiChild;
				cif.SaveMenuItemClick(sender, e);
			}else if(this.ActiveMdiChild.Name == "CheckUpForm"){
				CheckUpForm cuf = new CheckUpForm(this);
				cuf = (CheckUpForm)this.ActiveMdiChild;
				cuf.BtnSaveClick(sender, e);
			}
		}
		#endregion
		
		#region 【メニュー】名前をつけて保存
		void MenuSaveAtClick(object sender, EventArgs e)
		{
			if(this.ActiveMdiChild == null)return;
			if(this.ActiveMdiChild.Name == "CharaImageForm"){
				CharaImageForm cif = new CharaImageForm(this);
				cif = (CharaImageForm)this.ActiveMdiChild;
				cif.SaveMenuItemClick(sender, e);
			}else if(this.ActiveMdiChild.Name == "CheckUpForm"){
				CheckUpForm cuf = new CheckUpForm(this);
				cuf = (CheckUpForm)this.ActiveMdiChild;
				cuf.SaveAsCKIFile(sender, e);
			}
		}
		#endregion
		
		#region 【メニュー】画像として保存
		void MenuImageSaveClick(object sender, EventArgs e)
		{
			if(this.ActiveMdiChild == null)return;
			if(this.ActiveMdiChild.Name == "CharaImageForm"){
				CharaImageForm cif = new CharaImageForm(this);
				cif = (CharaImageForm)this.ActiveMdiChild;
				cif.ImageSaveMenuItemClick(sender, e);
			}else if(this.ActiveMdiChild.Name == "LapForm"){
				LapForm lf = new LapForm(this);
				lf = (LapForm)this.ActiveMdiChild;
				lf.MenuSaveImageClick(sender, e);
			}
		}
		#endregion
		
		#region 【メニュー】ページ設定
		void MenuPageSetupClick(object sender, EventArgs e)
		{
			if(this.ActiveMdiChild == null) return;
			if(this.ActiveMdiChild.Name == "CharaImageForm"){
				CharaImageForm cif = new CharaImageForm(this);
				cif = (CharaImageForm)this.ActiveMdiChild;
				cif.PageSetupMenuIteClick(sender, e);
			}
		}
		#endregion
		
		#region 【メニュー】印刷プレビュー
		void MenuPreviewClick(object sender, EventArgs e)
		{
			if(this.ActiveMdiChild == null) return;
			if(this.ActiveMdiChild.Name == "CharaImageForm"){
				CharaImageForm cif = new CharaImageForm(this);
				cif = (CharaImageForm)this.ActiveMdiChild;
				cif.PreViewMenuItemClick(sender, e);
			}
		}
		#endregion
		
		#region 【メニュー】印刷
		void MenuPrintClick(object sender, EventArgs e)
		{
			if(this.ActiveMdiChild == null) return;
			if(this.ActiveMdiChild.Name == "CharaImageForm"){
				CharaImageForm cif = new CharaImageForm(this);
				cif = (CharaImageForm)this.ActiveMdiChild;
				cif.PrintMenuItemClick(sender, e);
			}
		}
		#endregion
		
		#region 【メニュー】終了
		void MenuExitClick(object sender, EventArgs e)
		{
			this.Close();
		}
		#endregion
		
		#region 【メニュー】コピー
		void MenuCopyClick(object sender, EventArgs e)
		{
			if(this.ActiveMdiChild == null) return;
			if(this.ActiveMdiChild.Name == "CharaImageForm"){
				CharaImageForm cif = (CharaImageForm)this.ActiveMdiChild;
				
				cif.CopyMenuItemClick(sender, e);
			}
			
			if(this.ActiveMdiChild.Name == "LapForm"){
				LapForm lf = (LapForm)this.ActiveMdiChild;
				
				lf.MenuCopyClick(sender, e);
			}
		}
		#endregion
		
		#region 【メニュー】アクティブな小ウィンドウをコピー(クリップボードへ)
		void MenuAcitiveWindowCopy(object sender, EventArgs e)
		{
			if(this.ActiveMdiChild == null) return;
			
			//コントロールの外観を描画するBitmapの作成
			Bitmap bmp = new Bitmap(this.ActiveMdiChild.Width, this.ActiveMdiChild.Height);
			//キャプチャする
			this.ActiveMdiChild.DrawToBitmap(bmp, new Rectangle(0, 0, this.ActiveMdiChild.Width, this.ActiveMdiChild.Height));
			//クリップボードにセットする
			Clipboard.SetImage(bmp);
			
			//後始末
			bmp.Dispose();
		}
		#endregion
		
		#region 【メニュー】原画像
		void MenuSourceClick(object sender, EventArgs e)
		{
			BtnSourceClick(sender, e);
		}
		#endregion
		
		#region 【メニュー】細線化
		void MenuSaisenkaClick(object sender, EventArgs e)
		{
			BtnSaisenkaClick(sender, e);
		}
		#endregion
		
		#region 【メニュー】射影
		void MenuSyaeiClick(object sender, EventArgs e)
		{
			BtnSyaeiClick(sender, e);
		}
		#endregion
		
		#region 【メニュー】サーモグラフィ
		void MenuThermoClick(object sender, EventArgs e)
		{
			BtnThermoClick(sender, e);
		}
		#endregion
		
		#region 【メニュー】照合
		void MenuRecogClick(object sender, EventArgs e)
		{
			BtnCheckUpClick(sender, e);
		}
		#endregion
		
		#region 【メニュー】組合せ照合
		void MenuPluralRecogClick(object sender, EventArgs e)
		{
			BtnPluralCheckUpClick(sender, e);
		}
		#endregion
		
		#region 【メニュー】重ね合わせ
		void MenuLapClick(object sender, EventArgs e)
		{
			BtnLapClick(sender, e);
		}
		#endregion
		
		#region 【メニュー】設定
		void MenuSetupClick(object sender, EventArgs e)
		{
			SetupForm sf = new SetupForm();
			
			sf.setup = _setup;
			sf.StartPosition = FormStartPosition.CenterParent;
			if(sf.ShowDialog() == DialogResult.OK){
				foreach(Form f in this.MdiChildren){
					if(f.Name == "CharaImageForm"){
						CharaImageForm cif = new CharaImageForm(this);
						cif = (CharaImageForm)f;
						cif.Setup = this.Setup;
					}else if(f.Name == "IntraindividualVariationForm"){
						IntraindividualVariationForm cif = new IntraindividualVariationForm(this);
						cif = (IntraindividualVariationForm)f;
						cif.Setup = this.Setup;
					}else if(f.Name == "RangeCompare"){
						RangeCompare cif = new RangeCompare(this);
						cif.setup = this.Setup;
					}
					f.Refresh();
				}
			}
		}
		#endregion
		
		#region 【メニュー】上下に並べて表示
		void MenuUpDownAlignClick(object sender, EventArgs e)
		{
			this.LayoutMdi(MdiLayout.TileHorizontal);
		}
		#endregion
		
		#region 【メニュー】左右に並べて表示
		void MenuLRAlignClick(object sender, EventArgs e)
		{
			this.LayoutMdi(MdiLayout.TileVertical);
		}
		#endregion
		
		#region 【メニュー】重ねて表示
		void MenuOverAlignClick(object sender, EventArgs e)
		{
			this.LayoutMdi(MdiLayout.Cascade);
		}
		#endregion
		
		#region 【メニュー】Characomヘルプ
		void MenuCharacomHelpClick(object sender, EventArgs e)
		{
			//Help.ShowHelp(this, "CCI_Help.chm");
		}
		#endregion
		
		#region 【メニュー】オンラインヘルプ
		void MenuOnlineHelpClick(object sender, EventArgs e)
		{
			//Help.ShowHelpIndex(this, "CCI_Help.chm");
		}
		#endregion
		
		#region 【メニュー】バージョン情報
		void MenuVersionClick(object sender, EventArgs e)
		{
			VersionInfoForm vif = new VersionInfoForm();
			vif.StartPosition = FormStartPosition.CenterParent;
			vif.ShowDialog();
		}
		#endregion
		
		#region 【メニュー】元に戻す
		void MenuUndoClick(object sender, EventArgs e)
		{
			if(this.ActiveMdiChild == null){
				return;
			}
				
			if(this.ActiveMdiChild.Name == "CharaImageForm"){
				CharaImageForm cif = new CharaImageForm(this);
				cif = (CharaImageForm)this.ActiveMdiChild;
				
				cif.UndoMenuItemClick(sender, e);
				menuUndo.Enabled = cif.undoManager.CanUndo();
				menuRedo.Enabled = cif.undoManager.CanRedo();
			}	
			
			if(this.ActiveMdiChild.Name == "CheckUpForm"){
				CheckUpForm cuf = new CheckUpForm(this);
				cuf = (CheckUpForm)this.ActiveMdiChild;
				
				cuf.BtnUndoClick(sender, e);
				menuUndo.Enabled = cuf.undoManager.CanUndo();
				menuRedo.Enabled = cuf.undoManager.CanRedo();
			}
			
			if(this.ActiveMdiChild.Name == "LapForm"){
				LapForm cuf = new LapForm(this);
				cuf = (LapForm)this.ActiveMdiChild;
				
				cuf.BtnUndoClick(sender, e);
				menuUndo.Enabled = cuf.undoManager.CanUndo();
				menuRedo.Enabled = cuf.undoManager.CanRedo();
			}
		}
		#endregion
		
		#region 【メニュー】やり直し
		void MenuRedoClick(object sender, EventArgs e)
		{
			if(this.ActiveMdiChild == null){
				return;
			}
				
			if(this.ActiveMdiChild.Name == "CharaImageForm"){
				CharaImageForm cif = new CharaImageForm(this);
				cif = (CharaImageForm)this.ActiveMdiChild;
				
				cif.RedoMenuItemClick(sender, e);
				menuUndo.Enabled = cif.undoManager.CanUndo();
				menuRedo.Enabled = cif.undoManager.CanRedo();
			}	
			
			if(this.ActiveMdiChild.Name == "CheckUpForm"){
				CheckUpForm cuf = new CheckUpForm(this);
				cuf = (CheckUpForm)this.ActiveMdiChild;
				
				cuf.BtnRedoClick(sender, e);
				menuUndo.Enabled = cuf.undoManager.CanUndo();
				menuRedo.Enabled = cuf.undoManager.CanRedo();
			}
			
			if(this.ActiveMdiChild.Name == "LapForm"){
				LapForm cuf = new LapForm(this);
				cuf = (LapForm)this.ActiveMdiChild;
				
				cuf.BtnRedoClick(sender, e);
				menuUndo.Enabled = cuf.undoManager.CanUndo();
				menuRedo.Enabled = cuf.undoManager.CanRedo();
			}
		}
		#endregion
		#endregion
		
		#region 個人内変動ボタン
		void BtnRangeCompareClick(object sender, EventArgs e)
		{
			RangeCompare rc = new RangeCompare(this);
			rc.MdiParent = this;
			rc.setup = this.Setup;
			rc.SetNonTitle();
			rc.Show();
		}
		#endregion
		
		#region メインメニューの【ファイル】が開かれたとき
		void FileMenuItemsDropDownOpened(object sender, EventArgs e)
		{
			if(this.ActiveMdiChild == null) return;
			//【個別文字】画面
			if(this.ActiveMdiChild.Name == "CharaImageForm"){
				NewFileMenuItem.Enabled = true;
				menuOpen.Enabled = true;
				menuImport.Enabled = true;
				menuClose.Enabled = true;
				menuCloseAll.Enabled = true;
				//--
				menuSave.Enabled = true;
				menuSaveAt.Enabled = true;
				menuImageSave.Enabled = true;
				//--
				menuPageSetup.Enabled = true;
				menuPreview.Enabled = true;
				menuPrint.Enabled = true;
				//--
				menuExit.Enabled = true;
			}
			//【文字列】画面
			if(this.ActiveMdiChild.Name == "StringImageForm"){
				NewFileMenuItem.Enabled = true;
				menuOpen.Enabled = true;
				menuImport.Enabled = true;
				menuClose.Enabled = true;
				menuCloseAll.Enabled = true;
				//--
				menuSave.Enabled = true;
				menuSaveAt.Enabled = true;
				menuImageSave.Enabled = true;
				//--
				menuPageSetup.Enabled = false;
				menuPreview.Enabled = false;
				menuPrint.Enabled = false;
				//--
				menuExit.Enabled = true;
			}
			//【照合】画面
			else if(this.ActiveMdiChild.Name == "CheckUpForm"){
				NewFileMenuItem.Enabled = true;
				menuOpen.Enabled = true;
				menuImport.Enabled = true;
				menuClose.Enabled = true;
				menuCloseAll.Enabled = true;
				//--
				menuSave.Enabled = true;
				menuSaveAt.Enabled = true;
				menuImageSave.Enabled = true;
				//--
				menuPageSetup.Enabled = true;
				menuPreview.Enabled = true;
				menuPrint.Enabled = true;
				//--
				menuExit.Enabled = true;
			}
			//【組合せ照合】画面
			else if(this.ActiveMdiChild.Name == "PluralCheckUp"){
				NewFileMenuItem.Enabled = true;
				menuOpen.Enabled = true;
				menuImport.Enabled = true;
				menuClose.Enabled = true;
				menuCloseAll.Enabled = true;
				//--
				menuSave.Enabled = true;
				menuSaveAt.Enabled = true;
				menuImageSave.Enabled = true;
				//--
				menuPageSetup.Enabled = true;
				menuPreview.Enabled = true;
				menuPrint.Enabled = true;
				//--
				menuExit.Enabled = true;
			}
			//【重ね合わせ】画面
			else if(this.ActiveMdiChild.Name == "LapForm"){
				NewFileMenuItem.Enabled = true;
				menuOpen.Enabled = true;
				menuImport.Enabled = true;
				menuClose.Enabled = true;
				menuCloseAll.Enabled = true;
				//--
				menuSave.Enabled = true;
				menuSaveAt.Enabled = true;
				menuImageSave.Enabled = true;
				//--
				menuPageSetup.Enabled = true;
				menuPreview.Enabled = true;
				menuPrint.Enabled = true;
				//--
				menuExit.Enabled = true;
			}
			//【文字列重ね合わせ】画面
			else if(this.ActiveMdiChild.Name == "StringLapForm"){
				NewFileMenuItem.Enabled = true;
				menuOpen.Enabled = true;
				menuImport.Enabled = true;
				menuClose.Enabled = true;
				menuCloseAll.Enabled = true;
				//--
				menuSave.Enabled = true;
				menuSaveAt.Enabled = true;
				menuImageSave.Enabled = true;
				//--
				menuPageSetup.Enabled = true;
				menuPreview.Enabled = true;
				menuPrint.Enabled = true;
				//--
				menuExit.Enabled = true;
			}
			//【特徴平均】画面
			else if(this.ActiveMdiChild.Name == "AverageMaker"){
				NewFileMenuItem.Enabled = true;
				menuOpen.Enabled = true;
				menuImport.Enabled = true;
				menuClose.Enabled = true;
				menuCloseAll.Enabled = true;
				//--
				menuSave.Enabled = true;
				menuSaveAt.Enabled = true;
				menuImageSave.Enabled = true;
				//--
				menuPageSetup.Enabled = true;
				menuPreview.Enabled = true;
				menuPrint.Enabled = true;
				//--
				menuExit.Enabled = true;
			}
			//【個人内変動】画面
			else if(this.ActiveMdiChild.Name == "IntraindividualVariationForm"){
				NewFileMenuItem.Enabled = true;
				menuOpen.Enabled = true;
				menuImport.Enabled = false;
				menuClose.Enabled = true;
				menuCloseAll.Enabled = true;
				//--
				menuSave.Enabled = true;
				menuSaveAt.Enabled = true;
				menuImageSave.Enabled = false;
				//--
				menuPageSetup.Enabled = true;
				menuPreview.Enabled = true;
				menuPrint.Enabled = true;
				//--
				menuExit.Enabled = true;
			}
			//【変動比較】画面
			else if(this.ActiveMdiChild.Name == "RangeCompare"){
				NewFileMenuItem.Enabled = true;
				menuOpen.Enabled = true;
				menuImport.Enabled = false;
				menuClose.Enabled = true;
				menuCloseAll.Enabled = true;
				//--
				menuSave.Enabled = true;
				menuSaveAt.Enabled = true;
				menuImageSave.Enabled = true;
				//--
				menuPageSetup.Enabled = true;
				menuPreview.Enabled = true;
				menuPrint.Enabled = true;
				//--
				menuExit.Enabled = true;
			}
		}
		#endregion
		
		#region メインメニューの【編集】が開かれたとき
		void EditToolStripMenuItemDropDownOpened(object sender, EventArgs e)
		{
			if(this.ActiveMdiChild == null){
				menuCopy.Enabled = false;
				menuUndo.Enabled = false;
				menuRedo.Enabled = false;
				return;
			}
			menuCopy.Enabled = true;
				
			if(this.ActiveMdiChild.Name == "CharaImageForm"){
				CharaImageForm cif = new CharaImageForm(this);
				cif = (CharaImageForm)this.ActiveMdiChild;
				
				menuUndo.Enabled = cif.undoManager.CanUndo();
				menuRedo.Enabled = cif.undoManager.CanRedo();
			}	
			
			if(this.ActiveMdiChild.Name == "CheckUpForm"){
				CheckUpForm cuf = new CheckUpForm(this);
				cuf = (CheckUpForm)this.ActiveMdiChild;
				
				menuUndo.Enabled = cuf.undoManager.CanUndo();
				menuRedo.Enabled = cuf.undoManager.CanRedo();
			}
			
			if(this.ActiveMdiChild.Name == "LapForm"){
				LapForm cuf = new LapForm(this);
				cuf = (LapForm)this.ActiveMdiChild;
				
				menuUndo.Enabled = cuf.undoManager.CanUndo();
				menuRedo.Enabled = cuf.undoManager.CanRedo();
			}
		}
		#endregion
		
		#region メインメニューの【表示】が開かれたとき
		void ViewMenuItemsDropDownOpened(object sender, EventArgs e)
		{
			
		}
		#endregion
		
		#region メインメニューの【ウィンドウ】が開かれたとき
		void WindowMenuItemsDropDownOpened(object sender, EventArgs e)
		{
			UpdateWindowMenu();
		}
		#endregion
		
		#region メインメニューの【ヘルプ】が開かれたとき
		void HelpMenuItemsDropDownOpened(object sender, EventArgs e)
		{
			
		}
		#endregion
		
		
		void BtnHaikeiClick(object sender, EventArgs e)
		{
			ImageProc(CharaImageForm.ProcHaikei);
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			//テスト用ボタン
			for(int i=0; i<Setup.DisplayColor.Length; i++){
				Color c = Setup.DisplayColor[i];
				System.Diagnostics.Debug.WriteLine(String.Format("DisplayColor[{0}] = Color.FromArgb({1},{2},{3},{4});", i, c.A, c.R, c.G, c.B));
			}
		}
		
		#region 【メニュー】新規作成群
		public void MenuCharaNewClick(object sender, EventArgs e)
		{
			CharaImageForm cif = new CharaImageForm(this);
			
			cif.MdiParent = this;
			cif.Setup = this.Setup;
			cif.SetNonTitle();
			cif.Show();
		}
		//文字列新規作成
		public void MenuStringNewClick(object sender, EventArgs e)
		{
			StringImageForm sif = new StringImageForm(this);
			sif.MdiParent = this;
			sif.Setup = this.Setup;
			sif.SetNonTitle();
			sif.Show();
		}
		
		public void MenuLapNewClick(object sender, EventArgs e)
		{
			LapForm lf = new LapForm(this);
			
			lf.MdiParent = this;
			lf.SetNonTitle();
			lf.Show();
		}
		
		public void MenuSLapClick(object sender, EventArgs e)
		{
			StringLapForm slf = new StringLapForm(this);
			
			slf.MdiParent = this;
			slf.SetNonTitle();
			slf.Show();
		}
		
		void MenuAverageNewClick(object sender, EventArgs e)
		{
			AverageMaker cif = new AverageMaker(this);
			
			cif.MdiParent = this;
			cif.SetNonTitle();
			cif.Show();
		}
		
		void MenuCheckupNewClick(object sender, EventArgs e)
		{
			CheckUpForm cif = new CheckUpForm(this);
			
			cif.MdiParent = this;
			cif.SetNonTitle();
			cif.Show();
		}
		
		void MenuPluralNewClick(object sender, EventArgs e)
		{
			PluralCheckUp cif = new PluralCheckUp();
			
			cif.MdiParent = this;
			//cif.SetNonTitle();
			cif.Show();
		}
		
		void MenuIndividualNewClick(object sender, EventArgs e)
		{
			IntraindividualVariationForm cif = new IntraindividualVariationForm(this);
			
			cif.MdiParent = this;
			cif.Setup = this.Setup;
			cif.SetNonTitle();
			cif.Show();
		}
		
		void MenuRangeNewClick(object sender, EventArgs e)
		{
			RangeCompare cif = new RangeCompare(this);
			
			cif.MdiParent = this;
			cif.setup = this.Setup;
			cif.SetNonTitle();
			cif.Show();
		}
		#endregion
		
		#region アクティブなウインドウが変わったとき
		void MainFormMdiChildActivate(object sender, EventArgs e)
		{
			if(this.ActiveMdiChild == null) return;
			System.Diagnostics.Debug.WriteLine("ActiveChange:[" + this.ActiveMdiChild.Name + "]");
			if(this.ActiveMdiChild.Name == "CharaImageForm"){
				btnSource.Enabled = true;
				btnSaisenka.Enabled = true;
				btnSyaei.Enabled = true;
				btnFeature.Enabled = true;
				btnThermo.Enabled = true;
				btnHaikei.Enabled = true;
			}else if(this.ActiveMdiChild.Name == "StringImageForm"){
				btnSource.Enabled = true;
				btnSaisenka.Enabled = true;
				btnSyaei.Enabled = true;
				btnFeature.Enabled = false;
				btnThermo.Enabled = true;
				btnHaikei.Enabled = false;
			}else{
				btnSource.Enabled = false;
				btnSaisenka.Enabled = false;
				btnSyaei.Enabled = false;
				btnFeature.Enabled = false;
				btnThermo.Enabled = false;
				btnHaikei.Enabled = false;
			}
		}
		#endregion
		
		void MenuDBClick(object sender, EventArgs e)
		{
			if(Setup.StrDBDir == ""){
				MessageBox.Show("データベースの保存場所を設定してください。\n表示メニューから設定を開いて設定して下さい。","CharacomImagerPro エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			DBViewForm dbvf = new DBViewForm(this);
			dbvf.MdiParent = this;
			dbvf.Show();
		}
		
		void BtnDBViewClick(object sender, EventArgs e)
		{
			if(Setup.StrDBDir == ""){
				MessageBox.Show("データベースの保存場所を設定してください。\n表示メニューから設定を開いて設定して下さい。","CharacomImagerPro エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			DBViewForm dbvf = new DBViewForm(this);
			dbvf.MdiParent = this;
			dbvf.Show();
		}
		
		void BtnInputCharaClick(object sender, EventArgs e)
		{
			InputCharaForm icf = new InputCharaForm(this);
			icf.MdiParent = this;
			icf.Show();
		}
		#region 標準書体メニュー
		void MenuStandardImageClick(object sender, EventArgs e)
		{
			if(Setup.StrStandardDir == ""){
				MessageBox.Show("標準書体の格納場所を設定してください。\n表示メニューから設定を開いて設定して下さい。","CharacomImagerPro エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			StanderdImageForm sif = new StanderdImageForm((MainForm)this);
			sif.MdiParent = this;
			sif.Standard_or_stroke = 0;
			sif.Show();
		}
		#endregion
		
		#region 筆順画像メニュー
		void MenuStrokeImageClick(object sender, EventArgs e)
		{
			if(Setup.StrStrokeDir == ""){
				MessageBox.Show("標準書体の格納場所を設定してください。\n表示メニューから設定を開いて設定して下さい。","CharacomImagerPro エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			StanderdImageForm sif = new StanderdImageForm((MainForm)this);
			sif.MdiParent = this;
			sif.Standard_or_stroke = 1;
			sif.Show();
		}
		#endregion
		
		void TestMenuClick(object sender, EventArgs e)
		{
			//デバッグテスト
			this.Parent = this;
		}
		
		
		
		void MenuAllImposeClick(object sender, EventArgs e)
		{
			LapForm lpf = new LapForm(this);
			
			lpf.MdiParent = this;
			lpf.SetNonTitle();
			lpf.Show();
			
			foreach(Form child in this.MdiChildren){
				if(child.Name == "CharaImageForm"){
					lpf.InputLapForm((CharaImageForm)child);
					//System.Diagnostics.Debug.WriteLine("インプット");
				}
			}
			
			
		}
		
		void BtnStartClick(object sender, EventArgs e)
		{
			timer1.Interval = 100;
			wData.Clear();
			timer1.Start();
		}
		
		void BtnStopClick(object sender, EventArgs e)
		{
			timer1.Stop();
		}
		
		void Timer1Tick(object sender, EventArgs e)
		{
			WinTabClass wtdata = new WinTabClass();
			
			wtdata = wtWinTabData;
			wtdata.Pressuer = 5;
			wData.Add(wtdata);
			System.Diagnostics.Debug.WriteLine(wtdata.Pressuer.ToString());
		}
		
		#region ウィンドウをコピー
		// 2020.09.02 D.Honjyou 三崎さんからの要望により追加
		void BtnWindowCopyClick(object sender, EventArgs e)
		{
			MenuWindowCopyClick(sender, e);
		}
		
		void MenuWindowCopyClick(object sender, EventArgs e)
		{
			//フォームからスクリーンショットを撮る　
			Bitmap clipBmp = new Bitmap(this.Width, this.Height);
			this.DrawToBitmap(clipBmp, new Rectangle(0, 0, this.Width, this.Height));
			Clipboard.SetImage(clipBmp);
			
			clipBmp.Dispose();
		}
		
		#endregion
	}
}
