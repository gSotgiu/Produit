using System;
using System.Collections.Generic;
using Api.Produit.Data.Context.Contract;
using Api.Produit.Data.Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.Produit.Data.Entity;

public partial class PrdoduitDBContext : DbContext, IProduitDbContext
{
    public PrdoduitDBContext()
    {
    }

    public PrdoduitDBContext(DbContextOptions<PrdoduitDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adresse> Adresses { get; set; }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<ArticleVariant> ArticleVariants { get; set; }

    public virtual DbSet<Avi> Avis { get; set; }

    public virtual DbSet<Catégorie> Catégories { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Commande> Commandes { get; set; }

    public virtual DbSet<LigneCommande> LigneCommandes { get; set; }

    public virtual DbSet<OptionVariant> OptionVariants { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<Remise> Remises { get; set; }

    public virtual DbSet<Statut> Statuts { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<TypeVariant> TypeVariants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;database=product;port=3306", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.23-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Adresse>(entity =>
        {
            entity.HasKey(e => e.IdAdresse).HasName("PRIMARY");

            entity.ToTable("Adresse");

            entity.Property(e => e.CodePostal)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Pays).HasMaxLength(100);
            entity.Property(e => e.Rue).HasColumnType("text");
            entity.Property(e => e.Ville).HasMaxLength(150);
        });

        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => e.IdArticle).HasName("PRIMARY");

            entity.ToTable("Article");

            entity.HasIndex(e => e.IdCatégorie, "IdCatégorie");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Nom).HasMaxLength(100);

