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
```
#### Response Body
```json
userguid
```

### Sign Up

**POST** `/api/auth/signup`

Register a new manager.

#### Request Body

```json
{
  "email": "string",
  "password": "string"
}
```
#### Response Body
```json
{
  "name": "string",
  "email": "string",
  "position": "string",
  "token": "string"
}
```
---
## Calls Management

### Schedule Call

**POST** `/api/calls`

Schedule a call

#### Request Body

```json
{
  "companyId": "string",
  "pocId": "string",
  "time": "string",
  "comment": "string"
}
```
#### Response Body
```json
200 OK
```
### Update Call

**PATCH** `/api/calls`

Update a call

#### Request Body

```json
{
  "callId": "string",
  "statusId": "string",
  "comment": "string",
  "reScheduleDate": "string"
}
```
#### Response Body
```json
200 OK
```
### GET CALLS BY COMPANY ID

**PATCH** `/api/calls/{companyId}`

Get calls schedules for particular lead
#### Response Body
```json
[
  {
    "callScheduleId": 0,
    "scheduledWithName": "string",
    "scheduledWithPhone": "string",
    "callerName": "string",
    "scheduledAt": "2024-12-30T17:35:35.752Z",
    "comment": "string",
    "callStatusId": 0,
    "callStatusName": "string"
  }
]
```
---
## Dashboard

### Get Dashboard data

**GET** `/api/dashboard

GET data for the dashboard

#### Response Body
```json
{
  "data": [
    {
      "id": 0,
      "status": "string",
      "leads": [
        {
          "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          "companyName": "string",
          "enterpriseName": "string",
          "assignedTo": "string",
          "status": "string",
          "statusId": 0
        }
      ]
    }
  ]
}
```
### Dashboard details by followups

**GET** `/api/dashboard/by-followups`

Get dashboard data for followups section

#### Params
```json
day:string
month:string
year:string
page:number
take: number
```
#### Response Body
```json
[
  {
    "id": 0,
    "companyId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "name": "string",
    "followupDate": "string"
  }
]
```
### Dashboard details by risk
**GET** `/api/dashboard/by-risk`

Get dashboard data for risk section

#### Params
```json
page:number
take: number
```
#### Response Body
```json
[
  {
    "id": 0,
    "companyId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "name": "string",
    "followupDate": "string"
  }
]
```
---
## Lead Management

### Add Lead

**POST** `/api/leads`

Add a lead

#### Request Body

```json
{
  "parentEnterpriseName": "string",
  "companyName": "string",
  "companyEmail": "string",
  "companyAddress": "string",
  "country": "string",
  "timeZone": "string",
  "workingHourStart": "string",
  "workingHourEnd": "string",
  "comment": "string"
}
```
#### Response Body
```json
200 OK with GUID
```
### Update LEAD

**PATCH** `/api/leads`

UPDATE a lead

#### Request Body

```json
{
  "id": "string",
  "status": "string",
  "comment": "string"
}
```
#### Response Body
```json
200 OK
```
### GET LEAD

**GET** `/api/leads/{leadId}`

GET lead by LEAD GUID
#### Response Body
```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "parentEnterpriseName": "string",
  "companyName": "string",
  "companyEmail": "string",
  "companyAddress": "string",
  "country": "string",
  "timeZone": "string",
  "workingHourStart": "string",
  "workingHourEnd": "string",
  "comment": "string",
  "addedById": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "assignedToId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "status": {
    "id": 0,
    "status": "string"
  },
  "statusId": 0,
  "createdAt": "2024-12-30T17:45:15.587Z",
  "modifiedAt": "2024-12-30T17:45:15.587Z"
}
```
### GET LEAD by type

**GET** `/api/leads/{leadType}`

GET lead by LEAD type and page
#### Response Body
```json
[
  {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "companyName": "string",
    "enterpriseName": "string",
    "assignedTo": "string",
    "status": "string",
    "statusId": 0
  }
]
```
---
## Point of contact
### Point of contacts add
**POST** `/api/point-of-contact`

Add POC 

#### Request Body
```json
{
  "companyId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "name": "string",
  "phone": "string",
  "email": "string",
  "roleId": 0,
  "customRole": "string",
  "isMainPOC": true,
  "time": "string"

```
#### Response Body
```json
200 OK
```
### Point of contact get

**GET** `/api/point-of-contact/{companyId}`

Get poc for companyid

#### Response Body
```json
[
  {
    "id": "string",
    "leadsEntity": "null or object",
    "leadsId": "string",
    "name": "string",
    "phone": "string",
    "email": "string",
    "role": {
      "id": "integer",
      "name": "string"
    },
    "roleId": "integer",
    "customRoleId": "integer",
    "customRole": {
      "id": "integer",
      "name": "string"
    },
    "createdAt": "string (ISO 8601 date-time)",
    "updatedAt": "string (ISO 8601 date-time)",
    "addedById": "string",
    "managersEntity": "null or object"
  }
]

```