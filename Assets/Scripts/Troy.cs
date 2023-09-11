using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troy : MonoBehaviour
{
    // Deaktiviert die Klickbarkeit der Shards und des Diadems, damit diese nicht vor der Explosion durch die Wand angeklickt werden können
    void Start(){
        FindObjectOfType<ObjToggleTroy>().DeactivateShard();
		FindObjectOfType<ObjToggleTroy>().DeactivateDiadem();
    }

}
