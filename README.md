# Album Store API
This is an Web API coded in ASP.NET Core based on the sample API used in the "Implementing Entity Framwork with MVC" [MSDN online course](https://channel9.msdn.com/Series/Implementing-Entity-Framework-with-MVC).

### Technology Used
* C# (ASP.NET Core)
* Entity Framework

### Run the app
```
dotnet run
```

### API Functionalities
##### Albums
1. Get all albums: `GET api/albums/`
2. Get album by ID: `GET api/albums/{id}`
3. Create an album: `POST api/albums`
4. Update an album: `PATCH api/albums/{id}`
5. Delete an album: `DELETE api/albums/{id}`
6. Search albums: `GET api/albums/search`

##### Artists
1. Get all artists: `GET api/artists/`
2. Get all solo artists: `GET api/artists/solo`
3. Get artist by ID: `GET api/artists/{id}`
4. Create an artist: `POST api/artists`
5. Create a solo artist: `POST api/artists/solo`
6. Update an artist: `PATCH api/artists/{id}`
7. Update a solo artist: `PATCH api/artists/solo/{id}`
8. Delete an artist: `DELETE api/artists/{id}`

##### ArtistsDescriptions
1. Get all artistDescriptions: `GET api/artistDescriptions/`
2. Get artistDescription by ID: `GET api/artistDescriptions/{id}`
3. Create an artistDescription: `POST api/artistDescriptions`
4. Update an artistDescription: `PATCH api/artistDescriptions/{id}`
5. Delete an artistDescription: `DELETE api/artistDescriptions/{id}`
