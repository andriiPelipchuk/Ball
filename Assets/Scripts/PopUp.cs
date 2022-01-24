using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    private Text _text;
    private void Start()
    {
        _text = GetComponent<Text>();
    }
    public void ShowWinPopUp()
    {
        _text.text = "WIN";
    }
    public void ShowLosePopUp()
    {
        _text.text = "LOSE";
    }
}
