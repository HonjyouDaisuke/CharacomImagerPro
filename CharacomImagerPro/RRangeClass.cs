/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2012/04/05
 * 時刻: 19:17
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Collections;
using System.Drawing;
namespace CharacomImagerPro
{
	/// <summary>
	/// Description of RRangeClass.
	/// </summary>
	[Serializable]
	public class RRangeClass
	{
		//プロパティ
		private ArrayList _itemsR = new ArrayList();
		private ArrayList _itemsR2 = new ArrayList();
		private ArrayList _itemsKajyu = new ArrayList();
		private ArrayList _documentTitles = new ArrayList();
		private ArrayList _charaColors = new ArrayList();
		
		private string _title;
		private Color _viewColor;
		
		double GetMaxR()
		{
			double max = 0.0;
			foreach(double r in _itemsR){
				if(max < r) max = r;
			}
			return(max);
		}
		
		double GetMinR()
		{
			double min = 500.0;
			foreach(double r in _itemsR){
				if(min > r) min = r;
			}
			return(min);
		}
		
		double GetMaxR2()
		{
			double max = 0.0;
			foreach(double r in _itemsR2){
				if(max < r) max = r;
			}
			
			return(max);
		}
		
		double GetMinR2()
		{
			double min = 500.0;
			foreach(double r in _itemsR2){
				if(min > r) min = r;
			}
			return(min);
		}
		
		double GetAverage()
		{
			double sum = 0.0;
			foreach(double r in _itemsR){
				sum += r;
			}
			if( _itemsR.Count > 0) return(sum / _itemsR.Count);
			else				   return(0.0);
		}
		
		double GetAverageR2()
		{
			double sum = 0.0;
			foreach(double r in _itemsR2){
				sum += r;
			}
			if( _itemsR2.Count > 0) return(sum / _itemsR2.Count);
			else				   return(0.0);
		}
		
		double [] GetKajyuAverage()
		{
			double[] avg = new double[256];
			double sum = 0.0;
			
			for(int i=0; i<256; i++){
				sum = 0.0;
				foreach(double [] k in _itemsKajyu){
					sum += k[i];
				}
				if( _itemsKajyu.Count > 0) 	avg[i] = sum / _itemsKajyu.Count;
				else						avg[i] = 0.0;
				
			}
			return(avg);
		}
		
		double [] GetHaikeiAverage()
		{
			double[] avg = new double[512];
			double sum = 0.0;
			
			for(int i=0; i<256; i++){
				sum = 0.0;
				foreach(double [] k in _itemsKajyu){
					sum += k[i];
				}
				if( _itemsKajyu.Count > 0) 	avg[i] = sum / _itemsKajyu.Count;
				else						avg[i] = 0.0;
				
			}
			return(avg);
		}
		
		public ArrayList DocumentTitles {
			get { return _documentTitles; }
			set { _documentTitles = value; }
		}
		
		public ArrayList ItemsR {
			get { return _itemsR; }
			set { _itemsR = value; }
		}
		
		public ArrayList ItemsR2 {
			get { return _itemsR2; }
			set { _itemsR2 = value; }
		}
		
		public ArrayList CharaColors {
			get { return _charaColors; }
			set { _charaColors = value; }
		}
		
		public ArrayList ItemsKajyu {
			get { return _itemsKajyu; }
			set { _itemsKajyu = value; }
		}
		
		public void AddData(string documentTitle, Color c, double R, double R2, double[] kajyu)
		{
			System.Diagnostics.Debug.WriteLine("itemsR.Add");
			_itemsR.Add(R);
			System.Diagnostics.Debug.WriteLine("itemsR2.Add");
			_itemsR2.Add(R2);
			System.Diagnostics.Debug.WriteLine("kajyu.Add");
			_itemsKajyu.Add(kajyu);
			System.Diagnostics.Debug.WriteLine("documentTitle.Add");
			_documentTitles.Add(documentTitle);
			System.Diagnostics.Debug.WriteLine("colors.Add");
			_charaColors.Add(c);
		}
		public double MaxR {
			get { return GetMaxR(); }
			set { }
		}
		public double MinR {
			get { return GetMinR(); }
			set { }
		}
		public double MaxR2 {
			get { return GetMaxR2(); }
			set { }
		}
		public double MinR2 {
			get { return GetMinR2(); }
			set { }
		}
		public double AveR {
			get { return GetAverage(); }
			set { }
		}
		
		public double AveR2 {
			get { return GetAverageR2(); }
			set { }
		}
		
		public double [] AveKajyu{
			get { return GetKajyuAverage(); }
		}
		
		public double [] AveHaikei{
			get { return GetHaikeiAverage(); }
		}
		
		public string Title {
			get { return _title; }
			set { _title = value; }
		}
		public Color ViewColor {
			get { return _viewColor; }
			set { _viewColor = value; }
		}
		public RRangeClass()
		{
		}
	}
}
