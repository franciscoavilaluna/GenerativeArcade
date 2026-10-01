namespace GenerativeArcade.core
{
    public interface IMiniGame
    {
        void InitializeGame();

        void UpdateGame();

        bool CheckWinCondition();

        void EndGame();
    }
}
