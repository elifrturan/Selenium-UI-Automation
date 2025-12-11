# 🧪 Selenium UI Automation Tests – Oral & Dental Health Tracking System

This repository contains a full set of **end-to-end UI automation tests** developed with **Selenium WebDriver (C#)** for the **Oral and Dental Health Tracking System**, created during my long-term internship.

The aim of this test suite is to ensure **reliability, functional accuracy, and UI consistency** across all major user flows of the system.

---

## 🚀 Test Scope & Coverage

### 🔐 Authentication
- ✔ Login with valid credentials  
- ✔ Failed login redirection checks  
- ✔ Register with unique email generation  
- ✔ Forgot password (email verification)  
- ✔ Password reset flow  

---

### 🏠 Home Page
- ✔ Welcome user greeting check  
- ✔ “Last 7 days” tracking table validation  
- ✔ Daily recommendation visibility test  

---

### 👤 Profile Page
- ✔ User info load verification (email, full name, birthdate)  
- ✔ Profile update scenario (name update + success alert)  
- ✔ Navigation & URL validation  

---

### 📊 Health / Situation Page
- ✔ Records table visibility  
- ✔ Goal selection dropdown  
- ✔ Creating a new health record  
- ✔ Form field validations (date, time, duration, checkbox)  
- ✔ Recommendation component visibility  

---

### 🎯 Goal Management
- ✔ Goal creation (title, description, period, priority)  
- ✔ Period unit selection (“Günde”)  
- ✔ Validation of newly added goal in the table  

---

## 🛠 Technologies & Tools
- **C# / .NET**
- **Selenium WebDriver**
- **ChromeDriver**
- **NUnit / MSTest–compatible**
- **Explicit waits (WebDriverWait)**
- **Modular and isolated test classes**
- **Local environment test execution**
- **Integration with Business Layer for recommendations**
- **Redis-based caching within the main system**

---

## 📁 Project Structure

TestUI/
|
+-- Tests/
|   +-- LoginTest.cs
|   +-- RegisterTest.cs
|   +-- CheckEmailTest.cs
|   +-- ResetPasswordTest.cs
|   +-- HomePageTest.cs
|   +-- ProfilePageTest.cs
|   +-- GoalTest.cs
|   +-- SituationTest.cs
|
+-- Program.cs
+-- TestUI.sln
+-- .gitignore
+-- README.md

---

## 📌 Notes
- All UI tests run on **ChromeDriver**.  
- Tests include both **Thread.Sleep** and **WebDriverWait** (explicit waits).  
- Registration tests use **dynamic email generation** to avoid duplication errors.  
- This test suite was actively used during my internship to validate UI behavior.

---

## ▶️ Running the Tests
You can run tests manually via the `Program.cs` entry point or integrate into a test runner of your choice.
