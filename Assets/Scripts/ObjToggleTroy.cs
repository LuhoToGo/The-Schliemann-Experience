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
    public GameObject explosion;
    public GameObject dynamiteA;
    public Animator homerAn;
    public Animator shardAn;
    public Animator diademAn; 
    public Animator plainAn; 
    public Animator dynamiteAn; 

    
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

    public void DeactivateHomer(){
        homer.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void ActivateHomerA(){
        homerAn.SetBool("IsOpen", true);
    }

    public void DeactivateHomerA(){
        homerAn.SetBool("IsOpen", false);
    }

    public void ActivateShard(){
        shard.GetComponent<BoxCollider2D>().enabled = true;
    }
    
    public void DeactivateShard(){
        shard.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void ActivateShardA(){
        shardAn.SetBool("IsOpen", true);
    }

    public void DeactivateShardA(){
        shardAn.SetBool("IsOpen", false);
    }

    public void ActivateDiadem(){
        diadem.GetComponent<BoxCollider2D>().enabled = true;
    }
    
    public void DeactivateDiadem(){
        diadem.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void ActivateDiademA(){
        diademAn.SetBool("IsOpen", true);
    }

    public void DeactivateDiademA(){
        diademAn.SetBool("IsOpen", false);
    }

    public void DeactivatePlain(){
        plain.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void ActivatePlainA(){
        plainAn.SetBool("IsOpen", true);
    }

    public void DeactivatePlainA(){
        plainAn.SetBool("IsOpen", false);
    }

    public void DeactivateDynamite(){
        dynamite.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void ActivateDynamiteA(){
        dynamiteAn.SetBool("IsOpen", true);
    }

    public void DeactivateDynamiteA(){
        dynamiteA.SetActive(false);
        explosion.SetActive(true);
        Invoke("DeactivateExplosion",1);
    }

    public void DeactivateExplosion(){
        explosion.SetActive(false);
    }

    public void DeactivateTroyObj(){
        DeactivateHomer();
        DeactivatePlain();
        DeactivateDynamite();
        DeactivateDiadem();
        DeactivateShard();
    }

    public void ActivateTroyObj(){
        homer.GetComponent<BoxCollider2D>().enabled = true;
        plain.GetComponent<BoxCollider2D>().enabled = true;
        dynamite.GetComponent<BoxCollider2D>().enabled = true;
        diadem.GetComponent<BoxCollider2D>().enabled = true;
        shard.GetComponent<BoxCollider2D>().enabled = true;
    }
}
