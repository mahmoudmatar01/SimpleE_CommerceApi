using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EShopeApi.Models
{
    public class UserLogin
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userid { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }


    }
}
