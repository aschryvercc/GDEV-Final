using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    public float cameraDistOffset = 10;
    public Camera mainCamera;
    public GameObject player;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerInfo = player.transform.transform.position;
        mainCamera.transform.position = new Vector3(playerInfo.x, playerInfo.y, playerInfo.z - cameraDistOffset);
    }
}
