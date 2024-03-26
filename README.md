# Application Architecture Overview
This repository exemplifies a structured application based on a layered architecture, adhering to Domain-Driven Design (DDD) principles.
<br>
<br>
<br>
# Layers
### Domain Layer
The Domain Layer encapsulates entities, enums, specifications, and defines repository and unit of work contracts. It remains independent of other layers.

### Application Layer
The Application Layer houses business logic, services, service interfaces, and request/response models. Additionally, it defines third-party service interfaces. This layer depends on the Domain Layer.

### Infrastructure Layer
The Infrastructure Layer encompasses database-related logic (Repositories and DbContext) and implementations of third-party libraries (e.g., logging and email services). It is constructed upon the Domain and Application layers.

### Presentation Layer
The Presentation Layer comprises Web API or UI components.
<br><br><br>


# Used Technologies
- .Net 8<br>
- Entity Framework<br>
- Rest API<br>
- Xunit<br>
- Generic Repository Pattern<br>
- Specification pattern<br>
- Moq<br>
- Swagger<br>
- NLog<br>
