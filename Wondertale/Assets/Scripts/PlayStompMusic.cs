using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayStompMusic : MonoBehaviour
{
    void Awake()
    {
        FindObjectOfType<AudioManager>().StopPlaying("Inside_the_Tent");
        FindObjectOfType<AudioManager>().Play("StompRoom");
    }
}
