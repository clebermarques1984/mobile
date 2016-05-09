using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using itgMobile.Models;
using itgMobile.Views;
using itgMobile.Core;
using System.IO;
using System.Xml.Serialization;


namespace itgMobile.ViewModels
{
	public class ConsultaViewModel : BaseViewModel
	{

		public ICommand ListaCommand { get; set; }
		public ICommand AbrirPdfCommand { get; set; }

		private readonly Services.INavigationService _navigationService;
		private readonly Services.IMessageService _messageService;

		private string _cnpj = "55555555555576";
		public string CNPJ {
			get{ return _cnpj; }
			set{
				_cnpj = value;
				OnPropertyChanged();
			}
		}

		private DateTime _dataInicial = new DateTime(2010,11,01);
		public DateTime DataInicial {
			get{ return _dataInicial; }
			set{
				_dataInicial = value;
				OnPropertyChanged();
			}
		}

		private DateTime _dataFinal = new DateTime(2011,11,30);
		public DateTime DataFinal {
			get{ return _dataFinal; }
			set{
				_dataFinal = value;
				OnPropertyChanged();
			}
		}

		public ConsultaViewModel()
		{
			this.ListaCommand = new Command(this.Lista);
			this.AbrirPdfCommand = new Command(this.AbrirPdf);
			this._navigationService = DependencyService.Get<Services.INavigationService>();
			this._messageService = DependencyService.Get<Services.IMessageService>();
		}

		private async void Lista()
		{
			if (await this._messageService.ShowAsync (
				"Confirmação:"
				,"Gostaria de listar pagamentos?")) 
			{
				var viewModel = new ListaViewModel ();
				viewModel.Comissoes = getCmsPorData (_cnpj, _dataInicial, _dataFinal);
				var view = new ListaView ();
				view.BindingContext = viewModel;
				await this._navigationService.NavigateToLista(view);
			}

		}

		private async void AbrirPdf()
		{
			if (await this._messageService.ShowAsync (
					"Confirmação:"
					,"Gostaria de abrir o relatório em PDF?")) 
			{
				
				await this._navigationService.NavigateToAbrirPdf();
			}
		}

		public List<ComissaoInfo> getCmsPorData(string CNPJ, DateTime dtInicial, DateTime dtFinal)
		{
			CmsCore obj = new CmsCore();

			XmlUtil objXml = new XmlUtil();

			objXml.XmlStringBase = objXml.LoadXmlEmbedded ("itgMobile.Resource.input_8_1.xml");
			//objXml.XmlStringBase = Resources.itgMobileResource.input_8_1;

			//Define parametros de input no XML
			objXml.setParamValue("@cnpj", CNPJ);
			objXml.setParamValue("@dtInicial", dtInicial);
			objXml.setParamValue("@dtFinal", dtFinal);

			string xmlString = obj.getCmsPagasPorData(objXml.XmlString);

			//Retorna a lista de comissoes
			List<ComissaoInfo> comissoes = SerializarComissao(xmlString);
			return comissoes;
		}

		public bool abriPdf(string CNPJ, DateTime dtInicial, DateTime dtFinal)
		{
			CmsCore obj = new CmsCore();

			XmlUtil objXml = new XmlUtil();

			objXml.XmlStringBase = objXml.LoadXmlEmbedded ("itgMobile.Resource.input_8_4.xml");
			//objXml.XmlStringBase = Resources.itgMobileResource.input_8_4;

			//Define parametros de input no XML
			objXml.setParamValue("@cnpj", CNPJ);
			objXml.setParamValue("@dtInicial", dtInicial);
			objXml.setParamValue("@dtFinal", dtFinal);

			return obj.abriPdf(objXml.XmlString);
		}

		public List<ComissaoInfo> SerializarComissao(string xmlString)
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
				XmlSerializer cmsSerializer = new XmlSerializer(typeof(ComissaoInfo));
				//Transforma o XML e List<ComissaoInfo> e atribui o valor a comissoes
				comissoes = (ComissoesList)cmsSerializer.Deserialize(stream);

				return comissoes.ComissaoList;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

	}
}

