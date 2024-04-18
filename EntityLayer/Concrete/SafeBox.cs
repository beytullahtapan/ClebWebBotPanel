using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class SafeBox
    {
        [Key]
        public int Id { get; set; }
        public string SafeBoxName { get; set; }
        public double SafeBoxAmount { get; set; }

    }
}
