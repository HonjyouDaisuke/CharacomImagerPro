/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2012/01/25
 * 時刻: 16:56
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Drawing;

namespace CharacomImagerPro
{
	/// <summary>
	/// Description of CheckUpClass.
	/// </summary>
	public class CheckUpClass
	{
		//プロパティ
		//特徴データ
		double [] kajyuA = new double[256];
		double [] kajyuB = new double[256];
		public double[] KajyuB {
			get { return kajyuB; }
			set { kajyuB = value; }
		}
		public double[] KajyuA {
			get { return kajyuA; }
			set { kajyuA = value; }
		}
		
		//類似度・距離データ
		double ruijido;
		double distance;
		public double Ruijido {
			get { return ruijido; }
			set { ruijido = value; }
		}
		public double Distance {
			get { return distance; }
			set { distance = value; }
		}
		
		//サンプル画像データ
		Bitmap srcBitmap;
		public Bitmap SrcBitmap {
			get { return srcBitmap; }
			set { srcBitmap = value; }
		}
		
		public CheckUpClass()
		{
		}
	}
}
