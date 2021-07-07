using System;
using System.Collections.Generic;
using System.Text;
using CardGame.Interfaces;

namespace CardGame
{
    public class CommandLineIO : ICommandLineIO
    {
        public string ReadLine(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public void WriteRoundResult(List<IPlayer> players, IPlayer winingPlayer)
        {
            StringBuilder resultMessage = new StringBuilder();

            foreach(var player in players)
            {
                resultMessage.AppendLine(PlayerDetailMessage(player));
            }

            if (winingPlayer == null) //draw
            {
                resultMessage.AppendLine(DrawMessage);
            }
            else
            {
                resultMessage.AppendLine(RoundWinnerMessage(winingPlayer));
            }

            WriteLine(resultMessage.ToString());
        }

        public void WriteFinalResult(string winnerName)
        {
            WriteLine($"\n{winnerName} wins the game!");
        }

        public void WriteIntroMessage()
        {
            WriteLine("The Game Begins !!!\n");
        }

        public void WriteExitMessage()
        {
            WriteLine("Thanks for playing !!!");
        }

        private string PlayerDetailMessage(IPlayer player) => $"{player.Name} (Draw pile : {player.DrawPileCount} cards, Discard Pile : {player.DiscardPileCount} cards) : {player.LastDrawnCard.Number}";
        private string RoundWinnerMessage(IPlayer winingPlayer) => $"{winingPlayer.Name} wins this round";
        private string DrawMessage => "No winner in this round";
    }
}
