module LogLevels
open System

// Define the separators as an array of strings
let separators = [|"["; "]: "|]

let message (logLine: string): string = 
    match logLine.Split(separators, StringSplitOptions.RemoveEmptyEntries) with
    | [| _level; msg |] -> msg.Trim()
    | [| _single |]      -> "No log level found" // Fallback if no separator found
    | _                 -> "Malformed message"

let logLevel(logLine: string): string = 
    match logLine.Split(separators, StringSplitOptions.RemoveEmptyEntries) with
    | [| level; _msg |] -> level.ToLower()
    | [| _single |]      -> "No log level found" // Fallback if no separator found
    | _                 -> "Malformed message"

let reformat(logLine: string): string = 
    match logLine.Split(separators, StringSplitOptions.RemoveEmptyEntries) with
    | [| level; msg |] -> msg.Trim() + " (" + level.ToLower() + ")"
    | [| _single |]      -> "No log level found" // Fallback if no separator found
    | _                 -> "Malformed message"
