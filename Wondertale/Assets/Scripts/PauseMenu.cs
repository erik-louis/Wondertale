using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    // Buttons which are first selected
    [SerializeField] GameObject pauseOpenFirstSelected;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("Cancel"))
        {
            ClosePause();
        }
    }

    public void ClosePause()
    {
        
        pauseMenu.SetActive(false);
        
    }
}
