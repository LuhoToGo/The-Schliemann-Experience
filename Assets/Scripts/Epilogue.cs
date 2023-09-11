using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Epilogue : MonoBehaviour
{
    public Queue<string> text;
    public GameObject scoreSlider;
    public int delay = 2;  // Verzoegerungszeit (in Sekunden) nach dem ersten Text, bevor die Punkteleiste mit dem zugehoerigen Text angezeigt werden

    void Start() {
        ScoreManager.instance.FindScoreSlider(); // Richtige Referenz zum Slider wird gesucht
        scoreSlider.SetActive(false);  // Punkteleiste wird zu Beginn ausgeblendet
        
        text = new Queue<string>();
        text.Clear();
        text.Enqueue("Dr. Adler: “Hey [Player]. You have already reached the end of your exam. I'm already excited to see if you enjoyed your experience! Let's see how you scored...” \n\n\n");

        TextManager.Instance.StartDialogue(text);

        StartCoroutine(ShowScore(delay)); // Coroutine wird gestartet, um die Punkte und den zugehoerigen Text nach einer Verzoegerung anzuzeigen
    }

    // Coroutine
    IEnumerator ShowScore(int delay) {
        yield return new WaitForSeconds(delay);
        TextManager.Instance.AppendNextSentence(true);  // Anhaengen von Text wird eingeschaltet

        scoreSlider.SetActive(true);  // Punkteleiste wird wieder angezeigt
        int score = ScoreManager.instance.GetScore(); // Punktestand wird abgerufen
        ScoreManager.instance.UpdateScoreSlider(); // Punkteleiste wird aktualisiert
        Debug.Log("Gesamtpunktzahl: " + ScoreManager.instance.GetScore());
        string scoreBasedText;

        if(score <= 40)
            scoreBasedText = score + " / 100 points \n\n\n\n\n\n “I suppose you understood the game, but in some situations you couldn't switch off your instinct. I mean, after all, you're a good student, but you're not that much of a Schliemann.”";
        else if(score <= 70)
            scoreBasedText = score + " / 100 points \n\n\n\n\n\n “Congratulations! In some situations it was difficult for you to engage with Schliemann's way but all in all I am very proud of your approach.”";
        else
            scoreBasedText = score + " / 100 points \n\n\n\n\n\n “Fascinating how well you did! I am quite proud to call someone my student who understands a task so quickly. Maybe it's not a compliment to be like Schliemann, but you understood how he thought. Now it's up to you to become a good archaeologist and get it right.”";

        TextManager.Instance.AppendDialogue(scoreBasedText);
        TextManager.Instance.AppendNextSentence(false);  // Anhaengen von Text wird ausgeschaltet
    }

    public void endGame(){
        Application.Quit();
    }
}
