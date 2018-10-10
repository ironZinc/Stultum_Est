using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotgunShellsControl : MonoBehaviour {
    //private GameObject Player;

	void Start () {
        //Player = GameObject.Find("Player");
	}
	
	void Update () {

	}

    private void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.tag == "Player")
        {
            hit.gameObject.GetComponent<Shoot>().AddShotgunShells();
            Destroy(this.gameObject);
        }
    }

}
