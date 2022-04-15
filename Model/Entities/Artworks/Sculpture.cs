using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Model.Entities.Artworks; 

public class Sculpture : AArtwork {

    [Required, Precision(6,2), Range(0, 1000)]
    [Column("WEIGHT")]
    public float Weight { get; set; }
    
}