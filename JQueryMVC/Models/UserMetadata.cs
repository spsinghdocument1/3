using System.ComponentModel.DataAnnotations;

namespace JQueryMVC.Models
{
    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {
        public class UserMetadata
        {
            [StringLength(50), Required]
            public object Name { get; set; }
            [StringLength(5)]
            public object Email { get; set; }
            [Range(0, 10)]
            public object Rating { get; set; }
        }
    }

}