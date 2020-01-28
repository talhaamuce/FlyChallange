using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arkaPlananime : MonoBehaviour
{
    void Start()
    {
        

        //var bottomleft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        var topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width - (Screen.width * 0.05f), Screen.height));

        transform.position = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);
        transform.localScale = new Vector2(topRight.x / 4 - 0.05f, topRight.y / 2);

    }

   
}
