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

