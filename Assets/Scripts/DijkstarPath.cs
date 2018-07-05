using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct NodeRecord
{
    public Node node;
    public Connection connection;
    public int costSoFar;

    public NodeRecord(Node inNode, Connection con, int cost)
    {
        this.node = inNode;
        this.connection = con;
        this.costSoFar = cost;
    }

    public NodeRecord(NodeRecord record)
    {
        this.node = record.node;
        this.connection = record.connection;
        this.costSoFar = record.costSoFar;
    }
}

public class DijkstarPath : MonoBehaviour {

    private List<NodeRecord> openList;
    private List<NodeRecord> closedList;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DijkstarPathFind(Graph graph, Node start, Node end)
    {
        NodeRecord current = new NodeRecord();

        List<Connection> currentConnections = new List<Connection>();

        NodeRecord endNode = new NodeRecord();
        NodeRecord endNodeRecord = new NodeRecord();
        
        

        NodeRecord startRecord = new NodeRecord();
        startRecord.node = start;
        startRecord.connection = null;
        startRecord.costSoFar = 0;

        openList = new List<NodeRecord>();
        openList.Add(startRecord);

        closedList = new List<NodeRecord>();

        while(openList.Count > 0)
        {
            current = SmallestElement(openList);

            if (current.node == end)
                break;

            currentConnections = current.node.GetConnections();

            foreach(Connection conect in currentConnections)
            {
                endNode.node = conect.ToNode;
                endNode.connection = conect;
                endNode.costSoFar = current.costSoFar + conect.Cost;                

                if(closedList.Contains(endNode))
                {
                    //continue
                }
                else if(openList.Contains(endNode))
                {
                    endNodeRecord = openList.Find(x => openList.Contains(endNode));

                    if(endNodeRecord.costSoFar <= endNode.costSoFar)
                    {
                        //continue
                    }
                }
                else
                {
                    endNodeRecord = new NodeRecord(endNode);
                }

                if(!openList.Contains(endNode))
                {
                    openList.Add(endNodeRecord);
                }
            }

            openList.Remove(current);
            closedList.Add(current);
        }

        if(current.node != end)
        {
            //return none
        }
        else
        {
            List<Connection> path = new List<Connection>();


            while(current.node != start)
            {
                path.Add(current.connection);
                
            }
        }
    }

    NodeRecord SmallestElement(List<NodeRecord> list)
    {
        NodeRecord result = new NodeRecord();

        NodeRecord temp = new NodeRecord();

        temp = list[0];

        for(int i = 0; i < list.Count; i++)
        {
            foreach(Connection con in list[i].node.GetConnections())
            {
                if(con.Cost < temp.costSoFar)
                {
                    temp = list[i];
                    temp.costSoFar = con.Cost;
                }
            }
        }

        result = temp;

        return result;
    }
}
