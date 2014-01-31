using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using NumberGuessingGame.Models;

namespace NumberGuessingGame.ViewModels
{
    public class GuessViewModel
    {
        [Range(1, 100)]
        [Required]
        public int Guess { get; set; }
       

        public SecretNumber SecretNumber { get; set; }

        public Outcome Outcome { get; set; }

        public Dictionary<int, string> Counts { get; set; }

        public GuessViewModel()
        {
            this.Counts = new Dictionary<int, string>{
                   {0, "first"},
                   {1, "second"},
                   {2, "third"},
                   {3, "fourth"},
                   {4, "fifth"},
                   {5, "sixth"},
                   {6, "final"}
            };
           
        }

    }
}