using UnityEngine;
using TMPro;

public class UITest : MonoBehaviour
{
    public TextMeshProUGUI infoText;

    public void PrintMessage()
    {
        infoText.text="Tombol telah di klik!";
        Debug.Log("Tombol di klik");
    }
}
