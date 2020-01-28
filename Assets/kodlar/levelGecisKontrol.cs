using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class levelGecisKontrol : MonoBehaviour
{

    public void cıkıs()
    {
        Application.Quit();
    }

    public void basla()
    {
        PlayerPrefs.SetInt("run", 1);
        SceneManager.LoadScene("level1");

    }
}
