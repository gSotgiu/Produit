using Api.Produit.Data.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Produit.Data.Repository.Contract
{
    public interface ICommonRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="categorieId"></param>
        /// <returns></returns>
        Task<Catégorie> GetCategorieByIdAsync(int categorieId);
    }
}
