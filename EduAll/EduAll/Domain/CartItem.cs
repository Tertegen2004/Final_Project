using System.ComponentModel.DataAnnotations.Schema;

namespace EduAll.Domain
{
    public class CartItem
    {
        public int Id { get; set; }

        // Fk

        public int CartId { get; set; }
        public int CourseId { get; set; }

        // Nav Prop
        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }

        [ForeignKey(nameof(CartId))]
        public Cart Cart { get; set; }
    }
}
