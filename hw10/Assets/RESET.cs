using UnityEngine;
using System.Collections;

public class RESET : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ResetLevel () {
		Application.LoadLevel(Application.loadedLevel);
	}
}
