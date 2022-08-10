using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayThankYouMusic : MonoBehaviour
{
    void Awake()
    {
        FindObjectOfType<AudioManager>().StopPlaying("StompRoom");
        FindObjectOfType<AudioManager>().Play("mainmenuv2");
    }
}
