using System;
using System.Collections.Generic;

namespace Api.Produit.Data.Entity.Model;

public partial class OptionVariant
{
    public int IdOptionVariant { get; set; }

    public string? Valeur { get; set; }

    public int IdTypeVariant { get; set; }

    public int IdArticleVariant { get; set; }

    public virtual ArticleVariant IdArticleVariantNavigation { get; set; } = null!;

    public virtual TypeVariant IdTypeVariantNavigation { get; set; } = null!;
}
