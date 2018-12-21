using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1_Slot1_Send : MonoBehaviour {

    public static int incomeInc = 3;
    public static int goldDec = 10;

    public Text incomeLabel;
    public Text goldLabel;
    public Button slotButton;

    public static bool spendMax = HQManagerP1.spendMax;


	// Use this for initialization
	void Start ()
    {
        spendMax = HQManagerP1.spendMax;
        slotButton.onClick.AddListener(MonsterSend);
    }
	
	// Update is called once per frame
	void Update ()
    {
        spendMax = HQManagerP1.spendMax;
        incomeLabel = incomeLabel.GetComponent<Text>();
        incomeLabel.text = "+" + incomeInc;
        goldLabel = goldLabel.GetComponent<Text>();
        goldLabel.text = "" + goldDec + " Gold";
    }

    void MonsterSend()
    {
        while (AmmoManager.Gold >= goldDec)
        {
            if (AmmoManager.Gold >= goldDec)
            {
                AmmoManager.Gold -= goldDec;
                P1_World.goldIncome += incomeInc;
                //Spawn monster on opponents side/Queue monster for spawn at next wave
                if (spendMax == false)
                {
                    slotButton.onClick.RemoveListener(MonsterSend);
                    StartCoroutine(sendDelay());
                    break;
                }

            }
        }
    }

    IEnumerator sendDelay()
    {

        yield return new WaitForSeconds(0.025f);
        slotButton.onClick.AddListener(MonsterSend);
        StopCoroutine(sendDelay());

    }
}
