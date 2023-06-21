using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HS2231A1.Models
    {
    public class VenueEditViewModel
        {
        [Key]
        public int VenueId { get; set; }

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
        }
    }