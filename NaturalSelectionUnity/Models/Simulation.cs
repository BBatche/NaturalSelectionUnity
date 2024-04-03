using System;
using System.Collections.Generic;

namespace NaturalSelectionUnity.Models
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

