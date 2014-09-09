using UnityEngine;
using System.Collections;

public class PointText : MonoBehaviour {
    Vector3 backPosition = new Vector3(0.5F, 8, 2);
    Vector3 pointPosition = new Vector3(0.5F, 0.9F, 2);
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (End.startretrunde)
        {
            transform.position = Vector3.MoveTowards(transform.position, backPosition, UnityEngine.Time.smoothDeltaTime * 3);

        }
        if (GameBegin.IsBegin)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointPosition, UnityEngine.Time.smoothDeltaTime * 1);
        }
	}
}
