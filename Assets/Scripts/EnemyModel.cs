using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyModel : MonoBehaviour
{

	public Image healthBar;

	public float health;

	public GameObject Head;
	public GameObject EnemyDrone;


	private float initialHealth;


	private GameObject PlayerHead;
	private GameObject Player;

	void Start()
	{
		Player = GameObject.Find("Player");
		PlayerHead = GameObject.Find("Player/FirstPersonCharacter");
		health = 10;
		initialHealth = healthBar.transform.localScale.x;
	}

	void Update()
	{
		Head.transform.LookAt(Player.transform);
		EnemyDrone.transform.LookAt(PlayerHead.transform);




		if (health <= 0)
		{
			Destroy(this.gameObject);
		}
		//

		RaycastHit rayHit;

		Vector3 fwd = EnemyDrone.transform.TransformDirection(Vector3.forward);




	}
		

	public void subtractHealth()
	{
		health -= 1.00f;
		healthBar.transform.localScale = new Vector2(healthBar.transform.localScale.x - initialHealth * 0.1f, healthBar.transform.localScale.y);
	}

}