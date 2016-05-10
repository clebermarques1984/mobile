using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;
using Mobile.iOS;
using Xamarin.Forms;
using Foundation;
using UIKit;
using QuickLook;
using Mobile.Core.Service;
using System.Threading;

[assembly: Dependency(typeof(Especifico))]

namespace Mobile.iOS
{
	public class Especifico : UIViewController, ICore
	{
		private intranet.itg.cms_ws.Consultas wsCMS; //Serviço CMS http://200.152.194.6:8888/consultas.asmx
		private Dictionary<string, string> dicNodes;

		public Especifico()
		{
			//Instancia CMS WebService
			wsCMS = new intranet.itg.cms_ws.Consultas();
		}

        public string ErroMsg { get; set; }

		public Dictionary<string, string> GetXmlRetornoWS(string xmlString, Metodo valor, bool getInnerText)
		{
			try
			{
				ErroMsg = "";
				//Inicializa dicNodes
				dicNodes = new Dictionary<string, string>();

				string xmlStringOut = "";

				switch (valor)
				{
				case Metodo.ConsultaConsolidadaPagamentoPorData:
					xmlStringOut = wsCMS.ConsultaConsolidadaPagamentoPorData(xmlString);
					break;
				case Metodo.RelatorioDemonstrativoComissaoPagoPDF:
					xmlStringOut = wsCMS.RelatorioDemonstrativoComissaoPagoPDF(xmlString);
					break;
				default:
					break;
				}

				//Preenche dicNodes
				PreecherDicNodes(xmlStringOut, getInnerText);
			}
			catch (Exception ex)
			{
				ErroMsg = String.Format(@"ERROR: {0}", ex.Message);
				Debug.WriteLine(ErroMsg);
			}
			return dicNodes;
		}

		public string CriarPdf(Byte[] bytePDF, string strName)
		{
			string pdfPath = "";
			try
			{
				Stream stFile;
				ErroMsg = "";
				//Get documents folder path
				string documents = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
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
				ErroMsg = String.Format(@"ERROR: {0}", ex.Message);
				Debug.WriteLine(ErroMsg);
			}

			return pdfPath;
		}

		public void AbrirPdf(string pdfPath)
		{
			try
			{
				ErroMsg = "";

				FileInfo fi = new FileInfo(pdfPath);
				//Call InvokeOnMainThread and use an anonymous function in my asynchronous methods.
				//This must be done through the InvokeOnMainThread otherwise the app fires an uikit consistency error
				InvokeOnMainThread(() => {
					UINavigationController controller = FindNavigationController();
					QLPreviewController previewController = new QLPreviewController();
					previewController.DataSource = new PDFPreviewControllerDataSource(fi.FullName, fi.Name);
					controller.PresentViewController(previewController, true, null);
				});

			}
			catch (Exception ex)
			{
				ErroMsg = String.Format(@"ERROR: {0}", ex.Message);
				Debug.WriteLine(ErroMsg);
			}
		}

		private void PreecherDicNodes(string xmlString, bool getInnerText)
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
			
		private UINavigationController FindNavigationController()
		{
			foreach (var window in UIApplication.SharedApplication.Windows)
			{
				if (window.RootViewController.NavigationController != null)
					return window.RootViewController.NavigationController;
				else
				{
					UINavigationController val = CheckSubs(window.RootViewController.ChildViewControllers);
					if (val != null)
						return val;
				}
			}

			return null;
		}

		private UINavigationController CheckSubs(UIViewController[] controllers)
		{
			foreach (var controller in controllers)
			{
				if (controller.NavigationController != null)
					return controller.NavigationController;
				else
				{
					UINavigationController val = CheckSubs(controller.ChildViewControllers);
					if (val != null)
						return val;
				}
			}
			return null;
		}

        public void QuitApp()
        {
            Thread.CurrentThread.Abort();
        }

        public class PDFItem : QLPreviewItem
		{
			string title;
			string uri;

			public PDFItem(string title, string uri)
			{
				this.title = title;
				this.uri = uri;
			}

			public override string ItemTitle
			{
				get { return title; }
			}

			public override NSUrl ItemUrl
			{
				get { return NSUrl.FromFilename(uri); }
			}
		}

		public class PDFPreviewControllerDataSource : QLPreviewControllerDataSource
		{
			string url = "";
			string filename = "";

			public PDFPreviewControllerDataSource(string url, string filename)
			{
				this.url = url;
				this.filename = filename;
			}


			public override IQLPreviewItem GetPreviewItem(QLPreviewController controller, nint index)
			{
				return new PDFItem(filename, url);
			}


			public override nint PreviewItemCount(QLPreviewController controller)
			{
				return 1;
			}
		}
	}
}

