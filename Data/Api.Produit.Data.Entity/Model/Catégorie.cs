using System;
using System.Collections.Generic;

namespace Api.Produit.Data.Entity.Model;

public partial class Catégorie
{
    public int IdCatégorie { get; set; }

    public string? Nom { get; set; }

    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
}
