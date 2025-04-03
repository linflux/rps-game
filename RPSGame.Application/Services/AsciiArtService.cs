using System;
using System.Collections.Generic;

namespace RPSGame.Application.Services
{
    public static class AsciiArtService
    {
        private static readonly Dictionary<string, string> AsciiArtMap = new Dictionary<string, string>
        {
            { "rock", @"   _______
---'   ____ )
      (_____)
      (_____)
      (____)
---.__(___)" },

            { "paper", @"   _______
---'   ____)____
          ______)
          _______)
         _______)
---.__________)" },

            { "scissors", @"   _______
---'   ____)____
          ______)
       __________)
      (____)
---.__(___)" },

            { "lizard", @"     ____
  .-'    '-.
 /          \
|,  .-.  .-. ,|
| )(_o/  \o_)( |
 |/     /\     \|
 (_     ^^     _)
   \__|IIIIII|__/
    | \IIIIII/ |
    \          /
     `--------`" },

            { "spock", @"   _______
---'    ____)____
           ______)
         __________)
        (____)
---.__(___)
(Live long and prosper 🖖)" },

            { "gun", @"       _____,____
     / _____|____|
    | (____   ____)
     \____ |_|  
      |    |||" },

            { "lightning", @"      __/|
     // )
    // /
   // /
  //_/__
 (______)" },

            { "devil", @"    (\  .      /)
     \\  \|  // 
      ||  || 
     / |  || 
     \_|  || 
        (o_o)" },

            { "water", @"       ~  ~
     ~     ~~
    ~~~~~~  ~
   ~        ~
~~~~~~~~~~~" },

            { "air", @"          ~~
     ~~    ~
  ~~~~~~~~ ~
     ~     ~~" },

            { "sponge", @"  ___
 / @|@
 |###|
 |$  |" },

            { "fire", @"     (
      )
     (
  /\_/\
 ( o.o )
  > ^ <" },

            { "dragon", @"           _______________         
          |@@@@|     |####|       
          |@@@@|     |####|       
          |@@@@|     |####|       
 \@@@@@@@@@/    \############\    
  \@@@/           |##|>     \     
     (             \#/           
     )" }
    };

        public static void DisplayMoveArt(string move)
        {
            if (AsciiArtMap.TryGetValue(move.ToLower(), out var art))
            {
                Console.WriteLine(art);
            }
            else
            {
                Console.WriteLine("Move not recognized.");
            }
        }
    }
}