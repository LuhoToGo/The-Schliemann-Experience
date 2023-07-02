using UnityEngine;
using UnityEngine.UI;

public class NameInput : MonoBehaviour
{
    public InputField nameInputField;
    public Button startButton;
    public Text greetingText;

    private void Start()
    {
        nameInputField.Select(); // InputField wird ausgewaehlt
        startButton.gameObject.SetActive(false); // Start-Button ist zu Beginn nicht sichtbar
        greetingText.gameObject.SetActive(false);  // Begruessung ist zu Beginn nicht sichtbar
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SetPlayerName();
        }
    }

    public void SetPlayerName()
    {
        if (nameInputField.text.Length > 1) // Prueft, ob ein Name eingegeben wurde
        {
            PlayerName.playerName = nameInputField.text;
            Debug.Log("Player's name set to: " + PlayerName.playerName);
            startButton.gameObject.SetActive(true);  // Start-Button wird aktiv
            nameInputField.gameObject.SetActive(false);  // Input-Feld verschwindet
            greetingText.text = "Hello, " + PlayerName.playerName + "!";  // Begruessung wird gesetzt
            greetingText.gameObject.SetActive(true);  // Begruessung wird sichtbar gemacht
        }
    }
}
