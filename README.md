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

#### Disclaimer

Your feature folder name (`FeatureFolderOptions.FeatureFolderName` or `AreaFeatureFolderOptions.AreaFolderName` if using Areas) cannot be in your project namespace.

See: [Issue #27](https://github.com/OdeToCode/AddFeatureFolders/issues/27)

### Using areas Areas

If you want to enable areas, there are two pieces of code to add:
```c#
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc()
                .AddFeatureFolders()
                .AddAreaFeatureFolders();
    
        // "Features" is the default feature folder root. To override, pass along 
        // a new FeatureFolderOptions object with a different FeatureFolderName
    }
    
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        app.UseDeveloperExceptionPage();
        app.UseMvcWithDefaultRoute().UseMvc(routes => 
            routes.MapRoute(
                name: "areaRoute",
                template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"));
    }
```

The first piece is to add the ```.AddAreaFeaturesFolders()``` after the ```.AddFeatureFolders()```.
This adds the view locations for the areas.
The second part is another ```.UseMvc()``` method to configure the route to area controllers.

Now areas can be added using the default area layout combined with the feature folder setup.
Example:
```
/Areas
    /Administration // this is the area name
        /Overview   // this is the controller name
            /OverviewController.cs
            /Index.cshtml
```  

### If ReSharper (or Rider) is being annoying
Then add the package ```JetBrains.Annotations``` to the web app project and add the following lines 
above the Startup class between the using statements and the namespace. 
```c#
[assembly: AspMvcViewLocationFormat(@"~\Features\{1}\{0}.cshtml")]
[assembly: AspMvcViewLocationFormat(@"~\Features\{0}.cshtml")]
[assembly: AspMvcViewLocationFormat(@"~\Features\Shared\{0}.cshtml")]

[assembly: AspMvcAreaViewLocationFormat(@"~\Areas\{2}\{1}\{0}.cshtml")]
[assembly: AspMvcAreaViewLocationFormat(@"~\Areas\{2}\{0}.cshtml")]
[assembly: AspMvcAreaViewLocationFormat(@"~\Areas\{2}\Shared\{0}.cshtml")]
```
Replace 'Features' and 'Areas' part if you set a custom folder name.