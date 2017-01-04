The below implementation is Role manager specific 
System.Web.Security.Roles.GetRolesForUser(HttpContext.Current.User.Identity.Name);

for this you need to specify the role manger tag in the web.config.
<roleManager defaultProvider="WindowsProvider" enabled="true" cacheRolesInCookie="false">
   <providers>
    <add name="WindowsProvider" type="System.Web.Security.WindowsTokenRoleProvider" />
  </providers>
</roleManager>
----------------------------------------------------------------------------------------------------------------------------------------------------------
IIS Express command
cd C:\Program Files (x86)\IIS Express
iisexpress.exe  /config:"C:\Users\mitran\Documents\IISExpress\config\applicationhost.config"  /site:"CAAAETConfigurationUI" /apppool:"Clr4IntegratedAppPool"
------------------------------------------------------------------------------------------------------------------------------------------------------------
For the Grid Implemention Please look into
https://www.datatables.net/manual/ajax

1. The table dom element should have some <thead> element other wise will throw undefined javascript error.
2. The serverside sorting is interesting here. Please visit the Request.Querystring values to understand this.
-------------------------------------------------------------------------------------------------------------------------------------------------------------
ASP.NET MVC Implementation
Routing engine maps the route as in the order that they are registered. 
The very good example is how the grid is being populated with ajax address
-------------------------------------------------------------------------------------------------------------------------------------------------------------
Why Not Resource File for Message?
As this a middle tier application and business exception and messages will not chnage much frequently thus this is not required.
Further .Resx based messaging is highly recomended for localization which is not the case here. Also In terms of performnace this 
.resx is costlier in terms of complied constant messages.
For .resx based implementation please follow the URL of 
http://www.codeproject.com/Articles/5447/NET-Localization-using-Resource-file
https://msdn.microsoft.com/en-IN/library/gg418542(v=vs.110).aspx
Resgen tool location in Win7 vS2013 is C:\Program Files (x86)\Microsoft SDKs\Windows\v8.0A\bin\NETFX 4.0 Tools 
-------------------------------------------------------------------------------------------------------------------------------------------------------------
The SQLDbType to DBType has been performed as per the below URL
https://msdn.microsoft.com/en-us/library/cc716729(v=vs.110).aspx 
-------------------------------------------------------------------------------------------------------------------------------------------------------------
Topself (https://topshelf.readthedocs.org/en/latest/configuration/quickstart.html ):-
Below implementation from System.Threading.Timer is not suitable in windows service as this does not provide the flexibility to start and stop 
it explicitly.
Timer globalTimer = new Timer(new TimerCallback(entry.Dowork), param, param.DueTime, param.Interval);

Thus use system.timers.Timer.

-	This is not possible to pass command line argument during the installation of the windows service at runtime. It throw error from topshelf dlls 
as configuration error. There is a link (http://stackoverflow.com/questions/15245770/how-to-specify-command-line-options-for-service-in-topshelf) but 
not fit as modification in the registry is not good as per my concept. Instead follow this link https://github.com/Topshelf/Topshelf/blob/master/src/Topshelf/HelpText.txt

-	Topshelf creates the service name as "servicename"$"serviceinstancename". See it from right click property of the installed service.
-	Installing service from the bin folder is always a problem as it locks the .exe. To overcome use sc delete <<servicename>>.
-	Topshelf installation see this link. https://groups.google.com/forum/#!topic/topshelf-discuss/gq7H-V5nxv4
										 https://github.com/Topshelf/Topshelf/blob/master/src/Topshelf/HelpText.txt
----------------------------------------------------------------------------------------------------------------------------------------------------------------
Please visit the below URL for Code snippet mgmt.
https://msdn.microsoft.com/en-us/library/ms165394.aspx
----------------------------------------------------------------------------------------------------------------------------------------------------------------
DI Container
After investigation the performance benchmark and feature the most favoured containers are 
1. DryIoc 2. SimpleInject 3. TinyIoc
But to start with DI in terms of sample and documentation "SimpleInject" is the best fit. Folowed 
by TinyIoc and DryIoc.
http://iamrufio.com/2016/04/23/introduction-to-inversion-of-control-in-c-with-dry-ioc/ 
https://bitbucket.org/dadhi/dryioc/wiki/Home#markdown-header-usage-guide 