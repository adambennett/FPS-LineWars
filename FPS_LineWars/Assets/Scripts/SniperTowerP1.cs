using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperTowerP1 : MonoBehaviour {

   public new Collider collider;
   public Renderer rend;

	// Use this for initialization
	void Start ()
    {
        collider = GetComponent<Collider>();
        rend = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Keyboard 'C'"))
        {
            collider.enabled = !collider.enabled;
            rend.enabled = !rend.enabled;
        }
    }
}
