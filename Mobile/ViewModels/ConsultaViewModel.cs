using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Mobile.Models;
using Mobile.Views;
using Mobile.Core;
using System.IO;
using System.Xml.Serialization;
using static Mobile.Core.NativeCore;

namespace Mobile.ViewModels
{
    public class ConsultaViewModel : BaseViewModel
    {
        private readonly Services.INavigationService navigationService;

        private readonly Services.IMessageService messageService;

        public ICommand ListaCommand { get; }

        public ICommand AbrirPdfCommand { get; }

        private string cnpj;
        public string CNPJ
        {
            get { return cnpj; }
            set { cnpj = value; OnPropertyChanged(); }
        }

        private DateTime dataInicial;
        public DateTime DataInicial
        {
            get { return dataInicial; }
            set { dataInicial = value; OnPropertyChanged(); }
        }

        private DateTime dataFinal;
        public DateTime DataFinal
        {
            get { return dataFinal; }
            set { dataFinal = value; OnPropertyChanged(); }
        }

        public ConsultaViewModel()
        {
            //Define valores iniciais para CNPJ, DataInicial e DataFinal
            cnpj = "55555555555576";
            dataInicial = new DateTime(2010, 11, 01);
            dataFinal = new DateTime(2011, 11, 30);

            ListaCommand = new Command(Lista);
            AbrirPdfCommand = new Command(AbrirPdf);
            navigationService = DependencyService.Get<Services.INavigationService>();
            messageService = DependencyService.Get<Services.IMessageService>();
        }

        private async void Lista()
        {
            IsBusy = await messageService.ShowAsync("Confirmação:" ,"Gostaria de listar pagamentos?");
            if (IsBusy)
            {
                var obj = new CmsCore();
                var viewModel = new ListaViewModel();
                viewModel.Comissoes = await obj.ListAsync(cnpj, dataInicial, DataFinal);
                await navigationService.NavigateToLista(new ListaView(viewModel));
                IsBusy = false;
            }
        }

        private async void AbrirPdf()
        {
            IsBusy = await messageService.ShowAsync("Confirmação:", "Gostaria de abrir o relatório em PDF?");
            if (IsBusy)
            {
                var obj = new CmsCore();
                await obj.TryOpenPdfAsync(cnpj, dataInicial, dataFinal);
                var viewModel = new AbrirPdfViewModel();
                viewModel.Message = (Especifico.HasError) ? Especifico.ErroMsg : "Operação executada com sucesso.";
                await navigationService.NavigateToAbrirPdf(new AbrirPdfView(viewModel));
                IsBusy = false;
            }
        }
    }
}

