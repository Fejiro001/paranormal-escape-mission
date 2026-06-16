# Paranormal Investigation: Escape Mission

The game is called **Paranormal Investigation: Escape Mission**. In the game, an investigator enters a haunted house and explores different rooms to gather paranormal evidence while avoiding dangerous ghost encounters. Ghosts reduce the investigator's sanity level, while items can restore sanity. The objective is to collect enough evidence to reach the required credibility score and escape before the investigator's sanity reaches zero.

## Game Design

To model the game, I created six classes:

- **HauntedHouse** – Represents the haunted location being investigated. It contains the rooms, initializes the game, creates the room contents, and determines when the game ends.
- **Room** – Represents an individual room within the haunted house. A room can contain ghosts, evidence, items, or nothing at all.
- **Investigator** – Represents the player. The investigator can move between rooms, collect evidence and items, and has a sanity level that affects whether the game can continue.
- **Ghost** – Represents paranormal entities found in rooms. Ghosts scare the investigator and reduce their sanity level.
- **Evidence** – Represents paranormal clues collected by the investigator. Each piece of evidence has a credibility score that contributes toward winning the game.
- **Item** – Represents helpful objects that can restore the investigator's sanity.
