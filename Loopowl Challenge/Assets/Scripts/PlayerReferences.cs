
using UnityEngine;

public class PlayerReferences : MonoBehaviour
{
    public static PlayerReferences Instance { get; private set; }

    public Transform player;
    public Transform playerTarget;

	private void Awake()
	{
		Instance = this;
	}
}
