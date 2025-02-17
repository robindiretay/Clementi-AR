# Unity Project README

## Project Overview
This Unity project is an AR mobile game designed to relive old monuments of Clementi, specifically the iconic clock tower and fountain, which no longer exist. Using AR, players can "rebuild" these landmarks and take photos with them in real-world settings.

### Target Audience
The app is intended for people on tour guides in Clementi. It serves as an interactive tool that enhances the tour experience, allowing users unfamiliar with the old landscape to visualize and engage with historical landmarks.

## Features
- **AR Object Placement**: Scan specific images to trigger model placement.
- **Photo Mode**: Capture images with the AR monuments and save them to storage.
- **Clicker Game**: A timed clicking challenge to "build" the fountain model.
- **Quiz Mechanic**: Answer questions correctly to gradually complete the tower model.

## Technical Requirements
- **Unity Version**: 2022.3.24f1
- **Dependencies**: ARCore packages from Unity AR Mobile

## User Walkthrough
### General Mechanics
1. **Scanning & Placement**:
   - Players must first scan the **tower image** before scanning the **fountain image**.
   - Scanning the **fountain image first** will result in being barred from progression.
   - Scanning the **tower image** first will generate a **holographic image of the fountain**, along with a **Build** button.
   - Placement requires a recognized solid ground; otherwise, placement will be prevented.

2. **Building the Tower**:
   - Players must answer **6 quiz questions** to construct the tower.
   - Each correct answer builds one segment of the tower.
   - Once fully built, the player can enter **Camera Mode** to take a picture of the AR model.

3. **Building the Fountain**:
   - Players must engage in a **clicker game**, tapping a required number of times before the time limit expires.
   - Success results in the fountain being fully built.

## Known Issues & Limitations
- **Model Rotation**: Models cannot be rotated during placement, making them face a fixed direction.
- **Unity Play Mode Restriction**: Currently, only one object can be placed per session. Restarting Play Mode is required to switch between tower and fountain placement.

## Support
For issues or questions, please reach out for further assistance.

