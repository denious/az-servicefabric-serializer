using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("CartDetail", Schema = "Cart")]
    public partial class CartDetail
    {
        public int CartDetailID { get; set; }
        public int CartID { get; set; }
        public int ProductID { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal UnitListPrice { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? DiscountUnitPrice { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? UnitDiscount { get; set; }
        public int Qty { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public int? PromoCodeID { get; set; }
        public int? ParentCartDetailID { get; set; }
        [Required]
        [StringLength(400)]
        public string CreatedBy { get; set; }
        [Required]
        [StringLength(400)]
        public string ModifiedBy { get; set; }

        [ForeignKey("CartID")]
        [InverseProperty("CartDetail")]
        public virtual CartHeader Cart { get; set; }
    }
}
