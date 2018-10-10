using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scan : MonoBehaviour {

    public GameObject RayEmitter;
    public GameObject Scanner;

   // public LayerMask mask = 8;


    private RaycastHit rayHit;


    void Start () {

       
}

	void Update () {

		LayerMask layerMask = ~(1 << 8);
        

        if (Input.GetMouseButton(0) && Scanner.activeSelf == true)
        {
            Vector3 fwd = Scanner.transform.TransformDirection(Vector3.forward);
            Debug.DrawRay(RayEmitter.transform.position, fwd);
            Ray ray = new Ray(RayEmitter.transform.position, fwd);
			RaycastHit[] hits = Physics.RaycastAll(ray, 10f, layerMask);
			Debug.Log (hits[0].transform.tag);
            foreach(RaycastHit rayHit in hits)
            {
                if (rayHit.collider.transform.tag == "Scannable")
                {
					Debug.Log ("hit");
					Renderer renderer = rayHit.collider.transform.gameObject.GetComponent<Renderer> ();
					renderer.enabled = true;
                    Color colorAlpha = renderer.material.color;
//					colorAlpha.a = 0f;
//                    colorAlpha.a += 1.2f;
                    rayHit.collider.transform.gameObject.GetComponent<Renderer>().material.color = colorAlpha;
                }
            }
        }
	}
}
