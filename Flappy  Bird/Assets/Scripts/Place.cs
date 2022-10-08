using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place : MonoBehaviour
{
    public bool isTrigger;
    public GameObject pipe;
    //public AudioClip[] sounds;


    void Start()
    {
        isTrigger = false;
        Time.timeScale = 1;
    }


    void Update()
    {
        if (isTrigger)
        {
            Invoke("Uret", 8f);
            isTrigger = false;

        }

    }
    void Uret()
    {
        transform.position = transform.position + new Vector3(16, 0, 0);
        //en az 0.99  en fazla 2.80
        float rnd = Random.Range(1.1f, 2.65f);
        pipe.transform.localPosition = new Vector3(1.7f, rnd, -3);

    }

}


