using UnityEngine;

public class FlowSource : MonoBehaviour
{
    public float FlowStrength = 1;
    public Rigidbody Rigidbody;
    void Start()
    {
        FluidSimManager.Instance.FlowSources.Add(this);
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnDestroy()
    {
        FluidSimManager.Instance.FlowSources.Remove(this);
    }
}
