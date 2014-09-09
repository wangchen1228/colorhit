using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Umeng;

public class Player : MonoBehaviour
{
    public static bool playerstar = false;
    public Transform m_transform;
    public Vector3 fristPos;
    public Vector3 movePos;
    public Transform Prefabblue;
    public Transform Prefabgreen;
    public Transform Prefabred;
    public Transform Prefabyellow;
	
    public static int beishu = 0;
    public static int recordbeishu = 0;

    private static int blue = 0;
    private static int green = 0;
    private static int yellow = 0;
    private static int red = 0;
   // private string changeColor;

 
    public static bool pauseeverything = false;
    public static bool initial = false;

    public static int RED { get { return red; } }
    public static int GREEN { get { return green; } }
    public static int YELLOW { get { return yellow; } }
    public static int BLUE { get { return blue; } }
    Vector3 initialPosition = new Vector3(0, 2.5f, 0);
    GameObject gameovermusic;
   // GameObject hitmusic;
    public AudioClip hitedmusic;
    // Use this for initialization


    void Start()
    {
        gameovermusic = GameObject.Find("gameovermusic");
       
    }

    // Update is called once per frame
    void Update()
    {
        if (initial)
        {
            //m_transform.Translate(new Vector3(0, 0, 0));
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, UnityEngine.Time.smoothDeltaTime * 10);
            renderer.material.color = Color.white;
            blue = 0;
            green = 0;
            yellow = 0;
            red = 0;
            Debug.Log("initialinitialinitialinitialinitialinitialinitial");
            if (transform.position.x ==0)
            {
                initial = false;
            }
            //StartCoroutine(Waitmoment());
        }


