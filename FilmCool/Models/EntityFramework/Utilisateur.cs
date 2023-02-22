using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FilmCool.Models.EntityFramework
{
    [Table("t_e_utilisateur_utl")]
    public partial class Utilisateur
    {
        [Key]
        [Column("utl_id")]
        public int UtilisateurId { get; set; }

        [Column("utl_nom")]
        [StringLength(50)]
        public string? Nom { get; set; }

        [Column("utl_prenom")]
        [StringLength(50)]
        public string? Prenom { get; set; }

        [Column("utl_mobile")]
        [RegularExpression(@"^0[0-9]{9}$", ErrorMessage="Le mobile doit contenir 10 chiffres.")]
        [MinLength(10)]
        [MaxLength(10)]
        public string? Mobile { get; set; }

        [Column("utl_mail")]
        [EmailAddress]
        [MinLength(6)]
        [StringLength(100, ErrorMessage = "La longueur d'un mail doit être comprise entre 6 et 100 caractères.")]
        [Required]
        public string? Mail { get; set; }

        [Column("utl_pwd")]
        [MinLength(12)]
        [MaxLength(20)]
        [Required]
        public string? Pwd { get; set; }

        [Column("utl_rue")]
        [StringLength(200)]
        public string? Rue { get; set; }

        [Column("utl_cp")]
        [RegularExpression(@"^[0-9]{5}$", ErrorMessage = "Le code postal doit contenir 5 chiffres.")]
        [MinLength(5)]
        [MaxLength(5)]
        public string? CodePostal { get; set; }

        [Column("utl_ville")]
        [StringLength(50)]
        public string? Ville { get; set; }

        [Column("utl_pays")]
        [StringLength(50)]
        [DefaultValue("France")]
        public string? Pays { get; set; }

        [Column("utl_latitude")]
        public float? Latitude { get; set; }

        [Column("utl_longitude")]
        public float? Longitude { get; set; }

        [Column("utl_datecreation")]
        [Required]
        public DateTime DateCreation { get; set; }

        [InverseProperty("UtilisateurNotant")]
        public virtual ICollection<Notation> NotesUtilisateur { get; } = new List<Notation>();
    }
}