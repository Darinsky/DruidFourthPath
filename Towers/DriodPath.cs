using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;
using Il2CppSystem.Linq;
using PathsPlusPlus;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.Behaviors;
using Il2CppInterop.Runtime.InteropTypes.Arrays;


using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors;
using DruidFourthPath.Displays;



namespace FourthPath.Towers;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppAssets.Scripts.Utils;

public class Druid5th : ModDisplay
{
    public override string BaseDisplay => this.GetDisplay(TowerType.Druid,1, 5, 0);

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        SetMeshTexture(node, "050fire", 1);
        SetMeshTexture(node, "050fire", 0);
        



    }
}
public class Druid1st : ModDisplay
{
    public override string BaseDisplay => this.GetDisplay(TowerType.Druid, 1, 0, 1);

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        

        SetMeshTexture(node, "101fire", 2);
        //SetMeshTexture(node, "101fire", 0);




    }
}
public class Druid2nd : ModDisplay
{
    public override string BaseDisplay => this.GetDisplay(TowerType.Druid, 1, 0, 2);

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {


        SetMeshTexture(node, "101fire", 2);
        SetMeshTexture(node, "101fire", 0);




    }
}
public class Druid3rd : ModDisplay
{
    public override string BaseDisplay => this.GetDisplay(TowerType.Druid, 1, 3, 0);

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {


        SetMeshTexture(node, "130fire", 1);
        SetMeshTexture(node, "130fire", 0);




    }
}
public class Druid4th : ModDisplay
{
    public override string BaseDisplay => this.GetDisplay(TowerType.Druid, 1, 0, 4);

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {


        SetMeshTexture(node, "104fire", 2);
        SetMeshTexture(node, "104fire", 1);
        SetMeshTexture(node, "104fire", 0);




    }
}

public class DruidFourthPath : PathPlusPlus
{
    public override string Tower => TowerType.Druid;

    public override int UpgradeCount => 5;


    
}

public class FieryThorns : UpgradePlusPlus<DruidFourthPath>
{
    public override int Cost => Main.Tier1Cost;

    public override int Tier => 1;

    public override string Icon => "ThornSwarmUpgradeIcon";

    public override string Portrait => "0001-Druid";

    public override string Description => "All attacks inflicts flames onto the bloon";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        if (IsHighestUpgrade(towerModel))
        {
            towerModel.ApplyDisplay<Druid1st>();
        }
        if (!Main.PurpleImmun)
        {
            towerModel.GetAttackModel().weapons.FirstOrDefault(w => w.name == "WeaponModel_Weapon").projectile.GetDamageModel().immuneBloonProperties |= BloonProperties.Purple;
        }
        if (!Main.LeadImmun)
        {
            towerModel.GetAttackModel().weapons.FirstOrDefault(w => w.name == "WeaponModel_Weapon").projectile.GetDamageModel().immuneBloonProperties |= BloonProperties.Lead;
        }
        foreach (var projectile in towerModel.GetDescendants<ProjectileModel>().ToArray())
        {
            if (projectile.HasBehavior(out DamageModel damageModel))
                damageModel.immuneBloonProperties &= ~BloonProperties.Lead;
            projectile.collisionPasses = new int[] { -1, 0};
            var lasershock = Game.instance.model.GetTowerFromId("WizardMonkey-030").GetDescendant<AddBehaviorToBloonModel>().Duplicate();
            lasershock.lifespan = Main.DOTLength;
            lasershock.GetBehavior<DamageOverTimeModel>().interval = Main.DOTTicking;
            lasershock.GetBehavior<DamageOverTimeModel>().damage = Main.DOTDamage;
            projectile.AddBehavior(lasershock);
            towerModel.GetAttackModel().weapons.FirstOrDefault(w => w.name == "WeaponModel_Weapon").projectile.ApplyDisplay<ThornRed1>();
            // projectile.GetBehavior<DamageModel>().immuneBloonProperties = BloonProperties.None;

            

            if (towerModel.appliedUpgrades.Contains(UpgradeType.HeartOfThunder))
            {

               

                var druid = Game.instance.model.GetTower(TowerType.Druid, 2);
               





                 

            }
        }


      

        
    }
}

public class SearingThorns : UpgradePlusPlus<DruidFourthPath>
{
    public override int Cost => Main.Tier2Cost;

    public override int Tier => 2;

    public override string Icon => VanillaSprites.CamoTargetIconCross;

    public override string Portrait => "002-Druid";

    public override string Description => "Flames smear the camo off of bloons";

    

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        if (IsHighestUpgrade(towerModel))
        {
            towerModel.ApplyDisplay<Druid2nd>();
        }
        foreach (var filterInvisibleModel in towerModel.GetDescendants<FilterInvisibleModel>().ToArray())
        {
            filterInvisibleModel.isActive = false;
        }

        foreach (var projectile in towerModel.GetDescendants<ProjectileModel>().ToArray())
        {
            if (projectile.HasBehavior(out DamageModel damageModel))
                projectile.SetHitCamo(true);
            projectile.AddBehavior(Game.instance.model.GetTowerFromId("NinjaMonkey-020").GetAttackModel().weapons[0].projectile.GetBehavior<RemoveBloonModifiersModel>().Duplicate());
        }
    }
}

