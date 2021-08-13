using UniRx;
using UnityEngine;

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

        public void InitData()
        {
            MoveCount = 0;
            PlayerSide.Value = string.Empty;
            GameOver.Value = string.Empty;
        }

        private void ChangeSides()
        {
            PlayerSide.Value =
                (PlayerSide.Value == "X") ? "O" : "X"; // Note: Capital Letters for "X" and "O"
        }

        public void EndTurn(string[] playerSides)
        {
            MoveCount++;
            
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