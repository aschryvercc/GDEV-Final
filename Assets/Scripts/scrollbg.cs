using UnityEngine;
using System.Collections;

public class scrollbg : MonoBehaviour {

    public float sizeofImg;
    public float scrollSpeed;
    private Vector3 startPosition;
	// Use this for initialization
	void Start () {
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, sizeofImg);
        transform.position = startPosition + Vector3.left * newPos;
    }
}
