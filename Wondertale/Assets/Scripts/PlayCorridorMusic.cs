using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCorridorMusic : MonoBehaviour
{
    void Awake()
    {
        FindObjectOfType<AudioManager>().StopPlaying("Awakening_Welcome");
        FindObjectOfType<AudioManager>().Play("mainmenuV1");
    }
}
