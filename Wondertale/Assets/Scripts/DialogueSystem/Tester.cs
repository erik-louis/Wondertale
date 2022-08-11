using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public Conversation convo;
    
    
    public void StartConvo()
    {
        DialogueManager.StartConversation(convo);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")

        {
            StartConvo();
            StartCoroutine(Destroy());

        }

    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
