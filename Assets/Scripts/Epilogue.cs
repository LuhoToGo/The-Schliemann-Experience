using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Epilogue : MonoBehaviour
{
    public Queue<string> text;
 
    // Start is called before the first frame update
    void Start(){
        text = new Queue<string>();
        text.Clear();
		text.Enqueue("Dr. Adler: “Hey [Player]. You have already reached the end of your exam. I'm already excited to see if you enjoyed your experience! Let's see how you scored.” \n\nScore Balken einfuegen\n\n\n0-40%:  “I suppose you understood the game, but in some situations you couldn't switch off your instinct. I mean, after all, you're a good student, but you're not that much of a Schliemann.”\n\n41-70%: “Congratulations! In some situations it was difficult for you to engage with Schliemann's way but all in all I am very proud of your approach.”\n\n71-100%: “Fascinating how well you did! I am quite proud to call someone my student who understands a task so quickly. Maybe it's not a compliment to be like Schliemann, but you understood how he thought. Now it's up to you to become a good archaeologist and get it right.”");
		FindObjectOfType<TextManager>().StartDialogue(text);
    }

    public void endGame(){
        Application.Quit();
    }
}
