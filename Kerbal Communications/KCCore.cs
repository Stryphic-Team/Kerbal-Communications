using System;
using UnityEngine;

namespace KC
{
    public class KCCore : MonoBehaviour
    {
        #region Public Data
        public static KCCore Instance { get; protected set; }
        #endregion

        #region Events
        public event Action OnFrameUpdate = delegate { };
        public event Action OnPhysicsUpdate = delegate { };
        public event Action OnGuiUpdate = delegate { };
        #endregion

        #region Unity Events
        public void Start()
        {
            if(Instance != null)
            {
                Destroy(this);
                return;
            }

            Instance = this;
        }

        public void Update()
        {
            OnFrameUpdate.Invoke();
        }

        public void FixedUpdate()
        {
            OnPhysicsUpdate.Invoke();
        }

        public void OnGui()
        {
            OnGuiUpdate.Invoke();
        }

        public void OnDestroy()
        {
            Instance = null;
        }
        #endregion
    }

    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class KCCoreFlight : KCCore
    {
        #region Unity Events
        public new void Start()
        {
            base.Start();
            if (Instance == null)
                return;
        }

        private new void OnDestroy()
        {
            base.OnDestroy();
        }
        #endregion
    }

    [KSPAddon(KSPAddon.Startup.TrackingStation, false)]
    public class KCCoreTracking : KCCore
    {
        #region Unity Events
        public new void Start()
        {
            base.Start();
            if (Instance == null)
                return;
        }

        private new void OnDestroy()
        {
            base.OnDestroy();
        }
        #endregion
    }
}
