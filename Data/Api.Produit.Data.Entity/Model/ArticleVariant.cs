using System;
using System.Collections.Generic;

namespace Api.Produit.Data.Entity.Model;

public partial class ArticleVariant
{
    public int IdArticleVariant { get; set; }

    public int? PrixSpecifique { get; set; }

    public string? Image { get; set; }

    public int IdArticle { get; set; }

    public virtual ICollection<Avi> Avis { get; set; } = new List<Avi>();

    public virtual Article IdArticleNavigation { get; set; } = null!;

    public virtual ICollection<LigneCommande> LigneCommandes { get; set; } = new List<LigneCommande>();

    public virtual ICollection<OptionVariant> OptionVariants { get; set; } = new List<OptionVariant>();

    public virtual Stock? Stock { get; set; }
}
