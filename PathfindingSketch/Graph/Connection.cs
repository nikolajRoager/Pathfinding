namespace PathfindingSketch.Graph;

public class Connection
{
    public bool Road { get; private set; }
    public bool Rail { get; private set; }
    public bool PedestrianPath { get; private set; }
    public bool BicyclePath{ get; private set; }
    
    public Node From { get; private set; }
    public Node To { get; private set; }

    public Connection(bool road, bool rail, bool pedestrianPath, bool bicyclePath, Node from, Node to)
    {
        Road = road;
        Rail = rail;
        PedestrianPath = pedestrianPath;
        BicyclePath = bicyclePath;
        From = from;
        To = to;
        
        From.Neighbours.Add(To, this);
        To.Neighbours.Add(From, this);
    }
}