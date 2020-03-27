using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WikiHero.Services;

namespace WikiHero.ViewModels
{
    public abstract class BaseViewModel:INotifyPropertyChanged
    {
        protected INavigationService navigationService;
        protected IPageDialogService dialogService;
        protected ApiComicsVine apiComicsVine;
        public DelegateCommand LoadListCommand { get; set; }
        public BaseViewModel(INavigationService navigationService, IPageDialogService dialogService, ApiComicsVine apiComicsVine)
        {
            this.navigationService = navigationService;
            this.dialogService = dialogService;
            this.apiComicsVine = apiComicsVine;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
