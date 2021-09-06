/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2012/02/13
 * 時刻: 16:20
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;

namespace CharacomImagerPro
{
	#region インターフェイス(ICommand)
	public interface ICommand
	{
		void Action();
		void Undo();
		void Redo();
	}
	#endregion
	
	#region 使わない？？？
	/// <summary>
	/// Description of CharaImageCommand.
	/// </summary>
	public class CharaImageCommand
	{
		public CharaImageCommand()
		{
		}
	}
	#endregion
	
	#region コマンドマネージャー
	public class CommandManager
	{
		private Stack<ICommand> undo = new Stack<ICommand>();
		private Stack<ICommand> redo = new Stack<ICommand>();
		
		public void Action(ICommand command)
		{
			this.undo.Push(command);
			command.Action();
			this.redo.Clear();
		}
		
		public void UndoClear()
		{
			this.undo.Clear();
		}
		
		public void RedoClear()
		{
			this.redo.Clear();
		}
		
		public void Undo()
		{
			if(!this.CanUndo()) return;
			ICommand command = this.undo.Pop();
			command.Undo();
			this.redo.Push(command);
		}
		
		public void Redo()
		{
			if(!this.CanRedo())return;
			ICommand command = this.redo.Pop();
			command.Redo();
			this.undo.Push(command);
		}
		/// <summary>
	    /// 元に戻せるかどうかを確認する
	    /// </summary>
	    /// <returns>元に戻せるかどうか</returns>
	    public bool CanUndo()
	    {
	        return 0 < this.undo.Count;
	    }
	  
	    /// <summary>
	    /// やり直せるかどうかを確認する
	    /// </summary>
	    /// <returns>やり直せるかどうか</returns>
	    public bool CanRedo()
	    {
	        return 0 < this.redo.Count;
	    }
	}
	#endregion
	
	#region 【CharaImageForm】全色変更コマンド
	public class ImageColorChangeCommand : ICommand
	{
		private Bitmap _beforBmp = new Bitmap(320, 320);
		private Bitmap _nextBmp =  new Bitmap(320, 320);
		private Color _nextColor;
		private ImageEffect imageEffect = new ImageEffect();
		
		public ImageColorChangeCommand(Bitmap bmp,Color nextC)
		{
			this._nextBmp = bmp;
			this._nextColor = nextC;
		}
		
		//実行する
		public void Action()
		{
			imageEffect.BitmapCopy(_nextBmp, _beforBmp);
			imageEffect.DotChange(_nextBmp, _nextColor);
			//imageEffect.BitmapCopy(procBitmap, viewBitmap);
			System.Diagnostics.Debug.WriteLine("Action!! - ImageColorChangeCommand");
			
		}
		public void Undo()
		{
			System.Diagnostics.Debug.WriteLine("Undo!! - ImageColorChangeCommand");
			imageEffect.BitmapCopy(_beforBmp, _nextBmp);
		}
		public void Redo()
		{
			System.Diagnostics.Debug.WriteLine("ReDo!! - ImageColorChangeCommand");
			imageEffect.DotChange(_nextBmp, _nextColor);
		}
	}
	#endregion
	
	#region 【CharaImageForm】矩形色変更コマンド
	public class FrameColorChangeCommand : ICommand
	{
		private Bitmap _nextBmp = new Bitmap(320, 320);
		private Bitmap _beforeBmp = new Bitmap(320, 320);
		private Bitmap _beforeFDCBmp = new Bitmap(320, 320);
		private FrameDataClass _beforeFDC;
		private FrameDataClass _nextFDC;
		private Color _nextColor;
		private Bitmap _beforeDgvBmp = new Bitmap(35, 16);
		private Bitmap _nextDgvBmp = new Bitmap(35, 16);
		private Bitmap _setDgvBmp = new Bitmap(35, 16);
		
		ImageEffect imageEffect = new ImageEffect();
		
