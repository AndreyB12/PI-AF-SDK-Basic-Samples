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
using System.Collections.Generic;
using OSIsoft.AF;
using OSIsoft.AF.PI;


namespace ExamplesLibrary
{
    /// <summary>
    /// This example creates a floating and digital PI Point on the server.
    /// </summary>
    /// <prerequisite-examples>
    /// none
    /// </prerequisite-examples>
    public class CreatePIPointsExample : IExample
    {
        public void Run()
        {
            PIServers piServers = new PIServers();
            PIServer piServer = piServers["<AFSERVER>"];

            // Use PICommonPointAttributes so we don't have to remember the strings for point attributes.

            string floatpoint = "sample_floatpoint";
            Dictionary<string, object> floatpoint_attributes = new Dictionary<string, object>();
            floatpoint_attributes.Add(PICommonPointAttributes.PointClassName, "classic");
            floatpoint_attributes.Add(PICommonPointAttributes.Descriptor, "Hello floating world");
            floatpoint_attributes.Add(PICommonPointAttributes.PointType, "float32");

            string digitalpoint = "sample_digitalpoint";
            Dictionary<string, object> digitalpoint_attributes = new Dictionary<string, object>();
            digitalpoint_attributes.Add(PICommonPointAttributes.PointClassName, "classic");
            digitalpoint_attributes.Add(PICommonPointAttributes.Descriptor, "Hello digital world");
            digitalpoint_attributes.Add(PICommonPointAttributes.PointType, "digital");
            digitalpoint_attributes.Add(PICommonPointAttributes.DigitalSetName, "modes");

            Dictionary<string, IDictionary<string, object>> pointDict = new Dictionary<string, IDictionary<string, object>>();
            pointDict.Add(floatpoint, floatpoint_attributes);
            pointDict.Add(digitalpoint, digitalpoint_attributes);

            AFListResults<string, PIPoint> results = piServer.CreatePIPoints(pointDict);
        }
    }
}
