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
		
	}

			
	public void postDialogue(){ //wird nach jedem Dialog aufgerufen
		
	}
}

