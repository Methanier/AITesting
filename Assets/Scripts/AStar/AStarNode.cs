using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarNode : MonoBehaviour {

    
    [SerializeField]
    private readonly GameObject data;
    [SerializeField]
    private List<AStarConnection> connections;

    public AStarConnection ParentConnection { get; set; }


    public void AddConnection(AStarConnection connection)
    {
        connections.Add(connection);
    }

    public void Removeconneciton(AStarConnection connection)
    {
        connections.Remove(connection);
    }

    public List<AStarConnection> GetConnections()
    {
        return connections;
    }
}
