using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    float JumpPower = 150;
    float speed = 1;
    public GameObject skorText;
    public AudioClip[] sounds;
    public GameObject canvas;
    public Text highSkor;
    public Text gameSkor;
    private int skor;
    public int highScore;
    public GameObject gameover;
    public GameObject skorbord;

    void Start()
    {
        canvas.SetActive(false);
        skor = 0;
        highScore = PlayerPrefs.GetInt("hscore");
    }


    void Update()
    {
        // android controller
        for (var i= 0;i  < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase==TouchPhase.Began)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * JumpPower);
                
            }
        }


        // pc controller
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * JumpPower);
            


        }
        if (skor == 0)
        {
            highSkor.text = "High Score " + highScore.ToString();
        }
        


        //highSkor.text = "High Score " + highScore.ToString();
        //gameSkor.text = skor.ToString();
        //if (skor > highScore)
        //{
        //    highScore = skor;
        //}


    }
    public void OnTriggerExit2D(Collider2D collision1)
    {
        if (collision1.gameObject.tag == "Trigger")
        {
            collision1.gameObject.transform.root.gameObject.GetComponent<Place>().isTrigger = true;
            skorbord.GetComponent<scoreController>().scoreControll();
            GetComponent<AudioSource>().PlayOneShot(sounds[1], 1);


            if (skorbord.GetComponent<scoreController>().highScore > highScore)
            {
                highScore = skorbord.GetComponent<scoreController>().highScore;
            }
            highSkor.text = "High Score " + highScore.ToString();

            
        }

    }
    //private void OnTriggerExit2D(Collider2D collision1)
    //{
    //    if (collision1.gameObject.tag == "Trigger")
    //    {
    //        collision1.gameObject.transform.root.gameObject.GetComponent<Place>().isTrigger = true;
    //        skor++;
    //        highSkor.text = "High Score " + highScore.ToString();
    //        gameSkor.text = skor.ToString();
    //        if (skor > highScore)
    //        {
    //            highScore = skor;
    //        }
    //        GetComponent<AudioSource>().PlayOneShot(sounds[1], 1);

    //    }

    //}
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Carpisma")
        {

            gameover.GetComponent<GameOver>().Gameover();
            GetComponent<AudioSource>().PlayOneShot(sounds[2], 1);
        }

    }

    //public void GameOver()
    //{
    //    Time.timeScale = 0;
    //    GetComponent<AudioSource>().PlayOneShot(sounds[2], 1);

    //}
    public void PlayAgain()
    {
        Application.LoadLevel("SampleScene");
    }
    public void OnDestroy()
    {
        PlayerPrefs.SetInt("hscore", highScore);
    }
    public void birdSpeed()
    {
        if (skor >= 5)
        {
            speed = 2f;
        }

    }
}
