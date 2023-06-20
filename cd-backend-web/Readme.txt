Tools:
- Visual Studio Community (https://visualstudio.microsoft.com/vs/community/.  When installing, only the ASP.NET and Web Development workload needs to be selected.  Uncheck other workloads, but leave any other components.)
- Sql Server Express (https://www.microsoft.com/en-us/download/details.aspx?id=104781)
  - If you choose to use something other than Sql Server Express and it's defaults, the DefaultConnection in appsettings.Development.json will need to be changed to match the new connection
- Azure Data Studio (https://learn.microsoft.com/en-us/sql/azure-data-studio/download-azure-data-studio?view=sql-server-ver16&tabs=redhat-install%2Credhat-uninstall#download-azure-data-studio)

Nuget Packages:
- Dapper (will install when first built or by selecting 'Restore Nuget Packages' from solution context menu

Troubleshooting:

- If Edge complains about localhost certificate when launching, you can type 'thisisunsafe' after clicking anywhere in the browser window (the letters won't actually show, just type them).
This will tell Edge to trust the SSL connection, regardless of certificate
