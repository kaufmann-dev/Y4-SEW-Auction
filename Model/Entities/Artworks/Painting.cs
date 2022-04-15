using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities.Artworks; 

public class Painting : AArtwork {

    [Required, Range(0, 500)]
    [Column("HEIGHT")]
    public int Height { get; set; }

    [Required, Range(0, 500)]
    [Column("WIDTH")]    
    public int Width { get; set; }
    
}