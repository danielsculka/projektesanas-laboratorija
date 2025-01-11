namespace ProLab.Shared.RouteSets.Requests;

public class GenerateRouteSetRequest
{
    public string Name { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
}
