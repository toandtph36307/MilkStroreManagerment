# Contributing Guidelines

## Overview
This repository adopts a strict three-layer architecture for new features: Presentation, Service (Business), and Repository (Data). All new code for a feature should be organized beneath `FunctionForms.{Feature}` using the namespaces described below.

## Layers and Namespaces
- Presentation (UI): `QLPhongTro.FunctionForms.{Feature}.View`
  - Windows Forms and UserControls only.
  - UI code must contain no direct SQL — use services.

- Service / Business: `QLPhongTro.FunctionForms.{Feature}.Services`
  - Contains business rules, validation and orchestration logic.
  - Should depend on repository interfaces, not concrete implementations.

- Repository / Data Access: `QLPhongTro.FunctionForms.{Feature}._Repositories`
  - Responsible for database access and mapping to models.
  - Use parameterized queries or stored procedures.

- Models: `QLPhongTro.FunctionForms.{Feature}.Models`
  - DTOs and domain models used across layers.

## Connection string
Library code should obtain the connection string from `System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"]`. If not present, code may fall back to the legacy hard-coded connection string used in the project:
```
Data Source=DANGTHETOAN\TOANDT11;Initial Catalog=MilkStoreManagement;Integrated Security=True
```

## Coding rules
- Use PascalCase for class and property names.
- Keep methods small and single-responsibility.
- All SQL must be parameterized to prevent SQL injection.
- Repository methods return models or collections; service methods return simple types or models and perform validation.

## Example structure for `CustomerGroups` feature
- `FunctionForms.CustomerForm.Models.CategoryModel.cs`
- `FunctionForms.CustomerForm._Repositories.CategoryRepository.cs`
- `FunctionForms.CustomerForm.Services.CategoryService.cs`
- `FunctionForms.CustomerForm.View.CustomerGroups.cs`

## Pull Request checklist
- Code builds and runs.
- No direct SQL in UI code.
- Unit tests for service logic where applicable.

Thank you for contributing.