using System;
using System.IO;
using System.Reflection;

namespace Mobile.Core
{
	public class XmlUtil
	{
		private string _XmlString;
		public string XmlString
		{
			get
			{
				_XmlString = (!string.IsNullOrEmpty(_XmlString)) ? _XmlString : XmlStringBase;

				return _XmlString;
			}
			private set
			{
				_XmlString = value;
			}
		}

		/// <summary>
		/// Representa o XmlString de criação da classe
		/// </summary>
		public string XmlStringBase { get; set; }

		/// <summary>
		/// Substitui o paramName pelo paramValue em XmlString
		/// </summary>
		/// <param name="paramName">Nome do parametro como string</param>
		/// <param name="paramValue">Valor do parametro como object</param>
		public void setParamValue(string paramName, object paramValue)
		{
			paramValue = (paramValue.GetType() == typeof(DateTime)) ? ((DateTime)paramValue).ToString("yyyy-MM-dd") : paramValue;  
			XmlString = XmlString.Replace(paramName, (string)paramValue);
		}

		/// <summary>
		/// Use this, if it is not possible to use use a Resource file
		/// </summary>
		/// <param name="Path"></param>
		/// <returns></returns>
		public string LoadXmlEmbedded(string Path)
		{
			string xmlString = "";

			#region How to load an XML file embedded resource
			var assembly = GetType().GetTypeInfo().Assembly;

			Stream stream = assembly.GetManifestResourceStream(Path);

			using (var reader = new StreamReader(stream))
			{
				xmlString = reader.ReadToEnd();
			}
			#endregion

			return xmlString;
		}
	}
}
