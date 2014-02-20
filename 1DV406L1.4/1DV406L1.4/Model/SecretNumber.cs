using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.ObjectModel;

namespace _1DV406L1._4.Model
{
    public enum Outcome { Indefinite, Low, High, Correct, NoMoreGuesses, PreviousGuess }

    public class SecretNumber
    {
        //Fields
        private int _number;
        private List<int> _previousGuesses;
        public const int MaxNumberOfGuesses = 7;
        //Properties
        public bool CanMakeGuess
        {
            get { return Count < MaxNumberOfGuesses && Outcome != Outcome.Correct; }
        }

        public int Count
        {
            get { return _previousGuesses.Count; }
        }

        public int? Number
        {
            get
            {
                if (CanMakeGuess)
                {
                    return null;
                }
                else
                {
                    return _number;
                }
            }
        }

        public Outcome Outcome {get; private set;}

        public ReadOnlyCollection<int> PreviousGuesses
        {
            get { return _previousGuesses.AsReadOnly(); }
        }
        //Methods

        //Gets a new random number and clears previous guesses
        public void Initialize()
        {
            Random randomNumber = new Random();
            _number = randomNumber.Next(1, 101);

            _previousGuesses.Clear();
        }

        
        public Outcome MakeGuess(int guess)
        {
            if (!CanMakeGuess)
            {
                throw new Exception("Det går inte att göra en gissning");
            }

            if (guess < 1 || guess > 100)
            {
                throw new ArgumentOutOfRangeException("Värdet måste vara 1-100");
            }

            if (PreviousGuesses.Contains(guess))
            {
                Outcome = Outcome.PreviousGuess;
            }
            else
            {
                _previousGuesses.Add(guess);

                if (guess > _number)
                {
                    Outcome = Outcome.High;
                }

                else if (guess < _number)
                {
                    Outcome = Outcome.Low;
                }
                else
                {
                    Outcome = Outcome.Correct;
                }
            }

            return Outcome;
        }
        //Initiates a new list
        public SecretNumber()
        {
            _previousGuesses = new List<int>(MaxNumberOfGuesses);
            Initialize();
        }
    }

}