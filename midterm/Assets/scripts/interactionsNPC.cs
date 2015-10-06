using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class interactionsNPC : MonoBehaviour {

	public Text prompt;
	public Text dialogue;
	public Transform teacher1;
	public Transform teacher2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(transform.position, teacher1.transform.position) < 1) {
			Debug.Log ("TEACHER1");
			prompt.text = "Press 'Space' to talk.";
			if (Input.GetKeyDown(KeyCode.Space)) {
				dialogue.text = " TEACHER 1 TEXT";
			}
		} else if (Vector3.Distance(transform.position, teacher1.transform.position) > 2) {
			//prompt.text = "";
			dialogue.text = "";
		}
		if (Vector3.Distance(transform.position, teacher2.transform.position) < 1) {
			Debug.Log ("TEACHER2");
			prompt.text = "Press 'Space' to talk.";
			if (Input.GetKeyDown(KeyCode.Space)) {
				dialogue.text = " TEACHER 2 TEXT";
			}
		} else if (Vector3.Distance(transform.position, teacher2.transform.position) > 2) {
			//prompt.text = "";
			dialogue.text = "";
		}


	}
}
