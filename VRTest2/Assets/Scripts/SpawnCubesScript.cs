using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubesScript : MonoBehaviour
{
	[SerializeField] private GameObject _cubeToSpawn;
	[SerializeField] private Transform _spawnPosition;
	
	public void SpawnNewCubes()
	{
		Instantiate(_cubeToSpawn, _spawnPosition.position, Quaternion.identity);
	}
}
