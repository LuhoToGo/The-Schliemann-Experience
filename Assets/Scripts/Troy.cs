using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<ObjToggleTroy>().DeactivateHomer();
        FindObjectOfType<ObjToggleTroy>().DeactivateSherd();
        FindObjectOfType<ObjToggleTroy>().DeactivateDiadem();
        FindObjectOfType<ObjToggleTroy>().DeactivatePlain();
        FindObjectOfType<ObjToggleTroy>().DeactivateDynamite();
    }
}
