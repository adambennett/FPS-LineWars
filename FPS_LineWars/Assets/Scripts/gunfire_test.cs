using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gunfire_test : MonoBehaviour {

   

    // Use this for initialization
    void Start ()
    {

    }

    // Update is called once per frame
    void Update() {
        if (ScreenChecker.ClearScreen)
        { 
            if (Input.GetButtonDown("Fire1"))
            {
                if (AmmoManager.ClipBullets > 0)
                {
                    AudioSource gunsound = GetComponent<AudioSource>();
                    gunsound.Play();
                    GetComponent<Animation>().Play("GunShot");
                    AmmoManager.ClipBullets -= 1;
                }
            }
        }
    }
}
