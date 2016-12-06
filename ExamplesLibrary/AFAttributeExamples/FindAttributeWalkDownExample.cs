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
using OSIsoft.AF;
using OSIsoft.AF.Asset;


namespace ExamplesLibrary
{
    /// <summary>
    /// This example "walks-down" the AF hierarchy to locate an attribute of interest and then get its current value.
    /// The target attribute is \\Server\NuGreen\NuGreen\Houston\Cracking Process\Equipment\B-210|Process Feedrate.
    /// There are more direct methods to find this attribute, but this example is merely to demonstrate the behavior of
    /// some basic operations.
    /// Contrast this example with DirectLocateExample.
    /// </summary>
    /// <prerequisite-examples>
    /// none
    /// </prerequisite-examples>
    public class FindAttributeWalkDownExample : IExample
    {
        public void Run()
        {
            PISystems piSystems = new PISystems();
            PISystem piSystem = piSystems["<AFSERVER>"];

            AFDatabase afDatabase = piSystem.Databases["NuGreen"];

            AFElement nuGreen = afDatabase.Elements["NuGreen"];
            AFElement houston = nuGreen.Elements["Houston"];
            AFElement crackingProcess = houston.Elements["Cracking Process"];
            AFElement equipment = crackingProcess.Elements["Equipment"];
            AFElement b210 = equipment.Elements["B-210"];

            AFAttribute processFeedRate = b210.Attributes["Process Feedrate"];

            AFValue val = processFeedRate.GetValue();

            Console.WriteLine("Timestamp: {0}, Value: {1}", val.Timestamp, val.Value.ToString());
        }
    }
}
