using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{

    public Transform player;
    public float smoothRate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 playerPosiition = player.position;
        Vector3 cameraPositon = transform.position;

        //cameraPositon.x = playerPosiition.x;
        cameraPositon.x = Mathf.Lerp(cameraPositon.x, playerPosiition.x, smoothRate);
        transform.position = cameraPositon;
    }
}
