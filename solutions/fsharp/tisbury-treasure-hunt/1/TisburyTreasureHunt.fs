module TisburyTreasureHunt
open System.Text.RegularExpressions

let getCoordinate (line: string * string): string =
    match line with
    | _, coordinate -> coordinate

(*
// Getting rid of this to avoid using Regex
// This pattern takes a 'template' (Regex) and applies it to the 'input'
let (|Parse|_|) (template: string) (input: string) =
    let m = Regex.Match(input, template)
    if m.Success then
        // Return all captured groups as a list
        Some [ for i in 1 .. m.Groups.Count - 1 -> m.Groups.[i].Value ]
    else
        None

let convertCoordinate (coordinate: string): int * char = 
  match coordinate with 
  | Parse @"^(\d+)([a-zA-Z])$" [num; lett] -> (int num, char lett)
  | _ -> failwith "No match found"
*)

let convertCoordinate (coordinate: string): int * char = 
    let len = coordinate.Length
    if len < 2 then failwith "Invalid"
    // Fable translates these directly to Python slices or Rust indexing
    (int (coordinate.Substring(0, len - 1)), coordinate.[len - 1])

let compareRecords (azarasData: string * string) (ruisData: string * (int * char) * string) : bool = 
    // 1. Get the coordinate from Azara's data and convert it
    let azaraCoord = azarasData |> getCoordinate |> convertCoordinate
    
    // 2. Destructure Rui's data to get the coordinate part
    match ruisData with
    | (_, rCoord, _) -> azaraCoord = rCoord



let createRecord azara ruis =
    let (treasure, aCoordStr) = azara
    let (location, rCoord, quadrant) = ruis
    
    // Avoiding the 'when' guard makes it slightly clearer for the Fable transpiler
    if convertCoordinate aCoordStr = rCoord then 
        (aCoordStr, location, quadrant, treasure)
    else 
        ("", "", "", "")

