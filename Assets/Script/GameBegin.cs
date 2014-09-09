using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Umeng;

public class GameBegin : MonoBehaviour
{
   
    public GameObject GameBeginSmall;
    //public GameObject GameBeginBtn;
    public GameObject GameBeginBig;
    public static bool IsBegin = false;
    Vector3 targetPosition = new Vector3(-1, 10, 0);
    Vector3 backPosition = new Vector3(-1, 0, 0);
    Vector3 beginPosition = new Vector3(-1, -8, 0);
    Vector3 retrunPosition = new Vector3(-1, 0, 0);

     void Start()
    {

    }
     
    // Update is called once per frame
    void Update()
    {
        if (End.destroycube)
        {
            transform.position = Vector3.MoveTowards(transform.position, retrunPosition, UnityEngine.Time.smoothDeltaTime * 3);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray pos = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(pos, out hit))
            {
                if (hit.transform.name == "GameBeginBtn")
                {              
                    // Debug.Log("click");
                    //IsBegin = true;
                    GameBeginBig.active = false;
                    GameBeginSmall.active = true;				                  
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
                if (hit.transform.name == "GameBeginBtn")
                {

                    // Debug.Log("click");
                    IsBegin = true;
                    GameBeginBig.active = true;
                    GameBeginSmall.active = false;
                    GameObject.Find("Playermid").animation.Play("sizeSmall");

                    Secai.FirstCube = false;
                    Secai.Startproduce = 0;
                    End.destroycube = false;
                    Player.pauseeverything = false;
                    End.startretrunde = false;

					GA.StartLevel("MainGame");
                    //GameBeginBtn.active = false;
                    /*Animator m_ani = GameObject.Find("player").GetComponent<Animator>();
                    m_ani.enabled = false;*/

                    //Material mt = Background.materials[0];
                    //mt = (Material)GameObject.Find("ClickedBackground");
                    //ClickedBackground.active = false;


                }
            }
        }
        if (IsBegin)
        {
            transform.position = Vector3.MoveTowards(transform.position, beginPosition, UnityEngine.Time.smoothDeltaTime * 3);
        }
        if (GameTrad.IsTrad)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, UnityEngine.Time.smoothDeltaTime * 8);
        }
        if (BackMain.IsBack)
        {
            transform.position = Vector3.MoveTowards(transform.position, backPosition, UnityEngine.Time.smoothDeltaTime * 4);
        }
    }


}
