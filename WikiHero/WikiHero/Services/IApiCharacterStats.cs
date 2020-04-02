using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WikiHero.Models.CharacterStatModel;

namespace WikiHero.Services
{
    public interface IApiCharacterStats
    {
        [Get("/all.json")]
        Task<List<CharacterStats>> CharacterStats();
    }
}
