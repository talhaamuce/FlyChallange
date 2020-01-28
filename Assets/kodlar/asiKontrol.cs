using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class asiKontrol : MonoBehaviour
{
    public bool ciziliyor = false;
    public GameObject asi;
    public float buyutme = 0;
    public GameObject obje;
    GameObject gameManeger;
    public bool ciz;
    AudioSource[] ses;
    public Text gazText;
    [SerializeField]
    public GameObject oyunKaybettin;
    public Text levelText;





    void Start()
    {
        gameManeger = GameObject.FindGameObjectWithTag("gameManager");
        ses = GetComponents<AudioSource>();
        ciz = true;
    }


    void Update()
    {
        var topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));


        gazText.transform.position = new Vector2(topRight.x - 1, topRight.y - 1.5f);

        gazText.text = "GAZ=" + gameManeger.GetComponent<GameManager>().AsiHakki.ToString();
        if (Input.GetMouseButton(0) && ciz && gameManeger.GetComponent<GameManager>().AsiHakki > 0)
        {
            Vector2 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);


            if (!ciziliyor)
            {

                gameManeger.GetComponent<GameManager>().AsiHakki--;

                ses[0].Play();

                ciziliyor = true;


                obje = Instantiate(asi, vec, Quaternion.identity);
                obje.name = "sil";




                if (gameManeger.GetComponent<GameManager>().AsiHakki <= 0)
                {
                    if (PlayerPrefs.GetInt("run") == 1)
                    {
                        if (PlayerPrefs.GetInt("Level") >= 3)
                        {
                            GameObject.FindGameObjectWithTag("reklam").GetComponent<reklam>().reklamiGetir();
                        }
                        if (PlayerPrefs.GetInt("Level") > 1)
                        {
                            // GameObject.FindGameObjectWithTag("reklam").GetComponent<reklam>().reklamiGetir();
                            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") - 1);

                        }

                        levelText.text = "LEVEL " + PlayerPrefs.GetInt("Level").ToString();
                        //SceneManager.LoadScene("levelGecis");

                        oyunKaybettin.SetActive(true);
                        PlayerPrefs.SetInt("run", 0);
                    }

                }


                //if (GameObject.FindGameObjectsWithTag("virus").Length == 0)
                //{

                //    PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);


                //    Debug.Log(PlayerPrefs.GetInt("Level"));


                //    if (PlayerPrefs.GetInt("Level") % 2 == 0)
                //    {
                //        //  GameObject.FindGameObjectWithTag("reklam").GetComponent<reklam>().reklamiGetir();
                //        Debug.Log("reklam gösterildi");

                //    }
                //    oyunKazandın.SetActive(true);

                //}



            }
            else if (ciziliyor && obje != null)
            {
                //Debug.Log("büyütüyor");
                buyutme = buyutme + 0.01f;

                obje.transform.position = vec;
                obje.transform.localScale = new Vector3(buyutme, buyutme);


            }


            //obje.transform.localScale = new Vector3(Random.Range(4, 6) / 10f, Random.Range(5, 7) / 10f);
        }
        else
        {

            if (obje != null)
                obje.name = "silme";


            ciziliyor = false;
            ses[0].Stop();
            buyutme = 0;


            if (Input.GetMouseButtonUp(0))
                ciz = true;

        }


    }

    void sahne()
    {

    }









}

