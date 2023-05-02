using UnityEngine;
public class TestInput : MonoBehaviour {
    void Update() {
        Task_1();
        Task_2();
    }

    private void Task_1() {
        if(Input.touchCount > 0) {
            const int HUNDRED = 100;
            const int FIFTY = 50;

            Touch touch = Input.GetTouch(0);

            if(touch.deltaPosition.x > HUNDRED && touch.deltaPosition.y < FIFTY) {
                Debug.Log("����� � �����");
            }

            if(touch.deltaPosition.x < -HUNDRED && touch.deltaPosition.y > -FIFTY) {
                Debug.Log("����� � ����");
            }
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void Task_2() {
        if(Input.touchCount > 1) {
            Touch oldTouch1 = Input.GetTouch(0); // ��������� ����� ������� 1 (����� 1)
            Touch oldTouch2 = Input.GetTouch(1); // ��������� ����� ������� 2 (����� 2)

            Touch newTouch1 = Input.GetTouch(0);
            Touch newTouch2 = Input.GetTouch(1);
            // �� ������ ������ � ������ ����� �������� ������.
            if(newTouch2.phase == TouchPhase.Began) {
                oldTouch2 = newTouch2;
                oldTouch1 = newTouch1;
                return;
            }
            // ���������� ���������� ����� ������� ����� ������� � ���������� ����� ������ ����� �������
            float oldDistance = Vector2.Distance(oldTouch1.position, oldTouch2.position);
            float newDistance = Vector2.Distance(newTouch1.position, newTouch2.position);

            // ������� ����� ����� ������������, ������������� �������� �������� ���������� �������� �����, ������������� �������� �������� ���������� �������� �����
            float offset = newDistance - oldDistance;

            if(offset > 0) {
                Debug.Log("���� ����������");
            } else {
                Debug.Log("���� �����������");
            }
        }
    }


    private void Lesson() {
        if(Input.touchCount > 0) {
            // Debug.Log("���� ������� �� ������");

            // Debug.Log($"����������� ������� ������ ��� ������� ������� ��������� ������ �������� = {Input.touchCount}");

            Touch touch = Input.GetTouch(0); // ���������� ������ � ������� �� ����������� ���������. 0 = ������ ������������ �������

            //  Debug.Log($"������� ������� = {touch.position}");

            //if(touch.deltaPosition.x > 0) {
            //    Debug.Log($"����� �� �����");
            //}

            //if(touch.deltaPosition.x < 0) {
            //    Debug.Log($"����� �� ����");
            //}

            //-----------------------------------------------------------------------------------

            // ���� ������ �������� � touch.phase
            // 
            // TouchPhase.Began - ������ �������
            // TouchPhase.Moved - ������� ������ ����������
            // TouchPhase.Stationary - ������� ������ �� �������
            // TouchPhase.Ended - ����� ��� ������ ��� �����
            // TouchPhase.Canceled - ������� �������� �����

            if(touch.phase == TouchPhase.Began) {
                // ������������ ������ ������ ����
                Debug.Log("Ta�");
            }
        }
    }
}
