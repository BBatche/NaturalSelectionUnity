using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NaturalSelectionUnity.Models.Simulation
{
    public partial class Simulation
    {
        public string SimulationId { get; set; } = null!;

        public string SettingsId { get; set; } = null!;

        public string? UserEmail { get; set; }
    }
}
