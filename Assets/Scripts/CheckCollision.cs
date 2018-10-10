using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour {
   /*
    public List<GameObject> toIgnore;
    public static int num = 0;
    public bool isEnabled = true, hit = false;
    int myNum = 0;

	// Use this for initialization
	void Start () {
        Invoke("DestroyCollider", 0.5f);
        num++;
        myNum = num;
	}

    public void DestroyCollider()
    {
       // Debug.Log("destroy");
        isEnabled = false;
        GetComponent<BoxCollider>().enabled = false;
    }

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log(col.gameObject.tag);
        if (!hit && isEnabled && !toIgnore.Contains(col.gameObject) && col.gameObject.transform.parent == null)
        {
            hit = true;
            Debug.Log("Destroying: " + gameObject.name + " Pos" + myNum + "|" + col.gameObject.name);
            Destroy(gameObject);
        }

    }

    public void IgnoreThis(GameObject objToIgnore)
    {
        toIgnore.Add(objToIgnore);
        //Debug.Log(gameObject + "|" + objToIgnore);
            objToIgnore.GetComponent<CheckCollision>().toIgnore.Add(gameObject);
    }
  
    */

}
