using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardGame.Factories;
using CardGame.Interfaces;
using CardGame.Models;

namespace CardGame
{
    public class CardGameController : ICardGameController
    {
        private IPlayer player1;
        private IPlayer player2;
        private readonly IDeck _deck;
        private readonly IPlayerFactory _playerFactory;
        private readonly ICommandLineIO _commandLineIO;
        private readonly int _numberOfPlayers; // not used currently

        public CardGameController(IDeckFactory deckFactory, IPlayerFactory playerFactory, ICommandLineIO commandLineIO, int deckSize, int numOfPlayers)
        {
            _deck = deckFactory.Create(deckSize);
            _playerFactory = playerFactory;
            _numberOfPlayers = numOfPlayers;
            _commandLineIO = commandLineIO;
        }
        
        /// <summary>
        /// Take input for player names and then the game begins
        /// </summary>
        public void Start(string player1Name, string player2Name)
        {
            player1 =  _playerFactory.Create(player1Name);
            player1.AssignCards(_deck.GetHalfDeck().ToList());

            player2 = _playerFactory.Create(player2Name);
            player2.AssignCards(_deck.GetHalfDeck().ToList());

            _commandLineIO.WriteIntroMessage();

            if(player1 != null && player2 != null)
            {
                BeginGame();
            }

            _commandLineIO.WriteExitMessage();
        }

        /// <summary>
        /// Current Logic in considering that only two players are playing this game.
        /// </summary>
        private void BeginGame()
        {
            //cards that are there on the board to be picked by the winner
            var boardCards = new List<Card>();

            while (true)
            {
                if (player1.TryDrawCard(out var p1Card))
                {
                    if (player2.TryDrawCard(out var p2Card))
                    {
                        boardCards.AddRange(new List<Card> { p1Card, p2Card });
                        var winningPlayer = GetWinningPlayer();
                        //round is not draw
                        if (winningPlayer != null)
                        {
                            winningPlayer.AddCardsToDiscardPile(boardCards);
                            boardCards.Clear();
                        }
                        _commandLineIO.WriteRoundResult(player1, player2, winningPlayer);
                    }
                    else
                    {
                        //player 1 won the game
                        _commandLineIO.WriteFinalResult(player1.Name);
                        break;
                    }
                }
                else
                {
                    //player 2 won the game
                    _commandLineIO.WriteFinalResult(player2.Name);
                    break;
                }

                var userInput = _commandLineIO.ReadLine("Press Enter to continue to next round, or type 'exit' if you want to quit");

                if (!string.IsNullOrEmpty(userInput) && userInput.ToLower() == "exit") { break; }
            }
        }

        /// <summary>
        /// Gets the winning player - player whose card value is more (Considering 2 players)
        /// </summary>
        /// <returns>Returns null if both players have same card value</returns>
        private IPlayer GetWinningPlayer()
        {
            var winningCard = player1.LastDrawnCard.Compare(player2.LastDrawnCard);
            return winningCard == null ? null : player1.LastDrawnCard == winningCard ? player1 : player2;
        }
    }
}
