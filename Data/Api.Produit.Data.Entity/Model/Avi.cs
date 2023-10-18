using System;
using System.Collections.Generic;

namespace Api.Produit.Data.Entity.Model;

public partial class Avi
{
    public int IdAvis { get; set; }

    public int? Note { get; set; }

    public string? Commentaire { get; set; }

    public int IdArticleVariant { get; set; }

    public int IdClient { get; set; }

    public virtual ArticleVariant IdArticleVariantNavigation { get; set; } = null!;

    public virtual Client IdClientNavigation { get; set; } = null!;
}
