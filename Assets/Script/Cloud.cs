using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour {
    public Vector3 targetPosition = new Vector3(8.0F, 2.0F, 0.0F);
	// Use this for initialization

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (GameBegin.IsBegin)
        {
            Animator m_ani = this.GetComponent<Animator>();
            m_ani.enabled = false;

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, UnityEngine.Time.smoothDeltaTime * 2);
        }
        if (End.startretrunde) {
            Animator m_ani = this.GetComponent<Animator>();
            m_ani.enabled = true;
        }
	
	}

}
