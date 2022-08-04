using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue : MonoBehaviour
{
    public Conversation convo;

    private void Awake()
    {
        DialogueManager.StartConversation(convo);

    }

   
}
