using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace MVP
{
    public class GridPresenter : MonoBehaviour
    {
        public Button button;
        public Text buttonText;

        private GamePresenter gamePresenter;
        private GridModel gridModel = new GridModel();

        public void SetGamePresenterReference(GamePresenter presenter)
        {
            gamePresenter = presenter;
        }

        private void Start()
        {
            button.OnClickAsObservable()
                .Subscribe(_ => { SetSpace(); })
                .AddTo(gameObject);
            
            gridModel.PlayerSide
                .SubscribeToText(buttonText)
                .AddTo(gameObject);
        }

        private void SetSpace()
        {
            gridModel.PlayerSide.Value = gamePresenter.GetPlayerSide();
            button.interactable = false;
            gamePresenter.EndTurn();
        }

        public string GetPlayerSide()
        {
            return gridModel.PlayerSide.Value;
        }

        public void ResetPlayerSide()
        {
            gridModel.PlayerSide.Value = "";
        }

        public void SetBoardInteractable(bool toggle)
        {
            button.interactable = toggle;
        }
    }
}