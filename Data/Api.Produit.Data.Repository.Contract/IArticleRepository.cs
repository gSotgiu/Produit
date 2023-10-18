using Api.Produit.Data.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Produit.Data.Repository.Contract
{
    public interface IArticleRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="articleToAdd">L'article ajouté</param>
        /// <returns></returns>
        Task<Article> CreateArticleAsync(Article articleToAdd);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="articleToRemove">L'article supprimé</param>
        /// <returns></returns>
        Task<Article> DeleteArticleAsync(Article articleToRemove);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="articleToUpdate">L'article modifié</param>
        /// <returns></returns>
        Task<Article> UpdateArticleAsync(Article articleToUpdate);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<Article>> GetArticlesAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        Task<Article> GetArticlesByIdAsync(int articleId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="articleNom"></param>
        /// <returns></returns>
        Task<List<Article>> GetArticlesByNomAsync(string articleNom);


    }
}
