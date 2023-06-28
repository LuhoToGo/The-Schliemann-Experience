using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class clickcontrol : MonoBehaviour {

	public static string nameofobj;
	public Texture2D cursorTexture1;
	public Texture2D cursorTexture2;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
	public Queue<string> dialogue;
 	private Color startcolor;
	int points;


	void Start () {
		dialogue = new Queue<string>();
	}
	
	public void TriggerDialogue() {
		if (nameofobj == "SchliemannT"){
			dialogue.Clear();
			dialogue.Enqueue("Hello *name* It’s nice you’re here.");
			dialogue.Enqueue("There is a lot to do, to be successful and show all those Academic naysayers I was right all along...");
			dialogue.Enqueue("Welcome to Turkey!");
			dialogue.Enqueue("I firmly believe in the historicity of the Homeric epics and therefore believe Troy is an actual place.");
			dialogue.Enqueue("I really hope you have the same opinion on that.");
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		} else if (nameofobj == "diary") {
			dialogue.Clear();
			dialogue.Enqueue("i am a diary");
			dialogue.Enqueue("yeeeet");
			dialogue.Enqueue("testestest");
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		}
	}

	void OnMouseDown() {
		nameofobj = gameObject.name;
		Debug.Log (nameofobj);
		TriggerDialogue();
		gameObject.SetActive(false);
		Cursor.SetCursor(cursorTexture1, hotSpot, cursorMode);
	}

 	void OnMouseEnter()
 	{
    	 startcolor = GetComponent<Renderer>().material.color;
    	 GetComponent<Renderer>().material.color = Color.yellow;
		 Cursor.SetCursor(cursorTexture2, hotSpot, cursorMode);
	}
 	void OnMouseExit()
 	{
    	 GetComponent<Renderer>().material.color = startcolor;
		 Cursor.SetCursor(cursorTexture1, hotSpot, cursorMode);
 	}

	public void showQuestion(){ //wird nach jedem Dialog aufgerufen, hier also die passenden Fragen an den Spieler stellen
		Debug.Log("showQuestion funktioniert");
		if (nameofobj == "SchliemannT"){
			dialogue.Clear();
			dialogue.Enqueue("Hi *name*, here I am already!");
			dialogue.Enqueue("Just some quick sidenote:");
			dialogue.Enqueue("Just some quick sidenote:");
			FindObjectOfType<DialogueManager>().StartDialogueAssistant(dialogue);
		} else if (nameofobj == "diary") {
			Debug.Log("Diary weiter gehts");
		}

	}
}

