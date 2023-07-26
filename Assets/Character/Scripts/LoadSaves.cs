using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSaves : MonoBehaviour
{
    public void LoadOne()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadTwo()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadThree()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Back()
    {
        SceneManager.LoadScene("StartMenu");
    }
}