using System;
using UnityEngine;

namespace IIDKQuest.Mods
{
    internal class Platforms
    {
        private static GameObject B;
        private static GameObject C;
        private static bool D;
        private static bool E;
        private static Material F = new Material(Shader.Find("Sprites/Default"));

        private static void G()
        {
            C = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UnityEngine.Object.Destroy(C.GetComponent<Rigidbody>());
            UnityEngine.Object.Destroy(C.GetComponent<BoxCollider>());
            UnityEngine.Object.Destroy(C.GetComponent<Renderer>());
            C.transform.localScale = new Vector3(0.25f, 0.3f, 0.25f);
            GameObject H = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UnityEngine.Object.Destroy(H.GetComponent<Rigidbody>());

            H.transform.parent = C.transform;
            H.transform.rotation = Quaternion.identity;
            H.transform.localScale = new Vector3(0.1f, 1f, 1f);
            H.GetComponent<Renderer>().material = F;
            F.color = Color.black;
            H.transform.position = new Vector3(0.02f, 0f, 0f);
        }

        private static void I()
        {
            B = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UnityEngine.Object.Destroy(B.GetComponent<Rigidbody>());
            UnityEngine.Object.Destroy(B.GetComponent<BoxCollider>());
            UnityEngine.Object.Destroy(B.GetComponent<Renderer>());
            B.transform.localScale = new Vector3(0.25f, 0.3f, 0.25f);
            GameObject J = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UnityEngine.Object.Destroy(J.GetComponent<Rigidbody>());

            J.transform.parent = B.transform;
            J.transform.rotation = Quaternion.identity;
            J.transform.localScale = new Vector3(0.1f, 1f, 1f);
            J.GetComponent<Renderer>().material = F;
            F.color = Color.black;
            J.transform.position = new Vector3(-0.02f, 0f, 0f);
        }

        public static void K(string L)
        {
            if (L == "Normal")
            {
                if (easyInputs.EasyInputs.GetGripButtonDown(easyInputs.EasyHand.LeftHand) && C == null)
                {
                    G();
                }

                if (easyInputs.EasyInputs.GetGripButtonDown(easyInputs.EasyHand.RightHand) && B == null)
                {
                    I();
                }

                if (easyInputs.EasyInputs.GetGripButtonDown(easyInputs.EasyHand.LeftHand) && C != null && !D)
                {
                    C.transform.position = GorillaLocomotion.Player.Instance.leftHandTransform.position;
                    C.transform.rotation = GorillaLocomotion.Player.Instance.leftHandTransform.rotation;
                    D = true;
                }

                if (easyInputs.EasyInputs.GetGripButtonDown(easyInputs.EasyHand.RightHand) && B != null && !E)
                {
                    B.transform.position = GorillaLocomotion.Player.Instance.rightHandTransform.position;
                    B.transform.rotation = GorillaLocomotion.Player.Instance.rightHandTransform.rotation;
                    E = true;
                }

                if (!easyInputs.EasyInputs.GetGripButtonDown(easyInputs.EasyHand.LeftHand) && C != null)
                {
                    C.AddComponent<Rigidbody>();
                    UnityEngine.Object.Destroy(C, 3f);
                    C = null;
                    D = false;
                }

                if (!easyInputs.EasyInputs.GetGripButtonDown(easyInputs.EasyHand.RightHand) && B != null)
                {
                    B.AddComponent<Rigidbody>();
                    UnityEngine.Object.Destroy(B, 3f);
                    B = null;
                    E = false;
                }
            }
        }

        public static void M()
        {
            F.color = Color.red;
        }
    }
}