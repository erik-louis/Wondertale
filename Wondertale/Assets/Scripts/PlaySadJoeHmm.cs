using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySadJoeHmm : MonoBehaviour
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
        FindObjectOfType<AudioManager>().Play("SadJoe_Hmm");
    }

}
