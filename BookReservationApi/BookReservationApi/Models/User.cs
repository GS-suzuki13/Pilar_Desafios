using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookReservationApi.Models
{
    [Table("Users")]
    public class Users
    {
        [Column("Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Column("Name")]
        [Display(Name = "Nome")]
        public string Name { get; set; }
        [Column("UserName")]
        [Display(Name = "Nome de Usuario")]
        public string UserName { get; set; }
        [Column("Password")]
        [Display(Name = "Senha")]
        public string Password { get; set; }
        [Column("Reserve")]
        [Display(Name = "Reserva")]
        public string Reserve { get; set; }
    }
}
