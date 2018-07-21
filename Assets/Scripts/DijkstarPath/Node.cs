using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    [SerializeField]
    private readonly GameObject data;
    [SerializeField]
    private List<Connection> connections;

    public void AddConnection(Connection connection)
    {
        connections.Add(connection);
    }

    public void Removeconneciton(Connection connection)
    {
        connections.Remove(connection);
    }

    public List<Connection> GetConnections()
    {
        return connections;
    }
}
