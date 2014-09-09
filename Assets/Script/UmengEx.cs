using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Umeng;


public class UmengEx : MonoBehaviour {
	
	
	void Start () {
		
		//请到 http://www.umeng.com/analytics 获取app key 
		GA.StartWithAppKeyAndChannelId("53df2ab8fd98c5bddb005003", "AppStore");
		
		//触发统计事件 开始关卡
		//GA.StartLevel("MainGame");
		
		
	}
}