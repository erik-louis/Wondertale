using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySunnyGasp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")

        {
            StartCoroutine(PlayVoice());

        }
    }

    private IEnumerator PlayVoice()
    {
        yield return new WaitForSeconds(2f);
        FindObjectOfType<AudioManager>().Play("Sunny_Gasp");
    }

}
