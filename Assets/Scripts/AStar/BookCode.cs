/*def pathfindAStar(graph, start, end, heuristic): 
 
	// This structure is used to keep track of the 
	// information we need for each node 
	struct NodeRecord : node connection costSoFar estimatedTotalCost 
        node
        connection
        costSoFar
        estimatedTotalCost
 
	// Initialize the record for the start node
	startRecord = new NodeRecord()
	startRecord.node = start 
    startRecord.connection = None 
	startRecord.costSoFar = 0 
	startRecord.estimatedTotalCost = heuristic.estimate(start)

 
	// Initialize the open and closed lists 
	open = PathfindingList()
	open += startRecord 
	closed = PathfindingList()
 
	// Iterate through processing each node 
	while length(open) > 0: 
 
	    // Find the smallest element in the open list 
	    // (using the estimatedTotalCost) 
	    current = open.smallestElement() 
 
	    // If it is the goal node, then terminate 
	    if current.node == goal: break 
 
	    // Otherwise get its outgoing connections
	    connections = graph.getConnections(current) 
 
	    // Loop through each connection in turn 
        for connection in connections: 
 
	        // Get the cost estimate for the end node 
	        endNode = connection.getToNode() 
	        endNodeCost = current.costSoFar + connection.getCost() 
 
 
            // If the node is closed we may have to 
	        // skip, or remove it from the closed list. 
            if closed.contains(endNode): 
       
                // Here we find the record in the close list# corresponding to the endNode.
                // corresponding to the endNode
                endNodeRecord = close.find(endNode)
 
                // If we didn't find a shorter route, skip
                if endNodeRecord.costSoFar <= endNodeCost:
                    continue;
 
                // Otherwise remove it from the close list
                close -= endNodeRecord

                // We can use the node's old cost values 
                // to calculate its heuristic without calling
                // the possibly espensive heuristic function
                endNodeHeuristic = endNodeRecord.estimatedTotalCost - endNodeRecord.costSoFar;
 
 
            // Skip if the node is open and we've not
	        // found a better route
	        else if open.contains(endNode): 
 
	            // Here we find the record in the open list 
	            // corresponding to the endNode. 
	            endNodeRecord = open.find(endNode) 
 
	            // If our route is no better, then skip 
	            if endNodeRecord.costSoFar <= endNodeCost: 
	                continue; 
 
	            // We can use the node’s old cost values
                // to calculate its heuristic without calling 
                // the possibly expensive heuristic function 
                endNodeHeuristic = endNodeRecord.cost - endNodeRecord.costSoFar
                    

            // Otherwise we know we’ve got an unvisited 
            // node, so make a record for it
            else
                endNodeRecord = new NodeRecord()
                endNodeRecord.node = endNode
            
                // We'll need to colculate the heuristic value
                // using the function, since we don't have an
                // existing record to use
                endNodeHeuristic = heuristic.estimate(endNode)

            // We're here if we need to update the node
            // Update the cost, estimate and connection
            endNodeRecord.cost = endNodeCost
            endNodeRecord.connection = connection
            endNodeRecord.estimatedTotalCost = endNodeCost + endNodeHeuristic
            

            // And add it to the open list
            if not open.contains(endNode)
                open += endNodeRecord

        // We've finished looking at the connections for
        // the current node, so add it to the close list'
        // and remove it from the open list
        open -= current
        closed += current

    // We're here if we've either found the foal, or
    // if we've no more nodes to search, find which.
    if current.node != goal:

        // We've run out of nodes without finding the
        // goal, so there's no solution
        return None

    else:

        // Compile the list of connections in the path
        path = []

        // Work back along the path, accumulating
        // connections
        while current.node != start:
            path += current.connection
            current = current.connection.getFromNode()

        // reverse the path, and return it
        return reverse(path)
        */