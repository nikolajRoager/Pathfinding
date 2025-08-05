namespace PathfindingSketch.Graph;

/// <summary>
/// The plan for a public transport, which travels betwixt nodes following a fixed schedule
/// </summary>
public class PublicTransportPlan
{
    /// <summary>
    /// Name of this thing, I.e. the train or bus number/code ICL40, X233, 60
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Used for verifying the validity of the transport, trains must move on rail links, non trains (buses) must move on roads
    /// </summary>
    public bool IsTrain { get; set; }
    
    public List<PublicPlanElement> PlanElements { get; set; }
    
    /// <summary>
    /// When, in seconds after the start of the simulation (midnight), does the plan start? for example, the bus may debart from the first station at 7:00, 7:30, and 8:30
    /// </summary>
    public List<double> StartTimes { get; set; }

    public PublicTransportPlan(string name, bool isTrain, List<PublicPlanElement> planElements, List<double> startTimes)
    {
        Name = name;
        IsTrain = isTrain;
        PlanElements = planElements;
        StartTimes = startTimes;
    }
}