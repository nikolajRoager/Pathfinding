
using System.Xml;
using PathfindingSketch.Graph;

public static class Program
{
    public static void Main()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load("map.xml");
        
        List<Node> nodes = new List<Node>();
        
        
        var root = doc.DocumentElement;
        
        var nodesNode = root?.SelectSingleNode("nodes");
        var connectionsNode = root?.SelectSingleNode("connections");

        

        int expectedId = 0;
        foreach (XmlNode node in nodesNode.SelectNodes("node"))
        {
            int id = int.Parse(node.Attributes.GetNamedItem("id").Value);
            double x = double.Parse(node.Attributes.GetNamedItem("x").Value);
            double y = double.Parse(node.Attributes.GetNamedItem("y").Value);
            
            nodes.Add(new Node(id, x, y));
            
            if (id != expectedId)
                throw new Exception($"id of nodes is out of order id {id} was expected to be {expectedId}");
            ++expectedId;
        }

        List<Connection> connections = new List<Connection>();

        foreach (XmlNode node in connectionsNode.SelectNodes("connection"))
        {
            bool road = bool.Parse(node.Attributes?.GetNamedItem("road")?.Value ?? "false");
            bool rail = bool.Parse(node.Attributes?.GetNamedItem("rail")?.Value ?? "false");
            bool pedestrianPath = bool.Parse(node.Attributes?.GetNamedItem("pedestrianPath")?.Value ?? "false");
            bool bicyclePath = bool.Parse(node.Attributes?.GetNamedItem("bicyclePath")?.Value ?? "false");

            var fromString = node.Attributes?.GetNamedItem("from")?.Value;
            var toString= node.Attributes?.GetNamedItem("to")?.Value;
            if (fromString == null)
                throw new Exception("From attribute missing in a connection");
            if (toString == null)
                throw new Exception("To attribute missing in a connection");
            int fromId = int.Parse(fromString);
            int toId = int.Parse(toString);
            
            string name = node.Attributes?.GetNamedItem("name")?.Value ?? "null boulevard";
            
            Console.WriteLine("Connect "+fromId+" "+toId+" "+name);
            connections.Add(new Connection(road,rail,pedestrianPath,bicyclePath,nodes[fromId],nodes[toId],name));
        }


        //We will loop through each street with a unique name, and add house numbers
        Dictionary<string, int> streetNumbers = new Dictionary<string, int>();

        foreach (Connection connection in connections)
        {
            //Add 1 to the list of street numbers added, if it doesn't already exist
            if (!streetNumbers.TryAdd(connection.Name, 1))
            {
                //Otherwise increment by 2 (each node has both odd and even numbered houses)
                streetNumbers[connection.Name] += 2;
            }
            //Update the street number of the first house on this road
            connection.From.StreetNr = streetNumbers[connection.Name];
            connection.From.Street = connection.Name;
        }
        foreach (Node node in nodes)
            if (node.StreetNr == 0)//A node doesn't have a street number?
            {
                //Just pick a random street, and make this the final address
                if (node.Neighbours.Count == 0)
                {
                    throw new Exception($"Had node with no neighbours ({node.ID}), this is not allowed");
                }

                //Get any connection and make that the street
                var myStreet = node.Neighbours.First().Value;
                node.StreetNr=streetNumbers[myStreet.Name]+2;
                node.Street=myStreet.Name;


            }


        Console.WriteLine("Created nodes with addresses:");
        foreach (Node node in nodes)
        {
            Console.WriteLine($"{node.Street} {node.StreetNr}: {node.ID}");
            Console.WriteLine($"{node.Street} {node.StreetNr+1}: {node.ID}");
        }
        
    }
}