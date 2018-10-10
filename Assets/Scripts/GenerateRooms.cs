using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRooms : MonoBehaviour {

	public GameObject StartRoom;
	public GameObject EndRoom;

	public List<GameObject> chunks;

	public int maxRoomNumber = 4;
	public int currentRoomNumber;


	private GameObject NewRoom;
	private GameObject ExitPoint;
	private GameObject EntryPoint;
	private GameObject ExitPointHolder;

	private Vector3 entryPointLocalPos;

//	private GameObject[] ExitPoints;
//	private GameObject[] EntryPoints;

	private GameObject[] NewRoomChildrenList;

	void Start () {
		currentRoomNumber = 0;
		GenerateAllRooms ();
	}

	void Update () {
		
	}

	public void GenerateAllRooms()
	{

		NewRoom =  Instantiate(chunks[Random.Range(0, chunks.Count)]);
		currentRoomNumber += 1;
		NewRoomChildrenList = GameObject.FindGameObjectsWithTag("ExitPoint");
		foreach( GameObject NewRoomChildren in NewRoomChildrenList)
		{
			if(NewRoomChildren.transform.parent.gameObject == NewRoom)
			{
				ExitPointHolder = NewRoomChildren;
				ExitPointHolder.SetActive (false);
			}
		}

		ExitPoint = GameObject.FindWithTag ("ExitPoint");
		EntryPoint = GameObject.FindWithTag ("EntryPoint");
		entryPointLocalPos = EntryPoint.transform.localPosition;
		EntryPoint.transform.position = ExitPoint.transform.position;
		NewRoom.transform.position = EntryPoint.transform.position - entryPointLocalPos;
		ExitPoint.SetActive (false);
		EntryPoint.SetActive (false);
		ExitPointHolder.SetActive (true);

		if (currentRoomNumber == maxRoomNumber) {
			GameObject EndRoomObject = Instantiate (EndRoom);
			ExitPoint = GameObject.FindWithTag ("ExitPoint");
			EntryPoint = GameObject.FindWithTag ("EntryPoint");
			entryPointLocalPos = EntryPoint.transform.localPosition;
			EntryPoint.transform.position = ExitPoint.transform.position;
			EndRoomObject.transform.position = EntryPoint.transform.position - entryPointLocalPos;
			ExitPoint.SetActive (false);
			EntryPoint.SetActive (false);
			ExitPoint = null;
			EntryPoint = null;
		} else {
			NewRoom = null;
			GenerateAllRooms ();
		}
	}
}
