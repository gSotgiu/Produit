using Api.Produit.Business.Service.Dto.Article;
using Api.Produit.Data.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Produit.Business.Service.Contract
{
    public interface IProduitService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<ReadArticleDto>> GetReadArticlesAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="articleDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        Task<ReadArticleDto> CreateArticleAsync(CreateArticleDto articleDto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nom"></param>
        /// <returns></returns>
        Task<List<ReadArticleDto>> GetReadArticlesByNomAsync(string nom);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="articleDto"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ReadArticleDto> UpdateArticleAsync(CreateArticleDto articleDto, int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ReadArticleDto> DeleteArticleAsync(int id);
    }
}
