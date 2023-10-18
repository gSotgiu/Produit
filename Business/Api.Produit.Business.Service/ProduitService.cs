using Api.Produit.Business.Service.Contract;
using Api.Produit.Business.Mapper;
using Api.Produit.Business.Service.Dto.Article;
using Api.Produit.Data.Entity.Model;
using Api.Produit.Data.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Api.Produit.Business.Mapper.Produit;
using System.Reflection.Metadata;

namespace Api.Produit.Business.Service
{

    /// <summary>
    /// 
    /// </summary>
    public class ProduitService : IProduitService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly ICommonRepository _commonRepository;

        public ProduitService (IArticleRepository articleRepository, ICommonRepository commonRepository)
        {
            _articleRepository = articleRepository;
            _commonRepository = commonRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<ReadArticleDto>> GetReadArticlesAsync()
        {
            var articles = await _articleRepository.GetArticlesAsync().ConfigureAwait(false);
            List<ReadArticleDto> readArticlesDtos = new List<ReadArticleDto>();
            foreach (var article in articles) 
            {
                readArticlesDtos.Add(ArticleMapper.TransformReadDtoToEntity(article));
            }
            return readArticlesDtos;
         }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nom"></param>
        /// <returns></returns>
        public async Task<List<ReadArticleDto>> GetReadArticlesByNomAsync(string nom)
        {
            var articles = await _articleRepository.GetArticlesByNomAsync(nom).ConfigureAwait(false);
            List<ReadArticleDto> readArticlesDtos = new List<ReadArticleDto>();
            foreach (var article in articles)
            {
                readArticlesDtos.Add(ArticleMapper.TransformReadDtoToEntity(article));
            }
            return readArticlesDtos;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="nom"></param>
        /// <returns></returns>
        public async Task<ReadArticleDto> DeleteArticleAsync(int id)
        {

            var article = await _articleRepository.GetArticlesByIdAsync(id).ConfigureAwait(false);
            if (article == null)
            {
                throw new Exception("l'article à supprimer n'existe pas");
            }
            var deletedArticle = await _articleRepository.DeleteArticleAsync(article).ConfigureAwait(false);
            return ArticleMapper.TransformReadDtoToEntity(deletedArticle);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="articleDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<ReadArticleDto> CreateArticleAsync(CreateArticleDto articleDto)
        {
            if (articleDto == null) { 
            
            throw new ArgumentNullException(nameof(articleDto));
            }
            var categorie = await _commonRepository.GetCategorieByIdAsync(articleDto.IdCatégorie).ConfigureAwait(false);
            if (categorie == null) {
                throw new Exception("echec, aucune catégorie ne correspond à cette identifiant");
            }
            var articleToAdd = ArticleMapper.TransformCreateDtoToEntity(articleDto);
            var articleAdded = await _articleRepository.CreateArticleAsync(articleToAdd).ConfigureAwait(false);
           return ArticleMapper.TransformReadDtoToEntity(articleAdded);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="articleDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<ReadArticleDto> UpdateArticleAsync(CreateArticleDto articleDto, int id)
        {
            if (articleDto == null)
            {

                throw new ArgumentNullException(nameof(articleDto));
            }
            var currentArticle = await _articleRepository.GetArticlesByIdAsync(id).ConfigureAwait(false);
            if (currentArticle == null)
            {
                throw new Exception("echec, l'identifiant de l'article n'existe pas");
            }
            var articleToAdd = ArticleMapper.TransformCreateDtoToEntity(articleDto);
            var articleAdded = await _articleRepository.CreateArticleAsync(articleToAdd).ConfigureAwait(false);

            map(articleAdded, currentArticle);
            var updatedArticle = await _articleRepository.UpdateArticleAsync(currentArticle).ConfigureAwait(false);
            return ArticleMapper.TransformReadDtoToEntity(updatedArticle);
        }
        private void map(Article article, Article articleToUpdate)
        {
            articleToUpdate.Nom = article.Nom;
            articleToUpdate.Description = article.Description;
            articleToUpdate.PrixDefaut = article.PrixDefaut;
            articleToUpdate.IdCatégorie = article.IdCatégorie;
        }

    }
}
