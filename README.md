
# poker-hand-sorter ![GitHub release](https://img.shields.io/github/release/ajeetx/poker-hand.svg?style=for-the-badge) ![Maintenance](https://img.shields.io/maintenance/yes/2021.svg?style=for-the-badge)


| ![GitHub Release Date](https://img.shields.io/github/release-date/ajeetx/poker-hand.svg?style=plastic) |[![.Net Framework](https://img.shields.io/badge/DotNet-2.1-blue.svg?style=plastic)](https://www.microsoft.com/net/download/dotnet-core/2.1) | ![GitHub language count](https://img.shields.io/github/languages/count/ajeetx/poker-hand.svg?style=plastic)| ![GitHub top language](https://img.shields.io/github/languages/top/ajeetx/poker-hand.svg) |![GitHub repo size in bytes](https://img.shields.io/github/repo-size/ajeetx/poker-hand.svg) 
| ---          | ---        | ---      | ---       | --- |


## Project description

A poker hand consists of a combination of five playing cards, ranked in the following ascending order (lowest to highest)

|   Rank   |    Combination   |   Description   |
| --------- | ---------------- | --------------   |
|   1     |    High card    |   Highest value card    |
|   2     |    Pair Two     |   cards of same value    |
|   3    |   Two pairs   |   Two different pairs    |
|   4    |   Three of a kind   |   Three cards of the same value |
|   5    |   Straight    |  All five cards in consecutive value order   |
|   6   |    Flush    |  All five cards having the same suit   |
|    7   |  Full house   |    Three of a kind and a Pair   |
|    8   |  Four of a kind   |   Four cards of the same value   |
|    9   | Straight flush   |    All five cards in consecutive value order, with the same suit    |
|   10   |  Royal Flush   | Ten, Jack, Queen, King and Ace in the same suit   |


The cards are valued in the order: 2, 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King, Ace* * For this exercise, Ace is considered high only. (i.e. cannot be used as a low card below 2 in a straight). Suits are: Diamonds (D), Hearts (H), Spades (S), Clubs (C) When multiple players have the same ranked hand then the rank made up of the highest value cards wins. For example,  pair of kings beats a pair of queens, and a straight with a high card of Jack beats a straight with high card of nine. If two ranks tie, for example, if both players have a pair of Jacks, then highest cards in each hand are compared; if the highest cards tie then the next highest cards are compared, and so on. 


|   Hand   |   Player 1   |   Player 2   | Winner 1   |
|   -----   |   ----    | ----    |   ----   |
|   1  | 4H 4C 6S 7S KD    |    2C 3S 9S 9D TD   |     Player 2   |
|    |   Pair of Fours  |    Pair of Nines   |     | 
|   2   |  5D 8C 9S JS AC    |  2C 5C 7D 8S QH    |   Player 1    |    4 4D 6S 9H QH QC Pair of Queens Highest card Nine 3D 6D 7H QD 
|   |   Highest card Ace   |    Highest card Queen    |   |
|   3   | 2D 9C AS AH AC    |   3D 6D 7D TD QD   |   Player 2   |
|   |   Three Aces   | Flush with Diamonds   |      | 
|    4   |    4D 6S 9H QH QC    |   3D 6D 7H QD QS    |    Player 1    |
|    |   Pair of Queens Highest card Nine    |   Pair of Queens Highest card Seven   |    |
|   5    |    2H 2D 4C 4D 4S    |   3C 3D 3S 9S 9D   |    Player 1   |
|   |  Full House With Three Fours    |  Full House with Three Threes    |   |


#### Note - suits are not taken into account to break a tie for this exercise - only the value of the card determines a winner.


> a simple console based system to find out the winner from 2 poker hands

> uses a variant of `chain of responsibilty` design pattern  

### Environment Setup detail

> Download/install   	
>	1.	[![.Net Framework](https://img.shields.io/badge/DotNet-2.1_Framework-blue.svg?style=plastic)](https://www.microsoft.com/net/download/dotnet-core/2.1) to run console application
>   
>	2. [![VSCode](https://img.shields.io/badge/VS-Code-blue.svg?style=plastic)](https://code.visualstudio.com/) or [![VisualStudio](https://img.shields.io/badge/VS-2017-blue.svg?style=plastic)](https://visualstudio.microsoft.com/vs/older-downloads/) to run/debug the applications
>	
>   3. In Visual Studio Code, please install a [![c#](https://img.shields.io/badge/cSharp-extension-blue.svg?style=plastic)](https://github.com/OmniSharp/omnisharp-roslyn)
>   

#### Instruction

> There are 2 projects in the repository: 
> 
|   #   | application  |   type  |  description |
|   ---  | ---   |   ---   |  --- |
|   1   | PokerHand.Sorter   |    netcore2.1 console application |  poker hand winner logic|
|   2   | PokerHand.Sorter.Test  |  Test application  | poker hand winner logic test | 


>   Kindly clone /download the repository.

>   Open the solution file 'PokerHand.Sorter.sln' from VisualStudio 2017 or open through Visual Studio code by going to the downloaded folder location.

>   Kindly verify if the txt file `poker-hands.txt` with input is present within project `PokerHand.Sorter`
    
    - Kindly build the solition file 
    - And run in DEBUG MODE



keep coding :)


### Contact

Having any trouble? Please read out this [documentation](https://github.com/AJEETX/poker-hand/blob/master/README.md) or [contact](mailto:ajeetkumar@email.com) and to sort it out.

 [![HitCount](http://hits.dwyl.io/ajeetx/poker-hand/projects/1.svg)](http://hits.dwyl.io/ajeetx/poker-hand/projects/1) | ![GitHub contributors](https://img.shields.io/github/contributors/ajeetx/poker-hand.svg?style=plastic)|
 | --- | --- |


