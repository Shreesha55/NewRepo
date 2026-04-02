# TradeNet Portal - WebAPI Setup & Usage Guide

## Overview

Your TradeNet Portal project now has a complete **isolated WebAPI layer** for testing in Postman. This API is completely separate from your Razor Pages application and can be deleted at any time without affecting your main project.

## What's Included

### API Controllers (in `Api/Controllers/`)
- **ComplianceApiController** - Manage compliance records
- **LicenseApiController** - Manage trade licenses
- **TransactionApiController** - Manage transactions
- **MarketRecordApiController** - Manage market records
- **DocumentApiController** - Manage documents

### Supporting Files
- **README.md** - Detailed API documentation
- **Postman_Collection.json** - Ready-to-import Postman collection
- **SETUP_GUIDE.md** - This file

## Quick Start

### 1. Start Your Application
```bash
dotnet run
```

The application will be available at `https://localhost:5001`

### 2. Import Postman Collection
1. Open **Postman**
2. Click **Import** button
3. Navigate to `TradenetProject/Api/Postman_Collection.json`
4. Click **Open**

### 3. Test the APIs
The Postman collection includes pre-configured requests for all endpoints:
- **Compliance**: `/api/compliance`
- **License**: `/api/license`
- **Transaction**: `/api/transaction`
- **Market Record**: `/api/marketrecord`
- **Document**: `/api/document`

## API Endpoints

### Standard CRUD Operations (All Controllers)

```
GET    /api/{resource}              - Get all records
GET    /api/{resource}/{id}         - Get specific record
POST   /api/{resource}              - Create new record
PUT    /api/{resource}/{id}         - Update record
DELETE /api/{resource}/{id}         - Delete record
```

### Special Compliance Endpoints

```
POST   /api/compliance/{id}/passed  - Mark compliance as passed
POST   /api/compliance/{id}/failed  - Mark compliance as failed
```

## Response Format

All API responses follow REST conventions with appropriate HTTP status codes:

### Success (200-201)
```json
{
  "id": 1,
  "businessName": "ABC Trading",
  "status": "Active"
}
```

### Not Found (404)
```json
{
  "message": "Resource not found"
}
```

### Error (500)
```json
{
  "message": "An error occurred while processing your request"
}
```

## Key Features

✅ **Completely Isolated** - API code is in a separate `Api` folder  
✅ **No Conflicts** - Uses same services as main application, but in separate namespace  
✅ **Easy to Delete** - Delete the entire `Api` folder without any side effects  
✅ **Shared Data** - API and Razor Pages both access the same database  
✅ **RESTful Design** - Follows REST conventions with proper HTTP methods  
✅ **JSON Responses** - All responses are JSON formatted  
✅ **Proper Error Handling** - Includes validation and error messages  

## Data Sharing

The API and Razor Pages share the same:
- ✓ Database (AppDbContext)
- ✓ Services (IComplianceService, ILicenseService, etc.)
- ✓ Repositories (IComplianceRepository, ILicenseRepository, etc.)
- ✓ Models (ComplianceRecord, TradeLicense, etc.)

**Important**: Changes made through either the API or Razor Pages will be visible in both interfaces, since they use the same database.

## Example Usage in Postman

### Create a Compliance Record
```
POST https://localhost:5001/api/compliance
Content-Type: application/json

{
  "businessName": "ABC Trading",
  "inspectionType": "Safety",
  "inspectedDate": "2025-01-15"
}
```

**Response (201 Created)**:
```json
{
  "complianceID": 1,
  "businessName": "ABC Trading",
  "inspectionType": "Safety",
  "inspectedDate": "2025-01-15",
  "inspectedBy": "",
  "remarks": "",
  "result": "Pending"
}
```

### Get All Compliance Records
```
GET https://localhost:5001/api/compliance
```

**Response (200 OK)**:
```json
[
  {
    "complianceID": 1,
    "businessName": "ABC Trading",
    "inspectionType": "Safety",
    "inspectedDate": "2025-01-15",
    "inspectedBy": "",
    "remarks": "",
    "result": "Pending"
  }
]
```

### Update Compliance Record
```
PUT https://localhost:5001/api/compliance/1
Content-Type: application/json

{
  "businessName": "ABC Trading",
  "inspectionType": "Safety",
  "inspectedDate": "2025-01-15",
  "inspectedBy": "John Doe",
  "remarks": "Passed inspection",
  "result": "Passed"
}
```

### Mark Compliance as Passed
```
POST https://localhost:5001/api/compliance/1/passed
```

### Delete Compliance Record
```
DELETE https://localhost:5001/api/compliance/1
```

## Deleting the API

When you're done testing or want to remove the API:

### Option 1: Delete the Folder
1. In Solution Explorer, right-click the `Api` folder
2. Select **Delete**
3. Confirm the deletion

### Option 2: Using Command Line
```bash
rmdir /s "TradenetProject\Api"
```

### Result
✓ Main Razor Pages application continues to work normally  
✓ All existing functionality is unaffected  
✓ No project configuration changes needed  

## Troubleshooting

### SSL Certificate Error
If you get an SSL certificate error, add this to the Postman request **Headers**:
```
key: Disable-SSL-Verification
value: true
```

Or disable SSL verification in Postman settings.

### Port Mismatch
If the port is different from 5001:
1. Check the output when running `dotnet run`
2. Update the Postman collection base URL accordingly

### Model Property Names
The models use specific ID property names:
- ComplianceRecord → `ComplianceID`
- TradeLicense → `LicenseID`
- Transaction → `TransactionID`
- MarketRecord → `RecordID`
- Document → `DocumentID`

Always use these names in your requests.

## Summary

- 📁 **Location**: `TradenetProject/Api/`
- 🎯 **Purpose**: Isolated API testing without affecting main application
- 🗑️ **Deletion**: Simply delete the `Api` folder - nothing else needs to be changed
- 🔄 **Shared Data**: All changes sync between API and Razor Pages
- 📮 **Postman**: Import `Postman_Collection.json` for ready-to-use requests

Happy testing! 🚀
