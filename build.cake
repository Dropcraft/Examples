var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

var solutions = GetFiles("./**/*.sln");
var solutionPaths = solutions.Select(solution => solution.GetDirectory());

var srcDir = Directory("./src");

var artifactsDir = Directory("./artifacts");
var nupkgDestDir = artifactsDir + Directory("nuget-package");

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectories(new DirectoryPath[] {
        artifactsDir,
        nupkgDestDir
  	});

    foreach(var path in solutionPaths)
    {
        Information("Cleaning {0}", path);
        CleanDirectories(path + "/**/bin/" + configuration);
        CleanDirectories(path + "/**/obj/" + configuration);
    }
});

Task("Restore-NuGet-Packages")
    .Does(() =>
{
    foreach(var solution in solutions)
    {
        Information("Restoring NuGet Packages for {0}", solution);
        NuGetRestore(solution);
    }
});

Task("Build-Solutions")
    .Does(() =>
{
    foreach(var solution in solutions)
    {
        Information("Building {0}", solution);

        MSBuild(solution, settings =>
            settings
                .SetConfiguration(configuration)
                .WithProperty("TreatWarningsAsErrors", "true")
                .UseToolVersion(MSBuildToolVersion.NET46)
                .SetVerbosity(Verbosity.Minimal)
                .SetNodeReuse(false));
}});

Task("Package")
    .Does(() =>
{
    List<FilePath> nuspecs = new List<FilePath>(GetFiles("./src/nuspecs/*.nuspec"));
    foreach (var nuspec in nuspecs)
    {
        NuGetPack(nuspec, new NuGetPackSettings
        {
            BasePath = nuspec.GetDirectory(),
            OutputDirectory = nupkgDestDir,
            Symbols = false
        });
    }    
});

///////////////////////////////////////////////////////////////////////////////
// PRIMARY TARGETS
///////////////////////////////////////////////////////////////////////////////

Task("Build")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore-NuGet-Packages")
    .IsDependentOn("Build-Solutions")
    .IsDependentOn("Package");

Task("Default")
    .IsDependentOn("Build");

///////////////////////////////////////////////////////////////////////////////
// EXECUTION
///////////////////////////////////////////////////////////////////////////////

RunTarget(target);