# AddFeatureFolders
[![Build status](https://ci.appveyor.com/api/projects/status/k4aotmbkugavs2mq?svg=true)](https://ci.appveyor.com/project/OdeToCode/addfeaturefolders)
### Installation
```
    Install-Package OdeToCode.AddFeatureFolders 
```

### Usage 
```c#
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                    .AddFeatureFolders();

            // "Features" is the default feature folder root. To override, pass along 
            // a new FeatureFolderOptions object with a different FeatureFolderName
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseDeveloperExceptionPage();
            app.UseMvcWithDefaultRoute();
        }
    }    
```

### Don't Forget!
Add your feature folder to the list of assets to publish. In project.json:
```
  "publishOptions": {
    "include": [
      "wwwroot",
      "web.config",
      "Features/**/*.cshtml"
    ]
  }
```
Visual Studio 2017 doesn't have a project.json and what to do depends the Release Candidate (RC) version you are using:  
  
_Visual Studio 2017 RC2_ you need to add to your .csproj file:
```
  <ItemGroup>
    <Content Include="wwwroot\**\*;**\*.cshtml;appsettings.json;web.config;Features\**\*.cshtml">
      <CopyToPublishDirectory>PreserveNewest</CopyToPublishDirectory>
    </Content>
  </ItemGroup>
```
_Visual Studio 2017 RC4_ you don't need to add anything to your csproj file.  
  
If you had added the above because you were using RC2 then you will need to remove it when you use RC4.

### Just one more thing!
AddFeatureFolders uses the namespace of the controller to figure out where the views are. 
For example: 
```
/Features
	/Robots
		/Robots.cshtml
```
The above example folder structure relies on the namespace of the controller being `<whatever>.Features.Robots`. 

If you encounter problems with MVC locating the views check your controller namespace.
