# License Validation Flow

This document describes the main license validation flow of the LicenseGuard API.
It represents the core business logic responsible for authorizing or denying
software usage based on license rules.

---

## Context

A client application (desktop app, service, or tool) sends a request to the
LicenseGuard API to check whether it is authorized to operate.

This validation must be:
- Fast
- Secure
- Deterministic
- Auditable

---

## Entry Point

**Endpoint:**
POST /api/licenses/validate

**Input:**
- licenseKey
- machineHash
- applicationVersion

---

## Validation Steps

### 1. Receive Validation Request
The API receives a validation request from a client application containing
the license key and machine identifier.

---

### 2. License Lookup
The system searches for a license matching the provided license key.

- If the license does not exist → validation fails.

---

### 3. License Status Validation
The system verifies the current license status.

- If the license is revoked or inactive → validation fails.

---

### 4. Expiration Validation
The system checks whether the license has expired.

- If the expiration date is in the past → validation fails.

---

### 5. Device Validation
The system checks whether the machine is already registered under the license.

- If the device is already registered → continue.
- If the device is not registered:
  - Check if the license has available device slots.
  - If no slots are available → validation fails.
  - If slots are available → register the device.

---

### 6. Usage Registration
The system records the validation attempt for auditing and monitoring purposes.

This includes:
- License identifier
- Device identifier
- Timestamp
- Validation result

---

### 7. Validation Response
The API returns a response indicating whether the license is authorized.

If authorized, the response may include:
- License expiration date
- Enabled features
- Temporary validation token (optional)

---

## Failure Scenarios

Validation can fail due to:
- Invalid license key
- Revoked or inactive license
- Expired license
- Device limit exceeded

Each failure must return a clear and consistent response.

---

## Notes

- Controllers must not contain business rules.
- All validation rules must be handled by the domain/service layer.
- This flow represents the core logic of the system and should remain stable.
