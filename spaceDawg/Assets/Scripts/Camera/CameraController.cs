using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Room Camera
    [SerializeField] private float speed;

    private float currentPosX;

    private Vector3 velocity = Vector3.zero;

    //Player Camera
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;

    private float lookAhead; 




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Smooth Damp method
        //Gradually changes a vector towards a desire goal
        //Room camera
        /*  transform.position = Vector3.SmoothDamp(
              transform.position,
              new Vector3(currentPosX,transform.position.y, transform.position.z),
              ref velocity,
              speed);
        */

        //Camera to follow the player
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);

        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
    }

    public void MoveLocation(Transform _newArea)
    {
        currentPosX = _newArea.position.x;
    }
}
