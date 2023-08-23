using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dropdown : MonoBehaviour
{
    public TextMeshProUGUI output;
    public Button NewGame;

    public void HandleInputData(int val)
    {
        if (val == 0)
        {
            NewGame.interactable = false;
            output.text = "Age";
        }
        if (val == 1)
        {
            NewGame.interactable = true;
            output.text = "This game is suitable for you";
        }
        if (val == 2)
        {
            NewGame.interactable = true;
            output.text = "Getting too old for the game";
        }
        if (val == 3)
        {
            NewGame.interactable = false;
            output.text = "You are too old to play this game";
        }
    }
}
