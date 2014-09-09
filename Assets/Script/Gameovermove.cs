using UnityEngine;
using System.Collections;

public class Gameovermove : MonoBehaviour
{

    public static bool boolmove = false;
    Vector3 gameoverPosition = new Vector3(-14, 0, -1);
    Vector3 gameoveredPosition = new Vector3(-6, 0, -1);

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (boolmove)
        {
            transform.position = Vector3.MoveTowards(transform.position, gameoverPosition, UnityEngine.Time.smoothDeltaTime * 8);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, gameoveredPosition, UnityEngine.Time.smoothDeltaTime * 8);
        }
    }

}
