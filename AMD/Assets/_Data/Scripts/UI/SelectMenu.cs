using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject redBoxStart, redBoxInfo, redBoxExit;

    private int selected;

    private void Start()
    {
        redBoxInfo.SetActive(false);
        redBoxExit.SetActive(false);
        selected = 1;
    }

    private void Update()
    {
        if(Input.GetKeyUp("space"))
        {
            ChangeMenuSelected();
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
