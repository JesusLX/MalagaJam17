using isj23.Pools;
using UnityEngine;

public class Gadget : PoolItem {
    public string sound;
    public Sprite sprite;
    public float damage;
    public PlayerController target;
    public PlayerController thrower;
    public Rigidbody2D rb;
    public void ThrowGadget() {
        FindObjectOfType<AudioManager>().PlayOneShot(sound);
        rb.AddForce(transform.up * 800f);
    }
}