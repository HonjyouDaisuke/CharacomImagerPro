/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2012/01/25
 * 時刻: 16:25
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace CharacomImagerPro
{
	/// <summary>
	/// Description of PluralCheckUp.
	/// </summary>
	public partial class PluralCheckUp : Form
	{
		//照合データ蓄積用配列
		ArrayList CheckUps = new ArrayList();
		
		public PluralCheckUp()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			this.AllowDrop = true;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void PluralCheckUpDragEnter(object sender, DragEventArgs e)
		{
			if(e.Data.GetDataPresent(typeof(CheckUpForm))){
				e.Effect = DragDropEffects.Copy;
			}else{
				e.Effect = DragDropEffects.None;
			}
		}
		
		void PluralCheckUpDragDrop(object sender, DragEventArgs e)
		{
			CheckUpForm cuf;
			CheckUpClass cuc = new CheckUpClass();
			
			double [] kajyu = new double[256];
			
			if(e.Data.GetDataPresent(typeof(CheckUpForm))){
				cuf = (CheckUpForm)e.Data.GetData(typeof(CheckUpForm));
				cuc.KajyuA = cuf.KajyuA;
				cuc.KajyuB = cuf.KajyuB;
				cuc.Ruijido = cuf.Ruijido;
				cuc.Distance = cuf.Distance;
				
				CheckUps.Add(cuc);
				
				//DataGridViewに追加する
				dgvCheckUps.Rows.Add();
				
				dgvCheckUps[0, dgvCheckUps.Rows.Count - 1].Value = dgvCheckUps.Rows.Count.ToString();
				dgvCheckUps[1, dgvCheckUps.Rows.Count - 1].Value = (cuc.Ruijido).ToString("F4");
				//dgvCheckUps[2, dgvCheckUps.Rows.Count - 1].Value = cuc.Distance.ToString("F2");
			}
		}
		
		#region 類似度の算出
		public double GetR()
		{
			double p2 = 0.0;
			double q2 = 0.0;
			double a = 0.0;
			double R = 0.0;
			int i;
			
			foreach(CheckUpClass cuc in CheckUps){
				for(i=0; i<cuc.KajyuA.Length; i++){
					p2 += cuc.KajyuA[i] * cuc.KajyuA[i];
					q2 += cuc.KajyuB[i] * cuc.KajyuB[i];
					a += cuc.KajyuA[i] * cuc.KajyuB[i];
				}
			}
			R = a / Math.Sqrt(p2 * q2);
			return(R);
		}
		#endregion
		
		#region ユークリッド距離の算出
		public double GetDistance()
		{
			int i;
			double a = 0.0;
			
			foreach(CheckUpClass cuc in CheckUps){
				for(i=0; i<cuc.KajyuA.Length; i++){
					a += ((cuc.KajyuA[i] - cuc.KajyuB[i]) * (cuc.KajyuA[i] - cuc.KajyuB[i]));
				}
			}
			a = Math.Sqrt(a);
			
			return(a);
		}
		#endregion
		
		#region 照合ボタンが押されたとき
		void BtnCheckUpClick(object sender, EventArgs e)
		{
			double R;
			//double D;
			
			R=GetR();
			//D = GetDistance();
			lblCheckupRuiji.Text = R.ToString("F4");
			//lblCheckupDistance.Text = D.ToString("F2");
		}
		#endregion
	}
}
