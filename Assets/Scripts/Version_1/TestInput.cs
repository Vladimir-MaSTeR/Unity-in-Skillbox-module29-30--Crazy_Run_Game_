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
                Debug.Log("Свайп в право");
            }

            if(touch.deltaPosition.x < -HUNDRED && touch.deltaPosition.y > -FIFTY) {
                Debug.Log("Свайп в лево");
            }
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void Task_2() {
        if(Input.touchCount > 1) {
            Touch oldTouch1 = Input.GetTouch(0); // Последняя точка касания 1 (палец 1)
            Touch oldTouch2 = Input.GetTouch(1); // Последняя точка касания 2 (палец 2)

            Touch newTouch1 = Input.GetTouch(0);
            Touch newTouch2 = Input.GetTouch(1);
            // Во втором пункте я только начал касаться экрана.
            if(newTouch2.phase == TouchPhase.Began) {
                oldTouch2 = newTouch2;
                oldTouch1 = newTouch1;
                return;
            }
            // Рассчитать расстояние между старыми двумя точками и расстояние между новыми двумя точками
            float oldDistance = Vector2.Distance(oldTouch1.position, oldTouch2.position);
            float newDistance = Vector2.Distance(newTouch1.position, newTouch2.position);

            // Разница между двумя расстояниями, положительное значение означает увеличение масштаба жеста, отрицательное значение означает увеличение масштаба жеста
            float offset = newDistance - oldDistance;

            if(offset > 0) {
                Debug.Log("Жест увеличение");
            } else {
                Debug.Log("Жест уменьшается");
            }
        }
    }


    private void Lesson() {
        if(Input.touchCount > 0) {
            // Debug.Log("Есть касание на экране");

            // Debug.Log($"Колличество касаний экрана или сколько пальцев коснулось экрана телефона = {Input.touchCount}");

            Touch touch = Input.GetTouch(0); // возвращает данные о касании по переданному аргументу. 0 = первое историческое касание

            //  Debug.Log($"Позиция касания = {touch.position}");

            //if(touch.deltaPosition.x > 0) {
            //    Debug.Log($"Свайп на право");
            //}

            //if(touch.deltaPosition.x < 0) {
            //    Debug.Log($"Свайп на лево");
            //}

            //-----------------------------------------------------------------------------------

            // Фазы инпута хранятся в touch.phase
            // 
            // TouchPhase.Began - только начался
            // TouchPhase.Moved - позиция пальца изменилась
            // TouchPhase.Stationary - позиция пальца не изменна
            // TouchPhase.Ended - палец был только что убран
            // TouchPhase.Canceled - система отменила инпут

            if(touch.phase == TouchPhase.Began) {
                // регистрируем только начало тапа
                Debug.Log("Taп");
            }
        }
    }
}
