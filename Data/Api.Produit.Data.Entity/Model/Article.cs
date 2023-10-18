using System;
using System.Collections.Generic;

namespace Api.Produit.Data.Entity.Model;

public partial class Article
{
    public int IdArticle { get; set; }

    public string? Nom { get; set; }

    public string? Description { get; set; }

    public int? PrixDefaut { get; set; }

    public int IdCatégorie { get; set; }

    public virtual ICollection<ArticleVariant> ArticleVariants { get; set; } = new List<ArticleVariant>();

    public virtual Catégorie IdCatégorieNavigation { get; set; } = null!;

    public virtual ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();

    public virtual ICollection<Remise> Remises { get; set; } = new List<Remise>();
}
