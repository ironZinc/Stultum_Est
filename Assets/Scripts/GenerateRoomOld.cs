using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRoomOld : MonoBehaviour {

    public List<GameObject> prefabs;

    private int numRooms, roomsCreated = 0;

    EntryPoint pt = null;

    [Range(0f, 3f)]
    public float timeWaiting = 1f;

	// Use this for initialization
	void Start () {
        GenerateRooms();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GenerateRooms()
    {
        numRooms = 40;
        StartCoroutine(CreateRooms(GetPoints(gameObject)));
    }

    EntryPoint[] GetPoints(GameObject parent)
    {
        if (parent != null)
            return parent.transform.GetComponentsInChildren<EntryPoint>();
        else return new EntryPoint[0];
    }

    GameObject PickRandomRoom()
    {
        return Instantiate(prefabs[Random.Range(0, prefabs.Count - 2)]);
    }

    IEnumerator CreateRooms(EntryPoint[] points)
    {
        foreach (EntryPoint point in points)
        {
            if (point != null && !point.isUsed)
            {
                GameObject room;
                if (roomsCreated < numRooms)
                    room = PickRandomRoom();
                else if (!GameObject.Find("End(Clone)"))
                {
                    room = Instantiate(prefabs[prefabs.Count - 1]);
                }
                else
                    break;
                if (room != null && point != null && point.transform.parent.gameObject != null)
                {
                    //Debug.Log(point.transform.parent);
                   //room.GetComponent<CheckCollision>().IgnoreThis(point.transform.parent.gameObject);
                    //  Debug.Log("created");
                    roomsCreated++;
                }
                else
                {
                    //find a new dad
                }
                yield return new WaitForSeconds(timeWaiting);
                EntryPoint[] newPoints = GetPoints(room);
                RotateNewRoom(point, newPoints, room);
                yield return new WaitForSeconds(timeWaiting);
                if (room != null && point != null)
                {
                    //room.GetComponent<CheckCollision>().Invoke("DestroyCollider", 0.2f);
                    int pointNum = Random.Range(0, newPoints.Length);
                    if (newPoints.Length > 0 && newPoints[pointNum] != null)
                    {
                        if (point.transform.parent.gameObject.name != "Start")
                        {
                            //point.transform.parent.gameObject.GetComponent<CheckCollision>().IgnoreThis(newPoints[0].transform.parent.gameObject);
                        }
                        newPoints[pointNum].transform.parent = null;
                        //turn off new points mesh to open walls
                        room.transform.SetParent(newPoints[pointNum].transform, true);
                        newPoints[pointNum].transform.position = point.transform.position;
                        room.transform.parent = null;
                        newPoints[pointNum].transform.parent = room.transform;
                        newPoints[pointNum].isUsed = true;
                        point.isUsed = true;

                    }
                //Debug.Log(roomsCreated);
                    //  yield return new WaitForSeconds(timeWaiting);
                    if (roomsCreated < numRooms)
                        StartCoroutine(CreateRooms(newPoints));
                }
                else
                {
                    //find a new dad
                }
            }
        }
    }

    void AddTagToChildren (GameObject obj)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.tag = "lastMade";
        }
    }

    void RemoveTagFromChildren (GameObject obj)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.tag = "Untagged";
        }

    }

    void RotateNewRoom( EntryPoint mine, EntryPoint[] theirs, GameObject room)
    {
        if (theirs.Length > 0)
        {
            int rot = 0;
            switch (mine.dir)
            {
                case Direction.up:
                    switch (theirs[0].dir)
                    {
                        case Direction.up:
                            room.transform.rotation = Quaternion.Euler(room.transform.eulerAngles.x, room.transform.eulerAngles.y + 180, room.transform.eulerAngles.z);
                            rot = 180;
                            break;
                        case Direction.left:
                            room.transform.rotation = Quaternion.Euler(room.transform.eulerAngles.x, room.transform.eulerAngles.y - 90, room.transform.eulerAngles.z);
                            rot = -90;
                            break;
                        case Direction.right:
                            room.transform.rotation = Quaternion.Euler(room.transform.eulerAngles.x, room.transform.eulerAngles.y + 90, room.transform.eulerAngles.z);
                            rot = 90;
                            break;
                    }
                    break;
                case Direction.down:
                    switch (theirs[0].dir)
                    {
                        case Direction.down:
                            room.transform.rotation = Quaternion.Euler(room.transform.eulerAngles.x, room.transform.eulerAngles.y + 180, room.transform.eulerAngles.z);
                            rot = 180;
                            break;
                        case Direction.left:
                            room.transform.rotation = Quaternion.Euler(room.transform.eulerAngles.x, room.transform.eulerAngles.y + 90, room.transform.eulerAngles.z);
                            rot = 90;
                            break;
                        case Direction.right:
                            room.transform.rotation = Quaternion.Euler(room.transform.eulerAngles.x, room.transform.eulerAngles.y - 90, room.transform.eulerAngles.z);
                            rot = -90;
                            break;
                    }
                    break;
                case Direction.left:
                    switch (theirs[0].dir)
                    {
                        case Direction.left:
                            room.transform.rotation = Quaternion.Euler(room.transform.eulerAngles.x, room.transform.eulerAngles.y + 180, room.transform.eulerAngles.z);
                            rot = 180;
                            break;
                        case Direction.up:
                            room.transform.rotation = Quaternion.Euler(room.transform.eulerAngles.x, room.transform.eulerAngles.y - 90, room.transform.eulerAngles.z);
                            rot = -90;
                            break;
                        case Direction.down:
                            room.transform.rotation = Quaternion.Euler(room.transform.eulerAngles.x, room.transform.eulerAngles.y + 90, room.transform.eulerAngles.z);
                            rot = 90;
                            break;
                    }
                    break;
                case Direction.right:
                    switch (theirs[0].dir)
                    {
                        case Direction.right:
                            room.transform.rotation = Quaternion.Euler(room.transform.eulerAngles.x, room.transform.eulerAngles.y + 180, room.transform.eulerAngles.z);
                            rot = 180;
                            break;
                        case Direction.down:
                            room.transform.rotation = Quaternion.Euler(room.transform.eulerAngles.x, room.transform.eulerAngles.y - 90, room.transform.eulerAngles.z);
                            rot = -90;
                            break;
                        case Direction.up:
                            room.transform.rotation = Quaternion.Euler(room.transform.eulerAngles.x, room.transform.eulerAngles.y + 90, room.transform.eulerAngles.z);
                            rot = 90;
                            break;
                    }
                    break;
            }
            if (rot != 0)
                RotateNewPoints(theirs, rot);
        }
    }
    void RotateNewPoints(EntryPoint[] points, int changeAmt)
    {
        foreach (EntryPoint pt in points)
        {
            switch (changeAmt)
            {
                case 90:
                    switch (pt.dir)
                    {
                        case Direction.left:
                            pt.dir = Direction.up;
                            break;
                        case Direction.up:
                            pt.dir = Direction.right;
                            break;
                        case Direction.right:
                            pt.dir = Direction.down;
                            break;
                        case Direction.down:
                            pt.dir = Direction.left;
                            break;
                    }
                    break;
                case 180:
                    switch (pt.dir)
                    {
                        case Direction.left:
                            pt.dir = Direction.right;
                            break;
                        case Direction.up:
                            pt.dir = Direction.down;
                            break;
                        case Direction.right:
                            pt.dir = Direction.left;
                            break;
                        case Direction.down:
                            pt.dir = Direction.up;
                            break;
                    }
                    break;
                case -90:
                    switch (pt.dir)
                    {
                        case Direction.left:
                            pt.dir = Direction.down;
                            break;
                        case Direction.up:
                            pt.dir = Direction.left;
                            break;
                        case Direction.right:
                            pt.dir = Direction.up;
                            break;
                        case Direction.down:
                            pt.dir = Direction.right;
                            break;
                    }
                    break;
                
            }
        }
    }
}
