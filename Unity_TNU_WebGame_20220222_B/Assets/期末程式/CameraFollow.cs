using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float cameraDistance = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
    }
    void Awake()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2 ) / cameraDistance);
    }
    
    void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x,player.position.y,transform.position.z);
    }
    // Update is called once per frame

    
}
