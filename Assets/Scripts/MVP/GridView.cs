using UnityEngine;
using UnityEngine.UI;

namespace MVP
{
    public class GridView : MonoBehaviour
    {
        public Button button;
        public Text buttonText;

        public void SetBoardInteractable(bool toggle)
        {
            button.interactable = toggle;
        }
    }
}