using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ToggleProcess : MonoBehaviour {
	public ToggleGroup toggleGroup;
	public InputResponse inputResponse;

//	// Use this for initialization
//	void Start () {
//		
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//	}

	public void OnValueChagned(bool isOn) {
		if (isOn) {
//			foreach (Toggle tog in toggleGroup.ActiveToggles()) {
//				Debug.Log (tog.name + " is " + (tog.isOn ? "On" : "Off"));
//				//做被选按钮的相应处理，注意：已选按钮在重复下点击下会被重复响应
//			}
//			for(int i=0;i< GetComponentsInChildren<Toggle>().Length;i++) {
//				if (GetComponentsInChildren<Toggle> () [i].isOn)
//					//做被选按钮的相应处理，注意：已选按钮在重复下点击下会被重复响应
//					inputResponse.OnValueChanged (i);
//			}
            //判断是否是通过点击UI触发的事件，如果是需要移动相机
            if (EventSystem.current.IsPointerOverGameObject())
            {
                inputResponse.OnValueChanged(isOn ? 1 : 0);
            }

        }
	}

}
