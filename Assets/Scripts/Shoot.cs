using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shoot : MonoBehaviour

{
	
	public GameObject Bullet_Emitter_Rifle;
	public GameObject Bullet_Emitter_Pistol;
	public GameObject Bullet_Emitter_Shotgun1;
	public GameObject Bullet_Emitter_Shotgun2;
	public GameObject Bullet_Emitter_Shotgun3;
	public GameObject Bullet_Emitter_Shotgun4;
	public GameObject Bullet_Emitter_Shotgun5;
	public GameObject Bullet;
    public GameObject ShotgunBullet;
	public GameObject Rifle;
	public GameObject Pistol;
	public GameObject Shotgun;
	public GameObject Scanner;
	public GameObject AimRifle;
	public GameObject AimPistol;
	public GameObject AimShotgun;
	public GameObject NoAim;
	public GameObject Reloading;
	public GameObject OutOfAmmo;

    public AudioSource audio;

	public bool ready = true;
	public bool RifleAimBool = false;
	public bool PistolAimBool = false;
	public bool ShotgunAimBool = false;

	public GameObject recoilRifle;
	public GameObject recoilPistol;
	public GameObject recoilShotgun;

    public Text AmmoText;

	public float Bullet_Forward_Speed;
	public float Bullet_Up_Speed;

	public GameObject AimPos;


	public int RifleAmmo;
	public int PistolAmmo;
	public int ShotgunShells;
	public int RifleAmmoTotal;
	public int ShotgunShellsTotal;

	void Start ()
	{
        RifleAmmo = 30;
		PistolAmmo = 15;
        ShotgunShells = 6;
		RifleAmmoTotal = 30;
		ShotgunShellsTotal = 6;
	}

    
	void Update ()
	{

        if (Rifle.activeSelf)
        {
			AmmoText.text = RifleAmmo.ToString() + "/" + RifleAmmoTotal.ToString();
        }
        else if (Pistol.activeSelf)
        {
			AmmoText.text = PistolAmmo.ToString() + "/" + "Infinite";
        }
        else if (Shotgun.activeSelf)
        {
			AmmoText.text = ShotgunShells.ToString() + "/" + ShotgunShellsTotal.ToString();
        }
		else if (Scanner.activeSelf)
		{
			AmmoText.text = "N/A";
		}

        if (Input.GetKey(KeyCode.Mouse1))
		{
            Rifle.transform.position = AimPos.transform.position;
            Pistol.transform.position = AimPos.transform.position;
			Shotgun.transform.position = AimPos.transform.position;
			RifleAimBool = true;
			PistolAimBool = true;
			ShotgunAimBool = true;
		} else
        {
            Rifle.transform.position = NoAim.transform.position;
            Pistol.transform.position = NoAim.transform.position;
            Shotgun.transform.position = NoAim.transform.position;
            RifleAimBool = false;
            PistolAimBool = false;
            ShotgunAimBool = false;
        }

		if (ready && RifleAimBool == false)
		{
			Rifle.transform.position = NoAim.transform.position;
		}
		else if (ready && RifleAimBool == true)
		{
			Rifle.transform.position = AimPos.transform.position;
		}

		if (ready && PistolAimBool == false)
		{
			Pistol.transform.position = NoAim.transform.position;
		}
		else if (ready && PistolAimBool == true)
		{
			Pistol.transform.position = AimPos.transform.position;
		}

		if (ready && ShotgunAimBool == false)
		{
			Shotgun.transform.position = NoAim.transform.position;
		}
		else if (ready && ShotgunAimBool == true)
		{
			Shotgun.transform.position = AimPos.transform.position;
		}


		if (Input.GetKey (KeyCode.Mouse0) && Rifle.activeSelf && ready && RifleAmmo > 0) {
			

			GameObject Temporary_Bullet_Handler;
			Temporary_Bullet_Handler = Instantiate (Bullet, Bullet_Emitter_Rifle.transform.position, Bullet_Emitter_Rifle.transform.rotation) as GameObject;
            RifleAmmo -= 1;
            audio.Play();

			Temporary_Bullet_Handler.transform.Rotate (Vector3.left * 90);


			Rigidbody Temporary_RigidBody;
			Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody> ();


			Temporary_RigidBody.velocity = Camera.main.transform.forward * 180;
			//Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Speed);
			Temporary_RigidBody.AddForce (transform.up * Bullet_Up_Speed);
			StartCoroutine (recoilDelayRifle());

			Destroy (Temporary_Bullet_Handler, 5.0f);
		}
			

			if (Input.GetKeyDown(KeyCode.Mouse0) && Pistol.activeSelf && ready) {
			

				GameObject Temporary_Bullet_Handler;
				Temporary_Bullet_Handler = Instantiate (Bullet, Bullet_Emitter_Pistol.transform.position, Bullet_Emitter_Pistol.transform.rotation) as GameObject;
			PistolAmmo -= 1;
			audio.Play();

                Temporary_Bullet_Handler.transform.Rotate (Vector3.left * 90);


				Rigidbody Temporary_RigidBody;
				Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody> ();


				Temporary_RigidBody.velocity = Camera.main.transform.forward * 180;
				//Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Speed);
				Temporary_RigidBody.AddForce (transform.up * Bullet_Up_Speed);

				StartCoroutine (recoilDelayPistol ());

				Destroy (Temporary_Bullet_Handler, 5.0f);
			}

		if (Input.GetKeyDown(KeyCode.Mouse0) && Shotgun.activeSelf && ready && ShotgunShells > 0) {
			

				GameObject Temporary_Bullet_Handler1;
				GameObject Temporary_Bullet_Handler2;
				GameObject Temporary_Bullet_Handler3;
				GameObject Temporary_Bullet_Handler4;
				GameObject Temporary_Bullet_Handler5;
				Temporary_Bullet_Handler1 = Instantiate (ShotgunBullet, Bullet_Emitter_Shotgun1.transform.position, Bullet_Emitter_Shotgun1.transform.rotation) as GameObject;
				Temporary_Bullet_Handler2 = Instantiate (ShotgunBullet, Bullet_Emitter_Shotgun2.transform.position, Bullet_Emitter_Shotgun2.transform.rotation) as GameObject;
				Temporary_Bullet_Handler3 = Instantiate (ShotgunBullet, Bullet_Emitter_Shotgun3.transform.position, Bullet_Emitter_Shotgun3.transform.rotation) as GameObject;
				Temporary_Bullet_Handler4 = Instantiate (ShotgunBullet, Bullet_Emitter_Shotgun4.transform.position, Bullet_Emitter_Shotgun4.transform.rotation) as GameObject;
				Temporary_Bullet_Handler5 = Instantiate (ShotgunBullet, Bullet_Emitter_Shotgun5.transform.position, Bullet_Emitter_Shotgun5.transform.rotation) as GameObject;
                ShotgunShells -= 1;
             audio.Play();

            Temporary_Bullet_Handler1.transform.Rotate (Vector3.left * 90);
				Temporary_Bullet_Handler2.transform.Rotate (Vector3.left * 90);
				Temporary_Bullet_Handler3.transform.Rotate (Vector3.left * 90);
				Temporary_Bullet_Handler4.transform.Rotate (Vector3.left * 90);
				Temporary_Bullet_Handler5.transform.Rotate (Vector3.left * 90);


				Rigidbody Temporary_RigidBody1;
				Rigidbody Temporary_RigidBody2;
				Rigidbody Temporary_RigidBody3;
				Rigidbody Temporary_RigidBody4;
				Rigidbody Temporary_RigidBody5;
				Temporary_RigidBody1 = Temporary_Bullet_Handler1.GetComponent<Rigidbody> ();
				Temporary_RigidBody2 = Temporary_Bullet_Handler2.GetComponent<Rigidbody> ();
				Temporary_RigidBody3 = Temporary_Bullet_Handler3.GetComponent<Rigidbody> ();
				Temporary_RigidBody4 = Temporary_Bullet_Handler4.GetComponent<Rigidbody> ();
				Temporary_RigidBody5 = Temporary_Bullet_Handler5.GetComponent<Rigidbody> ();


				Temporary_RigidBody1.velocity = Camera.main.transform.forward * 90;
				Temporary_RigidBody2.velocity = Camera.main.transform.forward * 90;
				Temporary_RigidBody3.velocity = Camera.main.transform.forward * 90;
				Temporary_RigidBody4.velocity = Camera.main.transform.forward * 90;
				Temporary_RigidBody5.velocity = Camera.main.transform.forward * 90;
				//Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Speed);

			StartCoroutine (recoilDelayShotgun ());

//			ready = false;
//			//Shotgun.transform.position = recoilShotgun.transform.position;
//			recoilDelayShotgun ();
//
//			//Shotgun.transform.position = NoAim.transform.position;
//			ready = true;

				Destroy (Temporary_Bullet_Handler1, 5.0f);
				Destroy (Temporary_Bullet_Handler2, 5.0f);
				Destroy (Temporary_Bullet_Handler3, 5.0f);
				Destroy (Temporary_Bullet_Handler4, 5.0f);
				Destroy (Temporary_Bullet_Handler5, 5.0f);
			}


		if (Input.GetKeyDown (KeyCode.R) && Rifle.activeSelf && RifleAmmo != 30 && RifleAmmoTotal != 0) {
			StartCoroutine (reloadRifle ());
		} else if (Rifle.activeSelf && RifleAmmo == 0 && RifleAmmoTotal != 0) {
			StartCoroutine (reloadRifle ());
		} else if (Rifle.activeSelf && RifleAmmo == 0 && RifleAmmoTotal == 0) {
			OutOfAmmo.SetActive (true);
		}else {OutOfAmmo.SetActive (false);}
		if (Input.GetKeyDown (KeyCode.R) && Pistol.activeSelf && PistolAmmo != 15)
		{
			StartCoroutine (reloadPistol());
		} else if (Pistol.activeSelf && PistolAmmo == 0) {
			StartCoroutine (reloadPistol());
		}else {OutOfAmmo.SetActive (false);}
		if (Input.GetKeyDown (KeyCode.R) && Shotgun.activeSelf && ShotgunShells != 6 && ShotgunShellsTotal != 0) {
			StartCoroutine (reloadShotgun ());
		} else if (Shotgun.activeSelf && ShotgunShells == 0 && ShotgunShellsTotal != 0) {
			StartCoroutine (reloadShotgun ());
		} else if (Shotgun.activeSelf && ShotgunShells == 0 && ShotgunShellsTotal == 0) {
			OutOfAmmo.SetActive (true);
		} else {OutOfAmmo.SetActive (false);}




	}
		
	IEnumerator reloadRifle()
	{
		AmmoText.text = "0/" + RifleAmmoTotal;
		int rifleAmmoNeeded = 30 - RifleAmmo;
		Reloading.SetActive (true);
		Rifle.SetActive (false);
		yield return new WaitForSeconds (2.25f);
		if(!Pistol.activeSelf && !Shotgun.activeSelf)
		{
			RifleAmmoTotal -= rifleAmmoNeeded;
			RifleAmmo += rifleAmmoNeeded;
			if(RifleAmmoTotal < 0)
			{
				int lessThan = -RifleAmmoTotal;
				RifleAmmoTotal += lessThan;
				RifleAmmo -= lessThan;
			}
			Rifle.SetActive (true);
			Reloading.SetActive (false);
		}

	}
	IEnumerator reloadPistol()
	{
		AmmoText.text = "0/Infinite";
		Reloading.SetActive (true);
		Pistol.SetActive (false);
		yield return new WaitForSeconds (2f);
		if(!Rifle.activeSelf && !Shotgun.activeSelf)
		{
			PistolAmmo = 15;
			Pistol.SetActive (true);
			Reloading.SetActive (false);
		}

	}
	IEnumerator reloadShotgun()
	{
		AmmoText.text = "0/" + ShotgunShellsTotal;
		int ShotgunShellsNeeded = 6 - ShotgunShells;
		Reloading.SetActive (true);
		Shotgun.SetActive (false);
		yield return new WaitForSeconds (2.5f);
		if(!Pistol.activeSelf && !Rifle.activeSelf)
		{
			ShotgunShellsTotal -= ShotgunShellsNeeded;
			ShotgunShells += ShotgunShellsNeeded;
			if(ShotgunShellsTotal < 0)
			{
				int lessThan = -ShotgunShellsTotal;
				ShotgunShellsTotal += lessThan;
				ShotgunShells -= lessThan;
			}
			Shotgun.SetActive (true);
			Reloading.SetActive (false);
		}

	}

	IEnumerator recoilDelayRifle(){
		ready = false;
		Rifle.transform.position = recoilRifle.transform.position;
		yield return new WaitForSeconds (0.1f);	
		ready = true;
    }

	IEnumerator recoilDelayPistol(){
		ready = false;
		Pistol.transform.position = recoilPistol.transform.position;

		yield return new WaitForSeconds (0.3f);

        ready = true;
    }

	IEnumerator recoilDelayShotgun(){
		ready = false;
		Shotgun.transform.position = recoilShotgun.transform.position;
		yield return new WaitForSeconds (1f);

        ready = true;

	}

    public void AddRifleAmmo()
    {
        RifleAmmoTotal += 30;
    }

    public void AddShotgunShells()
    {
        ShotgunShellsTotal += 6;
    }



}