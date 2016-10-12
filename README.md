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