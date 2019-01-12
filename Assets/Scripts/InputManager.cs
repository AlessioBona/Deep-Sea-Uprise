using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    [SerializeField]
    Camera mainCamera;

    private void Awake()
    {
        Camera[] cameras = FindObjectsOfType<Camera>();
        foreach (Camera cam in cameras)
        {
            if (cam != mainCamera){
                cam.gameObject.SetActive(false);
            }
        }
    }

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
        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) && !directing)
        {
            DoRaycast();
        } else if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) && directing)
        {
            directing = false;
            selectedTurret.working = true;
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
                float dist;
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                groundPlane.Raycast(ray, out dist);
                Vector3 position = ray.GetPoint(dist);

                Vector3 relativePos = position - selectedTurret.transform.position;

                // the second argument, upwards, defaults to Vector3.up
                Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
                selectedTurret.transform.rotation = rotation;
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
        if (Input.GetMouseButtonDown(0))
        {
            if (positioning) { 
                positioning = false;
                selectedTurret.working = true;
            } else {
                positioning = true;
                selectedTurret.working = false;
            }

        }


        // if not positioning, then toggle directing
        if (Input.GetMouseButtonDown(1) && !positioning)
        {
            directing = true;
            selectedTurret.working = false;
        } 
    }
}