		public FrameColorChangeCommand(Bitmap bmp, FrameDataClass fdc, Color c, Bitmap dgvBmp, Bitmap setBmp)
		{
			this._nextBmp = bmp;
			this._nextFDC = fdc;
			this._nextColor = c;
			this._nextDgvBmp = dgvBmp;
			this._setDgvBmp = setBmp;
		}
		
		public void Action()
		{
			//Beforeを作る
			imageEffect.BitmapCopy(_nextBmp, _beforeBmp);
			_beforeFDC = _nextFDC.Clone();
			imageEffect.BitmapCopy(_nextFDC.Bmp, _beforeFDCBmp);
			imageEffect.BitmapCopy(_nextDgvBmp, _beforeDgvBmp);
			//実行
			//色変更
			/**よく分からないバグのため追加**/
			Bitmap bbb = new Bitmap(_beforeFDCBmp.Width, _beforeFDCBmp.Height);
      		imageEffect.BitmapWhitening(bbb);
      		imageEffect.BitmapCopy(_beforeFDCBmp, bbb);
      		//色変更実施
      		//imageEffect.BmpColorChange(_nextFDC.Bmp, _nextColor);
			imageEffect.DotChange(bbb, _nextColor);
			
      		imageEffect.BitmapCopy(bbb, _nextFDC.Bmp);
      		
      		_nextFDC.FrameColor = _nextColor;
			//キャンバスを書き換え
			imageEffect.BitmapImposeCopy(_nextBmp, _nextFDC.Bmp);
			//DataGridViewを書き換え
			imageEffect.BitmapCopy(_setDgvBmp, _nextDgvBmp);
		}
		
		public void Undo()
		{
			//色を戻す
			imageEffect.BitmapCopy(_beforeFDCBmp, _nextFDC.Bmp);
			_nextFDC.FrameColor = _beforeFDC.FrameColor;
			//キャンバスを戻す
			imageEffect.BitmapCopy(_beforeBmp, _nextBmp);
			//DataGridViewを戻す
			imageEffect.BitmapCopy(_beforeDgvBmp, _nextDgvBmp);
			System.Diagnostics.Debug.WriteLine("Undo ! - FrameColorChangeCommand");
		}
		
		public void Redo()
		{
			//色変更
			imageEffect.BmpColorChange(_nextFDC.Bmp, _nextColor);
			_nextFDC.FrameColor = _nextColor;
			//キャンバスを書き換え
			imageEffect.BitmapImposeCopy(_nextBmp, _nextFDC.Bmp);
			//DataGridViewを書き換え
			imageEffect.BitmapCopy(_setDgvBmp, _nextDgvBmp);
			System.Diagnostics.Debug.WriteLine("Redo ! - FrameColorChangeCommand");
		}
	}
	#endregion
	
	#region 【CharaImageForm】矩形削除コマンド
	public class FrameDeleteCommand : ICommand
	{
		private DataGridViewRow _beforeRow;
		private DataGridViewRowCollection _nextRows;
		private ImageDataClass _nextImageData;
		private FrameDataClass _beforeFDC;
		private int _delIndex;
		
		
		public FrameDeleteCommand(DataGridViewRowCollection Rows, ImageDataClass idc, int index)
		{
			_nextRows = Rows;
			_delIndex = index;
			_nextImageData = idc;
		}
		
		public void Action()
		{
			//beforの作成
			_beforeRow = _nextRows[_delIndex];
			_beforeFDC = (FrameDataClass)_nextImageData.FrameData[_delIndex];
			
			//DataGridViewを削除
			_nextRows.RemoveAt(_delIndex);
			_nextImageData.FrameData_Delete(_delIndex);
		}
		
		public void Undo()
		{
			_nextRows.Insert(_delIndex, _beforeRow);// = _beforRows;
			_nextImageData.FrameData_Insert(_delIndex, _beforeFDC);
		}
		
		public void Redo()
		{
			_nextRows.RemoveAt(_delIndex);
			_nextImageData.FrameData_Delete(_delIndex);
		}
	}
	#endregion
	
