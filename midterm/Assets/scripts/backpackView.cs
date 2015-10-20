using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class backpackView : MonoBehaviour {

	public Camera backpackCam;
	public backpack pack;
	public Text itemlist;
	public Text arrow;
	int packRow = 1;
	int itemTrue = 1;
	bool isOn;
	bool showingDesc = false;
	float descTimer = 0f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		itemTrue = 0;
		if (Input.GetKeyDown(KeyCode.B)) {
			isOn = !isOn;
		}

		itemlist.text = "";
		arrow.text = "";
		foreach (KeyValuePair<string, bool> pair in pack.items) {
			if (pair.Value) {
				itemlist.text += pair.Key + "\n";
				itemTrue++;
			}
		}
		backpackCam.enabled = isOn;

		if (itemlist.text != "" && backpackCam.enabled) {
			if (packRow < itemTrue) {
				if (Input.GetKeyDown (KeyCode.DownArrow)) {
					packRow++;
				}
			} 
			if (packRow > 1) {
				if (Input.GetKeyDown (KeyCode.UpArrow)) {
					packRow--;
				}
			}

			for (int i = 1; i < packRow; i++) {
				arrow.text += "\n";
			}
			arrow.text += "→";
			/*
			if (Input.GetKeyDown (KeyCode.Space)) {
				showingDesc = true;
				descTimer = 5f;
			}

			if (descTimer > 0) {
				int itemNum = packRow - 1;
				Debug.Log (pack.desc.Keys.)
				descTimer -= Time.deltaTime;
			}
		*/
			Debug.Log(packRow.ToString());
			//Debug.Log (arrow.text);
		}


	}
}
