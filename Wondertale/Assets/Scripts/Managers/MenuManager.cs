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

    public void OpenFacebookURL()
    {
        Application.OpenURL("https://www.facebook.com/WondertaleProductions/");
    }

    public void OpenTwitterURL()
    {
        Application.OpenURL("https://twitter.com/wondertaleprod?s=21&t=96CxXNjPhrWW5IhpYo7XvA");
    }

    public void OpenTiktokURL()
    {
        Application.OpenURL("https://www.tiktok.com/@wondertaleproductions?_d=secCgYIASAHKAESPgo8Ie5mBWavL7xcSJeLV6EjLJLTdkbcAS%2F4eYh0sKDDtNJimV8JPbSA2zfiHaQyjfYRX1Ao74goEzUk4ojBGgA%3D&_r=1&checksum=c974d4a5425bf203725a284c127a81c860a5123e39acefb629c29bd0689b9312&language=en&sec_uid=MS4wLjABAAAAB8z0KmA6nFjrPW4DY5rGr0JBJ-XJsdDY1ZRaRjre2yCxjI5m3zT9I0rg1uftSjai&sec_user_id=MS4wLjABAAAAhUpSrr9EZvHgfn2MQVS4DDKNmYYUWTybojKHMGji_1TxZIvlb394Zl-qf2LmOWDt&share_app_id=1233&share_author_id=7114676686536655877&share_link_id=E61F7286-A3BD-4A27-B916-8DD735A9F765&source=h5_m&timestamp=1656927024&tt_from=copy&u_code=d3ad5ejhcc0k6g&ug_btm=b6880%2Cb5836&user_id=6628293390101053446&utm_campaign=client_share&utm_medium=ios&utm_source=copy");
    }
}
