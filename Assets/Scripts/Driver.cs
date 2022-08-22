using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    //Set the turning speed
    [SerializeField]float steerSpeed = 250f;
    //Set the movement speed
    [SerializeField]float moveSpeed = 10f;
    //Set the movement speed when slowed 
    [SerializeField]float slowSpeed = 6f;
    //Set the movement speed when boosted
    [SerializeField]float boostSpeed = 16f;

    void Update()
    {
        //Set steerAmount to be the horizontal keys times steerSpeed
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        //Set moveAmount to be the vertical keys times moveSpeed 
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        //Moves the car fowards equals the moveAmount value
        transform.Translate(0, moveAmount, 0);
        //Rotates the car equals the steerAmount value
        transform.Rotate(0, 0, -steerAmount);
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        //When the car collides with obstacles, it will slow down
        moveSpeed = slowSpeed;
    }
    void OnTriggerEnter2D(Collider2D other) 
        {
            //If the car touches the Boosts it will:
            if(other.tag == "Boost")
            {
                //Boost the speed up
                moveSpeed = boostSpeed;
            }
        }
}
