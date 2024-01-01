using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Entities.Auctions;

namespace Model.Entities.Artworks; 

[Table("WORKS_OF_ART_BT")]
public class AArtwork {

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("ARTWORK_ID")]
    public int Id { get; set; }

    [Required, StringLength(150)]
    [Column("NAME")]
    public string Name { get; set; }

    [Required]
    [Column("AESTIMATED_VALUE")]
    public int AestimatedValue { get; set; }
}