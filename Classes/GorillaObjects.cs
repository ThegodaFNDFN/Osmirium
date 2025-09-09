using UnityEngine;
using Photon.Pun;
using easyInputs;

namespace IIDKQuest.Classes
{
    internal class GorillaObject
    {
        private GameObject _object;

        public GorillaObject(string name)
        {
            Debug.Log("Some of this is made by me, most by my friends who know coding better then me :3");
            _object = GameObject.Find(name);
        }

        public GameObject Object => _object;

        public bool Active
        {
            get => _object != null && _object.activeSelf;
            set
            {
                if (_object != null)
                    _object.SetActive(value);
            }
        }
    }

    internal class WatchAllWrapper
    {
        private bool _state;
        public bool Value
        {
            get => _state;
            set
            {
                _state = value;
                if (_state)
                {
                    PhotonNetwork.Instantiate("gorillaprefabs/gorillahuntmanager", Vector3.zero, Quaternion.identity, 0, null);
                    PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
                }
                else
                {
                    GameObject huntManager = GameObject.Find("GorillaHuntManager");
                    if (huntManager != null)
                        Object.Destroy(huntManager);
                }
            }
        }
    }

    internal class ColliderWrapper<T> where T : Collider
    {
        private bool _state;
        public bool Enabled
        {
            get => _state;
            set
            {
                _state = value;
                foreach (var c in Object.FindObjectsOfType<T>())
                {
                    c.enabled = _state;
                }
            }
        }
    }

    internal enum Shape
    {
        Cube,
        Sphere,
        Capsule,
        Cylinder,
        Plane,
        Quad
    }

    internal class PlayerWrapper
    {
        public GorillaTagger Instance => GorillaTagger.Instance;

        public class ArmGrow
        {
            private Vector3 _increment = new Vector3(0.01f, 0.01f, 0.01f);

            public void Left()
            {
                if (EasyInputs.GetGripButtonDown(EasyHand.LeftHand))
                {
                    GorillaTagger.Instance.transform.localScale -= _increment;
                }
            }

            public void Right()
            {
                if (EasyInputs.GetGripButtonDown(EasyHand.RightHand))
                {
                    GorillaTagger.Instance.transform.localScale += _increment;
                }
            }
        }

        private ArmGrow _growArms = new ArmGrow();
        public ArmGrow GrowArms => _growArms;

        public class TempModsWrapper
        {
            public void Fly(float speed = 0.5f)
            {
                if (EasyInputs.GetPrimaryButtonDown(EasyHand.RightHand))
                {
                    Camera mainCamera = Camera.main;
                    if (mainCamera != null)
                    {
                        GorillaTagger.Instance.transform.position += mainCamera.transform.forward * speed;
                        GorillaTagger.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    }
                }
            }
            public void Speedboost(float maxJumpSpeed = 11f, float jumpMultiplier = 1.25f)
            {
                GorillaLocomotion.Player.Instance.maxJumpSpeed = maxJumpSpeed;
                GorillaLocomotion.Player.Instance.jumpMultiplier = jumpMultiplier;
            }
            public void Gravity(float x, float y, float z)
            {
                Physics.gravity = new Vector3(x, y, z);
            }
            public void GhostMonke(bool enable)
            {
                if (GorillaTagger.Instance != null && GorillaTagger.Instance.myVRRig != null)
                {
                    GorillaTagger.Instance.myVRRig.enabled = !enable ? true : false;
                }
            }

            public class LongArmsWrapper
            {
                public void Set(float scale = 1.4f)
                {
                    GorillaTagger.Instance.transform.localScale = new Vector3(scale, scale, scale);
                }

                public void Adjustable(Vector3 scale)
                {
                    GorillaTagger.Instance.transform.localScale = scale;
                }
            }

            private LongArmsWrapper _longArms = new LongArmsWrapper();
            public LongArmsWrapper LongArms => _longArms;
        }

        private TempModsWrapper _tempMods = new TempModsWrapper();
        public TempModsWrapper TempMods => _tempMods;
    }


    internal static class GorillaObjects
    {
        public static GorillaObject QuitBox { get; } = new GorillaObject("QuitBox");
        public static WatchAllWrapper WatchAll { get; } = new WatchAllWrapper();

        public static class Collider
        {
            public static ColliderWrapper<MeshCollider> Mesh { get; } = new ColliderWrapper<MeshCollider>();
            public static ColliderWrapper<BoxCollider> Box { get; } = new ColliderWrapper<BoxCollider>();
            public static ColliderWrapper<SphereCollider> Sphere { get; } = new ColliderWrapper<SphereCollider>();
            public static ColliderWrapper<CapsuleCollider> Capsule { get; } = new ColliderWrapper<CapsuleCollider>();
        }

        public static GameObject CreateNew(Shape shape)
        {
            PrimitiveType type = PrimitiveType.Cube;

            switch (shape)
            {
                case Shape.Cube:
                    type = PrimitiveType.Cube;
                    break;
                case Shape.Sphere:
                    type = PrimitiveType.Sphere;
                    break;
                case Shape.Capsule:
                    type = PrimitiveType.Capsule;
                    break;
                case Shape.Cylinder:
                    type = PrimitiveType.Cylinder;
                    break;
                case Shape.Plane:
                    type = PrimitiveType.Plane;
                    break;
                case Shape.Quad:
                    type = PrimitiveType.Quad;
                    break;
            }

            return GameObject.CreatePrimitive(type);
        }

        public static PlayerWrapper Player { get; } = new PlayerWrapper();
    }
}