	#region 【CharaImageForm】矩形切り出しコマンド
	public class FrameMakeCommand : ICommand
	{
		private DataGridViewRow _setRow;
		private FrameDataClass _setFDC;
		private DataGridViewRowCollection _nextRows;
		private ImageDataClass _nextImageData;
		private Bitmap _nextBmp;
		private Bitmap _beforBmp;
	
		private ImageEffect imageEffect = new ImageEffect();
		public FrameMakeCommand(DataGridViewRowCollection Rows, Bitmap outputBmp, ImageDataClass idc, DataGridViewRow row, FrameDataClass fdc)
		{
			_nextRows = Rows;
			_setRow = row;
			_setFDC = fdc;
			_nextImageData = idc;
			_nextBmp = outputBmp;
			_beforBmp = new Bitmap(_nextBmp.Width, _nextBmp.Height);
		}
		
		public void Action()
		{
			//beforの作成
			imageEffect.BitmapCopy(_nextBmp, _beforBmp);
			//DataGridViewを追加
			_nextRows.Add(_setRow);
			System.Diagnostics.Debug.WriteLine("SetRow : " + _setRow.ToString());
			_nextImageData.FrameData_Add(_setFDC);
		}
		
		public void Undo()
		{
			_nextRows.RemoveAt(_nextRows.Count - 1);
			_nextImageData.FrameData_Delete(_nextImageData.FrameData.Count - 1);
			imageEffect.BitmapCopy(_beforBmp, _nextBmp);
		}
		
		public void Redo()
		{
			//DataGridViewを追加
			_nextRows.Add(_setRow);
			_nextImageData.FrameData_Add(_setFDC);
		}
	}
	#endregion
	
	#region 【照合】ドラッグイン
	public class CheckUpDragInCommand : ICommand
	{
		private DataGridViewRow _setRow;
		private DataGridViewRowCollection _nextRows;
		private ArrayList _nextFeatures;
		private FeatureClass _setFeature;
		
		public CheckUpDragInCommand(DataGridViewRowCollection Rows, DataGridViewRow row, ArrayList features, FeatureClass fc)
		{
			//DataGridView用
			_nextRows = Rows;
			_setRow = row;
			//FeatureClass用
			_nextFeatures = features;
			_setFeature = fc;
		}
		
		public void Action()
		{
			_nextRows.Add(_setRow);
			_nextFeatures.Add(_setFeature);
		}
		
		public void Undo()
		{
			_nextRows.RemoveAt(_nextRows.Count - 1);
			_nextFeatures.Remove(_setFeature);
		}
		
		public void Redo()
		{
			_nextRows.Add(_setRow);
			_nextFeatures.Add(_setFeature);
		}
	}
	#endregion
	
	#region 【照合】削除
	public class CheckUpDeleteCommand : ICommand
	{
		private DataGridViewRow _beforeRow;
		private DataGridViewRowCollection _nextRows;
		private ArrayList _nextFeatures;
		private FeatureClass _beforFeature;
		private int _delIndex;
		
		public CheckUpDeleteCommand(DataGridViewRowCollection Rows, ArrayList features, int index)
		{
			_nextRows = Rows;
			_delIndex = index;
			_nextFeatures = features;
		}
		
		public void Action()
		{
			//beforeの作成
			_beforeRow = _nextRows[_delIndex];
			_beforFeature = (FeatureClass)_nextFeatures[_delIndex];
			//実行
			_nextRows.RemoveAt(_delIndex);
			_nextFeatures.RemoveAt(_delIndex);
		}
		
		public void Undo()
		{
			_nextRows.Insert(_delIndex, _beforeRow);
			_nextFeatures.Insert(_delIndex, _beforFeature);
		}
		
		public void Redo()
		{
			_nextRows.RemoveAt(_delIndex);
			_nextFeatures.RemoveAt(_delIndex);
		}
	}
	#endregion
	
	#region 【重ね合わせ】ドラッグイン
	public class LapDragInCommand : ICommand
	{
		private DataGridViewRow _setRow;
		private DataGridViewRowCollection _nextRows;
		private ArrayList _nextDatas;
		private ImageDataClass _setData;
		
