using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HS2231A1.Models
    {
    public class VenueEditViewModel:VenueAddViewModel
        {
        [Key]
        public int VenueId { get; set; }
        }
    }