module LuciansLusciousLasagna

// TODO: define the 'expectedMinutesInOven' binding
let expectedMinutesInOven = 40

// TODO: define the 'remainingMinutesInOven' function
let remainingMinutesInOven (minutesInOvenSoFar : int) =
  expectedMinutesInOven - minutesInOvenSoFar

// TODO: define the 'preparationTimeInMinutes' function
let preparationTimeInMinutes (layers : int) = 
  layers * 2

// TODO: define the 'elapsedTimeInMinutes' function

let elapsedTimeInMinutes layerCount minutesSoFar  =
    preparationTimeInMinutes layerCount + minutesSoFar