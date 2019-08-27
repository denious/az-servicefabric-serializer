using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("CartHeader", Schema = "Cart")]
    public partial class CartHeader
    {
        public CartHeader()
        {
            CartDetail = new HashSet<CartDetail>();
        }

        public int CartID { get; set; }
        [StringLength(60)]
        public string SessionID { get; set; }
        [StringLength(400)]
        public string IdentityID { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? HeaderDiscount { get; set; }
        public int? PromoCodeID { get; set; }
        [Required]
        [StringLength(20)]
        public string Status { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedOn { get; set; }
        [Required]
        [StringLength(400)]
        public string CreatedBy { get; set; }
        [Required]
        [StringLength(400)]
        public string ModifiedBy { get; set; }

        [InverseProperty("Cart")]
        public virtual ICollection<CartDetail> CartDetail { get; set; }
    }
}
