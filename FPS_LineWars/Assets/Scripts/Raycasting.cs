using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Raycasting : MonoBehaviour {
    
    public int damage = P1_World.damage;
    public float targetDistance;            // Shooting raycast 
    public static float distance;           // Constant raycast distance
    public float allowedRange = P1_World.range;
    public GameObject SendMenu;
    public GameObject FPSController;
    RaycastHit hit;

    public static bool automatic = false;
    
    void Update() {
        Debug.DrawRay(transform.position, transform.forward * allowedRange);

        int ammoNeeded = P1_World.maxClip - AmmoManager.ClipBullets;
        int ammoAvail = AmmoManager.ReserveBullets;

// Distance for interactables
        Physics.Raycast(transform.position, transform.forward, out hit);
        distance = hit.distance;

// Shooting
        if (automatic == false)
        {
            if (ScreenChecker.ClearScreen)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    if (AmmoManager.ClipBullets > 0)
                    {
                        if (Physics.Raycast(transform.position, transform.forward, out hit, allowedRange))
                        {
                            targetDistance = hit.distance;
                            hit.transform.SendMessage("DeductPoints", damage, SendMessageOptions.DontRequireReceiver);
                        }
                    }
                }
            }
        }

        else
        {
            if (ScreenChecker.ClearScreen)
            {
                if (Input.GetButton("Fire1"))
                {
                    StartCoroutine(shotDelay());
                    if (AmmoManager.ClipBullets > 0)
                    {
                        if (Physics.Raycast(transform.position, transform.forward, out hit, allowedRange))
                        {
                            targetDistance = hit.distance;
                            hit.transform.SendMessage("DeductPoints", damage, SendMessageOptions.DontRequireReceiver);
                        }
                    }
                }
            }
        }
// END Shooting

// Reloading
        if (ScreenChecker.ClearScreen)
        {
            if (Input.GetButtonDown("Keyboard 'R'"))
            {
                if (ammoAvail > 0)
                {
                    if (ammoAvail > ammoNeeded)
                    {
                        AmmoManager.ReserveBullets -= ammoNeeded;
                        AmmoManager.ClipBullets += ammoNeeded;
                    }

                    else
                    {
                        AmmoManager.ClipBullets += ammoAvail;
                        AmmoManager.ReserveBullets = 0;
                    }

                }
            }
        }
// END Reloading

// Send Menu Display
        if (ScreenChecker.ClearScreen)
        {
            if (Input.GetButton("Keyboard 'T'"))
            {
                SendMenuManager.visibility = true;
                FPSController.GetComponent<FirstPersonController>().enabled = false;
                Cursor.visible = true;
            }

            if (Input.GetButtonDown("Cancel"))
            {
                //Display quit menu
            }
        }


        if (SendMenuManager.visibility || WeaponMenuManager_P1.visibility)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                SendMenuManager.visibility = false;
                WeaponMenuManager_P1.visibility = false;
                FPSController.GetComponent<FirstPersonController>().enabled = true;
                Cursor.visible = false;
                //image.enabled = false;
            }
        }

// END Send Menu Display
        else
        {
            if (Input.GetButtonDown("Cancel"))
            {
                //Display quit menu
            }
        }
    }
// END Update()

    IEnumerator shotDelay()
    {
        yield return new WaitForSeconds(1f);
        StopCoroutine(shotDelay());
    }
}
