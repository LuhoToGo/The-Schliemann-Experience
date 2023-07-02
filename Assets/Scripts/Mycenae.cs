using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mycenae : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<ObjToggleMycenae>().DeactivateMask();
        FindObjectOfType<ObjToggleMycenae>().DeactivateDiary();
        FindObjectOfType<ObjToggleMycenae>().DeactivatePottery();
        FindObjectOfType<ObjToggleMycenae>().DeactivatePermission();
        FindObjectOfType<ObjToggleMycenae>().DeactivateEoe();
    }
}
