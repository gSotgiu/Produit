using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Produit.Business.Service.Dto.Article
{
    public class ReadArticleDto : CreateArticleDto
    {
        public int Id { get; set; }

        public string? Nom { get; set; }

        public string? Description { get; set; }

        public int? PrixDefaut { get; set; }

        public int? IdCatégorie { get; set; }

        public string? CatégorieNom { get; set; }
    }

}
