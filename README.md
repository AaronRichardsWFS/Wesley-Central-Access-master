# WFS-Central-Access
**ASP.NET Core 3.1.2 Web Application for Wesley Family Services**

Built for WFS and their Central Access team.

### Packages used:
```[netcoreapp3.1]: 
 Top-level Package                                        Requested   Resolved
 > Microsoft.AspNetCore.Authentication.Negotiate          3.1.2       3.1.2   
 > Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation      3.1.2       3.1.2   
 > Microsoft.EntityFrameworkCore.Design                   3.1.2       3.1.2   
 > Microsoft.EntityFrameworkCore.SQLite                   3.1.2       3.1.2   
 > Microsoft.EntityFrameworkCore.SqlServer                3.1.2       3.1.2   
 > Microsoft.VisualStudio.Web.CodeGeneration.Design       3.1.1       3.1.1
 ```
## Quick Help

### Common Commands
- Building the app: `dotnet build`
- Running the app (also builds): `dotnet run`
- Dropping the DB: `dotnet ef database drop`
- Migrating the DB: `dotnet ef database update`
- Adding a new package: `dotnet add package <package>`

### Common Settings
- DB configurations are made in [`appsettings.json`](appsettings.json)
  - CURRENTLY SETUP FOR SQL SERVER IN BOTH DEVELOPMENT AND PRODUCTION
  - For development, a Docker container was used to run a local instance of Microsoft SQL Server 2017. When developing, Visual Studio should come with SQL Server Development already included.  OR when using VS Code you can install a local Docker container to run the SQL Server instance. The Docker container is linked [here](https://hub.docker.com/_/microsoft-mssql-server) with instructions to install.  Here is an example command to run the image: 
  
  ```docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Passw0rd!' --name WFSTestDB -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest```
- Active Directory security groups are configured in [`appsettings.json`](appsettings.json) as well.

## Deploying ASP.NET Core to IIS

### Step Zero - Resources

The following are extremely helpful resources related to hosting and deploying on an IIS Server.  We recommend having these links up to reference whenever deploying.

- [Publish an ASP.NET Core app to IIS](https://docs.microsoft.com/en-us/aspnet/core/tutorials/publish-to-iis?view=aspnetcore-3.1&tabs=visual-studio)
- [Host ASP.NET Core on Windows with IIS](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/iis/?view=aspnetcore-3.1)

#### Important things to keep in mind:

- IIS relies on [```web.config```](web.config) and [```appsettings.json```](appsettings.json) files in order to properly setup environment (development vs production) and active directory group settings among a few other configuration settings.  These two files are accessible to edit and manipulate after publishing of the app, but many others are not.  Keep this in mind when publishing (development mode is far easier to run the app quickly just to test things locally and change things on the fly--otherwise will have to republish every time).  

### Step One - Configure IIS

- The Microsoft tutorial given above (also [here](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/iis/?view=aspnetcore-3.1)) is a great guide and should be followed to configure a new site for IIS. Here a few things to keep in mind when following it:
  - Windows Authentication is configured in the [`web.config`](web.config) file and in the application itself.  You should not have to worry about setting anything up for that in IIS **EXCEPT** for ensuring you install the `Web Server > Security` role service.
  - When installing the .NET Core Hosting Bundle installer, we used .NET Core 3.1.2.  Installing future releases should not break anything, but to play it safe you can use 3.1.2 via the “Earlier versions of the installer” link in the guide. 
  - We are using the “In Process” hosting model as it is faster and Microsoft recommends it.  No configuration is necessary, it is the default.

### Step Two - Publish

- Ensure the codebase is cloned from Github and that it is running in either Visual Studio (paid) or Visual Studio Code (free).  Just open the WCAProject.sln file into Visual Studio or open the specific directory in Visual Studio Code and it will recognize the project.  Visual Studio Code requires installing the .NET Core SDK separately while Visual Studio incorporates it in the install (might have to look for .NET Core during installation).  
- Next, run the publish command as specified by which editor you’re currently using on this page [here](https://docs.microsoft.com/en-us/aspnet/core/tutorials/publish-to-iis?view=aspnetcore-3.1&tabs=visual-studio) (it is also linked above).  Ensure to specify “Release” as the publish operation.  An example is below for .NET Core CLI.  The CLI is installed whenever you install the SDK separately (i.e. when using VS Code).

```
dotnet publish --configuration Release
```

### Step Three - Copy Project Files

- Once you have published the application, copy the publish folder (`bin/publish`) to the target folder that the specific IIS site points to.
- Be sure to accept (“continue”) the confirmation message related to giving appropriate permissions to the newly copied over files.

### Step Four - Navigate

- Now navigate to the site at whichever hostname/address that was chosen earlier.
- Check that IIS does not throw any errors.  This often happens when deploying for the first time due to weird permissions errors with authentication configuration settings.  Follow these steps to resolve:
- Navigate to the IIS Manager and click on the main server (not the site itself) in the left sidebar.
- Then click on Feature Delegation
- Ensure that the authentication related features (mainly anonymous and windows) are set to read/write. Now rerun and it should work.

### Step Five - Transfer Data (if necessary)

- Please reference the database transfer script documentation provided in order to transfer data over from the old database into the new (“Database Migration Process”).
- Should only have to do this once, but the scripts make it easy to do it repeatedly if necessary.

## Tips for Future Use

- By default when in production, a “nicer” yet more vague error page shows when an exception or other error has occurred.  In order to view the developer exception page with lots of details, change the environment variable, `ASPNETCORE_ENVIRONMENT`, to `Development`.  Follow these steps to do this (also there is a nice guide [here](https://www.andrecarlucci.com/en/setting-environment-variables-for-asp-net-core-when-publishing-on-iis/)): 
  - Navigate to the site in IIS Manager then click on Configuration Editor.
  - Then select `system.webServer/aspNetCore` in the “Section” dropdown.
  - Add an environment variable with the key as `ASPNETCORE_ENVIRONMENT` and value as either `Development` or `Production`.
- Try to avoid changing settings like authentication scheme or other settings directly in IIS.  Whenever you republish, those settings will mostly likely be reset because they are not in the `web.config` file.  As such, whatever changes you’d like to make should usually go into this file.  


- **IMPORTANT NOTE:** In the application, an "Inquiry" is actually of the `ClientService` class (model).  ClientService is used as a database term because the ClientService table/model connects the Client table and the Service table.  

## Issues

### Current Issues
- “Active” checkbox when creating/modifying dropdown fields has no effect.  All fields are shown in the relevant forms regardless of whether they are active or not.
- Color scheme and layout/formatting of dropdown create, edit, index, and show pages do not currently align with the WFS color scheme and are not laid out super nicely. 
- The test suite xUnit should be integrated into this project. It runs unit tests that can be written within the test suite and will make development far easier and more reliable.

### Future Features/Additions
Here are some features that could/should be added on:
- A confirm message to warn users when leaving a create/edit page that has been filled in or modified in some way.
- More filtering options on the Inquiries list page (service, site, etc.).

## Adding to the Project

- Changes to any UI elements or "front-end" items (colors, formatting, link destinations, buttons, etc.) should be done in the views folder. 
- Adding additional 'dropdowns' will require a few things.
  - First, a new model. Add a model in the [Models](Models) folder using any of the other models as a template. This is where the data attributes for the new dropdown table will go.
  - Second, a new controller and views are needed. These can be easily autogenerated (once the model with all necessary data fields is written) using the scaffolding command included in .NET Core. Here is an example: 
  ```dotnet aspnet-codegenerator controller -name ClineitemsController -m Clineitem -dc WCAProjectContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries```
  More guidance from the Microsoft docs [here](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/tools/dotnet-aspnet-codegenerator?view=aspnetcore-3.1).
- Adding more fields to an exisiting model is straightforward. You need to find the model in question in the [Models](Models) folder. Then add the desired field using the other fields as a template. You will have to add a migration to the database using an included command. Here is an example: 
```dotnet ef migrations add UpdateClientFields```.

## Troubleshooting

- If you encounter an error upon startup similar to "The table 'services' already exists", you must comment out the "up" and "down" functions separately in the most recent migration file in the migrations folder.  This is an issue we could not figure out the underlying issue for, but this was our makeshift solution.


---
First production build developed by [Abhi Maddineni](https://github.com/amaddine), [CJ May](https://github.com/cmax4jam), and [Eugene Choi](https://github.com/eugeneiohc); Information Systems Program @ CMU; Feb - May 2020 

Feature improvements developed by [Abhi Deverapalli](https://github.com/abhidevarapalli), [Raymond Li](https://github.com/raybicboi), and [Jeff Xu](https://github.com/jeffjxu); Information Systems Program @ CMU; Feb - May 2021

Offical Changelog

05/07/2021
 - Fix - fixed client form so it is editable and saveable on create inquiry page and edit inquiry page
 - Fix - fixed SCA form so it is saveable on create inquiry and edit inquiry page
 - Fix - fixed several dropdown fields in client form
 - Fix - fixed notes feature so it is editable and saveable on create inquiry and edit inquiry page
 - Fix - added actions dropdown for notes
 - Fix - the poorly spaced client form fields is in a nicer format
 - Fix - "Save Changes" button on SCA screen is changed to "Close" since it doesn't actually save the SCA form
 - Enhancement - inquiry form is now responsive as more fields will show up if specific services are selected in the dropdown
 - Enhancement - SCA form fields are ordered to match the form on MS Access
 - Enhancement - a list of all inquiries for a client are listed when editing that client
 - Enhancement - when a client or a inquiry form is saved, the user is redirected to the edit page instead of the view page
 - Enhancement - when a client or a inquiry form is created, the user is redirected to the edit page instead of the view page
 - Enhancement - screening questions are now saved in the database under inquiry
 - Enhancement - client ID is displayed when editing a client
 - Enhancement - client form accordion is automatically uncollapsed on create inquiry page and edit inquiry page
 - Enhancement - skeleton view and controller code for a printer-friendly view is created but hidden

08/26/2020
 - Fix - Fixed Secondary Insurance - This is now a drop down
 - Fix - Rename Incoming Inquiries to Search Inquiries (will default to show all New Inquiries)
 - Fix - Home Page 'In Process' listing now filters on logged in user
 - Enhancement - Added new feild on the Worker table (UserName) this will be used by the system to know which user logged in is tied to witch worker entry.  Example: Worker Dawn is now tied to her computer username of haurperd
 - Enhancement - In all List views changed links to go to 'Edit' instead of 'Detail' view
 - Enhancement - In all List views added the CA DB ID and Credible ID
 - Enhancement - When Selecting Service of OP hide the "OP Type" - No longer needed
 - Enhancement - Implemented Audit backend
        - To Do:
                    - Add Tables to audit System
                    - Add Audit Reports

08/05/2020
 - Fix - Footer Section Bleeding on top of other text
 - Fix - When selecting the site of "School" the School Selection Box now shows up
 - Fix - When selecting the Programs of "OP", "BHRS", "IFC", or "WK" the hiddedn boxes now appear
 - Fix - Client Inquiry - Site Drop Down was not filtering out inactives
 - Fix - Client Inquiry - School Drop Down was not filtering out inactives
 - Fix - Client Inquiry - Status Drop Down was not filtering out inactives
 - Fix - Client Inquiry - Worker Drop Down was not filtering out inactives
 - Fix - Client Inquiry - Program Drop Down was not filtering out inactives
 - Fix - Client Inquiry - Internal Drop Down was not filtering out inactives
 - Fix - Client - Race Drop Down was not filtering out inactives
 - Fix - Client - Insurance Drop Down was not filtering out inactives
 - Fix - Client - Site Drop Down was not filtering out inactives
 - Fix - Client - School Drop Down was not filtering out inactives
 - Fix - Client - Status Drop Down was not filtering out inactives
 - Fix - Client - Worker Drop Down was not filtering out inactives
 - Fix - Client - Program Drop Down was not filtering out inactives
 - Fix - Age - Went entering DOB Age will calculate
 - Enhancement - System Recalculates age nightly
 - Enhancement - Created new Report Section
 - Enhancement - Moved Client Search Report to new Reports Section
 - Enhancement - Added security to reports page
 - Enhancement - Added Help Page
 - Enhancement - Moved Change Log and Debug to help Page


06/26/2020
 - Enhancement - Unlocked Client Feilds on Edit Inquery Screen
 - Fix - Added County to Inquiry Client view
 - Fix - Added County to Inquiry Client Create
 - Fix - Added County to Inquiry Client Edit
 - Enhancement - Added Page to pull SSRS Client Search
 - Enhancement - Added Link to WFS Services Site

06/18/2020
 - Fix - In Progress on home page from listing results
 - Fix - Client DB Number not showing on Client Page 
 - Fix - Converted Insurance2 to Foreign Key tied to Insurance List
 - Enhancement - Added Change log
 - Fix - Fixed Incomming Clients page not defaulting to new clients
 - Fix - Search on Client only searches the first phone number box, not the 2nd box also same with these search options email and contact relationship.
 - Enhancement - Added Name to In Process List on Homepage
 - Enhancement - Added Name to Incomming Inquiries
 - Enhancement - Added County to Client Page

04292020
 - Inital Release from CMU







