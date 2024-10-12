using System.ComponentModel.DataAnnotations;

namespace TheMaxieInn.ViewModels
{
    public class DogOwnerViewModel
    {
        public int OwnerId { get; set; }
        public int ReservationId { get; set; }
        [Required]
        [Display(Name = "Owner's Name")]
        public string OwnerName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
