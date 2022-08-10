using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevelTrigger : MonoBehaviour
{
    [SerializeField] int currentLevelIndex;
    [SerializeField] Animator transition;
    public float loadingTime = 1f;

    private void Awake()
    {
        currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadNextLevel()
    {
        currentLevelIndex += 1;
        StartCoroutine(LoadScene(currentLevelIndex));
    }

    public void LoadCredits()
    {
        StartCoroutine(Credits());
    }

    public void LoadMainMenu()
    {
        StartCoroutine(MainMenu());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")

        {
            if (currentLevelIndex == 12)
            {
                StartCoroutine(Thankyou());
                Debug.Log("Load Thank You");
            }

            else
            {
                LoadNextLevel();
            }
            

        }

        
    }

    IEnumerator LoadScene(int currentLevelIndex)
    {
        transition.SetTrigger("StartFade");

        yield return new WaitForSeconds(loadingTime);

        SceneManager.LoadScene(currentLevelIndex);

    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit");
    }

    IEnumerator Credits()
    {
        transition.SetTrigger("StartFade");

        yield return new WaitForSeconds(loadingTime);

        SceneManager.LoadScene("Credits");

    }

    IEnumerator MainMenu()
    {
        transition.SetTrigger("StartFade");

        yield return new WaitForSeconds(loadingTime);

        SceneManager.LoadScene("Main Menu");

    }

    IEnumerator Thankyou()
    {
        transition.SetTrigger("StartFade");

        yield return new WaitForSeconds(loadingTime);

        SceneManager.LoadScene("Thank You");

    }
}
