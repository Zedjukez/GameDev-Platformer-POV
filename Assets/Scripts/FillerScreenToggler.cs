using UnityEngine;
using UnityEngine.UI;

public class FillerScreenToggler : MonoBehaviour
{
    public Image fillerScreen;
    public Button quitButton;

    private void Start()
    {
        fillerScreen.gameObject.SetActive(false);
 
    }

    public void LoadInstructions()
    {
        // Enable the filler screen image to cover the screen
        fillerScreen.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(false);
    }

    public void Back()
    {
        fillerScreen.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(true);
    }
}
