using System;
using System.Collections.Generic;

namespace Api.Produit.Data.Entity.Model;

public partial class Stock
{
    public int IdStock { get; set; }

    public int? QuantiteDisponible { get; set; }

    public int IdArticleVariant { get; set; }

    public virtual ArticleVariant IdArticleVariantNavigation { get; set; } = null!;
}
