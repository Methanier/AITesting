using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AStarGraph {

    [SerializeField]
    public List<AStarNode> nodes;

    public AStarGraph()
    {
        nodes = new List<AStarNode>();
    }

    public void InitGraph()
    {
        AStarNode[] temp = GameObject.FindObjectsOfType<AStarNode>();

        for (int i = 0; i < temp.Length; i++)
        {
            nodes.Add(temp[i]);
        }
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
