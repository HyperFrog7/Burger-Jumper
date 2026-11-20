# Burger Jumper

A simple, fast 2D platformer made with Unity. You play as a burger, jump across platforms, and reach the crate at the end of each level without falling.

Free to play in your browser, with a Windows build available, and open source under the MIT license.

[Play in browser](https://burntburgerstudios.itch.io/burger-jumper) · [Download for Windows](https://github.com/burntburgerstudios/Burger-Jumper/releases/download/0.1.5/Windows.0.1.5.rar) · [Website](https://burntburgerstudios.com/) · [Source](https://github.com/burntburgerstudios/Burger-Jumper)

## Controls

| Action | Input |
| --- | --- |
| Move | `A` / `D` or `←` / `→` |
| Jump | `Space` (hold for a higher jump) |
| Back to menu | `Esc` |
| Choose a level | Level dropdown on the main menu |

Falling below the level respawns you at the start. Reach the crate to move on to the next level.

## Play

The current release is **0.1.5**.

- **Browser:** [burntburgerstudios.itch.io/burger-jumper](https://burntburgerstudios.itch.io/burger-jumper)
- **Windows:** [Windows.0.1.5.rar](https://github.com/burntburgerstudios/Burger-Jumper/releases/download/0.1.5/Windows.0.1.5.rar), or the [release page](https://github.com/burntburgerstudios/Burger-Jumper/releases/tag/0.1.5)
- **Web build:** download `Web.0.1.5.rar` from the release page and serve the extracted folder over HTTP. Opening `index.html` directly from disk will not work because the build loads Brotli-compressed assets.

## Run the project locally

### Requirements

- Unity **6000.0.85f2** (Unity 6). Install this exact version through Unity Hub.
- Git.
- Optional: the WebGL Build Support module if you want to build for the browser.

### Setup

1. Clone the repository:

   ```bash
   git clone https://github.com/burntburgerstudios/Burger-Jumper.git
   cd Burger-Jumper
   ```

2. In Unity Hub, choose **Add → Add project from disk** and select this folder.
3. Open the project with **6000.0.85f2**. Package dependencies are resolved automatically from `Packages/manifest.json`.
4. Open `Assets/MainMenu.unity` from the Project window and press **Play**.

The first import takes a few minutes. `Library/`, `Temp/`, and build output folders are generated locally and ignored by Git.

> Opening the project with a newer Unity version upgrades `ProjectSettings` and rewrites scenes. If you need to do that, use a throwaway branch and leave the upgrade out of pull requests.

## Build

1. Install **WebGL Build Support** (or the desktop platform module) through Unity Hub.
2. Open **File → Build Profiles**.
3. Select the existing **New Web Profile** in `Assets/Settings/Build Profiles`, or create a desktop profile.
4. Build.

`MainMenu` and `Level1` through `Level5` are already enabled in Build Settings.

## Project structure

| Path | Contents |
| --- | --- |
| `Assets/Scripts/` | Player movement, moving platforms, level goals, and menus |
| `Assets/MainMenu.unity` | Main menu and level select |
| `Assets/Level1.unity` through `Assets/Level5.unity` | Playable levels |
| `Assets/Art/` | Burger sprite and `.aseprite` source |
| `Assets/Brackeys/` | Free 2D Mega Pack assets |
| `Assets/Settings/` | URP settings and build profiles |
| `Packages/manifest.json` | Unity package dependencies |
| `ProjectSettings/` | Project and build configuration |

## Credits

- [Free 2D Mega Pack](https://assetstore.unity.com/packages/2d/free-2d-mega-pack-177430) by Brackeys

## License

[MIT](LICENSE) © 2026 Burnt Burger Studios
