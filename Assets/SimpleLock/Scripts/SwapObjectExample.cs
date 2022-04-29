using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapObjectExample : MonoBehaviour
{
    [SerializeField] VaultLock getLock;
    [SerializeField] AudioSource unlockSound;
    [SerializeField] GameObject ObjectOff;
    [SerializeField] AudioClip objectOffClip;
    [SerializeField] GameObject ObjectOn;
    [SerializeField] AudioClip objectOnClip;


    void Start()
    {
        getLock._lockEvent += LockDisabled;
        getLock._unlockEvent += LockEnabled;
    }

    void LockEnabled()
    {
        ObjectOff.SetActive(false);
        ObjectOn.SetActive(true);

        unlockSound.PlayOneShot(objectOnClip);

    }

    void LockDisabled()
    {
        ObjectOff.SetActive(true);
        ObjectOn.SetActive(false);

        unlockSound.PlayOneShot(objectOffClip);


    }
}
