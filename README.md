<div align="center">

# 🏫 school.net
### Moderne, sichere und skalierbare Schulplattform

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-Web_API-512BD4?style=flat&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![React](https://img.shields.io/badge/React-SPA-61DAFB?style=flat&logo=react&logoColor=black)](https://react.dev/)
[![MAUI](https://img.shields.io/badge/.NET_MAUI-Cross-Platform-512BD4?style=flat&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![PostgreSQL](https://img.shields.io/badge/PostgreSQL-Database-4169E1?style=flat&logo=postgresql&logoColor=white)](https://www.postgresql.org/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

</div>

---

## 📖 Über das Projekt
**school.net** ist eine moderne, cloudbasierte Web- und Mobilanwendung zur Verwaltung von Schulprozessen (elektronisches Klassenbuch, Stundenplan, Notenverwaltung und Anwesenheitskontrolle). Das Projekt wurde entwickelt, um eine performante, sichere und plattformübergreifende Architektur zu demonstrieren.

---

## 🏛️ Architektur & Technologie-Stack

Das Backend basiert strikt auf den Prinzipien der **Clean Architecture**, was eine hohe Testbarkeit, lose Kopplung und Wartbarkeit des Codes gewährleistet.

* **Backend:** ASP.NET Core Web API (.NET 8), Entity Framework Core, LINQ, SignalR (WebSockets).
* **Datenbank:** PostgreSQL (gehostet in der Azure Cloud), Migrations-Management via EF Core.
* **Web-Client (SPA):** React + TypeScript (Minimalistisches Monochrom-Design mit orangen Akzenten).
* **Mobile App:** .NET MAUI (für Android & iOS mit lokalem SQLite-Cache für den Offline-Modus).
* **Sicherheit & Logging:** JWT-Authentifizierung, RBAC (Role-Based Access Control), Serilog (strukturiertes Logging), Global Exception Handling.

---

## 🚀 Enterprise Features

* **Real-Time Updates (SignalR):** Sofortige Benachrichtigungen und Aktualisierung von Noten sowie Stundenplänen ohne Neuodenung der Seite.
* **Erweiterte Abfrageoptimierung:** Universelle Pagination, serverseitige Filterung und Sortierung (`PagedResponse<T>`).
* **Datenschutz & Audit:** Implementierung von *Soft Delete* (logisches Löschen statt physischem) und automatisiertem *Audit Logging* für kritische Änderungen.
* **Rollenbasiertes System:** Trennung der Zugriffsrechte für Administratoren, Lehrkräfte und Schüler.

---

## 🗂️ Datenbankstruktur (ER-Modell)

Das System umfasst folgende Hauptentitäten:
* **Classes & Users:** Benutzerverwaltung mit strikter Rollentrennung und Klassenzugehörigkeit.
* **Class_Subject:** M:N-Beziehung zur Trennung von Lehrplänen und physischem Stundenplan.
* **Schedule & Homework:** Fächerübergreifende Stundenpläne und digitale Hausaufgaben mit Fälligkeitsdatum.
* **Grades & Abwesenheit:** Notenverwaltung (inkl. Noten Tendenzen) und detaillierte Fehlzeiten-Erfassung (*Entschuldigt / Unentschuldigt*).

---

## 🛠️ Lokale Entwicklung & Setup

1. **Repository klonen:**
   ```bash
   git clone [https://github.com/your-username/school.net.git](https://github.com/your-username/school.net.git)
   cd school.net
