# Card Game

Card Game currently designed for 2 players. In this game each player gets a 20 cards from a shuffled deck of 40 cards. Then both players pick the top card from their draw pile and throw them on board. The player whose card is having greater value wins the round and takes all cards from the board and puts them in his discard pile. For any player, If there are no more cards in the draw pile, then shuffle the player's discard pile and use those cards as the new draw pile. Once a player has no cards in either their draw or discard pile, that player loses.

## Main Components
- Program.cs : Main entry point of console application
- CardGameController : Responsible for Controling the game logic and flow. Just Call Start method and game will begin.
- CommandLineIO : Responsible for all command line input output operations. Also takes care of the messages and formats to display.
- Card : Responsible for maintaining card state
- Deck : Responsible for maintaning complete deck state (List<Card>). It has configurable deck size and has behaviour to Shuffle Shuffle deck and Remove and Get Half of the cards from deck to be given to each player. 
- Player : Responsible for maintaining player state (Name, Draw pile, Discard Pile). Player can TryDrawCard from his pile based on game logic. It can also take cards from GameController before the game begins. 
- Utility.ListExtensions : Added extension to Shuffle an IList Collection using **Fisher yates Shuffle Algorithm**.
- Factories : Responsible for creating objects for different components 
- Interfaces : Holds behaviour spec for different components.

## Tests

Covered all the Test scenarios given in the assignment and segregated them into respective test components.

- PlayerTests 
  - What happens if player tries to draws from empty draw pile
  - What happens if player tries to draw card from non empty draw pile
  - What happens if player has no card in either of draw pile or discard pile
  
- DeckTests
  - New deck should contain 40 cards if deck size is 40
  - Shuffling the deck should shuffle the deck
 
- CardTests
  - What happens on Camparing two cards with different values, it should return higher value card
  - What happens on Comparing two cards with same value, it should return null
  
- CardGameTests
  - When comparing two cards of same value, winner of next round should win four cards.
