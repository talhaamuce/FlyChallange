using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuKontrol : MonoBehaviour
{
    GameObject obje;
    public GameObject sesAc;
    public GameObject sesKapat;
    public GameObject buttonOyna;
    public GameObject buttonCikis;

    Vector2 cam;

    void Start()
    {
        PlayerPrefs.SetInt("run", 1);

        var topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));


        sesAc.transform.position = new Vector2(topRight.x - 3, topRight.y - 3);
        sesKapat.transform.position = new Vector2(topRight.x - 3, topRight.y - 3);

        if (PlayerPrefs.GetInt("Ses") == 0)
        {
            sesAc.SetActive(true);
            sesKapat.SetActive(false);
            GameObject.FindGameObjectWithTag("arkaPlanSes").GetComponent<AudioSource>().enabled = true;
        }
        else
        {
            sesAc.SetActive(false);
            sesKapat.SetActive(true);
            GameObject.FindGameObjectWithTag("arkaPlanSes").GetComponent<AudioSource>().enabled = false;
        }

    }
    public void sesAcKapa()
    {
        if (PlayerPrefs.GetInt("Ses") == 0)
        {
            sesAc.SetActive(false);
            sesKapat.SetActive(true);
            PlayerPrefs.SetInt("Ses", 1);
            GameObject.FindGameObjectWithTag("arkaPlanSes").GetComponent<AudioSource>().enabled = false;
        }
        else
        {
            sesAc.SetActive(true);
            sesKapat.SetActive(false);
            PlayerPrefs.SetInt("Ses", 0);
            GameObject.FindGameObjectWithTag("arkaPlanSes").GetComponent<AudioSource>().enabled = true;

        }

    }

    public void basla()
    {
        PlayerPrefs.SetInt("run", 1);
        SceneManager.LoadScene("level1");
    }

    public void cıkıs()
    {
        Application.Quit();
    }


}
