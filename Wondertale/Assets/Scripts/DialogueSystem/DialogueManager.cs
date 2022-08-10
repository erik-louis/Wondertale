using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] int currentLevelIndex;

    public TextMeshProUGUI speakerName, dialogue, navButtonText;
    public Image speakerSprite;
    public GameObject speakerSpriteObject;

    private int currentIndex;
    private Conversation currentConvo;
    private static DialogueManager instance;
    private Animator anim;
    private Coroutine typing;

    [SerializeField] GameObject giveBottleQuestionPanel;
    [SerializeField] Conversation sadJoeHappyConvo;
    [SerializeField] Conversation sadJoeAngryConvo;

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
            // Load next Scene after Intro Dialogue Scene and last Dialogue of Game
            if (speakerName.text == "Doctor" || speakerName.text == "Sunny")
            {
                PlayerController.playerControlsEnabled = true;
                currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentLevelIndex += 1);
                return;
            }

            // Open Question Panel after Dialogue with SadJoe
            if (currentConvo.name == "SadJoe_Bottle")
            {
                instance.anim.SetBool("isOpen", false);
                giveBottleQuestionPanel.SetActive(true);
                EventSystem.current.SetSelectedGameObject(GameObject.Find("Yes"));
                PlayerController.playerControlsEnabled = false;
                return;
            }

            // Open SadJoe Helps Zuzu Cutscene after SadJoe Happy Convo
            if (currentConvo.name == "SadJoe_Help_Zuzu")
            {
                SceneManager.LoadScene("");
            }


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
        if (speakerName.text == "Monsieur Caligari" || speakerName.text == "Sad Joe" || speakerName.text == "Sunny")
        {
            speakerSpriteObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(525, 151, 0);
        }
        else
        {
            speakerSpriteObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-650, 155, 0);
        }

        

        // Play Dialogue Voices
        /*if (speakerSprite.GetComponent<Image>().sprite.name == "Caligari_Angry")
        {
            StartCoroutine(PlayCaligariAngry());
        }*/
        

        // Change Symbol of NavButton after last Dialogue
        if (currentIndex >= currentConvo.GetLength() + 1)
        {
            navButtonText.text = "X";
        }
    }

    public void SelectYes()
    {
        giveBottleQuestionPanel.SetActive(false);
        EventSystem.current.SetSelectedGameObject(GameObject.Find("NavButton"));
        StartConversation(sadJoeHappyConvo);

    }

    public void SelectNo()
    {
        giveBottleQuestionPanel.SetActive(false);
        EventSystem.current.SetSelectedGameObject(GameObject.Find("NavButton"));
        StartConversation(sadJoeAngryConvo);

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

    /*private IEnumerator PlayCaligariAngry()
    {
        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<AudioManager>().Play("Caligari_Angry");

    }*/


}
