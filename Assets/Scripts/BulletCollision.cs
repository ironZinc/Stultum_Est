﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour {

    public GameObject BulletHolePrefab;
    public GameObject BloodPrefab;


    private GameObject Blood1;
    private GameObject Blood2;
    private GameObject Blood3;
    private GameObject Blood4;

    private Vector3 hitPoint;


	void Start () {

    }

	void Update () {
		
	}

    void OnCollisionEnter(Collision hit)
    {
        foreach (ContactPoint contact in hit.contacts)
        {
            hitPoint = contact.point;
        }
        if (hit.gameObject.tag != "BulletHole" && hit.gameObject.tag != "Bullet" && hit.gameObject.tag != "EnemyType1" && hit.gameObject.tag != "Player" && hit.gameObject.tag != "Blood" && hit.gameObject.tag != "EnemyDrone" && hit.gameObject.tag != "RifleAmmo" && hit.gameObject.tag != "ShotgunShells")
        {
            Debug.Log(hit.gameObject);
            Instantiate(BulletHolePrefab, hitPoint, transform.rotation);
            Destroy(this.gameObject);
        } else if (hit.gameObject.tag == "Player" || hit.gameObject.tag == "Bullet")
        {
            
        }
        else if(hit.gameObject.tag == "EnemyType1")
        {
            Debug.Log("HitEnemy");
            hit.gameObject.GetComponent<EnemyType1Control>().subtractHealth();
            Destroy(this.gameObject);
            Blood1 = Instantiate(BloodPrefab, hitPoint, transform.rotation);
            Blood2 = Instantiate(BloodPrefab, hitPoint, transform.rotation);
            Blood3 = Instantiate(BloodPrefab, hitPoint, transform.rotation);
            Blood4 = Instantiate(BloodPrefab, hitPoint, transform.rotation);
        }
        else
        {
            Destroy(this.gameObject);
        }
        
        
    }

}