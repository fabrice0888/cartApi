# cartApi 

Introduction

Hello, I tried to create the application as simple as possible.  The home page gives a list of all APIs created. Expanding the API panel will give you an interface/library required on how to use the API.


Project Structure

Both part1 and part2 are found in the same project, it would be easier to run the application. The Home controller returns my views and the Product controller holds my APIs.


Data Storage

A local database has been used to store the data. A seeding method is populating the db with some initial data in the migration file.


Assumptions

-Authentication is not present but, the project has been designed to manage the basket of items for a specific customer (Customer Id “1”). A basic authentication with a token based mechanism can be use later to authenticate multiple users.
-The API does not cover auditing, invoicing, customer and product management.
