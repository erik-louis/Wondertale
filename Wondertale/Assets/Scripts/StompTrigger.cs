using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompTrigger : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Foot")
        {
            audioSource.PlayOneShot(audioClip);
            
        }
    }
}
