using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayZuzuGasp : MonoBehaviour
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
        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<AudioManager>().Play("Zuzu_Gasp");
        Debug.Log("Play Gasp");
    }
}
