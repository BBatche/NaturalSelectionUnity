using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class BugAlleleScript : MonoBehaviour
    {
        public enum AlleleType
        {
            Dom,
            Mid,
            Rec
        }

        public AlleleType alleleType; // The allele type of the bug

        // Method to set the allele type of the bug
        public void SetAlleleType(AlleleType type)
        {
            alleleType = type;
        }

        public AlleleType getAlleleType()
        {
            return alleleType;
        }
    }

