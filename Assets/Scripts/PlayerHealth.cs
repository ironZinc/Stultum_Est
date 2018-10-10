using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {


    public Image healthBar;

    public float health = 10f;
    private float initialHealth;

    void Start () {
        initialHealth = healthBar.transform.localScale.x;
        InvokeRepeating("HealthRegen", 4f, 4f);

    }

	void Update () {
        if(health <= 0)
        {

        SceneManager.LoadScene("GameOver");
        }
	}

    public void subtractHealth()
    {
        health -= 1.00f;
        healthBar.transform.localScale = new Vector2(healthBar.transform.localScale.x - initialHealth * 0.1f, healthBar.transform.localScale.y);
    }

    void HealthRegen()
    {
        if (health < 10f) {
            health += 1.00f;
            healthBar.transform.localScale = new Vector2(healthBar.transform.localScale.x + initialHealth * 0.1f, healthBar.transform.localScale.y);
        }
    }

}
