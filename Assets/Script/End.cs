using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Umeng;
using System.IO;

public class End : MonoBehaviour
{
    public static bool destroycube = false;
    //public GameObject retry;
    //public GameObject returned;
    public static bool startretrunde = false;
    public static bool starretry = false;
    public GameObject player;
    public GameObject playermid;
    private string path;
    private string picpath;
    Transform save;
	private bool btnlock = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)&&btnlock == false)
        {
            Ray pos = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(pos, out hit))
            {
                if (hit.transform.name == "retry")
                {
					btnlock = true;
                    Player.playerstar = true;
                   // ChangeScale(GameObject.Find("retry"));
                    GameObject.Find("retry").animation.Play("Changebtn");
                    Secai.speed = 3;
                    destroycube = true;
                    Player.initial = true;
                    StartCoroutine(waiting());
					GA.StartLevel("MainGame");
					GA.Use("Again", 1, 0.0);
                }
                else if (hit.transform.name == "returned")
                {
					btnlock = true;
                    //Color changesssColor = new Color(0, 0.686f, 1, 0);
                    /*save = new Material(GameObject.Find("returned").renderer.sharedMaterial);
                    Material nov = new Material(GameObject.Find("returned").renderer.sharedMaterial);
                    nov.color = new Color(save.color.r, save.color.g, save.color.b, 0.6f);
                    GameObject.Find("returned").renderer.sharedMaterial = nov;
                    StartCoroutine(returncolor());**/
                    GameObject.Find("returned").animation.Play("Changebtn");
                   // ChangeScale(GameObject.Find("returned"));
                    Player.initial = true;
                    StartCoroutine(waited());
					GA.Use("Home", 1, 0.0);

                }
                else if (hit.transform.name =="share")
                {
                   
                   // ChangeScale(GameObject.Find("share"));
                    
                    GameObject.Find("share").animation.Play("Changebtn");

					Application.CaptureScreenshot("screencapture.png");
					if(Application.platform==RuntimePlatform.Android || Application.platform==RuntimePlatform.IPhonePlayer){  
                    	path=Application.persistentDataPath;  
                    }

					Application.CaptureScreenshot("jietu.JPG");
#if UNITY_IOS
					Lihui.weibo();
#endif
					//判断文件是不是存在
                    //  picpath =path+"/Screenshot.png";
        //            Lihuiweibo.jietu(picpath);
					GA.Use("Share", 1, 0.0);
                }
            }
        }
    }
    IEnumerator waiting()
    {
        // Vector3 movePosition = new Vector3(0, 10, 1.1f);
        yield return new WaitForSeconds(1);
        starretry = true;
       // Debug.Log("retryretryretryretry");
		btnlock = false;
        PlaneMove.reach = false;
        GameBegin.IsBegin = false;
        Secai.showover = false;
        //  Gameovermove.boolmove = true;
        Gameovermove.boolmove = false;
        Secai.point = 0;
        Player.beishu = 0;
        Player.recordbeishu = 0;
    }
    IEnumerator waited()
    {
        // Vector3 movePosition = new Vector3(0, 10, 1.1f);
        yield return new WaitForSeconds(1);
        Secai.speed = 3;
		btnlock = false;

        PlaneMove.reach = false;
        GameBegin.IsBegin = false;
        destroycube = true;
        Secai.showover = false;
        Gameovermove.boolmove = false;
        startretrunde = true;
        Secai.point = 0;
        Player.beishu = 0;
        //GameShare.IsShare = false;
        //GameTrad.IsTrad = false;
        // player.SetActive(false);
        // playermid.SetActive(true);
        player.active = false;
        playermid.active = true;
        GameObject.Find("Playermid").animation.Play("sizeBig");
        Player.recordbeishu = 0;
    }
    IEnumerator returnScale(GameObject btn)
    {
        yield return new WaitForSeconds(0.1f);
      //  GameObject.Find("returned").renderer.sharedMaterial = save;
        btn.transform.localScale += new Vector3(0.1F, 0.1f, 0.1f);
    }
   /* void ChangeScale(GameObject btn) {
        btn.transform.localScale += new Vector3(-0.1F, -0.1f, -0.1f);
        StartCoroutine(returnScale(btn));
    }**/
}
