﻿using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;

namespace ProLab.Domain.Addresses;

[Owned]
public class Address
{
    [Required]
    [MaxLength(150)]
    public string Street { get; set; }

    [MaxLength(75)]
    public string? City { get; set; }

    [MaxLength(75)]
    public string? District { get; set; }

    [MaxLength(75)]
    public string? Parish { get; set; }

    [Required]
    [MaxLength(10)]
    public string PostalCode { get; set; }

    [Required]
    public Point Location { get; set; }
}
