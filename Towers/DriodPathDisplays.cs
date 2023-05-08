using Il2CppAssets.Scripts.Simulation.SMath;
using Il2CppAssets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;
using static Il2CppAssets.Scripts.Models.Towers.TargetType;


using MelonLoader;
using Harmony;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Utils;
using System;
using System.Text.RegularExpressions;
using System.IO;

using UnityEngine;
using System.Linq;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using System.Collections.Generic;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Simulation.Track;

using Il2CppAssets.Scripts.Simulation;
using Il2CppAssets.Scripts.Models.Towers.Pets;
using Il2CppAssets.Scripts.Unity.Bridge;
using System.Windows;
using BTD_Mod_Helper.Api.Towers;



using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using BTD_Mod_Helper;
using Il2CppAssets.Scripts.Models.Towers.Upgrades;
using HarmonyLib;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Models.Towers.Filters;

using Il2CppAssets.Scripts.Models.TowerSets;
using Il2Cpp;

namespace DruidFourthPath.Displays
{
	// All the Card Projectile displays are so similar, I just kept them in one .cs file
	// I would've used the multiple instance loading like in CardMonkeyMultiDisplay,
	// but I wanted to be able to directly reference the different classes themselves

	public class ThornRed1 : ModDisplay
	{
		public override string BaseDisplay => Generic2dDisplay;

		public override void ModifyDisplayNode(UnityDisplayNode node)
		{
			Set2DTexture(node, Name);
		}
	}





	
}