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
                if (_guessedNumbers.Count() == MaxNumberOfGuesses)
                {
                    return true;
                }
                else 
                {
                    return false;
                }
            }
        }

        public int Count
        {
            get
            {
                return _guessedNumbers.Count;
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
            throw new System.NotImplementedException();
        }

        public void Initialize()
        {
            // clear previously guessedNumbers
            _guessedNumbers.Clear();

            // Generate a random number between 1-100
            Random rnd = new Random();
            _number = rnd.Next(100) + 1;

        }
        

        

        public Outcome MakeGuess(int guess)
        {

            var guessedNumber = new GuessedNumber();
            guessedNumber.Number = guess;

            // Check if guess is in between 1 and 100
            if (guess < 1 && guess > 100)
            {
                throw new System.ArgumentOutOfRangeException();
            }

            // Do I have any more guesses?
            if (CanMakeGuess)
            {
                return Outcome.NoMoreGuesses;
            }

            // Check if this guess is allready done
            var sameGuess = _guessedNumbers.Where(x => x.Number == guess);
            if (sameGuess.Count() > 0)
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
            else
            {
                guessedNumber.Outcome = Outcome.Low;
            }

            // Add this guess to list
            _guessedNumbers.Add(guessedNumber);

            // Return outcome
            return guessedNumber.Outcome;
            
        }
    }
}