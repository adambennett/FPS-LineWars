using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunfire : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (ScreenChecker.ClearScreen)
        {
            if (Input.GetButton("Fire1"))
            {
                StartCoroutine(shotDelay());
                if (AmmoManager.ClipBullets > 0)
                {
                    AudioSource gunsound = GetComponent<AudioSource>();
                   // gunsound.Play();
                   // GetComponent<Animation>().Play("GunShot");
                    AmmoManager.ClipBullets -= 1;
                }
            }
        }
    }

    IEnumerator shotDelay()
    {
        yield return new WaitForSeconds(1f);
        StopCoroutine(shotDelay());
    }
}
