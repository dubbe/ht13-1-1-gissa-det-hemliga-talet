using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumberGuessingGame.Models
{
    enum Outcome
    {
        Indefinite, 
        Low,
        High,
        Right,
        NoMoreGuesses,
        OldGuess
    }
}
