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
                return true;
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
                return _guessedNumbers.AsReadOnly();
            } 
        }

        public GuessedNumber LastGuessedNumber 
        {
            get
            {
                return _lastGuessedNumber;
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
            // Check if guess is in between 1 and 100
            if (guess < 1 && guess > 100)
            {
                throw new System.ArgumentOutOfRangeException();
            }

            // Here i AM!
            // Figure out how to find in a list with structs, don't wanna loop them through each time... Boring
            if (_guessedNumbers.Find(guess))
            {

            }
            
            if (guess == _number)
            {
                return Outcome.Right;
            } 
            else if (guess > _number) 
            {
                return Outcome.High;
            }
            else if (guess < _number) 
            {
                return Outcome.Low;
            }
            
        }
    }
}