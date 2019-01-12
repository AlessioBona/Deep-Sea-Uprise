using UnityEngine;

[RequireComponent(typeof(TurretScript))]
public class FlowSource : MonoBehaviour
{
    public float FlowStrength = 1;
    private float _actualFlowStrength;
    private TurretScript _turretScript;
    void Start()
    {
        FluidSimManager.Instance.FlowSources.Add(this);
        _turretScript = GetComponent<TurretScript>();
        _actualFlowStrength = FlowStrength;
    }

    void Update()
    {
        // while the turret is being moved, it is not working and should not create flow
        FlowStrength = _turretScript.working ? _actualFlowStrength:0;
    }

    private void OnDestroy()
    {
        FluidSimManager.Instance.FlowSources.Remove(this);
    }
}
