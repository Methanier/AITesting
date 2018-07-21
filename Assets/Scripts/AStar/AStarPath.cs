using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct AStarNodeRecord
{
    public AStarNode node;
    public AStarConnection connection;
    public int costSoFar;

    public AStarNodeRecord(AStarNode inNode, AStarConnection con, int cost)
    {
        this.node = inNode;
        this.connection = con;
        this.costSoFar = cost;
    }

    public AStarNodeRecord(AStarNodeRecord record)
    {
        this.node = record.node;
        this.connection = record.connection;
        this.costSoFar = record.costSoFar;
    }
}

public class AStarPath
{

    private List<AStarNodeRecord> openList;
    private List<AStarNodeRecord> closedList;


    public List<AStarConnection> DijkstarPathFind(AStarGraph graph, AStarNode start, AStarNode end)
    {
        List<AStarConnection> path = new List<AStarConnection>();

        AStarNodeRecord current = new AStarNodeRecord();

        List<AStarConnection> currentConnections = new List<AStarConnection>();

        AStarNodeRecord endNode = new AStarNodeRecord();
        AStarNodeRecord endNodeRecord = new AStarNodeRecord();



        AStarNodeRecord startRecord = new AStarNodeRecord();
        startRecord.node = start;
        startRecord.connection = null;
        startRecord.costSoFar = 0;

        openList = new List<AStarNodeRecord>();
        openList.Add(startRecord);

        closedList = new List<AStarNodeRecord>();

        while (openList.Count > 0)
        {
            current = SmallestElement(openList);

            if (current.node == end)
                break;

            currentConnections = current.node.GetConnections();

            foreach (AStarConnection conect in currentConnections)
            {
                endNode.node = conect.ToNode;
                endNode.connection = conect;
                endNode.costSoFar = current.costSoFar + conect.Cost;

                if (closedList.Contains(endNode))
                {
                    //continue
                }
                else if (openList.Contains(endNode))
                {
                    endNodeRecord = openList.Find(x => openList.Contains(endNode));

                    if (endNodeRecord.costSoFar <= endNode.costSoFar)
                    {
                        //continue
                    }
                }
                else
                {
                    endNodeRecord = new AStarNodeRecord(endNode);
                }

                if (!openList.Contains(endNode))
                {
                    openList.Add(endNodeRecord);
                }
            }

            openList.Remove(current);
            closedList.Add(current);
        }

        if (current.node != end)
        {
            //return none
        }
        else
        {

            AStarNode temp = new AStarNode();


            while (current.node != start)
            {
                path.Add(current.connection);
                temp = current.connection.FromNode;

                for (int i = closedList.Count - 1; i >= 0; i--)
                {
                    if (closedList[i].node == temp)
                    {
                        current = closedList[i];
                    }
                }

            }
        }

        return path;
    }

    AStarNodeRecord SmallestElement(List<AStarNodeRecord> list)
    {
        AStarNodeRecord result = new AStarNodeRecord();

        AStarNodeRecord temp = new AStarNodeRecord();

        temp = list[0];

        for (int i = 0; i < list.Count; i++)
        {
            foreach (AStarConnection con in list[i].node.GetConnections())
            {
                if (con.Cost < temp.costSoFar)
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
