# Animals-system
# AnimalSupportSystem.Business

This is the core project for the solution. Is relaying on Command design pattern.

## Getting Started

There are four part to the Command pattern.

Command: Classes that execute an action(perform a function). In this case they are stored in Commands folder.

Reciver: Business objects that 'recive' the action from the command. In this case, we do not have much business logic here, and the only thing we do is
to insert data, sо for this, our receivers are model intities(AdoptionCenter, AnimalRegister, Request ec.).

Invoker: This class tells the Commands the execute thier actions. Our invoker is MedicalInvoker and has a AddCommand() method, it's adding
new command to the list of commands, and ProcessPendingCommands() method, executes all stored commands.
 
Client: Web API is calling the business logic.

We have created MedicalHandler, this class will handle the created commands from the FactoryCommand


### Prerequisites

Need to install log4net, this will help us to log the information and errors

### Installing

step 1: Tools –> Library Package Manager –> Package Manager Console
        Run the Install-Package log4net

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
