using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Activity : MonoBehaviour {

	public OutlineSystem outlinSystem;

	bool isShow = false;

	//所属部门
	public NameLibrary.DEPARTMENT departmentIndex = 0;
	//过程索引
	public NameLibrary.ACTIVITY activityIndex = 0;

	// Use this for initialization
	void Start () {
//		outlinSystem = GameObject.Find ("Outline System").GetComponent<OutlineSystem> ();
//		outlinSystem.outlineLayer = LayerMask.GetMask ("Activity");
//		outlinSystem.mainCamera = Camera.main;
//		Material mat = new Material(Shader.Find("Assets/Folder/Shader/MobileBulr"));
//		outlinSystem.blurMaterial = mat;
	}

	public int GetDepartment() {
		return (int)departmentIndex;
	}

	public int GetActivity() {
		return (int)activityIndex;
	}

	void OnMouseEnter(){
//		Debug.Log ("Mouse Enter");
		if(!EventSystem.current.IsPointerOverGameObject())
			isShow = true;
	}
	void OnMouseExit(){
//		Debug.Log ("Mouse Exit");
		isShow = false;
	}

	void OnGUI() {
		if(isShow){
			Vector2 pos = Camera.main.WorldToScreenPoint (transform.position);
			pos = new Vector2 (pos.x, Screen.height - pos.y);
			string name = NameLibrary.activity [(int)departmentIndex] [(int)activityIndex];
			Vector2 nameSize = GUI.skin.label.CalcSize (new GUIContent (name));
			GUI.Label (new Rect (pos.x - (nameSize.x / 2), pos.y, nameSize.x, nameSize.y), name);
		}
	}
}
