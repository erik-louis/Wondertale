using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoManager : MonoBehaviour
{
    [SerializeField] int currentLevelIndex;
    private bool loadingStarted = false;
    private float secondsLeft = 0;
    public float timer;

    private void Awake()
    {
        currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        
    }
    void Start()
    {
        StartCoroutine(DelayLoadLevel(timer));
    }

    IEnumerator DelayLoadLevel(float seconds)
    {
        secondsLeft = seconds;
        loadingStarted = true;

        do
        {
            yield return new WaitForSeconds(1);
        } 
        while (--secondsLeft > 0);

        

        if (currentLevelIndex == 11)
        {
            SceneManager.LoadScene("Main Menu");
            
        }

        else
        {
            SceneManager.LoadScene(currentLevelIndex += 1);
            
        }
        
    }

    // show Timer on top left of Screen
    /*void OnGUI()
    {
        if (loadingStarted)
            GUI.Label(new Rect(0, 0, 100, 20), secondsLeft.ToString());
    }
    */
    
}
