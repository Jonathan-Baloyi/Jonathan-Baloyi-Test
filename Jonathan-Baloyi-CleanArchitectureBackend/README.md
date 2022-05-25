# CleanArchitectureDemo
This is an overview of clean architecture

The idea is to separate concerns

We have the 4 important layers which are the Domain layer, Persistance / Data layer, application layer and the presentation layer.

## Domain Layer
The layer contains the Models / Entities and the interfaces of the Repository

## Application Layer
The layer is dependent on the Domain layer and it contains the Application logic
[ Services and View Models ]. The idea is that the service will have the implementation and the controller will just call the service.

## Persistance Layer or Data Layer
This layer is self explanatory, anything relating to database is done here and the layer is dependent on the Domain layer

## Presentation layer
This layer contains the controllers which call the service. The service is Injected on the constructor 

## Adding Migrations for SchoolDbContext
1. Run the following command against infrastructure.data project in the package manager console
```
add-migration InitialMigration -Context SchoolDbContext
```

2. There after update the database for the changes to show in sql database
```
update-database -Context SchoolDbContext
```

## Adding Migrations for IdentityDb
1. Run the following command against Mvc project in the package manager console
```
add-migration InitialMigration -Context ApplicationDbContext
```

2. There after update the database for the changes to show in sql database
```
update-database -Context ApplicationDbContext
```
