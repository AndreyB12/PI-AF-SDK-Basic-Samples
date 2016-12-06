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
    /// This example uses FindElementAttributes to return a list of AFAttribute objects to the client.
    /// </summary>
    /// <prerequisite-examples>
    /// none
    /// </prerequisite-examples>
    public class FindElementAttributesExample : IExample
    {
        public void Run()
        {
            PISystems piSystems = new PISystems();
            PISystem piSystem = piSystems["<AFSERVER>"];

            AFDatabase afDatabase = piSystem.Databases["NuGreen"];

            AFCategory elementCategory = afDatabase.ElementCategories["Equipment Assets"];
            AFCategory attributeCategory = afDatabase.AttributeCategories["Real-Time Data"];

            AFElementTemplate elementTemplate = afDatabase.ElementTemplates["Boiler"];

            const int pageSize = 1000;
            int startIndex = 0;
            int totalCount;
            do
            {
                // Find all "Water Flow" attributes in the NuGreen database.
                AFAttributeList attrList = AFAttribute.FindElementAttributes(
                    database: afDatabase,
                    searchRoot: null,
                    nameFilter: "*",
                    elemCategory: elementCategory,
                    elemTemplate: elementTemplate,
                    elemType: AFElementType.Any,
                    attrNameFilter: "*",
                    attrCategory: attributeCategory,
                    attrType: TypeCode.Double,
                    searchFullHierarchy: true,
                    sortField: AFSortField.Name,
                    sortOrder: AFSortOrder.Ascending,
                    startIndex: startIndex,
                    maxCount: pageSize,
                    totalCount: out totalCount);

                foreach (AFAttribute attr in attrList)
                {
                    Console.WriteLine("Parent element name: {0}", attr.Element);
                }

                startIndex += pageSize;

            } while (startIndex < totalCount);

        }
    }
}
