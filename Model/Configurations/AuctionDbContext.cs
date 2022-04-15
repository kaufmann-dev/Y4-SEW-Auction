using Microsoft.EntityFrameworkCore;
using Model.Entities.Artworks;
using Model.Entities.Auctions;

namespace Model.Configurations; 

public class AuctionDbContext : DbContext{

    public DbSet<AArtwork> Artworks { get; set; }
    public DbSet<Auction> Auctions { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<AuctionItems> AuctionItems { get; set; }

    public AuctionDbContext(DbContextOptions<AuctionDbContext> options) : base(options) {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<AArtwork>()
            .HasIndex(a => a.Name)
            .IsUnique();

        builder.Entity<AArtwork>()
            .HasDiscriminator<string>("WORK_OF_ART_TYPE")
            .HasValue<Setup>("SETUP")
            .HasValue<Sculpture>("SCULPTURE")
            .HasValue<Painting>("PAINTING");

        //builder.Entity<Customer>()
        //    .HasIndex(c => c.CustomerNr)
        //    .IsUnique();

        builder.Entity<AuctionItems>().HasKey(a => new
        {
            a.ArtworkId,
            a.CustomerId
        });

        builder.Entity<AuctionItems>()
            .HasOne(m => m.Customer)
            .WithMany()
            .HasForeignKey(m => m.CustomerId);

        builder.Entity<AuctionItems>()
            .HasOne(m => m.Artwork)
            .WithMany()
            .HasForeignKey(m => m.ArtworkId);

        builder.Entity<AuctionItems>()
            .HasOne(a => a.Artwork)
            .WithMany(a => a.CoolList)
            .HasForeignKey(a => a.ArtworkId);
    }
}