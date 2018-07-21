using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarGraph {

    [SerializeField]
    public List<AStarNode> nodes;

    public AStarGraph()
    {
        nodes = new List<AStarNode>();
    }

    public void AddNode(AStarNode node)
    {
        nodes.Add(node);
    }

    public void RemoveNode(AStarNode node)
    {
        nodes.Remove(node);
    }
}
