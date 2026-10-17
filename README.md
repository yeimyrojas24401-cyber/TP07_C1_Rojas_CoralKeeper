# Coral Keeper — Unity Project

Coral Keeper is a 2D underwater platformer set on an Indo-Pacific reef. You play as a little clownfish who must collect coral fragments and bring them back to the bleached reef to restore it. Swim, dive, and shoot bubbles past starfish, lionfish, and a territorial moray eel. The biology lives in the setting, the collectables, the enemies, and the goal.

## Features

### Core Gameplay
- The clownfish moves left and right with A / D or ← / →, and swims up with an impulse using Space, W, or ↑ (keys configurable in `PlayerDataSo`). A short cooldown between impulses keeps swimming controlled.
- The clownfish can dive with S or ↓, sinking faster than it would by drifting.
- Input is read in `Update` and physics is applied in `FixedUpdate` (`linearVelocity` and `AddForce` with `ForceMode2D.Impulse`).
- The clownfish shoots bubbles with J or left click, toward the direction it is facing, with a limited fire rate.
- Bubbles detect hits with a short `Physics2D.Raycast` every physics step (the ray is as long as the step, so fast bubbles never pass through walls or enemies). Each projectile asset (`ProjectileDataSo`) decides which layers it can hit.
- Health system — the clownfish has 5 lives. Touching an enemy costs one life, followed by a short invulnerability window with a blinking sprite. Lives are shown as icons in the UI.
- Goal — collect 5 coral fragments and reach the bleached reef at the end of the level to restore it and win. With fewer fragments, the reef shows how many are still missing. If you run out of lives, you lose.
- The camera follows the clownfish with Cinemachine (dead zone, damping, and a Confiner 2D so it never shows outside the level).

### Enemies
Each enemy has more than 2 HP, a health bar above it, and a death effect with particles and sound. Their values are set per enemy in `EnemyDataSo`:

- **Crown-of-thorns starfish** — patrols the reef floor between two points.
- **Moray eel** — waits in its cave and chases the player only inside its territory (an `OverlapCircle` centered on its home, not on itself, so the player can escape). When the player leaves, it swims back home. It uses a state machine (`enum` + `switch`: Idle, Chase, Return).
- **Lionfish** (extra) — stays in place and shoots spines at the player when they are in range. It reuses the same `Projectile` script as the bubbles, with its own `ProjectileDataSo`.

### Pickables & Power-up
Pickables are collected on trigger and play particles and a sound when picked up:

- **Coral fragment** — adds one fragment to the counter (x/5).
- **Plankton** — heals 1 life, up to the maximum.
- **Anemone (Symbiosis power-up)** — for 8 seconds the clownfish swims 1.5× faster, shoots twice as fast, and glows pink. The remaining time is shown on screen. Picking up another anemone renews the timer.

### Visual Feedback
- Parallax background with several layers that follow the camera at different speeds.
- Animated clownfish (idle, swim, damage, death), enemies, pickables (floating), bubbles (launch, fly, and a pop effect on impact), and death effects.
- Reef restoration effect — when the reef is restored, a curtain of bubbles rises and the cave changes to its healthy sprites.

### Scenes & Menus
- **Main Menu** scene, with Play, Settings, How To Play, Credits, and Exit (Exit is hidden in the Web build).
- **How To Play** panel with pages, reused in the Main Menu and in the Pause Menu.
- **Pause Menu**, opened with the Escape key, with Continue, Retry, How To Play, Settings, and Main Menu.
- **Settings** panel, allowing configuration of Master, Background, SFX, and UI volume, applied to an AudioMixer through exposed parameters.
- **Game Over** scene, shown after winning or losing, with a different background for each result, the fragments collected, and options to Retry or return to the Main Menu.

### Audio
Sound is integrated in the following interactions:

- Background music for each scene.
- UI button clicks.
- Swimming, shooting, and taking damage.
- Collecting each pickable.
- Enemy death.
- Victory and defeat.

All volume is configurable from the Settings panel and persists between sessions. It is routed through a single shared AudioMixer (Master, Background, SFX, and UI groups), converting linear slider values to decibels at runtime.

## Architecture & Code Quality

