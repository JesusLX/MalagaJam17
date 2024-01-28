using isj23.Pools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Gadget pool", menuName = "mj13/GadgetPool")]

public class GadgetPool : PoolSystemBase
{
    public override PoolItem Play(Transform parent, Vector3 position, Quaternion rotation) {
        PoolItem ps = base.Play(parent, position, rotation);
        ps = this.ThrowGadget(ps, rotation);
        return ps;
    }
    public override PoolItem Play(Vector3 position, Quaternion rotation) {
        PoolItem ps = base.Play(position, rotation);
        ps = this.ThrowGadget(ps, rotation);
        return ps;
    }
    public override PoolItem Play(Transform parent) {
        PoolItem ps = base.Play(parent);
        return ps;
    }

    public PoolItem ThrowGadget(PoolItem poolItem, Quaternion rotation) {
        poolItem.GetComponent<Gadget>().ThrowGadget();
        return poolItem;
    }
}
