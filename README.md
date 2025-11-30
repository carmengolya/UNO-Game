# UNO-Game
# 🎮 UNO Game – C# Console Application

This project is developed as part of my **Fundamental Concepts of Programming Languages** course.  
Its purpose is to implement a fully functional **UNO card game** using **C#** and core object-oriented programming principles.

This is an ongoing project, currently in its early stages.

---
## 📘 Project Overview

The project simulates the classic UNO card game in a console environment.

## 📘 Project Structure

The project is centered around several key classes and enumerations that describe the card game model.

### 📂 Classes of the Project

- **Card** – represents an UNO card, defined by a colour and a type  
- **Deck** – contains the 108 UNO cards, shuffles them and manages card drawing  
- **Player** – holds the player's name and their hand of cards  
- **Game** – coordinates the game flow, turns, and rule enforcement  

### 📂 Enumerations

- **Colour** – Red, Yellow, Green, Blue, None (for Wild cards)  
- **CardType** – Numeric cards (0–9) and special cards such as Skip, Reverse, PlusTwo, Wild, WildPlusFour  

These form the foundation of the game logic that I am gradually implementing.

---

## 🎯 Project Goal

The main objective is to develop a **playable UNO game** following standard rules, implemented in C#.  
The game will support:

- Matching cards by **colour** or **type**
- Handling **special cards**
- Multiple players (2–4)
- Drawing cards when no valid move exists
- Detecting when a player reaches **UNO**
- Determining the winner of a round
- A scoring system up to **500 points**

This project serves as a practical exercise in applying OOP concepts such as classes, encapsulation, game state management, and enumerations.

---

## 🃏 UNO Rules (Simplified)

### **1. Basic Gameplay**

- Players take turns playing a card that matches the **colour** or **type** of the top card on the discard pile.  
- If a player cannot play, they must draw one card.  
- When a player has only one card left, they must announce **“UNO!”**.

### **2. Special Cards**

| Card                  | Effect                                      |
|-----------------------|---------------------------------------------|
| **Skip**              | The next player is skipped                  |
| **Reverse**           | Reverses the direction of play              |
| **PlusTwo (+2)**      | Next player draws 2 cards and is skipped    |
| **Wild**              | Allows choosing a new colour                |
| **WildPlusFour (+4)** | Choose a colour + next player draws 4 cards |

### **3. Ending the Round**

A round ends when a player has played all their cards.

### **4. Scoring**

Points are awarded based on the cards remaining in opponents’ hands:

- Number cards -> face value  
- Skip, Reverse, PlusTwo -> 20 points  
- Wild and WildPlusFour -> 50 points  

A full UNO game is usually played until one player reaches **500 points**.

---

## 🛠️ Technologies

- **C#**
- **.NET Console Application**
- **Object-Oriented Programming**

---

## 📄 Notes

This project is created for educational purposes as part of my university coursework.
