using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HS2231A1.Models
    {
    public class VenueEditFormViewModel : VenueAddViewModel
        {
        [Key]
        public int VenueId { get; set; }

        // Advance Ticket Sale Password
        [Display(Name = "Advance Ticket Sale Password")]
        [DataType(DataType.Password)]
        public string TicketSalePassword { get; set; }

        // Promo Codo
        [Display(Name = "Promo Code")]
        [DisplayFormat(DataFormatString ="{0:NNLLL}",ApplyFormatInEditMode = true)]
        [RegularExpression(@"^\d{2} [A-Z]{3}$",ErrorMessage ="Promo Code must be in the format 'NNLLL' (e.g., 12XYZ)")]
        public string PromoCode { get; set; }

        // Capacity
        [Display(Name ="Concert Capacity")]
        [Range(1,75000,ErrorMessage ="Capacity must be between 1 and 75,000")]
        public int Capacity { get; set; }
        }
    }