# JobsDemo

This is a test project. The projects uses Asp.net MVC version 4.7.2.
The solution has 3 projects. 

1. **SarahShaw.Data** This project contains the code-first classes and entities of Entity Framework for DB operations.
2. **SarahShaw.Web** This is the main project containing web pages and Web API.
3. **SarahShaw.WebTests** This is a project that contains unit tests of the project.


## Clone instructions
Clone the project and restore nuget packages if you get any build errors.

## Create the Database
The database script is stored in the **App_Data** forlder of startup project **SarahShaw.Web**. Run this script in the SQL Server and it will create two tables with demo data.
After creating the database you will need to change the connection string in the projects to establish a proper conneciton with the database.
The connection string will be changed in two projects **SarahShaw.Web** and **SarahShaw.WebTests**. 

1. Open web.config file in **SarahShaw.Web** and reaplce the connection string value for DemoEntities connection string. You may only need to change your server instance name and the database name.
2. Open app.config file in **SarahShaw.WebTests** and do the same changes as above to change the connection string.

## Testing the project
Run the project in your local browser by pressing F5 in visual studio when the solution is open.

**Web Page:** The web page containt list of all jobs in the database and can be accessed using https://localhost:44347/home/index.
**Web API:** The web api returns the jobs summary with room types, total jobs in specific room type and status of the job. The API can be accessed via end point https://localhost:44347/api/jobs/all

**The port number may be different on your machine**
