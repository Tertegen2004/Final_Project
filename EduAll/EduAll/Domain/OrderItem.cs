using System.ComponentModel.DataAnnotations.Schema;

namespace EduAll.Domain
{
    public class OrderItem
    {
        public int Id { get; set; }
        public decimal PriceAtPurchase { get; set; }

        // Fk
        public int OrderId { get; set; }
        public int CourseId { get; set; }

        // Nav Prop
        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }
        [ForeignKey(nameof(CourseId))]

        public Course Course { get; set; }
    }
}
