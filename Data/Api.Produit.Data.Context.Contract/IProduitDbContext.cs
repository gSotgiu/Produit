using Api.Produit.Data.Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Api.Produit.Data.Context.Contract
{
    public interface IProduitDbContext : IDbContext
    {
        DbSet<Adresse> Adresses { get; set; }

        DbSet<Avi> Avis { get; set; }

        DbSet<Catégorie> Catégories { get; set; }

        DbSet<Client> Clients { get; set; }

        DbSet<Commande> Commandes { get; set; }

        DbSet<LigneCommande> LigneCommandes { get; set; }

        DbSet<OptionVariant> OptionVariants { get; set; }

        DbSet<Article> Articles { get; set; }

        DbSet<ArticleVariant> ArticleVariants { get; set; }

        DbSet<Promotion> Promotions { get; set; }

        DbSet<Remise> Remises { get; set; }

        DbSet<Statut> Statuts { get; set; }

        DbSet<Stock> Stocks { get; set; }

        DbSet<TypeVariant> TypeVariants { get; set; }

    }
}
