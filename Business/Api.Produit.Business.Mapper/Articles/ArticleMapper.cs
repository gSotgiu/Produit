using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Produit.Business.Service.Dto.Article;
using Api.Produit.Data.Entity.Model;

namespace Api.Produit.Business.Mapper.Produit
{
    public static class ArticleMapper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="createArticle"></param>
        /// <returns></returns>
        public static Article TransformCreateDtoToEntity(CreateArticleDto createArticle)
        {
            return new Article()
            {
                Nom = createArticle.Nom,
                Description = createArticle.Description,
                PrixDefaut = createArticle.PrixDefaut,
                IdCatégorie = createArticle.IdCatégorie,
            };

        }

        public static ReadArticleDto TransformReadDtoToEntity(Article article)
        {
            return new ReadArticleDto()
            {
                Id = article.IdArticle,
                Nom = article.Nom,
                Description = article.Description,
                PrixDefaut = article.PrixDefaut,
                IdCatégorie = article.IdCatégorie,
                CatégorieNom = article.IdCatégorieNavigation.Nom,
            };

        }

        public static object TransformReadDtoToEntity(ReadArticleDto articleDto)
        {
            throw new NotImplementedException();
        }
    }
}
