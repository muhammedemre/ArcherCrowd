using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelOfficer : MonoBehaviour
{
    public List<Transform> modelList = new List<Transform>();
    [SerializeField] List<Material> materialList= new List<Material>();
    public int indexOfModel;
    [SerializeField] bool materialAssign = false;

    public void SetTheModel(int modelIndex)
    {
        indexOfModel = modelIndex;
        for (int i = 0; i < modelList.Count; i++)
        {
            modelList[i].gameObject.SetActive(false);
        }
        modelList[modelIndex].gameObject.SetActive(true);
        RotateTheModel(modelList[modelIndex]);

        if (materialAssign)
        {
            SetRandomMaterial(modelList[modelIndex].GetComponent<MeshRenderer>());
        }       
    }

    void SetRandomMaterial(MeshRenderer mesh)
    {
        int randomMeshIndex = Random.Range(0, materialList.Count);
        mesh.material = materialList[randomMeshIndex];
    }

    public void RotateTheModel(Transform balloon)
    {
        Vector3 tempEuler = new Vector3(0f, Random.Range(0f,359f), 0f);
        balloon.eulerAngles = tempEuler;
    }

    #region Button
    [Title("Select the model then Invoke")]
    [Button("Set the model", ButtonSizes.Large)]
    void ButtonModelChooser(int model)
    {
        SetTheModel(model);
    }
    #endregion
}
