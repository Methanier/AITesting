using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct AStarNodeRecord
{
    public AStarNode node;
    public AStarConnection connection;
    public float costSoFar;
    public float estimatedTotalCost;

    public AStarNodeRecord(AStarNode inNode, AStarConnection con, float cost, float estimate)
    {
        this.node = inNode;
        this.connection = con;
        this.costSoFar = cost;
        this.estimatedTotalCost = estimate;
    }

    public AStarNodeRecord(AStarNodeRecord record)
    {
        this.node = record.node;
        this.connection = record.connection;
        this.costSoFar = record.costSoFar;
        this.estimatedTotalCost = record.estimatedTotalCost;
    }
}

public class AStarPath
{

    private List<AStarNodeRecord> openList;
    private List<AStarNodeRecord> closedList;


    public List<AStarConnection> AStarPathFind(AStarGraph graph, AStarNode start, AStarNode end)
    {
        List<AStarConnection> path = new List<AStarConnection>();

        AStarNodeRecord current = new AStarNodeRecord();

        List<AStarConnection> currentConnections = new List<AStarConnection>();

        AStarNodeRecord endNode = new AStarNodeRecord();
        AStarNodeRecord endNodeRecord = new AStarNodeRecord();

        float endNodeHeuristic = 0;



        AStarNodeRecord startRecord = new AStarNodeRecord();
        startRecord.node = start;
        startRecord.connection = null;
        startRecord.costSoFar = 0;
        startRecord.estimatedTotalCost = Heuristic(start, end);

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
                    endNodeRecord = closedList.Find(x => closedList.Contains(endNode));

                    if(endNodeRecord.costSoFar <= endNode.costSoFar)
                    {
                        //continue
                    }
                    else
                    {
                        closedList.Remove(endNodeRecord);
                        endNodeHeuristic = endNodeRecord.estimatedTotalCost - endNodeRecord.costSoFar;
                    }
                }
                else if (openList.Contains(endNode))
                {
                    endNodeRecord = openList.Find(x => openList.Contains(endNode));

                    if (endNodeRecord.costSoFar <= endNode.costSoFar)
                    {
                        //continue
                    }
                    else
                    {
                        endNodeHeuristic = endNodeRecord.estimatedTotalCost - endNodeRecord.costSoFar;
                    }
                }
                else
                {
                    endNodeRecord = new AStarNodeRecord(endNode);
                    endNodeHeuristic = Heuristic(endNode.node, end);
                }

                endNodeRecord.costSoFar = endNode.costSoFar;
                endNodeRecord.connection = endNode.connection;
                endNodeRecord.estimatedTotalCost = endNodeRecord.costSoFar + endNodeHeuristic;

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
        path.Reverse();

        return path;
    }

    AStarNodeRecord SmallestElement(List<AStarNodeRecord> list)
    {
        AStarNodeRecord result = new AStarNodeRecord();

        result = list[0];

        for (int i = 0; i < list.Count; i++)
        {
            if(list[i].estimatedTotalCost < result.estimatedTotalCost)
            {
                result = list[i];
            }
        }

        return result;
    }

    float Heuristic(AStarNode start, AStarNode end)
    {
        Vector3 diference = start.transform.position - end.transform.position;

        float mag = diference.magnitude;

        return mag;
    }
}


