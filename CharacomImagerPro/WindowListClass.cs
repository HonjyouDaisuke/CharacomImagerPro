/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2012/04/12
 * 時刻: 13:43
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Collections;

namespace CharacomImagerPro
{
	
	public class WindowNameClass
	{
		private string _fullFileName;
		private string _windowName;
		private int _windowID;
		
		
		#region プロパティ
		public string FullFileName {
			get { return _fullFileName; }
			set { _fullFileName = value; }
		}
		
		public string ViewFileName {
			get {
				if(_fullFileName == ""){
					return("");
				}else{
					return(System.IO.Path.GetFileName(_fullFileName));
				}
			}
		}
		
		public string WindowName {
			get { return _windowName; }
			set { _windowName = value; }
		}
		
		public string TitleName {
			get { 
				string name = "";
				System.Diagnostics.Debug.WriteLine("windowName = " + _windowName);
				switch (_windowName) {
					case "CharaImageForm": 					name = "【個別文字】"; break;	//対応済み
					case "StringImageForm": 				name = "【文字列】"; break;	
					case "CheckUpForm": 					name = "【照合】"; break;		//対応済み
					case "FeatureForm": 					name = "【特徴抽出】"; break;	//対応済み
					case "HaikeiDenpanForm": 				name = "【背景伝搬法】"; break;	//対応済み
					case "AverageMaker": 					name = "【特徴平均】"; break;	//対応済み
					case "IntraindividualVariationForm": 	name = "【個人内変動】"; break;	//対応済み
					case "LapForm": 						name = "【個別文字重ね合せ】"; break;	//対応済み
					case "StringLapForm": 					name = "【文字列重ね合せ】"; break;	
					case "PuralCheckUp": 					name = "【組合せ照合】"; break;
					case "RangeCompare": 					name = "【変動比較】"; break;	//対応済み
					default:								name = ""; break;
				}
				return(name + " - " + System.IO.Path.GetFileName(_fullFileName));
			}
		}
		
		public int WindowID {
			get { return _windowID; }
			set { _windowID = value; }
		}
		
		#endregion
	}
	/// <summary>
	/// Description of WindowListClass.
	/// </summary>
	public class WindowListClass
	{
		ArrayList _list = new ArrayList();
		Hashtable NonTitle = new Hashtable();
		
		public ArrayList List {
			get { return _list; }
			set { _list = value; }
		}
		int CurrentWindowID;
		
		public int AddWindow(string winName, string fileName)
		{
			//if(CheckFileName(winName, fileName)) return(-1);
			WindowNameClass wnc = new WindowNameClass();
			
			wnc.FullFileName = fileName;
			wnc.WindowName = winName;
			wnc.WindowID = CurrentWindowID;
			
			_list.Add(wnc);
			
			CurrentWindowID++;
			//System.Diagnostics.Debug.WriteLine("ウィンドウリストに追加しました。 ID[" + wnc.WindowID.ToString() + "]" + wnc.TitleName);
			return(wnc.WindowID);
		}
			
		public void RemoveWindowAsID(int winID)
		{
			foreach(WindowNameClass wnc in _list){
				if(wnc.WindowID == winID){
					_list.Remove(wnc);
					break;
				}
			}
		}
		
		public void ChangeWindowName(int winID, string Name)
		{
			//System.Diagnostics.Debug.WriteLine("winID=" + winID.ToString());
			foreach(WindowNameClass wnc in _list){
				//System.Diagnostics.Debug.WriteLine("wnc.WindowID = " + wnc.WindowID.ToString());
				if(wnc.WindowID == winID){
					wnc.FullFileName = Name;
				}
			}
		}
		
		public string GetWindowTitle(int winID)
		{
			string RetTitle = "";
			foreach(WindowNameClass wnc in _list){
				if(wnc.WindowID == winID){
					RetTitle = wnc.TitleName;
				}
			}
			return(RetTitle);
		}
		private bool CheckFileName(string winName, string fileName)
		{
			bool bRet = false;
			foreach(WindowNameClass wnc in _list){
				if(wnc.FullFileName == fileName && wnc.WindowName == winName){
					bRet = true;
				}
			}
			return(bRet);
		}
		
		#region 無題の番号を取得
		public int GetNonTitleNo(string winName)
		{
			if(NonTitle[winName] == null){
				NonTitle[winName] = 0;
			}
			NonTitle[winName] = (int)NonTitle[winName] + 1;
			System.Diagnostics.Debug.WriteLine("ウィンドウ名:" + winName + " 無題番号:" + NonTitle[winName].ToString());
			return((int)NonTitle[winName]);
		}
		#endregion
		public WindowListClass()
		{
			CurrentWindowID = 0;
		}
	}
}
