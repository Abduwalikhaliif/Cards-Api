# Cards Application RESTful API

This project implements a RESTful web service for managing cards in the Cards application. It is built using C#, .NET, and an SQL database.

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Endpoints](#endpoints)
- [Authentication and Authorization](#authentication-and-authorization)
- [Database Design](#database-design)
- [Documentation](#documentation)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)

## Introduction

The Cards application is designed to allow users to manage their cards with various properties such as name, description, color, and status. This API provides endpoints for creating, searching, retrieving, updating, and deleting cards, as well as user authentication and authorization.

## Features

1. User Authentication and Authorization
2. Card Creation
3. Card Search and Filtering
4. Single Card Retrieval
5. Card Update
6. Card Deletion
7. Database Design
8. RESTful API Implementation
9. Documentation

## Technologies Used

- C#
- .NET Core
- SQL Database (SQL Server)
- ASP.NET Core Web API
- JSON Web Tokens (JWTs)

## Endpoints

- POST /api/auth/login (User Login)
- POST /api/cards (Create Card)
- GET /api/cards (Search and Filter Cards)
- GET /api/cards/{id} (Retrieve Single Card)
- PUT /api/cards/{id} (Update Card)
- DELETE /api/cards/{id} (Delete Card)

## Authentication and Authorization

- Users are authenticated using a password-based login system.
- JSON Web Tokens (JWTs) are used for secure user info storage and authorization.
- Users are assigned roles: Member (access to own cards) and Admin (access to all cards).

## Database Design

- Tables: Users, Cards
- Relationships: User ID as a foreign key in the Cards table

## Documentation

API documentation is available using [Swagger/OpenAPI](#) (optional).

## Usage

To run this API project locally, follow the installation instructions in the [Installation](#installation) section.

## Contributing

Contributions are welcome! If you'd like to contribute to this project, please follow the guidelines outlined in the [Contributing](CONTRIBUTING.md) file.

## License

This project is licensed under the [MIT License](LICENSE).

## Contact

For any questions or inquiries, please contact [Abduwali khaliif](mailto:abduwaliabdullahi23@gmail.com).
