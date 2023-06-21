using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HS2231A1.Models
    {
    public class VenueEditFormViewModel 
        {
        [Key]
        public int VenueId { get; set; }

        [Required]
        [StringLength(80)]
        [Display(Name = "Company")]
        public string Company { get; set; }
        [StringLength(70)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [StringLength(40)]
        [Display(Name = "City")]
        public string City { get; set; }

        [StringLength(40)]
        [Display(Name = "State")]
        public string State { get; set; }

        [StringLength(40)]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [StringLength(10)]
        [Display(Name = "PostalCode")]
        public string PostalCode { get; set; }

        [StringLength(24)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [StringLength(24)]
        [Display(Name = "Fax")]
        public string Fax { get; set; }

        [StringLength(60)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(60)]
        [Display(Name = "Website")]
        public string Website { get; set; }

        [Display(Name = "OpenDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? OpenDate { get; set; }

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