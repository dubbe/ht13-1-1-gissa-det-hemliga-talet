using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NumberGuessingGame.Models
{
    public class SecretNumber
    {
        private List<GuessedNumber> _guessedNumbers;
        private GuessedNumber _lastGuessedNumber;
        private int? _number;

        const int MaxNumberOfGuesses = 7;

        public bool CanMakeGuess 
        {
            get
            {
                if (this.Count == MaxNumberOfGuesses)
                {
                    return false;
                }
                else if (this.LastGuessedNumber.Outcome == Outcome.Right)
                {
                    return false;
                }
                else 
                {
                    return true;
                }
            }
        }

        public int Count
        {
            get
            {
                if (this._guessedNumbers != null)
                {
                    return this._guessedNumbers.Count;
                }
                else
                {
                    return 0;
                }
            }
        }

        public IList<GuessedNumber> GuessedNumbers 
        {
            get
            {
                return this._guessedNumbers.AsReadOnly();
            } 
        }

        public GuessedNumber LastGuessedNumber 
        {
            get
            {
                return this._lastGuessedNumber;
            }
        }

        public int? Number 
        {
            get
            {
                if (CanMakeGuess)
                {
                    return null;
                } else {
                    return _number;
                }
            }
            private set
            {

            }
        }
        public SecretNumber()
        {
            this.Initialize();
        }

        public void Initialize()
        {
            // Generate a random number between 1-100
            Random rnd = new Random();
            _number = rnd.Next(100) + 1;

            // clear previously guessedNumbers and initialize list
            this._guessedNumbers = new List<GuessedNumber>();

        }
        

        

        public Outcome MakeGuess(int guess)
        {

            var guessedNumber = new GuessedNumber();
            guessedNumber.Number = guess;

            // Check if guess is in between 1 and 100
            if (guess < 1 || guess > 100)
            {
                throw new System.ArgumentOutOfRangeException();
            }

            // Do I have any more guesses?
            if (!this.CanMakeGuess)
            {
                return Outcome.NoMoreGuesses;
            }

            // Check if this guess is allready done
            var sameGuess = this._guessedNumbers.Where(x => x.Number == guess);
            var count = sameGuess.Count();
            if (count > 0)
            {
                return Outcome.OldGuess;
            }

            
            // So what is our guess?
            if (guess == _number)
            {
                guessedNumber.Outcome = Outcome.Right;
            } 
            else if (guess > _number) 
            {
                guessedNumber.Outcome = Outcome.High;
            }
            else if (guess < _number)
            {
                guessedNumber.Outcome = Outcome.Low;
            }
            else
            {
                guessedNumber.Outcome = Outcome.Indefinite;
            }

            // Add this guess to list
            this._guessedNumbers.Add(guessedNumber);
            this._lastGuessedNumber = guessedNumber;

            // Return outcome
            return guessedNumber.Outcome;
            
        }
    }
}