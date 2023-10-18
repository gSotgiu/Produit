using Api.Produit.Data.Context.Contract;
using Api.Produit.Data.Entity.Model;
using Api.Produit.Data.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Produit.Data.Repository
{
    public class CommonRepository : ICommonRepository
    {
        private readonly IProduitDbContext _dBContext;
        public CommonRepository(IProduitDbContext dbContext)
        {
            _dBContext = dbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categorieId"></param>
        /// <returns></returns>
        public async Task<Catégorie> GetCategorieByIdAsync(int categorieId)
        {
            return await _dBContext.Catégories.FirstOrDefaultAsync(x => x.IdCatégorie == categorieId).ConfigureAwait(false);
        }
    }
}
