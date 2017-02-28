using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour {
	public Transform mZoomContainer;
	//
	public Transform mXRotate;
	public float nearDistance = -1f;
	public float farDistance = -15f;
	private GameObject[] mXText;
	public Transform mPies;
	// Use this for initialization
	void Start () {
		mXText =GameObject.FindGameObjectsWithTag ("Building");
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (Input.GetAxis ("Mouse ScrollWheel")!=0) {
			Zoom ((int)Mathf.Sign(Input.GetAxis ("Mouse ScrollWheel")));
		}
		if (Input.GetMouseButton (1)) {
			if (Mathf.Abs( Input.GetAxis ("Mouse X"))>0.6f) {
				RotateByY((int)Mathf.Sign(Input.GetAxis ("Mouse X")));
				return;
			}
			if (Mathf.Abs(Input.GetAxis ("Mouse Y"))>0.6f) {
				RotateByX((int)Mathf.Sign(Input.GetAxis ("Mouse Y")));
				return;
			}
		}
		if (Input.GetMouseButton (0)) {
			if(Mathf.Abs( Input.GetAxis ("Mouse Y"))>0.6f) {
				RotateByMX((int)Mathf.Sign(Input.GetAxis ("Mouse Y")));
				return;
			}
			if (Mathf.Abs(Input.GetAxis ("Mouse Y"))>0.6f) {
				RotateByMX((int)Mathf.Sign(Input.GetAxis ("Mouse Y")));
				return;
			}
		}

	}
	//
	void Zoom(int dir)
	{
		mZoomContainer.localPosition += Vector3.forward*dir*Time.deltaTime*5;
		mZoomContainer.localPosition = new Vector3 (mZoomContainer.localPosition.x, mZoomContainer.localPosition.y, Mathf.Clamp (mZoomContainer.localPosition.z, farDistance, nearDistance));
	}
	//
	void RotateByX(int dir)
	{
		mXRotate.Rotate (Vector3.right * dir * Time.deltaTime * 90);
	}
	//
	void RotateByY(int dir)
	{
		transform.Rotate (Vector3.up * dir * Time.deltaTime * 90);
		for (int i = 0; i < mXText.Length; i++) {
			//跟随相机
			mXText [i].transform.LookAt (new Vector3(Camera.main.transform.position.x,mXText[i].transform.position.y,Camera.main.transform.position.z));//.transform.Rotate (Vector3.u * dir * Time.deltaTime * 90);
			//
		
		}
	}
	void RotateByMX(int dir)
	{
		mZoomContainer.localPosition += Vector3.up * dir * Time.deltaTime * 1;

		mZoomContainer.localPosition=new Vector3(mZoomContainer.localPosition.x, Mathf.Clamp (mZoomContainer.localPosition.y, 1, 10),mZoomContainer.localPosition.z);
	}
	//

}
