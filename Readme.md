# Json Schema GSoC 2024 Qualification Task

This repository contains steps to achieve the solution for the GSoC 2024 qualification task by Json Schema.

## Tasks

- Implement an incremental source generator in ExistingPackage to produce a missing attribute.
- Update ExistingPackage to generate a NuGet package enabling the usage of ServiceProvider and inclusion of the attribute.
- Successfully consume the ExistingPackage NuGet package in UserCode without direct project reference.

## Accomplishment

- Successfully implemented an incremental source generator in ExistingPackage to generate the missing attribute.
- Updated ExistingPackage to generate a NuGet package enabling the usage of ServiceProvider along with the generated attribute.
- Successfully consumed the ExistingPackage NuGet package in UserCode without direct project reference, ensuring modularity and ease of integration.

## 1. Generate Missing Attribute using Incremental Source Generators

- Install the necessary NuGet packages for the source generator.

- Implement an Incremental Source Generator in your ExistingPackage project library using `IIncrementalGenerator` interface.

- Update the project reference by specifying `OutputItemType` as Analyzer.

```
<ProjectReference Include="..\JsonSchema.GSoC2024.ExistingPackage\JsonSchema.GSoC2024.ExistingPackage.csproj"
   OutputItemType="Analyzer"/>
```

## **Important**

if you've got the below error, try to clean and build your solution.

```

Error Could not find a part of the path 'C:\{ProjectNamespace}\obj\Debug\net6.0\{ProjectNamespace}.GeneratedMSBuildEditorConfig.editorconfig'. {ProjectNamespace} C:\Program Files\Microsoft Visual Studio\2022\Enterprise\MSBuild\Current\Bin\Roslyn\Microsoft.Managed.Core.targets 190

```

If the solutions provided above do not resolve the issue, you can refer to the attached MS Learn link for further assistance. The error is likely caused by a long path. Enabling "long path support" can fix this issue.
[https://learn.microsoft.com/en-us/windows/win32/fileio/maximum-file-path-limitation?tabs=powershell](https://learn.microsoft.com/en-us/windows/win32/fileio/maximum-file-path-limitation?tabs=powershell)

Now build the solution, and the missing attribute has been generated through the source generator.

## 2. Update the ExistingPackage

- Please execute the following command to install all the dependencies required for the project.

- Configure Package Manager for Local feed.Open Visual Studio and go to Tools-> Nuget Package Manager ->Package Manager Settings, like below

<center><img src="Assets\Images\image-2.png" alt="image-2" width="500" height="350" ></center>

- In the settings, go to NuGet Package Manager > Package Sources, and click on the + button to add a new package source.

<center><img src="Assets\Images\image-3.png" alt="image-3" width="500" height="350" ></center>

- Provide all the neccessary details for your package.

<center><img src="Assets\Images\image-4.png" alt="image-4" width="500" height="350" ></center>

- Once you've provided all the package details and your project is ready,
  right-click on the project and select Pack.
  This action will create a .nupkg file in your project's bin folder.

<center><img src="Assets\Images\image-5.png" alt="image-5" width="500" height="350" ></center>

- Locate the .nupkg file in your project's bin folder and copy it.
  Paste the copied .nupkg file into the local.nuget folder you created earlier (C:\local.nuget).

- Open the solution or project where you want to use the custom package.
- Right-click on the project and select Manage NuGet Packages.

<center><img src="Assets\Images\image-6.png" alt="image-6" width="500" height="350" ></center>

- In the NuGet Package Manager, go to the settings icon and select your local package source (local.nuget).

<center><img src="Assets\Images\image-7.png" alt="image-7" width="500" height="350" ></center>

- Switch to the Browse tab, where you should see your custom package listed.
  Select the package and install it.
  Once installed, you can verify and test the package as needed.

<center><img src="Assets\Images\image-8.png" alt="image-8" width="500" height="350" ></center>

## References

### 1. Source Generators

- [Incremental Generators Cookbook
  ](https://github.com/dotnet/roslyn/blob/main/docs/features/incremental-generators.cookbook.md#open-issues)
- [Source Generators in C#](https://code-maze.com/csharp-source-generators/)
- [Incremental Generators](https://github.com/dotnet/roslyn/blob/main/docs/features/incremental-generators.md)

### 2. To Generate Nuget Package

- [Using Visual Studio](https://www.c-sharpcorner.com/article/how-to-create-and-test-nuget-package-locally-in-visual-studio-2022/)
- [Using cli](https://www.c-sharpcorner.com/article/creating-custom-nuget-packages-in-c-sharp/)
