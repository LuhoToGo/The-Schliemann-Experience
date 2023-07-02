using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set;}
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI dialogueAssistantText;
    public float textSpeed;
    public Animator animator;
    public Animator animatorAssistant;
    private Queue<string> sentences;
    private bool assistant;
    private string sceneName;

    void Start()
    {
        sentences = new Queue<string>();

		Scene currentScene = SceneManager.GetActiveScene();
		sceneName = currentScene.name;
    }


    public void StartDialogue (Queue<string> dialogue){
        animator.SetBool("IsOpen", true);
        sentences = dialogue;
        assistant = false;
        DisplayNextSentence();
    }

    public void StartDialogueAssistant (Queue<string> dialogue){
        animatorAssistant.SetBool("IsOpen", true);
        sentences = dialogue;
        assistant = true;
        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        if (sentences.Count == 0){
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        
        if (assistant == true){
            StartCoroutine(TypeSentenceAssistant(sentence));
        } else {
            StartCoroutine(TypeSentence(sentence));
        }
    }


    IEnumerator TypeSentence (string sentence) {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()){
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    IEnumerator TypeSentenceAssistant (string sentence) {
        dialogueAssistantText.text = "";
        foreach (char letter in sentence.ToCharArray()){
            dialogueAssistantText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void EndDialogue(){
        animator.SetBool("IsOpen", false);
        animatorAssistant.SetBool("IsOpen", false);
        Debug.Log("End of Conversation");

        if(sceneName == "Troy"){
            FindObjectOfType<DialogueTroy>().postDialogue();
        } else if (sceneName == "Mycenae"){
            FindObjectOfType<DialogueMycenae>().postDialogue();
        }
    }

}
