using System;
using System.Collections.Generic;
using UnityEngine;


namespace NaturalSelectionUnity.Models.Generation
{

    public partial class Generation
    {
        public int GenerationId { get; set; }

        public string SimulationId { get; set; } = null!;

        public int? GenerationNum { get; set; }

        public int? PopulationCount { get; set; }

        public int PopulationDominant { get; set; }

        public int PopulationMiddle { get; set; }

        public int PopulationRecessive { get; set; }

        public int KilledByPlayer { get; set; }

        public int KilledByKillzone { get; set; }
    }
}