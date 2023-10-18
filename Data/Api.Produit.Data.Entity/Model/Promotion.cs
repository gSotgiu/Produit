using System;
using System.Collections.Generic;

namespace Api.Produit.Data.Entity.Model;

public partial class Promotion
{
    public int IdPromotion { get; set; }

    public DateTime? Debut { get; set; }

    public DateTime? Fin { get; set; }

    public int? PourcentageReduction { get; set; }

    public int IdArticle { get; set; }

    public virtual Article IdArticleNavigation { get; set; } = null!;
}
