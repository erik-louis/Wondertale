using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI speakerName, dialogue, navButtonText;
    public Image speakerSpriteLeft;
    public Image speakerSpriteRight;

    private int currentIndex;
    private Conversation currentConvo;
    private static DialogueManager instance;

    private void Awake()
    {
        //make sure that only one DialogueManager is active in the scene
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // call DialogueManager from anywhere within the game
    public static void StartConversation(Conversation convo)
    {
        instance.currentIndex = 0;
        instance.currentConvo = convo;
        instance.speakerName.text = "";
        instance.dialogue.text = "";
        instance.navButtonText.text = ">";

        instance.ReadNext();
    }

    public void ReadNext()
    {
        speakerName.text = currentConvo.GetLineByIndex(currentIndex).speakerLeft.GetName();
        speakerName.text = currentConvo.GetLineByIndex(currentIndex).speakerRight.GetName();
        dialogue.text = currentConvo.GetLineByIndex(currentIndex).dialogue;
        speakerSpriteLeft.sprite = currentConvo.GetLineByIndex(currentIndex).speakerLeft.GetSprite();
        speakerSpriteRight.sprite = currentConvo.GetLineByIndex(currentIndex).speakerRight.GetSprite();
        currentIndex++;
    }
}
