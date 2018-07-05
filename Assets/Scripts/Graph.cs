using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Graph {

    [SerializeField]
    public List<Node> nodes;

    public Graph()
    {
        nodes = new List<Node>();
    }

    public void AddNode(Node node)
    {
        nodes.Add(node);
    }

    public void RemoveNode(Node node)
    {
        nodes.Remove(node);
    }    	
}
