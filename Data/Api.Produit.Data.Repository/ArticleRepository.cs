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

    public class ArticleRepository : IArticleRepository
    {
        private readonly IProduitDbContext _dBContext;
        public ArticleRepository (IProduitDbContext dbContext) 
        {
            _dBContext = dbContext;
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="articleToAdd">ajout d'un article</param>
        /// <returns></returns>
        public async Task<Article> CreateArticleAsync(Article articleToAdd)
        {
           var elementAdded = await _dBContext.Articles.AddAsync(articleToAdd).ConfigureAwait(false);
           await _dBContext.SaveChangesAsync().ConfigureAwait(false);
            return elementAdded.Entity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="articleToRemove">L'article supprimé</param>
        /// <returns></returns>
        public async Task<Article> DeleteArticleAsync(Article articleToRemove)
        {
            var elementDeleted =  _dBContext.Articles.Remove(articleToRemove);

            await _dBContext.SaveChangesAsync().ConfigureAwait(false);
            throw new Exception("l'article à supprimer n'existe pas aaaaa");
            return elementDeleted.Entity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="articleToUpdate">L'article modifié</param>
        /// <returns></returns>
        public async Task<Article> UpdateArticleAsync(Article articleToUpdate)
        {
            var elementUpdated = _dBContext.Articles.Update(articleToUpdate);
            await _dBContext.SaveChangesAsync().ConfigureAwait(false);
            return elementUpdated.Entity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Article>>GetArticlesAsync()
        {
            return await _dBContext.Articles.Include(x => x.IdCatégorieNavigation).ToListAsync().
                ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public async Task<Article>GetArticlesByIdAsync(int articleId)
        {
            return await _dBContext.Articles.Include(x => x.IdCatégorieNavigation).FirstOrDefaultAsync(x => x.IdArticle == articleId).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="articleNom"></param>
        /// <returns></returns>
        public async Task<List<Article>> GetArticlesByNomAsync(string articleNom)
        {

            return await _dBContext.Articles.Include(x => x.IdCatégorieNavigation).Where(x => x.Nom == articleNom).ToListAsync().ConfigureAwait(false);
        }
    }
}
