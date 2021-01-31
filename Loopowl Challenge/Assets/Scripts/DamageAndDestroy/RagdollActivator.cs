
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

	[SerializeField]
	public Rigidbody gameplayRigidbody;

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

        gameplayRigidbody.constraints &= ~RigidbodyConstraints.FreezePositionZ;
        gameplayRigidbody.constraints &= ~RigidbodyConstraints.FreezeRotation;

        //ensure the body falls off the stage
        var sidewaysLaunchVector = Random.Range(0, 2) == 0 ? Vector3.forward : Vector3.back;
        sidewaysLaunchVector *= 3f;
        gameplayRigidbody.velocity += sidewaysLaunchVector;

        foreach (var rig in rigidbodiesToActivate)
		{
            rig.isKinematic = false;
            rig.velocity = gameplayRigidbody.velocity;
		}
	}
}
