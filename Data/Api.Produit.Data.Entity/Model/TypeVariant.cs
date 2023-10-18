using System;
using System.Collections.Generic;

namespace Api.Produit.Data.Entity.Model;

public partial class TypeVariant
{
    public int IdTypeVariant { get; set; }

    public string? NomType { get; set; }

    public virtual ICollection<OptionVariant> OptionVariants { get; set; } = new List<OptionVariant>();
}
