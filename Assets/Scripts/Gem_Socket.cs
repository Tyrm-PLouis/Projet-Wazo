using UnityEngine;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;
public class Gem_Socket : MonoBehaviour
{
    private XRSocketInteractor socket;
    public GameObject WAZO;

    public Material onEye;
    public Material offEye;
    private Material[] mats;
    private SkinnedMeshRenderer renderer;

    private void Start()
    {
        socket = GetComponent<XRSocketInteractor>();
        renderer = WAZO.GetComponentInChildren<SkinnedMeshRenderer>();
    }

    private void Update()
    {
        mats = renderer.materials;
        socketCheck();
        renderer.materials = mats;
    }
    public void socketCheck()
    {
        IXRSelectInteractable objName = socket.GetOldestInteractableSelected();
        if (objName != null)
        {
            if (objName.transform.name == "Gem")
            {
                WAZO.GetComponent<SoundManagerWazo>().playDebut();
                StartCoroutine(delay());
                WAZO.GetComponent<IA_WAZO>().setStarted(true);
                mats[4] = onEye;
                
            }
        }
        if (!socket.hasSelection)
        {
            WAZO.GetComponent<IA_WAZO>().setStarted(false);
            mats[4] = offEye;
        }
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(13);
    }

}