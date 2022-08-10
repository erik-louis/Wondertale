using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play2ndFloorMusic : MonoBehaviour
{
    void Awake()
    {
        FindObjectOfType<AudioManager>().StopPlaying("Inside_the_Tent");
        FindObjectOfType<AudioManager>().Play("StompRoom");
    }
}
