/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2011/10/17
 * 時刻: 16:55
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Drawing;

namespace CharacomImagerPro
{
	/// <summary>
	/// Description of FeatureClass.
	/// </summary>
	[Serializable]
	public class FeatureClass
	{
		//プロパティ
		Bitmap srcBitmap;
		public Bitmap SrcBitmap {
			get { return srcBitmap; }
			set { srcBitmap = value; }
		}
		
		double [] kajyu = new double[256];
		public double[] Kajyu {
			get { return kajyu; }
			set { kajyu = value; }
		}
		
		double [] kajyuView = new double[256];
		public double[] KajyuView {
			get { return kajyuView; }
			set { kajyuView = value; }
		}
		
		double [] haikei = new double[512];		
		public double[] Haikei {
			get { return haikei; }
			set { haikei = value; }
		}
		
		double [] haikeiView = new double[512];		
		public double[] HaikeiView {
			get { return haikeiView; }
			set { haikeiView = value; }
		}

		double r;
		public double R {
			get { return r; }
			set { r = value; }
		}
		
		double r2;		
		public double R2 {
			get { return r2; }
			set { r2 = value; }
		}
		
		string fileName;		
		public string FileName {
			get { return fileName; }
			set { fileName = value; }
		}
		
		public FeatureClass()
		{
		}
	}
}
