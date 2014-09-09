using UnityEngine;
using System.Runtime.InteropServices;

public class Lihui  {
#if UNITY_IOS
	[DllImport("__Internal")]
	private static extern void viewDidLoad();

	public static void weibo ()
	{
		
		if (Application.platform != RuntimePlatform.OSXEditor) 
		{
			viewDidLoad();
		}
	}
#endif
}
