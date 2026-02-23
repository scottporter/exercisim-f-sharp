module ValentinesDay

// TODO: please define the 'Approval' discriminated union type
type Approval = 
  | Yes
  | No
  | Maybe
  
// TODO: please define the 'Cuisine' discriminated union type
type Cuisine = 
  | Korean
  | Turkish

// TODO: please define the 'Genre' discriminated union type
type Genre = 
  | Crime
  | Horror
  | Romance
  | Thriller

// TODO: please define the 'Activity' discriminated union type
type Activity = 
  | BoardGame
  | Movie of Genre
  | Chill
  | Restaurant of Cuisine
  | Walk of kilometers : int

let rateActivity (activity: Activity): Approval = 
  match activity with
    | BoardGame -> No
    | Movie Romance -> Yes
    | Movie _ -> No
    | Chill -> No
    | Restaurant Korean -> Yes
    | Restaurant Turkish -> Maybe
    | Walk kilometers when kilometers < 3 -> Yes
    | Walk kilometers when kilometers < 5 -> Maybe
    | Walk kilometers -> No
