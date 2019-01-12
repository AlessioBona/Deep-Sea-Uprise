using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour {

    [SerializeField]
    float selfDistructTime;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        selfDistructTime -= Time.deltaTime;

        if (selfDistructTime <= 0)
        {
            GameObject.Destroy(this.gameObject);
        }
	}
}
