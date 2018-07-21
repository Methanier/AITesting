using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarNode : MonoBehaviour {

    public bool showConnections;
    public Transform tf;

    [SerializeField]
    public Vector3 scale;
    [SerializeField]
    private readonly GameObject data;
    [SerializeField]
    private List<AStarConnection> connections;

    public AStarConnection ParentConnection { get; set; }

    private void Awake()
    { 
        foreach(AStarConnection con in connections)
        {
            con.FromNode = this;
        }
    }

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

    private void OnDrawGizmos()
    {
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        Gizmos.color = Color.red;
        Gizmos.DrawCube(Vector3.up * scale.y / 2f, scale);
        Gizmos.DrawRay(Vector3.zero, Vector3.forward * 0.4f);

        Gizmos.color = Color.green;

        if(showConnections)
        {
            foreach (AStarConnection con in connections)
            {
                Vector3 vectorToNode = con.ToNode.transform.position - transform.position;
                Gizmos.DrawRay(Vector3.zero, vectorToNode);
            }
        }        
    }
}
