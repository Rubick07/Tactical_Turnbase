<p align="center">
  <img width="100%" alt="Turnbase" src="https://github.com/user-attachments/assets/5b50cca5-229e-42c8-879e-ce176838ab33">
  </br>
</p>

## 🔴About
This project focused on recreating the core mechanics of tactical RPG games such as XCOM.
The project features grid-based movement, turn-based combat, and action execution systems built on top of Tilebase system.
It was primarily developed to study and implement the Command Pattern, allowing combat actions to be executed, queued, and managed in a clean 
and scalable way.
<br>

## 📋 Project Info
This project using Unity 6000.0.58f2

| **Role** | **Name** | **Development Time** 
|:-|:-|:-|
| Game Programmer | Evan Jonathan | 1 month |

<br>

##  📜Scripts and Features

• Command Pattern Implementation
• Grid-Based Movement
• Tilemap Combat System
• Turn Management
• Action Point System
• Tactical Target Selection
• Enemy Decision Making


|  Script       | Description                                                  |
| ------------------- | ------------------------------------------------------------ |
| `LevelGrid` |Manages Tilebase grid for Level|
| `GridSystem` |Manages Tilebase grid|
| `TurnSystem` |Manages Turn for unit|
|  `UnitManager.cs` | Manages Unit in field|
| `BaseAction.cs`  | Abstract base class for all unit actions |
| `Unit.cs`  | Handles character data and combat actions for battle units |
| `UnitAnimator.cs`  | Handles Unit Animation and effect |
| `UnitActionSystem.cs`  | Manages for player Input in battle |
| `CameraManager.cs`  | Manages camera position |
| `InputManager.cs`  | Manages player input |
| `EnemyAI.cs`  | Manages for Enemy AI in combat scene |
| `etc`  | |


<br>


## 📂Files description

```
├── Tactical            # In this folder, containing all the Unity project files, to be opened by a Unity Editor
   ├── Assets                       # In this folder, it contains all our code, assets, scenes, etc was not automatically created by Unity
      ├── Animation                # In this folder, it contaions all animation clip and animation Controller
      ├── Import                    # In this folder, it contaions all imported Unity Packages
      ├── Material                 # In this folder, it contaions all materials
      ├── Prefabs                   # In this folder, it contaions all prefabs for the games
      ├── Scenes                    # In this folder, there are scenes. You can open these scenes to play the game via Unity
      ├── Scripts                   # In this folder, it contaions all script for the games
      ├── Settings                  # In this folder, it contaions base settings from unity
      ├── TextMeshPro               # In this folder, it contaions plugin for TextMeshPro
      ├── Texture                   # In this folder, it contaions texture
      ├── TutorialInfo              # In this folder, it contaions URP packages
   ├── ...
      
```
<br>

## 🕹️Game controls

The following controls are bound in-game, for gameplay and testing.

## Battle Controller
| Key Binding       | Function          |
| ----------------- | ----------------- |
| W,A,S,D          | Move Camera |
| Scroll Wheel             | Move Up/Down Camera              |
| Left Mouse Click              | Select Unity And action |

<br>

