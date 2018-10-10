using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHoleDeleteSelf : MonoBehaviour {

	void Start () {
        StartCoroutine(DestroyBulletHole());
	}

	void Update () {
		
	}

    IEnumerator DestroyBulletHole()
    {
        yield return new WaitForSeconds(6f);
        Destroy(this.gameObject);
    }

}
