This repo aims to reproduce issue https://github.com/dotnet/efcore/issues/19759

## Instructions
1. Open the solution file in Visual Studio 2019
2. Open Package Manager Console window
3. Type the following command:

Add-Migration abc -Project EfCoreMigrationLinuxBug.Data -StartupProject EfCoreMigrationLinuxBug

## Result
This file is created on disk:

    Migrations\20200216202455_abc.Designer.cs

This entry is added to EfCoreMigrationLinuxBug.Data.csproj:

    <Compile Include="Migrations\20200216202455_abc.designer.cs" />

Notice the difference between "Designer" and "designer", which introduces a build error on Linux.

## Comment
These entries does not normally turn up in the csproj. The behaviour was activated by these lines that I (mysteriously) had in the csproj: 

    <ItemGroup>
        <Compile Remove="Migrations\**" />
        <EmbeddedResource Remove="Migrations\**" />
        <None Remove="Migrations\**" />
    </ItemGroup>
    
    
