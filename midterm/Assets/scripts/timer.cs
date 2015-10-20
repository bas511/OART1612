using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timer : MonoBehaviour {

	float timeLeft = 40;
	public Text clock;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime / 15f;
		clock.text = ((int)(timeLeft)).ToString() + " minutes left";
	}
}
