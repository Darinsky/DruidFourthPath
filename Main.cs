using BTD_Mod_Helper;
using FourthPath;
using MelonLoader;
using Main = FourthPath.Main;
using BTD_Mod_Helper.Api.ModOptions;
using Il2CppSystem.Collections.Specialized;
using UnityEngine;
using HarmonyLib;
using System;
using System.Reflection;
using BTD_Mod_Helper.Extensions;
using HarmonyPrefix = HarmonyLib.HarmonyPrefix;
using HarmonyPatch = HarmonyLib.HarmonyPatch;
using Il2CppAssets.Scripts.Unity.Display;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Il2CppAssets.Scripts.Simulation.Towers.Weapons;
using UnityEngine.Playables;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.Coop;

[assembly: MelonInfo(typeof(Main), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace FourthPath;

public partial class Main : BloonsTD6Mod

{
    


    public override void OnWeaponFire(Weapon weapon) 
    {
        base.OnWeaponFire(weapon);
        //MelonLogger.Msg(weapon.weaponModel.name);
    }
    
       
       
    private static readonly ModSettingCategory DOTEffects = new("Damage over time effects")
    {
        collapsed = true
    };
    private static readonly ModSettingCategory TowerRelated = new("Tower Related Stuff")
    {
        collapsed = true
    };
    private static readonly ModSettingCategory Costs = new("Cost Related Stuff")
    {
        collapsed = true
    };
    public static readonly ModSettingDouble DOTTicking = new(0.4d)
    {
        category = DOTEffects,
        displayName = "Ticking (Default: 0.4)",
        description = "Higher tiers use this value and multiplies it",
        min = 0,
        max = 3,
    };
    public static readonly ModSettingDouble DOTLength = new(4)
    {
        category = DOTEffects,
        displayName = "Duration (Default: 4)",
        description = "Higher tiers use this value and multiplies it",
        min = DOTTicking,
        max = DOTTicking * 50,
        
    };
    public static readonly ModSettingInt DOTDamage = new(1)
    {
        category = DOTEffects,
        displayName = "Damage (Default: 1)",
        description = "Higher tiers use this value and multiplies it",
        min = 0,
        max = 99999999,
    };
    public static readonly ModSettingBool PurpleImmun = new(true)
    {
        category = TowerRelated,
        displayName = "Can Pop Purples",
        description = "Can the bottom path pop purple bloons",
        button = true,
    };
    public static readonly ModSettingBool LeadImmun = new(true)
    {
        category = TowerRelated,
        displayName = "Can Pop Lead",
        description = "Can the bottom path pop lead/metal bloons",
        button = true,
    };
    public static readonly ModSettingInt ProjCount = new(5)
    {
        category = TowerRelated,
        displayName = "Projectile Count (Default: 5)",
        description = "Amount of Projectiles",
        min = 1,
        max = 16,
        slider = true,
    };


    public static readonly ModSettingInt Tier1Cost = new(600)
    {
        category = Costs,
        displayName = "Tier 1 Cost: (Default: 600)",
        description = "Changes the cost of the tier 1",
        min = 0,
        max = 9999999,
    };
    public static readonly ModSettingInt Tier2Cost = new(1100)
    {
        category = Costs,
        displayName = "Tier 2 Cost: (Default: 1100)",
        description = "Changes the cost of the tier 2",
        min = 0,
        max = 9999999,
    };
    public static readonly ModSettingInt Tier3Cost = new(5400)
    {
        category = Costs,
        displayName = "Tier 3 Cost: (Default: 5400)",
        description = "Changes the cost of the tier 3",
        min = 0,
        max = 9999999,
    };
    public static readonly ModSettingInt Tier4Cost = new(24000)
    {
        category = Costs,
        displayName = "Tier 4 Cost: (Default: 24000)",
        description = "Changes the cost of the tier 4",
        min = 0,
        max = 9999999,
    };
    public static readonly ModSettingInt Tier5Cost = new(60000)
    {
        category = Costs,
        displayName = "Tier 5 Cost: (Default: 60000)",
        description = "Changes the cost of the tier 5",
        min = 0,
        max = 9999999,
    };
}