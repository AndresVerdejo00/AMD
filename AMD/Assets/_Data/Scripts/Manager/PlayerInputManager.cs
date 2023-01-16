using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public static PlayerInputManager Instance;

    //inputs
    private const string PRESS_SPACE = "Click";
    private const string PRESS_MOUSE = "Click";

    private Player playerInput;

    private bool isInputAllowed = true;
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
    }

    public bool IsClickSpacePressed()
    {
        if (!isInputAllowed)
        {
            return false;
        }
        return playerInput.GetButtonDown(PRESS_SPACE);
    }

    public bool IsClickMousePressed()
    {
        if (!isInputAllowed)
        {
            return false;
        }
        return playerInput.GetButtonDown(PRESS_MOUSE);
    }

    public bool IsClickSpaceLongPressed()
    {
        if (!isInputAllowed)
        {
            return false;
        }
        return playerInput.GetButtonLongPress(PRESS_SPACE);
    }

    public bool IsClickMouseLongPressed()
    {
        if (!isInputAllowed)
        {
            return false;
        }
        return playerInput.GetButtonLongPress(PRESS_MOUSE);
    }

}
