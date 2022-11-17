using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGM : MonoBehaviour
{
    public SimpleInput input;
    public PlayerManager pManager;


    public static SimpleGM instance;

    private void Awake()
    {
        instance = this;
        Cursor.lockState =  CursorLockMode.Locked;
    }

    public void GameOver()
    {
        //Literally just a game over state;
        //Use it to reset the game/level
    }
}
