using UniRx;

namespace MVP
{
    // 게임 모델. 게임의 전체적인 비즈니스 로직 담당
    public class GameModel
    {
        public ReactiveProperty<string> PlayerSide { get; }
        public ReactiveProperty<string> GameOver { get; }
        
        public int MoveCount { get; set; }
        
        public GameModel()
        {
            PlayerSide = new ReactiveProperty<string>();
            GameOver = new ReactiveProperty<string>();
        }

        private void ChangeSides()
        {
            PlayerSide.Value =
                (PlayerSide.Value == "X") ? "O" : "X"; // Note: Capital Letters for "X" and "O"
        }

        public void EndTurn(string[] gridPlayerSides)
        {
            if (gridPlayerSides[0] == PlayerSide.Value && gridPlayerSides[1] == PlayerSide.Value && gridPlayerSides[2] == PlayerSide.Value)
            {
                GameOver.Value = PlayerSide.Value;
            }
            else if (gridPlayerSides[3] == PlayerSide.Value && gridPlayerSides[4] == PlayerSide.Value &&
                     gridPlayerSides[5] == PlayerSide.Value)
            {
                GameOver.Value = PlayerSide.Value;
            }
            else if (gridPlayerSides[6] == PlayerSide.Value && gridPlayerSides[7] == PlayerSide.Value &&
                     gridPlayerSides[8] == PlayerSide.Value)
            {
                GameOver.Value = PlayerSide.Value;
            }
            else if (gridPlayerSides[0] == PlayerSide.Value && gridPlayerSides[3] == PlayerSide.Value &&
                     gridPlayerSides[6] == PlayerSide.Value)
            {
                GameOver.Value = PlayerSide.Value;
            }
            else if (gridPlayerSides[1] == PlayerSide.Value && gridPlayerSides[4] == PlayerSide.Value &&
                     gridPlayerSides[7] == PlayerSide.Value)
            {
                GameOver.Value = PlayerSide.Value;
            }
            else if (gridPlayerSides[2] == PlayerSide.Value && gridPlayerSides[5] == PlayerSide.Value &&
                     gridPlayerSides[8] == PlayerSide.Value)
            {
                GameOver.Value = PlayerSide.Value;
            }
            else if (gridPlayerSides[0] == PlayerSide.Value && gridPlayerSides[4] == PlayerSide.Value &&
                     gridPlayerSides[8] == PlayerSide.Value)
            {
                GameOver.Value = PlayerSide.Value;
            }
            else if (gridPlayerSides[2] == PlayerSide.Value && gridPlayerSides[4] == PlayerSide.Value &&
                     gridPlayerSides[6] == PlayerSide.Value)
            {
                GameOver.Value = PlayerSide.Value;
            }
            else if (MoveCount >= 9)
            {
                GameOver.Value = "draw";
            }
            else
            {
                ChangeSides();
            }
        }
    }
}