using System;
using System.Collections.Generic;

namespace Api.Produit.Data.Entity.Model;

public partial class Remise
{
    public int IdRemise { get; set; }

    public int? PourcentageReduction { get; set; }

    public int IdArticle { get; set; }

    public virtual Article IdArticleNavigation { get; set; } = null!;

    public virtual ICollection<Client> IdClients { get; set; } = new List<Client>();
}
