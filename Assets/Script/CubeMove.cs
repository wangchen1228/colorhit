using UnityEngine;
using System.Collections;

public class CubeMove : MonoBehaviour
{

    Vector3 cubePosition = new Vector3(0, 2.5F, 0);
    Vector3 tradPosition = new Vector3(0, 10, 0);
    Vector3 backPosition = new Vector3(0, 0.5F, 0);
    public GameObject player;
    public GameObject playermid;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameBegin.IsBegin)
        {
            //animation["Cube"].normalizedTime = 0;
            //animation["Cube"].speed = 0;
            //.Rewind("player");
            //animation["player"].speed = 0;
            transform.position = Vector3.MoveTowards(transform.position, cubePosition, UnityEngine.Time.smoothDeltaTime * 1.5F);
            if (transform.position == cubePosition)
            {
                player.active = true;
                playermid.active = false;
            }
        }
        if (GameTrad.IsTrad)
        {
            //animation.Rewind("Cube");
            //animation["player"].speed = 0;
            transform.position = Vector3.MoveTowards(transform.position, tradPosition, UnityEngine.Time.smoothDeltaTime * 4);
        }
        if (BackMain.IsBack)
        {
            transform.position = Vector3.MoveTowards(transform.position, backPosition, UnityEngine.Time.smoothDeltaTime * 4);
            //animation.Play();
            //animation["player"].speed = 1;
        }
        if (End.startretrunde)
        {
            transform.position = Vector3.MoveTowards(transform.position, backPosition, UnityEngine.Time.smoothDeltaTime * 1);
        }
    }
}