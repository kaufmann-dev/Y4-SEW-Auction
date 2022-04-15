using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities.Auctions; 

[Table("CUSTOMERS")]
public class Customer {

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("CUSTOMER_ID")]
    public int Id { get; set; }

    [Required, StringLength(30)]
    [Column("LAST_NAME")]
    public string LastName { get; set; }

    [Required, StringLength(20)]
    [Column("PHONE_NR")]
    public string PhoneNr { get; set; }
    
    //[Column("CUSTOMER_NR")]
    //[StringLength(12)]
    //[Required]
    //public string CustomerNr { get; set; }
    
}