using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaulerFire : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButton("Fire1"))
        {
            if (AmmoManager.ClipBullets > 0)
            {
                AudioSource gunsound = GetComponent<AudioSource>();
                gunsound.Play();
                GetComponent<Animation>().Play("MaulerAnim");
                AmmoManager.ClipBullets -= 1;
            }
        }
    }
}
