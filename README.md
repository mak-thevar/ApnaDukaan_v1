# File Structure

```
│   ApnaDukaan_v1.csproj
│   ApnaDukaan_v1.csproj.user
│   appsettings.Development.json
│   appsettings.json
│   ClassDiag.cd
│   Program.cs
│   WeatherForecast.cs
│
├───BLL
│   ├───AutomapperProfile
│   │       DefaultProfile.cs
│   │
│   ├───DTOs
│   │       ProductRequestDTO.cs
│   │       ProductResponseDTO.cs
│   │
│   ├───Middlewares
│   │       ExceptionHandlerMiddleware.cs
│   │
│   └───Services
│           IProductService.cs
│
├───Controllers
│       CategoryController.cs
│       ProductController.cs
│       WeatherForecastController.cs
│
├───DAL
│   │   SeedingInitalData.cs
│   │
│   ├───DBContext
│   │       ApnaDukaanContext.cs
│   │
│   ├───Entities
│   │       Address.cs
│   │       Cart.cs
│   │       CartDetail.cs
│   │       Category.cs
│   │       Order.cs
│   │       OrderDetail.cs
│   │       Product.cs
│   │       Role.cs
│   │       User.cs
│   │
│   └───Repositories
│           IBaseRepository.cs
│
├───Migrations
│       20240122120725_EmptyMigration.cs
│       20240122120725_EmptyMigration.Designer.cs
│       20240122121205_SeedingTheInitalData.cs
│       20240122121205_SeedingTheInitalData.Designer.cs
│       ApnaDukaanContextModelSnapshot.cs
│
└───Properties
        launchSettings.json
```
