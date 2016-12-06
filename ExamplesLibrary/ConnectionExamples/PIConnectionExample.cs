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
using OSIsoft.AF.PI;


namespace ExamplesLibrary
{
    /// <summary>
    /// This example demonstrates making a connection to an PI Data Archive using an implicit connection and an explicit connection.
    /// </summary>
    /// <prerequisite-examples>
    /// none
    /// </prerequisite-examples>
    public class PIConnectionExample : IExample
    {
        public void Run()
        {
            ImplicitConnection();
            ExplicitConnection();
        }

        public void ImplicitConnection()
        {
            PIServers piServers = new PIServers();
            PIServer piServer = piServers["PIServerName"];
            // At this point, no connection is made.

            PIPoint piPoint = PIPoint.FindPIPoint(piServer, "sinusoid");
            // Now a connection is made by first data access.
        }

        public void ExplicitConnection()
        {
            PIServers piServers = new PIServers();
            PIServer piServer = piServers["PIServerName"];
            // At this point, no connection is made.

            piServer.Connect();
            // Now a connection is made by explicit call.

            PIPoint piPoint = PIPoint.FindPIPoint(piServer, "sinusoid");
        }
    }
}
