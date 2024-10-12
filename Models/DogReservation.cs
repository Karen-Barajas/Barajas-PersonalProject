using System.ComponentModel.DataAnnotations;

namespace TheMaxieInn.Models
{
    public class DogReservation
    {
        public int ReservationId { get; set; }
        [Required]
        [Display(Name = "Check In Date")]
        [DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; }

        [Required]
        [Display(Name = "Check Out Date")]
        [DataType(DataType.Date)]
        public DateTime CheckOutDate { get; set; }

        public DogOwner DogOwner { get; set; }
        public DogInformation DogInformation { get; set; }
    }
}
