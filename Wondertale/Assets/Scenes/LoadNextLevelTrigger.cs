using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevelTrigger : MonoBehaviour
{
    [SerializeField] int currentLevelIndex;

    private void Awake()
    {
        currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadNextLevel()
    {
        currentLevelIndex += 1;
        SceneManager.LoadScene(currentLevelIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")

        {
            LoadNextLevel();
        }
    }
}
