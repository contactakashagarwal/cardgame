namespace CardGame.Interfaces
{
    public interface ICommandLineIO
    {
        string ReadLine(string message);
        void WriteLine(string message);
        void WriteIntroMessage();
        void WriteExitMessage();
        void WriteRoundResult(IPlayer player1, IPlayer player2, IPlayer winingPlayer);
        void WriteFinalResult(string winnerName);
    }
}
