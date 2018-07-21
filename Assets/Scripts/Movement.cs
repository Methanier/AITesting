﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float moveSpeed;
    public float rotateSpeed;
    public float buffer;
    private Transform tf;

    [SerializeField]
    private List<Connection> path;

    private GameObject destination;
    private DijkstarPath pathGenerator;
    private Test test;
    private bool hasDestination = false;
    private int pathIndex = 0;

	// Use this for initialization
	void Start () {

        pathGenerator = new DijkstarPath();
        path = new List<Connection>();
        test = GameObject.FindObjectOfType<Test>();
        tf = GetComponent<Transform>();

	}
	
	// Update is called once per frame
	void Update () {

        AI();

	}

    public void Move()
    {
        tf.Translate(Vector3.forward * moveSpeed * Time.deltaTime);        
    }

    public bool RotateTowards(GameObject target)
    {
        Vector3 vectorToTarget = target.transform.position - tf.position;

        Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget);

        if (targetRotation != tf.rotation)
        {
            tf.rotation = Quaternion.RotateTowards(tf.rotation, targetRotation, rotateSpeed * Time.deltaTime);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AI()
    {
        if (path.Count == 0)
        {
            path = pathGenerator.DijkstarPathFind(test.graph, test.start, test.end);
        }

        destination = path[pathIndex].ToNode.gameObject;
        hasDestination = true;

        
        float distanceToTarget = Vector3.SqrMagnitude(destination.transform.position - tf.position);

        if(RotateTowards(destination))
        {

        }
        else if(distanceToTarget > buffer * buffer)
        {
            Move();
        }
        else if(distanceToTarget <= buffer * buffer)
        {
            pathIndex++;
            if(pathIndex >= path.Count)
            {

            }
            else
            {

            }
        }
    }
}