            entity.HasOne(d => d.IdCatégorieNavigation).WithMany(p => p.Articles)
                .HasForeignKey(d => d.IdCatégorie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Article_ibfk_1");
        });

        modelBuilder.Entity<ArticleVariant>(entity =>
        {
            entity.HasKey(e => e.IdArticleVariant).HasName("PRIMARY");

            entity.ToTable("ArticleVariant");

            entity.HasIndex(e => e.IdArticle, "IdArticle");

            entity.Property(e => e.Image).HasMaxLength(200);

            entity.HasOne(d => d.IdArticleNavigation).WithMany(p => p.ArticleVariants)
                .HasForeignKey(d => d.IdArticle)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ArticleVariant_ibfk_1");
        });

        modelBuilder.Entity<Avi>(entity =>
        {
            entity.HasKey(e => e.IdAvis).HasName("PRIMARY");

            entity.HasIndex(e => e.IdArticleVariant, "IdArticleVariant");

            entity.HasIndex(e => e.IdClient, "IdClient");

            entity.Property(e => e.Commentaire).HasColumnType("text");

            entity.HasOne(d => d.IdArticleVariantNavigation).WithMany(p => p.Avis)
                .HasForeignKey(d => d.IdArticleVariant)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Avis_ibfk_1");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Avis)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Avis_ibfk_2");
        });

        modelBuilder.Entity<Catégorie>(entity =>
        {
            entity.HasKey(e => e.IdCatégorie).HasName("PRIMARY");

            entity.ToTable("Catégorie");

            entity.Property(e => e.Nom).HasMaxLength(50);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("PRIMARY");

            entity.ToTable("Client");

            entity.HasIndex(e => e.IdAdresse, "IdAdresse");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.MotDePasse).HasMaxLength(50);
            entity.Property(e => e.Nom).HasMaxLength(50);
            entity.Property(e => e.Prenom).HasMaxLength(50);
            entity.Property(e => e.Pseudo).HasMaxLength(50);

            entity.HasOne(d => d.IdAdresseNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdAdresse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Client_ibfk_1");

            entity.HasMany(d => d.IdRemises).WithMany(p => p.IdClients)
                .UsingEntity<Dictionary<string, object>>(
                    "Beneficie",
                    r => r.HasOne<Remise>().WithMany()
                        .HasForeignKey("IdRemise")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Beneficie_ibfk_2"),
                    l => l.HasOne<Client>().WithMany()
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Beneficie_ibfk_1"),
                    j =>
                    {
                        j.HasKey("IdClient", "IdRemise")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("Beneficie");
                        j.HasIndex(new[] { "IdRemise" }, "IdRemise");
                    });
        });

        modelBuilder.Entity<Commande>(entity =>
        {
            entity.HasKey(e => e.IdCommande).HasName("PRIMARY");

            entity.ToTable("Commande");

            entity.HasIndex(e => e.IdAdresse, "IdAdresse");

            entity.HasIndex(e => e.IdClient, "IdClient");

            entity.HasIndex(e => e.IdStatut, "IdStatut");

            entity.Property(e => e.DateCommande).HasColumnType("datetime");

            entity.HasOne(d => d.IdAdresseNavigation).WithMany(p => p.Commandes)
                .HasForeignKey(d => d.IdAdresse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Commande_ibfk_1");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Commandes)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Commande_ibfk_3");

            entity.HasOne(d => d.IdStatutNavigation).WithMany(p => p.Commandes)
                .HasForeignKey(d => d.IdStatut)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Commande_ibfk_2");
        });

        modelBuilder.Entity<LigneCommande>(entity =>
        {
            entity.HasKey(e => e.IdLigneCommande).HasName("PRIMARY");

            entity.ToTable("LigneCommande");

            entity.HasIndex(e => e.IdArticleVariant, "IdArticleVariant");

            entity.HasIndex(e => e.IdCommande, "IdCommande");

            entity.HasOne(d => d.IdArticleVariantNavigation).WithMany(p => p.LigneCommandes)
                .HasForeignKey(d => d.IdArticleVariant)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("LigneCommande_ibfk_1");

            entity.HasOne(d => d.IdCommandeNavigation).WithMany(p => p.LigneCommandes)
                .HasForeignKey(d => d.IdCommande)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("LigneCommande_ibfk_2");
        });

        modelBuilder.Entity<OptionVariant>(entity =>
        {
            entity.HasKey(e => e.IdOptionVariant).HasName("PRIMARY");

            entity.ToTable("OptionVariant");

            entity.HasIndex(e => e.IdArticleVariant, "IdArticleVariant");

            entity.HasIndex(e => e.IdTypeVariant, "IdTypeVariant");

            entity.Property(e => e.Valeur).HasMaxLength(50);

            entity.HasOne(d => d.IdArticleVariantNavigation).WithMany(p => p.OptionVariants)
                .HasForeignKey(d => d.IdArticleVariant)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("OptionVariant_ibfk_2");

            entity.HasOne(d => d.IdTypeVariantNavigation).WithMany(p => p.OptionVariants)
                .HasForeignKey(d => d.IdTypeVariant)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("OptionVariant_ibfk_1");
        });

        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.HasKey(e => e.IdPromotion).HasName("PRIMARY");

            entity.ToTable("Promotion");

            entity.HasIndex(e => e.IdArticle, "IdArticle");

            entity.Property(e => e.Debut).HasColumnType("datetime");
            entity.Property(e => e.Fin).HasColumnType("datetime");

            entity.HasOne(d => d.IdArticleNavigation).WithMany(p => p.Promotions)
                .HasForeignKey(d => d.IdArticle)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Promotion_ibfk_1");
        });

        modelBuilder.Entity<Remise>(entity =>
        {
            entity.HasKey(e => e.IdRemise).HasName("PRIMARY");

            entity.ToTable("Remise");

            entity.HasIndex(e => e.IdArticle, "IdArticle");

            entity.HasOne(d => d.IdArticleNavigation).WithMany(p => p.Remises)
                .HasForeignKey(d => d.IdArticle)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Remise_ibfk_1");
        });

        modelBuilder.Entity<Statut>(entity =>
        {
            entity.HasKey(e => e.IdStatut).HasName("PRIMARY");

            entity.ToTable("Statut");

            entity.Property(e => e.Etat).HasMaxLength(50);
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => e.IdStock).HasName("PRIMARY");

            entity.ToTable("Stock");

            entity.HasIndex(e => e.IdArticleVariant, "IdArticleVariant").IsUnique();

            entity.HasOne(d => d.IdArticleVariantNavigation).WithOne(p => p.Stock)
                .HasForeignKey<Stock>(d => d.IdArticleVariant)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Stock_ibfk_1");
        });

        modelBuilder.Entity<TypeVariant>(entity =>
        {
            entity.HasKey(e => e.IdTypeVariant).HasName("PRIMARY");

            entity.ToTable("TypeVariant");

            entity.Property(e => e.NomType).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
