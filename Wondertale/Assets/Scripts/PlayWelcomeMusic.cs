using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWelcomeMusic : MonoBehaviour
{
    void Awake()
    {
        FindObjectOfType<AudioManager>().StopPlaying("Corridor_Atmosphere");
        FindObjectOfType<AudioManager>().Play("Awakening_Welcome");
    }
}
