using UnityEngine;
using System.Collections;

public class distance : MonoBehaviour
{
    public static float juli=1;
    public int suijishu;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        suijishu = Random.Range(0, 10);
        if (suijishu < 3)
        {
            juli = Random.Range(0.1f, 1);
        }
        else {
            juli = Random.Range(1,2);
        }

	}
}
