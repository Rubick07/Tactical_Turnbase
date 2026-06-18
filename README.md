<p align="center">
  <img width="100%" alt="Turnbase" src="https://github.com/user-attachments/assets/5b50cca5-229e-42c8-879e-ce176838ab33">
  </br>
</p>

## Developer & Contributions
**Evan Jonathan** (Game Programmer) <br>

## About
This project focused on recreating the core mechanics of tactical RPG games such as XCOM.
The project features grid-based movement, turn-based combat, and action execution systems built on top of Tilebase system.
It was primarily developed to study and implement the Command Pattern, allowing combat actions to be executed, queued, and managed in a clean 
and scalable way.
<br>

<br>

## Key Features

• Command Pattern Implementation <br>
• Grid-Based Movement <br>
• Tilemap Combat System <br>
• Turn Management <br>
• Action Point System <br>
• Tactical Target Selection <br>
• Enemy Decision Making <br>


<table>
<tr>
<td align="center" width="50%">
<strong>Tile-based Combat System</strong><br>
<img width="100%" alt="Tactical" src="https://github.com/user-attachments/assets/4194228d-5b9c-4dd2-a70f-52a3106782b5">
</td>
</tr>
</table>


## Scene Flow
```mermaid
flowchart LR
  ss[Sample Scene]
```

## Layer / Module Design
```mermaid
---
config:
  theme: neutral
  look: neo
---
graph TD
    subgraph "Core Systems"
        IM[InputManager]
        Ts[Turn System]
        
    end
    
    subgraph "Player Systems"
        UAS[Unit Action System]
        CC[Camera Controller]
    end
    
    subgraph "Unit System"
        U[Unit]
        UM[Unit Manager]
        HS[Health System]
        BA[Base Action]
    end
    
    subgraph "Tile-based Systems"
        GS[Grid System]
        LG[LevelGrid]
        GSV[Grid System Visual]
    end

    subgraph "Enemy Systems"
        EA[Enemy AI]
    end

    subgraph "UI Systems"
        UnitActionSystemUI[Unit Action SystemUI]
        TurnSystemUI[Turn System UI]
        ActionBusyUI[Action Busy UI]
        HealthSystemUI[HealthSystemUI]
    end

    IM --> UAS
    IM --> CC

    Ts --> TurnSystemUI
    UAS --> UnitActionSystemUI
    UAS --> U
    U --> UM
    U --> HS
    U --> BA
    U --> UnitActionSystemUI

    BA --> ActionBusyUI
    HS --> HealthSystemUI

    GS --> LG
    LG --> GSV

    EA --> U
    
    
    
    classDef coreStyle fill:#e1f5fe,stroke:#01579b,stroke-width:2px
    classDef playerStyle fill:#e8f5e8,stroke:#1b5e20,stroke-width:2px
    classDef enemyStyle fill:#ffebee,stroke:#b71c1c,stroke-width:2px
    classDef unitStyle fill:#fff3e0,stroke:#e65100,stroke-width:2px
    classDef uiStyle fill:#f3e5f5,stroke:#4a148c,stroke-width:2px
    
    class IM,Ts coreStyle
    class UAS,CC playerStyle
    class EAI enemyStyle
    class U,UM,HS unitStyle
    class UnitActionSystemUI,TurnSystemUI,ActionBusyUI uiStyle

```

## Modules and Features

The 3D Tactical turn-based Combat gameplay with Xcom-inspired GridSystem,TurnSystem, EnemyAI, and HealthSystem is powered by an extensive Unity C# scripting system.

|  📂 Name     | 🎬 Scene |  📋 Responsibility                                                 |
| ------------------- |----------------| ------------------------------------------------------------ |
| `LevelGrid` | Samplescene |Manages the tile-based grid for the level|
| `GridSystem` | Samplescene |Manages the tile-based grid system|
| `TurnSystem` | Samplescene |Manages turn order and turn progression|
|  `UnitManager.cs` | Samplescene | Manages all units on the battlefield|
| `BaseAction.cs`  | Samplescene |Abstract base class for all unit actions |
| `Unit.cs`  | Samplescene |Stores unit data and handles combat actions |
| `UnitAnimator.cs`| Samplescene | Handles unit animations and visual effects|
| `UnitActionSystem.cs`| Samplescene | Manages player input and unit actions during battle. |
| `CameraManager.cs`| Samplescene | Manages camera movement and positioning |
| `InputManager.cs`| Samplescene | Handles player input. |
| `EnemyAI.cs`| Samplescene | Manages enemy AI behavior during combat. |

