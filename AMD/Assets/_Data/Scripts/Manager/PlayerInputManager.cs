using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public static PlayerInputManager Instance;

    //inputs
    private const string PRESS_CLICK = "Click";

    private Player playerInput;

    public bool isInputAllowed = true;
<<<<<<< HEAD

    public static float numLongPresTime;

=======
>>>>>>> daf93d0a94171f55369b8b69781508481559ee78
    public bool IsInputAllowed
    {
        set
        {
            isInputAllowed = value;
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        playerInput = ReInput.players.GetPlayer(0);
        numLongPresTime = playerInput.controllers.maps.GetInputBehavior(0).buttonLongPressTime;
    }
    public bool IsClickSpace()
    {
        if (!isInputAllowed)
        {
            return false;
        }
        return playerInput.GetButton(PRESS_CLICK);
    }

    public bool IsClickSpacePressedUp()
    {
        if (!isInputAllowed)
        {
            return false;
        }

        //Debug.Log("Input? " + playerInput.GetButtonDown(PRESS_SPACE));
        return playerInput.GetButtonUp(PRESS_CLICK);
    }

    public bool IsClickMousePressedUp()
    {
        if (!isInputAllowed)
        {
            return false;
        }
        return playerInput.GetButtonUp(PRESS_CLICK);
    }

    public bool IsClickSpaceLongPressed()
    {
        if (!isInputAllowed)
        {
            return false;
        }
        return playerInput.GetButtonLongPress(PRESS_CLICK);
    }

    public bool IsClickSpaceUp()
    {
        if (!isInputAllowed)
        {
            return false;
        }
        return playerInput.GetButtonUp(PRESS_CLICK);
    }


    public bool IsClickMouseLongPressed()
    {
        if (!isInputAllowed)
        {
            return false;
        }
        return playerInput.GetButtonLongPress(PRESS_CLICK);
    }

<<<<<<< HEAD
=======
    public double GetTimePressed()
    {
        return playerInput.GetButtonTimePressed(PRESS_CLICK);

    }
>>>>>>> daf93d0a94171f55369b8b69781508481559ee78

    public void ResetIsInputAllowed()
    {
        StartCoroutine(ResetAllowedInput());
    }

    IEnumerator ResetAllowedInput()
    {
        yield return new WaitForSeconds(0.3f);
        isInputAllowed = true;
    }

}
