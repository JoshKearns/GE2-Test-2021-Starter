using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            other.transform.parent = transform;
            other.GetComponent<Rigidbody>().useGravity = false;
            other.transform.position = transform.position;

            var seekScript = transform.parent.GetComponent<Seek>();
            seekScript.targetGameObject = GameObject.FindGameObjectWithTag("Player");
        }
    }

    public void DropBall()
    {
        var ball = transform.GetChild(0);

        ball.GetComponent<Collider>().isTrigger = false;
        ball.transform.parent = null;
        ball.GetComponent<Rigidbody>().useGravity = true;

        var barkScript = transform.parent.GetComponent<Bark>();
        barkScript.barkFunction();
    }
}
