using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedManager : MonoBehaviour
{

    private bool isPaused;
    public GameObject pausePanel;
    public string mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Calling ChangePaused()
        if (Input.GetButtonDown("pause"))
        {
            ChangePause();
        }
    }

    public void ChangePause()
    {
        //If paused button is pressed
        isPaused = !isPaused;
        if(isPaused)
            {
                pausePanel.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                pausePanel.SetActive(false);
                Time.timeScale = 1f;
            }
    }

    //Quit to main button
    public void QuitToMain()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
