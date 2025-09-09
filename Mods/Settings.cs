using easyInputs;
using GorillaNetworking;
using IIDKQuest.Classes;
using JetBrains.Annotations;
using Photon.Pun;
using UnityEngine;
using static IIDKQuest.Menu.Main;
using static IIDKQuest.Settings;

namespace IIDKQuest.Mods
{
    internal class SettingsMods
    {
        private static GameObject direction;
        private static float lastDash = 0f;
        private static float cooldown = 1f;
        private static float force = 10f;
        private static float pushForce = 1f;
        private static float elapsedtime = 0f;
        private static int gravityindex = 0;
        private static float currentFlySpeed = 0.05f;
        private const float initialFlySpeed = 0.05f;
        private const float accelerationRate = 40f;
        private const float maxFlySpeed = 200000000000f;
        public static float armLength = 1.4f;

        public static int fontIndex = 0;
        public static string[] fontNames = new string[]
{
    "Comic Sans MS", "Arial", "Courier New", "Times New Roman", "Verdana",
    "Georgia", "Trebuchet MS", "Impact", "Lucida Console", "Palatino Linotype",
    "Tahoma", "Gill Sans", "Calibri", "Franklin Gothic Medium", "Garamond",
    "Segoe UI", "Candara", "Consolas", "Century Gothic", "Monaco"
};
        private static int currentThemeIndex = 0;
        private static readonly System.Action[] themes = new System.Action[]
        {
            () => ChangeTheme(new Color(0.05f, 0.06f, 0.1f), new Color(0.15f, 0.19f, 0.26f), new Color(0.23f, 0.42f, 1f), Color.white, Color.white, new Color(0.16f, 0.48f, 0.68f)),
            () => ChangeTheme(new Color(0.05f, 0.2f, 0.05f), new Color(0.2f, 0.7f, 0.2f), new Color(0.1f, 0.5f, 0.1f), Color.white, Color.white, new Color(0.1f, 0.5f, 0.1f)), // Green
            () => ChangeTheme(new Color(0.2f, 0, 0.3f), new Color(0.5f, 0.2f, 0.6f), new Color(0.35f, 0.1f, 0.5f), Color.white, Color.white, new Color(0.4f, 0, 0.7f)), // Purple
            () => ChangeTheme(new Color(0, 0, 0.2f), new Color(0, 0, 0.6f), new Color(0, 0, 0.4f), Color.white, Color.white, new Color(0, 0, 0.5f)), // Dark Blue
            () => ChangeTheme(new Color(0.9f, 0.85f, 0.3f), new Color(0.8f, 0.75f, 0.2f), new Color(0.7f, 0.65f, 0.1f), Color.white, Color.white, new Color(0.7f, 0.65f, 0.1f)), // Yellow
            () => ChangeTheme(new Color(1f, 0.6f, 0.2f), new Color(0.9f, 0.45f, 0f), new Color(0.7f, 0.3f, 0f), Color.white, Color.white, new Color(0.9f, 0.45f, 0f)), // Orange
            () => ChangeTheme(new Color(0.6f, 0.1f, 0.1f), new Color(0.9f, 0.4f, 0.4f), new Color(0.7f, 0.05f, 0.05f), Color.white, Color.white, new Color(0.9f, 0.2f, 0.2f)), // Red
            () => ChangeTheme(new Color(0.95f, 0.6f, 0.75f), new Color(1f, 0.3f, 0.5f), new Color(0.8f, 0.1f, 0.3f), Color.white, Color.white, new Color(1f, 0.3f, 0.5f)), // Pink
            () => ChangeTheme(new Color(1f, 1f, 1f), new Color(0.8f, 0.8f, 0.8f), new Color(0.6f, 0.6f, 0.6f), Color.white, Color.white, new Color(0.8f, 0.8f, 0.8f)), // White
            () => ChangeTheme(new Color(0.3f, 0.3f, 0.3f), new Color(0.5f, 0.5f, 0.5f), new Color(0.4f, 0.4f, 0.4f), Color.white, Color.white, new Color(0.5f, 0.5f, 0.5f)) // Grey
        };

        public static float flySpeed = 0.5f;
        private static readonly float[] flyModes = { 0.2f, 0.5f, 0.9f, 1.5f, 2.5f };
        private static readonly string[] flyModeNames = { "Slow", "Normal", "Fast", "Super Fast", "Sonic" };
        private static int flyModeIndex = 1;
        public static void EnterSettings()
        {
            pageNumber = 0;
            buttonsType = 1;
        }

