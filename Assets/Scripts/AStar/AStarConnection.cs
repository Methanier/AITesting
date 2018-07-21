using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarConnection {

    [SerializeField]
    private int _cost;
    [SerializeField]
    private AStarNode _fromNode;
    [SerializeField]
    private AStarNode _toNode;

    public int Cost { get { return _cost; } set { _cost = value; } }

    public AStarNode FromNode { get { return _fromNode; } }
    public AStarNode ToNode { get { return _toNode; } }
}
