using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extend : MonoBehaviour {

	public GameObject panel;

	GameObject inputField;
	bool isShow = false;
	// Use this for initialization
	void Start () {
		inputField = GameObject.Find ("InputField");
		if (!inputField)
			Debug.Log ("inputField is null");
		inputField.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPointerOver() {

		if (!isShow) {
			//延展底框宽度
			Rect rec = panel.GetComponent<RectTransform> ().rect;
			rec.width = rec.width * 3f;		//此处需要修改一下，固定数值会导致通用性不好
			panel.GetComponent<RectTransform> ().sizeDelta = new Vector2 (rec.width, rec.height);
			//创建Editor
			if (inputField) {
				inputField.SetActive (!isShow);
			}
			isShow = !isShow;
		}
	}

	public void OnPointerExit() {

		if (isShow) {
			//延展底框宽度
			Rect rec = panel.GetComponent<RectTransform> ().rect;
			rec.width = rec.width / 3f;
			panel.GetComponent<RectTransform> ().sizeDelta = new Vector2 (rec.width, rec.height);
			//创建Editor
			if (inputField) {
				inputField.SetActive (!isShow);
			}
			isShow = !isShow;
		}
	}
}
