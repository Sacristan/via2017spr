using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamEventController : MonoBehaviour {
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") // If other game object tag is Player
        {
            audioSource.Play(); //Play audio source
        }
    }

}
