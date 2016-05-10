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

namespace Mobile.ViewModels
{
    public class ConsultaViewModel : BaseViewModel
    {
        private readonly Services.INavigationService navigationService;

        private readonly Services.IMessageService messageService;

        public ICommand ListaCommand { get; set; }

        public ICommand AbrirPdfCommand { get; set; }

        private string cnpj;
        public string CNPJ
        {
            get { return cnpj; }
            set
            {
                cnpj = value;
                OnPropertyChanged();
            }
        }

        private DateTime dataInicial;
        public DateTime DataInicial
        {
            get { return dataInicial; }
            set
            {
                dataInicial = value;
                OnPropertyChanged();
            }
        }

        private DateTime dataFinal;
        public DateTime DataFinal
        {
            get { return dataFinal; }
            set
            {
                dataFinal = value;
                OnPropertyChanged();
            }
        }

        public ConsultaViewModel()
        {
            //Define valores iniciais para CNPJ, DataInicial e DataFinal
            cnpj = "55555555555576";
            dataInicial = new DateTime(2010, 11, 01);
            dataFinal = new DateTime(2011, 11, 30);

            this.ListaCommand = new Command(this.Lista);
            this.AbrirPdfCommand = new Command(this.AbrirPdf);
            this.navigationService = DependencyService.Get<Services.INavigationService>();
            this.messageService = DependencyService.Get<Services.IMessageService>();
        }

        private async void Lista()
        {
            if (await this.messageService.ShowAsync(
                "Confirmação:"
                , "Gostaria de listar pagamentos?"))
            {
                IsBusy = true;
                var obj = new CmsCore();
                var viewModel = new ListaViewModel();
                viewModel.Comissoes = await obj.ListAsync(cnpj, dataInicial, DataFinal);
                var view = new ListaView();
                view.BindingContext = viewModel;
                await this.navigationService.NavigateToLista(view);
                IsBusy = false;
            }
        }

        private async void AbrirPdf()
        {
            if (await this.messageService.ShowAsync(
                    "Confirmação:"
                    , "Gostaria de abrir o relatório em PDF?"))
            {
                IsBusy = true;
                var obj = new CmsCore();
                var viewModel = new AbrirPdfViewModel();
                viewModel.Status = await obj.TryOpenPdfAsync(cnpj, dataInicial, dataFinal);
                string msg = NativeCore.Especifico.ErroMsg;
                viewModel.Message = (!string.IsNullOrEmpty(msg)) ? msg : "Operação executada com sucesso.";
                var view = new AbrirPdfView();
                view.BindingContext = viewModel;
                await this.navigationService.NavigateToAbrirPdf(view);
                IsBusy = false;
            }
        }

    }
}

