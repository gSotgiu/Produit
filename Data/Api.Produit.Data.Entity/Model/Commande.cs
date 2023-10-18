using System;
using System.Collections.Generic;

namespace Api.Produit.Data.Entity.Model;

public partial class Commande
{
    public int IdCommande { get; set; }

    public DateTime? DateCommande { get; set; }

    public int IdAdresse { get; set; }

    public int IdStatut { get; set; }

    public int IdClient { get; set; }

    public virtual Adresse IdAdresseNavigation { get; set; } = null!;

    public virtual Client IdClientNavigation { get; set; } = null!;

    public virtual Statut IdStatutNavigation { get; set; } = null!;

    public virtual ICollection<LigneCommande> LigneCommandes { get; set; } = new List<LigneCommande>();
}
