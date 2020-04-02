using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using WikiHero.Models;
using WikiHero.Services;

namespace WikiHero.ViewModels
{
    public class DetailCharactersPageViewModel : BaseViewModel, INavigationAware
    {
        public ObservableCollection<Character> Characters { get; set; }
        public ObservableCollection<Character> CharactersEnemys { get; set; }
        public ObservableCollection<Comic> Comics { get; set; }
        public Character Character { get; set; }
        public DelegateCommand LoadCommand { get; set; }
        public DetailCharactersPageViewModel(INavigationService navigationService, IPageDialogService dialogService, IApiComicsVine apiComicsVine) : base(navigationService, dialogService, apiComicsVine)
        {



        }

        async Task LoadCharacter(int idCharacter)
        {
            try
            {
                var character = await apiComicsVine.FindCharacter(idCharacter, Config.Apikey,  null);
                Character = Character;
            }
            catch (Exception err)
            {

                await dialogService.DisplayAlertAsync("Error", $"{err}", "ok");
            }

        }
        async Task LoadCVolumes()
        {
            try
            {
                string volume= null;
                foreach (var item in Character.VolumeCredits)
                {
                    volume += $"{item.Id}||";
                }
               
                var character = await apiComicsVine.FindCharactersVolumes(Config.Apikey, volume, null);
                Character = Character;
            }
            catch (Exception err)
            {

                await dialogService.DisplayAlertAsync("Error", $"{err}", "ok");
            }

        }
        async Task LoadCharacterEnemyy()
        {
            try
            {
                string volume = null;
                foreach (var item in Character.CharacterEnemies)
                {
                    volume += $"{item.Id}||";
                }

                var character = await apiComicsVine.FindEnenmyCharacter(Config.Apikey, volume, null);
                CharactersEnemys = new ObservableCollection<Character>(character.Characters);
            }
            catch (Exception err)
            {

                await dialogService.DisplayAlertAsync("Error", $"{err}", "ok");
            }

        }
        //async Task LoadComics()
        //{
        //    try
        //    {
        //        string comic = null;
        //        foreach (var item in Character.Issues)
        //        {
        //            comic += $"{item.Id}||";
        //        }

        //        var comics = await apiComicsVine.FindCharacterComics(Config.Apikey, comic, null);
        //        Comics = new ObservableCollection<Comic   >(comics.Results);
        //    }
        //    catch (Exception err)
        //    {

        //        await dialogService.DisplayAlertAsync("Error", $"{err}", "ok");
        //    }

        //}





        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            var param = (Character)parameters[nameof(Character)];
            Character = param;                                                                                             
            LoadCommand = new DelegateCommand(async () => await LoadCharacter(Character.Id));
            LoadCommand.Execute();
        }
    }
}
