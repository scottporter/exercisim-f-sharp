module Bandwagoner

// TODO: please define the 'Coach' record type
type Coach = 
  { Name: string
    FormerPlayer: bool }

// TODO: please define the 'Stats' record type
type Stats = 
  { Wins: int
    Losses: int }

// TODO: please define the 'Team' record type
type Team = 
  { Name: string
    Coach: Coach
    Stats: Stats }

let createCoach (name: string) (formerPlayer: bool): Coach =
    {Name = name; FormerPlayer = formerPlayer}

let createStats(wins: int) (losses: int): Stats =
   {Wins = wins; Losses = losses}

let createTeam(name: string) (coach: Coach)(stats: Stats): Team =
  {Name = name; Coach = coach; Stats = stats}

let replaceCoach(team: Team) (coach: Coach): Team =
   let revised_team = { team with Coach = coach}
   revised_team

let isSameTeam(homeTeam: Team) (awayTeam: Team): bool =
   //let {Name = name_home_team} = homeTeam
   //let {Name = name_away_team} = awayTeam
   //name_home_team = name_away_team
   homeTeam = awayTeam  // Apparently they have a very weird idea of different teams... you can play yourself from the future?


let rootForTeam(team: Team): bool =
   let {Name = team_name; Coach = coach; Stats = stats} = team
   let {Name = coach_name; FormerPlayer = former_player} = coach
   let {Wins = wins; Losses = losses} = stats
   match (team_name, wins, losses, coach_name, former_player) with
   | (_, _, _, "Gregg Popovich", _) -> true
   | (_, _, _, _, true)             -> true
   | ("Chicago Bulls", _, _, _, _)  -> true
   | (_, w, _, _, _) when w >= 60    -> true
   | (_, w, l, _, _) when l > w     -> true
   | _                              -> false
   
