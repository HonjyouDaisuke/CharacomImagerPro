/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2011/10/31
 * 時刻: 11:33
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.ComponentModel;

namespace CharacomImagerPro
{
	/// <summary>
	/// Description of PropertyDisplay.
	/// </summary>
	/// <summary>
	/// プロパティ表示名を外部から設定するための属性。
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	class PropertyDisplayNameAttribute : Attribute
	{
		private string myPropertyDisplayName;

		public PropertyDisplayNameAttribute(string name)
		{
			myPropertyDisplayName = name;
		}

		public string PropertyDisplayName
		{
			get { return myPropertyDisplayName; }
		}
	}

	/// <summary>
	/// プロパティ表示名でPropertyDisplayPropertyDescriptorクラスを使用するために
	/// TypeConverter属性に指定するためのTypeConverter派生クラス。
	/// </summary>
	public class PropertyDisplayConverter : TypeConverter
	{
		public PropertyDisplayConverter()
		{
		}

		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object instance, Attribute[] filters)
		{
			PropertyDescriptorCollection collection = new PropertyDescriptorCollection(null);

			PropertyDescriptorCollection properies = TypeDescriptor.GetProperties(instance, filters, true);
			foreach(PropertyDescriptor desc in properies)
			{
				collection.Add(new PropertyDisplayPropertyDescriptor(desc));
			}

			return collection;
		}

		public override bool GetPropertiesSupported(ITypeDescriptorContext context)
		{
			return true;
		}
	}

	/// <summary>
	/// プロパティの説明（＝情報）を提供するクラス。DisplayNameをカスタマイズする。
	/// </summary>
	public class PropertyDisplayPropertyDescriptor : PropertyDescriptor
	{
		private PropertyDescriptor oneProperty;

		public PropertyDisplayPropertyDescriptor(PropertyDescriptor desc) : base(desc)
		{
			oneProperty = desc;
		}

		public override bool CanResetValue(object component)
		{
			return oneProperty.CanResetValue(component);
		}

		public override Type ComponentType
		{
			get 
			{
				return oneProperty.ComponentType;
			}
		}

		public override object GetValue(object component)
		{
			return oneProperty.GetValue(component);
		}

		public override string Description
		{
			get
			{
				return oneProperty.Description;
			}
		}
		
		public override string Category
		{
			get
			{
				return oneProperty.Category;
			}
		}

		public override bool IsReadOnly
		{
			get
			{
				return oneProperty.IsReadOnly;
			}
		}

		public override void ResetValue(object component)
		{
			oneProperty.ResetValue(component);		
		}

		public override bool ShouldSerializeValue(object component)
		{
			return oneProperty.ShouldSerializeValue(component);
		}

		public override void SetValue(object component, object value)
		{
			oneProperty.SetValue(component, value);
		}

		public override Type PropertyType
		{
			get 
			{
				return oneProperty.PropertyType;
			}
		}

		public override string DisplayName
		{
			get
			{
				PropertyDisplayNameAttribute attrib = 
					(PropertyDisplayNameAttribute)oneProperty.Attributes[typeof(PropertyDisplayNameAttribute)];
				if (attrib != null)
				{
					return attrib.PropertyDisplayName;
				}

				return oneProperty.DisplayName;
			}
		}

	}
}
