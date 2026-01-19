# LicenseGuard API MVP

Author: Lucas Emmanuel Rodrigues Firmino de Paula
Date: 01/19/2026 <br>
Summary: Document describing the minimum viable scope (MVP) for the LicenseGuard licensing API.

## MVP Checklist

[ ] What is a license in LicenseGuard? <br>
[ ] What is not included in the MVP? <br>
[ ] Essential use cases <br>
[ ] Minimum business rules

## What is a license in LicenseGuard?
A license in LicenseGuard is a technical authorization that allows client software to run under certain conditions.

In the MVP, a license:
- has a unique license key
- can be active, expired, or revoked
- can have an expiration date
- can be associated with one or more devices
- is validated exclusively by the LicenseGuard API backend
- A device is represented by an identifier provided by the client software.
- A license key identifies a single license.

### "The license does not represent payment, commercial plan, or end user."

## What is not included in the MVP?
In the MVP, the following are not part of the scope:
- Payment systems
- Subscriptions or plans
- Automatic renewal
- Trial controlled by usage time
- Multi-tenant (companies / organizations)
- Webhooks
- Administrative dashboard
- Advanced permission control
- Human user limitation
- Advanced hardware fingerprint

- Sophisticated rate limiting

### "The MVP's goal is to validate the core of the licensing system, not a complete SaaS product."

---
## Essential use cases
## 1. Create a license
- Generates a secure license key
- Defines initial status
- Can define expiration date

## 2. Validate a license
Receives:
- license key
- device identifier

Returns:
- valid or invalid
- reason for invalidation (expired, revoked, unauthorized device)

## 3. Associate device to license
- Optionally limited to N devices
- First use can register the device

## 4. Revoke a license
- Revoked license can no longer be validated
- Revocation is permanent

## 5. Query basic license information
- Status
- Expiration
- Number of associated devices

## Minimum business rules (Domain Rules)
- A license key must be unique and unpredictable.
- A revoked license never becomes valid again.
- An expired license cannot be validated.
- An unauthorized device invalidates the validation.
- A license can have zero or more associated devices.
- License validation does not depend on client state.
- Every validity decision must be deterministic.