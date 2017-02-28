using UnityEngine;
using System.Collections;

public class DropDownList : MonoBehaviour {

	public GameObject panel;
	void Start () 
	{
		panel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void HideOrShow()
	{
		panel.SetActive (!panel.activeSelf);
	}
}
