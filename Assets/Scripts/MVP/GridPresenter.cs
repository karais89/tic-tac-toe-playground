using UnityEngine;
using UnityEngine.UI;

public class GridPresenter : MonoBehaviour
{
    public Button button;
    public Text buttonText;

    private GamePresenter gamePresenter;

    public void SetGameControllerReference(GamePresenter presenter)
    {
        gamePresenter = presenter;
    }

    public void SetSpace()
    {
        buttonText.text = gamePresenter.GetPlayerSide();
        button.interactable = false;
        gamePresenter.EndTurn();
    }
}