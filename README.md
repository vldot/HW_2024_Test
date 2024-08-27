# Doofus Adventure

### Overview
This project was developed as part of an assignment to demonstrate key skills in Unity and C#. The primary focus of the project is object generation, collision detection, and setting up a score system in a game environment.

### Features
- **Pulpit Generation:** Dynamically generates pulpits at specific intervals and positions on the game grid.
- **Collision Detection:** Implements collision detection between the player and pulpits.
- **UI Setup:** The score UI is in place, displaying the score in real-time on the game screen.
- **ExplodeScript:** You can feel free to test the ExplodeScript to see something unexpected. :)

### Structure
- **Assets/Scripts/**: Contains all the C# scripts used in the project, including the `PulpitCollision`, and other related scripts.
- **Assets/Prefabs/**: Includes the pulpit prefab used for dynamic genNeration in the game.
- **Assets/Scenes/**: The main scene used in the project.

### Installation
1. Clone this repository to your local machine.
2. Open the project in Unity.
3. Run the main scene to start the game.

### Usage
- The player moves using WASD keys.
- Collide with pulpits (although the score does not update in this version).
- The score is displayed in the top-right corner of the game screen, but currently does not update.

### Known Issues
- Score doesn't update.
- Occasional delay in UI update.
- Collision handling needs precision improvement.
- Audio doesn’t work in all scenes.

### Future Improvements
- **Score Functionality:** Implement the actual score updating functionality.
- **Code Cleanup:** Clean up the existing code for better readability and maintenance.
- **Additional Features:** Add new game mechanics, like power-ups or additional levels.
