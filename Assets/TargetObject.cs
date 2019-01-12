using UnityEngine;

public class TargetObject : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        var fish = other.gameObject.GetComponent<FishBehaviour>();
        if (fish != null)
        {
            FindObjectOfType<MyGUIManager>().GameOver();
            Debug.Log("GAME OVER!!!");
        }
    }
}
