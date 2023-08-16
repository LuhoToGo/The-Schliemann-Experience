using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//template: FindObjectOfType<ObjToggleTroy>().ActivateObject();
//template: FindObjectOfType<ObjToggleTroy>().DeactivateObject();

//templateS: FindObjectOfType<ObjToggleTroy>().ActivateSchliemann();
//templateS: FindObjectOfType<ObjToggleTroy>().DeactivateSchliemann();


//Das ist wahnsinnig unschoen, aber funktioniert erstmal. Ich glaub ich hab Migraene.
//Toggle über einen Bool zu machen ist aber hier auch nicht viel schoener.
public class ObjToggleTroy : MonoBehaviour
{
    
    //Gameplay Objects
    public GameObject homer; 
    public GameObject shard; 
    public GameObject diadem; 
    public GameObject plain; 
    public GameObject dynamite; 
    public GameObject schliemann;
    public GameObject schliemannD;
    public GameObject background;

    //Artwork Showcase Objects
    public GameObject homerA; 
    public GameObject shardA; 
    public GameObject diademA; 
    public GameObject plainA; 
    public GameObject dynamiteA; 

    
    public void ActivateSchliemann(){
        schliemann.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void DeactivateSchliemann(){
        schliemann.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void SwapSchliemann(){
        schliemann.GetComponent<SpriteRenderer>().enabled = false;
        schliemannD.SetActive(true);
    }

    public void DeactivateBackground(){
        background.SetActive(false);
    }
    
    public void ActivateHomer(){
        homer.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void DeactivateHomer(){
        homer.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void ActivateHomerA(){
        homerA.SetActive(true);
    }

    public void DeactivateHomerA(){
        homerA.SetActive(false);
    }

    public void ActivateShard(){
        shard.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void DeactivateShard(){
        shard.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void ActivateShardA(){
        shardA.SetActive(true);
    }

    public void DeactivateShardA(){
        shardA.SetActive(false);
    }

    public void ActivateDiadem(){
        diadem.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void DeactivateDiadem(){
        diadem.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void ActivateDiademA(){
        diademA.SetActive(true);
    }

    public void DeactivateDiademA(){
        diademA.SetActive(false);
    }

    public void ActivatePlain(){
        plain.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void DeactivatePlain(){
        plain.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void ActivatePlainA(){
        plainA.SetActive(true);
    }

    public void DeactivatePlainA(){
        plainA.SetActive(false);
    }

    public void ActivateDynamite(){
        dynamite.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void DeactivateDynamite(){
        dynamite.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void ActivateDynamiteA(){
        dynamiteA.SetActive(true);
    }

    public void DeactivateDynamiteA(){
        dynamiteA.SetActive(false);
    }
}
