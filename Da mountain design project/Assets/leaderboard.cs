﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class leaderboard : MonoBehaviour
{
    public Timer timer;
    public string[] names;
    public float[] times;

    public static leaderboard instance = null;


    void Awake()
    {

        if (instance == null)

            instance = this;

        else if (instance != this)

            Destroy(gameObject);
       
    }
    // Start is called before the first frame update
   public void OnEnable()
    {
        

        bool playerhaspos = false;
        for (int i = 0; i < names.Length; i++)
        {
            Text namepos =  transform.GetChild(i).GetComponent<Text>();
            Text timetext = namepos.transform.GetChild(0).GetComponent<Text>();
            float currentTime = PlayerPrefs.GetFloat("time");
            if (currentTime < times[i] && playerhaspos == false)
            {
                playerhaspos = true;
                timetext.text = fixtime(currentTime);
                timetext.fontStyle = FontStyle.Bold;
                namepos.text = "YOU";
                namepos.fontStyle = FontStyle.Bold;
            }
            else
            {
                timetext.text = fixtime(times[i]);
                namepos.text = names[i];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    string fixtime(float time)
    {
    string min = ((int)time / 60).ToString();
    string sec = (time % 60).ToString("f0");
    string leaderboardTime =  min + ":" + sec;
        return leaderboardTime;
    }

}
