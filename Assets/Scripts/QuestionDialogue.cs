using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


// Template fuer andere Scripts:
// QuestionDialogue.Instance.ShowQuestion("Hier kommt die Frage hin?", () => {ActionA}, () => {ActionB}, () => {ActionC});
// Die Actions sind jeweils durch die Gewuenschten Funktionen zu ersetzen


public class QuestionDialogue : MonoBehaviour {
    
    public static QuestionDialogue Instance { get; private set;}

    private TextMeshProUGUI textMeshPro;
    private Button buttonA;
    private Button buttonB; 
    private Button buttonC;

    private void Awake() {
        Instance = this;
        textMeshPro = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        buttonA = transform.Find("Button A").GetComponent<Button>();
        buttonB = transform.Find("Button B").GetComponent<Button>();
        buttonC = transform.Find("Button C").GetComponent<Button>();

        Hide();
    }

    public void ShowQuestion(string questionText, Action actionA, Action actionB, Action actionC) {
        gameObject.SetActive(true);

        textMeshPro.text = questionText;

        buttonA.onClick.RemoveAllListeners();
        buttonA.onClick.AddListener(() => {

            FindObjectOfType<SoundEffects>().playClick();


            Hide();
            actionA();
        });

        buttonB.onClick.RemoveAllListeners();
        buttonB.onClick.AddListener(() => {

            FindObjectOfType<SoundEffects>().playClick();


            Hide();
            actionB();
        });

        buttonC.onClick.RemoveAllListeners();
        buttonC.onClick.AddListener(() => {

            FindObjectOfType<SoundEffects>().playClick();

            Hide();
            actionC();
        });
    }

    private void Hide(){
        gameObject.SetActive(false);

    }

}
