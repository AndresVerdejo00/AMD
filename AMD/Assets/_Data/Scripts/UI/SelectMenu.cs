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

    [SerializeField]
    private Image backgroundImageStart;
    [SerializeField]
    private Image backgroundImageInfo;
    [SerializeField]
    private Image backgroundImageExit;
    [SerializeField]
    private Image backgroundImagePanelInfo;


    private int selected;//option to manage switch
    private bool canBackToLobby = false;
    private bool isMain = true;//SE TIENE QUE COMPROBAR PARA CAMBIAR EL SELECTED, SOLO SE CAMBIA EN EL MAINPANEL

    private void Start()
    {
        redBoxInfo.SetActive(false);
        redBoxExit.SetActive(false);
        selected = 1;

        backgroundImageStart.fillAmount = 0;
        backgroundImageInfo.fillAmount = 0;
        backgroundImageExit.fillAmount = 0;
    }

    private void Update()
    {
        //rellenar barra de carga
        if (PlayerInputManager.Instance.IsClickSpace())
        {
            switch(selected)
            {
                case 1:
                    backgroundImageStart.fillAmount += (Time.deltaTime / PlayerInputManager.numLongPresTime);
                    break;
                case 2:
                    backgroundImageInfo.fillAmount += (Time.deltaTime / PlayerInputManager.numLongPresTime);
                    break;
                case 3:
                    backgroundImageExit.fillAmount += (Time.deltaTime / PlayerInputManager.numLongPresTime);
                    break;
                    
            }
        }



        if (PlayerInputManager.Instance.IsClickSpacePressedUp() && isMain)
        {
            ChangeMenuSelected();
            backgroundImageStart.fillAmount = 0;
            backgroundImageInfo.fillAmount = 0;
            backgroundImageExit.fillAmount = 0;
        }


        if(PlayerInputManager.Instance.IsClickSpaceLongPressed())
        {
            if(selected == 1)
            {
                SceneManager.LoadScene(numScene);
                isMain = false;

                backgroundImageStart.fillAmount = 0;
            }

            if(selected == 2 && canBackToLobby)
            {
                canBackToLobby = false;
                //active panels
                panelMain.SetActive(!panelMain.activeInHierarchy);
                panelInfo.SetActive(!panelInfo.activeInHierarchy);
                isMain = false;

                backgroundImageInfo.fillAmount = 0;
            }

            if(selected == 3)
            {
                Application.Quit();
                isMain = false;

                backgroundImageExit.fillAmount = 0;
            }
        }

        if (PlayerInputManager.Instance.IsClickSpacePressedUp())
        {
            canBackToLobby = true;
            backgroundImageStart.fillAmount += (Time.deltaTime / PlayerInputManager.numLongPresTime);
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
