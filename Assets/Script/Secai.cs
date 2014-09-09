using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;

public class Secai : MonoBehaviour
{
    public GameObject player;
	public GameObject plan;
    public Camera cam;
    public Transform Prefabblue;
    public Transform Prefabgreen;
    public Transform Prefabred;
    public Transform Prefabyellow;
    public Transform Prefabwhite;
    public static int point;
    public static float timer;
    public static int recordtimes;
    public static bool showover = false;
    public static bool FirstCube = false;

    private float cubeX;
    private bool suiji = false;
    public static float speed;
    //Rect windowRect = new Rect(20, 20, 100, 50);
    // public static float Cubespeed { get { return speed; }}
    private float timestart;
    private bool begin = false;
    public static int Startproduce = 0;
    public static GameObject backgroundmusic;
    public static GameObject Recordbreakingmusic;

	public static bool iphone4 = false;

    // Use this for initialization
    void Start()
    {
		if(Screen.height!=1136)
		{
			plan.transform.localScale=new Vector3(0.67f,1,5);
			iphone4 = true;
			//Camera.main.aspect = 0.67f;
		}
        
		Application.targetFrameRate = 60;

        Recordbreakingmusic = GameObject.Find("record-breakingmusic");
        backgroundmusic = GameObject.Find("backgroundmusic");
        recordtimes = PlayerPrefs.GetInt("recordtimes", 0);
        speed = 3.0f;
        point = 0;
    }
    Transform ob;
    // Update is called once per frame
    void Update()
    {
        if (showover)
        {
            // GameObject.Find("retry").renderer.enabled = true;
            // GameObject.Find("Cube").renderer.enabled = true;
            // GameObject.Find("returned").renderer.enabled = true;
            GameObject.Find("record Text").GetComponent<TextMesh>().text = point.ToString();
            GameObject.Find("mostHit Text").GetComponent<TextMesh>().text = "本局倍数： x" + Player.recordbeishu;
            GameObject.Find("most Text").GetComponent<TextMesh>().text = "最好成绩：" + recordtimes;
           // Debug.Log("showover");
        }

        float juli;

        //GameObject.Find("title Text").GetComponent<GUIText>().text = "色彩撞击";
        timer = Time.time - timestart;
       // if (begin)
        //{
            //GameObject.Find("time Text").GetComponent<GUIText>().text = "时间：" + timer.ToString(".000");
        GameObject.Find("point Text").GetComponent<TextMesh>().text = "分数：" + point;
        //GameObject.Find("beishu Text").GetComponent<TextMesh>().text = "倍数："+ " x" + Player.beishu;
       

        //  if (Startproduce == 0 && cam.transform.position.y < -10f)
        if (Startproduce == 0 && PlaneMove.reach)
        {
            Player.playerstar = true;
            Startproduce = 1;
            if (FirstCube == false)
            {
                FirstCube = true;
                // Debug.Log(FirstCube + " -------- :FirstCube");               
                ob = (Transform)Instantiate(getColorPref(), new Vector3(0, -5.5f, 0), Quaternion.identity);
                timestart = Time.time;
                if (GameShare.i % 2 == 0)
                {
                    backgroundmusic.audio.Play();
                }
            }
        }

        if (Startproduce == 1)
        {
            begin = true;
            if (Random.Range(0, 10) < 0f)
            {
                float k = Random.Range(-2.50f, 0.50f);

                if (k < (cubeX - 1.0f))
                {
                    cubeX = k;
                }
                else
                {
                    cubeX = k + 2.0f;
                }
                if (suiji == false)
                {
                    suiji = true;
                    juli = Random.Range(0.10f, 0.60f);

                }
                else
                {
                    suiji = false;
                    juli = Random.Range(0.60f, 0.70f);

                }
            }
            else
            {
                juli = Random.Range(0.90f, 3.40f);
                cubeX = Random.Range(-2.50f, 2.50f);
            }

            // Background.Move();
            if (Background.test == 1)
            {
                Vector2 velocity = new Vector2(0, 0);
                rigidbody2D.velocity = velocity;
            }
            else
            {
                Vector2 velocity = new Vector2(0, 0);
                rigidbody2D.velocity = velocity;
            }
            if (ob != null)
            {
                if ((5.5 + ob.position.y) > juli)
                {

                    ob = (Transform)Instantiate(getColorPref(), new Vector3(cubeX, -5.5f, 0), Quaternion.identity);
                    speed++;
                    // Debug.LogError("speed: " + speed);

                }
            }
        }
    }

    private Transform getColorPref()
    {
        int Whatcolour = Random.Range(0, 100);
        if (Whatcolour % 4 == 1)
        {
            return Prefabblue;
        }
        else if (Whatcolour % 4 == 2)
        {
            return Prefabgreen;
        }
        else if (Whatcolour % 4 == 3)
        {
            return Prefabred;
        }

        return Prefabyellow;
    }
    public static void recordTime()
    {
        if (recordtimes == 0)
        {
			if (GameShare.i % 2 == 0)
			{
				Recordbreakingmusic.audio.Play();
			}
            recordtimes = point;
            PlayerPrefs.SetInt("recordtimes", recordtimes);
        }
        if (recordtimes < point)
        {
            if (GameShare.i % 2 == 0)
            {
                Recordbreakingmusic.audio.Play();
            }
            recordtimes = point;
            PlayerPrefs.SetInt("recordtimes", recordtimes);

#if UNITY_IOS
            Leaderboard.ReportScore("2",(long)recordtimes);
#endif
        }
    }


  
}
