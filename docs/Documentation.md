#TheCreepyPenguins WebbApp

Vi har under projektet frågat om hjälp bland klasskompisar, lärare samt tagit information från ex. stackoverflow.

##- Ludo user stories

1. Som spelare slår jag med tärningar och får gå antal prickar på den med min pjäs

2. Som spelare kan man gå med i ett spel som har mindre än 4 spelare

3. Som spelare ska jag flytta pjäsen ett varv innan den kommer i mål.

4. Som spelare har jag fyra pjäser att gå i mål med

5. Som spelare vinner jag om jag har gått i mål med mina 4 pjäser

6. Som spelar får jag slå igen om jag slagit en 6:a med tärningen



##Gherkin: User stories 1-2
  Scenario: 
- A player starts a game 
- Then the player waits for a minimum of one player and maximum of three players to join

##User stories 3 & 6
  Scenario: 
- Another player joins a game 
- Given the player has started a game with roll the dice 
- The player moves the piece according to the number given on the dice 
- The player can only move one piece at a time
- If the player rolls a six on the dice, an extra chance is given to roll the dice again and to make an extra move accordingly to the new number given on the dice.
 - The next players turn

##User stories 4&6
  Scenario: 
- First player has made his/hers turn 
- Next player roll the dice 
- The player moves the piece according to the number given on the dice 
- The player only moves one piece at a time
- If the player rolls a six on the dice, you roll the dice again. 
- The next players turn, clockwise.
- Repeat until all 4 pieces of each player is in goal.
- First player with all 4 pieces in goal wins the game, and so on.. 



##How to play:

There has to be at least 2-4 players to begin the Ludo Game.

Every player has four pieces each on the board.

Every player has their own starting position.

You play by rolling the dice. 

You move one dice at a the time according to what number you get on the diece.

If you get a six on the diece, you may throw the dice again, and make another move.

When other number than six is received you pass the turn after making your move to the next player.

We play clockwise.

You continue until all four pieces reached the goal.

The first player whom reaches with all four pieces wins the game. 

Second place is given to the second one that reaches the goal and so on...




https://ludoproject.azurewebsites.net/

