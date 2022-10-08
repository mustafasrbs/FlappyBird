using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreController : MonoBehaviour
{
    public Text highSkor;
    public Text gameSkor;
    private int skor;
    public int highScore;
    public AudioClip[] sounds;
    public void scoreControll()
    {
        //collision1.gameObject.transform.root.gameObject.GetComponent<Place>().isTrigger = true;
        skor++;
        gameSkor.text = skor.ToString();
        if (skor >= highScore)
        {
            highScore = skor;
        }
        //highSkor.text = "High Score " + highScore.ToString();
        

    }
   
}
