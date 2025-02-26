# Verisk
C# submissions by interview candidate Qingtian Li

# Instructions
Requires [.NET 9.0 Runtime](https://dotnet.microsoft.com/en-us/download) ( on Windows )

# Exercise 1: Countdown Program with Error Handling
```bash
cd BackwardsCounter
dotnet build
BackwardsCounter\bin\Debug\net9.0\BackwardsCounter.exe 25 5
```
`BackwardsCounter\BackwardsCounterTests` contains the unit test for the main function. Test results:

![TestResults](https://github.com/user-attachments/assets/1136ab18-80d5-404f-9dcf-707413d4f0a3)

________________________________________
 
# Exercise 2: Multithreaded Data Processing
```bash
cd MultiThreading
dotnet build
MultiThreading\bin\Debug\net9.0\Exercise2_MultiThreading.exe Data/numbers.txt Data/output.txt
```
________________________________________
 
# Exercise 3: REST API Development in ASP.NET Core
```bash
cd RestApi
dotnet run --project RestApi
```
API should be accessible at:

http://localhost:5100

See Swagger UI ( http://localhost:5100/swagger/index.html ) for easy testing of the REST API.

## Endpoints

`GET`	`/api/products`	Returns all products.

`GET`	`/api/products/{id}`	Returns a specific product.

`POST`	`/api/products`	Adds a new product.

`PUT`	`/api/products/{id}`	Updates a product.

`DELETE`	`/api/products/{id}`	Deletes a product.

### Additional Information
- The API uses **Microsoft EntityFramework InMemory** database only for demonstration purposes. The products information stored resets when the API is restarted. In production, a connection to a real database, like SQL Server, can be used with Entity Framework or other technologies.
- Id is optional when posting an item. The database assigns the `id` to be the largest existing Id plus 1 if not specified.
- Id is non-zero. If `id` is 0 in the request body, it is equivalent to `id` not specified.
- Id cannot be updated. If trying to change the `id` using the `PUT` method, a `BadRequest` Error will occur.
- By HTTP stantard, updating an item with the `PUT` method requires all fields, not just changed ones.
- Returns 404 if `id` does not exist
________________________________________
# Bonus: AWS Microservices Migration
See `Data/AWS_Migration_Plan.pdf`
