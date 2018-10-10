using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Win : MonoBehaviour {

    private GameObject[] Enemys;

	private bool check;

	// Use this for initialization
	void Start () {
		StartCoroutine (Wait());
	}
	
	// Update is called once per frame
	void Update () {
		if(check == true)
		{
			Enemys = GameObject.FindGameObjectsWithTag("EnemyType1");
	        if (Enemys.Length == 0)
	        {
	            SceneManager.LoadScene("Win");
	        }
		}
	}
	IEnumerator Wait()
	{
		yield return new WaitForSeconds (10f);
		check = true;
	}
}
