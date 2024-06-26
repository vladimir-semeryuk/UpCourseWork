﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upcoursework.Common.HealthChecks;
public class HealthCheck
{
    public string OverallStatus { get; set; }
    public IEnumerable<HealthCheckItem> HealthChecks { get; set; }
    public string TotalDuration { get; set; }
}

public class HealthCheckItem
{
    public string Status { get; set; }
    public string Component { get; set; }
    public string Description { get; set; }
    public string Duration { get; set; }
}