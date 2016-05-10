using System;
using System.Xml.Serialization;

namespace Mobile.Models
{
	[XmlType("Comissao")]
	public class ComissaoInfo
	{
		[XmlElement("dataPagamento")]
		public DateTime dataPagamento { get; set; }

		[XmlElement("numeroFaturas")]
		public int numeroFaturas { get; set; }

		[XmlElement("valorBruto")]
		public double valorBruto { get; set; }

		[XmlElement("valorIR")]
		public double valorIR { get; set; }

		[XmlElement("valorISS")]
		public double valorISS { get; set; }

		[XmlElement("inss")]
		public double inss { get; set; }

		[XmlElement("pis")]
		public double pis { get; set; }

		[XmlElement("valor")]
		public double valor { get; set; }

		[XmlElement("cnpjcpf")]
		public string cnpjcpf { get; set; }

		/// <summary>
		/// Retorna "Data de Pag: dd/MM/yyyy - Valor Pago: R$99,99)
		/// </summary>
		[System.Xml.Serialization.XmlIgnoreAttribute]
		public string detalhes
		{
			get { return string.Format ("Data: {0:dd/MM/yyyy} - Valor: R$ {1}", dataPagamento, valor); }
		}
			
		/* Exemplo de retorno no xml da função 8.1 - ConsolidadaPagamentoPorData
         <Comissao>
              <dataPagamento>2010-09-13</dataPagamento>
              <numeroFaturas>275</numeroFaturas>
              <valorBruto>70.00</valorBruto>
              <valorIR>1.05</valorIR>
              <valorISS>1.40</valorISS>
              <inss>0.00</inss>
              <pis>0.00</pis>
              <valor>67.55</valor>
              <cnpjcpf>55.555.555/5555-76</cnpjcpf>
        </Comissao>
        */
	}
}
