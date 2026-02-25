module RolePlayingGame

type Player = { 
    Name: string option
    Level: int
    Health: int
    Mana: int option
}

// let introduce (player: Player): string = 
let introduce {Name = optionalName}: string = 
    //let {Name = optionalName} = player
    match optionalName with
    | Some name -> name
    | None -> "Mighty Magician"

let revive (player: Player): Player option = 
    (* let {Health = health; Level = level} = player
    match health with 
    | 0 when level >= 10 -> Some {player with Health = 100; Mana = Some 100}
    | 0 when level < 10 -> Some {player with Health = 100}
    | _ -> None *)
    match player with 
    | {Health = 0; Level = level} when level >= 10 -> Some {player with Health = 100; Mana = Some 100}
    | {Health = 0} -> Some {player with Health = 100}
    | _ -> None

let castSpell (manaCost: int) (player: Player): Player * int =
    match (player, manaCost) with 
    | ({Health = health; Mana = None}, mana_cost) when mana_cost < health -> ({player with Health = health - mana_cost}, 0)
    | ({Health = health; Mana = None}, mana_cost) when mana_cost >= health -> ({player with Health = 0}, 0)
    | ({Mana = Some mana}, mana_cost) when (mana < mana_cost) -> (player, 0)
    | ({Mana = Some mana}, mana_cost) -> ({player with Mana = Some (mana - mana_cost)}, (mana_cost * 2))
    
