﻿module FsUno.Tests.``When playing a second turn``

open Xunit
open System


[<Fact>]
let ``Same color should be accepted``() =
    Given [ GameStarted(1, 4, Digit(3, Red)) 
            CardPlayed(1, 0, Digit(9, Red)) ] 
    |> When ( PlayCard(1, 1, Digit(8, Red)) )                  
    |> Expect [ CardPlayed(1, 1, Digit(8, Red)) ]

[<Fact>]
let ``Same value should be accepted``() =
    Given [ GameStarted(1, 4, Digit(3, Red)) 
            CardPlayed(1, 0, Digit(9, Red)) ] 
    |> When ( PlayCard(1, 1, Digit(9, Yellow)) )                  
    |> Expect [ CardPlayed(1, 1, Digit(9, Yellow)) ]

[<Fact>]
let ``Different value and color should be rejected``() =
    Given [ GameStarted(1, 4, Digit(3, Red)) 
            CardPlayed(1, 0, Digit(9, Red)) ] 
    |> When ( PlayCard(1, 1, Digit(8, Yellow)) )                  
    |> ExpectThrows<InvalidOperationException>

[<Fact>]
let ``First player should play at his turn``() =
    Given [ GameStarted(1, 4, Digit(3, Red)) 
            CardPlayed(1, 0, Digit(9, Red)) ] 
    |> When ( PlayCard(1, 2, Digit(9, Green)) )                
    |> ExpectThrows<InvalidOperationException>

[<Fact>]
let ``After a full round it should be player 0 turn``() =
    Given [ GameStarted(1, 4, Digit(3, Red)) 
            CardPlayed(1, 0, Digit(9, Red))
            CardPlayed(1, 1, Digit(8, Red))
            CardPlayed(1, 2, Digit(6, Red))
            CardPlayed(1, 3, Digit(6, Red)) ] 
    |> When ( PlayCard(1, 0, Digit(1, Red)) )                
    |> Expect [ CardPlayed(1, 0, Digit(1, Red)) ]
