# Card Game

Card Game currently designed for 2 players. In this game each player gets a 20 cards from a shuffled deck of 40 cards (Deck size can be configured). Then both players pick the top card from their draw pile and throw them on board. The player whose card is having greater value wins the round and takes all cards from the board and puts them in his discard pile. For any player, If there are no more cards in the draw pile, then shuffle the player's discard pile and use those cards as the new draw pile. Once a player has no cards in either their draw or discard pile, that player loses.

## Important Points To Consider

- The deck size value should be configured in multiples of 4, like 4, 8, 12, 16 etc.
- Currenly this game is compatible to be played with only 2 players. We can extend to multiplayer functionality later.
- Deck Shuffle function is using **Fisher Yates Shuffle Algorithm**
- After each round game controller will prompt a message 'Press Enter to continue to next round, or type 'exit' if you want to quit'. You may press enter to proceed to next round, or type exit to quit the game.
- Quick Tip : If someone wants to check the functionality quickly, just set the deck size in Program.cs file to something like 12 or 8 and then run the program.

## Main Components
- Program.cs : Main entry point of console application
- CardGameController : Responsible for Controling the game logic and flow. Just Call Start method and game will begin.
- CommandLineIO : Responsible for all command line input output operations. Also takes care of the messages and formats to display.
- Card : Responsible for maintaining card state
- Deck : Responsible for maintaning complete deck state (List of Cards). It has configurable deck size and has behaviour to Shuffle the deck and Remove and Get propotionate cards from the deck to be distributed to each player in game. 
- Player : Responsible for maintaining player state (Name, Draw pile, Discard Pile). Player can TryDrawCard from his pile based on game logic. It can also take cards from GameController before the game begins. TryDrawCard will remove the top card from draw pile and move its reference to LastDrawnCard. If there are no cards left to draw then LastDrawnCard will be null.
- Utility.ListExtensions : Added extension to Shuffle an IList Collection using **Fisher yates Shuffle Algorithm**.
- Factories : Responsible for creating objects for different components.
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
  
  
### Output snaps
  
      Welcome To cards game !!!
      Enter player 1 name - akash
      Enter player 2 name - palavi
      The Game Begins !!!

      akash (Draw pile : 5 cards, Discard Pile : 2 cards) : 3
      palavi (Draw pile : 5 cards, Discard Pile : 0 cards) : 2
      akash wins this round

      Press Enter to continue to next round, or type 'exit' if you want to quit

      akash (Draw pile : 4 cards, Discard Pile : 2 cards) : 2
      palavi (Draw pile : 4 cards, Discard Pile : 0 cards) : 2
      No winner in this round

      Press Enter to continue to next round, or type 'exit' if you want to quit

      akash (Draw pile : 3 cards, Discard Pile : 2 cards) : 1
      palavi (Draw pile : 3 cards, Discard Pile : 4 cards) : 2
      palavi wins this round

      Press Enter to continue to next round, or type 'exit' if you want to quit

      akash (Draw pile : 2 cards, Discard Pile : 2 cards) : 1
      palavi (Draw pile : 2 cards, Discard Pile : 4 cards) : 1
      No winner in this round

      Press Enter to continue to next round, or type 'exit' if you want to quit

      ...
      ...
      ...

      akash (Draw pile : 2 cards, Discard Pile : 10 cards) : 2
      palavi (Draw pile : 0 cards, Discard Pile : 0 cards) : 1
      akash wins this round

      Press Enter to continue to next round, or type 'exit' if you want to quit


      akash wins the game!
      Thanks for playing !!!
