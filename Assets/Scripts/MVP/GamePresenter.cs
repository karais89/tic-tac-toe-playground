using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace MVP
{
    public class GamePresenter : MonoBehaviour
    {
        // 뷰 정의
        public GameView view;

        // 모델 정의
        private GameModel gameModel = new GameModel();
        private GridModel[] gridModels;

        private void Awake()
        {
            gameModel.InitData();
            MakeGridModel();
            
            view.Init();
        }
        
        private void MakeGridModel()
        {
            gridModels = new GridModel[view.gridView.Length];
            for (int i = 0; i < view.gridView.Length; i++)
            {
                gridModels[i] = new GridModel();
            }
        }

        private void Start()
        {
            SetEvents();
            Bind();
        }

        private void SetEvents()
        {
            view.playerX.button.OnClickAsObservable()
                .Subscribe(_ => { SetStartingSide("X"); })
                .AddTo(gameObject);

            view.playerO.button.OnClickAsObservable()
                .Subscribe(_ => { SetStartingSide("O"); })
                .AddTo(gameObject);

            view.restartButton.GetComponent<Button>().OnClickAsObservable()
                .Subscribe(_ => { RestartGame(); })
                .AddTo(gameObject);

            // 그리드 안의 버튼들 이벤트 등록
            for (int i = 0; i < view.gridView.Length; i++)
            {
                int index = i; // 클로저
                view.gridView[i].button.OnClickAsObservable()
                    .Subscribe(_ => { SetSpace(index); })
                    .AddTo(gameObject);
            }
        }

        private void Bind()
        {
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

            // 그리드안의 값 변경시 호출
            for (int i = 0; i < gridModels.Length; i++)
            {
                gridModels[i].PlayerSide
                    .SubscribeToText(view.gridView[i].buttonText)
                    .AddTo(gameObject);
            }
        }

        private void SetSpace(int index)
        {
            gridModels[index].PlayerSide.Value = gameModel.PlayerSide.Value;
            view.gridView[index].SetBoardInteractable(false);
            gameModel.EndTurn(GetPlayerSides());
        }

        private string[] GetPlayerSides()
        {
            var playerSides = new string[gridModels.Length];
            for (int i = 0; i < gridModels.Length; i++)
            {
                playerSides[i] = gridModels[i].PlayerSide.Value;
            }

            return playerSides;
        }

        private void RestartGame()
        {
            gameModel.InitData();
            InitGridModel();
            
            view.RestartGame();
        }

        private void InitGridModel()
        {
            foreach (var model in gridModels)
            {
                model.PlayerSide.Value = "";
            }
        }

        private void GameOver(string winningPlayer)
        {
            view.GameOver(winningPlayer);
        }

        private void SetStartingSide(string startingSide)
        {
            gameModel.PlayerSide.Value = startingSide;

            view.StartGame();
        }
    }
}