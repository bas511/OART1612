using UnityEngine;
using System.Collections;

public class movePlayer : MonoBehaviour {

	bool firstPerson = false;
	public bool zoomable = false; // possibility of a glasses-like item enabling zoom
	//bool zoomed = false;
	Rigidbody rbody;
	Vector3 lastAngles, lastCamPos;
	Vector3 inputVector;
	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.F)) {
			if (!firstPerson) {
				lastAngles = Camera.main.transform.eulerAngles;
				lastCamPos = Camera.main.transform.position;
				Camera.main.transform.localPosition = new Vector3(0f, 0.3f, 0f);
				Camera.main.transform.eulerAngles = new Vector3(0f, lastAngles.y, 0f);
			}
			else {
				Camera.main.transform.position = lastCamPos;
				Camera.main.transform.eulerAngles = lastAngles;
			}
			firstPerson = !firstPerson;
			Debug.Log ("SWITCH");
			Debug.Log (firstPerson.ToString());
		}
		Debug.Log(zoomable);		
		if (firstPerson) {

			//Camera.main.transform.position = transform.position;
			Camera.main.transform.eulerAngles += new Vector3(-Input.GetAxis("CamVertical"), 
			                                                 Input.GetAxis("CamHorizontal"), 0f);

			//if (Input.GetAxis("CamZoom")) {
				Camera.main.transform.localPosition = Camera.main.transform.TransformDirection(0f, 0f, Input.GetAxis("CamZoom"));
			//}

			/*
			if (zoomable) {
				Camera.main.transform.position += Camera.main.transform.TransformDirection(0f, 0f, Input.GetAxis("CamZoom") * Time.deltaTime);
				if (Camera.main.transform.localPosition.z < 0) {
					Debug.Log ("STOP.");
					Debug.Log (Camera.main.transform.localPosition.z);
					Camera.main.transform.localPosition = new Vector3(0f, 0.3f, 0f);
				}

				Debug.Log (Camera.main.transform.position);
			}
			*/
		}
		else {
			inputVector = new Vector3( 0f, 0f, Input.GetAxis ("Vertical") );
			transform.eulerAngles += new Vector3(0f, Input.GetAxis("Horizontal") * 60f * Time.deltaTime,0f);
		}
		//Debug.Log(rbody.velocity);
		// Camera.main.transform.eulerAngles = new Vector3(0f, -transform.eulerAngles.y, 0f);
		//Camera.main.transform.position = 
	}

	void FixedUpdate () {
		rbody.velocity = (firstPerson) ? Vector3.zero : transform.TransformDirection(inputVector * 5f);
	}
}
