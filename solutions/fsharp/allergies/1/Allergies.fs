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

    // 2. Define the recursion (score is edited via subtraction)
    let rec solve currentScore remaining found =
        match remaining with

        | [] -> found
        | head :: tail ->
            let value = int head
            if currentScore >= value then
                // Edit the score by subtracting the value
                solve (currentScore - value) tail (head :: found)
            else
                solve currentScore tail found

    // 3. APPLY MODULO HERE before starting
    solve (codedAllergies % 256) allergens []

let allergicTo codedAllergies allergen =
    // Call 'list' function to get the full list
    let myAllergies = list codedAllergies
    
    // Check if the specific allergen is in that list
    myAllergies |> List.contains allergen

