module Allergies

open System

type Allergen = 
| Eggs = 1
| Peanuts = 2
| Shellfish = 4
| Strawberries = 8
| Tomatoes = 16
| Chocolate = 32
| Pollen = 64
| Cats = 128

let list codedAllergies = 
    // 1. Get the sorted list of allergens
    let allergens = 
        Enum.GetValues(typeof<Allergen>)

        |> Seq.cast<Allergen> 
        |> Seq.toList 
        |> List.sortByDescending int

    // Handle the case where the list might be empty to avoid a crash
    let maxScore = 
        if List.isEmpty allergens then 1
        else (allergens |> List.map int |> List.max) * 2

    let initialScore = codedAllergies % maxScore

    let updateState (currentScore, found) allergen =
        let value = int allergen
        if currentScore >= value then
            (currentScore - value, allergen :: found)
        else
            (currentScore, found)

    let (_, finalAllergies) = List.fold updateState (initialScore, []) allergens
    finalAllergies

let allergicTo codedAllergies allergen =
    // Call 'list' function to get the full list
    let myAllergies = list codedAllergies
    
    // Check if the specific allergen is in that list
    myAllergies |> List.contains allergen