<br>

## Game Flow Chart
```mermaid
---
config:
  theme: redux
  look: neo
---
flowchart TD
  start([Battle Start])
  start --> TurnSystemCheck{Check Is Player Turn}

  TurnSystemCheck -->|Yes| move{Player Input}
  TurnSystemCheck -->|No| EnemyAI[EnemyAI]

  
  move -->|Left Mouse Button| SU[Select Unit]
  move -->|Click End Turn Button| EndTurn[EndTurn]

  EndTurn --> ChangeTurnSystemEnemy[Change To Enemy Turn]

  ChangeTurnSystemEnemy --> TurnSystemCheck

  SU --> CheckAction{does it have action points?}

  CheckAction -->|Yes| SelectAction[SelectAction]
  CheckAction -->|No| ded[Cant perform Action]

  ded --> move

  SelectAction --> SelectActionTargetGrid[SelectActionTargetGrid]
  
  SelectActionTargetGrid --> PlayerUnitActionPerform[Player Unit Action Perform]

  PlayerUnitActionPerform --> CheckEnemyHealth{Is There Enemy Unit Health <= 0?}

    CheckEnemyHealth -->|Yes| EnemyUnitDead[Enemy Unit Dead]
    CheckEnemyHealth -->|No| PlayerUnitActionComplete[Player Unit Action Complete]

    EnemyUnitDead --> CheckEnemyUnitList{Check Unit Manager Are there still Enemy unit on the battlefield?}

    CheckEnemyUnitList -->|Yes| move
    CheckEnemyUnitList -->|No| Victory[Victory!]
    
    PlayerUnitActionComplete --> move
  
    EnemyAI --> ChooseEnemyUnit[Choose Enemy Unit]

    ChooseEnemyUnit --> CheckEnemyUnitActionPoin[Check if Enemy Unit has Action Points]

    CheckEnemyUnitActionPoin -->|Yes| chooseBestEnemyAction[Choose Best Enemy Action]
    CheckEnemyUnitActionPoin -->|No| CheckOtherEnemyUnit[Check Other Enemy Unit]

    CheckOtherEnemyUnit --> EnemyEnd{Check if All Enemy Unit dont have ActionValue}

    EnemyEnd -->|Yes| EnemyUnitEndTurn[Enemy Unit End Turn]
    EnemyEnd -->|No| ChooseEnemyUnit[Check Other Enemy Unit]

    ChooseBestEnemyAction --> EnemyActionPerform[EnemyActionPerform]

    EnemyActionPerform --> CheckPlayerHealth{Is There Player Unit Health <= 0?}

    CheckPlayerHealth -->|Yes| PlayerUnitDead[Player Unit Dead]
    CheckPlayerHealth -->|No| EnemyAI

    PlayerUnitDead --> CheckPlayerUnitList{Check Unit Manager Are there still Player unit on the battlefield?}

    CheckPlayerUnitList -->|Yes| EnemyAI
    CheckPlayerUnitList -->|No| Defeat[DEFEAT!]

    EnemyUnitEndTurn --> ChangeToPlayerTurn[Change To Player Turn]
    ChangeToPlayerTurn --> TurnSystemCheck
    
```

<br>

## Event Signal Diagram
```mermaid
classDiagram
    %% --- Unit Systems ---
    class Unit {
        +OnAnyActionPointsChanged()
        +OnAnyUnitSpawned()
        +OnAnyUnitDead()
    }

    class UnitActionSystem {
        +OnSelectedUnitChanged()
        +OnSelectedActionChanged()
        +OnBusyChanged(bool)
        +OnActionStarted()
    }

    class HealthSystem {
        +OnDead()
        +OnDamaged()
    }

    class BaseAction{
        OnAnyActionStart()
        OnAnyActionComplete()  
    }


    class LevelGrid{
      OnAnyUnitMovedGridPosition()
    }

    %% --- Relations ---
    UnitManager --> Unit : Update List

    Unit --> HealthSystem : Take Damage

    HealthSystem --> Unit : Dead

    UnitActionSystem --> BaseAction : PerformAction

    MoveAction --> LevelGrid : UpdatePosition

```

<br>

## Installation & Setup
1. Clone this repository
2. Open the project in Unity (6 or later recommended)
3. Open the main gameplay scene
4. Press Play to start testing

## Controls
| Key Binding       | Function          |
| ----------------- | ----------------- |
| W,A,S,D          | Move Camera |
| Scroll Wheel             | Move Up/Down Camera              |
| Left Mouse Click              | Select Unity And action |
