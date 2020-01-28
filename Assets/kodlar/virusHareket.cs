using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class virusHareket : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 hareket;
    float hiz = 4;
    public Sprite[] virus;
    public Sprite[] virussol;
    SpriteRenderer spriteRenderer;
    int virusSayacSag = 0;
    float beklemeanimZaman = 0;
    public GameObject olusinek;
    Vector2 pozisyonOld = new Vector2(0, 0), pozisyonNow;
    int oldurSayac = 0;
    Thread thread;
    float elapsed = 0f;


    void Start()
    {

        hareket = new Vector2(Random.Range(1.3f, -1.3f), Random.Range(1.2f, -1.2f));
        spriteRenderer = GetComponent<SpriteRenderer>();


    }

    private double uzaklikHesapla(Vector2 v1, Vector2 v2)
    {
        return System.Math.Sqrt(System.Math.Pow(v2.x - v1.x, 2) + System.Math.Pow(v2.y - v1.y, 2));
    }

    void Update()
    {
        if (hareket.x > 0)
            animaasyon("sag");
        else
            animaasyon("sol");

        transform.Translate(hareket * hiz * Time.deltaTime);

    }

    void animaasyon(string yon)
    {


        beklemeanimZaman += Time.deltaTime;
        if (beklemeanimZaman > 0.05f)
        {
            if (yon == "sag")
            {
                spriteRenderer.sprite = virus[virusSayacSag++];
                if (virusSayacSag == virus.Length)
                {
                    virusSayacSag = 0;
                }
            }

            else if (yon == "sol")
            {
                spriteRenderer.sprite = virussol[virusSayacSag++];

                if (virusSayacSag == virussol.Length)
                {
                    virusSayacSag = 0;
                }
            }

            beklemeanimZaman = 0;
        }

    }


    void FixedUpdate()
    {
        //Virüs öldürme Kontrolü
        elapsed += Time.deltaTime;
        if (elapsed >= 1f)
        {
            elapsed = elapsed % 1f;


            if (pozisyonOld.x != 0 && pozisyonOld.y != 0)
            {
                double mesafaFarki = uzaklikHesapla(pozisyonOld, this.transform.position);

                //Debug.Log("MesafeFarki: " + mesafaFarki);

                if (mesafaFarki < 0.8f)
                    oldurSayac++;
                else
                    oldurSayac = 0;
            }

            pozisyonOld = new Vector2(this.transform.position.x, this.transform.position.y);


            if (oldurSayac >= 5)
            {
                oldurSayac = 0;
                SinekOldur();
            }
        }
    }

    private void SinekOldur()
    {
        olusinek.transform.position = gameObject.transform.position;

        Instantiate(olusinek);
        Destroy(gameObject);

        if (GameObject.FindGameObjectsWithTag("virus").Length == 1)
        {
            if (PlayerPrefs.GetInt("run") == 1)
            {
                PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
                GameObject.FindGameObjectWithTag("gameManager").GetComponent<GameManager>().oyunKazandin.SetActive(true);
                GameObject.FindGameObjectWithTag("gameManager").GetComponent<GameManager>().levelText.text = "LEVEL " + PlayerPrefs.GetInt("Level").ToString();
                PlayerPrefs.SetInt("run", 0);

            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "virus")
        {

            hareket.y = hareket.y * -1;
            hareket.x = hareket.x * -1;
        }
        if (col.tag == "asi")
        {
            hareket.y = hareket.y * -1;
            hareket.x = hareket.x * -1;
        }
        if (col.name == "sagSol")
        {
            hareket.x = hareket.x * -1;
        }
        if (col.name == "yukariAsagi")
        {
            hareket.y = hareket.y * -1;
        }

    }
}
