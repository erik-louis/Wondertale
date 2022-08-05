using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayHospitalMusic : MonoBehaviour
{
   
    void Awake()
    {
        FindObjectOfType<AudioManager>().StopPlaying("mainmenuv2");
        FindObjectOfType<AudioManager>().Play("Hospital");
    }

}
