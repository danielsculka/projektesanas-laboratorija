﻿namespace ProLab.Api.Features.RouteSets.Generate;

public class GenerateRouteSetRequest
{
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
