using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//template: FindObjectOfType<ObjToggleMycenae>().ActivateObject();
//template: FindObjectOfType<ObjToggleMycenae>().DeactivateObject();

//templateS: FindObjectOfType<ObjToggleMycenae>().ActivateSchliemann();
//templateS: FindObjectOfType<ObjToggleMycenae>().DeactivateSchliemann();

public class ObjToggleMycenae : MonoBehaviour
{

    //Gameplay Objects
    public GameObject mask; 
    public GameObject diary; 
    public GameObject pottery; 
    public GameObject permission; 
    public GameObject eoe; 
    public GameObject schliemann;


    //Artwork Showcase Objects

    public Animator maskAn;
    public Animator diaryAn;
    public Animator potteryAn;
    public Animator permissionAn;
    public Animator eoeAn;

    public void ActivateSchliemann(){
        schliemann.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void DeactivateSchliemann(){
        schliemann.GetComponent<BoxCollider2D>().enabled = false;
    }
    
    public void ActivateMask(){
        mask.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void DeactivateMask(){
        mask.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void ActivateMaskA(){

        maskAn.SetBool("IsOpen", true);
    }

    public void DeactivateMaskA(){
        maskAn.SetBool("IsOpen", false);

    }

    public void ActivateDiary(){
        diary.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void DeactivateDiary(){
        diary.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void ActivateDiaryA(){

        diaryAn.SetBool("IsOpen", true);
    }

    public void DeactivateDiaryA(){
        diaryAn.SetBool("IsOpen", false);

    }

    public void ActivatePottery(){
        pottery.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void DeactivatePottery(){
        pottery.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void ActivatePotteryA(){

        potteryAn.SetBool("IsOpen", true);
    }

    public void DeactivatePotteryA(){
        potteryAn.SetBool("IsOpen", false);

    }

    public void ActivatePermission(){
        permission.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void DeactivatePermission(){
        permission.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void ActivatePermissionA(){

        permissionAn.SetBool("IsOpen", true);
    }

    public void DeactivatePermissionA(){
        permissionAn.SetBool("IsOpen", false);

    }

    public void ActivateEoe(){
        eoe.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void DeactivateEoe(){
        eoe.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void ActivateEoeA(){

        eoeAn.SetBool("IsOpen", true);
    }

    public void DeactivateEoeA(){
        eoeAn.SetBool("IsOpen", false);

    }
}
