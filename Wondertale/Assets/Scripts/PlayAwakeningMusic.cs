using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAwakeningMusic : MonoBehaviour
{
    void Awake()
    {
        FindObjectOfType<AudioManager>().StopPlaying("Hospital");
        FindObjectOfType<AudioManager>().Play("Awakening_Welcome");
    }
}
