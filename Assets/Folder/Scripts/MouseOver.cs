using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseOver : MonoBehaviour {

	int buttonIndex;

	bool beBigger = false;
	bool beClick = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (beClick) {
			
		}
	}

	public void OnMouseClick() {

		beClick = true;
//		if (beChange) {
//			Button[] buttonArray = GetComponentsInChildren<Button> ();
//			DoZoomInOrOut (buttonArray [buttonIndex]);
//		}
	}
	public void ZoomInOrOut(int index) {
//		Button[] bt;
//		if (beBigger) {
//			bt = GetComponentsInChildren<Button> ();
//			bt[index].transform.localScale = new Vector3 (1.2f, 1.2f, 1.2f);
//		} else {
//			bt = GetComponentsInChildren<Button> ();
//			bt[index].transform.localScale = new Vector3 (1, 1, 1);
//		}
		if (index != buttonIndex) {
			buttonIndex = index;
		}

//		Button[] buttonArray = GetComponentsInChildren<Button> ();
		Toggle[] buttonArray = GetComponentsInChildren<Toggle> ();
		if (beBigger) {
			buttonArray[index].transform.localScale = new Vector3 (1, 1, 1);
		} else {
			buttonArray[index].transform.localScale = new Vector3 (1.2f, 1.2f, 1.2f);
		}
		beBigger = !beBigger;
	}

	public void DoZoomInOrOut(Button button) {

		if (beBigger) {
			button.transform.localScale = new Vector3 (1, 1, 1);
		} else {
			button.transform.localScale = new Vector3 (1.2f, 1.2f, 1.2f);
		}
		beBigger = !beBigger;
	}
}
