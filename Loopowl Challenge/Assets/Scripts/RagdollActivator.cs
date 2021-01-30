
using UnityEngine;

public class RagdollActivator : MonoBehaviour
{
    //Isn't it annoying how behaviours and colliders don't have a common parent
    //or interface with .enabled?
    [SerializeField]
    public Behaviour[] behavioursToActivate;

    [SerializeField]
    public Behaviour[] behavioursToDeactivate;

    [SerializeField]
    public Collider[] collidersToActivate;

    [SerializeField]
    public Collider[] collidersToDeactivate;

    [SerializeField]
    public Rigidbody[] rigidbodiesToActivate;

	//[SerializeField]
	//public Rigidbody gameplayRigidbody; //needed?

	public void Activate()
	{
        foreach (var behaviour in behavioursToActivate)
		{
            behaviour.enabled = true;
		}

        foreach (var behaviour in behavioursToDeactivate)
		{
            behaviour.enabled = false;
		}

        foreach (var col in collidersToActivate)
		{
            col.enabled = true;
		}

        foreach (var col in collidersToDeactivate)
		{
            col.enabled = false;
		}

        foreach (var rig in rigidbodiesToActivate)
		{
            rig.isKinematic = false;
		}
	}
}
