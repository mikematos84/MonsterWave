﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDialogue : MonoBehaviour {

    public int MonsterRole = 0;

    private int totalRoles = 4;

    private string MonsterGreeting;
    private string MonsterConfused;
    private string MonsterSkeptical;
    private string MonsterAngry;
    private string MonsterHappy;

    private TextMesh monsterText;

    private string tempText = "";
    private int waitCount = 0;
    private int maxWait = 1;
    public float revealTimer = 3.0f;

    public string[] status = new string[] { "greeting", "confused", "skeptical", "angry", "happy" };

    private string[] greetingOptions = new string[] {"I'm Bob! \nI love making friends!", "Hiya, I'm Yolanda! \nDo you know what time it is?", "Ronald wants to throw you\n a surprise birthday party!", "Aloha! I'm Penelope, \nand I wrote you a song!"};
    private string[] confusedOptions = new string[] {"Do you think we \ncould be friends?", "It's hug time!\n Wanna hug?", "Ronald doesn't understand \nwhy you aren't surprised.", "Do you want to hear \nthe song I wrote?"};
    private string[] skepticalOptions = new string[] { "So...then...\nare we not friends??", "How...come...you...\ndon't wanna hug??", "What...do...you...mean...\nit's not your birthday??", "Did...you...just...say...\nyou don't like songs??" };
    private string[] angryOptions = new string[] {"I WAS GOING TO MAKE US \nFRIENDSHIP BRACELETS!!!", "HUGS ARE SCIENTIFICALLY \nPROVEN TO CALM THE SOUL!!!", "BUT RONALD GOT YOU A PRESENT \nAND EVERYTHING!!!", "BUT I DIDN'T EVEN \nGET TO THE CHORUS!!!"};
    private string[] happyOptions = new string[] {"Yay! Friends for life!", "Awesome! Let's hug \nwith our minds!", "Ronald can't wait \nto bring out the cake!", "Song time! And-a-one, \nand-a-two..."};

    // Use this for initialization
    void Start () {

         monsterText = GetComponent<TextMesh>();

        //to be replaced when specific characters play specific roles.
       // if (MonsterRole == 0)
       // {
            MonsterRole = Random.Range(1, totalRoles);
       // }

        MonsterGreeting = greetingOptions[MonsterRole-1];
        MonsterConfused = confusedOptions[MonsterRole-1];
        MonsterSkeptical = skepticalOptions[MonsterRole - 1];
        MonsterAngry = angryOptions[MonsterRole-1];
        MonsterHappy = happyOptions[MonsterRole-1];

	}

    void Update ()
    {
        if(revealTimer >= 0.0f)
        {

            revealTimer -= Time.deltaTime;

            if(revealTimer <= 0.0f)
            {

                SetDialogue("greeting");

            }

        }


        if (tempText != "")
        {
            if (waitCount == 0)
            {
                monsterText.text += tempText.Substring(0, 1);
                tempText = tempText.Substring(1, tempText.Length - 1);
                waitCount++;
            }
            else if (waitCount == maxWait)
            {
                waitCount = 0;

            }
            else
            {

                waitCount++;

            }
        }

    }

    public void SetDialogue (string monsterStatus)
    {
        switch(monsterStatus)
        {
            case "greeting":
                tempText = MonsterGreeting;
                break;
            case "confused":
            case "0":
                tempText = MonsterConfused;
                break;
            case "skeptical":
            case "1":
                tempText = MonsterSkeptical;
                break;
            case "angry":
            case "2":
                tempText = MonsterAngry;
                break;
            case "happy":
                tempText = MonsterHappy;
                break;
        }

        monsterText.text = "";

    }
	
}
