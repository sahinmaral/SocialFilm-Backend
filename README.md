# SocialFilm

Before running backend side, you have to create appsettings.json file at SocialFilm.WebAPI folder.
And set ;

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "PSQLConnectionString": "Your_PSQL_Connection_String"
  },
  "JwtOptions": {
    "Issuer": "SocialFilm",
    "Audience": "SocialFilm",
    "SecurityKey": "Your_Security_Key",
    "AccessTokenExpiration": 3,
    "RefreshTokenExpiration": 15
  },
  "Cloudinary": {
    "CloudName": "Your_Cloudinary_CloudName",
    "APIKey": "Your_Cloudinary_APIKey",
    "APISecret": "Your_Cloudinary_APISecret"
  },
  "TMDBApi": {
    "APIKey" : "Your_TMDB_API_Key"
  },
  "AllowedHosts": "*"
}
```
