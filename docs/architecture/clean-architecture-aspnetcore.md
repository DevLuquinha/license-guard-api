# Clean Architecture in ASP.NET Core

Author: Lucas Emmanuel Rodrigues Firmino de Paula  
Date: 21/01/2026  
Summary: This document describes Clean Architecture concepts applied to ASP.NET Core, focusing on architectural decisions for the LicenseGuard API.

---

### Guiding Question
"How should Clean Architecture be applied to an ASP.NET Core Web API to keep business rules isolated, controllers thin, and the system simple and maintainable without overengineering?"

---

## Purpose of the Document
This document focuses on understanding how Clean Architecture principles apply specifically to ASP.NET Core Web APIs.  
It aims to support conscious architectural decisions for the LicenseGuard API and does not define implementation details, frameworks, or libraries.

---

## Clean Architecture Overview (Conceptual)

- What Clean Architecture is<br>
`Clean Architecture has the main ideia: "The center of my software not is the database or framework, however the business rules."`
- What problem it solves<br>
`The clean architecture solves the dangerous coupling of the classic architecture (UI -> Business -> Data), if the database changed, will need to change the business layer. Helps decouple from frameworks, difficulties with tests and fragility.`
- Why it is not about folders or frameworks<br>
`Because it is about concepts and business logic, not just about folders structures or frameworks/features.`
- Difference between architecture and implementation<br>
`Architecture defines the high-level, intentional structure and rules of a system, while implementation is the concrete, technical execution of that design.`
---

## Layers in Clean Architecture
(To be filled after study)

### Domain Layer
- What belongs here<br>
`1. Entities: Objects that has an ID and contains business logic example: License or Customer.`<br>
`2.Value objects: Objects that has not an ID, only defined by their values example: LicenseKey, DateRange.`<br>
`3. Repositories Interfaces: I contract type of says "I need to save a license".`
- What must NEVER be here<br>
`1. Entity Framework references or database frameworks`<br>
`2. Nothing about ASP.NET Core like HttpContext, ControllerBase or ActionResult`<br>
`3. Libraries, the domains need to be C# only.`
- Why this layer has no dependencies<br>
`Because this layer needs to be the "Point of the Truth", without dependencies, the unit tests are immediately solves.`

### Application Layer
- Responsibilities of the application layer
- Difference between business rules and orchestration
- Why it should not depend on ASP.NET Core

### Infrastructure Layer
- Why infrastructure is a detail
- What kind of code belongs here
- Why it depends on Application and Domain

### API Layer (Presentation / Delivery)
- Role of ASP.NET Core in the architecture
- Why controllers are considered adapters
- What should and should not be inside controllers

---

## Dependency Rule

- Explanation of the dependency direction<br>
`The main rule about the Clean Architecture is the dependency rule. This rule say that source code dependencies can only point inward, the domain/entity layer.`
- Why dependencies always point inward<br>
`Because the high-layers can recieve changes, so if all of the dependencies always point inward, we can changes the external layers without change the domain/business rules, because they are in the center.`
- Why the Domain must be the most stable layer
`Because all of application depends of the Domain Layer. This means resistance to change.`

---

## Clean Architecture Applied to ASP.NET Core
(To be filled after study)

- Where ASP.NET Core fits in the architecture
- Why ASP.NET Core should be isolated in the API project
- Why Application and Domain must be framework-agnostic

---

## Thin Controllers Principle
(To be filled after study)

- What “thin controllers” means
- Responsibilities of a controller
- What controllers should NOT do
- Why business logic in controllers is harmful

---

## Cross-Cutting Concerns
(Conceptual understanding only)

- Error handling
- Result pattern (success / failure)
- Logging
- Authentication and authorization

Note: These concerns should not pollute the Domain layer.

---

## Common Mistakes to Avoid
(To be filled after study)

- Turning Clean Architecture into folder architecture
- Letting Domain depend on EF Core
- Writing business rules inside controllers
- Overengineering with unnecessary patterns
- Treating Application layer as a pass-through

---

## Architectural Decisions for LicenseGuard API
(To be filled after study)

- Number of projects in the solution
- Responsibility of each project
- What is intentionally kept simple
- What is intentionally postponed

---

## Study Checklist

[ ] What is Clean Architecture really about?  
[ ] Why Clean Architecture is not framework-dependent  
[ ] Responsibilities of each layer  
[ ] Dependency rules and their importance  
[ ] How ASP.NET Core fits into Clean Architecture  
[ ] What makes a controller “thin”  
[ ] Where business rules should live  
[ ] Where infrastructure concerns should live  
[ ] Common pitfalls in ASP.NET Core Clean Architecture projects  
[ ] I can explain the LicenseGuard architecture decisions without mentioning frameworks  

---

## Completion Criteria
This study is considered complete when I can confidently answer:

- Why the LicenseGuard API is split into multiple projects
- Why the Application layer does not depend on ASP.NET Core
- Why the Domain layer has no external dependencies
- Why Infrastructure is treated as a detail
- Why controllers must remain thin
