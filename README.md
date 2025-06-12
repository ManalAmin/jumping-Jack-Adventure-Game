# Jumping-Jack's-Adventure-Game

## Authors

- Haniya Hussain 
- Manal Amin

## About The Game

**Jumping Jack’s Adventure** is a 2D space-themed action-platformer built with Unity. In this game, players guide Jack through treacherous environments to reclaim a mystical artifact from the villain, Hunter.

---

## Storyline

In a realm where myth and technology collide, **Jack**, a brave villager, is on a quest to retrieve a stolen artifact that maintains world balance. The artifact is in the hands of **Hunter**, a dangerous enemy threatening global chaos. Jack must survive hazards, battle enemies, and defeat Hunter to restore harmony.

---

## Gameplay Overview

- Navigate **4 rooms/levels** with increasing difficulty.
- **Avoid or fight enemies and obstacles** like saws, spikes, and spikeheads.
- Collect **health packs** to restore health.
- Battle the final boss, **Hunter**, in the last level.
- **Win** by passing through the final door after defeating Hunter.

---

## Features

### Characters
- **Jack** (Player): Agile space explorer.
- **Hunter** (Enemy): Robotic villain with advanced combat mechanics.

### Main System Design Patterns Used
- **State Pattern**: Controls enemy behavior (patrolling, attacking, dying).
- **Singleton Pattern**: Manages sound through a single `SoundManager` instance.

### System Design
- Modular components:
  - `PlayerAttack`
  - `AlienEnemy`
  - `EnemyPatrol`
  - `TrapController`
  - `UIManager`

### Visual & Animation
- Realistic environment textures (space station).
- Frame-based animation for character actions (run, jump, attack).
- Custom-designed obstacles (rotating saw, hydraulic spikes, Spikehead chaser).

### Physics
- Unity Physics2D for movement, gravity, collision.
- Newtonian mechanics used for jump and movement accuracy.
- `BoxCast` used for grounded detection.

---

## Controls

| Action    | Key           |
|-----------|---------------|
| Move      | → (Right Arrow) |
| Jump      | Spacebar      |
| Attack    | ← (Left Arrow) |

---

## Health & Scoring System

- Player starts with **10 health points**.
- Health decreases on collision with obstacles/enemies.
- **Lifelines (Health Packs)** can restore health.
- Game over on health reaching 0.

---

## Screenshots & Media

> ![Title Screen](screenshots/image.png)
> ![Jack Character](screenshots/jack_model.png)
> ![Hunter Enemy](screenshots/hunter_model.png)
> ![Battle Scene](screenshots/Battle_filed.png)
> ![UML Diagram](screenshots/uml_diagram.png)


## Built With

- **Unity Game Engine**
- **C# (MonoBehaviour Scripting)**
- **Draw.io** (for UML diagrams)

---

## How to Play

  1. Clone the repository:
    ```
    git clone https://github.com/Haniyahussain/jumping-Jack-Adventure-Game.git
    ```

  2. Open the project in Unity (preferably 2020.3+).

  3. Hit `Play` in the Unity editor.


## Gameplay Preview

![Gameplay Preview](screenshots/gameplay.gif)



