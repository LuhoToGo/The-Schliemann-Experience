using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource explosion;
    public AudioSource click;
    public AudioSource clickText;


    public void playExplosion(){
        explosion.Play();
    }

    public void playClick(){
        click.Play();
    }

    public void playClickText(){
        clickText.Play();
    }
}
