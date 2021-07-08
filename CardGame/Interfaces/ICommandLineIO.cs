using System.Collections.Generic;

namespace CardGame.Interfaces
{
    /// <summary>
    /// Responsible for all console input output operations
    /// </summary>
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
