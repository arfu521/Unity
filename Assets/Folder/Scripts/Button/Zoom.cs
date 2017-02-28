using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zoom : MonoBehaviour {

	// Use this for initialization
//	void Start () {
//		
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//	}

	public void ZoomIn() {
		transform.localScale = new Vector3 (1.2f, 1.2f, 1.2f);
//		Debug.Log ("ZoomIn");
	}

	public void ZoomOut() {
		transform.localScale = new Vector3 (1, 1, 1);
//		Debug.Log ("ZoomOut");
	}
}
