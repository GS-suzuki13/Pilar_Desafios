using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookReservationApi.Models
{
    [Table("Books")]
    public class Books
    {
        [Column("Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Column("BookName")]
        [Display(Name = "Nome do Livro")]
        public string BookName { get; set; }
        [Column("Author")]
        [Display(Name = "Autor")]
        public string Author { get; set; }
        [Column("Synopsis")]
        [Display(Name = "Sinopse")]
        public string Synopsis { get; set; }
        [Column("ReleaseDate")]
        [Display(Name = "Data de Lancamento")]
        public string ReleaseDate { get; set; }
        [Column("Status")]
        [Display(Name = "Status")]
        public bool Status { get; set; }
        [Column("Reserve")]
        [Display(Name = "Reserva")]
        public string Reserve { get; set; }

    }
}
