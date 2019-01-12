using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FishBehaviour : MonoBehaviour
{
	public GameObject Target;

	private Rigidbody _rigidbody;
	public float TurningForce;


	private float lastTimePulsed;
	public float PulseFrequency = 1;
	public float PulseStrength = 10;
	public bool DoPulse = false;
	void Start()
	{
		_rigidbody = GetComponent<Rigidbody>();
		lastTimePulsed = Time.realtimeSinceStartup;
	}
	
	void Update()
	{
		// TODO swim forward in bursts
		TurnTowardTarget();
		PulseForward();
	}

	void TurnTowardTarget()
	{
		var forward = transform.forward;
		var targetDirection = Target.transform.position - transform.position;
		var torqueDirection = Vector3.Cross(forward, targetDirection);
		_rigidbody.AddTorque(torqueDirection*TurningForce);
	}

	void PulseForward()
	{
		if (!DoPulse || Time.realtimeSinceStartup - lastTimePulsed > PulseFrequency)
		{
			lastTimePulsed = Time.realtimeSinceStartup;
			_rigidbody.AddForce(transform.forward*PulseStrength);
		}
	}
	
}
