# Coderr

## Description
Coderr is an ASP.NET Core application for freelance IT services. Users can create accounts, post offers for services, place orders for available services, and submit reviews.

Please do also check out the DRF-version for this API under: https://github.com/mariuskas1/coderr_backend

---

## Tech Stack
- **.NET**: 8.0
- **ASP.NET Core**: 8.0
- **Entity Framework Core**: 9.0.2
- **JWT Authentication**
- **AutoMapper**: 14.0.0
- **Swagger (Swashbuckle)**: 6.6.2
- **SQL Server**

---

## NuGet Dependencies
- **AutoMapper**: 14.0.0
- **Microsoft.AspNetCore.Authentication.JwtBearer**: 8.0.2
- **Microsoft.AspNetCore.Identity.EntityFrameworkCore**: 8.0.2
- **Microsoft.EntityFrameworkCore.SqlServer**: 9.0.2
- **Microsoft.EntityFrameworkCore.Tools**: 9.0.2
- **Microsoft.IdentityModel.Tokens**: 8.6.0
- **SSwashbuckle.AspNetCore**: 6.6.2
- **System.IdentityModel.Tokens.Jwt**: 8.6.0

---



## API Endpoints

### Offers
* GET /offers/ - Retrieve a list of offers with filtering and search options
* POST /offers/ - Create a new offer with details
* GET /offers/{id}/ - Retrieve details of a specific offer
* PATCH /offers/{id}/ - Update a specific offer
* DELETE /offers/{id}/ - Delete a specific offer
* GET /offerdetails/{id}/ - Retrieve details of a specific offer detail

### Orders
* GET /orders/ - Retrieve the orders for the logged-in user
* POST /orders/ - Create a new order based on an offer
* GET /orders/{id}/ - Retrieve details of a specific order
* PATCH /orders/{id}/ - Update the status of a specific order
* DELETE /orders/{id}/ - Delete an order (Admin only)
* GET /order-count/{business_user_id}/ - Retrieve the count of active orders for a business user
* GET /completed-order-count/{business_user_id}/ - Retrieve the count of completed orders for a business user

### General Information
* GET /base-info/ - Retrieve general platform information

### User Profiles
* GET /profile/{id}/ - Retrieve details of a specific user
* PATCH /profile/{id}/ - Update details of a specific user
* GET /profiles/business/ - Retrieve a list of business user
* GET /profiles/customer/ - Retrieve a list of customer profiles

### Authentication & Registration
* POST /auth/login/ - User login
* POST /auth/registration/ - User registration

### Reviews 
* GET /reviews/ - Retrieve a list of reviews
* POST /reviews/ - Create a new review
* GET /reviews/{id}/ - Retrieve details of a specific review
* PATCH /reviews/{id}/ - Update a specific review
* DELETE /reviews/{id}/ - Delete a specific review






