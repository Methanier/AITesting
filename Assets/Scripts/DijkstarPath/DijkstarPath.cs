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

public class DijkstarPath {

    private List<NodeRecord> openList;
    private List<NodeRecord> closedList;

	
    public List<Connection> DijkstarPathFind(Graph graph, Node start, Node end)
    {
        List<Connection> path = new List<Connection>();

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
            
            Node temp;


            while(current.node != start)
            {
                path.Add(current.connection);
                temp = current.connection.FromNode;

                for (int i = closedList.Count - 1;  i >= 0; i--)
                {
                    if (closedList[i].node == temp)
                    {
                        current = closedList[i];
                    }
                }
                
            }
        }

        path.Reverse();

        return path;
    }

    NodeRecord SmallestElement(List<NodeRecord> list)
    {
        NodeRecord result = new NodeRecord();

        NodeRecord temp = new NodeRecord();

        temp = list[0];

        int tempCost = list[0].node.GetConnections()[0].Cost;

        for(int i = 0; i < list.Count; i++)
        {
            foreach(Connection con in list[i].node.GetConnections())
            {
                if(con.Cost < tempCost)
                {
                    temp = list[i];
                    tempCost = con.Cost;
                }
            }
        }

        result = temp;

        return result;
    }
}
