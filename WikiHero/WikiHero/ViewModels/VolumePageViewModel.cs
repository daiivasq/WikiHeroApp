using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiHero.Helpers;
using WikiHero.Models;
using WikiHero.Services;
using Xamarin.Essentials;

namespace WikiHero.ViewModels
{
    public class VolumePageViewModel : BaseViewModel
    {
        public ObservableCollection<Volume> Volumes { get; set; } = new ObservableCollection<Volume>();
        public int ItemTreshold { get; set; }
        public bool IsBusy { get; set; }
        public string PublisherPrincipal { get; set; }
        private Volume selectionVolume;

        public Volume SelectionVolume
        {
            get { return selectionVolume; }
            set
            {
                selectionVolume = value; 

                if (selectionVolume != null)
                {
                    SelectionVolumes(SelectionVolume);
                }
            }
        }

        public string PublisherSecond{ get; set; }
        public string PublisherThird { get; set; }
        public DelegateCommand RefreshCommand { get; set; }
        public string Text { get; set; }
        public DelegateCommand ItemTresholdReachedCommand { get; set; }
        public DelegateCommand SearchCommand => new DelegateCommand(FindVolume);

        public VolumePageViewModel(INavigationService navigationService, IPageDialogService dialogService, ApiComicsVine apiComicsVine, string publisherPrincipal, string publisherSecond, string publisherThird, int offeset) : base(navigationService, dialogService, apiComicsVine)
        {
            this.PublisherPrincipal =publisherPrincipal;
            this.PublisherSecond = publisherSecond;
            this.PublisherThird = publisherThird;
            ItemTresholdReachedCommand = new DelegateCommand(async () =>
            {
                offeset += 100;
                await ScrollLoadComics(offeset);
            });

            RefreshCommand = new DelegateCommand(async () =>
            {
                IsBusy = true;
                Text = null;
                await LoadComics(0);
                IsBusy = false;

            });

        }


        protected async Task ScrollLoadComics(int offset)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var items = await apiComicsVine.GetMoreVolumes(offset, PublisherPrincipal, PublisherSecond, PublisherThird);
                foreach (var item in items)
                {
                    Volumes.Add(item);
                }
                if (offset == 1000)
                {
                    ItemTreshold = -1;
                    return;
                }

            
            }

            catch (Exception ex)
            {
                await dialogService.DisplayAlertAsync("Error", $"{ex.Message}", "Ok");
            }
            finally
            {
                IsBusy = false;
            }

        }
        protected async void FindVolume()
        {
         
            if (string.IsNullOrEmpty(Text))
            {
                await LoadComics(0);
            }
            else
            {
                var list = await apiComicsVine.FindVolume(Text, 0);
                Volumes = new ObservableCollection<Volume>(list);
            }
            
        }

        protected async void SelectionVolumes(Volume volume)
        {
            var param = new NavigationParameters
            {
                { nameof(Volume), volume }
            };
            await navigationService.NavigateAsync(new Uri($"{ConfigPageUri.DetailComicPage}", UriKind.Relative), param, false);
        }

        protected async Task LoadComics(int offset)
        {
            try
            {
                var comics = await apiComicsVine.GetAllVolumes(offset,PublisherPrincipal,PublisherSecond,PublisherThird);
                Volumes = new ObservableCollection<Volume>(comics);
            }
            catch (Exception ex)
            {

                await dialogService.DisplayAlertAsync("Volume", $"{ex.Message}", "Ok");

            }
        }
  }



}


