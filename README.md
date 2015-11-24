# PI-AF-SDK-Basic-Samples

This repository provides self-contained and reproducible samples of basic operations using AF SDK. The aim is to provide an accessible hands-on experience with the PI AF SDK using code examples that are portable and easy to follow.

Each example demonstrates a basic operation within the PI AF SDK. These examples present PI AF SDK as a set of basic "building blocks", rather than an entire "pre-packaged solution". The goal is to enable the user to learn the basic operations of PI AF SDK so they then have the tools to build more specific applications and a foundation to learn more advanced PI AF SDK concepts.

## Solution contents

`ExamplesLibrary` contains the examples. Each example is a separate class and outputs to the Console.

`PI-AF-SDK-Basic-Samples` contains the Console application that runs the examples.

## Requirements

1. AF Client 2.5+
2. .NET Framework 4+
3. Visual Studio 2012+
4. AF Server and PI Data Archive

## Getting started

### Import the NuGreen database.

Many of the examples uses the NuGreen database. To use the NuGreen database, follow these steps:

1. Create an AF Database named "NuGreen".
2. Import the database from the provided [NuGreen.xml](NuGreen.xml) via PI System Explorer>File>Import from File.
3. Verify that a root element "NuGreen" is created inside the NuGreen database.
4. Check in the changes if not done so already.

### AF Server and PI Data Archive Names

The code examples come with simple placeholders such as `<AFSERVER>` and `<PISERVER>`.

Please replace these with your server names before starting.

### Dependencies

Some examples depend on having run prior examples successfully. This is because these dependent examples require AF objects and/or PI Points to have been created by the prior examples. The comments in the code above each class will explicitly list out the dependencies of each example. For instance,

```
/// <prerequisite-examples>
/// BuildSimpleDatabaseExample, CreateEventFramesExample
/// </prerequisite-examples>
```    

### Run an example

Examples are executed by the Console application. To run a particular example, simply instantiate a new object of the desired example type and call its Run() method.

To run the AFConnectionExample, for instance, use:
```csharp
IExample example = new AFConnectionExample();
example.Run()
```

### PI AF SDK Reference guide

It is recommended that for each example, the user finds the corresponding PI AF SDK method in the [online guide] (https://techsupport.osisoft.com/Documentation/PI-AF-SDK/html/1a02af4c-1bec-4804-a9ef-3c7300f5e2fc.htm). This will provide further context and reinforcement of the presented concepts.

## Recommended learning path

A recommended learning path for going through the examples is as follows:

### 1.0 Connecting

- [ConnectionExamples/AFConnectionExample](/ExamplesLibrary/ConnectionExamples/AFConnectionExample.cs)
- [ConnectionExamples/PIConnectionExample](/ExamplesLibrary/ConnectionExamples/PIConnectionExample.cs)

### 2.0 Finding and loading AF Elements

- [AFElementExamples/FindElementsExample](/ExamplesLibrary/AFElementExamples/FindElementsExample.cs)
- [AFElementExamples/PartialLoadElementsExample](/ExamplesLibrary/AFElementExamples/PartialLoadElementsExample.cs)
- [AFElementExamples/LoadElementsExample](/ExamplesLibrary/AFElementExamples/LoadElementsExample.cs)
 
### 3.0 Finding AF attributes

- [AFAttributeExamples/FindAttributeWalkDownExample](/ExamplesLibrary/AFAttributeExamples/FindAttributeWalkDownExample.cs)
- [AFAttributeExamples/FindAttributesByPathExample](/ExamplesLibrary/AFAttributeExamples/FindAttributesByPathExample.cs)
- [AFAttributeExamples/FindElementAttributesExample](/ExamplesLibrary/AFAttributeExamples/FindElementAttributesExample.cs)

### 4.0 Finding PIPoints

- [PIPointExamples/FindPIPointsExample](/ExamplesLibrary/PIPointExamples/FindPIPointsExample.cs)

### 5.0 Reading values

- [ReadingValuesExamples/ReadFromAFExample](/ExamplesLibrary/ReadingValuesExamples/ReadFromAFExample.cs)
- [ReadingValuesExamples/ReadFromPIExample](/ExamplesLibrary/ReadingValuesExamples/ReadFromPIExample.cs)

### 6.0 Creating AF objects

- [BuildAFDatabaseExamples/BuildSimpleDatabaseExample](/ExamplesLibrary/BuildAFDatabaseExamples/BuildSimpleDatabaseExample.cs)

### 7.0 Create PI Points 

- [PIPointExamples/CreatePIPointsExample](/ExamplesLibrary/PIPointExamples/CreatePIPointsExample.cs)

### 8.0 Writing values

- [WriteValuesExample/WriteValuesUsingAFExample](/ExamplesLibrary/WriteValuesExample/WriteValuesUsingAFExample.cs)
- [WriteValuesExample/WriteValuesUsingPIExample](/ExamplesLibrary/WriteValuesExample/WriteValuesUsingPIExample.cs)

### 9.0 Creating and Finding Event Frames

- [AFEventFrameExamples/CreateEventFrameExample](/ExamplesLibrary/AFEventFrameExamples/CreateEventFrameExample.cs)
- [AFEventFrameExamples/FindEventFramesExample](/ExamplesLibrary/AFEventFrameExamples/FindEventFramesExample.cs)

##Licensing

Copyright 2015 OSIsoft, LLC.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
   
Please see the file named [LICENSE.md](LICENSE.md).
