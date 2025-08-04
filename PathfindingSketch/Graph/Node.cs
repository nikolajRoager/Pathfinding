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
    /// This variable should always be odd, the node is automatically home to even numbered addresses on the other side of the road
    /// </summary>
    public int StreetNr { get; set; }
    /// <summary>
    /// What street are we on, must be a singular street, even if this node has multiple neighbours
    /// </summary>
    public string Street { get; set; }
    
    
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

        //Indicates that street number has not been set, it will be set externally when the streets are added
        StreetNr = 0;
        Street = "null";
    }
}