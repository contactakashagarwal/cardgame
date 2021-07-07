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
        private readonly IDeck _deck;
        private readonly IPlayerFactory _playerFactory;
        private readonly ICommandLineIO _commandLineIO;

        public CardGameController(IDeck deck, IPlayerFactory playerFactory, ICommandLineIO commandLineIO)
        {
            _deck = deck;
            _playerFactory = playerFactory;
            _commandLineIO = commandLineIO;
        }

        /// <summary>
        /// Initializes the game
        /// </summary>
        /// <param name="playerNames"></param>
        public void Start(List<string> playerNames)
        {
            List<IPlayer> players = new List<IPlayer>();

            playerNames.ForEach(playerName =>
            {
                var player = _playerFactory.Create(playerName);
                player.AssignCards(_deck.GetCardsForPlayer().ToList());
                players.Add(player);
            });

            _commandLineIO.WriteIntroMessage();
            BeginGame(players);
            _commandLineIO.WriteExitMessage();
        }

        /// <summary>
        /// Begin game, currently taking into consideration only first 2 players are playing
        /// </summary>
        /// <param name="players"></param>
        private void BeginGame(List<IPlayer> players)
        {
            //cards that are there on the board to be picked by the winner
            var boardCards = new List<Card>();
            
            //taking first two players only for now
            var player1 = players[0];
            var player2 = players[1];
            var playersInGame = new List<IPlayer> { player1, player2 };

            while (true)
            {
                player1.TryDrawCard();
                player2.TryDrawCard();

                //both players have cards
                if(player1.LastDrawnCard != null && player2.LastDrawnCard != null)
                {
                    boardCards.AddRange(new List<Card> { player1.LastDrawnCard, player2.LastDrawnCard });
                    var winningPlayer = GetWiningPlayer(playersInGame);

                    //no draw, hence cards will remain on board
                    if (winningPlayer != null)
                    {
                        winningPlayer.AddCardsToDiscardPile(boardCards);
                        boardCards.Clear();
                    }
                    _commandLineIO.WriteRoundResult(playersInGame, winningPlayer);
                }
                //player 1 has no cards
                else if(player1.LastDrawnCard == null)
                {
                    //player 2 wins the game
                    _commandLineIO.WriteFinalResult(player2.Name);
                    break;
                }
                //player 2 has no cards
                else
                {
                    //player 1 wins the game
                    _commandLineIO.WriteFinalResult(player1.Name);
                    break;
                }

                var userInput = _commandLineIO.ReadLine("Press Enter to continue to next round, or type 'exit' if you want to quit");
                if (!string.IsNullOrEmpty(userInput) && userInput.ToLower() == "exit") { break; }
            }
        }

        /// <summary>
        /// Gets the winning player - player whose card value is more (Considering 2 players)
        /// We can modify this function logic if we want to get winning player out of more than 2 players
        /// </summary>
        /// <returns>Returns null if both players have same card value</returns>
        private IPlayer GetWiningPlayer(List<IPlayer> players)
        {
            var player1 = players[0];
            var player2 = players[1];

            var winningCard = player1.LastDrawnCard.Compare(player2.LastDrawnCard);
            return winningCard == null ? null : player1.LastDrawnCard == winningCard ? player1 : player2;
        }
    }
}