        if (playerstar == true)
        {
            rigidbody.velocity = new Vector3(0, 0, 0);

            float moveY = 0;// 上下移动的数值;        
            float moveX = 0;//左右移动的数值;
            int i = 1;

            //是否刚刚触屏
            //while (i < Input.touchCount)
            //{
            //Debug.Log("i:" + i + " Touch Count:" + Input.touchCount);
         
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                i++;
                //接触屏幕的坐标
                fristPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            }
             if (Input.GetTouch(0).phase == TouchPhase.Moved)//是否触屏移动
             {                                  //触屏移动后的坐标
                 movePos = Input.GetTouch(0).deltaPosition;

                 //更据X轴的值判断移动方向
				if (Mathf.Abs(fristPos.x - movePos.x) > 0)
                 {


					//向右,左移动
					if ((fristPos.x < movePos.x && Camera.main.WorldToScreenPoint(transform.position).x<Screen.width)||(fristPos.x > movePos.x && Camera.main.WorldToScreenPoint(transform.position).x > 0))
					{    
						//if(fristPos.x > m_transform.position.x){moveX += movePos.x / 1000;}
						 //if ((movePos.x / 700) + m_transform.position.x <= 2.40f)
                         //if ((movePos.x / 700) + m_transform.position.x <=Camera.main.ScreenToWorldPoint(WordPos).x)

							moveX += movePos.x / 700;
							//moveX += Mathf.Abs(movePos.x / 700);
                         
					}
				
                 }
                /* if (m_transform.position.x > -2.5f && m_transform.position.x < 2.5f)
                 {
                     m_transform.Translate(new Vector3(8 * moveX, moveY, 0));
                 }**/
				if(Secai.iphone4 == true)
				{
					if(8 * moveX>0.5f){
						for(int j=0;j<Mathf.Abs(8 * moveX/0.5f);j++)
						{
							if (m_transform.position.x -0.5f > -3f && m_transform.position.x + 0.5f <3f){
								if(moveX>0){
									m_transform.Translate(new Vector3(0.5f, 0, 0));
								}else{
									m_transform.Translate(new Vector3(-0.5f, 0, 0));
								}
							}
						}
						if (m_transform.position.x -0.5f > -3f && m_transform.position.x + 0.5f <3f){
							m_transform.Translate(new Vector3((8 * moveX)%0.5f, 0, 0));
						}
					}
					else
					{
						if (m_transform.position.x + 8 * moveX > -3f && m_transform.position.x + 8 * moveX <3f)
						{
							m_transform.Translate(new Vector3(8 * moveX, 0, 0));
						}
					}
				}else{

					if(8 * moveX>0.5f){
						for(int j=0;j<Mathf.Abs(8 * moveX/0.5f);j++)
						{
							if (m_transform.position.x -0.5f > -2.5f && m_transform.position.x + 0.5f <2.5f){
								if(moveX>0){
									m_transform.Translate(new Vector3(0.2f, 0, 0));
								}else{
									m_transform.Translate(new Vector3(-0.2f, 0, 0));
								}
							}
						}
						if (m_transform.position.x -0.5f > -2.5f && m_transform.position.x + 0.5f<2.5f){
							m_transform.Translate(new Vector3((8 * moveX)%0.5f, 0, 0));
						}
					}
					else
					{
						if (m_transform.position.x + 8 * moveX > -2.5f && m_transform.position.x + 8 * moveX <2.5f)
						{
							m_transform.Translate(new Vector3(8 * moveX, 0, 0));
						}
					}
				}
             }
        }
        else {
            //rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
           // RigidbodyConstraints.FreezeAll;
           // Rigidbody.freezePosition = true;
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }
      }
    
   // }

    //void OnCollisionEnter(Collision collisionInfo)
	void OnTriggerEnter(Collider collisionInfo)
    {
        
		if (collisionInfo.tag == "Finish")
        {
            playerstar = false;
			Destroy(collisionInfo.gameObject);
            Secai.recordTime();
            StartCoroutine(Wait());
			GA.FinishLevel("MainGame");
        }
		else if (collisionInfo.tag == "GameController")
        {
            // Debug.Log("碰撞到的物体的名字是:" + collisionInfo.gameObject.name);

            PlaySounds();
			Destroy(collisionInfo.gameObject);
            Color changeColor = new Color(0, 0.6863f, 1, 1);
            renderer.material.color = changeColor;
            beishu++;
           
          //  protect.SendMessage("AddPoints");
            Recordbeishu();
            blue++;
            green = 0;
            yellow = 0;
            if (blue == 1)
            {
                beishu = 1;
                Secai.point += 1;
                Addpoints();
                // speedDown.active = false;
                // protect.active = false;

            }
            else if (blue == 2)
            {
                Secai.point += 2;
                Addpoints();

            }
            else if (blue > 2)
            {
                Addpoints();
                Secai.point += beishu;
                // speedRush.active = true;

            }
            Addpoints();
        }
		else if (collisionInfo.tag == "EditorOnly")
        {
            // Debug.Log("碰撞到的物体的名字是:" + collisionInfo.gameObject.name);

            PlaySounds();
			Destroy(collisionInfo.gameObject);
           // renderer.material.color = Color.green;
            Color changeColorg = new Color(0, 0.733f, 0.032f, 0);
            renderer.material.color = changeColorg;
            beishu++;
            
            // protect.SendMessage("AddPoints");
            Recordbeishu();
            green++;
            yellow = 0;
            blue = 0;
            if (green == 1)
            {
                beishu = 1;
                Secai.point += 1;
                Addpoints();
                // protect.active = false;
                // speedRush.active = false;
            }
            else if (green == 2)
            {
                Secai.point += 2;
                Addpoints();

            }
            else if (green > 2)
            {
                //

                //speedDown.active = true;
                Addpoints();
                Secai.point += beishu;
            }
            Addpoints();
        }
        else if (collisionInfo.tag == "Respawn")
        {
            // Debug.Log("碰撞到的物体的名字是:" + collisionInfo.gameObject.name);

            PlaySounds();
            Destroy(collisionInfo.gameObject);
           // renderer.material.color = Color.yellow;
            Color changeColory = new Color(0.961f, 0.906f, 0, 0);
            renderer.material.color = changeColory;
            beishu++;
           
            Recordbeishu();
            yellow++;
            blue = 0;
            green = 0;
            if (yellow == 1)
            {
                beishu = 1;
                Secai.point += 1;
                Addpoints();
                //  speedRush.active = false;
                //  speedDown.active = false;
            }
            else if (yellow == 2)
            {
                Secai.point += 2;
                Addpoints();

            }
            else if (yellow > 2)
            {
                Addpoints();
                Secai.point += beishu;
                // protect.active = true;


            }
            
        }
    }

    private void Addpoints()
    {
        //GameObject.Find("Combo").animation.Stop();
        GameObject.Find("ComboHolder").transform.GetComponentInChildren<TextMesh>().text = "X" + beishu;
        //GameObject.Find("Combo").animation.Play("Combo");
        GameObject.Find("WaveText233").animation.Stop("comboText");
        GameObject.Find("WaveText233").animation.Play("comboText");
    }

    IEnumerator Wait()
    {
        // Vector3 movePosition = new Vector3(0, 10, 1.1f);
        yield return new WaitForSeconds(0.01f);
        // Application.LoadLevelAsync("Gameover");
        //transform.position = Vector3.MoveTowards(transform.position, tradPosition, UnityEngine.Time.smoothDeltaTime * 4);
        //GameObject.FindGameObjectWithTag("EditorOnly").transform.position = Vector3.MoveTowards(transform.position, movePosition, UnityEngine.Time.smoothDeltaTime * 2);
        //TriggerGameOver();
        // GameObject.Find("gameover").collider.enabled = true;
        //Secai.showover = true;
        Secai.backgroundmusic.audio.Stop();
        if (GameShare.i % 2 == 0)
        {
            gameovermusic.audio.Play();
        }
        Secai.showover = true;
        pauseeverything = true;
        Gameovermove.boolmove = true;
    }
    IEnumerator Waitmoment()
    {
        yield return new WaitForSeconds(1.2f);
        initial = false;
    }

 

    void Recordbeishu() {



        if (recordbeishu == 0)
        {
            recordbeishu = beishu;
           
        }
        if (recordbeishu < beishu)
        {

            recordbeishu = beishu;
           
        }
    }
    void PlaySounds() {
        
        if (GameShare.i % 2 == 0)
        {
        hitedmusic = Resources.Load("Audio/hit") as AudioClip;
        AudioSource.PlayClipAtPoint(hitedmusic, new Vector3(0, 10, 0), 1.0f);
        }
        // StartCoroutine(Playhit());
    }
  
}