using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    [SerializeField]
    Camera mainCamera;

    private Plane groundPlane;

    public bool positioning { get; private set; }

    public bool directing { get; private set; }

    public TurretScript selectedTurret;

    // Use this for initialization
    void Start () {
        groundPlane = new Plane(Vector3.up, Vector3.zero);
	}
	
	// Update is called once per frame
	void Update () {
        // check if click
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            DoRaycast();
        }

        if (positioning)
        {
            if(selectedTurret != null)
            {
                float dist;
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                groundPlane.Raycast(ray, out dist);
                Vector3 position = ray.GetPoint(dist);

                selectedTurret.transform.position = position;


            }
        }
        else if (directing)
        {
            if (selectedTurret != null)
            {

            }
        }
    }

    private void DoRaycast()
    {
        //raycast
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            // is it a Turret?
            if(objectHit.GetComponentInParent<TurretScript>())
            {
                selectedTurret = objectHit.GetComponentInParent<TurretScript>();

                TogglePositionAndDirecting();
            }
        }

    }

    private void TogglePositionAndDirecting()
    {
        // if not directing, then toggle positioning
        if (Input.GetMouseButtonDown(0) && !directing)
        {
            positioning = !positioning;

        }

        // if not positioning, then toggle directing
        if (Input.GetMouseButtonDown(1) && !positioning)
        {
            directing = !directing;
        }
    }
}
