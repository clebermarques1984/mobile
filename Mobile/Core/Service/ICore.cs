using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobile;

namespace Mobile.Core.Service
{
	public enum Metodo
	{
		ConsultaConsolidadaPagamentoPorData,
		RelatorioDemonstrativoComissaoPagoPDF
	}

	public interface ICore
	{
		string ErroMsg { get; set; }

        bool HasError { get; }

		/// <summary>
		/// Cria um item para cada node do XML que pode ser acessado pelo nome
		/// </summary>
		/// <param name="xmlString"></param>
		/// <param name="valor"></param>
		/// <returns></returns>
		Dictionary<string, string> GetXmlRetornoWS(string xmlString, Metodo valor, bool getInnerText);

		/// <summary>
		/// Cria um arquivo PDF no Device e retorna o endereço do arquivo como string
		/// </summary>
		/// <param name="bytePDF">arquivo pdf como Byte[]</param>
		/// <param name="strName">Nome que o arquivo será salvo</param>
		/// <returns></returns>

		string CriarPdf(byte[] bytePDF, string strName);

		/// <summary>
		/// Abri um arquivo pdf
		/// </summary>
		/// <param name="pdfPath">Endereço completo do arquivo pdf</param>
		void AbrirPdf(string pdfPath);

        void QuitApp();
	}
}
