using System;
using System.Collections.Generic;
using itgMobile.Core.Service;

namespace itgMobile.Core
{
    public class CmsCore
	{
		public string getCmsPagasPorData(string xmlString)
		{
			string ret = "";

			var obj = ItgWebService.itgEspecifico;

			Dictionary<string, string> dicNodes;

			dicNodes = obj.getXmlRetornoWS(xmlString, metodos.ConsultaConsolidadaPagamentoPorData, false);

			if (dicNodes.ContainsKey("Comissoes"))
			{
				ret = dicNodes["Comissoes"];
			}

			return ret; 
		}

		public bool abriPdf(string xmlString)
		{
			bool ret = false;

			var obj = ItgWebService.itgEspecifico;

			Dictionary<string, string> dicNodes;

			dicNodes = obj.getXmlRetornoWS(xmlString, metodos.RelatorioDemonstrativoComissaoPagoPDF, true);

			string pdfString = "";

			if (dicNodes.ContainsKey("documento"))
			{
				pdfString = dicNodes["documento"];
			}

			Byte[] bytePDF = Convert.FromBase64String(pdfString);

			string pdfPath = obj.CriarPdf(bytePDF, "relatorio.pdf");

			obj.abrirPdf(pdfPath);

			ret = true;

			return ret;
		}
	}
}
