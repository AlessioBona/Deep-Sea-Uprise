﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	private List<FishGroupSpawnPosition> SpawnPositions;

	public float SpawnFrequency;
	private float _lastTimeSpawned;

	public float Difficulty = 0f;
	public float DifficultyPerSecond=0.2f;

	void Start()
	{
		SpawnPositions = GetComponentsInChildren<FishGroupSpawnPosition>().ToList();
		_lastTimeSpawned = Time.realtimeSinceStartup - SpawnFrequency - 1f;
	}
	void Update ()
	{
		Difficulty += DifficultyPerSecond * Time.deltaTime;
		
		if (Time.realtimeSinceStartup - _lastTimeSpawned > SpawnFrequency)
		{
			_lastTimeSpawned = Time.realtimeSinceStartup;
			var index = Mathf.FloorToInt(Random.Range(0, SpawnPositions.Count));
			SpawnPositions[index].Spawn(Mathf.FloorToInt(Difficulty+3), 0.1f, Difficulty);
		}
		
	}
}
