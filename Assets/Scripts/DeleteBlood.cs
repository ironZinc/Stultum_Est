using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBlood : MonoBehaviour {

	void Start () {
        StartCoroutine(DestroyBlood());
	}
	
	void Update () {
		
	}

    IEnumerator DestroyBlood()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }

}
