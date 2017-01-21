﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDialogue : MonoBehaviour {

    private string MonsterGreeting;
    private string MonsterConfused;
    private string MonsterAngry;
    private string MonsterHappy;

    private int randomCharacter;
    private int totalCharacters = 3;
    private TextMesh tempText;
    private string currentStatus;
    public string newStatus;

    private string[] greetingOptions = new string[] {"I'm Bob! \nI love making friends!", "Hiya, I'm Yolanda! \nDo you wanna hug?", "Ronald wants to throw you\n a surprise birthday party!", "Hola! I'm Penelope, \nand I wrote you a song!"};
    private string[] confusedOptions = new string[] {"But...but...\nare we not friends??", "How...come...you...\ndon't wanna hug??", "What...do...you...mean...\nit's not your birthday??", "Did...you...just...say...\nyou don't like songs??"};
    private string[] angryOptions = new string[] {"I WAS GOING TO MAKE US \nFRIENDSHIP BRACELETS!!!", "HUGS ARE SCIENTIFICALLY \nPROVEN TO CALM THE SOUL!!!", "BUT RONALD GOT YOU A PRESENT \nAND EVERYTHING!!!", "BUT I DIDN'T EVEN \nGET TO THE CHORUS!!!"};
    private string[] happyOptions = new string[] {"Yay! Friends for life!", "Awesome! Let's hug \nwith our minds!", "Ronald can't wait \nto bring out the cake!", "Song time! And-a-one, \nand-a-two..."};

    // Use this for initialization
    void Start () {

        randomCharacter = Random.Range(0, totalCharacters);
        MonsterGreeting = greetingOptions[randomCharacter];
        MonsterConfused = confusedOptions[randomCharacter];
        MonsterAngry = angryOptions[randomCharacter];
        MonsterHappy = happyOptions[randomCharacter];

        newStatus = "greeting";

	}

    void Update ()
    {

        if(newStatus != currentStatus)
        {
            currentStatus = newStatus;
            SetDialogue(currentStatus);

        }

    }

    public void SetDialogue (string monsterStatus)
    {

       tempText = GetComponent<TextMesh>();

        switch(monsterStatus)
        {
            case "greeting":
                tempText.text = MonsterGreeting;
                break;
            case "confused":
                tempText.text = MonsterConfused;
                break;
            case "angry":
                tempText.text = MonsterAngry;
                break;
            case "happy":
                tempText.text = MonsterHappy;
                break;

        }

    }
	
}
