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

### Now you can organize controllers and views in a Features folder hierarchy

See the sample folder for more examples. 

\Features
  \Home
      \HomeController.cs
      \HomeViewModel.cs
      \HomeIndexHandler.cs
      \HomeIndexQuery.cs
      \Index.cshtml

### For project.json
If you are using a version of .NET Core with project.json, add your feature folder to the list of assets to publish. In project.json:
```
  "publishOptions": {
    "include": [
      "wwwroot",
      "web.config",
      "Features/**/*.cshtml"
    ]
  }
```

### Just one more thing!
AddFeatureFolders uses the namespace of the controller to figure out where the views are. 
For example: 
```
/Features
	/Robots
		/Robots.cshtml
```
The above example folder structure relies on the namespace of the controller being `<whatever>.Features.Robots`. 

If you encounter problems with MVC locating the views, check your controller namespace.
