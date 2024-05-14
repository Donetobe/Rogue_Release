using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class Game
    {
        List<string> cards = new List<string>
             {
                "club 2", "club 3", "club 4", "club 5", "club 6", "club 7", "club 8", "club 9", "club 10", "club Jack", "club Queen", "club King", "club ACE",
                "diamonds 2", "diamonds 3", "diamonds 4", "diamonds 5", "diamonds 6", "diamonds 7", "diamonds 8", "diamonds 9", "diamonds 10", "diamonds Jack", "diamonds Queen", "diamonds King", "diamonds ACE",
                "hearts 2", "hearts 3", "hearts 4", "hearts 5", "hearts 6", "hearts 7", "hearts 8", "hearts 9", "hearts 10", "hearts Jack", "hearts Queen", "hearts King", "hearts ACE",
                "spades 2", "spades 3", "spades 4", "spades 5", "spades 6", "spades 7", "spades 8", "spades 9", "spades 10", "spades Jack", "spades Queen", "spades King", "spades ACE",
                "club 2", "club 3", "club 4", "club 5", "club 6", "club 7", "club 8", "club 9", "club 10", "club Jack", "club Queen", "club King", "club ACE",
                "diamonds 2", "diamonds 3", "diamonds 4", "diamonds 5", "diamonds 6", "diamonds 7", "diamonds 8", "diamonds 9", "diamonds 10", "diamonds Jack", "diamonds Queen", "diamonds King", "diamonds ACE",
                "hearts 2", "hearts 3", "hearts 4", "hearts 5", "hearts 6", "hearts 7", "hearts 8", "hearts 9", "hearts 10", "hearts Jack", "hearts Queen", "hearts King", "hearts ACE",
                "spades 2", "spades 3", "spades 4", "spades 5", "spades 6", "spades 7", "spades 8", "spades 9", "spades 10", "spades Jack", "spades Queen", "spades King", "spades ACE",
                "club 2", "club 3", "club 4", "club 5", "club 6", "club 7", "club 8", "club 9", "club 10", "club Jack", "club Queen", "club King", "club ACE",
                "diamonds 2", "diamonds 3", "diamonds 4", "diamonds 5", "diamonds 6", "diamonds 7", "diamonds 8", "diamonds 9", "diamonds 10", "diamonds Jack", "diamonds Queen", "diamonds King", "diamonds ACE",
                "hearts 2", "hearts 3", "hearts 4", "hearts 5", "hearts 6", "hearts 7", "hearts 8", "hearts 9", "hearts 10", "hearts Jack", "hearts Queen", "hearts King", "hearts ACE",
                "spades 2", "spades 3", "spades 4", "spades 5", "spades 6", "spades 7", "spades 8", "spades 9", "spades 10", "spades Jack", "spades Queen", "spades King", "spades ACE"
             };

        string chosenCard;

        List<string> playerCards = new List<string>();
        List<string> dealerCards = new List<string>();

        int playerNumber;
        int dealerNumber;

        bool playerHasAce;
        bool dealerHasAce;

        

        int cardsToGive;
        int cardCount;

        int cardCountDealer = 0;
        int cardsToGiveDealer = 2;

        bool gameIsRunning = true;
        int money = 100;
        int bet;
        bool betIsIn = false;
        public void Run()
        {
            

            Console.WriteLine("Welcome to Blackjack!");

            while (gameIsRunning)
            {
        

                Console.WriteLine($"You have {money}e");




                while (!betIsIn)
                {
                    Console.WriteLine("What is your bet?");
                    string vastaus = Console.ReadLine();

                    if (checkIfNumber(vastaus))
                    {
                        bet = Convert.ToInt32(vastaus);
                        money -= bet;
                        betIsIn = true;
                        break;
                    }

                }

                playerNumber = 0;
                dealerNumber = 0;

                playerHasAce = false;
                dealerHasAce = false;

                playerCards = new List<string>();
                dealerCards = new List<string>();

                cardsToGive = 2;
                cardCount = 0;

                GivePlayerCards();
                GiveDealerCards();

                CalculatePlayerNumber();
                CalculateDealerNumber();

                if (betIsIn)
                {
                    AskForMove();
                }
                

                betIsIn = false;
            }

        }

        void GetCard()
        {
            Random random = new Random();

            int cardIndex = random.Next(0, cards.Count);

            chosenCard = cards[cardIndex];

            cards.RemoveAt(cardIndex);

        }

        void GiveDealerCards()
        {
            
            Console.WriteLine("The dealers cards are:");
      
            while (cardCountDealer < cardsToGiveDealer)
            {
                GetCard();
                dealerCards.Add(chosenCard);
                cardCountDealer++;

            }
            if (dealerCards.Count <= 2)
            {
                Console.WriteLine("Unknown");
                for (int i = 1; i < dealerCards.Count; i++)
                {
                    Console.WriteLine(dealerCards[i]);
                }
                
            }
            else
            {
                for (int i = 0; i < dealerCards.Count; i++)
                {
                   
                    Console.WriteLine(dealerCards[i]);
                }
            }
        
        }

        void GivePlayerCards()
        {
            Console.WriteLine("Your cards are:");
            
            
            while (cardCount < cardsToGive)
            {
                GetCard();
                playerCards.Add(chosenCard);
                cardCount++;
                
            }
            for (int i = 0; i < playerCards.Count; i++)
            {
                Console.WriteLine(playerCards[i]);
            }


        }

        void CalculatePlayerNumber()
        {
            //IF BLACKJACK
            bool blackJackIsPossible = false;

           
                if (playerCards.Count < 3)
                {
                    foreach (var card in playerCards)
                    {
                        char lastSymbol = card[card.Length - 1];
                        if (lastSymbol == 'E')
                        {
                            playerHasAce = true;
                        }
                        else if (lastSymbol == 'g')
                        {
                            blackJackIsPossible = true;
                        }
                        else if (lastSymbol == 'n')
                        {
                            blackJackIsPossible = true;
                        }
                        else if (lastSymbol == 'k')
                        {
                            blackJackIsPossible = true;
                        }
                        else if (lastSymbol == '0')
                        {
                            blackJackIsPossible = true;
                        }
                        else
                        {
                            blackJackIsPossible = false;
                        }

                      
                       
                    }

                    if (blackJackIsPossible && playerHasAce)
                    {
                        Console.WriteLine("BLACKJACK");
                        money += bet * 4;
                        betIsIn = false;
                        return;
                    }

                }

            

            foreach (var card in playerCards)
            {

                int number;
                char lastSymbol = card[card.Length - 1];
                
                if (lastSymbol == 'E')
                {
                    number = 11;
                    playerHasAce = true;
                    playerNumber += number;
                }
                else if (lastSymbol == 'g')
                {
                    number = 10;
                    playerNumber += number;
                }
                else if (lastSymbol == 'n')
                {
                    number = 10;
                    playerNumber += number;
                }
                else if (lastSymbol == 'k')
                {
                    number = 10;
                    playerNumber += number;
                }
                else if (lastSymbol == '0')
                {
                    number = 10;
                    playerNumber += number;
                }
                else
                {
                    number = lastSymbol - '0';
                    playerNumber += number;
                }
            
            }

           
        }

        void CalculateDealerNumber()
        {
            //IF BLACKJACK
            bool blackJackIsPossible = false;

                if (dealerCards.Count < 3)
                {
                    foreach (var card in dealerCards)
                    {
                        char lastSymbol = card[card.Length - 1];
                        if (lastSymbol == 'E')
                        {
                            dealerHasAce = true;
                        }
                        else if (lastSymbol == 'g')
                        {
                            blackJackIsPossible = true;
                        }
                        else if (lastSymbol == 'n')
                        {
                            blackJackIsPossible = true;
                        }
                        else if (lastSymbol == 'k')
                        {
                            blackJackIsPossible = true;
                        }
                        else if (lastSymbol == '0')
                        {
                            blackJackIsPossible = true;
                        }
                        else
                        {
                            blackJackIsPossible = false;
                        }



                    }

                    if (blackJackIsPossible && dealerHasAce)
                    {
                        if (!betIsIn)
                        {
                            Console.WriteLine("DEALER ALSO HAS BLACKJACK SO ITS A DRAW");
                            money -= bet * 3;
                            betIsIn = false;
                            return;
                        }
                        Console.WriteLine("DEALER HAS BLACKJACK");
                        betIsIn = false;
                        return;

                    }

                }


           

            foreach (var card in dealerCards)
            {

                int number;
                char lastSymbol = card[card.Length - 1];
                if (lastSymbol == 'E')
                {
                
                        number = 11;
                    

                    dealerHasAce = true;
                    dealerNumber += number;
                }
                else if (lastSymbol == 'g')
                {
                    number = 10;
                    dealerNumber += number;
                }
                else if (lastSymbol == 'n')
                {
                    number = 10;
                    dealerNumber += number;
                }
                else if (lastSymbol == 'k')
                {
                    number = 10;
                    dealerNumber += number;
                }
                else if (lastSymbol == '0')
                {
                    number = 10;
                    dealerNumber += number;
                }
                else
                {
                    number = lastSymbol - '0';
                    dealerNumber += number;
                }

            }

        }

        bool checkIfNumber(string vastaus)
        {
            foreach (char c in vastaus)
            {
                if (!Char.IsDigit(c))
                {
                    return false;

                }

            }
            return true;
        }

        void AskForMove()
        {
            bool isBust = false;
            while (true)
            {
                
                

                if (playerNumber > 21 && playerHasAce)
                {
                    foreach (var card in playerCards)
                    {

                        int number;
                        char lastSymbol = card[card.Length - 1];

                        if (lastSymbol == 'E' && playerNumber > 21)
                        {
                          playerNumber -= 10;
                        }
                    }
                }

                Console.WriteLine($"Your number is: {playerNumber} do you hit or stand?");

                string vastaus = Console.ReadLine();

                if (vastaus == "hit")
                {
                    playerNumber -= playerNumber;
                    cardsToGive+=1;
                    GivePlayerCards();
                    CalculatePlayerNumber();
                    if (playerNumber > 21)
                    {
                        if (playerHasAce)
                        {
                            playerNumber -= 10;
                            continue;
                        }
                        Console.WriteLine($"Your number is: {playerNumber}");
                        Console.WriteLine("You have gone bust");

                        isBust = true;
                        betIsIn = false;
                        break;
                    }
                    continue;
                }
                else if (vastaus == "stand")
                {
                    
                    break;
                }
                Console.WriteLine("Incorrect answer try again");

            
            }

       

            while (dealerNumber <= playerNumber && dealerNumber < 18)
            {
               

                dealerNumber -= dealerNumber;
                cardsToGiveDealer += 1;
                GiveDealerCards();
                
                CalculateDealerNumber();
                
                
                if (dealerNumber > 21)
                {

                    while (dealerNumber > 21 && dealerHasAce)
                    {
                        foreach (var card in playerCards)
                        {

                            int number;
                            char lastSymbol = card[card.Length - 1];

                            if (lastSymbol == 'E' && dealerNumber > 21)
                            {
                                dealerNumber -= 10;
                            }
                        }
                    }

                }

           
            }

            if (dealerNumber > 21 && betIsIn)
            {
                Console.WriteLine($"Dealers number is {dealerNumber}");

                Console.WriteLine("Dealer has gone bust");

                money += bet * 2;
            }

            else if (dealerNumber > playerNumber && dealerNumber < 22 && betIsIn)
            {
                Console.WriteLine($"Dealer wins with {dealerNumber}");
                Console.WriteLine($"The dealers winning cards are:");
                for (int i = 0; i < dealerCards.Count; i++)
                {

                    Console.WriteLine(dealerCards[i]);
                }
            }
            else if (playerNumber > dealerNumber && betIsIn)
            {
                Console.WriteLine("You win");
                money += bet * 2;
            }
            else if   (betIsIn && betIsIn)
            {
                Console.WriteLine("Draw");
                money += bet;
            }
        }

       
    }
}
