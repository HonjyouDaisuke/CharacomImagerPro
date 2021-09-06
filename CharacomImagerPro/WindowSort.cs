/*
 * SharpDevelopによって生成
 * ユーザ: 大介
 * 日付: 2020/01/18
 * 時刻: 10:35
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;

namespace CharacomImagerPro
{
	/// <summary>
	/// Description of WindowSort.
	/// </summary>
	public class WindowSort
	{
		public int ID;
		public int X;
		public int Y;
		public string Name;
		public string Caption;
		
		public WindowSort(int id, int x, int y, string name, string caption){
			this.ID = id;
			this.X = x;
			this.Y = y;
			this.Name = name;
			this.Caption = caption;
		}
	}
}
