using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//template: FindObjectOfType<ObjToggleTroy>().ActivateObject();
//template: FindObjectOfType<ObjToggleTroy>().DeactivateObject();

//templateS: FindObjectOfType<ObjToggleTroy>().ActivateSchliemann();
//templateS: FindObjectOfType<ObjToggleTroy>().DeactivateSchliemann();


//Das ist wahnsinnig unschoen, aber funktioniert erstmal. Ich glaub ich hab Migraene.
<<<<<<< Updated upstream
=======
//Toggle ueber einen Bool zu machen ist aber hier auch nicht viel schoener.
>>>>>>> Stashed changes
public class ObjToggleTroy : MonoBehaviour
{
    public GameObject homer; 
    public GameObject shard; 
    public GameObject diadem; 
    public GameObject plain; 
    public GameObject dynamite; 
    public GameObject schliemann;
    public GameObject schliemannD;
    public GameObject background;

<<<<<<< Updated upstream

    //private Color homerColor;
    //private Color shardColor;
    //private Color diademColor;
    //private Color plainColor;
    //private Color dynamiteColor;
    
=======
    //Artwork Showcase Objects
    public Animator homerAn;
    public Animator shardAn;
    public Animator diademAn;
    public Animator plainAn;
    public Animator dynamiteAn;


>>>>>>> Stashed changes
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
        //homer.GetComponent<Renderer>().material.color = homerColor;
    }

    public void DeactivateHomer(){
        homer.GetComponent<BoxCollider2D>().enabled = false;
        //homerColor = homer.GetComponent<Renderer>().material.color;
    	//homer.GetComponent<Renderer>().material.color = Color.grey;
    }

    public void ActivateShard(){
        shard.GetComponent<BoxCollider2D>().enabled = true;
        //shard.GetComponent<Renderer>().material.color = shardColor;
    }

    public void DeactivateShard(){
        shard.GetComponent<BoxCollider2D>().enabled = false;
        //shardColor = shard.GetComponent<Renderer>().material.color;
    	//shard.GetComponent<Renderer>().material.color = Color.grey;
    }

    public void ActivateDiadem(){
        diadem.GetComponent<BoxCollider2D>().enabled = true;
        //diadem.GetComponent<Renderer>().material.color = diademColor;
    }

    public void DeactivateDiadem(){
        diadem.GetComponent<BoxCollider2D>().enabled = false;
<<<<<<< Updated upstream
        //diademColor = diadem.GetComponent<Renderer>().material.color;
    	//diadem.GetComponent<Renderer>().material.color = Color.grey;
=======
    }

    public void ActivateDiademA(){
        diademAn.SetBool("IsOpen", true);
    }

    public void DeactivateDiademA(){
        diademAn.SetBool("IsOpen", false);
>>>>>>> Stashed changes
    }

    public void ActivatePlain(){
        plain.GetComponent<BoxCollider2D>().enabled = true;
        //plain.GetComponent<Renderer>().material.color = plainColor;
    }

    public void DeactivatePlain(){
        plain.GetComponent<BoxCollider2D>().enabled = false;
<<<<<<< Updated upstream
        //plainColor = plain.GetComponent<Renderer>().material.color;
    	//plain.GetComponent<Renderer>().material.color = Color.grey;
=======
    }

    public void ActivatePlainA(){
        plainAn.SetBool("IsOpen", true);
    }

    public void DeactivatePlainA(){
        plainAn.SetBool("IsOpen", false);
>>>>>>> Stashed changes
    }

    public void ActivateDynamite(){
        dynamite.GetComponent<BoxCollider2D>().enabled = true;
        //dynamite.GetComponent<Renderer>().material.color = dynamiteColor;
    }

    public void DeactivateDynamite(){
        dynamite.GetComponent<BoxCollider2D>().enabled = false;
<<<<<<< Updated upstream
        //dynamiteColor = dynamite.GetComponent<Renderer>().material.color;
    	//dynamite.GetComponent<Renderer>().material.color = Color.grey;
=======
    }

    public void ActivateDynamiteA(){
        dynamiteAn.SetBool("IsOpen", true);
    }

    public void DeactivateDynamiteA(){
        dynamiteAn.SetBool("IsOpen", false);
>>>>>>> Stashed changes
    }
}
