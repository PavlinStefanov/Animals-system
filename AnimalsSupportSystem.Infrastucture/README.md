# AnimalSupportSystem.Infrastructure

This project contains the first layer that will communicate with the database.
The idea here is to create a thin layer for adding and fetching data from the storage. 

## Getting Started

We have a model folder, which contains all entities. Is used code first approach with Entity framework.
We also have a configuration folder which contains all configurations for the entities, Entity framewrok contains
Fluent Api for this purpose. EF Fluent api is based on a Fluent API design pattern(https://en.wikipedia.org/wiki/Fluent_interface) where the result
is formulated by method chaining(https://en.wikipedia.org/wiki/Method_chaining).

Context folder has a AnimalSystemDbContext which implements DbContext class, this class is a entry point for communication with the database.
We have an AnimalSystemDbContextFactory with one method Create(), this method is creating new DbContext instance.
Both of the classes have an abstractions.
 
```
private readonly IAnimalSystemDbContextFactory<IAnimalSystemDbContext> _dbContextFactory

public MyConstructor(IAnimalSystemDbContextFactory<IAnimalSystemDbContext> dbContextFactory)
{
    _dbContextFactory = dbContextFactory;
}

public void MyMethod()
{
    using(var dbContext = _dbContextFactory.Create())
	{
	    // data manipulation operations..
	}
}
```

Folders Configuration and Migrations are created by Entity framewrok

### Prerequisites

For working corectly and comunicate with the database we need to install Entity Framework. The current version of the framewrok that we are using
is 6.2.0

In App.config file add connection string 
```
<connectionStrings>
  <add name="connectionStringName" connectionString="Data Source=server name;Initial Catalog=database name;Integrated Security=SSPI; MultipleActiveResultSets=true" providerName="System.Data.SqlClient" />
</connectionStrings>
```

### Installing

step 1: Tools –> Library Package Manager –> Package Manager Console
        Run the Install-Package EntityFramework command
step 2: Run the Enable-Migrations command in Package Manager Console
step 3: Run Add-Migration migrationName
step 4: Run Update-Database

