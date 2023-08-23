using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button Newgame;
    // Start is called before the first frame update
    void Start()
    {
        Newgame.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //New game button
    public void NewGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    //Quit game button
    public void QuitGame()
    {
        Application.Quit();
    }

    //Continue button
    public void Continue()
    {
        SceneManager.LoadScene("LoadSaves");
    }
}
