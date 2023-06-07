using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Student_Smer.Models
{
    public class Smer
    {
        [Required(ErrorMessage = "SmerID je obavezan")]
        public int SmerID { get; set; }

        [DisplayName("Naziv smera")]
        [Required(ErrorMessage = "Ime je obavezno")]
        [MaxLength(50, ErrorMessage = "Ne sme vise od 50 karaktera")]
        public string NazivSmera { get; set; } = "";

        [DisplayName("Sifra smera")]
        [Required(ErrorMessage = "Sifra je obavezno")]
        [MaxLength(5, ErrorMessage = "Ne sme vise od 5 karaktera")]
        public string Sifra { get; set; } = "";

        public List<Student>? Students { get; set; }
    }
}
