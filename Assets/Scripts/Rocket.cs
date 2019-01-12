using UnityEngine;

namespace DefaultNamespace
{
    public class Rocket: FlowSource
    {        
        public KeyCode BoostKey;
        public float MaxSpeed = 100f;
        public float velocityFactor = 0.05f;
        public float RotationSpeed = 10f;
        public float FlowSpeed = 1;
        public bool Pulsed = true;
        
        private void Update()
        {
            FlowStrength = Input.GetKey(BoostKey) && ! Pulsed || Input.GetKeyDown(BoostKey) ? FlowSpeed : 0;

            transform.rotation *= Quaternion.AngleAxis(Input.GetAxis("Horizontal")*RotationSpeed, Vector3.up);

            Rigidbody.velocity -= transform.forward * FlowStrength*velocityFactor;
            if (Rigidbody.velocity.magnitude > MaxSpeed)
                Rigidbody.velocity = Rigidbody.velocity.normalized * MaxSpeed;
        }
    }
}