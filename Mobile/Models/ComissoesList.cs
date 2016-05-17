using System.Collections.Generic;
using System.Xml.Serialization;
using Mobile.Models;

namespace Mobile
{
	[XmlRoot("Comissoes"), XmlType("Comissoes")]
	public class ComissoesList
	{
		public ComissoesList()
            : this(new List<ComissaoInfo>())
		{

		}

        public ComissoesList(List<ComissaoInfo> comissoesList)
        {
            ComissaoList = comissoesList;
        }

		[XmlElement("Comissao")]
		public List<ComissaoInfo> ComissaoList { get; set; }
	}
}
