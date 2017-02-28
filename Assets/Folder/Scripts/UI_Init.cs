using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Init : MonoBehaviour {
	public GameObject Canvas;
//	public GameObject MainCamera;
	public GUISkin mySkin;
//	public Texture image;
	public GameObject text;

	//部门列表框

//	GameObject SelectedGameObject = null;
	GameObject CanvHandle;
	GameObject InfoTip;
	GameObject ResultPanel;
//	GameObject ResultContent;
//	//列表框标题文本
//	Text labelText;
//	//列表框内活动按钮
//	Button[] resultButton;
//
//	Vector3 CameraOriginPos;
//
//	//列表项添加到的父物体对象
//	ToggleGroup DepartmentList;
//	ScrollRect ScrollView;
//	Text InfoTipText;
//
//	int departmentIndex = 0;
//	int activityIndex = 0;
//	bool isShow = false;

	void Awake() {
//		DepartmentList = GameObject.Find (Canvas.name + "/Department Panel").GetComponent<ToggleGroup>();
		InfoTip = GameObject.Find (Canvas.name + "/InfoTip");
//		InfoTipText = InfoTip.GetComponentInChildren<ScrollRect>().GetComponentInChildren<Text> ();
		ResultPanel = GameObject.Find (Canvas.name + "/Result Panel");
//		ResultContent = GameObject.Find (Canvas.name + "/Result Panel/Scroll View/Viewport/Content");
//		labelText = GameObject.Find (Canvas.name + "/Result Panel/Label Panel/Label").GetComponent<Text> ();
//		resultButton = GameObject.Find (Canvas.name + "/Result Panel/Panel/Button Group").GetComponentsInChildren<Button> ();
//		CameraOriginPos = MainCamera.transform.position;
	}

	// Use this for initialization
	void Start () {
		ResultPanel.SetActive (false);
		InfoTip.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
