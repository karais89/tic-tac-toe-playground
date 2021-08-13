using MVP;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

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

public class GamePresenter : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Text gameOverText;
    public GameObject restartButton;

    public PlayerView playerX;
    public PlayerView playerO;
    public PlayerColorView activePlayerColor;
    public PlayerColorView inactivePlayerColor;

    public GameObject startInfo;

    // 프리젠트 참조
    public GridPresenter[] gridPresenters;

    // 모델 정의
    private GameModel gameModel = new GameModel();

    private void Awake()
    {
        gameModel.MoveCount = 0;

        SetGameControllerReferenceOnButtons();
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
    }

    private void Start()
    {
        // 이벤트 바인딩
        playerX.button.OnClickAsObservable().Subscribe(_ =>
        {
            SetStartingSide("X");
        }).AddTo(gameObject);

        playerO.button.OnClickAsObservable().Subscribe(_ =>
        {
            SetStartingSide("O");
        }).AddTo(gameObject);

        restartButton.GetComponent<Button>().OnClickAsObservable().Subscribe(_ =>
        {
            RestartGame();
        }).AddTo(gameObject);
        
        // 플레이어 턴이 변경될 시 호출.
        gameModel.PlayerSide.Where(playerSide => !string.IsNullOrEmpty(playerSide))
            .Subscribe(playerSide =>
            {
                if (playerSide == "X")
                {
                    SetPlayerColors(playerX, playerO);
                }
                else
                {
                    SetPlayerColors(playerO, playerX);
                }
            }).AddTo(gameObject);

        // 게임 오버 시 호출
        gameModel.GameOver.Where(winPlayer => !string.IsNullOrEmpty(winPlayer))
            .Subscribe(GameOver)
            .AddTo(gameObject);
    }

    private void StartGame()
    {
        SetBoardInteractable(true);
        SetPlayerButtons(false);
        startInfo.SetActive(false);
    }

    private void SetGameControllerReferenceOnButtons()
    {
        foreach (var grid in gridPresenters)
        {
            grid.SetGameControllerReference(this);
        }
    }

    public string GetPlayerSide()
    {
        return gameModel.PlayerSide.Value;
    }

    public void EndTurn()
    {
        gameModel.MoveCount++;

        gameModel.EndTurn(GetPlayerSides());
    }

    private string[] GetPlayerSides()
    {
        var playerSides = new string[gridPresenters.Length];
        for (int i = 0; i < gridPresenters.Length; i++)
        {
            playerSides[i] = gridPresenters[i].GetPlayerSide();
        }

        return playerSides;
    }
    
    private void SetGameOverText(string value)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = value;
    }

    public void RestartGame()
    {
        gameModel.MoveCount = 0;
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        SetPlayerButtons(true);
        SetPlayerColorsInactive();
        startInfo.SetActive(true);

        foreach (var grid in gridPresenters)
        {
            grid.ResetPlayerSide();
        }
    }

    private void SetBoardInteractable(bool toggle)
    {
        foreach (var grid in gridPresenters)
        {
            grid.SetBoardInteractable(toggle);
        }
    }

    private void GameOver(string winningPlayer)
    {
        SetBoardInteractable(false);

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

    private void SetPlayerColors(PlayerView newPlayer, PlayerView oldPlayer)
    {
        newPlayer.panel.color = activePlayerColor.panelColor;
        newPlayer.text.color = activePlayerColor.textColor;
        oldPlayer.panel.color = inactivePlayerColor.panelColor;
        oldPlayer.text.color = inactivePlayerColor.textColor;
    }

    public void SetStartingSide(string startingSide)
    {
        gameModel.PlayerSide.Value = startingSide;
        StartGame();
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