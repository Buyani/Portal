
# Prototype of Matric Upgrade Management System

#Finished Use Cases
1. Register(Basic User) 
2. Login
3. Create Subject

#Pending Use Cases(to be intergrated)
1. Confirm Email
2. Reset Password
3. Update Profile
4. Register Student

COT Project support CRUD operations for cot reports for forex anlysis ,howerver in future more use cases will be added to this project for expand its functionality

# Frameworks - Libraries

1. ASP.NET MVC (version 5)
2. Repository Pattern
3. Entity Framework .Net Core 3.1.0
4. IdentityFramework(Security)
   ===>In this project I extended IdentityUser into ApplicationUser this was done in order to add more attributes that are no presewnt in Identity class
4. Automapper
5. UnitOfWork

# Running Project

- Open the project with Visual Studio 2019
- in `appsettings.json`file change the connection string according to your system.
  ```
    "ConnectionStrings": {
    "CotConnection": "Server=(localdb)\\mssqllocaldb;Database=CotData;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  ```
- In package manager console run the following commands 
    ```
	-Add-Migration InitialCreate or use any name you like
	-Update-database 
   ```
- Run the project start adding cot reports

#  Not much validation has been done in this project 
