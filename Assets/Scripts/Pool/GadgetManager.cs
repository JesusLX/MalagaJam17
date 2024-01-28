using isj23.Pools;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GadgetManager : Singleton<GadgetManager> {
    public List<GadgetPool> gadgets;

    [Header("Test")]
    public string testId;
    public bool testMultishootAtStart = false;
    private Coroutine testMultishootCor;

    private void Start() {
        gadgets ??= new();
        if (testMultishootAtStart) {
            testMultishootCor = StartCoroutine(Multishot());
        }
    }

    private IEnumerator Multishot() {
        while (testMultishootAtStart) {
            TestPlay();
            yield return 0f;
        }
    }
    /// <summary>
    /// Test Function "Play" with the position and rotation of this manager using this.testId to select the Gadget to play
    /// </summary>
    [ContextMenu("Test/Play")]
    public void TestPlay() {
        Play(
            testId,
            null,
            transform.position,
            transform.rotation);
    }
    /// <summary>
    /// Test Function "Play" using this manager transform as parent and this.testId to select the Gadget to play
    /// </summary>
    [ContextMenu("Test/PlayAttached")]
    public void TestPlayAttached() {
        Play(testId, gameObject.transform, Vector3.zero, Quaternion.identity);
    }

    /// <summary>
    /// Invoke the particle system using the pool
    /// </summary>
    /// <param name="poolId">Id to find the pool</param>
    /// <param name="parent">Transform nullable to set as the Gadget Parent</param>
    /// <param name="position">Vector3 where to position and Play the Gadget</param>
    /// <param name="rotation">Rotation of the Gadget</param>
    /// <returns>The Gadget invoked</returns>
    public Gadget Play(string poolId, Transform parent, Vector3 position, Quaternion rotation) {
        if (position == null) {
            position = Vector3.zero;
        }
        GadgetPool pool = FindPool(poolId);
        var ps = pool.Play(parent, position, rotation);

        return ps.GetComponent<Gadget>();
    }
    public Gadget PlayRandom( Transform parent, Vector3 position, Quaternion rotation, PlayerController target) {
        if (position == null) {
            position = Vector3.zero;
        }
        GadgetPool pool = gadgets[Random.Range(0,gadgets.Count)];
        var ps = pool.Play(parent, position, rotation);

        return ps.GetComponent<Gadget>();
    }

    private GadgetPool FindPool(string poolId) {
        GadgetPool pool = gadgets.Find(pool => pool.Id == poolId);
        return pool;
    }
}
