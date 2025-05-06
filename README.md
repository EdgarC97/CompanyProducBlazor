# CompanyProductBlazor

Aplicación web Blazor WebAssembly para la gestión de compañías y productos.

## Requisitos Previos

* [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
* Backend API corriendo localmente (verifica que esté en funcionamiento y toma nota de la URL base y el puerto, como `https://localhost:5041` o similar)

## 📦 Estructura del Proyecto

* `CompanyProductBlazor` - Proyecto Blazor WebAssembly (Frontend)

```
CompanyProductBlazor/
├── wwwroot/
│   ├── css/
│   │   ├── app.css
│   │   ├── base.css
│   │   ├── components/
│   │   │   ├── buttons.css
│   │   │   ├── forms.css
│   │   │   ├── modals.css
│   │   │   ├── notifications.css
│   │   │   ├── spinners.css
│   │   │   └── tables.css
│   │   ├── pages/
│   │   │   ├── companies.css
│   │   │   └── products.css
│   │   └── open-iconic/
│   ├── favicon.ico
│   └── index.html
├── Pages/
│   ├── Companies/
│   │   ├── CompanyCreate.razor
│   │   ├── CompanyDetails.razor
│   │   ├── CompanyEdit.razor
│   │   └── CompanyList.razor
│   ├── Products/
│   │   ├── ProductCreate.razor
│   │   ├── ProductDetails.razor
│   │   ├── ProductEdit.razor
│   │   └── ProductList.razor
│   ├── Index.razor
│   └── Counter.razor
├── Shared/
│   ├── MainLayout.razor
│   ├── NavMenu.razor
│   └── NotificationComponent.razor
├── Models/
│   ├── Company.cs
│   └── Product.cs
├── Services/
│   ├── Interfaces/
│   │   ├── ICompanyService.cs
│   │   ├── IProductService.cs
│   │   └── INotificationService.cs
│   ├── CompanyService.cs
│   ├── ProductService.cs
│   └── NotificationService.cs
├── Helpers/
│   └── HttpClientExtensions.cs
├── App.razor
├── Program.cs
└── _Imports.razor
```
## Configuración del Frontend

1. Abre el archivo `Program.cs` en `CompanyProductBlazor` y verifica que el `HttpClient` apunte a la URL correcta del backend:

```csharp
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5041/api/") });
```

⚠️ Asegúrate de que la URL coincida con la del backend local.

## Ejecutar el Proyecto

1. Abre una terminal y ve a la carpeta del proyecto `CompanyProductBlazor`
2. Ejecuta:

```bash
dotnet run
```

3. Abre tu navegador y ve a `https://localhost:5200` (o el puerto que indique la consola)

## Funcionalidades

* CRUD de compañías
* CRUD de productos asociados a compañías
* Visualización de listas ordenadas por fecha de creación
* Validaciones de formularios (campos obligatorios, email, teléfono numérico de 10 dígitos)
* Modal de confirmación y notificaciones amigables

## Notas

* Las notificaciones emergentes se muestran centradas como modales.
* La eliminación de compañías con productos asociados no está permitida por el backend; el frontend lo notifica con un mensaje claro.

---

Disfruta del proyecto 🚀


