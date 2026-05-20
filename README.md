# Lottery Number Generator

This project generates random lottery numbers for different games: **Loto**, **PoolLoto**, **SuperKino**, **MegaMillions**, and **PowerBall**.

## Current Features
- Interactive game selection from console.
- Generation of one or multiple lottery lists.
- Optional comparison against simulated winning numbers.
- Save generated numbers in a `.txt` file.
- Input validation for common invalid values.

## Refactoring Improvements Applied
- Extracted reusable helpers in `Program.cs` for parsing, Yes/No prompts, and number formatting.
- Centralized game-option map/prompt creation in `GameTypeExtensions` to avoid duplicated hardcoded option text.
- Added defensive validation in `GameSettings` (`Validate`) to prevent invalid game configurations.
- Made `LotoList` immutable from outside (`IReadOnlyList<int>` + get-only properties).
- Improved `LotoTest`:
  - supports optional `Random` injection for easier testing;
  - clears previous generated lists on each generation run to avoid accidental accumulation;
  - validates number of requested lists;
  - returns sorted matched numbers for deterministic output.

## Suggested Web Interface (next step)
A clean migration path is to build an **ASP.NET Core MVC** or **Blazor Server** web app with:

1. **Game selector panel**
   - Dropdown for game type.
   - Numeric input for number of lists.
   - Toggle to compare with winning numbers.

2. **Results table/card grid**
   - One card per generated list.
   - Styled number chips (`01`, `02`, etc.).
   - Match summary badges (e.g., `3 matches`).

3. **Persistence/export actions**
   - “Download TXT” button.
   - Optional “Save history” in SQLite (date, game, numbers).

4. **Architecture recommendation**
   - Move `LotoTest` logic into an application service (`LotteryService`).
   - Keep UI thin: controller/component only orchestrates request + response.
   - Add unit tests for service behavior (number ranges, count, deduplication).

## Build
```bash
dotnet build
```
