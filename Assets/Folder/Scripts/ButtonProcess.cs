using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonProcess : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnValueChanged(int v) {
		//做按钮处理，产生场景切换
//		DontDestroyOnLoad (GameObject.Find("Canvas Toggle"));
		switch (v) {
		case 1:
		case 2:
		case 3:
		case 4:
			SceneManager.LoadScene ("Points");
//			Application.LoadLevel("Points");
			break;
		}
	}

	public void Quit() {
		Application.Quit ();
	}
}
