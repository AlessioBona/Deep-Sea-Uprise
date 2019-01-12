using UnityEngine;

public class FlowSource : MonoBehaviour
{
    public float FlowStrength = 1;
    void Start()
    {
        FluidSimManager.Instance.FlowSources.Add(this);
    }

    private void OnDestroy()
    {
        FluidSimManager.Instance.FlowSources.Remove(this);
    }
}
