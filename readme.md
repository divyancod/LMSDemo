
# Key Account Management Lead Management System

https://klmsfrontend.azurewebsites.net/login
This web application is designed for the account managers to manage leads and track according to the requirements and info. Built on .NET and Angular providing flexibility.

# Features

1. **Authentication and Authorization** to access the platform.
2. **Add Lead** - Add your leads with leads data.
3. 5 States for leads - **NEW, IN PROGRESS, FollowUP, Closed Won, Closed Lost**
4. **Point Of Contact** - Add any point of contact with system built in **roles** with the flexibility to add **CUSTOM ROLE** if system built in roles doesn't match the ROLE of POC. 
5. Dashboard endpoints to populate data on dashboard with 
	1. **Todays Calls** - Call scheduled for today
	2. **At Risk Leads** - Leads that are at risk of being lost.
	3. **Upcoming follow up of months.** - Prepare your month by tracking upcoming scheduled calls.
6. Option to Add POC while adding a lead and schedule call with the lead.
7. Once call is scheduled the lead will automatically moves to **In Progress** state.
8. If there is any missed call and no activity on lead for PAST 10 DAYS the lead will show as **AT RISK**.
9. Schedule call with any POC with flexibility.
	1. Schedule **Single call if required**
	2. Schedule **Call frequency** with options like **Daily, Weekly and Monthly**
10. Comprehensive **CALL STATES** with options like
	1.  **Rescheduling feature** - Moves the current call to reschedule state and schedule another call on desired date.
	2. **Completed** - To ensure call purpose is completed.
	3. **Waiting** - In case of lead is busy for a call.
	4. **Answered** - If LEAD is requiring some information same day.
	5. **UnAnswered** - If Lead didn't picked the phone and not sure what needs to be done for the next call
	6. **Cancelled** - If required to cancel the scheduled call.
11. List all calls logs at single location with **FILTERING OPTION**

# Code features
1. Backend on .NET 8 with flexibility of hosting.
2. Angular frontend to enhanced user experience.
3. Use of Entity framework as **ORM** with custom written **Stored procedures** to fetch required data as per will.
4. Separation of concern for all controllers with **RESTFUL** architecture.
5. Modular code with **MODEL** layer **Service** layer and **Repository** layer to accommodate upcoming changes with ease.
6. **Request and Response** Contracts for easy data binding.

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
   cd KAMLMSBackend/KAMLMSBackend
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

## For more details please visit backend project for detailed API request and response body info.

---