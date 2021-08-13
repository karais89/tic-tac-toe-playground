using UnityEngine;
using UnityEngine.UI;

namespace MVP
{
    [System.Serializable]
    public class PlayerView
    {
        public Image panel;
        public Text text;
        public Button button;
    }

    [System.Serializable]
    public class PlayerColorView
    {
        public Color panelColor;
        public Color textColor;
    }

    public class GameView : MonoBehaviour
    {
        public GameObject gameOverPanel;
        public Text gameOverText;
        public GameObject restartButton;

        public PlayerView playerX;
        public PlayerView playerO;
        public PlayerColorView activePlayerColor;
        public PlayerColorView inactivePlayerColor;

        public GameObject startInfo;

        public void SetPlayerColors(string playerSide)
        {
            if (playerSide == "X")
            {
                SetPlayerColors(playerX, playerO);
            }
            else
            {
                SetPlayerColors(playerO, playerX);
            }
        }

        public void Init()
        {
            gameOverPanel.SetActive(false);
            restartButton.SetActive(false);
        }

        public void StartGame()
        {
            SetPlayerButtons(false);
            startInfo.SetActive(false);
        }

        public void RestartGame()
        {
            gameOverPanel.SetActive(false);
            restartButton.SetActive(false);
            SetPlayerButtons(true);
            SetPlayerColorsInactive();
            startInfo.SetActive(true);
        }

        public void GameOver(string winningPlayer)
        {
            if (winningPlayer == "draw")
            {
                SetGameOverText("It's a Draw!");
                SetPlayerColorsInactive();
            }
            else
            {
                SetGameOverText(winningPlayer + " Wins!");
            }

            restartButton.SetActive(true);
        }

        private void SetGameOverText(string value)
        {
            gameOverPanel.SetActive(true);
            gameOverText.text = value;
        }

        private void SetPlayerColors(PlayerView newPlayer, PlayerView oldPlayer)
        {
            newPlayer.panel.color = activePlayerColor.panelColor;
            newPlayer.text.color = activePlayerColor.textColor;
            oldPlayer.panel.color = inactivePlayerColor.panelColor;
            oldPlayer.text.color = inactivePlayerColor.textColor;
        }

        private void SetPlayerButtons(bool toggle)
        {
            playerX.button.interactable = toggle;
            playerO.button.interactable = toggle;
        }

        private void SetPlayerColorsInactive()
        {
            playerX.panel.color = inactivePlayerColor.panelColor;
            playerX.text.color = inactivePlayerColor.textColor;
            playerO.panel.color = inactivePlayerColor.panelColor;
            playerO.text.color = inactivePlayerColor.textColor;
        }
    }
}