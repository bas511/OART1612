using UnityEngine;
using System.Collections;

public class startGame1 : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.S)){
			Application.LoadLevel (1);
		}
	}
}
