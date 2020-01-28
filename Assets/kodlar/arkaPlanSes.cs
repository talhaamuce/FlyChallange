using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arkaPlanSes : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

}
