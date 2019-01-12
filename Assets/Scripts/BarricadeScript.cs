using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarricadeScript : MonoBehaviour {

    [SerializeField]
    float healthPoints;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Barricade hit by: " + collision.gameObject.name);
        if(healthPoints >= 0)
        {
            healthPoints--;
            if(healthPoints <= 0)
            {
                BreakDown();
            }
        }
    }

    private void BreakDown()
    {
        gameObject.SetActive(false);
    }
}
