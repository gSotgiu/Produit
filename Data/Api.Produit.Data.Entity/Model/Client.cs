using System;
using System.Collections.Generic;

namespace Api.Produit.Data.Entity.Model;

public partial class Client
{
    public int IdClient { get; set; }

    public string? Prenom { get; set; }

    public string? Pseudo { get; set; }

    public string? Nom { get; set; }

    public string? Email { get; set; }

    public string? MotDePasse { get; set; }

    public int IdAdresse { get; set; }

    public virtual ICollection<Avi> Avis { get; set; } = new List<Avi>();

    public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();

    public virtual Adresse IdAdresseNavigation { get; set; } = null!;

    public virtual ICollection<Remise> IdRemises { get; set; } = new List<Remise>();
}
