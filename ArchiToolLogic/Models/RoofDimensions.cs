/**********************************************************
 * ROOFDIMENSIONS.CS
 * 
 * Purpose: A collection of information about roof dimensions
 * internal column height(ICH), external column height(ECH), 
 * distance between columns, and slope.
 * 
 * Author: Maria Bennett
 * ********************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArchiTool.ArchiToolLogic.Models
{
    public class RoofDimensions
    {

        //Constructor
        public RoofDimensions()
        {
            ICHValue =      new Number(0);
            ECHValue =      new Number(0);
            DistanceValue = new Number(0);
            SlopeValue =    new Number(0);
            ICHString = "";
            ECHString = "";
            DistanceString = "";
            SlopeString = "";
            ICHName =      "Interior Column Height";
            ECHName =      "Exterior Column Height";
            DistanceName = "Distance Between Columns";
            SlopeName =    "Slope";
            DimensionFormat =      new List<string>();
            SlopeDimensionFormat = new List<string>();
            DimensionFormat.Add("Select Units");
            DimensionFormat.Add("Feet and Inches (Eighths)");
            DimensionFormat.Add("Feet and Inches (Sixteenths)");
            DimensionFormat.Add("Decimal Feet");
            SlopeDimensionFormat.Add("Select Units");
            SlopeDimensionFormat.Add("Inches per Linear Foot (Eighths)");
            SlopeDimensionFormat.Add("Inches per Linear Foot (Sixteenths)");
            SlopeDimensionFormat.Add("Decimal Inches per Linear Foot");
            SlopeDimensionFormat.Add("Degrees");
            SlopeDimensionFormatSelected = "Select Units";
            ICHDimensionFormatSelected = "Select Units";
            ECHDimensionFormatSelected = "Select Units";
            DistanceDimensionFormatSelected = "Select Units";
            ErrorMessage = "Select units, enter 3 dimensions, and click calculate";
    }

        //Copy Constructor
        public RoofDimensions(RoofDimensions rd)
        {
            ICHValue = rd.ICHValue;
            ECHValue = rd.ECHValue;
            DistanceValue = rd.DistanceValue;
            SlopeValue = rd.SlopeValue;
            ICHString = rd.ICHString;
            ECHString = rd.ECHString;
            DistanceString = rd.DistanceString;
            SlopeString = rd.SlopeString;
            ICHName = rd.ICHName;
            ECHName = rd.ECHName;
            DistanceName = rd.DistanceName;
            SlopeName = rd.SlopeName;
            DimensionFormat = rd.DimensionFormat;
            SlopeDimensionFormat = rd.SlopeDimensionFormat;
            SlopeDimensionFormatSelected =rd.SlopeDimensionFormatSelected;
            ICHDimensionFormatSelected = rd.ICHDimensionFormatSelected;
            ECHDimensionFormatSelected = rd.ECHDimensionFormatSelected;
            DistanceDimensionFormatSelected = rd.DistanceDimensionFormatSelected;
            ErrorMessage = rd.ErrorMessage;
            Id = rd.Id;
        }

        public string ErrorMessage { get; set; }
        public int Id { get; set; }

        //Format Input/Display Options
        public List<string> DimensionFormat { get; set; }
        public List<string> SlopeDimensionFormat { get; set; }

        public string SlopeDimensionFormatSelected { get; set; }
        public string ICHDimensionFormatSelected { get; set; }
        public string ECHDimensionFormatSelected { get; set; }
        public string DistanceDimensionFormatSelected { get; set; }

        //Interior Column Height
        public string ICHName { get; set; } 
        public Number ICHValue { get; set; }
        public string ICHString { get; set; }

        //Exterior Column Height
        public string ECHName { get; set; } 
        public Number ECHValue { get; set; }
        public string ECHString { get; set; }

        //Slope
        public string SlopeName { get; set; }
        public Number SlopeValue { get; set; }
        public string SlopeString { get; set; }

        //Distance between columns
        public string DistanceName { get; set; }
        public Number DistanceValue { get; set; }
        public string DistanceString { get; set; }
        
    }
}