		public LapDragInCommand(DataGridViewRowCollection Rows, DataGridViewRow row, ArrayList imageData, ImageDataClass idc)
		{
			//DataGridView用
			_nextRows = Rows;
			_setRow = row;
			//FeatureClass用
			_nextDatas = imageData;
			_setData = idc;
		}
		
		public void Action()
		{
			_nextRows.Add(_setRow);
			_nextDatas.Add(_setData);
		}
		
		public void Undo()
		{
			_nextRows.RemoveAt(_nextRows.Count - 1);
			_nextDatas.Remove(_setData);
		}
		
		public void Redo()
		{
			_nextRows.Add(_setRow);
			_nextDatas.Add(_setData);
		}
	}
	#endregion
	
	#region 【重ね合わせ】削除
	public class LapDeleteCommand : ICommand
	{
		private DataGridViewRow _beforeRow;
		private DataGridViewRowCollection _nextRows;
		private ArrayList _nextDatas;
		private ImageDataClass _beforData;
		private int _delIndex;
		
		public LapDeleteCommand(DataGridViewRowCollection Rows, ArrayList imageDatas, int index)
		{
			_nextRows = Rows;
			_delIndex = index;
			_nextDatas = imageDatas;
		}
		
		public void Action()
		{
			//beforeの作成
			_beforeRow = _nextRows[_delIndex];
			_beforData = (ImageDataClass)_nextDatas[_delIndex];
			//実行
			_nextRows.RemoveAt(_delIndex);
			_nextDatas.RemoveAt(_delIndex);
		}
		
		public void Undo()
		{
			_nextRows.Insert(_delIndex, _beforeRow);
			_nextDatas.Insert(_delIndex, _beforData);
		}
		
		public void Redo()
		{
			_nextRows.RemoveAt(_delIndex);
			_nextDatas.RemoveAt(_delIndex);
		}
	}
	#endregion
	
	#region 【重ね合わせ】順番入れ替え
	public class LapExchangeCommand : ICommand
	{
		private DataGridView _nextDGV;
		private ArrayList _nextDatas;
		private int _beforeIndex;
		private int _nextIndex;
		private int frame_width;
		private int frame_height;
		
		public LapExchangeCommand(DataGridView dgv, ArrayList imageDatas, int srcIndex, int outIndex, int width, int height)
		{
			frame_width = width;
			frame_height = height;
			_nextDGV = dgv;
			_nextDatas = imageDatas;
			_beforeIndex = srcIndex;
			_nextIndex = outIndex;
		}
		
		#region DataGridView データの入れ替え
		void dgvChangeData(DataGridViewRowCollection Rows, int a, int b)
		{
			string _filename;
			Bitmap _bmp;
				
			_filename = (string)Rows[a].Cells[1].Value;
			_bmp = (Bitmap)Rows[a].Cells[0].Value;
				
			Rows[a].Cells[1].Value = Rows[b].Cells[1].Value;
			Rows[a].Cells[0].Value = Rows[b].Cells[0].Value;
				
			Rows[b].Cells[1].Value = _filename;
			Rows[b].Cells[0].Value = _bmp;
				
		}
		#endregion
		
		#region 重ねあわせクラス入れ替え
		void ImageDataChangeData(ArrayList ImageArray, int a, int b)
		{
			ImageDataClass idc1 = new ImageDataClass(frame_width, frame_height);
			ImageDataClass idc2 = new ImageDataClass(frame_width, frame_height);
			
			idc1 = (ImageDataClass)ImageArray[a];
			idc2 = (ImageDataClass)ImageArray[b];
			
			ImageArray[b] = idc1;
			ImageArray[a] = idc2;
			
		}
		#endregion
		public void Action()
		{
			//beforeの作成
			//_beforeRow = _nextRows[_delIndex];
			//_beforData = (ImageDataClass)_nextDatas[_delIndex];
			//実行
			dgvChangeData(_nextDGV.Rows, _beforeIndex, _nextIndex);
			ImageDataChangeData(_nextDatas, _beforeIndex, _nextIndex);
			_nextDGV.CurrentCell = _nextDGV[0, _nextIndex];
			//_nextRows.RemoveAt(_delIndex);
			//_nextDatas.RemoveAt(_delIndex);
		}
		