        public static void MenuSettings()
        {
            pageNumber = 0;
            buttonsType = 2;
        }
        public static void ModsSettings()
        {
            pageNumber = 0;
            buttonsType = 3;
        }
        public static void MovementSettings()
        {
            pageNumber = 0;
            buttonsType = 4;
        }

        public static void ProjectileSettings()
        {
            pageNumber = 0;
            buttonsType = 5;
        }
        public static void EnterSafety()
        {
            pageNumber = 0;
            buttonsType = 6;
        }
        public static void EnterRegular()
        {
            pageNumber = 0;
            buttonsType = 7;
        }
        public static void EnterNames()
        {
            pageNumber = 0;
            buttonsType = 8;
        }
        public static void EnterPhoton()
        {
            pageNumber = 0;
            buttonsType = 9;
        }
        public static void EnterNetworked()
        {
            pageNumber = 0;
            buttonsType = 10;
        }
        public static void EnterVRRig()
        {
            pageNumber = 0;
            buttonsType = 11;
        }
        public static void RightHand()
        {
            rightHanded = true;
        }

        public static void LeftHand()
        {
            rightHanded = false;
        }

        public static void EnableFPSCounter()
        {
            fpsCounter = true;
        }

        public static void DisableFPSCounter()
        {
            fpsCounter = false;
        }

        public static void EnableNotifications()
        {
            disableNotifications = false;
        }

        public static void DisableNotifications()
        {
            disableNotifications = true;
        }

        public static void EnableDisconnectButton()
        {
            disconnectButton = true;
        }

        public static void DisableDisconnectButton()
        {
            disconnectButton = false;
        }

        public static void LongArms()
        {
            GorillaObjects.Player.TempMods.LongArms.Set(armLength);
        }
        public static void ChangeArmLength()
        {
            armLength += 0.1f;
            if (armLength > 2f) armLength = 1.2f;

            foreach (var buttonArray in IIDKQuest.Menu.Buttons.buttons)
            {
                foreach (var button in buttonArray)
                {
                    if (button.buttonText.StartsWith("Long Arms Length:"))
                    {
                        button.buttonText = $"Long Arms Length: {armLength:F1}";
                        break;
                    }
                }
            }
        }

        public static float maxJumpSpeed = 11f;
        public static float jumpMultiplier = 1.25f;
        public static void RegularSpeed()
        {
            GorillaObjects.Player.TempMods.Speedboost(maxJumpSpeed, jumpMultiplier);
        }
        public static void ChangeSpeedBoost()
        {
            maxJumpSpeed += 1f;
            jumpMultiplier += 0.05f;

            if (maxJumpSpeed > 30f)
            {
                maxJumpSpeed = 9f;
                jumpMultiplier = 1.1f;
            }

            foreach (var buttonArray in IIDKQuest.Menu.Buttons.buttons)
            {
                foreach (var button in buttonArray)
                {
                    if (button.buttonText.StartsWith("Speed Boost Power:"))
                    {
                        button.buttonText = $"Speed Boost Power: {maxJumpSpeed:F1}, {jumpMultiplier:F2}";
                        break;
                    }
                }
            }

            GorillaObjects.Player.TempMods.Speedboost(maxJumpSpeed, jumpMultiplier);
        }


        public static void NoTagFreeze()
        {
            GorillaLocomotion.Player.Instance.disableMovement = false;
        }

