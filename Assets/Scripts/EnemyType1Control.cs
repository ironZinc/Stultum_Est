using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyType1Control : MonoBehaviour
{

    public Image healthBar;

    public float health;

    public GameObject Head;
    public GameObject EnemyDrone;
    public GameObject EnemyBulletEmitter;
    public GameObject EnemyBulletPrefab;


    private float initialHealth;

    public bool shoot = false;
    public bool ready = true;
	public bool moveToPlayer = false;

    private GameObject PlayerHead;
    private GameObject Player;
    private GameObject EnemyBullet;
    private Rigidbody EnemyBulletRigidbody;
	private NavMeshAgent agent;
	private List<GameObject> points;


    void Start()
    {
        Player = GameObject.Find("Player");
        PlayerHead = GameObject.Find("Player/FirstPersonCharacter");
        health = 10;
        initialHealth = healthBar.transform.localScale.x;
		agent = GetComponent<NavMeshAgent>();
		points = new List<GameObject>(GameObject.FindGameObjectsWithTag ("EnemySpawn"));
    }

    void Update()
    {
        Head.transform.LookAt(Player.transform);
        EnemyDrone.transform.LookAt(PlayerHead.transform);
		if(this.gameObject.transform.position.y <= -15f)
		{
			Destroy (this.gameObject);
		}

		if(Vector3.Distance(this.gameObject.transform.position, Player.transform.position) <= 30f)
		{
			StopCoroutine (EnemyMove());
			Debug.Log ("safsdafsfsfd");
			agent.destination = Player.transform.position;
		}else {
			StartCoroutine (EnemyMove());
		}

        if (health <= 0)
        {
			agent.enabled = false;
			EnemyDrone.SetActive (false);
			healthBar.enabled = false;
			Destroy(this.gameObject, 1f);
        }
        //

        RaycastHit rayHit;

        Vector3 fwd = EnemyDrone.transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(EnemyBulletEmitter.transform.position, fwd, out rayHit))
        {
            if (rayHit.transform.tag == "Player") {
                shoot = true;
            }
        }


        StartCoroutine(EnemyDroneShoot());
    }

	IEnumerator EnemyMove()
	{
		agent.destination = points[Random.Range (0, points.Count)].transform.position;
		yield return new WaitForSeconds (5f);
		EnemyMove ();

	}

	IEnumerator EnemyDroneShoot()
    {
        //Debug.Log("testing");
        if (shoot == true && ready == true)
        {
            Debug.Log("shooting");
            EnemyBullet = Instantiate(EnemyBulletPrefab, EnemyBulletEmitter.transform.position, EnemyBulletEmitter.transform.rotation) as GameObject;
            EnemyBulletRigidbody = EnemyBullet.GetComponent<Rigidbody>();
            EnemyBulletRigidbody.velocity = EnemyDrone.transform.forward * 80;
            ready = false;
            yield return new WaitForSeconds(1f);
            ready = true;
        }
    }

    public void subtractHealth()
    {
        health -= 1.00f;
		healthBar.transform.localScale = new Vector2(healthBar.transform.localScale.x - initialHealth * 0.1f, healthBar.transform.localScale.y);
    }

}