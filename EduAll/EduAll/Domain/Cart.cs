using System.ComponentModel.DataAnnotations.Schema;

namespace EduAll.Domain
{
    public class Cart
    {
        public int Id { get; set; }

        public DateTime UpdatedAt { get; set; }

        // Fk

        public string UserId { get; set; }

        // Nav Prop
        [ForeignKey(nameof(UserId))]
        public AppUser User { get; set; }

        public List<CartItem> CartItems { get; set; }

    }
}
