module GuessingGame

let reply (guess: int): string = 
  match guess with 
  | guess when (guess = 42) -> "Correct"
  | guess when (guess = 41 || guess = 43) -> "So close"
  | guess when (guess < 41) -> "Too low"
  | guess when (guess > 43) -> "Too high"
