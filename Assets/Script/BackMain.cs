using UnityEngine;
using System.Collections;

public class BackMain : MonoBehaviour {
    Vector3 targetPosition = new Vector3(1.5f, -4f, 0);
    Vector3 backPosition = new Vector3(1, -13, 0);
    public GameObject BackBig;
    public GameObject BackSmall;
    public static bool IsBack = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (GameTrad.IsTrad)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, UnityEngine.Time.smoothDeltaTime * 4);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray pos = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(pos, out hit))
            {
                if (hit.transform.name == "BackBtn")
                {

                    //Debug.Log("Back");
                    //IsBack = true;
                    BackBig.active = false;
                    BackSmall.active = true;

                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Ray pos = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(pos, out hit))
            {
                if (hit.transform.name == "BackBtn")
                {

                    // Debug.Log("click");
                    IsBack = true;
                    BackBig.active = true;
                    BackSmall.active = false;   

                }
            }
        }
        
        
        if (IsBack)
        {
            transform.position = Vector3.MoveTowards(transform.position, backPosition, UnityEngine.Time.smoothDeltaTime * 3);
            
        }
        if (transform.position == backPosition)
        {
            IsBack = false;
            //GameTrad.IsTrad = false;
        }
	}
}