ScriptableObjects separate data from scene logic, split by role:

- `PlayerDataSo` (configuration): movement, swim, dive, and shoot keys; speeds and forces; lives and invulnerability; fire rate; Symbiosis duration, multipliers, and color; player sound clips.
- `EnemyDataSo` (configuration, one asset per enemy): max health, death effect, speeds, detection range, and fire rate.
- `ProjectileDataSo` (configuration, one asset per projectile): speed, lifetime, damage, hit layers, and hit effect.
- `LevelDataSo` (configuration): how many fragments the level requires.
- `CoralProgressSo` (runtime state): fragments collected, broadcasting a change event for the UI and the goal. Reset at the start of every run.
- `GameResultSo` (runtime state): whether the player won. It survives the scene change, so the Game Over scene can read it.
- `AudioDataSo`: master, background, SFX, and UI volume, persisted via PlayerPrefs and applied to the shared AudioMixer. Every slider goes through one entry point, `SetVolumeOf(channel, value)`, which updates the field, the mixer, the event, and PlayerPrefs in one place.

Observer pattern with C# events: the UI, `GameManager`, and effects subscribe to events (fragments, lives, death, reef restored, Symbiosis time, enemy health, volume, pause) instead of searching for objects at runtime. Every `+=` has a matching `-=`. For example, `LevelGoal.OnReefRestored` is handled by both `GameManager` (end of the run) and `ReefRestoreEffect` (bubbles and healthy reef).

Events for discrete changes, not checks every frame: the moray eel raises `OnStateChanged` only when its state changes, and `MorayEelAnimation` reacts to it.

Single source of truth for pause: `GameManager` owns the pause state (`IsPaused`, `SetPaused`, `OnPauseChanged`) and is the only script that changes `Time.timeScale` in Gameplay. The Pause Menu requests the change and shows its panels when notified; the player and the lionfish read `IsPaused`.

Reaching the goal doesn't depend on trigger order: `LevelGoal` remembers whether the player is inside and tries to restore the reef both when the player enters and when a new fragment is collected.

Guard flags (`picked`, `restored`, `gameEnded`) make sure each pickup, reef restoration, and end of the run happens only once.

Pickables use inheritance: an abstract `Pickable` base class handles the trigger, sound, particles, and destruction, and each pickable (`CoralFragment`, `PlanktonPickup`, `SymbiosisPickup`) only overrides its own effect.

Composition for death effects: each enemy's death effect is a prefab assigned in its `EnemyDataSo`, with particles, sound, and `AutoDestroy`, so the sound is not cut off when the enemy is destroyed.

Physics movement uses Rigidbody2D velocity in `FixedUpdate` with interpolation.

Marker components (`PlayerMarker`, `EnemyMarker`) are used instead of string-based tags for collision identification, providing compile-time safety.

Reusable, single-purpose UI scripts (`SliderVolume` driven by the shared `AudioChannel` enum, `UIBtnBack`, `UIHowToPlay` with a configurable return panel, and `BtnClickSound`) avoid duplicating near-identical code across sliders, buttons, and panels.

## Controls

| Action | Keys |
|---|---|
| Move | A / D, ← / → |
| Swim up | Space, W, ↑ |
| Dive | S, ↓ |
| Shoot bubbles | J, Left click |
| Pause | Esc |

## Credits
- Game Dev / Game Designer / SFX / Media Artist - Yeimy Rojas.
- Pixel Artist / Game Designer / Pixel Animator - Aurora Salazar.
- Music and sounds: Generated with Claude (AI) and edited by Yeimy Rojas (mixing and pitch correction).
- Font: Luckiest Guy.

## Notes
During the development of this project, artificial intelligence tools were used as support for resolving questions, understanding concepts, and reviewing code. AI was primarily used as a reference and learning resource, providing explanations of programming structures, syntax, and possible solutions to problems encountered during development. No code was directly copied from AI-generated responses; the code implemented in the project was written and developed by the author based on their own understanding and adapted to the specific needs of the project.

Link Itchio https://yeimy-rojas-midnightbaker.itch.io/coral-keeper

Contact:
Yeimy Rojas The Midnight Baker. https://www.artstation.com/yeimy24401
