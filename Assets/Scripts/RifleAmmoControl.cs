using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleAmmoControl : MonoBehaviour {

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
            hit.gameObject.GetComponent<Shoot>().AddRifleAmmo();
            Destroy(this.gameObject);
        }
    }

}
