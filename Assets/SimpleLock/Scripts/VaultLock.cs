using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaultLock : MonoBehaviour
{
    [SerializeField] string solution = "1234";//The solution to the lock that should be met to open the lock.

    string inputCode;

    public delegate void UnlockEvent();
    public UnlockEvent _unlockEvent;//Subcribe methods to this event to be called when the lock is unlocked.

    public delegate void LockEvent();
    public UnlockEvent _lockEvent;//Subscribe the methods you want executed to this event.

    public bool isLocked = true;


    //Exposed method to set the input code to match with the solution.
    public void LockInput(string input)
    {
        inputCode += input;
        CheckInput();
    }


    //This method checks wether the input code matches the solution's length and if it does, it checks if the input code matches the solution.
    void CheckInput()
    {
        if (inputCode.Length >= solution.Length)
        {
            if (string.Equals(inputCode, solution))
            {
                print("unlocked");
                isLocked = false;
                _unlockEvent?.Invoke();
            }
            else
            {
                print("wrong code, try again.");
                isLocked = true;
                inputCode = "";
                _lockEvent?.Invoke();
            }
        }
    }
}


