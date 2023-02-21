using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FilmCool.Models.EntityFramework
{
    [Table("t_e_film_flm")]
    public partial class Film
    {
        [Key]
        [Column("flm_id")]
        public int FilmId { get; set; }

        [Column("flm_titre")]
        [StringLength(100)]
        [Required]
        public string Titre { get; set; } = null!;

        [Column("flm_resume")]
        public string? Resume { get; set; }

        [Column("flm_datesortie")]
        public DateTime DateSortie { get; set; }

        [Column("flm_duree")]
        public decimal Duree { get; set; }

        [Column("flm_genre")]
        [StringLength(30)]
        public string? Genre { get; set; }

        [InverseProperty("FilmNote")]
        public virtual ICollection<Notation> NotesFilm { get; } = new List<Notation>();
    }
}
