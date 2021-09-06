/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2012/04/06
 * 時刻: 10:25
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Collections;
using System.Drawing;

namespace CharacomImagerPro
{
	/// <summary>
	/// Description of IndividualClass.
	/// </summary>
	[Serializable]
	public class IndividualClass
	{
		ArrayList _charas = new ArrayList();
		private string _title;
		private Color _viewColor;
		
		public ArrayList Charas {
			get { return _charas; }
			set { _charas = value; }
		}
		
		public string Title {
			get { return _title; }
			set { _title = value; }
		}
		
		public Color ViewColor {
			get { return _viewColor; }
			set { _viewColor = value; }
		}
		
		public void AddChara(RRangeClass rrc)
		{
			_charas.Add(rrc);
		}
		
		public int MaxLength {
			get{
				int max = 0;
				foreach(RRangeClass rrc in _charas){
					if(rrc.ItemsR.Count > max) max = rrc.ItemsR.Count;
				}
				return max;
			}
		}
		public IndividualClass()
		{
		}
	}
}
