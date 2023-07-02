using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//template: FindObjectOfType<ObjToggleMycenae>().ActivateObject();
//template: FindObjectOfType<ObjToggleMycenae>().DeactivateObject();

//templateS: FindObjectOfType<ObjToggleMycenae>().ActivateSchliemann();
//templateS: FindObjectOfType<ObjToggleMycenae>().DeactivateSchliemann();


//Das ist wahnsinnig unschoen, aber funktioniert erstmal. Ich glaub ich hab Migraene.
public class ObjToggleMycenae : MonoBehaviour
{
    public GameObject mask; 
    public GameObject diary; 
    public GameObject pottery; 
    public GameObject permission; 
    public GameObject eoe; 
    public GameObject schliemann;

    private Color maskColor;
    private Color diaryColor;
    private Color potteryColor;
    private Color permissionColor;
    private Color eoeColor;
    
    public void ActivateSchliemann(){
        schliemann.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void DeactivateSchliemann(){
        schliemann.GetComponent<BoxCollider2D>().enabled = false;
    }
    
    public void ActivateMask(){
        mask.GetComponent<BoxCollider2D>().enabled = true;
        mask.GetComponent<Renderer>().material.color = maskColor;
    }

    public void DeactivateMask(){
        mask.GetComponent<BoxCollider2D>().enabled = false;
        maskColor = mask.GetComponent<Renderer>().material.color;
    	mask.GetComponent<Renderer>().material.color = Color.grey;
    }

    public void ActivateDiary(){
        diary.GetComponent<BoxCollider2D>().enabled = true;
        diary.GetComponent<Renderer>().material.color = diaryColor;
    }

    public void DeactivateDiary(){
        diary.GetComponent<BoxCollider2D>().enabled = false;
        diaryColor = diary.GetComponent<Renderer>().material.color;
    	diary.GetComponent<Renderer>().material.color = Color.grey;
    }

    public void ActivatePottery(){
        pottery.GetComponent<BoxCollider2D>().enabled = true;
        pottery.GetComponent<Renderer>().material.color = potteryColor;
    }

    public void DeactivatePottery(){
        pottery.GetComponent<BoxCollider2D>().enabled = false;
        potteryColor = pottery.GetComponent<Renderer>().material.color;
    	pottery.GetComponent<Renderer>().material.color = Color.grey;
    }

    public void ActivatePermission(){
        permission.GetComponent<BoxCollider2D>().enabled = true;
        permission.GetComponent<Renderer>().material.color = permissionColor;
    }

    public void DeactivatePermission(){
        permission.GetComponent<BoxCollider2D>().enabled = false;
        permissionColor = permission.GetComponent<Renderer>().material.color;
    	permission.GetComponent<Renderer>().material.color = Color.grey;
    }

    public void ActivateEoe(){
        eoe.GetComponent<BoxCollider2D>().enabled = true;
        eoe.GetComponent<Renderer>().material.color = eoeColor;
    }

    public void DeactivateEoe(){
        eoe.GetComponent<BoxCollider2D>().enabled = false;
        eoeColor = eoe.GetComponent<Renderer>().material.color;
    	eoe.GetComponent<Renderer>().material.color = Color.grey;
    }
}
