using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities.Artworks; 

public class Setup : AArtwork {

    [Column("DESCRIPTION"), DataType(DataType.Text)]
    public string Description { get; set; }
    
}