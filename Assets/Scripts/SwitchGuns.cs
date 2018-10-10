using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGuns : MonoBehaviour {

    public GameObject Scanner;
    public GameObject Rifle;
	public GameObject Pistol;
	public GameObject Shotgun;
	public GameObject NoAim;
	public GameObject Reloading;

	public GameObject PistolGun;
	public GameObject PistolHand;
	public GameObject RifleGun;
	public GameObject ShotgunGun;
	public GameObject ScannerGun;

	private bool pistolRotate;
	private bool pistolRotateHand;
	private bool rifleRotate;
	private bool shotgunRotate;
	private bool scannerRotate;

	private int rotateTimes = 1;
	private int rotateTimes2 = 1;

	void Start () {
        Scanner.SetActive(false);
        Rifle.SetActive (true);
		Pistol.SetActive (false);
		Shotgun.SetActive (false);
	}
	

	void Update () {

	

		if (Input.GetKeyDown (KeyCode.Alpha1)) {
            Scanner.SetActive(false);
            Rifle.SetActive(true);
            Pistol.SetActive(false);
            Shotgun.SetActive(false);
			Reloading.SetActive (false);
			RifleGun.transform.localEulerAngles = new Vector3 (90f, 0f, 0f);
			rifleRotate = true;
        }

		if (Input.GetKeyDown (KeyCode.Alpha2)) {
            Scanner.SetActive(false);
            Rifle.SetActive(false);
            Pistol.SetActive(true);
            Shotgun.SetActive(false);
			Reloading.SetActive (false);
			PistolHand.transform.localEulerAngles = new Vector3 (90f, 0f, 0f);
			pistolRotate = true;
			pistolRotateHand = true;
        }

		if (Input.GetKeyDown (KeyCode.Alpha3)) {
            Scanner.SetActive(false);
            Rifle.SetActive(false);
            Pistol.SetActive(false);
            Shotgun.SetActive(true);
			Reloading.SetActive (false);
			ShotgunGun.transform.localEulerAngles = new Vector3 (-90f, 0f, 0f);
			shotgunRotate = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Scanner.SetActive(true);
            Rifle.SetActive(false);
            Pistol.SetActive(false);
            Shotgun.SetActive(false);
			Reloading.SetActive (false);
			ScannerGun.transform.localPosition = new Vector3 (0f, 0f, -0.4f);
			scannerRotate = true;
        }
		if(pistolRotate)
		{
			PistolGun.transform.Rotate (-30.4166667f, 0f, 0f);
			rotateTimes++;
			if(rotateTimes >= 25)
			{
				pistolRotate = false;
				rotateTimes = 1;
				PistolGun.transform.localEulerAngles = new Vector3 (0f, 0f, 0f);
			}
		}
		if(pistolRotateHand)
		{
			PistolHand.transform.Rotate (-5.625f, 0f, 0f);
			rotateTimes2++;
			if(rotateTimes2 >= 17)
			{
				pistolRotateHand = false;
				rotateTimes2 = 1;
				PistolHand.transform.localEulerAngles = new Vector3 (0f, 0f, 0f);
			}
		}
		if(rifleRotate)
		{
			RifleGun.transform.Rotate (-5.625f, 0f, 0f);
			rotateTimes++;
			if(rotateTimes >= 17)
			{
				rifleRotate = false;
				rotateTimes = 1;
				RifleGun.transform.localEulerAngles = new Vector3 (0f, 0f, 0f);
			}
		}
		if(shotgunRotate)
		{
			ShotgunGun.transform.Rotate (5.625f, 0f, 0f);
			rotateTimes++;
			if(rotateTimes >= 17)
			{
				shotgunRotate = false;
				rotateTimes = 1;
				ShotgunGun.transform.localEulerAngles = new Vector3 (0f, 0f, 0f);
			}
		}
		if(scannerRotate)
		{
			ScannerGun.transform.Translate (0f, 0f, 0.025f);
			rotateTimes++;
			if(rotateTimes >= 17)
			{
				scannerRotate = false;
				rotateTimes = 1;
				ScannerGun.transform.localPosition = new Vector3 (0f, 0f, 0f);
			}
		}
    }
}
