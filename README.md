# Flappy Bird Windows Port

A complete Flappy Bird game implementation using C# Windows Forms, designed to run natively on Windows without any external dependencies.

## 🎮 Game Features

- **Classic Flappy Bird Gameplay**: Navigate through pipes by jumping at the right time
- **Smooth Animation**: 50 FPS gameplay with smooth bird movement and physics
- **Score System**: Track your high score as you pass through pipes
- **Game Over & Restart**: Full game state management with restart functionality
- **Responsive Controls**: Space bar for jumping and game start
- **Visual Polish**: Colorful graphics with bird animations and pipe designs

## 🚀 How to Play

1. **Start the Game**: Press `SPACE` to begin
2. **Control the Bird**: Press `SPACE` to make the bird jump
3. **Avoid Obstacles**: Navigate through the green pipes without touching them
4. **Score Points**: Each pipe you pass through increases your score
5. **Game Over**: Restart by clicking the "Restart Game" button

## 🛠️ Building and Running

### Prerequisites
- .NET 6.0 or later
- Windows OS (Windows Forms dependency)
- Visual Studio 2022 or Visual Studio Code with C# extension

### Quick Start

```bash
# Clone the repository
git clone https://github.com/akgamerz790/flaperbirdWIndowport.git
cd flaperbirdWIndowport

# Build the project
dotnet build

# Run the game
dotnet run
```

### Alternative Build Methods

#### Using Visual Studio
1. Open `FlappyBird.csproj` in Visual Studio
2. Press `F5` or click "Start" to build and run

#### Creating Standalone Executable
```bash
# Create a self-contained executable
dotnet publish -c Release -r win-x64 --self-contained true

# The executable will be in: bin/Release/net6.0-windows/win-x64/publish/
```

## 🏗️ Project Structure

```
flaperbirdWIndowport/
├── FlappyBird.csproj    # Project configuration
├── Program.cs           # Application entry point
├── GameForm.cs          # Main game window and UI logic
├── Game.cs              # Core game logic and state management
├── Bird.cs              # Bird entity with physics and rendering
├── Pipe.cs              # Pipe obstacles with collision detection
└── README.md            # This file
```

## 🎯 Game Mechanics

### Physics
- **Gravity**: Constant downward acceleration
- **Jump**: Instant upward velocity when space is pressed
- **Terminal Velocity**: Realistic falling speed limits

### Collision Detection
- **Rectangle-based**: Precise collision detection between bird and pipes
- **Boundary Checking**: Top and bottom screen boundaries
- **Real-time Updates**: 50 FPS collision checking

### Scoring System
- **Pipe Passage**: +1 point for each pipe successfully passed
- **Real-time Display**: Score updates immediately
- **Game Over Screen**: Final score display

## 🔧 Customization

The game is designed to be easily customizable. Key parameters you can modify:

- **Game Speed**: Adjust `GAME_SPEED` in `GameForm.cs`
- **Gravity**: Modify `GRAVITY` constant for different difficulty
- **Jump Strength**: Change `JUMP_STRENGTH` for higher/lower jumps
- **Pipe Gap**: Adjust `PIPE_GAP` in `Game.cs` for easier/harder gameplay
- **Pipe Speed**: Modify `PIPE_SPEED` in `Pipe.cs`
- **Colors**: Change brush colors in draw methods

## 🐛 Troubleshooting

### Common Issues:

1. **Game doesn't start**: Ensure you have .NET 6.0 or later installed
2. **Controls not working**: Click on the game window to give it focus
3. **Build errors**: Make sure you're targeting `net6.0-windows` framework
4. **Performance issues**: Close other applications to free up system resources

### Build Errors:
```bash
# If you get package restore errors:
dotnet restore

# If you get framework errors:
dotnet --list-sdks  # Check installed SDKs
```

## 🎨 Technical Details

- **Framework**: .NET 6.0 Windows Forms
- **Language**: C# 10
- **Architecture**: Object-oriented with separation of concerns
- **Rendering**: GDI+ graphics with double buffering
- **Input**: Windows Forms KeyDown events
- **Timer**: Windows Forms Timer for game loop

## 📝 Future Enhancements

Potential improvements for the game:
- [ ] Sound effects and background music
- [ ] High score persistence
- [ ] Multiple difficulty levels
- [ ] Custom bird skins
- [ ] Particle effects
- [ ] Background animations
- [ ] Gamepad support

## 🤝 Contributing

Feel free to fork this repository and submit pull requests for improvements!

## 📄 License

This project is open source and available under the MIT License.

---

**Created by akgamerz790** | [GitHub Profile](https://github.com/akgamerz790)