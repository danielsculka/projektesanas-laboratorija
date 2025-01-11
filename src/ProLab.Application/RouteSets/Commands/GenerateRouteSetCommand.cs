namespace ProLab.Application.RouteSets.Commands;

public class GenerateRouteSetCommand
{
    public required string Name { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
}
