using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI speakerName, dialogue, navButtonText;
    public Image speakerSprite;
    public GameObject speakerSpriteObject;

    private int currentIndex;
    private Conversation currentConvo;
    private static DialogueManager instance;
    private Animator anim;
    private Coroutine typing;
    

    private void Awake()
    {
        
        //make sure that only one DialogueManager is active in the scene
        if (instance == null)
        {
            instance = this;
            anim = GetComponent<Animator>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // call DialogueManager from anywhere within the game
    public static void StartConversation(Conversation convo)
    {
        PlayerController.playerControlsEnabled = false;
        instance.anim.SetBool("isOpen", true);
        instance.currentIndex = 0;
        instance.currentConvo = convo;
        instance.speakerName.text = "";
        instance.dialogue.text = "";
        instance.navButtonText.text = ">";

        instance.ReadNext();
    }

    public void ReadNext()
    {
        // After last dialogue line, close Box and enable Player Controls
        if (currentIndex > currentConvo.GetLength())
        {
            instance.anim.SetBool("isOpen", false);
            StartCoroutine(EnableMovement());
            return;
        }

        speakerName.text = currentConvo.GetLineByIndex(currentIndex).speaker.GetName();

        if (typing == null)
        {
            typing = instance.StartCoroutine(TypeText(currentConvo.GetLineByIndex(currentIndex).dialogue));
        }
        else
        {
            instance.StopCoroutine(typing);
            typing = null;
            typing = instance.StartCoroutine(TypeText(currentConvo.GetLineByIndex(currentIndex).dialogue));
        }

        speakerSprite.sprite = currentConvo.GetLineByIndex(currentIndex).speaker.GetSprite();
        currentIndex++;

        // Move Sprite of Characters except of Zuzu to the right side
        if (speakerName.text == "Director")
        {
            
            speakerSpriteObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(640, 151, 0);
        }
        else
        {
            speakerSpriteObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-709, 151, 0);
        }
        

        // Change Symbol of NavButton after last Dialogue
        if (currentIndex >= currentConvo.GetLength() + 1)
        {
            navButtonText.text = "X";
        }
    }

    // Text is being typed into the box
    private IEnumerator TypeText(string text)
    {
        dialogue.text = "";
        bool complete = false;
        int index = 0;

        while (!complete)
        {
            dialogue.text += text[index];
            index++;
            yield return new WaitForSeconds(0.02f);

            if (index == text.Length)
            {
                complete = true;
            }
        }

        typing = null;
    }

    private IEnumerator EnableMovement()
    {
        yield return new WaitForSeconds(0.02f);
        PlayerController.playerControlsEnabled = true;
    }


}
