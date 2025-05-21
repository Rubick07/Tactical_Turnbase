using Unity.VisualScripting;
using UnityEngine;

namespace Redacted.Component
{
    public abstract partial class RDCTStaticClasses : MonoBehaviour
    {
        public abstract void OnCreated();
        public virtual void OnStart() { }
        public virtual void OnUpdate() { }
    }
}