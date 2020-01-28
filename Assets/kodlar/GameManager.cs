using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public cerceve kenarlik;
    public virusHareket virus;
    public static Vector2 bottomleft;
    public static Vector2 topRight;
    public int AsiHakki = 20;
    public List<GameObject> arkaplan;
    [SerializeField]
    public GameObject oyunKazandin;
    public Text levelText;




    void Start()
    {


        if (PlayerPrefs.GetInt("Level") == 0)
            PlayerPrefs.SetInt("Level", 1);

        bottomleft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));

        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));


        cerceveOlustur("sagSol", new Vector2(1f, bottomleft.y * 5), new Vector2(topRight.x + 0.5f, 0)); // sağ
        cerceveOlustur("sagSol", new Vector2(1, bottomleft.y * 5), new Vector2(bottomleft.x - 0.5f, 0)); // sol
        cerceveOlustur("yukariAsagi", new Vector2(topRight.x * 5, 1), new Vector2(0, bottomleft.y - 0.5f)); // asağı
        cerceveOlustur("yukariAsagi", new Vector2(topRight.x * 5, 1), new Vector2(0, topRight.y + 0.6f)); //yukarı

        var arkaPlanRnd = Random.Range(0, 4);
 

        arkaplan[arkaPlanRnd].transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y);
        arkaplan[arkaPlanRnd].transform.localScale = new Vector3(topRight.x / 4 - 0.05f, topRight.y / 2);
        arkaplan[arkaPlanRnd].GetComponent<SpriteRenderer>().sortingOrder = -1;

        Instantiate(arkaplan[arkaPlanRnd]);


        for (int i = 0; i < PlayerPrefs.GetInt("Level"); i++)
        {

            float x = Random.Range(bottomleft.x, topRight.x);
            float y = Random.Range(bottomleft.y, topRight.y);

            Instantiate(virus, new Vector2(x, y), Quaternion.identity);
            //obje.transform.localScale = new Vector3(Random.Range(4, 6) / 10f, Random.Range(5, 7) / 10f);

        }
    }
    void cerceveOlustur(string name, Vector2 boy, Vector2 pos)
    {
        cerceve cerceve = Instantiate(kenarlik) as cerceve;
        cerceve.name = name;
        cerceve.transform.position = pos;
        cerceve.transform.localScale = boy;
    }

    void Update()
    {

    }
}

