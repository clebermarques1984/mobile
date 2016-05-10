using Mobile.Droid;
using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;
using Android.Content;
using Mobile.Core.Service;

[assembly: Dependency(typeof(Especifico))]

namespace Mobile.Droid
{
    public class Especifico : ICore
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
                Android.Net.Uri uri = Android.Net.Uri.Parse("file:///" + pdfPath);
                Intent intent = new Intent(Intent.ActionView);

                intent.SetDataAndType(uri, "application/pdf");
                intent.SetFlags(ActivityFlags.ClearWhenTaskReset | ActivityFlags.NewTask);

                Xamarin.Forms.Forms.Context.StartActivity(intent);
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

        public void QuitApp()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}