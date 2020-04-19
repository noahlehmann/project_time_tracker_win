<div align="center">![icon](https://github.com/noahlehmann/project_time_tracker_win/blob/develop/timer.ico "http://www.iconarchive.com/artist/vcferreira.html")</div>

# Project Time Tracker Win 

## Setup

1. #### Open Nuget Paket Manager and install following packages
   
   1.1 **LiveCharts.WPF** (min. version 0.9.7) and dependencies
   
   1.4 **Microsoft.EntityFrameworkCore** (min. version 3.1.2) and depedencies
   
   1.3 **JetBrains.Annotations** (min. version 2019.1.3) and dependencies
   
   1.4 **MaterialDesignThemes** (min. version 3.0.1) and dependencies

   **Note**: Dependencies should install automatically

2. #### Open Paket-Manager-Console

   2.1 Issue Command (Once per project setup)
	
   ````Script 
   Enable-Migrations
   ````
   
   2.2 Issue Command (Once per change in Data Model)

   ````Script
   Add-Migration '[Name]'
   ````
   
   2.3 Issue Command (To run a migration)
	
   ````Script
   Update-Database
   ````

