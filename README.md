# Developer Coding Test
## Running the application
To run this application, you will need to have .NET Core 8.0 installed. You can download it from [here](https://dotnet.microsoft.com/download/dotnet-core/8.0).
Once you have .NET Core 8.0 installed, you can run the application by navigating to the root directory of the project and running the following command:
```bash
dotnet run
```
This command will build and run your application.

## API Endpoints
The application has a single endpoint that returns the top 15 stories from HackerNewsAPI. The endpoint is as follows:
```
GET /stories?limit=15
```
The valid values for limit query parameter is (0-15). More details on assumptions can be found below.

## Assumptions
Assuming the acceptable response time for the API, the request is limited for 15 records per request, and the API is not paginated. API becomes slower when the number of records increases, and hence will not be able to handle large number requests, moreover will burden the HackerNewsAPI.

## Design Decisions
The application is desinged to be minimal api. It has a single endpoint that returns the top 15 stories from HackerNewsAPI. The application is designed to be simple

## Improvements
Following are the improvements that can be made to the application:
- Add pagination to the API (by adding skip and take parameters to the request)
- Add caching to the API to reduce the number of requests to HackerNewsAPI
- Add authentication to the API
- Add rate limiting to the API
- Add Unit Tests to the application.

