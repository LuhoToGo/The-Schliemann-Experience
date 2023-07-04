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
    public GameObject skipButton;


    void Start(){
        sentences = new Queue<string>();
    }


    public void StartDialogue (Queue<string> dialogue){
        sentences = dialogue;
        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }


    IEnumerator TypeSentence (string sentence) {
        dialogueText.text = "";
        sentence = sentence.Replace("[Player]", PlayerName.playerName);
        foreach (char letter in sentence.ToCharArray()){
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
        EndDialogue();
    }

    void EndDialogue(){
        Debug.Log("End of Conversation");
        skipButton.SetActive(true);
    }

}
