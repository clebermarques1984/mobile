using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Mobile.Core.Service;
using Mobile.Models;

namespace Mobile.Core
{
    public class CmsCore
    {
        /// <summary>
        /// Retorna uma lista de pagamentos do CNPJ/CPF dentro do periodo definido
        /// </summary>
        /// <param name="Cnpj">CNPN/CPF do corretor</param>
        /// <param name="DataInicial">Data Inicial dos pagamentos</param>
        /// <param name="DataFinal">Data Final dos pagamentos</param>
        /// <returns></returns>
        public Task<List<ComissaoInfo>> ListAsync(string Cnpj, DateTime DataInicial, DateTime DataFinal)
        {
            return Task.Factory.StartNew(() =>
            {
                XmlUtil objXml = new XmlUtil();

                //objXml.XmlStringBase = objXml.LoadXmlEmbedded ("Mobile.Resource.input_8_1.xml");
                objXml.XmlStringBase = Resource.MobileResource.input_8_1;

                //Define parametros de input no XML
                objXml.setParamValue("@cnpj", Cnpj);
                objXml.setParamValue("@dtInicial", DataInicial);
                objXml.setParamValue("@dtFinal", DataFinal);

                string xmlString = GetXmlCmsPagas(objXml.XmlString);
                //Retorna a lista de comissoes
                List<ComissaoInfo> comissoes = SerializarComissao(xmlString);
                return comissoes;
            });
        }

        private string GetXmlCmsPagas(string xmlString)
        {
            string ret = "";

            var obj = NativeCore.Especifico;

            Dictionary<string, string> dicNodes;

            dicNodes = obj.GetXmlRetornoWS(xmlString, Metodo.ConsultaConsolidadaPagamentoPorData, false);

            if (dicNodes.ContainsKey("Comissoes"))
            {
                ret = dicNodes["Comissoes"];
            }

            return ret;
        }

        private List<ComissaoInfo> SerializarComissao(string xmlString)
        {
            if (string.IsNullOrEmpty(xmlString))
            {
                return null;
            }

            try
            {
                var comissoes = new ComissoesList();

                Stream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(xmlString));
                //Define o tipo de serialização
                XmlSerializer cmsSerializer = new XmlSerializer(typeof(ComissoesList));
                //Transforma o XML e List<ComissaoInfo> e atribui o valor a comissoes
                comissoes = (ComissoesList)cmsSerializer.Deserialize(stream);

                return comissoes.ComissaoList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Tenta abrir o relatório PDF de pagamentos do CNPJ/CPF dentro do periodo definido
        /// </summary>
        /// <param name="Cnpj">CNPN/CPF do corretor</param>
        /// <param name="DataInicial">Data Inicial dos pagamentos</param>
        /// <param name="DataFinal">Data Final dos pagamentos</param>
        /// <returns></returns>
        public Task<bool> TryOpenPdfAsync(string Cnpj, DateTime DataInicial, DateTime DataFinal)
        {
            return Task.Factory.StartNew(() =>
            {
                XmlUtil objXml = new XmlUtil();

                //objXml.XmlStringBase = objXml.LoadXmlEmbedded ("Mobile.Resource.input_8_4.xml");
                objXml.XmlStringBase = Resource.MobileResource.input_8_4;

                //Define parametros de input no XML
                objXml.setParamValue("@cnpj", Cnpj);
                objXml.setParamValue("@dtInicial", DataInicial);
                objXml.setParamValue("@dtFinal", DataFinal);

                bool ret = GetXmlPdf(objXml.XmlString);
                return ret;
            });
        }

        private bool GetXmlPdf(string xmlString)
        {
            bool ret = false;

            var obj = NativeCore.Especifico;

            Dictionary<string, string> dicNodes;

            dicNodes = obj.GetXmlRetornoWS(xmlString, Metodo.RelatorioDemonstrativoComissaoPagoPDF, true);

            string pdfString = "";

            if (dicNodes.ContainsKey("documento"))
            {
                pdfString = dicNodes["documento"];
            }

            Byte[] bytePDF = Convert.FromBase64String(pdfString);

            string pdfPath = obj.CriarPdf(bytePDF, "relatorio.pdf");

            obj.AbrirPdf(pdfPath);

            ret = true;

            return ret;
        }
    }
}
