using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class InputResponse : MonoBehaviour {
	public GameObject Canvas;
	public GameObject MainCamera;
	public GUISkin mySkin;
	public Texture image;
	public GameObject text;

	//部门列表框

	GameObject SelectedGameObject = null;
	GameObject CanvHandle;
	GameObject InfoTip;
	GameObject ResultPanel;
	GameObject ResultContent;
	//列表框标题文本
	Text labelText;
	//列表框内活动按钮
	Button[] resultButton;

	Vector3 CameraOriginPos;

	//列表项添加到的父物体对象
	ToggleGroup DepartmentList;
	ScrollRect ScrollView;
	Text InfoTipText;

	int departmentIndex = 0;
	int activityIndex = 0;
//	bool isShow = false;

	void Awake() {
		DepartmentList = GameObject.Find (Canvas.name + "/Department Panel").GetComponent<ToggleGroup>();
		InfoTip = GameObject.Find (Canvas.name + "/InfoTip");
		InfoTipText = InfoTip.GetComponentInChildren<ScrollRect>().GetComponentInChildren<Text> ();
		ResultPanel = GameObject.Find (Canvas.name + "/Result Panel");
		ResultContent = GameObject.Find (Canvas.name + "/Result Panel/Scroll View/Viewport/Content");
		labelText = GameObject.Find (Canvas.name + "/Result Panel/Label Panel/Label").GetComponent<Text> ();
		resultButton = GameObject.Find (Canvas.name + "/Result Panel/Panel/Button Group").GetComponentsInChildren<Button> ();
		CameraOriginPos = MainCamera.transform.position;
	}

	// Use this for initialization
	void Start () {
		ResultPanel.SetActive (false);
		InfoTip.SetActive (false);
	}

	//通过对模型点击2次后进入下一场景的功能，为了记录同一模型被点击2次设置的变量
	Activity PrevObj;
	Activity CurrObj;

	int Clicktimes = 0;

	Ray ray;
	//射线检测到的物体信息
	RaycastHit hit;

//	float upTime;
	// Update is called once per frame
	void Update () {
		
		if (!EventSystem.current.IsPointerOverGameObject ()) {
			if (Input.GetMouseButtonUp (0)) {
				//Camera.main表示主摄像机
				//生成一条射线
				ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				//检测射线方向是否有物体
				if (Physics.Raycast (ray, out hit, 1000, LayerMask.GetMask ("Activity"))) {			//只检测Layer Process

					SelectedGameObject = hit.collider.gameObject;
					//					Debug.Log (SelectedGameObject);
					Activity pro = SelectedGameObject.GetComponentInChildren<Activity> ();
					if (pro) {
						CurrObj = pro;
						Clicktimes++;

						departmentIndex = (int)pro.GetDepartment ();
						activityIndex = (int)pro.GetActivity ();
						//进行选中的活动相应的UI选中处理
						ActivitytipShow (departmentIndex, activityIndex);
						DepartmentList.GetComponentsInChildren<Toggle> () [departmentIndex].isOn = true;
						//移动目标活动为视图当前主目标
//					Camera.main.GetComponent<MouseFollowRotation> ().target = pro.transform;
						MainCamera.GetComponent<MouseFollowRotation> ().target = pro.transform;

//						//现目标点坐标
//						Vector3 currentTarget = MainCamera.GetComponent<MouseFollowRotation> ().target.position;
//						//相机距现目标点距离
//						Vector3 dis = MainCamera.transform.position - currentTarget;
//						float angle= Vector3.Angle (currentTarget, pro.transform.position);
//						float distance = dis.magnitude;


					}
				}

			}

			if (Clicktimes >= 2) {
				if (CurrObj.Equals (PrevObj)) {
					CurrObj = null;
					PrevObj = null;
					PlayerPrefs.SetFloat ("Pos", 5f);
//					Application.LoadLevel ("Points");
					SceneManager.LoadScene ("Points");
				}
				Clicktimes = 0;
			}
			PrevObj = CurrObj;

//			if (Input.GetMouseButtonUp (0)) {
//				//Camera.main表示主摄像机
//				//生成一条射线
//				ray = Camera.main.ScreenPointToRay (Input.mousePosition);
//				//检测射线方向是否有物体
//				if (Physics.Raycast (ray, out hit, 1000, LayerMask.GetMask ("Activity"))) {			//只检测Layer Process
//
//					SelectedGameObject = hit.collider.gameObject;
//					//					Debug.Log (SelectedGameObject);
//					Activity pro = SelectedGameObject.GetComponentInChildren<Activity> ();
//					if (pro) {
//						departmentIndex = (int)pro.GetDepartment ();
//						activityIndex = (int)pro.GetActivity ();
//						//进行选中的活动相应的UI选中处理
//						ActivitytipShow (departmentIndex, activityIndex);
//						DepartmentList.GetComponentsInChildren<Toggle> () [departmentIndex].isOn = true;
//						//移动目标活动为视图当前主目标
////					Camera.main.GetComponent<MouseFollowRotation> ().target = pro.transform;
//						MainCamera.GetComponent<MouseFollowRotation> ().target = pro.transform;
//					}
//				}
//			}

		}
	}

	// Update is called once per frame
	void LateUpdate() {
//		if (Input.GetMouseButtonDown (0)) {
//			//Camera.main表示主摄像机
//			//生成一条射线
//			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
//			//检测射线方向是否有物体
//			if (Physics.Raycast (ray, out hit, 1000, LayerMask.GetMask ("Activity"))) {			//只检测Layer Process
//
//				SelectedGameObject = hit.collider.gameObject;
//				//					Debug.Log (SelectedGameObject);
//				Activity pro = SelectedGameObject.GetComponentInChildren<Activity> ();
//				if (pro) {
//					DoubleClick ();
//				}
//			}
//		}
//		if (Input.GetMouseButtonDown(0)) {
//			int v = DoubleClick();
//			if (v == 1) {
//				PlayerPrefs.SetFloat ("Pos", 5f);
//				Application.LoadLevel ("Points");
//			} 
//		}
	}
//	void FixedUpdate(){
//		if (Input.GetMouseButtonDown (0)) {
//			count++;
//		}
//		if (count >= 1) {
//			count = 0;
//			PlayerPrefs.SetFloat ("Pos", 5f);
//			Application.LoadLevel ("Points");
////			SceneManager.LoadScene ("Points");
//		}
//	}

//	GameObject RaycastDetect() {
//		GameObject Obj;
//		//Camera.main表示主摄像机
//		//生成一条射线
//		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
//		//检测射线方向是否有物体
//		if (Physics.Raycast (ray, out hit, 1000, LayerMask.GetMask ("Activity"))) {			//只检测Layer Process
//
//			Obj = hit.collider.gameObject;
//			return Obj;
//		}
//		return null;
//	}

	public void OnValueChanged(int v) {
		Toggle[] tog = DepartmentList.GetComponentsInChildren<Toggle> ();
		for (int i = 0; i < tog.Length; i++) {
			if (tog [i].isOn) {
				departmentIndex = i;
                //移动目标活动为视图当前主目标
//                Camera.main.GetComponent<MouseFollowRotation> ().target = GameObject.Find ("D" + i).transform;
				MainCamera.GetComponent<MouseFollowRotation> ().target = GameObject.Find ("D" + i).transform;
				//在这里处理按下按钮时弹出活动列表框操作
				ShowResult(i);
			}
		}
	}

    void ActivitytipShow(int departmentIndex, int activityIndex)
    {
        if (activityIndex >= NameLibrary.activitytips[departmentIndex].Length)
        {
            InfoTipText.text = "";
            InfoTip.SetActive(false);
            return;
        }
        if (NameLibrary.activitytips[departmentIndex][activityIndex] == null)
        {
            InfoTipText.text = "";
            InfoTip.SetActive(false);
            return;
        }
        string str = NameLibrary.activitytips[departmentIndex][activityIndex];
        if (str != "")
        {
			InfoTipText.text = "    " + NameLibrary.activity[departmentIndex][activityIndex];
            InfoTipText.text += ("    " + str);
            InfoTip.SetActive(true);
        } else
        {
            InfoTipText.text = "";
            InfoTip.SetActive(false);
        }
    }
		
	void OnGUI()
	{
//		if (SelectedGameObject) {
//			//得到NPC头顶在3D世界中的坐标
//			//默认NPC坐标点在脚底下，所以这里加上npcHeight它模型的高度即可
//			Vector3 worldPosition = new Vector3 (SelectedGameObject.transform.position.x + 1, SelectedGameObject.transform.position.y, SelectedGameObject.transform.position.z);
//			//根据NPC头顶的3D坐标换算成它在2D屏幕中的坐标
//			Vector2 position = Camera.current.WorldToScreenPoint (worldPosition);
//			//得到真实NPC头顶的2D坐标
//			position = new Vector2 (Screen.width - position.x, Screen.height - position.y);
//			//注解3
//			//计算NPC名称的宽高
//			Vector2 nameSize = GUI.skin.label.CalcSize (new GUIContent (NameLibrary.activity [departmentIndex] [activityIndex]));
//			//设置显示颜色为黄色
//			GUI.color = Color.yellow;
//			//绘制NPC名称
//			GUI.Label (new Rect (position.x - (nameSize.x / 2), position.y - nameSize.y, nameSize.x, nameSize.y), name);
//		}

//		Vector3 pos = Vector3.zero;
//
//		if (isShow) {
//			float win_pos_x = 200;
//			float win_pos_y = 80;
//			float win_width = 640;
//			float win_height = 480;
//
//			GUI.skin = mySkin;
//			GUI.BeginGroup(new Rect(win_pos_x, win_pos_y, win_width, win_height));
//			GUI.Box(new Rect(0, 0, win_width, win_height), image);
//
//			pos.x = 0;
//			pos.y = 0;
//			for (int actIndex = 0; actIndex < 8; actIndex++) {
////			for (int actIndex = 0; actIndex < NameLibrary.activity [departmentIndex].Length; actIndex++) {
//				if (NameLibrary.activity [departmentIndex] [actIndex] == "") {
//					continue;
//				}
//				string name = NameLibrary.activity [departmentIndex] [actIndex];
//				Vector2 nameSize = GUI.skin.label.CalcSize (new GUIContent (name));
//
//				float width = nameSize.x + 4;
//				float herght = nameSize.y;
//
//				GUI.BeginGroup(new Rect(pos.x, pos.y+2, width, herght));
////				GUI.Box(new Rect(0, 0, width, herght), image);
////				GUI.DrawTexture (new Rect (pos.x, pos.y, nameSize.x, nameSize.y), image);
//				GUI.Label (new Rect (2, 0, width, herght), name);
//				GUI.EndGroup ();
//
//				pos.x += width + 6;
////				pos.y += nameSize.y + 2;
//				//			pos.y += offset;
//			}
//			GUI.EndGroup ();
//		}
	}

	void OnMouseEnter(){
		Debug.Log ("Mouse Enter");
		Vector2 pos = Camera.main.WorldToScreenPoint (transform.position);
		pos = new Vector2 (pos.x, Screen.height - pos.y);
		string name = NameLibrary.activity [departmentIndex] [activityIndex];
		Vector2 nameSize = GUI.skin.label.CalcSize (new GUIContent (name));
		GUI.Label (new Rect (pos.x - (nameSize.x / 2), pos.y, nameSize.x, nameSize.y), name);
	}
	void OnMouseExit(){
		Debug.Log ("Mouse Exit");
	}

	public void ShowResult(int departmentIndex) {
		
		if (NameLibrary.activity [departmentIndex].Length == 0)
			return;
//
//		GameObject txt = GameObject.Instantiate (text, ResultContent.transform);
//		RectTransform rectTransform = txt.GetComponent<RectTransform> ();
//		RectTransform rectTrans = new RectTransform();
//		rectTrans. = 0;
//		rectTrans.position.y = 0;
//		rectTransform = rectTrans;
//		string name = NameLibrary.activity [departmentIndex] [actIndex];
//		txt.GetComponent<text>.text = name;

//		isShow = true;
		ResultPanel.SetActive (true);
		labelText.text = NameLibrary.departmentStr [departmentIndex];

		for (int i = 0; i < 4; i++) {
			resultButton [i].GetComponentInChildren<Text> ().text = NameLibrary.activity [departmentIndex] [i];
		}

	}
	//摄像机位置复位，目前无过渡，需要修改
	public void CameraPositionReset() {
		Scene scene = SceneManager.GetActiveScene ();
		if(scene.name != "UI_Toggle 1")
			SceneManager.LoadScene ("UI_Toggle 3");
		MainCamera.GetComponent<MouseFollowRotation> ().target = GameObject.Find ("Camera Target").GetComponent<Transform>();
		MainCamera.transform.position = CameraOriginPos;
	}

	//双击
	private float time = 0f;		//
	private int count=0;			//
	void DoubleClick()
	{
		//Camera.main表示主摄像机
		//生成一条射线
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		//检测射线方向是否有物体
		if (Physics.Raycast (ray, out hit, 1000, LayerMask.GetMask ("Activity"))) {			//只检测Layer Process

			SelectedGameObject = hit.collider.gameObject;
			//					Debug.Log (SelectedGameObject);
			Activity pro = SelectedGameObject.GetComponentInChildren<Activity> ();
			if (pro) {


				count++;
				if (count == 1) {
					time = Time.time;
				}
				if (count == 2 && Time.time - time <= 0.2f) {
					PlayerPrefs.SetFloat ("Pos", 5f);
//					Application.LoadLevel ("Points");
					SceneManager.LoadScene ("Points");
					count = 0;
				}
				if (Time.time - time > 0.2f) {
					count = 0;
				}
//				departmentIndex = (int)pro.GetDepartment ();
//				activityIndex = (int)pro.GetActivity ();
//				//进行选中的活动相应的UI选中处理
//				ActivitytipShow (departmentIndex, activityIndex);
//				DepartmentList.GetComponentsInChildren<Toggle> () [departmentIndex].isOn = true;
//				//移动目标活动为视图当前主目标
////					Camera.main.GetComponent<MouseFollowRotation> ().target = pro.transform;
//				MainCamera.GetComponent<MouseFollowRotation> ().target = pro.transform;
			}
		}
	}
}
