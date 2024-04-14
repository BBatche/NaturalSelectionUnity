using System;
using System.Collections.Generic;
using UnityEngine;

namespace NaturalSelectionUnity.Models.Settings
{

    public partial class Setting
    {
        public int SettingsId { get; set; }

        public int? MovementSpeed { get; set; }

        public string? MovementType { get; set; }

        public int? BeginningPopulation { get; set; }

        public int? KillZones { get; set; }

        public string? BackgroundColor { get; set; }

        public int? BeginningDominant { get; set; }

        public int? BeginningMiddle { get; set; }

        public int? BeginningRecessive { get; set; }

        public string? UserEmail { get; set; }
    }
}