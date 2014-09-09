using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {
    public static int Backgroundmove = 0;
    public static int test = 1;
    public static bool reach = false;
    Vector3 backgroundPosition = new Vector3(0, 0, 1);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       // Debug.Log("test:" + test);
       // if (Backgroundmove == 1)
       // {
              //  Vector2 velocity = new Vector2(0, -3);
              //  rigidbody2D.velocity = velocity;
            
       // }

        if (GameBegin.IsBegin) {
            transform.position = Vector3.MoveTowards(transform.position, backgroundPosition, UnityEngine.Time.smoothDeltaTime * 4);
            if (transform.position.y < -11.4f) {
                reach = true;
            }
        }
	}
  
   // public  static void Move() {
       // Backgroundmove = 1;
    //}

    
}
