# Editora Inovação - MVC Helpers

The Nuget package with some MVC (.NET Framework) helpers

[![wakatime](https://wakatime.com/badge/github/InovacaoMediaBrasil/EditoraInovacao.MVC.svg)](https://wakatime.com/badge/github/InovacaoMediaBrasil/EditoraInovacao.MVC)
[![GitHub license](https://img.shields.io/github/license/InovacaoMediaBrasil/EditoraInovacao.MVC)](https://github.com/InovacaoMediaBrasil/EditoraInovacao.MVC)
[![GitHub last commit](https://img.shields.io/github/last-commit/InovacaoMediaBrasil/EditoraInovacao.MVC/main)](https://github.com/InovacaoMediaBrasil/EditoraInovacao.MVC)
[![Build](https://github.com/InovacaoMediaBrasil/EditoraInovacao.MVC/actions/workflows/build.yml/badge.svg)](https://github.com/InovacaoMediaBrasil/EditoraInovacao.MVC/actions/workflows/build.yml)
[![Deploy](https://github.com/InovacaoMediaBrasil/EditoraInovacao.MVC/actions/workflows/deploy.yml/badge.svg)](https://github.com/InovacaoMediaBrasil/EditoraInovacao.MVC/actions/workflows/deploy.yml)
[![Linter check](https://github.com/InovacaoMediaBrasil/EditoraInovacao.MVC/actions/workflows/linter.yml/badge.svg)](https://github.com/InovacaoMediaBrasil/EditoraInovacao.MVC/actions/workflows/linter.yml)
[![Update packages](https://github.com/InovacaoMediaBrasil/EditoraInovacao.MVC/actions/workflows/update-packages.yml/badge.svg)](https://github.com/InovacaoMediaBrasil/EditoraInovacao.MVC/actions/workflows/update-packages.yml)

![logo.png](logo.png)

.NET Framework MVC Helpers library

---

## NuGet - Package Manager for .NET

[![EditoraInovacao.MVC NuGet Version](https://img.shields.io/nuget/v/EditoraInovacao.MVC.svg?style=flat)](https://www.nuget.org/packages/EditoraInovacao.MVC/)
[![EditoraInovacao.MVC NuGet Downloads](https://img.shields.io/nuget/dt/EditoraInovacao.MVC.svg?style=flat)](https://www.nuget.org/packages/EditoraInovacao.MVC/)

```bash

dotnet add package EditoraInovacao.MVC

```

---

## Features

- Controller
- EmptyController
- EnumFlagsModelBinder
- ExtendedSelectListItem
- NewtonsoftJsonResult
- ViewRenderer

### Controller

A base controller that adds two results:

- JsonResult - Generates a [NewtonsoftJsonResult](#NewtonsoftJsonResult) result.
- ErrorResponse - Generates a JsonResult with ErrorResponse type, including custom code, custom error message and any ModelState errors key/message pair.

### EmptyController

An empty controller class that derives from [Controller](#Controller).

### EnumFlagsModelBinder

Adds a model binder that enables binding of a flag enum in the model, allowing multiple flag selection.

### ExtendedSelectListItem

A class that extends the System.Web.Mvc.SelectListItem with a new property named HtmlAttributes that can be used with ViewHelpers to send custom HTML properties/attributes from Model to View.

### NewtonsoftJsonResult

Extends JsonResult with custom JSON serialization settings. 

- Formatting.Indented
- ReferenceLoopHandling.Ignore

### ViewRenderer

A helper class that enables view rendering on demand.
Expose the following 3 methods:

- CreateController - Creates an instance of a Controller (can be any valid controller)
- RenderView - Renders a view based on the view's name and an object as the model for that view. It uses the [EmptyController](#EmptyController) as the controller.
- RenderView - Extension method for a Controller class, that renders a view based on the view's name and an object as the model for that view.
 
---

Developed by [Guilherme Branco Stracini](https://www.guilhermebranco.com.br) for [Editora Inovação](https://www.editorainovacao.com.br) 

© 2012 ~ 2023 All rights reserved.

---
