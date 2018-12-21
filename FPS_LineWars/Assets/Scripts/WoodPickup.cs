using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodPickup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter()
    {
        AmmoManager.Wood += 600;
        this.gameObject.SetActive(false);
    }
}
