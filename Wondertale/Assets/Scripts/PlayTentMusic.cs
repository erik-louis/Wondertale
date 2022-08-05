using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTentMusic : MonoBehaviour
{
    void Awake()
    {
        FindObjectOfType<AudioManager>().StopPlaying("Awakening_Welcome");
        FindObjectOfType<AudioManager>().Play("Inside_the_Tent");
    }
}
