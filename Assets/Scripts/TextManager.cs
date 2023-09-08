using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TextManager : MonoBehaviour
{
    public static TextManager Instance { get; private set;}
    public TextMeshProUGUI dialogueText;
    public float textSpeed;
    private Queue<string> sentences;
    private bool appendNextSentence = false;
    public GameObject skipButton;

    void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    void Start() {
        sentences = new Queue<string>();
    }

    public void StartDialogue (Queue<string> dialogue) {
        sentences = dialogue;
        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence) {
        dialogueText.text = !appendNextSentence ? "" : dialogueText.text; // Dynamische Entfernung von Text
        sentence = sentence.Replace("[Player]", PlayerName.playerName);
        foreach (char letter in sentence.ToCharArray()){
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
        EndDialogue();
    }

    void EndDialogue() {
        Debug.Log("End of Conversation");
        skipButton.SetActive(true);
    }

    // Bestimmt, ob der naechste Satz angehaengt werden soll oder nicht
    public void AppendNextSentence(bool shouldAppend) {
        appendNextSentence = shouldAppend;
    }

    // Neuer Text wird an das bestehende Dialogsystem anhaengt
    public void AppendDialogue(string newText) {
        StartCoroutine(TypeSentence(newText));
    }
}
