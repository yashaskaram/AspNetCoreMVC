using BookStore_App.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore_App.Repository
{
    public interface ILanguageRepository
    {
        Task<List<LanguageModel>> GetLanguages();
    }
}