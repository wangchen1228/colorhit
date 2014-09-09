using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Umeng;

public class GameTrad : MonoBehaviour {

    //public GameObject Background;
    //public GameObject ClickedBackground;
    public GameObject GameTradBig;
    public GameObject GameTradSmall;
    public static bool IsTrad = false;
	

	public Leaderboard ld;
    Vector3 targetPosition = new Vector3(-10, -4.5f, 0);
    Vector3 backPosition = new Vector3(-1.7f, -4.5f, 0);
	
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray pos = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(pos, out hit))
            {
                if (hit.transform.name == "GameTradBtn")
                {

                    // Debug.Log("click");
                    //IsBegin = true;

                    GameTradBig.active = false;
                    GameTradSmall.active = true;

                    //Material mt = Background.materials[0];
                    //mt = (Material)GameObject.Find("ClickedBackground");
                    //ClickedBackground.active = false;


                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Ray pos = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(pos, out hit))
            {
                if (hit.transform.name == "GameTradBtn")
                {

                    // Debug.Log("click");
                    //IsTrad = true;
                    GameTradBig.active = true;
                    GameTradSmall.active = false;

#if UNITY_IOS
					ld.ShowLeaderboard ();
#elif UNITY_ANDROID
                    IsTrad = true;
#endif
					GA.Use("Trad", 1, 0.0);
                    //Material mt = Background.materials[0];
                    //mt = (Material)GameObject.Find("ClickedBackground");
                    //ClickedBackground.active = false;


                }
            }
        }
        if (GameBegin.IsBegin)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, UnityEngine.Time.smoothDeltaTime * 3);
        }
        if (IsTrad)
        {

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, UnityEngine.Time.smoothDeltaTime * 3);
        }
        if (BackMain.IsBack)
        {
            IsTrad = false;
            transform.position = Vector3.MoveTowards(transform.position, backPosition, UnityEngine.Time.smoothDeltaTime * 3);
        }
        if (End.startretrunde)
        {
            //IsTrad = false;
            transform.position = Vector3.MoveTowards(transform.position, backPosition, UnityEngine.Time.smoothDeltaTime * 5);
        }
    }


}

