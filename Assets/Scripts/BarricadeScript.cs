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

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Barricade hit by: " + collision.gameObject.name);
        
        var fish = collision.gameObject.GetComponent<FishBehaviour>();
        if (fish == null)
            return;
        
        fish.Die();
        
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
