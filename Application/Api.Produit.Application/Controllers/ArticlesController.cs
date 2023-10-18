using Api.Produit.Business.Service.Contract;
using Api.Produit.Business.Service.Dto.Article;
using Api.Produit.Data.Repository;
using Api.Produit.Data.Repository.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Produit.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IProduitService _produitService;

        public ArticlesController(IProduitService produitService)
        {
            _produitService = produitService;
        }
        // GET: api/<ArticlesController>
        [HttpGet]
        [ProducesResponseType(typeof(List<ReadArticleDto>), 200)]
        public async Task<ActionResult>GetArticlesAsync()
        {
            var articlesDto = await _produitService.GetReadArticlesAsync().ConfigureAwait(false);
            return Ok(articlesDto);
        }

        //// GET api/<ArticlesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ArticlesController>
        [HttpPost]
        public async Task<ActionResult> CreateArticleAsync([FromBody] CreateArticleDto articleDto)
        {
            if (string.IsNullOrWhiteSpace(articleDto?.Nom))
            {
                return BadRequest(
                    new {Error = "Il manque le nom du produit"});
            }
            try
            {
                var elementAdded = await _produitService.CreateArticleAsync(articleDto).ConfigureAwait(false);
                return Ok(elementAdded);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nom"></param>
        /// <returns></returns>
        [HttpGet ("getByName")]
        public async Task<ActionResult> GetArticleByNameAsync([FromQuery] string nom)
        {
            var article = await _produitService.GetReadArticlesByNomAsync(nom).ConfigureAwait(false);
            if (string.IsNullOrWhiteSpace(nom))
            {
                return BadRequest(
                    new { Error = "Il manque le nom du produit" });
            }
            try
            {
                return Ok(article);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="articleDto"></param>
        /// <returns></returns>
        // PUT api/<ArticlesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateArticleAsync(int id, [FromBody] CreateArticleDto articleDto)
        {
            if (string.IsNullOrWhiteSpace(articleDto?.Nom))
            {
                return BadRequest(
                    new { Error = "Il manque l'identifiant du produit" });
            }
            try
            {
                var elementAdded = await _produitService.UpdateArticleAsync(articleDto, id).ConfigureAwait(false);
                return Ok(elementAdded);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<ArticlesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteArticleAsync(int id)
        {
            try
            {
                var elementAdded = await _produitService.DeleteArticleAsync(id).ConfigureAwait(false);
                return Ok(elementAdded);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }
    }
}
