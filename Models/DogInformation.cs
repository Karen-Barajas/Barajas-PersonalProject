using System.ComponentModel.DataAnnotations;

namespace TheMaxieInn.Models
{
    public class DogInformation
    {
        public int DogId { get; set; }
        public int ReservationId { get; set; }
        [Required]
        [Display(Name = "Dog's Name")]
        public string DogName { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Breed { get; set; }
        [Required]
        public string Sex { get; set; }
        [Display(Name = "Spayed/Neutered")]
        [Required]
        public bool SpayedOrNeutered { get; set; }
        [Display(Name = "Vaccinated")]
        [Required]
        public bool Vaccinated { get; set; }
        [Display(Name = "Special Accommodation")]
        [Required]
        public bool SpecialAccommodation { get; set; }

        public DogReservation DogReservation { get; set; }
    }
}
