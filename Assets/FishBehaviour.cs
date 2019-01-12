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

	public float Life = 6;
	
	void Start()
	{
		_rigidbody = GetComponent<Rigidbody>();
		lastTimePulsed = Time.realtimeSinceStartup;
		Target = FindObjectOfType<TargetObject>().gameObject;
		Life += Random.Range(-0.1f, .1f) * Life;
	}
	
	void Update()
	{
		// TODO swim forward in bursts
		TurnTowardTarget();
		PulseForward();
		TickDownLife();
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

	void Die()
	{
		Destroy(gameObject);
	}

	void TickDownLife()
	{
		Life -= Time.deltaTime;
		if (Life < 0)
			Die();
	}
	
}
