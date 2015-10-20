using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class interactionPage2 : MonoBehaviour {
	
	public Text info;
	public movePlayer player;
	//public Collider glasses;
	public backpack backpack;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter (Collider activator) {
		info.text = "You got some graded drawings. You can add this to your paper.";
		//Destroy(this.gameObject);
		this.gameObject.transform.position = new Vector3(0f, 100f, 0f);
		player.zoomable = true;
		backpack.items["PAGE 2*"] = true;
		
		
	}
}
