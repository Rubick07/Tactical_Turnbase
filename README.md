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

• Command Pattern Implementation <br>
• Grid-Based Movement <br>
• Tilemap Combat System <br>
• Turn Management <br>
• Action Point System <br>
• Tactical Target Selection <br>
• Enemy Decision Making <br>


|  Script       | Description                                                  |
| ------------------- | ------------------------------------------------------------ |
| `LevelGrid` |Manages the tile-based grid for the level|
| `GridSystem` |Manages the tile-based grid system|
| `TurnSystem` |Manages turn order and turn progression|
|  `UnitManager.cs` | Manages all units on the battlefield|
| `BaseAction.cs`  | Abstract base class for all unit actions |
| `Unit.cs`  | Stores unit data and handles combat actions |
| `UnitAnimator.cs`  | Handles unit animations and visual effects|
| `UnitActionSystem.cs`  | Manages player input and unit actions during battle. |
| `CameraManager.cs`  | Manages camera movement and positioning |
| `InputManager.cs`  | Handles player input. |
| `EnemyAI.cs`  | Manages enemy AI behavior during combat. |
| `etc`  | |


<br>


## 📂Files description

```
├── Tactical            # In this folder, containing all the Unity project files, to be opened by a Unity Editor
   ├── Assets                       # Project assets and resources.
      ├── Animation                # Animation clips and Animator Controllers.
      ├── Import                    # Imported packages and third-party assets.
      ├── Material                 # Materials used by game objects.
      ├── Prefabs                   # Reusable game object prefabs.
      ├── Scenes                    # Playable game scenes.
      ├── Scripts                   # Gameplay and system scripts.
      ├── Settings                  # Unity project settings.
      ├── TextMeshPro               # TextMeshPro assets and resources.
      ├── Texture                   # Textures and sprites.
      ├── TutorialInfo              # Unity-generated tutorial and URP resources.
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

