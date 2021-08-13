using UniRx;

namespace MVP
{
    // 게임 모델. 게임의 전체적인 비즈니스 로직 담당
    public class GameModel
    {
        // ReactiveProperty는 값이 변경될 시 발행 된다.
        
        public ReactiveProperty<string> PlayerSide { get; } // 현재 턴 정보 (O or X)
        public ReactiveProperty<string> GameOver { get; } // 게임 오버 정보 (턴 정보 or draw)

        private int moveCount;
        
        public GameModel()
        {
            PlayerSide = new ReactiveProperty<string>();
            GameOver = new ReactiveProperty<string>();
        }

        public void InitData()
        {
            moveCount = 0;
            PlayerSide.Value = string.Empty;
            GameOver.Value = string.Empty;
        }

        private void ChangeSides()
        {
            PlayerSide.Value =
                (PlayerSide.Value == "X") ? "O" : "X"; // Note: Capital Letters for "X" and "O"
        }

        // 그리드 정보 비교. 비효율적인 방법이지만, 기존 유니티 예제와 동일한 방법으로 구현
        public void EndTurn(string[] playerSides)
        {
            moveCount++;
            
            if (playerSides[0] == PlayerSide.Value && playerSides[1] == PlayerSide.Value && playerSides[2] == PlayerSide.Value)
            {
                GameOver.Value = PlayerSide.Value;
            }
            else if (playerSides[3] == PlayerSide.Value && playerSides[4] == PlayerSide.Value &&
                     playerSides[5] == PlayerSide.Value)
            {
                GameOver.Value = PlayerSide.Value;
            }
            else if (playerSides[6] == PlayerSide.Value && playerSides[7] == PlayerSide.Value &&
                     playerSides[8] == PlayerSide.Value)
            {
                GameOver.Value = PlayerSide.Value;
            }
            else if (playerSides[0] == PlayerSide.Value && playerSides[3] == PlayerSide.Value &&
                     playerSides[6] == PlayerSide.Value)
            {
                GameOver.Value = PlayerSide.Value;
            }
            else if (playerSides[1] == PlayerSide.Value && playerSides[4] == PlayerSide.Value &&
                     playerSides[7] == PlayerSide.Value)
            {
                GameOver.Value = PlayerSide.Value;
            }
            else if (playerSides[2] == PlayerSide.Value && playerSides[5] == PlayerSide.Value &&
                     playerSides[8] == PlayerSide.Value)
            {
                GameOver.Value = PlayerSide.Value;
            }
            else if (playerSides[0] == PlayerSide.Value && playerSides[4] == PlayerSide.Value &&
                     playerSides[8] == PlayerSide.Value)
            {
                GameOver.Value = PlayerSide.Value;
            }
            else if (playerSides[2] == PlayerSide.Value && playerSides[4] == PlayerSide.Value &&
                     playerSides[6] == PlayerSide.Value)
            {
                GameOver.Value = PlayerSide.Value;
            }
            else if (moveCount >= 9)
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