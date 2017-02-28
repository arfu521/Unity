using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseFollowRotation : MonoBehaviour
{
	public Transform target;
	public float xSpeed = 200;
	public float ySpeed = 200;
	public float mSpeed = 10;
	public float yMinLimit = -50;
	public float yMaxLimit = 50;
	public float distance = 2;
	public float minDistance = 5;
	public float maxDistance = 30;

	//bool needDamping = false;
	public bool needDamping = true;
	float damping = 5.0f;

	public float x = 0.0f;
	public float y = 0.0f;

	public float Sensitive = 4;

	// Use this for initialization
	void Start()
	{
		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;
		target = GameObject.Find ("Camera Target").GetComponent<Transform>();

	}

	// Update is called once per frame
	void LateUpdate()
	{
//			if (target) {
				//use the light button of mouse to rotate the camera
//				if (Input.GetMouseButton (1)) {
//					x += Input.GetAxis ("Mouse X") * xSpeed * 0.02f;
//					y -= Input.GetAxis ("Mouse Y") * ySpeed * 0.02f;
//
//					y = ClampAngle (y, yMinLimit, yMaxLimit);
//				}
//                //判断如果鼠标如果在UI上则鼠标滚轮无效
//                if (!EventSystem.current.IsPointerOverGameObject())
//                    distance -= Input.GetAxis ("Mouse ScrollWheel") * mSpeed;
//				distance = Mathf.Clamp (distance, minDistance, maxDistance);
//				Quaternion rotation = Quaternion.Euler (y, x, 0.0f);
//				Vector3 disVector = new Vector3 (0.0f, 0.0f, -distance);
//				Vector3 position = rotation * disVector  + target.position;
		Quaternion rotation;
		if (Input.GetMouseButton (1)) {
			x += Input.GetAxis ("Mouse X") * xSpeed * 0.02f;
			y -= Input.GetAxis ("Mouse Y") * ySpeed * 0.02f;

			y = ClampAngle (y, yMinLimit, yMaxLimit);

			rotation = Quaternion.Euler (y, x, 0.0f);
		} else {
			rotation = target.localRotation;
		}
		
		//判断如果鼠标如果在UI上则鼠标滚轮无效
		if (!EventSystem.current.IsPointerOverGameObject())
			distance -= Input.GetAxis ("Mouse ScrollWheel") * mSpeed;
		distance = Mathf.Clamp (distance, minDistance, maxDistance);
//		rotation = Quaternion.Euler (y, x, 0.0f);
//		Vector3 disVector = new Vector3 (0.0f, 0.0f, -distance);
//		disVector.magnitude += target.position.magnitude; 
		Vector3 position =  target.position*distance;
		rotation = Quaternion.AngleAxis (180, Vector3.up) * rotation;

				//adjust the camera
				if (needDamping) {
//					transform.rotation = Quaternion.Lerp (transform.rotation, rotation, Time.deltaTime * damping);
			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * damping);
			transform.position = Vector3.Slerp (transform.position, position, Time.deltaTime * damping);				
				} else {
					transform.rotation = rotation;
					transform.position = position;
				}
//			}

//		if (Input.GetMouseButtonDown(0)) {
//			DoubleClick ();
//			//mZoomContainer.position += Vector3.back * 1 * Time.deltaTime * 5;
//		}
	}

	static float ClampAngle(float angle, float min, float max)
	{
        //		if (angle < -360)
        //			angle += 360;
        //		if (angle > 360)
        //			angle -= 360;
        if (angle < -180)
            angle += 180;
        if (angle > 180)
            angle -= 180;
        return Mathf.Clamp(angle, min, max);
	}


}