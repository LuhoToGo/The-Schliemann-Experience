using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//template: FindObjectOfType<ObjToggle>().ActivateObject();
//template: FindObjectOfType<ObjToggle>().DeactivateObject();


//Das ist wahnsinnig unschoen, aber funktioniert erstmal
public class ObjToggleTroy : MonoBehaviour
{
    public GameObject homer; 
    public GameObject sherd; 
    public GameObject diadem; 
    public GameObject plain; 
    public GameObject dynamite; 


    public void ActivateHomer(){
        homer.SetActive(true);
    }

    public void DeactivateHomer(){
        homer.SetActive(false);
    }

    public void ActivateSherd(){
        sherd.SetActive(true);
    }

    public void DeactivateSherd(){
        sherd.SetActive(false);
    }

    public void ActivateDiadem(){
        diadem.SetActive(true);
    }

    public void DeactivateDiadem(){
        diadem.SetActive(false);
    }

    public void ActivatePlain(){
        plain.SetActive(true);
    }

    public void DeactivatePlain(){
        plain.SetActive(false);
    }

    public void ActivateDynamite(){
        dynamite.SetActive(true);
    }

    public void DeactivateDynamite(){
        dynamite.SetActive(false);
    }
}
