
# Key Account Management Lead Management System

This is a web-based application for managing property listings, providing users with functionalities to search, buy, or rent properties. The backend is built on .NET 8, while the frontend uses Angular 14. The application connects to a SQL Server database for data management.

## System Requirements

**Backend**  
- .NET 8 SDK or later  
- SQL Server 2019 or later  
- Azure (if project needs to be deployed)

**Frontend**  
- Node.js v16 or later  
- Angular CLI v14.2 or later  
- Web browser (Google Chrome, Edge, or Firefox recommended)  

**General**  
- Operating System: Windows 10/11, macOS 10.15+, or Linux  
- Memory: Minimum 8GB RAM  
- Disk Space: Minimum 2GB free space  

## Installation Instructions

1. **Clone the Repository**  
   ```bash
   git clone https://github.com/divyancod/LMSDemo.git
   cd LMSDemo
2. **Backend Setup**
   ```bash
   cd KAMLMSBackend
   dotnet restore
   dotnet ef database update
   ```
	Please update the connection string to the SQL Server according to your Credentials in appsetting.json
	  ```bash
	  "ConnectionStrings": {
	 "KAMLMSDbString": "Data Source=.;initial catalog=KAMLMSDb;Integrated Security=True;TrustServerCertificate=True;"=
	}
	 ```
3. **Frontend Setup**
   ```bash
   cd KAMLMSFrontend/lms-ui
   npm install
   ```      
	Update the backend URL as per your system if backend starts on different port in the environment.ts file.
	```bash
	export const environment  = {
	production:  false,
	apiUrl:  'https://localhost:7129/api'};
	```
4. **Running Backend**
	```bash
	cd KAMLMSBackend/KAMLMSBackend
	dotnet run --launch-profile "https"
	```
	Hosting of backend will start on  "https://localhost:7129"
	Swagger can be accessed on - https://localhost:7129/swagger/index.html
	**Can be modified in launchSettings.json**
	
5. **Running Frontend**
	```bash
	cd KAMLMSFrontend/lms-ui
	ng serve
**Visit localhost:4200 the application will be accessible**

6. **Run backend test**
	```bash
	cd KAMLMSBackend/KAMLMSBackend
	dotnet test
**This application is primarily focused on backend functionality; therefore, the tests are designed and implemented specifically for the service layer of the backend.**


# KAMLMSBackend API Documentation
## Table of Contents

- [Authentication](#authentication)
  - [Sign Up](#sign-up)
  - [Login](#login)
- [Call Management](#call-management)
  - [Create Call Schedule](#create-call-schedule)
  - [Update Call Schedule](#update-call-schedule)
  - [Get Call Schedules](#get-call-schedules)
- [Dashboard](#dashboard)
  - [Get Dashboard Overview](#get-dashboard-overview)
  - [Get Follow-ups by Date](#get-follow-ups-by-date)
  - [Get Follow-ups by Risk](#get-follow-ups-by-risk)
- [Lead Management](#lead-management)
  - [Create Lead](#create-lead)
  - [Update Lead](#update-lead)
  - [Get Lead Details](#get-lead-details)
- [Reference Data](#reference-data)
  - [Get Roles](#get-roles)
  - [Get Countries](#get-countries)
  - [Get Call Status Types](#get-call-status-types)
  - [Get Lead Types](#get-lead-types)
- [Point of Contact](#point-of-contact)
  - [Create Point of Contact](#create-point-of-contact)
  - [Get Point of Contact by Company ID](#get-point-of-contact-by-company-id)

---

## Authentication

### Sign Up

**POST** `/api/auth/signup`

Register a new manager.

#### Request Body

```json
{
  "email": "string",
  "password": "string",
  "fullName": "string",
  "phone": "string"
}
