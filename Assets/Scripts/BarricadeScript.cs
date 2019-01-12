using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarricadeScript : MonoBehaviour {

    [SerializeField]
    float healthPoints;
    SkinnedMeshRenderer meshRend;

    [SerializeField]
    Texture[] breakingTextures;

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

            if (healthPoints == 2)
            {
                SwitchTexture(breakingTextures[0]);
            }
            else if (healthPoints == 1)
            {
                SwitchTexture(breakingTextures[1]);
            }
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

    void SwitchTexture(Texture newTexture)
    {
        meshRend = GetComponentInChildren<SkinnedMeshRenderer>();
        meshRend.material.mainTexture = newTexture;
    }
}
