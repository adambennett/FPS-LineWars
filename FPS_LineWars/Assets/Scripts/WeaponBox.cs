using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;


public class WeaponBox : MonoBehaviour {

    public float TheDistance = Raycasting.distance;
    public GameObject InteractPopup;
    public GameObject FPSController;
    Text interactPrompt;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        TheDistance = Raycasting.distance;
        
    }

    void OnMouseOver()
    {
        if (TheDistance <= 4)
        {

            interactPrompt = InteractPopup.GetComponent<Text>();
            interactPrompt.text = "Interact";
            if (Input.GetButtonDown("Fire2"))
            {
                OpenWeaponMenu();  
            }
        }

        else
        {
            interactPrompt = InteractPopup.GetComponent<Text>();
            interactPrompt.text = "";
        }
    }

    void OpenWeaponMenu()
    {
        WeaponMenuManager_P1.visibility = true;
        FPSController.GetComponent<FirstPersonController>().enabled = false;
        Cursor.visible = true;
    }
}
