using System;
using System.Collections.Generic;

namespace Api.Produit.Data.Entity.Model;

public partial class LigneCommande
{
    public int IdLigneCommande { get; set; }

    public int? Quantite { get; set; }

    public int IdArticleVariant { get; set; }

    public int IdCommande { get; set; }

    public virtual ArticleVariant IdArticleVariantNavigation { get; set; } = null!;

    public virtual Commande IdCommandeNavigation { get; set; } = null!;
}
