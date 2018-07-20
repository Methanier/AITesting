using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    [Header("Graph")]
    public Graph graph;


    [Header("Testing")]
    public Node start;
    public Node end;

    private DijkstarPath pathGenerator;

    public List<Connection> path;

	// Use this for initialization
	void Start () {

        pathGenerator = new DijkstarPath();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log("Test update");
        if(Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Getting Path");
            GetPath();
        }
		
	}

    void GetPath()
    {
        path = pathGenerator.DijkstarPathFind(graph, start, end);
    }
}
