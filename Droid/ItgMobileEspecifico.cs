using itgMobile.Droid;
using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;
using Android.Content;
using itgMobile.Core.Service;

[assembly: Dependency(typeof(ItgEspecifico))]

namespace itgMobile.Droid
{
	public class ItgEspecifico : ICore
	{
		private intranet.itg.cms_ws.Consultas wsCMS; //Serviço CMS http://200.152.194.6:8888/consultas.asmx

		private Dictionary<string, string> dicNodes;

		public ItgEspecifico()
		{
			//Instancia CMS WebService
			wsCMS = new intranet.itg.cms_ws.Consultas();
		}

		private string _errorMsg;
		public string errorMsg {
			get
			{
				return _errorMsg;
			}
			set
			{
				_errorMsg = value;
			}
		}   

		public Dictionary<string, string> getXmlRetornoWS(string xmlString, metodos valor, bool getInnerText)
		{
			try
			{
				_errorMsg = "";
				//Inicializa dicNodes
				dicNodes = new Dictionary<string, string>();

				string xmlStringOut = "";

				switch (valor)
				{
				case metodos.ConsultaConsolidadaPagamentoPorData:
					xmlStringOut = wsCMS.ConsultaConsolidadaPagamentoPorData(xmlString);
					break;
				case metodos.RelatorioDemonstrativoComissaoPagoPDF:
					xmlStringOut = wsCMS.RelatorioDemonstrativoComissaoPagoPDF(xmlString);
					break;
				default:
					break;
				}

				//Preenche dicNodes
				preecherDicNodes(xmlStringOut, getInnerText);
			}
			catch (Exception ex)
			{
				_errorMsg = String.Format(@"ERROR: {0}", ex.Message);
				Debug.WriteLine(_errorMsg);
			}
			return dicNodes;
		}

		public string CriarPdf(Byte[] bytePDF, string strName)
		{
			string pdfPath = "";
			try
			{
				Stream stFile;
				_errorMsg = "";
				//Get documents folder path
				string documents = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
				pdfPath = Path.Combine(documents, strName);

				if (File.Exists(pdfPath))
				{
					File.Delete(pdfPath);
				}

				stFile = File.Create(pdfPath);
				stFile.Write(bytePDF, 0, bytePDF.Length);
				stFile.Close();
				stFile.Dispose();
			}
			catch (Exception ex)
			{
				_errorMsg = String.Format(@"ERROR: {0}", ex.Message);
				Debug.WriteLine(_errorMsg);
			}

			return pdfPath;
		}

		public void abrirPdf(string pdfPath)
		{
			try
			{
				_errorMsg = "";
				Android.Net.Uri uri = Android.Net.Uri.Parse("file:///" + pdfPath);
				Intent intent = new Intent(Intent.ActionView);

				intent.SetDataAndType(uri, "application/pdf");
				intent.SetFlags(ActivityFlags.ClearWhenTaskReset | ActivityFlags.NewTask);

				Xamarin.Forms.Forms.Context.StartActivity(intent);
			}
			catch (Exception ex)
			{
				_errorMsg = String.Format(@"ERROR: {0}", ex.Message);
				Debug.WriteLine(_errorMsg);
			}
		}

		private void preecherDicNodes(string xmlString, bool getInnerText)
		{
			XmlDocument xmlDoc = new XmlDocument();
			XmlNodeList xmlNds;
			//Carrega o xmlString em xmlDoc
			xmlDoc.LoadXml(xmlString);
			//Seleciona todos Nodes do XML
			xmlNds = xmlDoc.DocumentElement.ChildNodes;
			//Cria um item para cada node do XML que pode ser acessado pelo nome em dicNodes
			foreach (XmlNode n in xmlNds)
			{
				if (getInnerText)
				{
					dicNodes.Add(n.Name, n.InnerText);
				}
				else
				{
					dicNodes.Add(n.Name, n.OuterXml);
				}
			}
		}

        public void quitApp()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}