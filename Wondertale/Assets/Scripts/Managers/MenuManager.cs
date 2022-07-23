using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu, optionsMenu;

    // Buttons which are first selected
    [SerializeField] GameObject mainMenuFirstSelected, optionsOpenFirstSelected, optionsCloseFirstSelected;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("Cancel"))
        {
            CloseOptions();
        }
    }

    public void OpenOptions()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);

        // clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        // set a new selcted object
        EventSystem.current.SetSelectedGameObject(optionsOpenFirstSelected);
    }

    public void CloseOptions()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);

        // clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        // set a new selcted object
        EventSystem.current.SetSelectedGameObject(optionsCloseFirstSelected);
    }
}
