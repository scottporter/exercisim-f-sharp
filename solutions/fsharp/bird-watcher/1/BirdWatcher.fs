module BirdWatcher

let lastWeek : int array = [|0; 2; 5; 3; 7; 8; 4|]

let yesterday(counts: int[]): int = (Array.get counts (counts.Length - 1 - 1)) // 0-indexed languages are weird

let total(counts: int[]): int = Array.sum counts

let dayWithoutBirds(counts: int[]): bool = Array.contains(0) counts
  
let incrementTodaysCount(counts: int[]): int[] = 
  counts[6] <- (counts[6] + 1) 
  counts

let unusualWeek(counts: int[]): bool =
  match counts with
    | [| _; 0; _; 0; _; 0; _|] -> true // no birds on even days
    | [| _; 10; _; 10; _; 10; _|] -> true // 10 birds on even days
    | [| 5; _; 5; _; 5; _; 5|]  -> true // 5 birds on odd days
    | _ -> false // Anything else
