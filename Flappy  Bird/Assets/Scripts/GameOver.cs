using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public AudioClip[] sounds;
    public GameObject canvas;
  
    
    public void Gameover()
    {
        canvas.SetActive(true);
        Time.timeScale = 0;


    }
}
