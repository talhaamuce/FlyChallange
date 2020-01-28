using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asiCapma : MonoBehaviour
{
    GameObject asikontrol;
    public bool durdur;
  
    void Start()
    {
        durdur = false;
        asikontrol = GameObject.FindGameObjectWithTag("asii");
    }
    void OnMouseDown()
    {
       
        asikontrol.GetComponent<asiKontrol>().ciz = false;
        

    }
    void OnMouseUp()
    {
       
        asikontrol.GetComponent<asiKontrol>().ciz = true;
    }
    void Update()
    {
        //if (asikontrol.GetComponent<asiKontrol>().ciziliyor && asikontrol.GetComponent<asiKontrol>().obje !=null)
        //{
        //    animaasyon();
        //}
       
    }

    

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "virus" && (asikontrol.GetComponent<asiKontrol>().ciziliyor) && this.name == "sil")
        {
            Destroy(asikontrol.GetComponent<asiKontrol>().obje);

        }
        if (asikontrol.GetComponent<asiKontrol>().ciziliyor && this.name == "sil" && (col.name == "silme" || col.tag == "kenarlik"))
        {
            asikontrol.GetComponent<asiKontrol>().ciziliyor = false;
            asikontrol.GetComponent<asiKontrol>().ciz = asikontrol.GetComponent<asiKontrol>().ciziliyor;
        }


    }


}
