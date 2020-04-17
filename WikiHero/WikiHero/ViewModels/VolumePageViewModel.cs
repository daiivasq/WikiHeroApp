﻿using Prism.Commands;
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
using Xamarin.Forms.StateSquid;

namespace WikiHero.ViewModels
{
    public class VolumePageViewModel : BaseViewModel, INavigationAware
    {
        public ObservableCollection<Volume> Volumes { get; set; } = new ObservableCollection<Volume>();
        public int ItemTreshold { get; set; }
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


        public VolumePageViewModel(INavigationService navigationService, IPageDialogService dialogService, IApiComicsVine apiComicsVine) : base(navigationService, dialogService, apiComicsVine)
        {
            int offeset = 0;

            ItemTresholdReachedCommand = new DelegateCommand(async () =>
            {
                offeset += 100;
                await ScrollLoadComics(offeset);
            });

            RefreshCommand = new DelegateCommand(async () =>
            {
                IsBusy = true;
                Text = string.Empty;
                await LoadComics();
                IsBusy = false;

            });
            LoadListCommand = new DelegateCommand(async () =>
            {
                await LoadComics();
            });

        }


        protected async Task ScrollLoadComics(int offset)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var volumes = await apiComicsVine.GetMoreVolumes(Config.Apikey,offset, Publisher);
                var notNull = from item in volumes.Volumes where item.Publisher != null select item;
                var marvelOrDc = notNull.Where(e => e.Publisher.Name.Contains(Publisher) || e.Publisher.Name.Contains(PublisherSecond) || e.Publisher.Name.Contains(PublisherThird));
                foreach (var item in marvelOrDc)
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
                CurrentState = State.None;
            }

        }
        protected async void FindVolume()
        {
         
            if (string.IsNullOrEmpty(Text))
            {
                await LoadComics();
            }
            else
            {
                var volumes = await apiComicsVine.SearchVolume(Text,Config.Apikey,0);
                var notNull = from item in volumes.Volumes where item.Publisher != null select item;
                var marvelOrDc = notNull.Where(e => e.Publisher.Name == Publisher || e.Publisher.Name == PublisherSecond || e.Publisher.Name == PublisherThird);
                Volumes = new ObservableCollection<Volume>(marvelOrDc);
            }
            
        }

        protected async void SelectionVolumes(Volume volume)
        {
            var param = new NavigationParameters
            {
                { nameof(Volume), volume }
            };
            await navigationService.NavigateAsync(new Uri($"{ConfigPageUri.DetailVolumePage}", UriKind.Relative), param);
        }

        protected async Task LoadComics()
        {
            try
            {
                CurrentState = State.Loading;
                var volumes = await apiComicsVine.GetMVolumes(Config.Apikey, Publisher);
                var notNull = from item in volumes.Volumes where item.Publisher != null select item;
                var marvelOrDc = notNull.Where(e => e.Publisher.Name.Contains(Publisher) || e.Publisher.Name.Contains(PublisherSecond) || e.Publisher.Name.Contains(PublisherThird));
                Volumes = new ObservableCollection<Volume>(marvelOrDc);
                CurrentState = State.None;
            }
            catch (Exception ex)
            {
                CurrentState = State.Error;
                CurrentState = State.None;

            }
            finally
            {
                CurrentState = State.None;
            }
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
           
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            var param = (ETypeApplication)parameters[$"{ConfigPageUri.NextPage}"];
            Publisher = param.ToString();
            switch (Publisher)
            {
                case "DC":
                    {
                        PublisherSecond = "Warner Brothers";
                        PublisherThird = "Dynamite Entertainment";
                        break;
                    }
                case "Marvel":
                    {
                        PublisherSecond = "Fawcett Publications";
                        PublisherThird = "Atlas";
                        PublisherFourth = "Disney";
                        break;
                    }
                default:
                    break;
            }
            LoadListCommand.Execute();
        }
    }



}


