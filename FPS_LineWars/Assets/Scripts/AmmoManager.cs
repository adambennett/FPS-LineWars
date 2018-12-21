using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoManager : MonoBehaviour {

    public GameObject ReserveAmmo;
    public GameObject ClipAmmo;
    public GameObject WoodCount;
    public GameObject GoldCount;
    public GameObject BrickCount;
    public static int ClipBullets;
    public static int maxClip = P1_World.maxClip;
    int intClipBullets;
    public static int ReserveBullets;
    int intReserveBullets;
    public static int Wood = 0;
    public static int Gold = 6100;
    public static int Brick = 0;
    int intWood;
    int intGold;
    int intBrick;

    Text clip;
    Text reserve;
    Text wood;
    Text gold;
    Text brick;

    // Use this for initialization
    void Start ()
    {
        clip = ClipAmmo.GetComponent<Text>();
        reserve = ReserveAmmo.GetComponent<Text>();
        wood = WoodCount.GetComponent<Text>();
        gold = GoldCount.GetComponent<Text>();
        brick = BrickCount.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        intClipBullets = ClipBullets;
        intReserveBullets = ReserveBullets;
        intWood = Wood;
        intGold = Gold;
        intBrick = Brick;
        
         clip.text = "" + intClipBullets;
         reserve.text = "" + intReserveBullets;
         wood.text = "Wood: " + intWood;
         gold.text = "Gold : " + intGold;
         brick.text = "Brick: " + intBrick;
    }

    
}