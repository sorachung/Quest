using System;
using System.Collections.Generic;
using System.Linq;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge
            Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
            Challenge theAnswer = new Challenge(
                "What's the answer to life, the universe and everything?", 42, 25);
            Challenge whatSecond = new Challenge(
                "What is the current second?", DateTime.Now.Second, 50);

            int randomNumber = new Random().Next() % 10;
            Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

            Challenge favoriteBeatle = new Challenge(
                @"Who's your favorite Beatle?
    1) John
    2) Paul
    3) George
    4) Ringo
",
                4, 20
            );

            Challenge whatHour = new Challenge("What hour is it?", DateTime.Now.Hour, 50);
            Challenge bestNumber = new Challenge("What is the best number?", 24, 25);

            Random randomizer = new Random();
            int num1 = randomizer.Next(1, 101);
            int num2 = randomizer.Next(1, 101);
            Challenge multiplication = new Challenge($"What is {num1} x {num2}?", num1 * num2, 150);


            // "Awesomeness" is like our Adventurer's current "score"
            // A higher Awesomeness is better

            // Here we set some reasonable min and max values.
            //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
            //  If an Adventurer has an Awesomeness less than the min, they are terrible
            int minAwesomeness = 0;
            int maxAwesomeness = 100;

            // Get player's name to using in Adventurer constructor
            Console.Write("What is your name, young adventurer? ");
            string name = Console.ReadLine();

            // Make a new "Robe" object to pass to Adventurer constructor
            Robe robe = new Robe()
            {
                Colors = new List<string>() { "red", "pink", "orange", "green" },
                Length = 80
            };

            // Make a new "Hat" object to pass to Adventurer constructor
            Hat hat = new Hat()
            {
                ShininessLevel = 8
            };

            // Make an instance of Prize description of prize
            Prize prize = new Prize("It looks like a potato on a pedestal.");

            // Make a new "Adventurer" object using the "Adventurer" class
            Adventurer theAdventurer = new Adventurer(name, robe, hat);

            // give description of adventurer
            Console.WriteLine(theAdventurer.GetDescription());

            // A list of challenges for the Adventurer to complete
            // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
            List<Challenge> challenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle,
                whatHour,
                bestNumber,
                multiplication
            };


            // play game while gameActiv is true;
            bool gameActive = true;

            // keep track of successful runs
            int successfulRuns = 0;

            while (gameActive)
            {
                // create copy of challenges so that we can remove challenges until 5 is remaining without altering the total list of challenges
                List<Challenge> chosenChallenges = new List<Challenge>(challenges);

                while (chosenChallenges.Count > 5)
                {
                    chosenChallenges.RemoveAt(randomizer.Next(0, chosenChallenges.Count));
                }

                chosenChallenges = chosenChallenges.OrderBy(item => randomizer.Next()).ToList();

                // Loop through all the challenges and subject the Adventurer to them
                foreach (Challenge challenge in chosenChallenges)
                {
                    challenge.RunChallenge(theAdventurer);
                }

                // This code examines how Awesome the Adventurer is after completing the challenges
                // And praises or humiliates them accordingly
                if (theAdventurer.Awesomeness >= maxAwesomeness)
                {
                    Console.WriteLine("YOU DID IT! You are truly awesome!");
                    successfulRuns++;
                }
                else if (theAdventurer.Awesomeness <= minAwesomeness)
                {
                    Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
                }
                else
                {
                    Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
                }

                // show the potato medal if they won!
                prize.ShowPrize(theAdventurer);

                // prompt user whether they want to repeat the quest
                Console.Write("Would you like to repeat your adventure? (Y/N) ");
                string answer = Console.ReadLine();

                // check if answer is y or n
                if (!(answer != "" && answer.ToLower().Trim() == "y"))
                {
                    gameActive = false;
                }

                theAdventurer.Awesomeness = 50 + successfulRuns * 10;
            }

        }
    }
}