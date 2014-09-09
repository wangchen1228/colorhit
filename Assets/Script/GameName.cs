using UnityEngine;
using System.Collections;

public class GameName : MonoBehaviour
{

    Vector3 namePosition = new Vector3(0, 10, 0);
    Vector3 backPosition = new Vector3(0, 3, 0);
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameBegin.IsBegin)
        {
            transform.position = Vector3.MoveTowards(transform.position, namePosition, UnityEngine.Time.smoothDeltaTime * 3);
        }
        if (GameTrad.IsTrad)
        {
            transform.position = Vector3.MoveTowards(transform.position, namePosition, UnityEngine.Time.smoothDeltaTime * 3);
        }
        if (BackMain.IsBack)
        {
            transform.position = Vector3.MoveTowards(transform.position, backPosition, UnityEngine.Time.smoothDeltaTime * 3);
        }
        if (End.startretrunde)
        {
            transform.position = Vector3.MoveTowards(transform.position, backPosition, UnityEngine.Time.smoothDeltaTime * 5);
        }
    }
}