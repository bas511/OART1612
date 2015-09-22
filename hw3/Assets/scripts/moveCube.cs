using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class moveCube : MonoBehaviour {

	public float moveSpeed = 50f;
	public Transform goal;
	public Transform rings;
	public Transform wrong;
	public Text directionText;
	public Text hintText;

	string[] directions = {"N", "NE", "E", "SE", "S", "SW", "W", "NW" };

	// Update is called once per frame
	void Update () {

		rings.eulerAngles += new Vector3(Mathf.Cos(Time.time * 10) *  5f, Time.deltaTime * 10 *  5f, Mathf.Sin(Time.time * 10) *  5f) ;

		// when moving diagonally, divide by sqrt(2) to make actual speed the same as moving straight
		float diagSpeed = moveSpeed / 1.414f;

		// check for double input first (moving diagonally)
		if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)) {
			transform.position += new Vector3(diagSpeed * Time.deltaTime, 0, diagSpeed * Time.deltaTime);
			transform.eulerAngles = new Vector3(0f, 45f, 0f);
		}
		else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)) {
			transform.position += new Vector3(diagSpeed * Time.deltaTime, 0, -diagSpeed * Time.deltaTime);
			transform.eulerAngles = new Vector3(0f, 135f, 0f);
		}
		else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)) {
			transform.position += new Vector3(-diagSpeed * Time.deltaTime, 0, -diagSpeed * Time.deltaTime);
			transform.eulerAngles = new Vector3(0f, 225f, 0f);
		}
		else if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)) {
			transform.position += new Vector3(-diagSpeed * Time.deltaTime, 0, diagSpeed * Time.deltaTime);
			transform.eulerAngles = new Vector3(0f, 315f, 0f);
		}
		// now check single inputs
		else if(Input.GetKey(KeyCode.W)) {
			transform.position += new Vector3(0, 0, moveSpeed * Time.deltaTime);
			transform.eulerAngles = new Vector3(0f, 0f, 0f);
		}
		else if(Input.GetKey(KeyCode.D)) {
			transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
			transform.eulerAngles = new Vector3(0f, 90f, 0f);
		}
		else if(Input.GetKey(KeyCode.S)) {
			transform.position += new Vector3(0, 0, -moveSpeed * Time.deltaTime);
			transform.eulerAngles = new Vector3(0f, 180f, 0f);
		}
		else if(Input.GetKey(KeyCode.A)) {
			transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
			transform.eulerAngles = new Vector3(0f, 270f, 0f);
		}

		if ((goal.position - transform.position).magnitude < 5f) {
			hintText.text = "YOU WIN!!!";
		} else if ((wrong.position - transform.position).magnitude < 20f) {
			hintText.text = "If you're near a cylinder with a spike through it, you're about as cold as you can get.";
		} else if (transform.position.x < -20) {
			hintText.text = "Try heading East until you see a lighthouse-looking thingy...";
		} else if (transform.position.x > 100) {
			hintText.text = "If you see a floating ring-like figure, you're headed in the right direction...";
		} else {
			hintText.text = "In the open sea, look for a landmark! It may help guide you.";
		}

		Camera.main.transform.position = transform.position + new Vector3(0f, 15f, -7f);
		directionText.text = "You are facing: " + directions[(int)(transform.eulerAngles.y / 45)];
	}
}
