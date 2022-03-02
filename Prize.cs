using System;

namespace Quest
{
    public class Prize
    {
        // textual description of the prize
        private string _text;

        // constructor for Prize
        public Prize(string text)
        {
            _text = text;
        }

        // show the prize; expose _text based on adventurer's awesomeness
        public void ShowPrize(Adventurer adventurer)
        {
            if (adventurer.Awesomeness > 0)
            {
                for (int i = 1; i < adventurer.Awesomeness; i++)
                {
                    Console.WriteLine($"Congratulations! You won a prize! {_text}");
                }
            }
            else
            {
                Console.WriteLine("Your adventure was not very cash money...");
            }
        }
    }
}