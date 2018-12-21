using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenChecker : MonoBehaviour {

    public static bool ClearScreen = true;
    private bool isMenu1 = false;
    private bool isMenu2 = false;
    private bool isMenu3 = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (SendMenuManager.visibility == false) { isMenu1 = false; }
        else { isMenu1 = true; }
        if (WeaponMenuManager_P1.visibility == false) { isMenu2 = false; }
        else { isMenu2 = true; }
        //if (BuilderMenuManager_P1.visibility == false) { isMenu3 = false; }
        //else { isMenu3 = true; }

        if (isMenu1 || isMenu2 || isMenu3)
        {
            ClearScreen = false;
        }

        else
        {
            ClearScreen = true;
        }
    }
}
