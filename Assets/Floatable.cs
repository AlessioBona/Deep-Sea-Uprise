using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Floatable : MonoBehaviour
{
    public Rigidbody Rigidbody;
    void Start()
    {
        FluidSimManager.Instance.Floatables.Add(this);
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnDestroy()
    {
        FluidSimManager.Instance.Floatables.Remove(this);
    }
}
