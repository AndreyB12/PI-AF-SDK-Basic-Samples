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
using OSIsoft.AF.EventFrame;
using OSIsoft.AF.Time;


namespace ExamplesLibrary
{
    /// <summary>
    /// This example creates 5 event frames of 1 day periods spanning the last 5 days.
    /// The primary referenced element for the event frames are set to the Region_0\BoilerA element.
    /// </summary>
    /// <prerequisite-examples>
    /// BuildSimpleDatabaseExample
    /// </prerequisite-examples>
    public class CreateEventFrameExample : IExample
    {
        public void Run()
        {
            PISystems piSystems = new PISystems();
            PISystem piSystem = piSystems["<AFSERVER>"];

            AFDatabase afDatabase = piSystem.Databases["Basic-AFSDK-Sample"];

            CreateEventFrameTemplate(afDatabase);
            CreateEventFrames(afDatabase);
        }

        private void CreateEventFrameTemplate(AFDatabase afDatabase)
        {
            AFElementTemplate efTemplate = afDatabase.ElementTemplates.Add("BasicEventFrameTemplate");
            // Specify that this is an Event Frame Template.
            efTemplate.InstanceType = typeof(AFEventFrame);

            AFAttributeTemplate tempAttr = efTemplate.AttributeTemplates.Add("Maximum temperature");
            tempAttr.DataReferencePlugIn = AFDataReference.GetPIPointDataReference(afDatabase.PISystem);

            AFAttributeTemplate pressAttr = efTemplate.AttributeTemplates.Add("Maximum pressure");
            pressAttr.DataReferencePlugIn = AFDataReference.GetPIPointDataReference(afDatabase.PISystem);

            tempAttr.ConfigString = @".\Elements[.]|Temperature;TimeMethod=NotSupported;TimeRangeMethod=Maximum";
            pressAttr.ConfigString = @".\Elements[.]|Pressure;TimeMethod=NotSupported;TimeRangeMethod=Maximum";

            // Do a bulk check in of all changes made so far.
            afDatabase.CheckIn();
        }

        private void CreateEventFrames(AFDatabase afDatabase)
        {
            AFElementTemplate efTemplate = afDatabase.ElementTemplates["BasicEventFrameTemplate"];
            for (int i = 0; i < 5; i++)
            {
                AFEventFrame ef = new AFEventFrame(afDatabase, "EF_" + i, efTemplate);
                ef.SetStartTime(new AFTime(string.Format("t-{0}d", i + 1)));
                ef.SetEndTime(new AFTime(string.Format("t-{0}d", i)));

                AFElement element = afDatabase.Elements["Region_0"].Elements["BoilerA"];
                ef.PrimaryReferencedElement = element;
            }

            // Do a bulk check in of all changes made so far.
            afDatabase.CheckIn();
        }
    }
}
