# TradeNet Portal - WebAPI Testing Controllers

This folder contains separate WebAPI controllers designed for testing purposes in Postman. These controllers are completely isolated from the main Razor Pages application and can be safely deleted without affecting the project.

## Features

- **Separate API Endpoints**: All API endpoints are prefixed with `/api/` (e.g., `/api/compliance`, `/api/license`)
- **RESTful Design**: Uses proper HTTP methods (GET, POST, PUT, DELETE)
- **JSON Responses**: Returns JSON responses with appropriate status codes
- **Error Handling**: Includes proper error messages and HTTP status codes
- **Deletable**: This entire folder can be deleted without any impact on the main project

## Available API Controllers

1. **ComplianceApiController** - `/api/compliance`
   - GET /api/compliance - Get all compliance records
   - GET /api/compliance/{id} - Get compliance record by ID
   - POST /api/compliance - Create new compliance record
   - PUT /api/compliance/{id} - Update compliance record
   - DELETE /api/compliance/{id} - Delete compliance record
   - POST /api/compliance/{id}/passed - Mark as passed
   - POST /api/compliance/{id}/failed - Mark as failed

2. **LicenseApiController** - `/api/license`
   - GET /api/license - Get all licenses
   - GET /api/license/{id} - Get license by ID
   - POST /api/license - Create new license
   - PUT /api/license/{id} - Update license
   - DELETE /api/license/{id} - Delete license

3. **TransactionApiController** - `/api/transaction`
   - GET /api/transaction - Get all transactions
   - GET /api/transaction/{id} - Get transaction by ID
   - POST /api/transaction - Create new transaction
   - PUT /api/transaction/{id} - Update transaction
   - DELETE /api/transaction/{id} - Delete transaction

4. **MarketRecordApiController** - `/api/marketrecord`
   - GET /api/marketrecord - Get all market records
   - GET /api/marketrecord/{id} - Get market record by ID
   - POST /api/marketrecord - Create new market record
   - PUT /api/marketrecord/{id} - Update market record
   - DELETE /api/marketrecord/{id} - Delete market record

5. **DocumentApiController** - `/api/document`
   - GET /api/document - Get all documents
   - GET /api/document/{id} - Get document by ID
   - POST /api/document - Create new document
   - PUT /api/document/{id} - Update document
   - DELETE /api/document/{id} - Delete document

## Testing with Postman

### Base URL
```
https://localhost:5001/api
```

### Example Requests

**Get all compliance records:**
```
GET https://localhost:5001/api/compliance
```

**Create a new compliance record:**
```
POST https://localhost:5001/api/compliance
Content-Type: application/json

{
  "id": 0,
  "inspectionDate": "2025-01-15",
  "complianceArea": "Safety",
  "result": "Pending",
  "inspectedBy": "",
  "remarks": ""
}
```

**Update a compliance record:**
```
PUT https://localhost:5001/api/compliance/1
Content-Type: application/json

{
  "id": 1,
  "inspectionDate": "2025-01-15",
  "complianceArea": "Safety",
  "result": "Passed",
  "inspectedBy": "John Doe",
  "remarks": "Passed inspection"
}
```

**Delete a compliance record:**
```
DELETE https://localhost:5001/api/compliance/1
```

## How to Delete This API

To remove the API testing functionality without affecting your main project:

1. **Delete the entire `Api` folder** from your project
2. The main Razor Pages application will continue to work normally
3. All MVC controllers and Razor Pages remain unaffected

No other files need to be modified when deleting this folder.

## Important Notes

- The API uses the same services as the main application (IComplianceService, ILicenseService, etc.)
- All changes made through the API affect the same database as the main application
- The API is automatically registered in the dependency injection container through `AddControllersWithViews()` in Program.cs
