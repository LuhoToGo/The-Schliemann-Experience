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
    public GameObject maskA; 
    public GameObject diaryA; 
    public GameObject potteryA; 
    public GameObject permissionA; 
    public GameObject eoeA; 

    
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
        maskA.SetActive(true);
    }

    public void DeactivateMaskA(){
        maskA.SetActive(false);
    }

    public void ActivateDiary(){
        diary.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void DeactivateDiary(){
        diary.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void ActivateDiaryA(){
        diaryA.SetActive(true);
    }

    public void DeactivateDiaryA(){
        diaryA.SetActive(false);
    }

    public void ActivatePottery(){
        pottery.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void DeactivatePottery(){
        pottery.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void ActivatePotteryA(){
        potteryA.SetActive(true);
    }

    public void DeactivatePotteryA(){
        potteryA.SetActive(false);
    }

    public void ActivatePermission(){
        permission.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void DeactivatePermission(){
        permission.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void ActivatePermissionA(){
        permissionA.SetActive(true);
    }

    public void DeactivatePermissionA(){
        permissionA.SetActive(false);
    }

    public void ActivateEoe(){
        eoe.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void DeactivateEoe(){
        eoe.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void ActivateEoeA(){
        eoeA.SetActive(true);
    }

    public void DeactivateEoeA(){
        eoeA.SetActive(false);
    }
}
