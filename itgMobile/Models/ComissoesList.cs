using System.Collections.Generic;
using System.Xml.Serialization;
using itgMobile.Models;

namespace itgMobile
{
	[XmlRoot("Comissoes"), XmlType("Comissoes")]
	public class ComissoesList
	{
		public ComissoesList()
		{
			ComissaoList = new List<ComissaoInfo>();
		}

		[XmlElement("Comissao")]
		public List<ComissaoInfo> ComissaoList { get; set; }
	}
}
