# Scenario
Starting a new project using a microservice architecture requires a lot of extra effort.  
We know that a monolithic solution also has some restrictions, as scalability.  
What if we tell you that there is an alternative solution that merges the best of two scenarios?  

# What is ModularArchitecture
The idea behind this architecture style is simple:  
> - Low Coupling: Each module should be independent of other modules in the system  
> - High Cohesion: Components of the module are all related thus making it easier to understand what module does as a self-contained subsystem (SRP)  

# The solution
From a high level, the architecture defines an API, two modules, and a common event bus for communication (IMediatr):  
Each module is separated into some projects, which are implemented as separate binaries: 
> - `Facade` for handling all requests  
> - `Domain` for domain logic and as a handler for all Commands  
> - `Messages` for the definitions of Commands and Events classes  
> - `ReadModel` for the handlers of DomainEvents and the readmodel management  
> - `SharedKernel` that contains domainId, Dtos, and all shared components

# Fitness Functions
Are special tests that ensure that the architecture, defined at the beginning of the project, remains valid.  
In this solution we used two different libraries  
> - ArchUnitNET is a free, simple library for checking the architecture of C# code. It is the C# fork of ArchUnit Java for Java  
> - NetArchtest is a fluent API for .Net Standard that can enforce architectural rules in unit tests. It's inspired by the ArchUnit library for java  

# Run Solution
> - docker build -t brewup .  
> - docker run --rm -p 8000:80 brewup