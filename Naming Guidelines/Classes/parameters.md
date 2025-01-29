# Nomenclatura paràmetres

✅ Els paràmetres han de seguir la nomenclatura **camelCasing** 

**Example:**
```csharp
public void SetUserName(string userName) { }
public int CalculateTotal(int itemCount, double pricePerItem) { }
```

✅ Han de decriure el seu propòsit i què representen

**Example:**
```csharp
// CORRECTE
public void SendEmail(string recipientEmail, string subject, string messageBody) { }

// INCORRECTE
public void SendEmail(string email, string sub, string msg) { }
```

✔️ El nom el paràmetre ha d'estar relacionat amb el seu propòsit, no amb el seu tipus.

**Example:**
```csharp
// CORRECTE

public void ProcessPayment(decimal amount, string currencyCode) { }

// INCORRECTE
public void ProcessPayment(decimal d, string s) { }
```
