using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponMenuManager_P1 : MonoBehaviour {

    public static bool visibility = false;
    public GameObject menu;
    private Image image;

    // Cost Values
    public static int goldDec1 = 100;
    public static int goldDec2 = 500;
    public static int goldDec3 = 2000;
    public static int goldDec4 = 6000;
    public static int goldDec5 = 20000;
    public static int goldDec6 = 50;

    // Weapon Buttons
    public Button slot1Button;
    public Button slot2Button;
    public Button slot3Button;
    public Button slot4Button;
    public Button slot5Button;
    public Button ammoButton;

    // Guns
    public GameObject M9;
    public GameObject archtronic;
    public GameObject mauler;
    public GameObject FireSleet;
    public GameObject grimbrand;
    public GameObject hellwailer;
    
    IEnumerator sendDelay()
    {
        yield return new WaitForSeconds(0.025f);
        slot1Button.onClick.AddListener(BuyWep1);
        slot2Button.onClick.AddListener(BuyWep2);
        slot3Button.onClick.AddListener(BuyWep3);
        slot4Button.onClick.AddListener(BuyWep4);
        slot5Button.onClick.AddListener(BuyWep5);
        ammoButton.onClick.AddListener(BuyAmmo);
        StopCoroutine(sendDelay());
    }

    // Use this for initialization
    void Start ()
    {
        slot1Button.onClick.AddListener(BuyWep1);
        slot2Button.onClick.AddListener(BuyWep2);
        slot3Button.onClick.AddListener(BuyWep3);
        slot4Button.onClick.AddListener(BuyWep4);
        slot5Button.onClick.AddListener(BuyWep5);
        ammoButton.onClick.AddListener(BuyAmmo);
        P1_World.equippedWeapon = M9;
    }

    // Update is called once per frame
    void Update()
    {
        // Weapon Menu Visibility
        image = menu.GetComponent<Image>();
        if (visibility)
        {
            image.enabled = true;
        }

        else
        {
            image.enabled = false;
        }
    }

    void BuyWep1()
    {
        if (AmmoManager.Gold >= goldDec1)
        {
            AmmoManager.Gold -= goldDec1;
            P1_World.equippedWeapon = grimbrand;
            Raycasting.automatic = true;

            M9.SetActive(false);
            grimbrand.SetActive(true);

            slot1Button.onClick.RemoveListener(BuyWep1);
            slot2Button.onClick.RemoveListener(BuyWep2);
            slot3Button.onClick.RemoveListener(BuyWep3);
            slot4Button.onClick.RemoveListener(BuyWep4);
            slot5Button.onClick.RemoveListener(BuyWep5);
            ammoButton.onClick.RemoveListener(BuyAmmo);
            StartCoroutine(sendDelay());
        }
    }

    void BuyWep2()
    {
        if (AmmoManager.Gold >= goldDec2)
        {
            AmmoManager.Gold -= goldDec2;
            P1_World.equippedWeapon = mauler;

            //Raycasting.automatic = true;

            M9.SetActive(false);
            mauler.SetActive(true);

            slot1Button.onClick.RemoveListener(BuyWep1);
            slot2Button.onClick.RemoveListener(BuyWep2);
            slot3Button.onClick.RemoveListener(BuyWep3);
            slot4Button.onClick.RemoveListener(BuyWep4);
            slot5Button.onClick.RemoveListener(BuyWep5);
            ammoButton.onClick.RemoveListener(BuyAmmo);
            StartCoroutine(sendDelay());
        }
    }

    void BuyWep3()
    {
        if (AmmoManager.Gold >= goldDec3)
        {
            AmmoManager.Gold -= goldDec3;
            P1_World.equippedWeapon = FireSleet;

            //Raycasting.automatic = true;

            M9.SetActive(false);
            FireSleet.SetActive(true);

            slot1Button.onClick.RemoveListener(BuyWep1);
            slot2Button.onClick.RemoveListener(BuyWep2);
            slot3Button.onClick.RemoveListener(BuyWep3);
            slot4Button.onClick.RemoveListener(BuyWep4);
            slot5Button.onClick.RemoveListener(BuyWep5);
            ammoButton.onClick.RemoveListener(BuyAmmo);
            StartCoroutine(sendDelay());
        }
    }

    void BuyWep4()
    {
        if (AmmoManager.Gold >= goldDec4)
        {
            AmmoManager.Gold -= goldDec4;
            P1_World.equippedWeapon = archtronic;
            Raycasting.automatic = true;

            M9.SetActive(false);
            archtronic.SetActive(true);

            slot1Button.onClick.RemoveListener(BuyWep1);
            slot2Button.onClick.RemoveListener(BuyWep2);
            slot3Button.onClick.RemoveListener(BuyWep3);
            slot4Button.onClick.RemoveListener(BuyWep4);
            slot5Button.onClick.RemoveListener(BuyWep5);
            ammoButton.onClick.RemoveListener(BuyAmmo);

            StartCoroutine(sendDelay());
        }
    }

    void BuyWep5()
    {
        if (AmmoManager.Gold >= goldDec5)
        {
            AmmoManager.Gold -= goldDec5;
            P1_World.equippedWeapon = hellwailer;

            Raycasting.automatic = true;

            M9.SetActive(false);
            hellwailer.SetActive(true);

            slot1Button.onClick.RemoveListener(BuyWep1);
            slot2Button.onClick.RemoveListener(BuyWep2);
            slot3Button.onClick.RemoveListener(BuyWep3);
            slot4Button.onClick.RemoveListener(BuyWep4);
            slot5Button.onClick.RemoveListener(BuyWep5);
            ammoButton.onClick.RemoveListener(BuyAmmo);
            StartCoroutine(sendDelay());
        }
    }

    void BuyAmmo()
    {
        if (AmmoManager.Gold >= goldDec6)
        {
            AmmoManager.Gold -= goldDec6;
            AmmoManager.ReserveBullets += 50;

            slot1Button.onClick.RemoveListener(BuyWep1);
            slot2Button.onClick.RemoveListener(BuyWep2);
            slot3Button.onClick.RemoveListener(BuyWep3);
            slot4Button.onClick.RemoveListener(BuyWep4);
            slot5Button.onClick.RemoveListener(BuyWep5);
            ammoButton.onClick.RemoveListener(BuyAmmo);

            StartCoroutine(sendDelay());
        }
    }
}
