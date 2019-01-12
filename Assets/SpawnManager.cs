using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	private List<FishGroupSpawnPosition> SpawnPositions;

	public float SpawnFrequency;
	private float _lastTimeSpawned;

	public float Difficulty = 4f;
	public float DifficultyPerSecond=0.2f;

	void Start()
	{
		SpawnPositions = GetComponentsInChildren<FishGroupSpawnPosition>().ToList();
	}
	void Update ()
	{
		Difficulty += DifficultyPerSecond * Time.deltaTime;
		Debug.Log(Difficulty);
		
		if (Time.realtimeSinceStartup - _lastTimeSpawned > SpawnFrequency)
		{
			_lastTimeSpawned = Time.realtimeSinceStartup;
			var index = Mathf.FloorToInt(Random.Range(0, SpawnPositions.Count));
			SpawnPositions[index].Spawn(Mathf.FloorToInt(Difficulty), 0.1f, Difficulty);
		}
		
	}
}
