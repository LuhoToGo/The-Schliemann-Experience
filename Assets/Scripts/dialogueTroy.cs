using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class DialogueTroy : MonoBehaviour {

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
		ScoreManager.instance.ResetScore(); // Punktestand wird zurueckgesetzt
		dialogue = new Queue<string>();
	}
	
	void OnMouseDown() {
		FindObjectOfType<SoundEffects>().playClick();
		nameofobj = gameObject.name;
		Debug.Log (nameofobj);
		TriggerDialogue();
		if (nameofobj != "SchliemannT"){
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
		if (nameofobj == "SchliemannT" && counter == 0){
			FindObjectOfType<ObjToggleTroy>().DeactivateSchliemann();
			dialogue.Clear();
			dialogue.Enqueue("Hello [Player]. It’s nice you’re here.");
			dialogue.Enqueue("There is a lot to do, to be successful and show all those Academic naysayers I was right all along...");
			dialogue.Enqueue("Welcome to Turkey!");
			dialogue.Enqueue("I firmly believe in the historicity of the Homeric epics and therefore believe Troy is an actual place.");
			dialogue.Enqueue("I really hope you have the same opinion on that.");
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		} else if (nameofobj == "homer") {
			QuestionDialogue.Instance.ShowQuestion("A: Yes of course we can find Troy based on evidence in the Iliad. \n \n B: We must be careful because the Homeric epics are works of fiction composed some 500 years after the events its supposed to describe. It is unlikely they are accurate or useful. \n \n C: The homeric epics may offer some useful information but we should consider using other sources as well.",
			 () => {Debug.Log("10 Punkte");
			 		ScoreManager.instance.AddScore(10); // AddScore-Methode des ScoreManagers wird aufgerufen, um 10 Punkte zum Gesamtscore hinzuzufuegen
					FindObjectOfType<SoundEffects>().playRight();
			 		dialogue.Clear();
					dialogue.Enqueue("I am proud of your confidence and that you always see success ahead. That's the path we’re taking.");
					FindObjectOfType<DialogueManager>().StartDialogue(dialogue);}, 
			 () => {Debug.Log("0 Punkte");
			 		FindObjectOfType<SoundEffects>().playWrong();
			 		dialogue.Clear();
					dialogue.Enqueue("I don't really support that decision. Fortunately, you are only my assistant, and I still have the decision-making power.");
					FindObjectOfType<DialogueManager>().StartDialogue(dialogue);}, 
			 () => {Debug.Log("5 Punkte");
			 		ScoreManager.instance.AddScore(5); // AddScore-Methode des ScoreManagers wird aufgerufen, um 5 Punkte zum Gesamtscore hinzuzufuegen
					FindObjectOfType<SoundEffects>().playRight();
			 		dialogue.Clear();
					dialogue.Enqueue("I don't really support that decision. Fortunately, you are only my assistant, and I still have the decision-making power.");
					FindObjectOfType<DialogueManager>().StartDialogue(dialogue);});
		} else if (nameofobj == "SchliemannT" && counter == 3){
			FindObjectOfType<ObjToggleTroy>().DeactivateSchliemann();
			dialogue.Clear();
			dialogue.Enqueue("Oh damn my first choice of site was a bust but my colleague Frank has a different idea.");
			dialogue.Enqueue("Find me the map, so I can see what he is talking about");
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
			counter++; // jetzt 4
		} else if (nameofobj == "plain"){
			dialogue.Clear();
			dialogue.Enqueue("By Jove! Frank may be right but I am very rich and have the media flair.");
			dialogue.Enqueue("I think I should get all the credit for discovering Troy, and keep all the treasure.");
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		} else if (nameofobj == "SchliemannT" && counter == 6){
			FindObjectOfType<ObjToggleTroy>().DeactivateSchliemann();
			dialogue.Clear();
			dialogue.Enqueue("The Trojan war happened a very long time ago so in theory the level of the Trojan war would be very low.");
			dialogue.Enqueue("But how to access it?");
			dialogue.Enqueue("Can you find an object with which we could trigger a small explosion maybe?");
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
			counter++; // jetzt 7
		} else if (nameofobj == "dynamite"){
			QuestionDialogue.Instance.ShowQuestion("A: Perhaps we can go more slowly, digging each level carefully in order to  preserve as much material as possible.  \n \n B: Use dynamite to reach the correct level as quickly and efficiently as possible. \n \n C: The stratigraphic levels are often not so clear. You can probably excavate two-three levels at once without much issue,  and we can always go back if something looks particularly interesting.",
			 () => {Debug.Log("0 Punkte");
			 		FindObjectOfType<SoundEffects>().playWrong();
					dialogue.Clear();
					dialogue.Enqueue("Don't be so hesitant. That way you won't become a great archaeologist like me.");
					dialogue.Enqueue("Just listen to me, I know my stuff.");
					FindObjectOfType<DialogueManager>().StartDialogue(dialogue);}, 
			 () => {Debug.Log("10 Punkte");
			 		ScoreManager.instance.AddScore(10);
					FindObjectOfType<SoundEffects>().playRight();
					dialogue.Clear();
					dialogue.Enqueue("That's what I call effectiveness!");
					FindObjectOfType<DialogueManager>().StartDialogue(dialogue);}, 
			 () => {Debug.Log("5 Punkte");
			 		ScoreManager.instance.AddScore(5);
					FindObjectOfType<SoundEffects>().playRight();
					dialogue.Clear();
					dialogue.Enqueue("Don't be so hesitant. That way you won't become a great archaeologist like me.");
					dialogue.Enqueue("Just listen to me, I know my stuff.");
					FindObjectOfType<DialogueManager>().StartDialogue(dialogue);});
		} else if (nameofobj == "SchliemannT" && counter == 7){
			FindObjectOfType<ObjToggleTroy>().DeactivateSchliemann();
			dialogue.Clear();
			dialogue.Enqueue("With all this hard work we found some sherds.");
			dialogue.Enqueue("Can you bring them to me, please?");
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
			counter++; //jetzt 8
		} else if (nameofobj == "shard"){
			dialogue.Clear();
			dialogue.Enqueue("These sherds look very lame, I don’t think we should keep them.");
			dialogue.Enqueue("Do you agree, [Player]?");
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		} else if (nameofobj == "SchliemannT" && counter == 9){
			FindObjectOfType<ObjToggleTroy>().DeactivateSchliemann();
			dialogue.Clear();
			dialogue.Enqueue("Have you seen the gold Headdress?");
			dialogue.Enqueue("I mean the one that looks very expensive!");
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
			counter++; //jetzt 10
		} else if (nameofobj == "diadem"){
			FindObjectOfType<ObjToggleTroy>().SwapSchliemann();
			dialogue.Clear();
			dialogue.Enqueue("Ah, thank you!");
			dialogue.Enqueue("The findings, especially the very fancy gold ones, are the most important goal of the excavation. Correct?");
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		} else {
			Debug.Log("Irgendwas stimmt hier nicht");
		}	
	}

			
			
	public void postDialogue(){ //wird nach jedem Dialog aufgerufen
		if (nameofobj == "SchliemannT" && counter == 0){
			dialogue.Clear();
			dialogue.Enqueue("Hi [Player], here I am already!");
			dialogue.Enqueue("Just some quick sidenote:");
			dialogue.Enqueue("Even though this is still an exam in my class, and I want you to do great obviously, this experience is about being the best assistant to Schliemann as possible");
			dialogue.Enqueue("So try choosing the answers he chose back then, and not the ones we learned about in class. ;)");
			FindObjectOfType<DialogueManager>().StartDialogueAssistant(dialogue);
			counter++; //jetzt 1
		} else if (nameofobj == "SchliemannT" && counter == 1) {
			dialogue.Clear();
			dialogue.Enqueue("So, do you think I’m right, and we can find out where Troy is nowadays based on the Homeric epics?");
			dialogue.Enqueue("Find me the books and choose your answer.");
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
			counter++; //jetzt 2
		} else if (nameofobj == "SchliemannT" && counter == 2) {
			FindObjectOfType<ObjToggleTroy>().ActivateHomer();
			counter++; //jetzt 3
		} else if (nameofobj == "homer" && counter == 3) {
			FindObjectOfType<ObjToggleTroy>().ActivateSchliemann();
		} else if (nameofobj == "SchliemannT" && counter == 4) {
			FindObjectOfType<ObjToggleTroy>().ActivatePlain();
		} else if (nameofobj == "plain" && counter == 4){
			QuestionDialogue.Instance.ShowQuestion("A: Νo, We should give full credit to all our colleagues and put the artefacts in a museum for everyone to enjoy. \n \n B: Agreed! We will get more attention and funding that way. One great man making a great discovery! \n \n C: Perhaps we can give Frank  a footnote?",
			 () => {Debug.Log("0 Punkte");
			 		FindObjectOfType<SoundEffects>().playWrong();
			 		dialogue.Clear();
					dialogue.Enqueue("Oh, you are too selfless. I will show you how to do it.");
					FindObjectOfType<DialogueManager>().StartDialogue(dialogue);}, 
			 () => {Debug.Log("10 Punkte");
			 		ScoreManager.instance.AddScore(10);
					FindObjectOfType<SoundEffects>().playRight();
			 		dialogue.Clear();
					dialogue.Enqueue("I really like how you are starting to think like I do.");
					FindObjectOfType<DialogueManager>().StartDialogue(dialogue);}, 
			 () => {Debug.Log("5 Punkte");
			 		ScoreManager.instance.AddScore(5);
					FindObjectOfType<SoundEffects>().playRight();
			 		dialogue.Clear();
					dialogue.Enqueue("Oh, you are too selfless. I will show you how to do it.");
					FindObjectOfType<DialogueManager>().StartDialogue(dialogue);});
			counter++; //jetzt 5
		} else if (nameofobj == "plain" && counter == 5){
			dialogue.Clear();
			dialogue.Enqueue("Hey [Player]! Some additional information for you on that:");
			dialogue.Enqueue("Schliemann was actually digging at a site called Pinarbasi and not finding anything and was about to give up.");
			dialogue.Enqueue("His colleague Frank Calvert, who owned part of the mound called Hisarlik advised him to try digging at his mound.");
			dialogue.Enqueue("This is where 'Troy' turned out to be.");
			FindObjectOfType<DialogueManager>().StartDialogueAssistant(dialogue);
			counter++; //jetzt 6
		} else if (nameofobj == "plain" && counter == 6){
			FindObjectOfType<ObjToggleTroy>().ActivateSchliemann();	
		} else if (nameofobj == "SchliemannT" && counter == 7){
			FindObjectOfType<ObjToggleTroy>().ActivateDynamite();
		} else if (nameofobj == "dynamite" && counter == 7){
			FindObjectOfType<SoundEffects>().playExplosion();
		 	FindObjectOfType<ObjToggleTroy>().DeactivateBackground();
			FindObjectOfType<ObjToggleTroy>().ActivateSchliemann();
		} else if (nameofobj == "SchliemannT" && counter == 8){
			FindObjectOfType<ObjToggleTroy>().ActivateShard();
		} else if (nameofobj == "shard" && counter == 8){
			QuestionDialogue.Instance.ShowQuestion("A: All information matters, and we should be as detailed in our collection as  possible. It could be useful for another project \n \n B: Keep only the significant ones, like bases, lips, handles or painted sherds which are diagnostic. We can throw the rest away. \n \n C: Yes, lets just throw it out. Who really cares about lamp bowls and scraps. There is way too many anyway.",
			 () => {Debug.Log("0 Punkte");
			 		FindObjectOfType<SoundEffects>().playWrong();
			 		dialogue.Clear();
					dialogue.Enqueue("You know what? Put them away anyway, I don't want to see these sherds anymore during this dig.");
					FindObjectOfType<DialogueManager>().StartDialogue(dialogue);}, 
			 () => {Debug.Log("5 Punkte");
			 		ScoreManager.instance.AddScore(5);
					FindObjectOfType<SoundEffects>().playRight();
			 		dialogue.Clear();
					dialogue.Enqueue("You know what? Put them away anyway, I don't want to see these sherds anymore during this dig.");
					FindObjectOfType<DialogueManager>().StartDialogue(dialogue);}, 
			 () => {Debug.Log("10 Punkte");
			 		ScoreManager.instance.AddScore(10);
					FindObjectOfType<SoundEffects>().playRight();
			 		dialogue.Clear();
					dialogue.Enqueue("You're right, we should get rid of the junk, it doesn't look very promising.");
					FindObjectOfType<DialogueManager>().StartDialogue(dialogue);});
			counter++; //jetzt 9
		} else if (nameofobj == "shard" && counter == 9){
			FindObjectOfType<ObjToggleTroy>().ActivateSchliemann();
		} else if (nameofobj == "SchliemannT" && counter == 10){
			FindObjectOfType<ObjToggleTroy>().ActivateDiadem();
		} else if (nameofobj == "diadem" && counter == 10){
			QuestionDialogue.Instance.ShowQuestion("A: Absolutely! It gets the most attention. We should give it an inaccurate name to sell more newspapers and have your wife model it  \n \n B: Νo, the findings alone is not the only goal. The archaeological context matters. Have we even checked if this is from the time we claim it is. \n \n C: The gold findings are not the only important items, the media might like them but Museums and fellow archaeologists  are interested in more than that. Have you included these other aspects in your reports Dr. Schliemann?",
			 () => {Debug.Log("10 Punkte");
			 		ScoreManager.instance.AddScore(10);
					FindObjectOfType<SoundEffects>().playRight();
					dialogue.Clear();
					dialogue.Enqueue("That’s it! That’s what we are doing.");
					FindObjectOfType<DialogueManager>().StartDialogue(dialogue);}, 
			 () => {Debug.Log("5 Punkte");
			 		ScoreManager.instance.AddScore(5);
					FindObjectOfType<SoundEffects>().playRight();
			 		dialogue.Clear();
					dialogue.Enqueue("You’re always talking about context and morality… Boooring!");
					FindObjectOfType<DialogueManager>().StartDialogue(dialogue);}, 
			 () => {Debug.Log("0 Punkte");
			 		FindObjectOfType<SoundEffects>().playWrong();
			 		dialogue.Clear();
					dialogue.Enqueue("You’re always talking about context and morality… Boooring!");
					FindObjectOfType<DialogueManager>().StartDialogue(dialogue);});
			counter++; // jetzt 11
		} else if (nameofobj == "diadem" && counter == 11){
			dialogue.Clear();
			dialogue.Enqueue("[Player], you may be interested to know that The 'Treasure of Priam', which the diadem you see was part, was uncovered as during Schliemann's initial excavations.");
			dialogue.Enqueue("It wasn't until Carl Blagen excavated at the site (1932-1938) that the stratigraphy was established and revealed the treasure dated to Troy II (2550-2300) and not Troy VII (1300-1050) when Priam, if he existed, would have ruled the city.");
			FindObjectOfType<DialogueManager>().StartDialogueAssistant(dialogue);
			counter++; //jetzt 12
		} else if (nameofobj == "diadem" && counter == 12){
			QuestionDialogue.Instance.ShowQuestion("A: Continue with Mycenae \n \n B: Quit to Main Menu \n \n C: Quit the Game",
			 () => {Initiate.Fade("Mycenae", Color.black, 1.0f);}, 
			 () => {SceneManager.LoadScene(0);}, 
			 () => {Application.Quit();});
		} else {
			Debug.Log("Keine Reaktion hinterlegt");
		}

	}
}
