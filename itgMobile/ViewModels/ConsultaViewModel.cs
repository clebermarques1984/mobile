﻿using System;
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
        private readonly Services.INavigationService _navigationService;

        private readonly Services.IMessageService _messageService;

        public ICommand ListaCommand { get; set; }

        public ICommand AbrirPdfCommand { get; set; }

        private string _cnpj;
        public string CNPJ
        {
            get { return _cnpj; }
            set
            {
                _cnpj = value;
                OnPropertyChanged();
            }
        }

        private DateTime _dataInicial;
        public DateTime DataInicial
        {
            get { return _dataInicial; }
            set
            {
                _dataInicial = value;
                OnPropertyChanged();
            }
        }

        private DateTime _dataFinal;
        public DateTime DataFinal
        {
            get { return _dataFinal; }
            set
            {
                _dataFinal = value;
                OnPropertyChanged();
            }
        }

        public ConsultaViewModel()
        {
            //Define valores iniciais para CNPJ, DataInicial e DataFinal
            _cnpj = "55555555555576";
            _dataInicial = new DateTime(2010, 11, 01);
            _dataFinal = new DateTime(2011, 11, 30);

            this.ListaCommand = new Command(this.Lista);
            this.AbrirPdfCommand = new Command(this.AbrirPdf);
            this._navigationService = DependencyService.Get<Services.INavigationService>();
            this._messageService = DependencyService.Get<Services.IMessageService>();
        }

        private async void Lista()
        {
            if (await this._messageService.ShowAsync(
                "Confirmação:"
                , "Gostaria de listar pagamentos?"))
            {
                IsBusy = true;
                var obj = new CmsCore();
                var viewModel = new ListaViewModel();
                await Task.Delay(5).ContinueWith(
                        task => viewModel.Comissoes = obj.List(_cnpj, _dataInicial, _dataFinal)
                );
                var view = new ListaView();
                view.BindingContext = viewModel;
                await this._navigationService.NavigateToLista(view);
                IsBusy = false;
            }
        }

        private async void AbrirPdf()
        {
            if (await this._messageService.ShowAsync(
                    "Confirmação:"
                    , "Gostaria de abrir o relatório em PDF?"))
            {
                IsBusy = true;
                var obj = new CmsCore();
                var viewModel = new AbrirPdfViewModel();
                await Task.Delay(5).ContinueWith(
                    task => viewModel.Status = obj.tryOpenPdf(_cnpj, _dataInicial, _dataFinal)
                );
                string msg = ItgWebService.itgEspecifico.errorMsg;
                viewModel.Message = (!string.IsNullOrEmpty(msg)) ? msg : "Operação executada com sucesso.";
                var view = new AbrirPdfView();
                view.BindingContext = viewModel;
                await this._navigationService.NavigateToAbrirPdf(view);
                IsBusy = false;
            }
        }

    }
}

