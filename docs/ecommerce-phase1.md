# E-commerce Clean Architecture - Phase 1: Foundation & Project Setup

## Overview
This phase establishes the foundation of your e-commerce application using Clean Architecture principles. You'll create the basic project structure and understand the core concepts before diving into implementation.

## What is Clean Architecture?
Clean Architecture separates your application into layers with clear dependencies flowing inward:
- **External layers depend on inner layers, never the reverse**
- **Business logic is isolated from external concerns**
- **Easy to test, maintain, and modify**

## Project Structure

```
ECommerce.Solution/
├── src/
│   ├── ECommerce.Domain/              # Core business entities and rules
│   ├── ECommerce.Application/         # Use cases and application logic
│   ├── ECommerce.Infrastructure/      # Data access, external services
│   └── ECommerce.WebAPI/             # API controllers and presentation
├── tests/
│   ├── ECommerce.Domain.Tests/
│   ├── ECommerce.Application.Tests/
│   ├── ECommerce.Infrastructure.Tests/
│   └── ECommerce.WebAPI.Tests/
└── docs/
    └── architecture/
```

## Layer Responsibilities

### 1. Domain Layer (ECommerce.Domain)
**Purpose**: Contains enterprise business rules and entities
**Contains**:
- Entities (Product, Order, Customer, etc.)
- Value Objects (Money, Address, Email)
- Domain Events
- Repository Interfaces
- Domain Services Interfaces
- Enums and Constants

**Dependencies**: None (pure business logic)

### 2. Application Layer (ECommerce.Application)
**Purpose**: Contains application-specific business rules and use cases
**Contains**:
- Use Cases/Commands/Queries
- DTOs (Data Transfer Objects)
- Mapping Profiles
- Application Services
- Validation Rules
- Interface definitions for external services

**Dependencies**: Only Domain layer

### 3. Infrastructure Layer (ECommerce.Infrastructure)
**Purpose**: Implements external concerns
**Contains**:
- Database context and configurations
- Repository implementations
- External service implementations (email, payment)
- File storage implementations
- Third-party integrations

**Dependencies**: Domain and Application layers

### 4. Presentation Layer (ECommerce.WebAPI)
**Purpose**: Handles HTTP requests and responses
**Contains**:
- Controllers
- Middleware
- Request/Response models
- Authentication/Authorization
- Dependency injection configuration

**Dependencies**: Application and Infrastructure layers

## Core Entities (Domain Models)

### Basic Entity Structure
```
Customer
├── Id (Guid)
├── Email (Value Object)
├── FirstName
├── LastName
├── DateCreated
└── IsActive

Product
├── Id (Guid)
├── Name
├── Description
├── Price (Value Object)
├── StockQuantity
├── CategoryId
├── DateCreated
└── IsActive

Order
├── Id (Guid)
├── CustomerId
├── OrderDate
├── Status (Enum)
├── TotalAmount (Value Object)
├── ShippingAddress (Value Object)
└── OrderItems (Collection)

OrderItem
├── Id (Guid)
├── OrderId
├── ProductId
├── Quantity
├── UnitPrice (Value Object)
└── TotalPrice (Value Object)
```

## Essential Libraries for Phase 1

### Domain Layer
- No external dependencies (keep it pure)

### Application Layer
```xml
<PackageReference Include="MediatR" Version="12.1.1" />
<PackageReference Include="FluentValidation" Version="11.7.1" />
<PackageReference Include="AutoMapper" Version="12.0.1" />
```

### Infrastructure Layer
```xml
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="8.0.0" />
```

### WebAPI Layer
```xml
<PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="8.0.0" />
<PackageReference Include="Swashbuckle.AspNetCore" Version="6.5.0" />
<PackageReference Include="Serilog.AspNetCore" Version="7.0.0" />
```

## Basic Business Flow - Order Processing

### High-Level Flow
1. **Customer browses products** → Get products from catalog
2. **Customer adds to cart** → Validate product availability
3. **Customer proceeds to checkout** → Validate cart items
4. **Customer places order** → Create order, reduce inventory
5. **Order confirmation** → Send confirmation email
6. **Order fulfillment** → Update order status, ship product

### Key Business Rules
- Products must be in stock before adding to order
- Order total must be calculated correctly including taxes
- Customer must be authenticated for checkout
- Inventory must be updated when order is placed
- Order status changes must be tracked

## Design Patterns to Use

### 1. Repository Pattern
- Abstract data access
- Enable easy testing
- Separate business logic from data concerns

### 2. CQRS (Command Query Responsibility Segregation)
- Separate read and write operations
- Use MediatR for handling commands and queries
- Optimize read and write models independently

### 3. Domain Events
- Decouple business operations
- Enable reactive behavior
- Improve maintainability

## Phase 1 Deliverables

By the end of Phase 1, you should have:
1. ✅ Solution structure created with all projects
2. ✅ Basic domain entities defined
3. ✅ Repository interfaces in Domain layer
4. ✅ Basic use case structure in Application layer
5. ✅ Database context setup in Infrastructure layer
6. ✅ Basic API controllers in WebAPI layer
7. ✅ Dependency injection configured
8. ✅ Basic project references established

## Next Phase Preview

Phase 2 will cover:
- Implementing CRUD operations for Products
- Setting up Entity Framework with Code First
- Creating your first use cases with MediatR
- Basic API endpoints
- Simple validation rules

## Interview Talking Points

When discussing this project in interviews, emphasize:
- **Separation of Concerns**: Each layer has a specific responsibility
- **Dependency Inversion**: High-level modules don't depend on low-level modules
- **Testability**: Business logic is isolated and easily testable
- **Maintainability**: Changes in one layer don't affect others
- **Scalability**: Easy to swap implementations or add new features

## Key Questions You Should Be Able to Answer

1. Why did you choose Clean Architecture?
2. How does dependency flow work in your solution?
3. What are the benefits of keeping the Domain layer dependency-free?
4. How would you add a new feature (e.g., product reviews)?
5. How would you change the database from SQL Server to PostgreSQL?

---

**Status**: Phase 1 - Foundation Complete
**Next**: Phase 2 - Basic CRUD Operations