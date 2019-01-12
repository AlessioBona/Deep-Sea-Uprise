using UnityEngine;

public class FishGroupSpawnPosition : MonoBehaviour
{
	public GameObject FishPrefab;

	public void Spawn(int count, float radius)
	{
		for (int i = 0; i < count; i++)
		{
			var pos = GetRandomPosition(radius);
			var rotation = Quaternion.identity;
			var go = Instantiate(FishPrefab, pos, rotation, transform);
		}
	}

	private Vector3 GetRandomPosition(float radius)
	{
		var offset = Random.insideUnitSphere * radius;
		offset.y = 0;
		return transform.position + offset;
	}
}
