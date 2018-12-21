using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HQManagerP1 : MonoBehaviour {

    public static float Health;
    public static float MaxHealth;
    public static float rechargeSpeed;
    public static float initDelay;
    public static float bufferDelay;
    public static float fastRecharge;
    public static int fastChargeDuration = 30;
    public static int UpgradeCost;
    public static float UpgradeIncome;
    public static int Level;
    public static bool upgradeSpeed = false;
    public static bool spendMax = false;

    public Button upgradeButton;
    public Toggle spendAll;
    public Text toggleLabel;

    public GameObject player;

    private int seed;

	// Use this for initialization
	void Start ()
    {
        Health = 1000;
        MaxHealth = 1000;
        UpgradeCost = 500;
        UpgradeIncome = 0.5f;
        Level = 1;
        rechargeSpeed = 0.025f;
        initDelay = 10f;
        bufferDelay = 10f;
        fastRecharge = 0.05f;
        StartCoroutine(HealthRecharge());
        upgradeButton = upgradeButton.GetComponent<Button>();
        upgradeButton.onClick.AddListener(HQUpgrade);
        spendAll = spendAll.GetComponent<Toggle>();
        spendAll.onValueChanged.AddListener(SpendAll);
        toggleLabel.text = "Buy Max Quantity";
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
            Destroy(player);
        }

        if (Health < MaxHealth)
        {
            StartCoroutine(HealthRecharge());
        }

        if (Health == MaxHealth)
        {
            upgradeSpeed = false;
        }

        if (AmmoManager.Wood > 453)
        {
            System.Random rnd = new System.Random();
            seed = rnd.Next(150, (AmmoManager.Wood / 3));
        }
        else
        {
            seed = 150;
        }
    }

    void DeductPoints(int damage)
    {
        StopAllCoroutines();
        Health -= damage;
        StartCoroutine(HealthRecharge());
    }

    void HQUpgrade()
    {
        while (AmmoManager.Wood > UpgradeCost)
        {
            if (AmmoManager.Wood > UpgradeCost)
            {
                AmmoManager.Wood -= UpgradeCost;
                if (P1_World.incomeTime > 1)
                {
                    P1_World.incomeTime -= UpgradeIncome;
                }
                Level += 1;
                UpgradeCost = (UpgradeCost * 2) + seed;
                upgradeSpeed = true;
                StartCoroutine(quickCharge());
                MaxHealth += 1000;
                
                //Check HQ level against unlocks
                if (spendMax == false)
                {
                    upgradeButton.onClick.RemoveListener(HQUpgrade);
                    StartCoroutine(upgradeDelay());
                    break;
                }

            }
        }
    }

    void SpendAll(bool isClick)
    {
        if (isClick == false) { spendMax = false;  }
        if (isClick == true) { spendMax = true; }
    }

    IEnumerator quickCharge()
    {
        while (upgradeSpeed)
        {
            
            yield return new WaitForSeconds(fastChargeDuration);
            upgradeSpeed = false;
            StopAllCoroutines();
            
        }
    }

    IEnumerator upgradeDelay()
    {
       
        yield return new WaitForSeconds(0.025f);
        upgradeButton.onClick.AddListener(HQUpgrade);
        StopCoroutine(upgradeDelay());

    }

    IEnumerator HealthRecharge()
    {
        
        while (true)
        {
            
            if (Health < MaxHealth && upgradeSpeed == false)
            {
                yield return new WaitForSeconds(initDelay);
                if (Health < MaxHealth)
                {
                    Health += rechargeSpeed;
                }
                yield return new WaitForSeconds(bufferDelay); 
            }

            if (Health < MaxHealth && upgradeSpeed)
            {
                yield return new WaitForSeconds(0);
                if (Health < MaxHealth)
                {
                    Health += fastRecharge;
                    
                }
                yield return new WaitForSeconds(1);
            }
            else
            { 
                yield return null;
            }
        }
    }
}
