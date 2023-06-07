using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Student_Smer.Models
{
    public class Student
    {
        [Required(ErrorMessage = "StudentID je obavezan")]
        public int StudentID { get; set; }

        [DisplayName("Ime studenta")]
        [Required(ErrorMessage = "Ime studenta je obavezno")]
        [MaxLength(30)]
        public string Ime { get; set; } = "";

        [DisplayName("Prezime studenta")]
        [Required(ErrorMessage = "Prezime studenta je obavezno")]
        [MaxLength(30)]
        public string Prezime { get; set; } = "";

        [DisplayName("JMBG studenta")]
        [Required(ErrorMessage = "JMBG studenta je obavezno")]
        [MaxLength(13)]
        public string JMBG { get; set; } = "";

        [DisplayName("Pol studenta")]
        [Required(ErrorMessage = "Pol studenta je obavezno")]
        [MaxLength(6)]
        public string Pol { get; set; } = "";

        [DisplayName("Aktivnost studenta")]
        public bool Aktivan { get; set; }

        [DisplayName("SmerID")]
        [Required(ErrorMessage = "SmerID je obavezno")]
        public int SmerID { get; set; }
        public Smer? Smer { get; set; }
    }
}
