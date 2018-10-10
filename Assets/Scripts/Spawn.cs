using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	public GameObject EnemyPrefab;
	public GameObject RifleAmmoPrefab;
	public GameObject ShotgunShellsPrefab;


	private GameObject Enemy;
	private GameObject RifleAmmo;
	private GameObject ShotgunShells;

	private List<GameObject> enemySpawns;
	private List<GameObject> rifleAmmoSpawns;
	private List<GameObject> shotgunShellsSpawns;

    void Start () {
		StartCoroutine (SpawnEnemy());
		StartCoroutine (SpawnRifleAmmo());
		StartCoroutine (SpawnShotgunShells());
	}

	void Update () {
		
	}

	public IEnumerator SpawnEnemy()
	{
		yield return new WaitForSeconds (1f);
		enemySpawns = new List<GameObject>(GameObject.FindGameObjectsWithTag ("EnemySpawn"));
		for(int i = 0; i < 15; i++)
		{
			int randomNumber = Random.Range (0, enemySpawns.Count);
			Enemy = Instantiate (EnemyPrefab, enemySpawns[randomNumber].transform.position, enemySpawns[randomNumber].transform.rotation) as GameObject;
			enemySpawns.RemoveAt (randomNumber);
		}
	}

	public IEnumerator SpawnRifleAmmo()
	{
		yield return new WaitForSeconds (1f);
		rifleAmmoSpawns = new List<GameObject>(GameObject.FindGameObjectsWithTag ("RifleAmmoSpawn"));
		for(int i = 0; i < 5; i++)
		{
			int randomNumber = Random.Range (0, rifleAmmoSpawns.Count);
			RifleAmmo = Instantiate (RifleAmmoPrefab, rifleAmmoSpawns[randomNumber].transform.position, rifleAmmoSpawns[randomNumber].transform.rotation) as GameObject;
			rifleAmmoSpawns.RemoveAt (randomNumber);
		}
	}

	public IEnumerator SpawnShotgunShells()
	{
		yield return new WaitForSeconds (1f);
		shotgunShellsSpawns = new List<GameObject>(GameObject.FindGameObjectsWithTag ("ShotgunShellsSpawn"));
		for(int i = 0; i < 6; i++)
		{
			int randomNumber = Random.Range (0, shotgunShellsSpawns.Count);
			ShotgunShells = Instantiate (ShotgunShellsPrefab, shotgunShellsSpawns[randomNumber].transform.position, shotgunShellsSpawns[randomNumber].transform.rotation) as GameObject;
			shotgunShellsSpawns.RemoveAt (randomNumber);
		}
	}

}
