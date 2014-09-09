using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour
{
    public GameObject gameObject;
    public static float presentvelocity;
   
    
    // Use this for initialization
    void Start()
    {
       
        rigidbody.velocity = new Vector3(0,( 3.30f+0.02f*Secai.speed), 0);
     
    }

    // Update is called once per frame
    void Update()
    {
        if (End.destroycube)
        {
            if (gameObject.transform.position.y > -10) {
                Destroy(gameObject);
            }
        }
        if (Player.pauseeverything) {
            rigidbody.velocity = new Vector3(0 , 0, 0);
        }
        if (gameObject.transform.position.y > 4)
        {
            Destroy(gameObject);
        }
    }
}