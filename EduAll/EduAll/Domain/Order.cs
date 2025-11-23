using EduAll.Constant;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduAll.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public PaymentState PaymentState { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;

        // Fk

        public string UserId { get; set; }

        // Nav Prop
        [ForeignKey(nameof(UserId))]
        public AppUser User { get; set; }

        public List<CartItem> CartItems { get; set; }

    }
}
