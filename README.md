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
##### Artists
1. Get all artists: `GET api/artists/`
2. Get all solo artists: `GET api/artists/solo`
3. Get artist by ID: `GET api/artists/{id}`
4. Create a artist: `POST api/artists`
5. Create a artist: `POST api/artists`/solo
6. Update a artist: `PATCH api/artists/{id}`
7. Delete a artist: `DELETE api/artists/{id}`

##### ArtistsDescriptions
1. Get all artistDescriptionDescriptions: `GET api/artistDescriptions/`
2. Get artistDescription by ID: `GET api/artistDescriptions/{id}`
3. Create a artistDescription: `POST api/artistDescriptions`
4. Update a artistDescription: `PATCH api/artistDescriptions/{id}`
5. Delete a artistDescription: `DELETE api/artistDescriptions/{id}`

##### Albums
1. Get all albums: `GET api/albums/`
2. Get album by ID: `GET api/albums/{id}`
3. Create a album: `POST api/albums`
4. Update a album: `PATCH api/albums/{id}`
5. Delete a album: `DELETE api/albums/{id}`
6. Search in albums: `GET api/albums/search`
