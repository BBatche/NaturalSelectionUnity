using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NaturalSelectionUnity.Models.Simulation
{
    public partial class Simulation
    {
        public int SimulationId { get; set; }

        public int SettingsId { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public bool? IsActive { get; set; }

        public string? UserEmail { get; set; }
    }
}
