#region Copyright
//  Copyright 2016  OSIsoft, LLC
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
#endregion
using System;
using System.Collections.Generic;
using OSIsoft.AF;
using OSIsoft.AF.Asset;
using OSIsoft.AF.PI;


namespace ExamplesLibrary
{
    /// <summary>
    /// Retrieving values from PIPoints is best done in bulk.
    /// By bulk retrieving the data, the number of round-trips to the PI Data Archive are reduced.
    /// This example makes a bulk snapshot call for SINUSOID, SINUSOIDU, CDT158, and CDM158 PI Points.
    /// </summary>
    /// <prerequisite-examples>
    /// none
    /// </prerequisite-examples>
    public class ReadFromPIExample : IExample
    {
        public void Run()
        {
            PIServers piServers = new PIServers();
            PIServer piServer = piServers["<PISERVER>"];

            IList<PIPoint> points = PIPoint.FindPIPoints(piServer, new[] { "sinusoid", "sinusoidu", "cdt158", "cdm158" });

            // Create an PIPointList object in order to make the bulk call later.
            PIPointList pointList = new PIPointList(points);

            if (pointList == null) return;

            // MAKE A BULK CALL TO THE PI DATA ARCHIVE
            AFListResults<PIPoint,AFValue> values = pointList.CurrentValue(); // Requires AF SDK 2.7+

            foreach (AFValue val in values)
            {
                Console.WriteLine("Point: {0}, Timestamp: {1}, Value: {2}", val.PIPoint, val.Timestamp, val.Value.ToString());
            }
        }

    }
}