		public void Undo()
		{
			dgvChangeData(_nextDGV.Rows, _nextIndex, _beforeIndex);
			ImageDataChangeData(_nextDatas, _nextIndex, _beforeIndex);
			_nextDGV.CurrentCell = _nextDGV[0, _beforeIndex];
			
			//_nextRows.Insert(_delIndex, _beforeRow);
			//_nextDatas.Insert(_delIndex, _beforData);
		}
		
		public void Redo()
		{
			dgvChangeData(_nextDGV.Rows, _beforeIndex, _nextIndex);
			ImageDataChangeData(_nextDatas, _beforeIndex, _nextIndex);
			_nextDGV.CurrentCell = _nextDGV[0, _nextIndex];
			
		}
	}
	#endregion
	
	#region 【変動比較】ドラッグイン
	public class RangeCompareDragInCommand : ICommand
	{
		private ArrayList _nextDatas;
		private IndividualClass _setData;
		
		public RangeCompareDragInCommand(IndividualClass ic, ArrayList rangeData)
		{
			_nextDatas = rangeData;
			_setData = ic;
		}
		
		public void Action()
		{
			_nextDatas.Add(_setData);
		}
		
		public void Undo()
		{
			_nextDatas.Remove(_setData);
		}
		
		public void Redo()
		{
			_nextDatas.Add(_setData);
		}
	}
	#endregion
	
	#region 【変動比較】削除
	public class RangeCompareDeleteCommand : ICommand
	{
		private ArrayList _nextDatas;
		private IndividualClass _delData;
		private int _delIndex;
		
		public RangeCompareDeleteCommand(ArrayList rangeData, int index)
		{
			_nextDatas = rangeData;
			_delIndex = index;
			
		}
		
		public void Action()
		{
			//beforeの作成
			_delData = (IndividualClass)_nextDatas[_delIndex];
			//実行
			_nextDatas.RemoveAt(_delIndex);
		}
		
		public void Undo()
		{
			_nextDatas.Insert(_delIndex, _delData);
		}
		
		public void Redo()
		{
			//実行
			_nextDatas.RemoveAt(_delIndex);
		}
	}
	#endregion
	
	#region 【変動比較】資料名の変更
	public class RangeCompareNameChangeCommand : ICommand
	{
		private IndividualClass _nextData;
		private string setName;
		private string beforName;
		
		public RangeCompareNameChangeCommand(IndividualClass ic, string name)
		{
			_nextData = ic;
			setName = name;
		}
		
		public void Action()
		{
			//beforeの作成
			beforName = _nextData.Title;
			//実行
			_nextData.Title = setName;
			System.Diagnostics.Debug.WriteLine(setName + "にかえました");
		}
		
		public void Undo()
		{
			_nextData.Title = beforName;
			System.Diagnostics.Debug.WriteLine(beforName + "に戻しました");
		}
		
		public void Redo()
		{
			//実行
			_nextData.Title = setName;
			System.Diagnostics.Debug.WriteLine(setName + "にしました");
		}
	}
	#endregion
	
	#region 【変動比較】表示色の変更
	public class RangeCompareColorChangeCommand : ICommand
	{
		private IndividualClass _nextData;
		private Color setColor;
		private Color beforColor;
		
		public RangeCompareColorChangeCommand(IndividualClass ic, Color c)
		{
			_nextData = ic;
			setColor = c;
		}
		
		public void Action()
		{
			//beforeの作成
			beforColor = _nextData.ViewColor;
			//実行
			_nextData.ViewColor = setColor;
			
		}
		
		public void Undo()
		{
			_nextData.ViewColor = beforColor;
			
		}
		
		public void Redo()
		{
			//実行
			_nextData.ViewColor = setColor;
			
		}
	}
	#endregion
}
