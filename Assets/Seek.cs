using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Seek : SteeringBehaviour
{
    public GameObject targetGameObject = null;

    public Vector3 target = Vector3.zero;
    public BallPickUp _ballPickUp;

    public void OnDrawGizmos()
    {
        if (isActiveAndEnabled && Application.isPlaying)
        {
            Gizmos.color = Color.cyan;
            if (targetGameObject != null)
            {
                target = targetGameObject.transform.position;
            }
            Gizmos.DrawLine(transform.position, target);
        }
    }

    public override Vector3 Calculate()
    {
        return boid.SeekForce(target);
    }

    public void Update()
    {
        if (targetGameObject != null)
        {
            if (targetGameObject.CompareTag("Player"))
            {
                var dist = Vector3.Distance(targetGameObject.transform.position, transform.position);
                
                if (dist < 10)
                {
                    var player = GameObject.FindGameObjectWithTag("Player");
                    player.GetComponent<ThrowBall>().canThrow = true; Debug.Log("Test");
                    
                    _ballPickUp.DropBall();
                    targetGameObject = null;
                    var boidScript = GetComponent<Boid>();
                    boidScript.canMove = false;
                }
                else
                {
                    target = new Vector3(targetGameObject.transform.position.x, 0f, targetGameObject.transform.position.z);
                }
            }
            else
            {
                target = new Vector3(targetGameObject.transform.position.x, 0f, targetGameObject.transform.position.z);
            }
        }
    }
}