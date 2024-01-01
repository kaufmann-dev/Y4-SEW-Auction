using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Entities.Artworks;

namespace Model.Entities.Auctions;

[Table("AUCTION_HAS_ITEMS_JT")]
public class AuctionItems
{
    [Column("ARTWORK_ID")]
    public int ArtworkId { get; set; }
    public AArtwork Artwork { get; set; }
    
    [Column("CUSTOMER_ID")]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    
    [Column("AUCTION_ID")]
    public int AuctionId { get; set; }
    public Auction Auction { get; set; }
    
    [Column("PRICE")]
    [Required]
    public int Price { get; set; }
}