using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FilmCool.Models.EntityFramework
{
    [Table("t_e_utilisateur_utl")]
    public partial class Utilisateur
    {
        public Utilisateur(int utilisateurId, string? nom, string? prenom, string? mobile, string? mail, string? pwd, string? rue, string? codePostal, string? ville, string? pays, float? latitude, float? longitude, DateTime dateCreation)
        {
            UtilisateurId = utilisateurId;
            Nom = nom;
            Prenom = prenom;
            Mobile = mobile;
            Mail = mail;
            Pwd = pwd;
            Rue = rue;
            CodePostal = codePostal;
            Ville = ville;
            Pays = pays;
            Latitude = latitude;
            Longitude = longitude;
            DateCreation = dateCreation;
        }

        public Utilisateur(int utilisateurId, string? nom, string? prenom, string? mobile, string? mail, string? pwd, string? rue, string? codePostal, string? ville, string? pays, float? latitude, float? longitude, DateTime dateCreation, ICollection<Notation> notesUtilisateur)
        {
            UtilisateurId = utilisateurId;
            Nom = nom;
            Prenom = prenom;
            Mobile = mobile;
            Mail = mail;
            Pwd = pwd;
            Rue = rue;
            CodePostal = codePostal;
            Ville = ville;
            Pays = pays;
            Latitude = latitude;
            Longitude = longitude;
            DateCreation = dateCreation;
            NotesUtilisateur = notesUtilisateur;
        }

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
        [EmailAddress(ErrorMessage = "La longueur d'un mail doit être comprise entre 6 et 100 caractères.")]
        [MinLength(6)]
        [StringLength(100)]
        [Required]
        public string? Mail { get; set; }

        [Column("utl_pwd")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{12,20}$", ErrorMessage = "Le mot de passe doit contenir entre 12 et 20 charactères avec au moins 1 minuscule, 1 majuscule, 1 chiffre et 1 caractère spécial.")]
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

        public override bool Equals(object? obj)
        {
            return obj is Utilisateur utilisateur &&
                   UtilisateurId == utilisateur.UtilisateurId &&
                   Nom == utilisateur.Nom &&
                   Prenom == utilisateur.Prenom &&
                   Mobile == utilisateur.Mobile &&
                   Mail == utilisateur.Mail &&
                   Pwd == utilisateur.Pwd &&
                   Rue == utilisateur.Rue &&
                   CodePostal == utilisateur.CodePostal &&
                   Ville == utilisateur.Ville &&
                   Pays == utilisateur.Pays &&
                   Latitude == utilisateur.Latitude &&
                   Longitude == utilisateur.Longitude &&
                   DateCreation == utilisateur.DateCreation;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(UtilisateurId);
            hash.Add(Nom);
            hash.Add(Prenom);
            hash.Add(Mobile);
            hash.Add(Mail);
            hash.Add(Pwd);
            hash.Add(Rue);
            hash.Add(CodePostal);
            hash.Add(Ville);
            hash.Add(Pays);
            hash.Add(Latitude);
            hash.Add(Longitude);
            hash.Add(DateCreation);
            return hash.ToHashCode();
        }
    }
}