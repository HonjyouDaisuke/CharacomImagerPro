/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2011/10/18
 * 時刻: 15:54
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Collections;

namespace CharacomImagerPro
{
	/// <summary>
	/// Description of MathClass.
	/// </summary>
	public class MathClass
	{
		public MathClass()
		{
		}
		#region 平均を求める
		public double GetAverage(double [] v)
		{
			int i;
			double sum;
			
			sum = 0.0;
			for(i=0; i<v.Length; i++){
				sum += v[i];
			}
			return((double)(sum / v.Length));
		}
		#endregion
		
		#region 2つの特徴の平均を求める
		public double [] Get2Average(double [] a, double [] b)
		{
			double [] avg = new double[a.Length];
			
			for(int i=0; i<a.Length; i++){
				avg[i] = (a[i] + b[i]) / 2.0;
			}
			return(avg);
		}
		#endregion
		
		#region 平均分散を求める
		public double GetVar(ArrayList fc, int mode)
		{
			//mode
			//0:加重方向指数ヒストグラム特徴
			//1:背景伝搬法
			
			int i, jigen;
			if(mode == 0){
				jigen = 256;
			}else{
				jigen = 512;
			}
			double [] sum = new double[jigen];
			double [] sum2 = new double[jigen];
			double [] v = new double[jigen];
			
			for(i=0; i<sum.Length; i++){
				sum[i]=0.0;
				sum2[i]=0.0;
			}
			foreach(FeatureClass fn in fc){
				if(mode == 0){
					//加重方向指数ヒストグラム特徴の場合
					for(i=0; i<fn.Kajyu.Length; i++){
						sum[i] += fn.Kajyu[i];
						sum2[i] += fn.Kajyu[i] * fn.Kajyu[i];
					}
				}else{
					//背景伝搬法の場合
					for(i=0; i<fn.Haikei.Length; i++){
						sum[i] += fn.Haikei[i];
						sum2[i] += fn.Haikei[i] * fn.Haikei[i];
					}
				}
				
			}
			for(i=0; i<sum.Length; i++){
				if(fc.Count > 1){
					v[i] = ((fc.Count * sum2[i]) - (sum[i] * sum[i]))/(fc.Count * (fc.Count - 1));
				}else{
					v[i] = 0;
				}
			}
			return(GetAverage(v));
		}
		#endregion
		
		#region 類似度の算出
		public double GetR(double [] p, double []q)
		{
			double p2 = 0.0;
			double q2 = 0.0;
			double a = 0.0;
			double R = 0.0;
			int i;
			
			for(i=0; i< p.Length; i++){
				p2 += p[i] * p[i];
				q2 += q[i] * q[i];
				a += p[i] * q[i];
			}
			
			R = a / Math.Sqrt(p2 * q2);
			return(R);
		}
		#endregion
		
		#region 類似度2の算出(平均から自分自身を抜く)
		public double GetR2(double [] p, double []q, int num)
		{
			double p2 = 0.0;
			double q2 = 0.0;
			double a = 0.0;
			double R = 0.0;
			int i;
			double work;
			
			for(i=0; i< p.Length; i++){
				if(num == 1){
					work=0;
				}else{
					work = (p[i] * num - q[i]) / (num - 1);
				}
				p2 += work * work;
				q2 += q[i] * q[i];
				a += work * q[i];
			}
			//System.Diagnostics.Debug.WriteLine("["+i.ToString()+"] p="+p[i].ToString()+" q="+q[i].ToString()+" num="+num.ToString()+" work="+work.ToString());
			if(Math.Sqrt(p2 * q2) == 0.0){
				R = 0;
			}else{
				R = a / Math.Sqrt(p2 * q2);
			}
			if(R==0.0)R=1.0;
			return(R);
		}
		#endregion
		
		#region ユークリッド距離の算出
		public double GetDistance(double [] p, double [] q)
		{
			int i;
			double a = 0.0;
			for(i=0; i<p.Length; i++){
				a += ((p[i] - q[i]) * (p[i] - q[i]));
			}
			a = Math.Sqrt(a);
			
			return(a);
		}
		#endregion
	}
}
