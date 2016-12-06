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
using OSIsoft.AF;
using OSIsoft.AF.Asset;


namespace ExamplesLibrary
{
    /// <summary>
    /// This example demonstrates making a connection to an AF Server using an implicit connection and an explicit connection.
    /// </summary>
    /// <prerequisite-examples>
    /// none
    /// </prerequisite-examples>
    public class AFConnectionExample : IExample
    {
        public void Run()
        {
            ImplicitConnection();
            ExplicitConnection();
        }

        private void ImplicitConnection()
        {
            PISystems piSystems = new PISystems();
            PISystem piSystem = piSystems["<AFSERVER>"];
            // At this point, no connection is made.

            AFAttribute afAttribute = AFAttribute.FindAttribute(@"NuGreen\NuGreen\Houston|Environment", piSystem);
            // Now a connection is made by first data access.
        }

        private void ExplicitConnection()
        {
            PISystems piSystems = new PISystems();
            PISystem piSystem = piSystems["<AFSERVER>"];
            // At this point, no connection is made.

            piSystem.Connect();
            // Now a connection is made by explicit call.

            AFAttribute afAttribute = AFAttribute.FindAttribute(@"NuGreen\NuGreen\Houston|Environment", piSystem);
        }
    }
}
