using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class PowerUpManager : MonoBehaviour
{

    //=============================================================
    //================= common - COMMON - common  =================
    //=============================================================

    public int RapidFireEffect()
    {
        Debug.Log("============ RapidFire activated");
        return 10;
    }

    public int DoubleShotEffect()
    {
        Debug.Log("============ DoubleShot activated");
        return 10;
    }

    public int DoubleJumpEffect()
    {
        Debug.Log("============ DoubleJump activated");
        return 10;
    }

    public int ExtraAmmoEffect()
    {
        Debug.Log("============ ExtraAmmo activated");
        return 10;
    }

    public int GrenadeEffect()
    {
        Debug.Log("============ Grenade activated");
        return 10;
    }

    //=============================================================
    //==================== rare - RARE - rare  ====================
    //=============================================================

    public int TurretDuckEffect()
    {
        Debug.Log("============ TurretDuck activated");
        return 10;
    }

    public int JetPackEffect()
    {
        Debug.Log("============ JetPack activated");
        return 10;
    }

    public int RocketLauncherEffect()
    {
        Debug.Log("============ RocketLauncher activated");
        return 10;
    }

    public int AutoLockEffect()
    {
        Debug.Log("============ AutoLock activated");
        return 10;
    }

    public int TempUnlimitedEffect()
    {
        Debug.Log("============ TempUnlimited activated");
        return 10;
    }

    public int AttacksEffect()
    {
        Debug.Log("============ Attacks activated");
        return 10;
    }

    //=============================================================
    //==================== epic - EPIC - epic  ====================
    //=============================================================

    public int NukeEffect()
    {
        Debug.Log("============ Nuke activated");
        return 10;
    }

    public int DuckTankEffect()
    {
        Debug.Log("============ DuckTank activated");
        return 10;
    }

    public int DuckTornadoEffect()
    {
        Debug.Log("============ DuckTornado activated");
        return 10;
    }

    public int AirStrikeEffect()
    {
        Debug.Log("============ AirStrike activated");
        return 10;
    }

    public int BlackHoleEffect()
    {
        Debug.Log("============ BlackHole activated");
        return 10;
    }

    public int TeleportEffect()
    {
        Debug.Log("============ Teleport activated");
        return 10;
    }

    public int DroneEffect()
    {
        Debug.Log("============ Drone activated");
        return 10;
    }
    public void ActivatePowerUpEffect(string powerUpEffectName)
    {
        MethodInfo method = this.GetType().GetMethod(powerUpEffectName, BindingFlags.Public | BindingFlags.Instance);
        if (method != null)
        {
            method.Invoke(this, null);
        }
        else
        {
            Debug.Log("No effect found for: " + powerUpEffectName);
        }
    }
}
