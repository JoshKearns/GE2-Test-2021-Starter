using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    public GameObject ball;
    public Transform ballPos;
    public float ballThrowSpeed;

    public Bark barkScript;
    public Seek seekScript;
    public Boid boidScript;
    public BallPickUp ballPickUpScript;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var targetDir = ballPos.position - transform.position;
            var spawnBall = Instantiate(ball, ballPos.transform.position, Quaternion.identity);
            spawnBall.GetComponent<Rigidbody>().AddForce(targetDir * ballThrowSpeed);
            
            barkScript.barkFunction();
            seekScript.targetGameObject = spawnBall;

            boidScript.canMove = true;
            
            ballPickUpScript.DropBall();
        }
    }
}
