using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set;}
    public TextMeshProUGUI dialogueText;
    public float textSpeed;
    public Animator animator;
    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }


    public void StartDialogue (Queue<string> dialogue){
        animator.SetBool("IsOpen", true);

        sentences = dialogue;

        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        if (sentences.Count == 0){
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence) {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()){
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void EndDialogue(){
        animator.SetBool("IsOpen", false);
        Debug.Log("End of Conversation");
        FindObjectOfType<clickcontrol>().showQuestion();
    }

}