public class SprewingThorns : UpgradePlusPlus<DruidFourthPath>
{
    public override int Cost => Main.Tier3Cost;

    public override int Tier => 3;

    public override string Icon => VanillaSprites.FireballUpgradeIcon;

    public override string Description => "Thorns now spew flames whenever they collide with bloons";
    public override string Portrait => "030-Druid";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        towerModel.ApplyDisplay<Druid3rd>();

        var cascadeEmission = new ArcEmissionModel("ArcEmissionModel_", Main.ProjCount, 0, 360,
            new Il2CppReferenceArray<EmissionBehaviorModel>(1)
            {
                [0] = new EmissionRotationOffProjectileDirectionModel(
                    "EmissionRotationOffProjectileDirectionModel_", -25, 25, true)
            }, false);

        var cascadedProjectile = Game.instance.model.GetTowerFromId("WizardMonkey-030").GetAttackModel().weapons[0].projectile.Duplicate();
        cascadedProjectile.display = new() { guidRef = "125ac5d653097974b9707f641258f71b" };

        
        cascadedProjectile.pierce = 10;
        cascadedProjectile.GetDamageModel().damage *= 2;
        cascadedProjectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        var lasershock = Game.instance.model.GetTowerFromId("WizardMonkey-030").GetDescendant<AddBehaviorToBloonModel>().Duplicate();
        lasershock.lifespan = Main.DOTLength;
        lasershock.GetBehavior<DamageOverTimeModel>().interval = Main.DOTTicking;
        lasershock.GetBehavior<DamageOverTimeModel>().damage = Main.DOTDamage * 2;
        towerModel.GetWeapon().projectile.GetBehavior<AddBehaviorToBloonModel>().GetBehavior<DamageOverTimeModel>().damage *= 2;

        cascadedProjectile.collisionPasses = new int[] { -1, 0 };
       
       // PathPlusPlusExtensions.GetTier(TowerModel., 3);

        




        towerModel.GetWeapon().projectile.AddBehavior(new CreateProjectileOnContactModel("CreateProjectileOnExpireModel_", cascadedProjectile, cascadeEmission, false, false, false));
        towerModel.GetWeapon().projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.AddBehavior(lasershock);
    }
}

public class FieryImpact : UpgradePlusPlus<DruidFourthPath>
{
    public override int Cost => Main.Tier4Cost;

    public override int Tier => 4;

    public override string Icon => "0004-Druid";

    public override string Portrait => "004-Druid";

    public override string Description => "Fire shrapnel Homes onto bloons, and throws down constant wall of fires";
    public override void ApplyUpgrade(TowerModel towerModel)
    {
        towerModel.ApplyDisplay<Druid4th>();
        var damageOverTimeModel = towerModel.GetWeapon().projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetBehavior<AddBehaviorToBloonModel>().GetBehavior<DamageOverTimeModel>();
        
         damageOverTimeModel.damage *= 2;
        damageOverTimeModel.interval *= 0.25f;
        towerModel.GetWeapon().projectile.GetBehavior<AddBehaviorToBloonModel>().GetBehavior<DamageOverTimeModel>().interval *= 0.25f;
        towerModel.GetWeapon().projectile.GetBehavior<AddBehaviorToBloonModel>().GetBehavior<DamageOverTimeModel>().damage *= 3;

        towerModel.GetWeapon().projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.AddBehavior(new TrackTargetModel("garar", 999999, true, true, 360, false, 720, false, false));
        towerModel.GetWeapon().projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.AddBehavior(new TravelStraitModel("guh", 200, 2000));
        towerModel.GetWeapon().projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.scale *= 1.4f;

        


    }
}

public class SpiritOfTheInferno : UpgradePlusPlus<DruidFourthPath>
{
    public override int Cost => Main.Tier5Cost;

    public override int Tier => 5;

    public override string Icon => VanillaSprites.InfernoRingUpgradeIcon;

    public override string Description => " the flames from the underworld";

    public override string Portrait => "050-Druid";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        towerModel.ApplyDisplay<Druid5th>();

        var damageOverTimeModel = towerModel.GetWeapon().projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetBehavior<AddBehaviorToBloonModel>().GetBehavior<DamageOverTimeModel>();

        damageOverTimeModel.damage *= 50;
        damageOverTimeModel.interval = 0.05f;
        towerModel.GetWeapon().projectile.GetBehavior<AddBehaviorToBloonModel>().GetBehavior<DamageOverTimeModel>().interval = 0.05f;
        towerModel.GetWeapon().projectile.GetBehavior<AddBehaviorToBloonModel>().GetBehavior<DamageOverTimeModel>().damage *= 34;
        towerModel.GetWeapon().projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetBehavior<AddBehaviorToBloonModel>().lifespan *= 5;
        towerModel.GetWeapon().projectile.GetBehavior<AddBehaviorToBloonModel>().lifespan *= 5;



        foreach (var weaponModel in towerModel.GetWeapons())
        {
            weaponModel.rate *= 0.55f;
           // weaponModel.projectile.GetDamageModel().damage *= 4;


        }
        foreach (var damageModel in towerModel.GetDescendants<DamageModel>().ToArray())
        {
            damageModel.damage *= 4;
        }




    }
}