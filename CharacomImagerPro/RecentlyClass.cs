/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2011/11/04
 * 時刻: 16:19
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Collections;
namespace CharacomImagerPro
{
	/// <summary>
	/// Description of RecentlyClass.
	/// </summary>
	[Serializable]
	public class RecentlyClass
	{
		private ArrayList files = new ArrayList();
		
		public ArrayList Files {
			get { return files; }
			set { files = value; }
		}
		
		#region ファイルがすでにリストに存在するかどうかのチェック
		private bool CheckFileName(string FileName)
		{
			bool bRet = false;
			
			foreach(string f in files){
				if(f == FileName) bRet = true;
			}
			
			return(bRet);
		}
		#endregion
		
		#region ファイルを追加
		public bool AddFileList(string FileName)
		{
			bool bRet = false;
			
			if(CheckFileName(FileName) == false){
				files.Add(FileName);
				bRet = true;
				if(files.Count > 5){
					files.RemoveAt(0);
				}
			}
			return(bRet);
		}
		#endregion
		
		public RecentlyClass()
		{
		}
	}
}
