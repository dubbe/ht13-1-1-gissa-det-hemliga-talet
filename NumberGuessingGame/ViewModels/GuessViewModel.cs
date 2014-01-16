using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NumberGuessingGame.ViewModels
{
    public class GuessViewModel
    {
        [Required]
        public int Guess { get; set; }
    }
}