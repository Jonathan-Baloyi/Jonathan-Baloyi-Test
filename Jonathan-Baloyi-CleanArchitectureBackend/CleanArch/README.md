# CleanArchitectureDemo
This is an overview of clean architecture

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
