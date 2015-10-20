using UnityEngine;
using System.Collections;

public class movePlayer : MonoBehaviour {

	bool firstPerson = false;
	public bool zoomable = true; // possibility of a glasses-like item enabling zoom
	bool zoomed = false;
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
			//Debug.Log ("SWITCH");
			//Debug.Log (firstPerson.ToString());
		}
		//Debug.Log(zoomable);		
		if (firstPerson) {

			//Camera.main.transform.position = transform.position;
			Camera.main.transform.eulerAngles += new Vector3(-Input.GetAxis("CamVertical"), 
			                                                 Input.GetAxis("CamHorizontal"), 0f);

			if (zoomable) {
				Debug.Log ("IN");
				if (Input.GetKeyDown(KeyCode.Z)) {
					zoomed = !zoomed;
					Debug.Log (zoomed);
				}
			}

			Camera.main.fieldOfView = (zoomed) ? 45f : 60f;
		}
		else {
			inputVector = new Vector3( 0f, 0f, Input.GetAxis ("Vertical") );
			transform.eulerAngles += new Vector3(0f, Input.GetAxis("Horizontal") * 60f * Time.deltaTime,0f);
		}


	}

	void FixedUpdate () {
		rbody.velocity = (firstPerson) ? Vector3.zero : transform.TransformDirection(inputVector * 5f);
	}
}
