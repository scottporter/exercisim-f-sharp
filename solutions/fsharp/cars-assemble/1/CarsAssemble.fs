module CarsAssemble

let successRate (speed: int): float =
    match speed with
    | speed when speed = 0 -> 0.0
    | speed when speed >= 1 & speed <= 4 -> 1.0
    | speed when speed >= 5 & speed <= 8 -> 0.9
    | speed when speed = 9 -> 0.8
    | speed when speed >= 10 -> 0.77

let productionRatePerHour (speed: int): float =
    221.0 * (float speed) * (successRate speed )

let workingItemsPerMinute (speed: int): int =
   int ((productionRatePerHour speed) / 60.0)
