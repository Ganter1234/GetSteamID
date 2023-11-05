using System;
using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Memory;
using CounterStrikeSharp.API.Modules.Menu;
using CounterStrikeSharp.API.Modules.Utils;
using CounterStrikeSharp.API.Modules.Entities;

namespace GetSteamID;
public class GetSteamID : BasePlugin
{
    public override string ModuleName => "Get SteamID";
    public override string ModuleVersion => "1.0.0";
    public override string ModuleAuthor => "Ganter1234";

    [ConsoleCommand("steam", "Get your SteamID")]
    public void SteamCommand(CCSPlayerController? player, CommandInfo command)
    {
        if(player != null && player.PlayerPawn != null && player.PlayerPawn.IsValid)
        {
            var steamid64 = player.SteamID;
            SteamID steam = new SteamID(steamid64);
            var steamid3 = steam.SteamId3;
            player.PrintToChat($"Приветствую, {ChatColors.Green}{player.PlayerName}!");
            player.PrintToChat($"SteamID64: {ChatColors.Red}{steamid64}");
            player.PrintToChat($"SteamID2: {ChatColors.Purple}{steam.SteamId2}");
            player.PrintToChat($"SteamID3: {ChatColors.Yellow}{steamid3}");
            steamid3 = steamid3.Replace("[", "").Replace("U:1:", "").Replace("]", "");
            player.PrintToChat($"AccountID: {ChatColors.Olive}{steamid3}");
        }
    }
}