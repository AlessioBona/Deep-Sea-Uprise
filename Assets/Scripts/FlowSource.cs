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
        // TODO if is being positioned
        FlowStrength = false ? 0 : _actualFlowStrength;
    }

    private void OnDestroy()
    {
        FluidSimManager.Instance.FlowSources.Remove(this);
    }
}
