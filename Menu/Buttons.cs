using IIDKQuest.Classes;
using IIDKQuest.Mods;
using static IIDKQuest.Settings;

namespace IIDKQuest.Menu
{
    internal class Buttons
    {
        public static ButtonInfo[][] buttons = new ButtonInfo[][]
        {
            new ButtonInfo[] { // Main Mods
                new ButtonInfo { buttonText = "Settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Opens the main settings page for the menu."},
                new ButtonInfo { buttonText = "Safety", method =() => SettingsMods.EnterSafety(), isTogglable = false, toolTip = "Opens the main settings page for the menu."},
                new ButtonInfo { buttonText = "Regular", method =() => SettingsMods.EnterRegular(), isTogglable = false, toolTip = "Opens the main settings page for the menu."},
                new ButtonInfo { buttonText = "Names", method =() => SettingsMods.EnterNames(), isTogglable = false, toolTip = "Opens the main settings page for the menu."},
                new ButtonInfo { buttonText = "Photon", method =() => SettingsMods.EnterPhoton(), isTogglable = false, toolTip = "Opens the main settings page for the menu."},
                new ButtonInfo { buttonText = "Networked", method =() => SettingsMods.EnterNetworked(), isTogglable = false, toolTip = "Opens the main settings page for the menu."},
                new ButtonInfo { buttonText = "VRRig", method =() => SettingsMods.EnterVRRig(), isTogglable = false, toolTip = "Opens the VRRig page for the menu."},

            },

            new ButtonInfo[] { // Settings
                new ButtonInfo { buttonText = "Home", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Menu Settings", method =() => SettingsMods.MenuSettings(), isTogglable = false, toolTip = "Opens the main settings page for the menu."},
                new ButtonInfo { buttonText = "Mod Settings", method =() => SettingsMods.ModsSettings(), isTogglable = false, toolTip = "Opens the main settings page for the menu."},

            },

            new ButtonInfo[] { // Menu Settings
                new ButtonInfo { buttonText = "Back", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Returns to the main settings page for the menu."},
                new ButtonInfo { buttonText = "Right Hand", enableMethod =() => SettingsMods.RightHand(), disableMethod =() => SettingsMods.LeftHand(), toolTip = "Puts the menu on your right hand."},
                new ButtonInfo { buttonText = "Disconnect Button", enableMethod =() => SettingsMods.EnableDisconnectButton(), disableMethod =() => SettingsMods.DisableDisconnectButton(), enabled = disconnectButton, toolTip = "Toggles the disconnect button."},
                new ButtonInfo { buttonText = "Change Theme Color", method =() => SettingsMods.ChangeMenuTheme(), isTogglable = false, toolTip = ""},
            },

            new ButtonInfo[] { // Mods Settings
                new ButtonInfo { buttonText = "Back", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Returns to the main settings page for the menu."},
                new ButtonInfo { buttonText = $"Long Arms Length: {SettingsMods.armLength}", method =() => SettingsMods.ChangeArmLength(), isTogglable = false, toolTip = ""},
                new ButtonInfo { buttonText = $"Speed Boost Power: {SettingsMods.maxJumpSpeed}, {SettingsMods.jumpMultiplier}", method =() => SettingsMods.ChangeSpeedBoost(), isTogglable = false, toolTip = ""},
                new ButtonInfo { buttonText = $"Fly Speed: Normal", method = () => SettingsMods.ChangeFlySpeed(), isTogglable = false, toolTip = "" },
                new ButtonInfo { buttonText = $"Projectile Speed: 0.2s", isTogglable = false, toolTip = "" },
                new ButtonInfo { buttonText = "Projectile: Increase Speed", method = () => Projectiles.IncreaseProjectileSpeed(), isTogglable = false, toolTip = "" },
                new ButtonInfo { buttonText = "Projectile: Decrease Speed", method = () => Projectiles.DecreaseProjectileSpeed(), isTogglable = false, toolTip = "" },
                new ButtonInfo { buttonText = $"Projectile Color: Regular", method = () => Projectiles.ChangeProjectileColor(), isTogglable = false, toolTip = "" },

            },

            new ButtonInfo[] { // Movement Settings
                new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Returns to the main settings page for the menu."},
            },

            new ButtonInfo[] { // Projectile Settings
                new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.MenuSettings(), isTogglable = false, toolTip = "Opens the settings for the menu."},
            },

            new ButtonInfo[] { // Safety
                new ButtonInfo { buttonText = "Home", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},

            },

            new ButtonInfo[] { // Regular
                new ButtonInfo { buttonText = "Home", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Long Arms", method =() => SettingsMods.LongArms(),toolTip = ""},
                new ButtonInfo { buttonText = "Speed Boost", method =() => SettingsMods.RegularSpeed(),toolTip = ""},
                new ButtonInfo { buttonText = "No Freeze", method =() => SettingsMods.NoTagFreeze(),toolTip = ""},
                new ButtonInfo { buttonText = "Platforms", method =() => Platforms.K("Normal"), toolTip = ""},
                new ButtonInfo { buttonText = "Noclip", method =() => SettingsMods.Noclip(),toolTip = ""},
                new ButtonInfo { buttonText = "Grow Arms", method =() => SettingsMods.GrowArms(),toolTip = ""},
                new ButtonInfo { buttonText = "Fly", method =() => SettingsMods.Fly(),toolTip = ""},
                new ButtonInfo { buttonText = "Fly V2", method =() => SettingsMods.FlyV2(),toolTip = ""},
                new ButtonInfo { buttonText = "Hand Fly", method =() => SettingsMods.HandFly(),toolTip = ""},
                new ButtonInfo { buttonText = "Acceleration Fly", method =() => SettingsMods.AccelFly(),toolTip = ""},
                new ButtonInfo { buttonText = "Noclip Fly", method =() => SettingsMods.NoclipFly(),toolTip = ""},
                new ButtonInfo { buttonText = "Slingshot Fly", method =() => SettingsMods.SlingshotFly(),toolTip = ""},
                new ButtonInfo { buttonText = "Feather Falling IV", method =() => SettingsMods.SlowFall(),toolTip = ""},
                new ButtonInfo { buttonText = "Dash", method =() => SettingsMods.Dash(),toolTip = ""},
                new ButtonInfo { buttonText = "Gravity Randomizer", enableMethod =() => SettingsMods.RandomGravity(), disableMethod =() => SettingsMods.FixGravity(), toolTip = ""},
                new ButtonInfo { buttonText = "Disable QuitBox", method =() => SettingsMods.DisableQuitBox(), isTogglable = false,toolTip = ""},
                new ButtonInfo { buttonText = "Enable QuitBox", method =() => SettingsMods.EnableQuitBox(), isTogglable = false,toolTip = ""},
                new ButtonInfo { buttonText = "Give All Watch", method =() => SettingsMods.GiveAllWatch(), isTogglable = false,toolTip = ""},
                new ButtonInfo { buttonText = "Flick Jump", method =() => SettingsMods.FlickJump(), toolTip = ""},

            },

            new ButtonInfo[] { // Names
                new ButtonInfo { buttonText = "Home", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Daisy09", method = () => SettingsMods.Daisy09(), toolTip = "" },
                new ButtonInfo { buttonText = "Pbbv", method = () => SettingsMods.Pbbv(), toolTip = "" },
                new ButtonInfo { buttonText = "Echo", method = () => SettingsMods.Echo(), toolTip = "" },
                new ButtonInfo { buttonText = "EndIsHere", method = () => SettingsMods.EndIsHere(), toolTip = "" },
                new ButtonInfo { buttonText = "Statue", method = () => SettingsMods.Statue(), toolTip = "" },
                new ButtonInfo { buttonText = "Banshee", method = () => SettingsMods.Banshee(), toolTip = "" },
                new ButtonInfo { buttonText = "Glitch", method = () => SettingsMods.Glitch(), toolTip = "" },
                new ButtonInfo { buttonText = "Lucy", method = () => SettingsMods.Lucy(), toolTip = "" },
                new ButtonInfo { buttonText = "J3VU", method = () => SettingsMods.J3VU(), toolTip = "" },
                new ButtonInfo { buttonText = "Namo", method = () => SettingsMods.Namo(), toolTip = "" },
                new ButtonInfo { buttonText = "Morse", method = () => SettingsMods.Morse(), toolTip = "" },
                new ButtonInfo { buttonText = "Bees", method = () => SettingsMods.Bees(), toolTip = "" },

            },

            new ButtonInfo[] { // Photon
                new ButtonInfo { buttonText = "Home", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Auto Master", method = () => SettingsMods.SetMaster(), toolTip = "" },

            },

            new ButtonInfo[] { // Networked
                new ButtonInfo { buttonText = "Home", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Strobe", method = () => SettingsMods.Strobe(), toolTip = "" },
                new ButtonInfo { buttonText = "Cube Spam", method = () => Projectiles.CubeSpam(), toolTip = "" },
                new ButtonInfo { buttonText = "Cube Rain", method = () => Projectiles.CubeRain(), toolTip = "" },
                new ButtonInfo { buttonText = "Large Cube Rain", method = () => Projectiles.MapCubeRain(), toolTip = "" },
                new ButtonInfo { buttonText = "Cube Fountain", method = () => Projectiles.CubeFountain(), toolTip = "" },
                new ButtonInfo { buttonText = "Bigger Cube Spam", method = () => Projectiles.BigCubes(), toolTip = "" },

            },

            new ButtonInfo[] { // VRRig
                new ButtonInfo { buttonText = "Home", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Ghost Monke", method = () => SettingsMods.GhostMonke(), toolTip = "" },

            },

        };
    }
}
