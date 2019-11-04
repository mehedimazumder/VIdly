﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Driving License")]
        public string DrivingLicense { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}