using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WikiHeroApp.Models.CharacterStatModel;

namespace WikiHeroApp.Services
{
    public interface IApiCharacterStats
    {
        [Get("/all.json")]
        Task<List<CharacterStats>> CharacterStats();
    }
}
