namespace PathfindingSketch.Graph;

/// <summary>
/// A node, which can be home to up to 2 addresses, (one on either side of the road)
/// </summary>
public class Node
{
    /// <summary>
    /// Unique ID of this node among all nodes,
    /// </summary>
    public int ID { get; private set; }
    
    /// <summary>
    /// The street number of this address, a number from 1 to whatever on each road
    /// Should always be odd, the node is automatically home to even numbered addresses on the other side of the road
    /// </summary>
    public int StreetNr { get; private set; }
    
    
    /// <summary>
    /// Location on the map in meters
    /// </summary>
    public double X { get; private set; }
    /// <summary>
    /// Location on the map in meters
    /// </summary>
    public double Y { get; private set; }
    
    public Dictionary<Node, Connection> Neighbours { get; private set; }


    public Node(int id, double x, double y)
    {
        this.ID = id;
        X = x;
        Y = y;
        
        //Will be set by the connections when added
        Neighbours = new Dictionary<Node, Connection>();
    }
}