        public static void GrowArms()
        {
            if (EasyInputs.GetGripButtonDown(EasyHand.LeftHand))
            {
                GorillaObjects.Player.GrowArms.Left(); 
            }
            if (EasyInputs.GetGripButtonDown(EasyHand.RightHand))
            {
                GorillaObjects.Player.GrowArms.Right();
            }
        }
        public static void HandFly()
        {
            if (EasyInputs.GetPrimaryButtonDown(EasyHand.RightHand))
            {
                Transform rightHandController = GorillaTagger.Instance.rightHandTransform;

                if (rightHandController != null)
                {
                    GorillaTagger.Instance.transform.position += rightHandController.forward * 0.5f;
                    GorillaTagger.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
            }
        }
        public static void AccelFly()
        {
            if (EasyInputs.GetPrimaryButtonDown(EasyHand.RightHand))
            {
                Camera mainCamera = Camera.main;
                if (mainCamera != null)
                {
                    currentFlySpeed += accelerationRate * Time.deltaTime;
                    currentFlySpeed = Mathf.Min(currentFlySpeed, maxFlySpeed);
                    GorillaTagger.Instance.transform.position += mainCamera.transform.forward * currentFlySpeed * Time.deltaTime;
                }
            }
            else
            {
                currentFlySpeed = initialFlySpeed;
            }
        }
        public static void NoclipFly()
        {
            if (EasyInputs.GetPrimaryButtonDown(EasyHand.RightHand))
            {
                Camera mainCamera = Camera.main;
                if (mainCamera != null)
                {
                    GorillaTagger.Instance.transform.position += mainCamera.transform.forward * 0.5f;
                    GorillaTagger.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    var meshColliders = Object.FindObjectsOfType<MeshCollider>();
                    foreach (var collider in meshColliders)
                    {
                        collider.enabled = false;
                    }
                }
            }
            else
            {
                var meshColliders = Object.FindObjectsOfType<MeshCollider>();
                foreach (var collider in meshColliders)
                {
                    collider.enabled = true;
                }
            }
        }
        public static void Fly()
        {
            GorillaObjects.Player.TempMods.Fly(flySpeed);
        }

        public static void ChangeFlySpeed()
        {
            flyModeIndex = (flyModeIndex + 1) % flyModes.Length;
            flySpeed = flyModes[flyModeIndex];

            foreach (var buttonArray in IIDKQuest.Menu.Buttons.buttons)
            {
                foreach (var button in buttonArray)
                {
                    if (button.buttonText.StartsWith("Fly Speed:"))
                    {
                        button.buttonText = $"Fly Speed: {flyModeNames[flyModeIndex]}";
                        break;
                    }
                }
            }
        }
        public static void SlingshotFly()
        {
            var cam = Camera.main;
            var player = GorillaTagger.Instance;
            if (player == null || cam == null) return;

            var rb = player.GetComponent<Rigidbody>();
            if (rb == null) return;

            if (EasyInputs.GetPrimaryButtonDown(EasyHand.RightHand))
            {
                Vector3 forward = cam.transform.forward.normalized;
                rb.velocity += forward * pushForce;
            }
        }
        public static void FlyV2()
        {
            var player = GorillaTagger.Instance;
            if (player == null) return;

            var rb = player.GetComponent<Rigidbody>() ?? player.GetComponentInChildren<Rigidbody>();
            var hand = GorillaLocomotion.Player.Instance?.rightHandTransform;
            if (rb == null || hand == null) return;

            if (EasyInputs.GetGripButtonDown(EasyHand.RightHand))
            {
                var hits = Physics.OverlapSphere(hand.position, 2f);
                var closestDist = float.MaxValue;
                var closestPoint = Vector3.zero;
                var closestNorm = Vector3.zero;
                var found = false;

                foreach (var col in hits)
                {
                    if (col.gameObject == player) continue;

                    var cp = col.ClosestPoint(hand.position);
                    var d = Vector3.Distance(hand.position, cp);
                    if (d >= closestDist) continue;

                    closestDist = d;
                    closestPoint = cp;
                    var dir = (hand.position - cp).normalized;

                    if (Physics.Raycast(cp, dir, out var r, 0.1f))
                        closestNorm = r.normal;
                    else
                        closestNorm = dir;

                    found = true;
                }

                if (found)
                {
                    if (direction == null)
                    {
                        direction = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        Object.Destroy(direction.GetComponent<Collider>());
                        direction.GetComponent<Renderer>().material.color = Color.green;
                        direction.transform.localScale = Vector3.one * 0.25f;
                    }

                    direction.transform.position = closestPoint;
                    Physics.gravity = -closestNorm * 9.81f;
                    return;
                }
            }

            if (direction != null)
            {
                Object.Destroy(direction);
                direction = null;
            }

            Physics.gravity = Vector3.down * 9.81f;
        }

        public static void SlowFall()
        {
            var player = GameObject.Find("GorillaPlayer");
            if (player == null) return;

            var rb = player.GetComponent<Rigidbody>() ?? player.GetComponentInChildren<Rigidbody>();
            if (rb == null) return;

            if (rb.velocity.y < -2f)
            {
                rb.velocity /= 5f;
            }
        }
        public static void Dash()
        {
            var gtPlayer = GorillaTagger.Instance;
            var mainCam = Camera.main;
            if (gtPlayer == null || mainCam == null) return;

            var rb = gtPlayer.GetComponent<Rigidbody>();
            if (rb == null) return;

            if (Time.time - lastDash < cooldown) return;

            if (EasyInputs.GetPrimaryButtonDown(EasyHand.RightHand))
            {
                var dir = mainCam.transform.forward;
                dir.Normalize();
                rb.velocity += dir * force;
                lastDash = Time.time;
            }
        }

        public static void FlickJump()
        {
            if (EasyInputs.GetPrimaryButtonDown(EasyHand.RightHand))
            {
                Vector3 newPosition = GorillaObjects.Player.Instance.rightHandTransform.transform.position;
                newPosition.y -= 1f;
                GorillaObjects.Player.Instance.rightHandTransform.transform.position = newPosition;
            }
        }

        public static void RandomGravity()
        {
            float changeInterval = 5f;
            Vector3[] gravityVectors = new Vector3[]
            {
        Vector3.down,
        Vector3.left,
        Vector3.right,
        Vector3.back,
        Vector3.forward
            };

            elapsedtime += Time.deltaTime;
            if (elapsedtime < changeInterval) return;

            gravityindex = Random.Range(0, gravityVectors.Length);
            Physics.gravity = gravityVectors[gravityindex] * 9.81f;
            elapsedtime = 0f;
        }


        public static void FixGravity()
        {
            GorillaObjects.Player.TempMods.Gravity(0f, -9.81f, 0f);
        }
        public static void DisableQuitBox()
        {
            GorillaObjects.QuitBox.Active = false;
        }
        public static void EnableQuitBox()
        {
            GorillaObjects.QuitBox.Active = true;
        }
        public static void GiveAllWatch()
        {
            GorillaObjects.WatchAll.Value = true;
        }
        public static void Noclip()
        {
            if (EasyInputs.GetTriggerButtonDown(EasyHand.RightHand))
            {
                GorillaObjects.Collider.Mesh.Enabled = false;
            }
            else
            {
                GorillaObjects.Collider.Mesh.Enabled = true;
            }
        }
        public static void GhostMonke()
        {
            if (EasyInputs.GetPrimaryButtonDown(EasyHand.RightHand))
            {
                GorillaObjects.Player.TempMods.GhostMonke(true);
            }
            else
            {
                GorillaObjects.Player.TempMods.GhostMonke(false);
            }
        }
        public static void Daisy09()
        { 
            PhotonNetwork.LocalPlayer.NickName = "<color=#FF0000>Daisy09</color>"; 
        }
        public static void Pbbv()
        {
            PhotonNetwork.LocalPlayer.NickName = "<color=#0000FF>Pbbv</color>";
        }
        public static void Echo()
        {
            PhotonNetwork.LocalPlayer.NickName = "<color=#00FF00>Echo</color>";
        }
        public static void EndIsHere()
        { 
            PhotonNetwork.LocalPlayer.NickName = "<color=#800080>EndIsHere</color>"; 
        }
        public static void Statue()
        { 
            PhotonNetwork.LocalPlayer.NickName = "<color=#808080>Statue</color>"; 
        }
        public static void Banshee()
        { 
            PhotonNetwork.LocalPlayer.NickName = "<color=#FFFF00>Banshee</color>"; 
        }
        public static void Glitch()
        { 
            PhotonNetwork.LocalPlayer.NickName = "<color=#00FFFF>Glitch</color>"; 
        }
        public static void Lucy()
        { 
            PhotonNetwork.LocalPlayer.NickName = "<color=#FF00FF>Lucy</color>";
        }
        public static void Monkeye()
        { 
            PhotonNetwork.LocalPlayer.NickName = "<color=#FFA500>Monkeye</color>";
        }
        public static void J3VU()
        { 
            PhotonNetwork.LocalPlayer.NickName = "<color=#FFFFFF>J3VU</color>";
        }
        public static void Namo()
        { 
            PhotonNetwork.LocalPlayer.NickName = "<color=#32CD32>Namo</color>";
        }
        public static void Morse()
        { 
            PhotonNetwork.LocalPlayer.NickName = "<color=#008080>Morse</color>"; 
        }
        public static void Bees()
        { 
            PhotonNetwork.LocalPlayer.NickName = "<color=#FFD700>Bees</color>"; 
        }
        public static void SetMaster()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
            }
        }
        public static void Strobe()
        {
            GorillaKeyboardButton key = new GorillaKeyboardButton();
            key.characterString = Random.Range(0, 50).ToString();
            GorillaComputer.instance.ProcessColorState(key);
            GorillaComputer.instance.colorCursorLine = Random.Range(0, 3);
        }
        public static void ChangeMenuTheme()
        {
            currentThemeIndex++;
            if (currentThemeIndex >= themes.Length)
                currentThemeIndex = 0;
            themes[currentThemeIndex].Invoke();
        }
        private static void ChangeTheme(Color bg, Color btn1, Color btn2, Color txt1, Color txt2, Color outline)
        {
            Settings.ChangeMenuTheme(bg, btn1, btn2, txt1, txt2, fontNames[fontIndex], 18, outline);
        }


    }
}
