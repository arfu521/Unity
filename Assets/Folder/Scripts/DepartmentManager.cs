using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepartmentManager : MonoBehaviour {

	//设定的预置体
	public GameObject ActivityPrefab;
	public GameObject TopPrefab;
	//两层间的距离偏移，为0时没有空隙
	public float tweenDistance = 0;
	//部门大厦距中心点的距离
	public float disToCenter = 3;

	public GameObject Origin;

	// Use this for initialization
	void Start () {
		CreateModule ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CreateModule(){
	
		for (int i = 0; i < NameLibrary.activity.Length; i++) {
			if (NameLibrary.activity [i] == null)
				new WaitForSeconds (1);
		}

		//先获得建立的活动模型所在的部门相关信息
		//先假定部门位置信息为0，向上延伸
		Vector3 departmentPos = new Vector3 (0, 0, disToCenter);
		Quaternion quaternion = Quaternion.identity;
//		Quaternion quaternion = Quaternion.Euler (-90, 0, 0);

		GameObject tempPrefab;
		float offset = ActivityPrefab.GetComponent<BoxCollider> ().size.y + tweenDistance;

		for (int departmentIndex = 0; departmentIndex < NameLibrary.departmentStr.Length; departmentIndex++) {

			if (NameLibrary.departmentStr [departmentIndex] == "") {
				Debug.Log ("Name of Department_" + departmentIndex + " is Empty!");
				continue;
			}
			
			//创建部门父物体
			GameObject parentObj = new GameObject ("D" + departmentIndex);
			parentObj.tag = "Building";

			Transform transform = parentObj.GetComponent<Transform> ();
			transform.position = departmentPos;
			transform.RotateAround (Origin.transform.position, Vector3.up, departmentIndex * 60);
			//正面始终朝向相机
			Vector3 camerapos = Camera.main.transform.position;
			camerapos.y = 0;
//			transform.LookAt (camerapos);

			parentObj.AddComponent<BuildingRotate> ();

			if (NameLibrary.activity [departmentIndex].Length == 0)
				continue;
			
			Vector3 pos = transform.position;

			for (int actIndex = 0; actIndex < NameLibrary.activity [departmentIndex].Length; actIndex++) {
				if (NameLibrary.activity [departmentIndex] [actIndex] == "\r") {
//					Debug.Log ("Name of Activity_" + actIndex + " in Department_" + departmentIndex + " is Empty!");
//					continue;
					//临时增加此句，为的是在遇到空行时，就不再继续读取后续文件内容
					break;
				}
				//读取资源文件
//				string assetsName = "Prefabs/" + "old" + "/Layer_D" + departmentIndex + "A" + actIndex; 
				string assetsName = "Prefabs/" + "D" + departmentIndex + "/Layer_D" + departmentIndex + "A" + actIndex; 
				tempPrefab = Resources.Load(assetsName) as GameObject;
				if (tempPrefab == null) {
//					Debug.Log ("文件:" + assetsName + "未找到!");
					//使用普通预置体文件
					tempPrefab = ActivityPrefab;
				}

				tempPrefab = Instantiate (tempPrefab, pos, quaternion, parentObj.transform);
                Activity proc = tempPrefab.GetComponent<Activity> ();
				proc.departmentIndex = (NameLibrary.DEPARTMENT)departmentIndex;
				proc.activityIndex = (NameLibrary.ACTIVITY)actIndex;
				proc.name = "D" + departmentIndex + "_A" + actIndex;
				pos.y += offset;
			}

			parentObj.GetComponent<Transform> ().LookAt (camerapos);

			//创建楼层的顶部
//			string assetsNameD = "Prefabs/" + "old" + "/Top_" + "D" + departmentIndex;
			string assetsNameD = "Prefabs/" + "D" + departmentIndex + "/Top_" + "D" + departmentIndex; 
			tempPrefab = Resources.Load(assetsNameD) as GameObject;
			if (tempPrefab == null) {
//				Debug.Log ("文件:" + assetsNameD + "未找到!");
				//使用普通预置体文件
				tempPrefab = TopPrefab;
			}
			tempPrefab = Instantiate (tempPrefab, pos, quaternion, parentObj.transform);

		}
	}
}
