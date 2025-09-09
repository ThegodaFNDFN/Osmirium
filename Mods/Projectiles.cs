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
    internal class Projectiles
    {
        public static float projectileSpeed = 1f;
        public static Color projectileColor = Color.white;

        private static float lastCubeTimeRight = 0f;
        private static float lastCubeTimeLeft = 0f;

        private static readonly float[] projectileSpeeds = { 0.05f, 0.1f, 0.15f, 0.2f, 0.25f, 0.3f, 0.35f, 0.4f, 0.5f, 0.6f, float.Epsilon };
        private static int projectileSpeedIndex = 3;
        private static readonly Color[] projectileColors = { Color.white, Color.red, new Color(1f, 0.5f, 0f), Color.yellow, Color.green, Color.blue, Color.cyan, Color.magenta, new Color(1f, 0.4f, 0.7f), new Color(0.6f, 0.3f, 0f), Color.black };
        private static readonly string[] projectileColorNames = { "Regular", "Red", "Orange", "Yellow", "Green", "Blue", "Cyan", "Magenta", "Pink", "Brown", "Black" };
        private static int projectileColorIndex = 0;
        public static void CubeSpam()
        {
            float timeNow = Time.time;

            if (EasyInputs.GetGripButtonDown(EasyHand.RightHand) && timeNow - lastCubeTimeRight >= projectileSpeed)
            {
                lastCubeTimeRight = timeNow;
                SpawnProjectile(GorillaLocomotion.Player.Instance.rightHandTransform);
            }

            if (EasyInputs.GetGripButtonDown(EasyHand.LeftHand) && timeNow - lastCubeTimeLeft >= projectileSpeed)
            {
                lastCubeTimeLeft = timeNow;
                SpawnProjectile(GorillaLocomotion.Player.Instance.leftHandTransform);
            }
        }
        public static void CubeRain()
        {
            float timeNow = Time.time;

            if (EasyInputs.GetGripButtonDown(EasyHand.RightHand) && timeNow - lastCubeTimeRight >= projectileSpeed)
            {
                lastCubeTimeRight = timeNow;

                GameObject gorillaPlayer = GameObject.Find("GorillaPlayer");
                if (gorillaPlayer != null)
                {
                    Vector3 positionAbovePlayer = gorillaPlayer.transform.position + new Vector3(UnityEngine.Random.Range(-5f, 5f), 20f, UnityEngine.Random.Range(-5f, 5f));
                    Quaternion rotationAbovePlayer = Quaternion.identity;
                    GameObject bullet = PhotonNetwork.Instantiate("bulletPrefab", positionAbovePlayer, rotationAbovePlayer);
                    BoxCollider collider = bullet.GetComponent<BoxCollider>();
                    if (collider != null) UnityEngine.Object.Destroy(collider);
                    Renderer rend = bullet.GetComponent<Renderer>();
                    if (rend != null) rend.material.color = projectileColor;
                }
            }
        }
        public static void BigCubes()
        {
            float timeNow = Time.time;
            if (EasyInputs.GetGripButtonDown(EasyHand.RightHand) && timeNow - lastCubeTimeRight >= projectileSpeed)
            {
                lastCubeTimeRight = timeNow;
                Vector3 position = GorillaLocomotion.Player.Instance.rightHandTransform.position;
                Quaternion rotation = GorillaLocomotion.Player.Instance.rightHandTransform.rotation;
                GameObject bullet = PhotonNetwork.Instantiate("bulletPrefab", position, rotation);
                bullet.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                BoxCollider collider = bullet.GetComponent<BoxCollider>();
                if (collider != null) UnityEngine.Object.Destroy(collider);
                Renderer rend = bullet.GetComponent<Renderer>();
                if (rend != null) rend.material.color = projectileColor;
            }
            if (EasyInputs.GetGripButtonDown(EasyHand.LeftHand) && timeNow - lastCubeTimeLeft >= projectileSpeed)
            {
                lastCubeTimeLeft = timeNow;
                Vector3 position = GorillaLocomotion.Player.Instance.leftHandTransform.position;
                Quaternion rotation = GorillaLocomotion.Player.Instance.leftHandTransform.rotation;
                GameObject bullet = PhotonNetwork.Instantiate("bulletPrefab", position, rotation);
                bullet.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                BoxCollider collider = bullet.GetComponent<BoxCollider>();
                if (collider != null) UnityEngine.Object.Destroy(collider);
                Renderer rend = bullet.GetComponent<Renderer>();
                if (rend != null) rend.material.color = projectileColor;
            }
        }

        public static void MapCubeRain()
        {
            float timeNow = Time.time;
            if (EasyInputs.GetGripButtonDown(EasyHand.RightHand) && timeNow - lastCubeTimeRight >= projectileSpeed)
            {
                lastCubeTimeRight = timeNow;
                GameObject gorillaPlayer = GameObject.Find("GorillaPlayer");
                if (gorillaPlayer != null)
                {
                    Vector3 positionAbovePlayer = gorillaPlayer.transform.position + new Vector3(UnityEngine.Random.Range(-30f, 30f), 25f, UnityEngine.Random.Range(-30f, 30f));
                    Quaternion rotationAbovePlayer = Quaternion.identity;
                    GameObject bullet = PhotonNetwork.Instantiate("bulletPrefab", positionAbovePlayer, rotationAbovePlayer);
                    BoxCollider collider = bullet.GetComponent<BoxCollider>();
                    if (collider != null) UnityEngine.Object.Destroy(collider);
                    Renderer rend = bullet.GetComponent<Renderer>();
                    if (rend != null) rend.material.color = projectileColor;
                }
            }
        }

        public static void CubeFountain()
        {
            float timeNow = Time.time;
            if (EasyInputs.GetGripButtonDown(EasyHand.RightHand) && timeNow - lastCubeTimeRight >= projectileSpeed)
            {
                lastCubeTimeRight = timeNow;
                GameObject gorillaPlayer = GameObject.Find("GorillaPlayer");
                if (gorillaPlayer != null)
                {
                    Vector3 positionAbovePlayer = gorillaPlayer.transform.position + new Vector3(0f, 5f, 0f);
                    Quaternion rotationAbovePlayer = Quaternion.identity;
                    GameObject bullet = PhotonNetwork.Instantiate("bulletPrefab", positionAbovePlayer, rotationAbovePlayer);
                    Renderer rend = bullet.GetComponent<Renderer>();
                    if (rend != null) rend.material.color = projectileColor;
                }
            }
        }

        private static void SpawnProjectile(Transform handTransform)
        {
            Vector3 position = handTransform.position;
            Quaternion rotation = handTransform.rotation;
            GameObject bullet = PhotonNetwork.Instantiate("bulletPrefab", position, rotation);
            BoxCollider collider = bullet.GetComponent<BoxCollider>();
            if (collider != null) UnityEngine.Object.Destroy(collider);
            Renderer rend = bullet.GetComponent<Renderer>();
            if (rend != null) rend.material.color = projectileColor;
        }

        public static void IncreaseProjectileSpeed()
        {
            if (projectileSpeedIndex < projectileSpeeds.Length - 1)
            {
                projectileSpeedIndex++;
                if (projectileSpeeds[projectileSpeedIndex] <= 0f) projectileSpeedIndex++;
            }
            projectileSpeed = projectileSpeeds[projectileSpeedIndex];
            UpdateProjectileSpeedButton();
        }

        public static void DecreaseProjectileSpeed()
        {
            if (projectileSpeedIndex > 0) projectileSpeedIndex--;
            projectileSpeed = projectileSpeeds[projectileSpeedIndex];
            UpdateProjectileSpeedButton();
        }


        private static void UpdateProjectileSpeedButton()
        {
            foreach (var buttonArray in IIDKQuest.Menu.Buttons.buttons)
            {
                foreach (var button in buttonArray)
                {
                    if (button.buttonText.StartsWith("Projectile Speed:"))
                    {
                        button.buttonText = $"Projectile Speed: {projectileSpeed:F2}s";
                        break;
                    }
                }
            }
        }
        public static void ChangeProjectileColor()
        {
            projectileColorIndex = (projectileColorIndex + 1) % projectileColors.Length;
            projectileColor = projectileColors[projectileColorIndex];

            foreach (var buttonArray in IIDKQuest.Menu.Buttons.buttons)
            {
                foreach (var button in buttonArray)
                {
                    if (button.buttonText.StartsWith("Projectile Color:"))
                    {
                        button.buttonText = $"Projectile Color: {projectileColorNames[projectileColorIndex]}";
                        break;
                    }
                }
            }
        }
    }
}
