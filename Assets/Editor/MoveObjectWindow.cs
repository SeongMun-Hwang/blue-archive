using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveObjectsWindow : EditorWindow
{
    Vector3 moveAmount;

    [MenuItem("Custom Tools/Move Objects by Value")]
    public static void ShowWindow()
    {
        GetWindow<MoveObjectsWindow>("Move Objects");
    }

    void OnGUI()
    {
        //값 입력으로 오브젝트 이동
        GUILayout.Label("Move Selected Objects", EditorStyles.boldLabel);
        moveAmount = EditorGUILayout.Vector3Field("Move Amount", moveAmount);
        if (GUILayout.Button("Move Objects"))
        {
            MoveSelectedObjects(moveAmount);
        }
        GUILayout.Space(10);

        // 부모를 삭제하는 버튼 추가
        GUILayout.Label("Remove Object's Parent", EditorStyles.boldLabel);
        if (GUILayout.Button("Remove Parent of Selected Objects"))
        {
            RemoveSelectedAndReparentChildren();
        }
        GUILayout.Space(10);

        //부모 좌표 초기화 및 자식에게 상속
        GUILayout.Label("Reset Parent's position, keep child", EditorStyles.boldLabel);
        if (GUILayout.Button("Relocate Children"))
        {
            RelocateChildren();
        }
        GUILayout.Space(10);

        //블록 정렬
        GUILayout.Label("X & Y axis allign", EditorStyles.boldLabel);
        if (GUILayout.Button("Align Selected Objects"))
        {
            AlignSelectedObjects();
        }
        GUILayout.Space(10);
    }

    void MoveSelectedObjects(Vector3 delta)
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            Undo.RecordObject(obj.transform, "Move Objects");
            obj.transform.position += delta;
        }
    }

    // 선택된 부모 객체를 삭제하고 자식들을 원래 위치에 유지시키는 함수
    void RemoveSelectedAndReparentChildren()
    {
        foreach (GameObject selectedObj in Selection.gameObjects)
        {
            // 선택된 GameObject의 부모 확인
            Transform parentTransform = selectedObj.transform.parent;

            // 선택된 GameObject가 부모를 가지고 있는 경우에만 작업 수행
            if (parentTransform != null)
            {
                // 선택된 GameObject의 모든 자식을 순회
                int children = selectedObj.transform.childCount;
                for (int i = children - 1; i >= 0; i--)
                {
                    Transform child = selectedObj.transform.GetChild(i);

                    // Undo 기록을 위해 자식 객체의 부모 변경 사항을 등록
                    Undo.SetTransformParent(child, parentTransform, "Reparent Child");

                    // 자식을 상위 부모에게 직접 연결
                    child.SetParent(parentTransform, true);
                }

                // 선택된 GameObject 삭제
                Undo.DestroyObjectImmediate(selectedObj);
            }
        }
    }
    void RelocateChildren()
    {
        foreach (GameObject selectedObj in Selection.gameObjects)
        {
            Transform parentTransform = selectedObj.transform;

            // 부모 오브젝트의 원래 위치 저장
            Vector3 originalParentPosition = parentTransform.position;

            // 자식 오브젝트의 글로벌 위치를 저장할 리스트
            List<Vector3> childGlobalPositions = new List<Vector3>();

            // 자식 오브젝트의 글로벌 위치 저장
            for (int i = 0; i < parentTransform.childCount; i++)
            {
                childGlobalPositions.Add(parentTransform.GetChild(i).position);
            }

            // 부모 오브젝트의 위치를 (0, 0, 0)으로 변경
            Undo.RecordObject(parentTransform, "Reset Parent Position");
            parentTransform.position = Vector3.zero;

            // 자식 오브젝트의 글로벌 위치를 복원
            for (int i = 0; i < parentTransform.childCount; i++)
            {
                Transform child = parentTransform.GetChild(i);
                Undo.RecordObject(child, "Relocate Child");
                child.position = childGlobalPositions[i];
            }
        }
    }
    void AlignSelectedObjects()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            // 오브젝트의 현재 위치를 가져옴
            Vector3 currentPosition = obj.transform.position;

            // x와 z 좌표를 반올림하여 정렬
            float alignedX = Mathf.Round(currentPosition.x);
            float alignedZ = Mathf.Round(currentPosition.z);

            // y 좌표는 변경하지 않음
            float alignedY = currentPosition.y;

            // 오브젝트의 위치를 업데이트하기 전에 Undo 기능을 위해 변경을 기록
            Undo.RecordObject(obj.transform, "Align Objects");

            // 오브젝트의 위치를 업데이트
            obj.transform.position = new Vector3(alignedX, alignedY, alignedZ);
        }
    }

}