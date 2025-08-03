
using PathfindingSketch.Graph;

public static class Program
{
    public static void Main()
    {
        List<Node> nodes = new List<Node>()
        {
            new Node(0,0, 0),
            new Node(1,100, 20),
            new Node(2,200, -20),
            new Node(3,300, 20),
            new Node(4,400, -0),
        };
        List<Connection> connections = new List<Connection>()
        {
            new Connection(true,false,true,true,nodes[0],nodes[1]),
            new Connection(true,false,true,true,nodes[1],nodes[2]),
            new Connection(true,false,true,true,nodes[2],nodes[3]),
            new Connection(true,false,true,true,nodes[3],nodes[4]),
        };
        
        
        //Generate names of addresses
    }
}