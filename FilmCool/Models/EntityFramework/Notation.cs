using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FilmCool.Models.EntityFramework
{
    [Table("t_j_notation_not")]
    public partial class Notation
    {
        [Key]
        [Column("utl_id")]
        public int UtilisateurId { get; set; }

        [Key]
        [Column("flm_id")]
        public int FilmId { get; set; }

        [Column("not_note")]
        [Range(0,5)]
        [Required]
        public int Note { get; set; }

        [ForeignKey("UtilisateurId")]
        [InverseProperty("NotesUtilisateur")]
        public virtual Utilisateur UtilisateurNotant { get; set; } = null!;

        [ForeignKey("FilmId")]
        [InverseProperty("NotesFilm")]
        public virtual Film FilmNote { get; set; } = null!;
    }
}