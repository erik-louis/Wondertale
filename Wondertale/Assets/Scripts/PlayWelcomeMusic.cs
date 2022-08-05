using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWelcomeMusic : MonoBehaviour
{
    void Awake()
    {
        FindObjectOfType<AudioManager>().StopPlaying("mainmenuv2");
        FindObjectOfType<AudioManager>().Play("Awakening_Welcome");
    }
}
