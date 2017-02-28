using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//[System.Serializable]

public class SelectObj : MonoBehaviour {

	public GameObject Canvas;

	GameObject SelectedGameObject = null;
	GameObject CanvHandle;

	//列表项添加到的父物体对象
	Dropdown DepartmentList;
	Dropdown ActivityList;
	Text ActivityTip;

	int departmentIndex = 0;
	int activityIndex = 0;

	void Awake() {
		CanvHandle = Instantiate (Canvas);
		DepartmentList = GameObject.Find (Canvas.name + "(Clone)/Department").GetComponent<Dropdown>();
		ActivityList = GameObject.Find (Canvas.name + "(Clone)/Activity").GetComponent<Dropdown>();
		ActivityTip = GameObject.Find (Canvas.name + "(Clone)/ActivityTip").GetComponentInChildren<Text> ();
		CanvHandle.SetActive (false);
	}

	// Use this for initialization
	void Start () {
		FillDepartmentList();
		FillActivationList (departmentIndex);
		DepartmentList.onValueChanged.AddListener ((int v) => OnValueChanged(v));
	}

	Ray ray;
	//射线检测到的物体信息
	RaycastHit hit;

	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonUp (0)) {
			//Camera.main表示主摄像机
			//生成一条射线
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			//检测射线方向是否有物体
			if (Physics.Raycast (ray, out hit, 1000, LayerMask.GetMask("Activity"))) {			//只检测Layer Process

				SelectedGameObject = hit.collider.gameObject;
                //					Debug.Log (SelectedGameObject);
                Activity pro = SelectedGameObject.GetComponentInChildren<Activity> ();
				if(pro) {
					departmentIndex = (int)pro.GetDepartment ();
					activityIndex = (int)pro.GetActivity ();
					//进行选中的活动相应处理
					CreateUI (departmentIndex, activityIndex);
//					CanvHandle.SetActive (true);
					//移动目标活动为视图当前主目标
					Camera.main.GetComponent<MouseFollowRotation> ().target = pro.transform;
				} else {
					CanvHandle.GetComponentInChildren<Animator> ().SetFloat ("Dirct", -1);
					CanvHandle.GetComponentInChildren<Animator> ().SetTrigger ("Trigger");
					CanvHandle.SetActive (false);
					return;
				}
			}
		}
	}

	void CreateUI(int departmentIndex, int activityIndex) {
//		FillActivationList (departmentIndex);
		//设定列表中当前应该显示的列表项
		DepartmentList.value = departmentIndex;
		DepartmentList.captionText.text = DepartmentList.options [DepartmentList.value].text;
		ActivityList.value = activityIndex;
		ActivityList.captionText.text = ActivityList.options[ActivityList.value].text;
		//显示对应的信息提示
		ActivitytipShow(departmentIndex,activityIndex);
		CanvHandle.SetActive(true);
		CanvHandle.GetComponentInChildren<Animator> ().SetFloat ("Dirct", 1);
		CanvHandle.GetComponentInChildren<Animator> ().SetTrigger ("Trigger");
	}

	void FillDepartmentList(){
		Dropdown.OptionData tempData;

		//此处需要根据实际情况判断是否需要创建，如之前已经创建过

		//创建部门列表
		DepartmentList.ClearOptions ();

		foreach (string str in NameLibrary.departmentStr) {
			if (str.Equals (""))
				continue;
			tempData = new Dropdown.OptionData ();
			tempData.text = str;
			DepartmentList.options.Add (tempData);
		}
	}

	public void FillActivationList(int departmentIndex) {
		//创建活动列表
		Dropdown.OptionData tempData;
		ActivityList.ClearOptions();
		foreach (string str in NameLibrary.activity[departmentIndex]) {
			if (str.Equals (""))
				continue;
			tempData = new Dropdown.OptionData ();
			tempData.text = str;
			ActivityList.options.Add (tempData);
		}
	}

	void ActivitytipShow(int departmentIndex, int activityIndex) {
		if (activityIndex >= NameLibrary.activitytips [departmentIndex].Length)
			return;
		if (NameLibrary.activitytips [departmentIndex][activityIndex] == "")
			return;
		string str = NameLibrary.activitytips [departmentIndex] [activityIndex];
		if (str != null) {
			ActivityTip.text = str;
		}
	}

	void OnValueChanged(int v) {
		departmentIndex = v;
		FillActivationList (departmentIndex);
	}

}
