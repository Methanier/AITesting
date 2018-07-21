using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AStarConnection {

    [SerializeField]
    private int _cost;
    private AStarNode _fromNode;
    [SerializeField]
    private AStarNode _toNode;

    public int Cost { get { return _cost; } set { _cost = value; } }

    public AStarNode FromNode { get { return _fromNode; } set { _fromNode = value; } }
    public AStarNode ToNode { get { return _toNode; } }
}
