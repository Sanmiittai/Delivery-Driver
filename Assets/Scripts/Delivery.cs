using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    //Color if the car has a package
    [SerializeField]Color32 hasPackageColor = new Color32 (1, 1, 1, 1);
    //Color if the car dont has a package
    [SerializeField]Color32 noPackageColor = new Color32 (1, 1, 1, 1);
    //Defines if the car has a package, starts false
    bool hasPackage = false;

    SpriteRenderer spriteRenderer;

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        //Debug of crash
        Debug.Log("I crashed!");
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        //If the car touches a package and dont has a package it will:
        if(other.tag == "Package" && !hasPackage)
        {
            //Say that the package was picked
            Debug.Log("Package picked up");
            //Turn hasPackage to true
            hasPackage = true;
            //Change the color of the car
            spriteRenderer.color = hasPackageColor;
            //Destroy the package
            Destroy(other.gameObject);
        }
        //If the car already has a package it  will:
        else if(other.tag == "Package" && hasPackage)
        {
            //Say that he already has a package
            Debug.Log("I already have a package!");
        }
        //If the car touches a Customer and has a package ir will:
        if(other.tag == "Customer" && hasPackage)
        {
            //Say it delivered the package
            Debug.Log("Package delivered");
            //Turn hasPackage to false
            hasPackage = false;
            //Change the color of the car
            spriteRenderer.color = noPackageColor;
        }
        //If the car touches a Customer and dont has a package i will:
        else if(other.tag == "Customer" && !hasPackage)
        {
            //Say that he dont has a package
            Debug.Log("I don't have any package!");
        }
    }
}
