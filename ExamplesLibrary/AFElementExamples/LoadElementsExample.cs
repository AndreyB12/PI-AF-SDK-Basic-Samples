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
    /// Find and load a collection of elements instantiated from the Boiler template.
    /// Print each found element name and attribute count to the console.
    /// </summary>
    /// <prerequisite-examples>
    /// none
    /// </prerequisite-examples>
    public class LoadElementsExample : IExample
    {
        public void Run()
        {
            PISystems piSystems = new PISystems();
            PISystem piSystem = piSystems["<AFSERVER>"];

            AFDatabase afDatabase = piSystem.Databases["NuGreen"];

            const int pageSize = 1000;
            int startIndex = 0;
            int totalCount;
            do
            {
                // Find a collection of elements instantiated from the Boiler tempplate.
                // Only the Elements' header information (Name, Description, Template, Type, etc.)
                // are loaded from the AF Server by this call.
                AFNamedCollection<AFElement> elements = AFElement.FindElements(
                    database: afDatabase,
                    searchRoot: null,
                    query: "Boiler",
                    field: AFSearchField.Template,
                    searchFullHierarchy: true,
                    sortField: AFSortField.Name,
                    sortOrder: AFSortOrder.Ascending,
                    startIndex: startIndex,
                    maxCount: pageSize,
                    totalCount: out totalCount);
                if (elements == null) break;

                // This call goes to the AF Server to fully load the found elements in one call,
                // so further AF Server calls can be avoided.
                AFElement.LoadElements(elements);

                // Now we can use the elements without having to make any additional server calls.
                // In the example below, accessing the Attributes collection would have 
                // caused an additional call per element if we had not called LoadElements previously.
                Console.WriteLine("Found {0} Elements.", elements.Count);
                foreach (AFElement item in elements)
                {
                    Console.WriteLine("  Element {0} has {1} Attributes", item.Name, item.Attributes.Count);
                }

                startIndex += pageSize;

            } while (startIndex < totalCount);

            
        }

    }
}
