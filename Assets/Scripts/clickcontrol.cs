﻿using UnityEngine;
using System.Collections;

public class clickcontrol : MonoBehaviour {

	public static string nameofobj;
	public Texture2D cursorTexture1;
	public Texture2D cursorTexture2;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
 	private Color startcolor;
	public int count = 0;

	public Dialogue dialogue;

	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TriggerDialogue() {
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
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
}

