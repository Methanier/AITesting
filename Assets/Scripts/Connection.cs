using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Connection {

    [SerializeField]
    private int _cost;
    [SerializeField]
    private Node _fromNode;
    [SerializeField]
    private Node _toNode;

    public int Cost { get { return _cost; } set { _cost = value; } }

    public Node FromNode { get { return _fromNode; } }
    public Node ToNode { get { return _toNode; } }
} 
