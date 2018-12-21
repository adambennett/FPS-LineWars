using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SendMenuManager : MonoBehaviour {

    public static bool visibility = false;
    public static bool spendMax = HQManagerP1.spendMax;

    private Image image;

    public GameObject menu;
    public GameObject slotHQCost;
    public GameObject slotHQIncome;
    public GameObject slotHQLevel;
    public GameObject slotHQHealth;

    // HQ Text Variables
    private Text hp;
    private Text level;
    private Text income;
    private Text cost;

    // Slot Text Variables
    public Text incomeLabel1;
    public Text goldLabel1;
    public Text incomeLabel2;
    public Text goldLabel2;
    public Text incomeLabel3;
    public Text goldLabel3;

    // Slot Income/Gold Values
    public static int incomeInc1 = 3;
    public static int goldDec1 = 10;
    public static int incomeInc2 = 6;
    public static int goldDec2 = 50;
    public static int incomeInc3 = 12;
    public static int goldDec3 = 100;
    
    // Slot Buttons
    public Button slot1Button;
    public Button slot2Button;
    public Button slot3Button;

    IEnumerator sendDelay()
    {

        yield return new WaitForSeconds(0.025f);
        slot1Button.onClick.AddListener(Slot1Send);
        slot2Button.onClick.AddListener(Slot2Send);
        slot3Button.onClick.AddListener(Slot3Send);
        StopCoroutine(sendDelay());

    }

    // Use this for initialization
    void Start ()
    {
        hp = slotHQHealth.GetComponent<Text>();
        level = slotHQLevel.GetComponent<Text>();
        income = slotHQIncome.GetComponent<Text>();
        cost = slotHQCost.GetComponent<Text>();

        spendMax = HQManagerP1.spendMax;

        slot1Button.onClick.AddListener(Slot1Send);
        slot2Button.onClick.AddListener(Slot2Send);
        slot3Button.onClick.AddListener(Slot3Send);
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Send Menu Visibility
        image = menu.GetComponent<Image>();
        if (visibility)
        {
            hp.text = "" + Math.Floor(HQManagerP1.Health) + "/" + HQManagerP1.MaxHealth;
            level.text = "Level " + HQManagerP1.Level;
            income.text = "-" + HQManagerP1.UpgradeIncome + " seconds";
            cost.text = "" + HQManagerP1.UpgradeCost + " Wood";
            image.enabled = true;
        }

        else
        {
            image.enabled = false;
        }
        //
        // Handling 'Buy All' 
        spendMax = HQManagerP1.spendMax;
        //
        // Setting Slot Labels
        incomeLabel1 = incomeLabel1.GetComponent<Text>();
        incomeLabel1.text = "+" + incomeInc1;
        goldLabel1 = goldLabel1.GetComponent<Text>();
        goldLabel1.text = "" + goldDec1 + " Gold";
        //
        // Slot 2
        incomeLabel2 = incomeLabel2.GetComponent<Text>();
        incomeLabel2.text = "+" + incomeInc2;
        goldLabel2 = goldLabel2.GetComponent<Text>();
        goldLabel2.text = "" + goldDec2 + " Gold";
        //
        // Slot 3
        incomeLabel3 = incomeLabel3.GetComponent<Text>();
        incomeLabel3.text = "+" + incomeInc3;
        goldLabel3 = goldLabel3.GetComponent<Text>();
        goldLabel3.text = "" + goldDec3 + " Gold";
        //
    }

    void Slot1Send()
    {
        while (AmmoManager.Gold >= goldDec1)
        {
            if (AmmoManager.Gold >= goldDec1)
            {
                AmmoManager.Gold -= goldDec1;
                P1_World.goldIncome += incomeInc1;
                //Spawn monster on opponents side/Queue monster for spawn at next wave
                if (spendMax == false)
                {
                    slot1Button.onClick.RemoveListener(Slot1Send);
                    slot2Button.onClick.RemoveListener(Slot2Send);
                    slot3Button.onClick.RemoveListener(Slot3Send);
                    StartCoroutine(sendDelay());
                    break;
                }

            }
        }
    }

    void Slot2Send()
    {
        while (AmmoManager.Gold >= goldDec2)
        {
            if (AmmoManager.Gold >= goldDec2)
            {
                AmmoManager.Gold -= goldDec2;
                P1_World.goldIncome += incomeInc2;
                //Spawn monster on opponents side/Queue monster for spawn at next wave
                if (spendMax == false)
                {
                    slot1Button.onClick.RemoveListener(Slot1Send);
                    slot2Button.onClick.RemoveListener(Slot2Send);
                    slot3Button.onClick.RemoveListener(Slot3Send);
                    StartCoroutine(sendDelay());
                    break;
                }

            }
        }
    }

    void Slot3Send()
    {
        while (AmmoManager.Gold >= goldDec3)
        {
            if (AmmoManager.Gold >= goldDec3)
            {
                AmmoManager.Gold -= goldDec3;
                P1_World.goldIncome += incomeInc3;
                //Spawn monster on opponents side/Queue monster for spawn at next wave
                if (spendMax == false)
                {
                    slot1Button.onClick.RemoveListener(Slot1Send);
                    slot2Button.onClick.RemoveListener(Slot2Send);
                    slot3Button.onClick.RemoveListener(Slot3Send);
                    StartCoroutine(sendDelay());
                    break;
                }

            }
        }
    }
}
