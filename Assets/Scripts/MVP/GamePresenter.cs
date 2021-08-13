using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace MVP
{
    public class GamePresenter : MonoBehaviour
    {
        // 뷰 정의
        public GameView view;

        // 다른 프리젠트 참조
        public GridPresenter[] gridPresenters;

        // 모델 정의
        private GameModel gameModel = new GameModel();

        private void Awake()
        {
            gameModel.InitData();

            SetGamePresenterReferenceOnButtons();
            view.Init();
        }

        private void Start()
        {
            // 이벤트 바인딩
            view.playerX.button.OnClickAsObservable()
                .Subscribe(_ => { SetStartingSide("X"); })
                .AddTo(gameObject);

            view.playerO.button.OnClickAsObservable()
                .Subscribe(_ => { SetStartingSide("O"); })
                .AddTo(gameObject);

            view.restartButton.GetComponent<Button>().OnClickAsObservable()
                .Subscribe(_ => { RestartGame(); })
                .AddTo(gameObject);

            // 플레이어 턴이 변경될 시 호출.
            gameModel.PlayerSide
                .Where(playerSide => !string.IsNullOrEmpty(playerSide))
                .Subscribe(view.SetPlayerColors)
                .AddTo(gameObject);

            // 게임 오버 시 호출
            gameModel.GameOver
                .Where(winPlayer => !string.IsNullOrEmpty(winPlayer))
                .Subscribe(GameOver)
                .AddTo(gameObject);
        }

        private void StartGame()
        {
            SetBoardInteractable(true);
            
            view.StartGame();
        }

        private void SetGamePresenterReferenceOnButtons()
        {
            foreach (var grid in gridPresenters)
            {
                grid.SetGamePresenterReference(this);
            }
        }

        public string GetPlayerSide()
        {
            return gameModel.PlayerSide.Value;
        }

        public void EndTurn()
        {
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

        private void RestartGame()
        {
            gameModel.InitData();
            view.RestartGame();
            ResetBoardPlayerSide();
        }

        private void ResetBoardPlayerSide()
        {
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

            view.GameOver(winningPlayer);
        }

        private void SetStartingSide(string startingSide)
        {
            gameModel.PlayerSide.Value = startingSide;

            StartGame();
        }
    }
}