using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundManagerWazo : MonoBehaviour
{
    public UnityEvent startingWazo;
    public AudioSource source;
    public AudioClip debut;
    public AudioClip arme;


    private bool first_diag = false;
    private bool second_diag = false;


    private void Start()
    {

    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Voice_Sword")
        {
            if (!second_diag)
            {
                source.clip = arme;
                source.PlayOneShot(arme);
                second_diag = true;
            }
        }
    }

    public void playDebut()
    {
        if (!first_diag)
        {
            source.clip = debut;
            source.PlayOneShot(debut);
            first_diag = true;
        }
    }

}