using System.ComponentModel.DataAnnotations;

namespace TheMaxieInn.ViewModels
{
    public class DogReservationViewModel
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
    }
}
