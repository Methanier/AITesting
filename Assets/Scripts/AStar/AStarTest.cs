using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarTest : MonoBehaviour {

    [Header("Graph")]
    [HideInInspector]
    public AStarGraph graph;


    [Header("Testing")]
    public AStarNode start;
    public AStarNode end;

    private AStarPath pathGenerator;

    public List<AStarConnection> path;

    private void Awake()
    {
        graph.InitGraph();
    }

    // Use this for initialization
    void Start()
    {

        pathGenerator = new AStarPath();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Getting Path");
            GetPath();
        }

    }

    void GetPath()
    {
        path = pathGenerator.AStarPathFind(graph, start, end);
    }
}
