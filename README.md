# MoveX

A personal productivity dashboard, built with WPF and C#.
I started this project because it seemed like a good way to teach myself Vertical Slice Architecture, EF Core, and dependency injection along the way.

## What it does

MoveX combines several productivity tools into one app:

- Habits — track daily/recurring habits
- Finance — manage transactions, categories, and balances
- Goals — set and complete goals
- Journal — write journal entries
- Study Tracker — log study sessions and total time studied
- Time Tracker — track time entries
- Tasks — manage todo items

## Status

Core features implemented across all modules
UI is currently being implemented.

## Running
cd MoveX.WPF

dotnet run

## Requirements

- .NET SDK (8.0 or newer)

## Sidenotes

- Architecture: Vertical Slice Architecture across four projects (`MoveX.Domain`, `MoveX.Database`, `MoveX.Features`, `MoveX.WPF`)
- Uses EF Core with SQLite for persistence
- Dependency injection across all modules
