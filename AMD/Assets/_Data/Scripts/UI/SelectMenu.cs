using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject redBoxStart, redBoxInfo, redBoxExit;
    [SerializeField]
    private int numScene;//scene to go
    [SerializeField]
    private GameObject panelMain;//main panel with the tittle and buttons
    [SerializeField]
    private GameObject panelInfo;//panel from menu info


    private int selected;//option to manage switch
    private bool canBackToLobby = false;
    private bool isMain = true;//SE TIENE QUE COMPROBAR PARA CAMBIAR EL SELECTED, SOLO SE CAMBIA EN EL MAINPANEL

    private void Start()
    {
        redBoxInfo.SetActive(false);
        redBoxExit.SetActive(false);
        selected = 1;
    }

    private void Update()
    {
        if (PlayerInputManager.Instance.IsClickSpacePressed() && isMain)
        {
            ChangeMenuSelected();
        }


        if(PlayerInputManager.Instance.IsClickSpaceLongPressed())
        {
            if(selected == 1)
            {
                SceneManager.LoadScene(numScene);
                isMain = false;
            }

            if(selected == 2 && canBackToLobby)
            {
                canBackToLobby = false;
                //active panels
                panelMain.SetActive(!panelMain.activeInHierarchy);
                panelInfo.SetActive(!panelInfo.activeInHierarchy);
                isMain = false;
            }

            if(selected == 3)
            {
                Application.Quit();
                isMain = false;
            }
        }

        if (PlayerInputManager.Instance.IsClickSpaceUp())
        {
            canBackToLobby = true;
            isMain = true;
        }

    }

    private void ChangeMenuSelected()
    {
        switch (selected)
        {
            case 1:
                redBoxStart.SetActive(false);
                redBoxInfo.SetActive(true);

                selected = 2;
                break;
            case 2:
                redBoxInfo.SetActive(false);
                redBoxExit.SetActive(true);

                selected = 3;
                break;
            case 3:
                redBoxExit.SetActive(false);
                redBoxStart.SetActive(true);

                selected = 1;
                break;
                
            default:
                print("menu not detected");
                break;
        }


    }

}
