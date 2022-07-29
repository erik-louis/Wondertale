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
        FindObjectOfType<AudioManager>().StopPlaying("Hospital");
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

        SceneManager.LoadScene(currentLevelIndex +=1);
    }

    void OnGUI()
    {
        if (loadingStarted)
            GUI.Label(new Rect(0, 0, 100, 20), secondsLeft.ToString());
    }
    
    
}
