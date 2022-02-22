using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Entities.Artworks;

namespace Model.Entities.Auctions; 

[Table("AUCTIONS")]
public class Auction {

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("AUCTION_ID")]
    public int Id { get; set; }

    [Required]
    [Column("DATE_OF_AUCTION")]
    public DateTime AuctionDate { get; set; }

    [Required, StringLength(100)]
    [Column("TOPIC")]
    public string Topic { get; set; }

    public AArtwork Artwork = new AArtwork();
}