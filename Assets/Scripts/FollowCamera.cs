using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]GameObject thingToFollow;
    void LateUpdate()
    {
        //Makes the camera follow the car
        transform.position = thingToFollow.transform.position + new Vector3(0,0,-20);
    }
}
