﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class DialogueMycenae : MonoBehaviour {

	public static string nameofobj;
	public Texture2D cursorTexture1;
	public Texture2D cursorTexture2;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
	public Queue<string> dialogue;
 	private Color startcolor;
	public static int counter = 0; 


	void Start () {
		ScoreManager.instance.FindScoreSlider(); // Richtige Referenz zum Slider wird gesucht
		ScoreManager.instance.UpdateScoreSlider(); // Punkteleiste wird aktualisiert
		dialogue = new Queue<string>();
	}
	
	void OnMouseDown() {
		FindObjectOfType<SoundEffects>().playClick();
		nameofobj = gameObject.name;
		Debug.Log (nameofobj);
		TriggerDialogue();
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
	

	public void TriggerDialogue() { //wird aufgerufen wenn gameObject angeklickt wurde
		if (nameofobj != "SchliemannM" && counter == 0){
			dialogue.Clear();
			dialogue.Enqueue("Hello [Player]. Try clicking on me instead of this junk.");
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		} else if (nameofobj == "SchliemannM" && counter == 0){
			FindObjectOfType<ObjToggleMycenae>().DeactivateSchliemann();
			dialogue.Clear();
			dialogue.Enqueue("Good morning [Player]. Welcome back for another excavation!");
			dialogue.Enqueue("Welcome to Mycenae. Please find me the permit.");
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		} else if (nameofobj == "permission" && counter == 1) {
			gameObject.SetActive(false);
			FindObjectOfType<ObjToggleMycenae>().ActivatePermissionA();
			dialogue.Clear();
			dialogue.Enqueue("So what would you, my dear assistant, start with today?");
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		} else if (nameofobj == "SchliemannM" && counter == 4) {
			FindObjectOfType<ObjToggleMycenae>().DeactivateSchliemann();
			dialogue.Clear();
			dialogue.Enqueue("Where did I put that stupid report book? Can you find it somewhere?");
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		} else if (nameofobj == "diary" && counter == 5) {
			gameObject.SetActive(false);
			FindObjectOfType<ObjToggleMycenae>().ActivateDiaryA();
			dialogue.Clear();
			dialogue.Enqueue("You’re asking me, if you should finish the reports? Gmpff decide yourself!");
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		} else if (nameofobj == "SchliemannM" && counter == 8) {
			FindObjectOfType<ObjToggleMycenae>().DeactivateSchliemann();
			dialogue.Clear();
			dialogue.Enqueue("Great, so many nice findings here. There was this one pot, I liked specifically…");
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		} else if (nameofobj == "pottery" && counter == 9) {
			gameObject.SetActive(false);
			FindObjectOfType<ObjToggleMycenae>().ActivatePotteryA();
			dialogue.Clear();
			dialogue.Enqueue("Thank you. You are a very good assistant.");
			dialogue.Enqueue("I’ll challenge you to another question, even though the answer is pretty obvious to me.");
			dialogue.Enqueue("Let’s see: Would you say the findings are the most important goal of an excavation?");
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		} else if (nameofobj == "SchliemannM" && counter == 11) {
			FindObjectOfType<ObjToggleMycenae>().DeactivateSchliemann();
			dialogue.Clear();
			dialogue.Enqueue("What shimmers so beautifully golden? Bring it to me!");
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		} else if (nameofobj == "mask" && counter == 12) {
			gameObject.SetActive(false);
			FindObjectOfType<ObjToggleMycenae>().ActivateMaskA();
			dialogue.Clear();
			dialogue.Enqueue("We finally found the mask! What do you think of it?");
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		} else if (nameofobj == "SchliemannM" && counter == 14) {
			FindObjectOfType<ObjToggleMycenae>().DeactivateSchliemann();
			dialogue.Clear();
			dialogue.Enqueue("This was a very exhausting time for me.");
			dialogue.Enqueue("We should mark the end of the excavation in Mycenae in 1876.");
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
			counter++; //jetzt 15
		} else if (nameofobj == "EoE" && counter == 15) {
			gameObject.SetActive(false);
			FindObjectOfType<ObjToggleMycenae>().ActivateEoeA();
			dialogue.Clear();
			dialogue.Enqueue("Can you think of my main reason to end this excavation here, today?");
			dialogue.Enqueue("Think like I do one more time!");
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		} else {
			Debug.Log("Das war der falsche Gegenstand");
			float randomNumber = Random.Range(0, 5);
			dialogue.Clear();
			if (randomNumber == 1){
				dialogue.Enqueue("That is not what i asked you to find for me!");
			} else if (randomNumber == 2){
				dialogue.Enqueue("What are you clicking on? Stop it!");
			} else if (randomNumber == 3){
				dialogue.Enqueue("Maybe you should try clicking me instead!");
			} else if (randomNumber == 4){
				dialogue.Enqueue("Hey! I am more important than clicking on that thing!");
			} else {
				dialogue.Enqueue("What are you doing? Click on me instead!");
			}
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		}	
	}

			
	public void postDialogue(){ //wird nach jedem Dialog aufgerufen
		if (nameofobj == "SchliemannM" && counter == 0) {
			counter++; //jetzt 1
		} else if (nameofobj == "permission" && counter == 1) {
			QuestionDialogue.Instance.ShowQuestion("A: First of all, all the competent authorities need to give their permission. \n \n B: Come on, what's the harm in 34 test trenches without a permit?! \n \n C: The survey before the excavation could start without permission.",
			 () => {Debug.Log("0 Punkte");
			 		FindObjectOfType<SoundEffects>().playWrong();
			 		dialogue.Clear();
					dialogue.Enqueue("You always want to start so slowly. Let's jump right in.");
					FindObjectOfType<DialogueManager>().StartDialogue(dialogue);}, 
			 () => {Debug.Log("10 Punkte");
			 		ScoreManager.instance.AddScore(10);
					FindObjectOfType<SoundEffects>().playRight();
			 		dialogue.Clear();
					dialogue.Enqueue("I totally agree.");
					FindObjectOfType<DialogueManager>().StartDialogue(dialogue);}, 
			 () => {Debug.Log("5 Punkte");
			 		ScoreManager.instance.AddScore(5);
					FindObjectOfType<SoundEffects>().playRight();
			 		dialogue.Clear();
					dialogue.Enqueue("You always want to start so slowly. Let's jump right in.");
					FindObjectOfType<DialogueManager>().StartDialogue(dialogue);});
			counter++; //jetzt 2
		}  else if (nameofobj == "permission" && counter == 2) {
			dialogue.Clear();
			dialogue.Enqueue("Εxcavations must always start after the relevant permission of the responsible authorities.");
			dialogue.Enqueue("Usually archaeologists must be careful and well informed about what is allowed and what is not, as well as that each country has its own legal framework.");
			FindObjectOfType<DialogueManager>().StartDialogueAssistant(dialogue);
			counter++; //jetzt 3
		}  else if (nameofobj == "permission" && counter == 3) {
			FindObjectOfType<ObjToggleMycenae>().DeactivatePermissionA();
			FindObjectOfType<ObjToggleMycenae>().ActivateSchliemann();
			counter++; //jetzt 4
		} else if (nameofobj == "SchliemannM" && counter == 4) {
			counter++; //jetzt 5
		} else if (nameofobj == "diary" && counter == 5) {
			QuestionDialogue.Instance.ShowQuestion("A: I’ll just put some imagination on it, so I won’t loose precious time. \n \n B: I was always taught that, ‘All information matters’, so I’ll write them as detailed as possible. \n \n C: Maybe the details are not necessary, I’ll just write a basic report.",
			 () => {Debug.Log("10 Punkte");
			 		ScoreManager.instance.AddScore(10);
					FindObjectOfType<SoundEffects>().playRight();
			 		dialogue.Clear();
					dialogue.Enqueue("Time and money over everything! You and I, we speak the same language.");
					FindObjectOfType<DialogueManager>().StartDialogue(dialogue);}, 
			 () => {Debug.Log("0 Punkte");
			 		FindObjectOfType<SoundEffects>().playWrong();
			 		dialogue.Clear();
					dialogue.Enqueue("Hmm… And I still tell you, nobody wants to read these overly detailed reports.");
					FindObjectOfType<DialogueManager>().StartDialogue(dialogue);}, 
			 () => {Debug.Log("5 Punkte");
			 		ScoreManager.instance.AddScore(5);
					FindObjectOfType<SoundEffects>().playRight();
			 		dialogue.Clear();
					dialogue.Enqueue("Hmm… And I still tell you, nobody wants to read these overly detailed reports.");
					FindObjectOfType<DialogueManager>().StartDialogue(dialogue);});
			counter++; //jetzt 6
		} else if (nameofobj == "diary" && counter == 6) {
			dialogue.Clear();
			dialogue.Enqueue("Excavation is a destructive method and cannot be repeated. ");
			dialogue.Enqueue("So, it is important to write in the field or archaeological diary all the procedures followed during the excavation.");
			dialogue.Enqueue("Thus, the archaeologists of the excavation and future researchers will be able to refer to details from the field.");
			dialogue.Enqueue("However it is important to strike that balance between detail and time.");
			dialogue.Enqueue("On an excavation it would be entirely at your discretion.");
			FindObjectOfType<DialogueManager>().StartDialogueAssistant(dialogue);
			counter++; //jetzt 7
		} else if (nameofobj == "diary" && counter == 7) {
			FindObjectOfType<ObjToggleMycenae>().DeactivateDiaryA();
			FindObjectOfType<ObjToggleMycenae>().ActivateSchliemann();
			counter++; //jetzt 8
		} else if (nameofobj == "SchliemannM" && counter == 8) {
			counter++; //jetzt 9
		} else if (nameofobj == "pottery" && counter ==  9) {
			QuestionDialogue.Instance.ShowQuestion("A: Νo, the findings alone is not the goal. The archaeological context matters. \n \n B: Historical and cultural significance through careful analysis matter more. \n \n C: Absolutely! Give money to the workers. Faster work - more findings",
			 () => {Debug.Log("5 Punkte");
			 		ScoreManager.instance.AddScore(5);
					FindObjectOfType<SoundEffects>().playRight();
			 		dialogue.Clear();
					dialogue.Enqueue("Maybe I'll look for another assistant. Sometimes you don’t seem to like the fun parts.");
					FindObjectOfType<DialogueManager>().StartDialogue(dialogue);}, 
			 () => {Debug.Log("0 Punkte");
			 		FindObjectOfType<SoundEffects>().playWrong();
			 		dialogue.Clear();
					dialogue.Enqueue("Maybe I'll look for another assistant. Sometimes you don’t seem to like the fun parts.");
					FindObjectOfType<DialogueManager>().StartDialogue(dialogue);}, 
			 () => {Debug.Log("10 Punkte");
			 		ScoreManager.instance.AddScore(10);
					FindObjectOfType<SoundEffects>().playRight();
			 		dialogue.Clear();
					dialogue.Enqueue("Yes, yes, YES!");
					FindObjectOfType<DialogueManager>().StartDialogue(dialogue);});
			counter++; //jetzt 10
		} else if (nameofobj == "pottery" && counter ==  10) {
			dialogue.Clear();
			dialogue.Enqueue("Τhe findings of an excavation are quite important, however, without the archaeological context-");
			dialogue.Enqueue("where they were found (coordinates, stratigraphy) are simple findings.");
			dialogue.Enqueue("Only their examination as part of a whole can help in the understanding of the past.");
			FindObjectOfType<DialogueManager>().StartDialogueAssistant(dialogue);
			counter++; //jetzt 11
		} else if (nameofobj == "pottery" && counter ==  11) {
			FindObjectOfType<ObjToggleMycenae>().DeactivatePotteryA();
			FindObjectOfType<ObjToggleMycenae>().ActivateSchliemann();
		} else if (nameofobj == "SchliemannM" && counter == 11) {
			counter++; //jetzt 12
		} else if (nameofobj == "mask" && counter == 12) {
			QuestionDialogue.Instance.ShowQuestion("A: The examination of the context will give us the chronology. \n \n B: It’s definitely Agamemnon’s death mask! \n \n C: Some examination of the gold can give us an accurate chronology.",
			 () => {Debug.Log("0 Punkte");
			 		FindObjectOfType<SoundEffects>().playWrong();
			 		dialogue.Clear();
					dialogue.Enqueue("Accuracy, chronology, reliability, all these words ending on ‘y’ are my least favorite…");
					FindObjectOfType<DialogueManager>().StartDialogue(dialogue);}, 
			 () => {Debug.Log("10 Punkte");
			 		ScoreManager.instance.AddScore(10);
					FindObjectOfType<SoundEffects>().playRight();
			 		dialogue.Clear();
					dialogue.Enqueue("That's the same language that you and I have, that I mean.");
					FindObjectOfType<DialogueManager>().StartDialogue(dialogue);}, 
			 () => {Debug.Log("5 Punkte");
			 		ScoreManager.instance.AddScore(5);
					FindObjectOfType<SoundEffects>().playRight();
			 		dialogue.Clear();
					dialogue.Enqueue("Accuracy, chronology, reliability, all these words ending on ‘y’ are my least favorite…");
					FindObjectOfType<DialogueManager>().StartDialogue(dialogue);});
			counter++; //jetzt 13
		} else if (nameofobj == "mask" && counter == 13) {
			dialogue.Clear();
			dialogue.Enqueue("Schliemann argued that the mask belonged to Agamemnon, the mythical king of Mycenae who lived in the 12th century BC.");
			dialogue.Enqueue("However, some scholars argue that the mask may be a later forgery or a replica rather than an original artifact from the time of Agamemnon.");
			dialogue.Enqueue("The test of the gold may provide the answer!");
			FindObjectOfType<DialogueManager>().StartDialogueAssistant(dialogue);
			counter++; //jetzt 14
		} else if (nameofobj == "mask" && counter == 14) {
			FindObjectOfType<ObjToggleMycenae>().DeactivateMaskA();
			FindObjectOfType<ObjToggleMycenae>().ActivateSchliemann();
		} else if (nameofobj == "EoE" && counter == 15) {
			QuestionDialogue.Instance.ShowQuestion("A: We have Agamemnon’s treasures, we have nothing more to discover. \n \n B: We don’t have enough money to continue. \n \n C: Our work is done, all the archaeological remains have been documented. Next step, their examination.",
			 () => {Debug.Log("10 Punkte");
			 		ScoreManager.instance.AddScore(10);
					FindObjectOfType<SoundEffects>().playRight();
			 		dialogue.Clear();
					dialogue.Enqueue("Exactly my opinion! I really liked working with you [Player]. See you when the opportunity arises.");
					FindObjectOfType<DialogueManager>().StartDialogue(dialogue);}, 
			 () => {Debug.Log("5 Punkte");
			 		ScoreManager.instance.AddScore(5);
					FindObjectOfType<SoundEffects>().playRight();
			 		dialogue.Clear();
					dialogue.Enqueue("Yeah yeah, Let's pack up our stuff and get out of here.");
					FindObjectOfType<DialogueManager>().StartDialogue(dialogue);}, 
			 () => {Debug.Log("0 Punkte");
			 		FindObjectOfType<SoundEffects>().playWrong();
			 		dialogue.Clear();
					dialogue.Enqueue("Yeah yeah, Let's pack up our stuff and get out of here.");
					FindObjectOfType<DialogueManager>().StartDialogue(dialogue);});
			counter++; //jetzt 16
		} else if (nameofobj == "EoE" && counter == 16) {
			dialogue.Clear();
			dialogue.Enqueue("Excavations are usually permitted for a certain period of time.");
			dialogue.Enqueue("The finding of important objects, or objects that archaeologists consider important, is not a factor affecting the end of the excavation.");
			dialogue.Enqueue("An important factor is the good and detailed documentation of all findings.");
			dialogue.Enqueue("However, we must bear in mind that the archaeological sector often suffers from insufficient funding or pressure from construction companies to complete excavations more quickly.");
			FindObjectOfType<DialogueManager>().StartDialogueAssistant(dialogue);
			counter++; //jetzt 17
		} else if (nameofobj == "EoE" && counter == 17) {
			FindObjectOfType<ObjToggleMycenae>().DeactivateEoeA();
			Initiate.Fade("Epilogue", Color.black, 1.0f); 
		} else {
			Debug.Log("Keine Reaktion hinterlegt");
		}
	}
}
