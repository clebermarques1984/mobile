using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;
using itgMobile.iOS;
using Xamarin.Forms;
using Foundation;
using UIKit;
using QuickLook;
using itgMobile.Core.Service;
using System.Threading;

[assembly: Dependency(typeof(ItgEspecifico))]

namespace itgMobile.iOS
{
	public class ItgEspecifico : UIViewController, ICore
	{
		private intranet.itg.cms_ws.Consultas wsCMS; //Serviço CMS http://200.152.194.6:8888/consultas.asmx
		private Dictionary<string, string> dicNodes;

		public ItgEspecifico()
		{
			//Instancia CMS WebService
			wsCMS = new intranet.itg.cms_ws.Consultas();
		}

		private string _errorMsg;
		public string errorMsg
		{
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

        public void quitApp()
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

