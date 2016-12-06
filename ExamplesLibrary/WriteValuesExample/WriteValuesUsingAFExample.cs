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
using OSIsoft.AF.Data;
using OSIsoft.AF.Time;


namespace ExamplesLibrary
{
    /// <summary>
    /// This example demonstrates how to write values to the PI Data Archive via an AF Server.
    /// An example for numeric and digital tags is given.
    /// </summary>
    /// <prerequisite-examples>
    /// BuildSimpleDatabaseExample
    /// </prerequisite-examples>
    public class WriteValuesUsingAFExample : IExample
    {
        public void Run()
        {
            PISystems piSystems = new PISystems();
            PISystem piSystem = piSystems["<AFSERVER>"];

            AFDatabase afDatabase = piSystem.Databases["Basic-AFSDK-Sample"];

            AFElement boilerA = afDatabase.Elements["Region_0"].Elements["BoilerA"];

            AFElementTemplate elementTemplate = afDatabase.ElementTemplates["BasicBoilerTemplate"];
            AFAttributeTemplate temperatureAttrTemplate = elementTemplate.AttributeTemplates["Temperature"];
            AFAttributeTemplate modeAttrTemplate = elementTemplate.AttributeTemplates["Mode"];
            AFElement.LoadAttributes(new[] { boilerA }, new[] { temperatureAttrTemplate, modeAttrTemplate });

            AFEnumerationSet digSet = afDatabase.EnumerationSets["Modes"];

            IList<AFValue> valuesToWrite = new List<AFValue>();
            for (int i = 0; i < 10; i++)
            {
                AFTime time = new AFTime(new DateTime(2015, 1, 1, i, 0, 0, DateTimeKind.Local));

                AFValue afValueFloat = new AFValue(i, time);
                // Associate the AFValue to an attribute so we know where to write to.
                afValueFloat.Attribute = boilerA.Attributes["Temperature"];

                AFEnumerationValue digSetValue = i % 2 == 0 ? digSet["Auto"] : digSet["Manual"];
                AFValue afValueDigital = new AFValue(digSetValue, time);
                afValueDigital.Attribute = boilerA.Attributes["Mode"];

                valuesToWrite.Add(afValueFloat);
                valuesToWrite.Add(afValueDigital);
            }

            // Perform a bulk write. Use a single local call to PI Buffer Subsystem if possible.
            // Otherwise, make a single call to the PI Data Archive.
            // We use no compression just so we can check all the values are written.
            // AFListData is the class that provides the bulk write method.
            AFListData.UpdateValues(valuesToWrite, AFUpdateOption.InsertNoCompression, AFBufferOption.BufferIfPossible);
        }
    }
}
