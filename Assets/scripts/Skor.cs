using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skor : MonoBehaviour
{
    private float skor = 0f;
    private int levelzorlugu = 1;
    private int maxlevel = 10;
    private int skorsonrakilevel = 10;
    public Text Skortext;
    public Text lwtext;
    private bool İsDead = false;
    public olummenu ölümmenü;

    void Start()
    {

        lwtext.text = "Hız:" + levelzorlugu.ToString();
    }

    private void Update()
    {
        if (İsDead)
        {
            return;
        }
        if (skor >= skorsonrakilevel)
        {
            SonrakiLevel();
        }

        skor += Time.deltaTime *levelzorlugu;
        Skortext.text = "Skor:" + ((int)skor).ToString();
        
    }
    private void SonrakiLevel()
    {
        if (levelzorlugu==maxlevel*Time.deltaTime )
            return;
 
        skorsonrakilevel *= 2;
        levelzorlugu++;

        GetComponent<KarakterHareket>().GeçerliHiz(levelzorlugu);
        lwtext.text = "Hız:" + levelzorlugu.ToString();
    }
    public void OnDeath()
    {
        İsDead = true;
        if (PlayerPrefs.GetFloat("enskor")<skor)
        {
            PlayerPrefs.SetFloat("enskor", skor);
        }
        ölümmenü.ToggleEndMenu(skor);
        gameObject.SetActive(true);
    }
}
