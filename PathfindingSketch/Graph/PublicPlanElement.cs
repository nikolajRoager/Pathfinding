namespace PathfindingSketch.Graph;

/// <summary>
/// An element of a travel plan for a public transport: A node with an associated expected time of arrival
/// </summary>
/// <param name="Location">Where exactly is it</param>
/// <param name="Time">When do we expect to arrive, in seconds after the start of the entire plan</param>
/// <param name="Stop">Does this location stop at this train</param>
public record PublicPlanElement(Node Location, double Time,bool Stop)
{
}