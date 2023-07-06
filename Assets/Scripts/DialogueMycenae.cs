using UnityEngine;
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
		dialogue = new Queue<string>();
	}
	
	void OnMouseDown() {
		FindObjectOfType<SoundEffects>().playClick();
		nameofobj = gameObject.name;
		Debug.Log (nameofobj);
		TriggerDialogue();
		if (nameofobj != "SchliemannM"){
			gameObject.SetActive(false);
		}
		
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
		if (nameofobj == "SchliemannM" && counter == 0){
			FindObjectOfType<ObjToggleMycenae>().DeactivateSchliemann();
			dialogue.Clear();
			dialogue.Enqueue("Good morning [Player]. Welcome back for another excavation!");
			dialogue.Enqueue("Welcome to Mycenae. Please find me the permit.");
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		} else if (nameofobj == "permission") {
			dialogue.Clear();
			dialogue.Enqueue("So what would you, my dear assistant, start with today?");
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		} else if (nameofobj == "SchliemannM" && counter == 2) {
			FindObjectOfType<ObjToggleMycenae>().DeactivateSchliemann();
			dialogue.Clear();
			dialogue.Enqueue("Where did I put that stupid report book? Can you find it somewhere?");
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		} else if (nameofobj == "diary") {
			dialogue.Clear();
			dialogue.Enqueue("You’re asking me, if you should finish the reports? Gmpff decide yourself!");
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		} else if (nameofobj == "SchliemannM" && counter == 5) {
			FindObjectOfType<ObjToggleMycenae>().DeactivateSchliemann();
			dialogue.Clear();
			dialogue.Enqueue("Great, so many nice findings here. There was this one pot, I liked specifically…");
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		} else if (nameofobj == "pottery") {
			dialogue.Clear();
			dialogue.Enqueue("Thank you. You are a very good assistant.");
			dialogue.Enqueue("I’ll challenge you to another question, even though the answer is pretty obvious to me.");
			dialogue.Enqueue("Let’s see: Would you say the findings are the most important goal of an excavation?");
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		} else if (nameofobj == "SchliemannM" && counter == 7) {
			FindObjectOfType<ObjToggleMycenae>().DeactivateSchliemann();
			dialogue.Clear();
			dialogue.Enqueue("What shimmers so beautifully golden? Bring it to me!");
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		} else if (nameofobj == "mask") {
			dialogue.Clear();
			dialogue.Enqueue("We finally found the mask! What do you think of it?");
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		} else if (nameofobj == "SchliemannM" && counter == 10) {
			FindObjectOfType<ObjToggleMycenae>().DeactivateSchliemann();
			dialogue.Clear();
			dialogue.Enqueue("This was a very exhausting time for me.");
			dialogue.Enqueue("We should mark the end of the excavation in Mycenae in 1876.");
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		} else if (nameofobj == "EoE") {
			dialogue.Clear();
			dialogue.Enqueue("Can you think of my main reason to end this excavation here, today?");
			dialogue.Enqueue("Think like I do one more time!");
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		} else {
			Debug.Log("Irgendwas stimmt hier nicht");
		}	
	}

			
	public void postDialogue(){ //wird nach jedem Dialog aufgerufen
		if (nameofobj == "SchliemannM" && counter == 0) {
			FindObjectOfType<ObjToggleMycenae>().ActivatePermission();
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
			FindObjectOfType<ObjToggleMycenae>().ActivateSchliemann();
		}  else if (nameofobj == "SchliemannM" && counter == 2) {
			FindObjectOfType<ObjToggleMycenae>().ActivateDiary();
			counter++; //jetzt 3
		} else if (nameofobj == "diary" && counter == 3) {
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
			counter++; //jetzt 4
		} else if (nameofobj == "diary" && counter == 4) {
			dialogue.Clear();
			dialogue.Enqueue("Excavation is a destructive method and cannot be repeated. ");
			dialogue.Enqueue("So, it is important to write in the field or archaeological diary all the procedures followed during the excavation.");
			dialogue.Enqueue("Thus, the archaeologists of the excavation and future researchers will be able to refer to details from the field.");
			dialogue.Enqueue("However it is important to strike that balance between detail and time.");
			dialogue.Enqueue("On an excavation it would be entirely at your discretion.");
			FindObjectOfType<DialogueManager>().StartDialogueAssistant(dialogue);
			counter++; //jetzt 5
		} else if (nameofobj == "diary" && counter == 5) {
			FindObjectOfType<ObjToggleMycenae>().ActivateSchliemann();
		} else if (nameofobj == "SchliemannM" && counter == 5) {
			FindObjectOfType<ObjToggleMycenae>().ActivatePottery();
			counter++; //jetzt 6
		} else if (nameofobj == "pottery" && counter ==  6) {
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
			counter++; //jetzt 7
		} else if (nameofobj == "pottery" && counter ==  7) {
			FindObjectOfType<ObjToggleMycenae>().ActivateSchliemann();
		} else if (nameofobj == "SchliemannM" && counter == 7) {
			FindObjectOfType<ObjToggleMycenae>().ActivateMask();
			counter++; //jetzt 8
		} else if (nameofobj == "mask" && counter == 8) {
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
			counter++; //jetzt 9
		} else if (nameofobj == "mask" && counter == 9) {
			dialogue.Clear();
			dialogue.Enqueue("Schliemann argued that the mask belonged to Agamemnon, the mythical king of Mycenae who lived in the 12th century BC.");
			dialogue.Enqueue("However, some scholars argue that the mask may be a later forgery or a replica rather than an original artifact from the time of Agamemnon.");
			dialogue.Enqueue("The test of the gold may provide the answer!");
			FindObjectOfType<DialogueManager>().StartDialogueAssistant(dialogue);
			counter++; //jetzt 10
		} else if (nameofobj == "mask" && counter == 10) {
			FindObjectOfType<ObjToggleMycenae>().ActivateSchliemann();
		} else if (nameofobj == "SchliemannM" && counter == 10) {
			FindObjectOfType<ObjToggleMycenae>().ActivateEoe();
		} else if (nameofobj == "EoE" && counter == 10) {
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
			counter++; //jetzt 11
		} else if (nameofobj == "EoE" && counter == 11) {
			Initiate.Fade("Epilogue", Color.black, 1.0f); 
		} else {
			Debug.Log("Keine Reaktion hinterlegt");
		}
	}
}

