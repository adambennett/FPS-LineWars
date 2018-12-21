using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1_Door_Open : MonoBehaviour {
    public float TheDistance = Raycasting.distance;
    public GameObject InteractPopup;
    Text interactPrompt;

    void Update()
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
                OpenDoor();
            }
        }

        else
        {
            interactPrompt = InteractPopup.GetComponent<Text>();
            interactPrompt.text = "";
        }

    }

    void OnMouseExit()
    {
        interactPrompt = InteractPopup.GetComponent<Text>();
        interactPrompt.text = "";
    }

    void OpenDoor()
    {
        GetComponent<Animation>().Play("DoorAnim");
    }


}
