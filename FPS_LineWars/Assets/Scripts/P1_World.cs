using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class P1_World : MonoBehaviour {

    public static int goldIncome;
    public static int woodIncome;
    public static int brickIncome;
    public static int ammoIncome;
    public static int damage;
    public static int maxClip;
    public static float range;
    public static float Health;
    public static float Shield;
    public static float regenSpeed;
    public static float moveSpeed;
    public static float jumpHeight;
    public static float reloadMod;
    public static float incomeTime;

    private bool timeKeeper = false;
    private bool crRunning = false;

    public static GameObject equippedWeapon;
    public GameObject M9;
    public GameObject archtronic;
    public GameObject mauler;
    public GameObject FireSleet;
    public GameObject grimbrand;
    public GameObject hellwailer;

    public Text incomeCounter;
   
	// Use this for initialization
	void Start ()
    {
        goldIncome = 20;
        Health = 100;
        incomeTime = 10.5f;
        ammoIncome = 0;   // temp
        woodIncome = 1000;  // temp
	}
	
	// Update is called once per frame
	void Update ()
    {
        GunCheck();

		if (timeKeeper)
        {
            AmmoManager.Gold += goldIncome;
            AmmoManager.Wood += woodIncome;
            AmmoManager.Brick += brickIncome;
            AmmoManager.ReserveBullets += ammoIncome;
            timeKeeper = false;
            if (crRunning) { }
            else
            {
                StartCoroutine(timer());
                crRunning = true;
            }
        }
        
        else
        {
            if (crRunning) { }
            else
            {
                StartCoroutine(timer());
                crRunning = true;
            }
        }

        float goldPerMin = (60 / incomeTime) * goldIncome;
        double goldPerMinDisplay = Math.Floor(goldPerMin);

        incomeCounter = incomeCounter.GetComponent<Text>();
        incomeCounter.text = "" + goldPerMinDisplay + " G/min";
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(incomeTime);
        timeKeeper = true;
        StopAllCoroutines();
        crRunning = false;
    }

    void DeductPoints(int damage)
    {
        Health -= damage;
    }

    void GunCheck()
    {
        if (equippedWeapon == archtronic)
        {
            range = 20f;
            damage = 15;
            maxClip = 60;
        }

        if (equippedWeapon == M9)
        {
            range = 15f;
            damage = 5;
            maxClip = 10;
        }

        if (equippedWeapon == FireSleet)
        {

        }

        if (equippedWeapon == grimbrand)
        {

        }

        if (equippedWeapon == mauler)
        {

        }
    }
}
