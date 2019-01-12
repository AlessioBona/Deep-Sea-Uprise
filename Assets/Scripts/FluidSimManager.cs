using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class FluidSimManager: MonoBehaviour
{
    public static FluidSimManager Instance;
    
    public FluidSim FluidSim;

    public List<FlowSource> FlowSources;
    public List<Floatable> Floatables;

    void Awake()
    {
        Instance = this;
        if(FlowSources==null)
            FlowSources = new List<FlowSource>();
        if (Floatables==null)
            Floatables = new List<Floatable>();
    }
    
    private void FixedUpdate()
    {
        FluidSim.ResetFields();        

        // Add Flow Sources' Velocities
        foreach (var flowSource in FlowSources)
        {
            FluidSim.FlowSourceAtPos(flowSource.transform.position, flowSource.FlowStrength * flowSource.transform.TransformDirection(Vector3.forward).ToPlaneVector2() );            
        }
        
        FluidSim.UpdateFlow();
        // TODO have game objects flow with the fluid

        foreach (var floatable in Floatables)
        {
            floatable.Rigidbody.velocity = FluidSim.GetVelocityAtPos(floatable.transform.position) * 10f;
        }
        
        FluidSim.ScaleDensity(0.99f);
    }
}
