using System.Collections.Generic;

namespace CardGame.Interfaces
{
    public interface ICommandLineIO
    {
        string ReadLine(string message);
        void WriteLine(string message);
        void WriteIntroMessage();
        void WriteExitMessage();
        void WriteRoundResult(List<IPlayer> players, IPlayer winingPlayer);
        void WriteFinalResult(string winnerName);
    }
}
