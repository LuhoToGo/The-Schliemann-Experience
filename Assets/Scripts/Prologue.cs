using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prologue : MonoBehaviour
{
    public Queue<string> text;
 
    // Start is called before the first frame update
    void Start(){
        text = new Queue<string>();
        text.Clear();
		text.Enqueue("[Player]: “Hey can anyone hear me? One moment I was sitting in my archaeology class at University,  about  to start writing my module exam and now all of a sudden I can only hear my own voice and it's pitch black?!” \n\nDr. Adler: “Oh perfect that worked! Don’t panic, it's me your Archaeology Professor, Dr. Adler. I will explain everything to you, [Player]. Sorry for surprising you. I didn’t mean to scare you, I just didn’t know if it would work out… But it did! So, you just travelled back in time to to the late 19th century. I know, crazy?! Remember Heinrich Schliemann, the man we just talked about in class? Great, so for your module exam you are now his assistant. Your task is to help him out at his excavations at Troy and Mycenae. He’ll tell you what to do, don’t worry. Oh and also, you’re not alone! I’m right here in your phone in your pocket and write you whenever I think it’s necessary. Great! Thank you for being my first student ever trying this. I’m as excited as you are!”");
		FindObjectOfType<TextManager>().StartDialogue(text);
    }

    public void startGame(){
        Initiate.Fade("Troy", Color.black, 1.0f);
    }
}
