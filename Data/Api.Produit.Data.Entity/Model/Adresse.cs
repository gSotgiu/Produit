using System;
using System.Collections.Generic;

namespace Api.Produit.Data.Entity.Model;

public partial class Adresse
{
    public int IdAdresse { get; set; }

    public string? Ville { get; set; }

    public string? Rue { get; set; }

    public string? CodePostal { get; set; }

    public string? Pays { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();
}
