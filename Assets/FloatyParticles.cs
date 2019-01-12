using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatyParticles : MonoBehaviour
{
	private ParticleSystem particleSystem;
	public FluidSim FluidSim;
	
	void Start()
	{
		particleSystem = GetComponent<ParticleSystem>();
	}
	
	void LateUpdate () {
         
		ParticleSystem.Particle[] p = new ParticleSystem.Particle[particleSystem.particleCount+1];
		int l = particleSystem.GetParticles(p);
         
		int i = 0;
		while (i < l) {
			p[i].velocity = FluidSim.GetVelocityAtPos(p[i].position) * 10f;

			i++;
		}
  
		particleSystem.SetParticles(p, l);    
         
	}
}
