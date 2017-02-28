using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class NameLibrary : MonoBehaviour {
	//部门列表枚举，同时与List表的索引值相对应
	public enum DEPARTMENT {DEVLOPMENT = 0, DESIGN, SALES, ENGINEERING, FIANANCE, CONTRACT};

	public enum ACTIVITY {P1 = 0, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15};

    //部门名称字符串列表
	public static string[] departmentStr = {"前期部", "设计部", "合约部", "工程部", "营销部", "财务部"};
    static string[] devlopmentStr= {"获得土地挂牌文件", "成交确定书","签定土地出让合同及用地批准书","宗地图测量"};
	static string[] designStr = {""};
	static string[] salesStr= {""};
	static string[] engineeringStr= {""};
	static string[] fianaceStr= {""};
	static string[] contractStr= {""};

    public static string[][] activity = new string[6][]{
        devlopmentStr,
		designStr,
		salesStr,
		engineeringStr,
		fianaceStr,
		contractStr
	};

	public static string[][] activitytips = new string[6][]{
		new string[] {"拿到土地拍块信息相关文件"},
		new string[] {},
		new string[] {},
		new string[] {"不可一视的相关文件"},
		new string[] {},
		new string[] {},
	};

	string[] FileName = {"DepartmentName", "Devlopment", "Design", "Contract", "Engineering", "Sales", "Fianace" };
	string[] ActivitytipFile = {"DevlopmentTip", "DesignTip", "ContractTip", "EngineeringTip", "SalesTip", "FianaceTip"};

	// Use this for initialization
	void Awake () {
        TextAsset TempText;

		//获得部门名称列表
//		TempText = Resources.Load("DepartmentName") as TextAsset;
//		if (TempText == null)
//			continue;
//		departmentStr = TempText.text.Split("\n"[0]) ;

//        List<string> list = new List<string>(TempText.text.Split("\n"[0]));
		//读活动列表文件
        for (int i = 1; i < FileName.Length; i++)
        {
            TempText = Resources.Load("NameLibrary/" + FileName[i]) as TextAsset;
			if (TempText == null) {
				Debug.Log("文件：" + FileName[i] + "未找到");
				continue;
			}
			activity [i-1] = TempText.text.Split("\n"[0]) ;
        }
		//读活动信息提示文件
		for (int i = 0; i < ActivitytipFile.Length; i++)
		{
			TempText = Resources.Load(ActivitytipFile[i]) as TextAsset;
			if (TempText == null) {
				Debug.Log ("文件：" + ActivitytipFile [i] + "未找到");
				continue;
			}
			activitytips [i] = TempText.text.Split("\n"[0]) ;
		}

	}
}
