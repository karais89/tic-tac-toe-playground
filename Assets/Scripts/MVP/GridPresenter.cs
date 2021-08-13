using MVP;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class GridPresenter : MonoBehaviour
{
    public Button button;
    public Text buttonText;

    private GamePresenter gamePresenter;
    private GridModel gridModel = new GridModel();

    public void SetGameControllerReference(GamePresenter presenter)
    {
        gamePresenter = presenter;
    }

    private void Start()
    {
        button.OnClickAsObservable().Subscribe(_ =>
        {
            SetSpace();
        }).AddTo(gameObject);
    }

    private void SetSpace()
    {
        gridModel.PlayerSide = gamePresenter.GetPlayerSide();
        
        buttonText.text = gridModel.PlayerSide;
        button.interactable = false;
        gamePresenter.EndTurn();
    }

    public string GetPlayerSide()
    {
        return gridModel.PlayerSide;
    }

    public void ResetPlayerSide()
    {
        gridModel.PlayerSide = "";
    }

    public void SetBoardInteractable(bool toggle)
    {
        button.interactable = toggle;
    }
}