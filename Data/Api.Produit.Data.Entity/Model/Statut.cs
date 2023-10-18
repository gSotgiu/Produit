using System;
using System.Collections.Generic;

namespace Api.Produit.Data.Entity.Model;

public partial class Statut
{
    public int IdStatut { get; set; }

    public string? Etat { get; set; }

    public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();
}
