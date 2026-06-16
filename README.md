# Paranormal Investigation: Escape Mission

A console-based C# adventure game where you play as a paranormal investigator exploring a haunted house in search of evidence of supernatural activity.

Navigate through mysterious rooms, collect paranormal evidence, encounter hostile ghosts, and manage your sanity carefully. Gather enough credible evidence before your sanity reaches zero to successfully complete the investigation and escape the haunted house.

## Gameplay

The investigation begins inside **The Screaming Oaks**, a haunted manor containing multiple rooms.

During the investigation, rooms may contain:

- Ghosts that reduce your sanity.
- Evidence that increases your credibility score.
- Items that restore sanity.
- Nothing at all.

The contents of the rooms are randomized at the start of each game, making every investigation different.

## Winning the Game

To win, you must:

- Collect evidence worth at least the required credibility score.
- Maintain a sanity level above zero.

You lose if:

- Your sanity reaches zero or below before collecting enough credible evidence.

## Features
- Randomized room contents for replayability.
- Multiple ghost behavior types:
	- Passive
	- Aggressive
	- Violent
- Credibility-based victory system.
- Sanity management system.
- Inventory tracking.
- Evidence collection and reporting.
- Interactive console menu system.
- Final investigation report showing:
	- Items collected
	- Evidence discovered
	- Total credibility score
	- Remaining sanity

## Object-Oriented Design

The game is built using *six main classes*:

### HauntedHouse

Represents the haunted location being investigated. It manages room creation, game initialization, win/loss conditions, and investigation reports.

### Room

Represents a location within the haunted house. Rooms may contain ghosts, evidence, items, or be empty.

### Investigator

Represents the player. The investigator can move between rooms, collect evidence and items, and track sanity and credibility.

### Ghost

Represents paranormal entities encountered during the investigation. Different behavior types determine how much sanity damage they inflict.

### Evidence

Represents paranormal findings collected by the investigator. Each piece of evidence contributes a credibility score toward the investigation.

### Item

Represents useful tools or supplies that restore the investigator's sanity.

## Technologies Used

- C#
- .NET Console Application
- Object-Oriented Programming (OOP)

## OOP Concepts Demonstrated

- Classes and Objects
- Constructors
- Encapsulation
- Properties
- Access Modifiers
- Static Members
- Constants (`const`)
- Readonly Fields (`readonly`)
- Collections (`List<T>` and Arrays)