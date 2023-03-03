using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField]
    private MazeNode _nodePrefab;

    [SerializeField]
    private Vector2Int _mazeSize;

    private void Start() {
        GenerateMazeInstant(_mazeSize);
        //StartCoroutine(GenerateMaze(_mazeSize));
    }

     private void GenerateMazeInstant(Vector2Int size) {
        List<MazeNode> nodes = new List<MazeNode>();

        //создание узлов
        for(int x = 0; x < size.x; x++) {
            for(int y = 0; y < size.y; y++) {
                Vector3 nodePos = new Vector3(x - (size.x / 2f), 0, y - (size.y / 2f));
                MazeNode newNode = Instantiate(_nodePrefab, nodePos, Quaternion.identity, transform);
                nodes.Add(newNode);
            }
        }

        List<MazeNode> currenPath = new List<MazeNode>();
        List<MazeNode> completedNodes = new List<MazeNode>();

        //выбор начального узла
        currenPath.Add(nodes[Random.Range(0, nodes.Count)]);
        currenPath[0].SetState(NodeState.CURRENT);
        
        //currenPath[currenPath.Count - 1].SetState(NodeState.COMPLETED); //эксперементировал

        while(completedNodes.Count < nodes.Count) {
            //проверяем есть ли соседний узел
            List<int> possibleNextNode = new List<int>();  // список возможных следующих узлов
            List<int> possibleDirection = new List<int>(); // список возможных направлений

            var currentNodeIndex = nodes.IndexOf(currenPath[currenPath.Count - 1]);
            var currentNodeX = currentNodeIndex / size.y;
            var currentNodeY = currentNodeIndex % size.y;

            if(currentNodeX < size.x - 1) {
                //проверка с права
                if(!completedNodes.Contains(nodes[currentNodeIndex + size.y]) &&
                   !currenPath.Contains(nodes[currentNodeIndex + size.y])) {
                    
                    possibleDirection.Add(1);
                    possibleNextNode.Add(currentNodeIndex + size.y);
                }
            }
            if(currentNodeX > 0) {
                //проверка с лева
                if(!completedNodes.Contains(nodes[currentNodeIndex - size.y]) &&
                   !currenPath.Contains(nodes[currentNodeIndex - size.y])) {

                    possibleDirection.Add(2);
                    possibleNextNode.Add(currentNodeIndex - size.y);
                }
            }

            if(currentNodeY < size.y - 1) {
                //проверка с верху
                if(!completedNodes.Contains(nodes[currentNodeIndex + 1]) &&
                   !currenPath.Contains(nodes[currentNodeIndex + 1])) {

                    possibleDirection.Add(3);
                    possibleNextNode.Add(currentNodeIndex + 1);
                }
            }
            if(currentNodeY > 0) {
                //проверка с низу
                if(!completedNodes.Contains(nodes[currentNodeIndex - 1]) &&
                   !currenPath.Contains(nodes[currentNodeIndex - 1])) {

                    possibleDirection.Add(4);
                    possibleNextNode.Add(currentNodeIndex - 1);
                }
            }

            //Выбор следующего узла
            if(possibleDirection.Count > 0) {
                var chosenDirection = Random.Range(0, possibleDirection.Count);
                MazeNode chosenNode = nodes[possibleNextNode[chosenDirection]];

                switch(possibleDirection[chosenDirection]) { //рушим стены
                    case 1:
                        chosenNode.RemoveWall(1);
                        currenPath[currenPath.Count - 1].RemoveWall(0);
                        break;
                    case 2:
                        chosenNode.RemoveWall(0);
                        currenPath[currenPath.Count - 1].RemoveWall(1);
                        break;
                    case 3:
                        chosenNode.RemoveWall(3);
                        currenPath[currenPath.Count - 1].RemoveWall(2);
                        break;
                    case 4:
                        chosenNode.RemoveWall(2);
                        currenPath[currenPath.Count - 1].RemoveWall(3);
                        break;
                }

                currenPath.Add(chosenNode);
                //chosenNode.SetState(NodeState.CURRENT);
            } else {
                completedNodes.Add(currenPath[currenPath.Count - 1]); // возврат

                //currenPath[currenPath.Count - 1].SetState(NodeState.COMPLETED);
                currenPath.RemoveAt(currenPath.Count - 1);
            }
        }
    }

    //IEnumerator GenerateMaze(Vector2Int size) {
    //    List<MazeNode> nodes = new List<MazeNode>();

    //    //создание узлов
    //    for(int x = 0; x < size.x; x++) {
    //        for(int y = 0; y < size.y; y++) {
    //            Vector3 nodePos = new Vector3(x - (size.x / 2f), 0, y - (size.y / 2f));
    //            MazeNode newNode = Instantiate(_nodePrefab, nodePos, Quaternion.identity, transform);
    //            nodes.Add(newNode);

    //            yield return null;
    //        }
    //    }

    //    List<MazeNode> currenPath = new List<MazeNode>();
    //    List<MazeNode> completedNodes = new List<MazeNode>();

    //    currenPath.Add(nodes[Random.Range(0, nodes.Count)]); //выбор начального узла
    //    currenPath[0].SetState(NodeState.CURRENT);
    //    //currenPath[currenPath.Count - 1].SetState(NodeState.COMPLETED); //эксперементировал

    //    while(completedNodes.Count < nodes.Count) {
    //        //проверяем есть ли соседний узел
    //        List<int> possibleNextNode = new List<int>();  // список возможных следующих узлов
    //        List<int> possibleDirection = new List<int>(); // список возможных направлений

    //        var currentNodeIndex = nodes.IndexOf(currenPath[currenPath.Count - 1]);
    //        var currentNodeX = currentNodeIndex / size.y;
    //        var currentNodeY = currentNodeIndex % size.y;

    //        if(currentNodeX < size.x - 1) {
    //            //проверка с права
    //            if(!completedNodes.Contains(nodes[currentNodeIndex + size.y]) &&
    //               !currenPath.Contains(nodes[currentNodeIndex + size.y])) {

    //                possibleDirection.Add(1);
    //                possibleNextNode.Add(currentNodeIndex + size.y);
    //            }
    //        }
    //        if(currentNodeX > 0) {
    //            //проверка с лева
    //            if(!completedNodes.Contains(nodes[currentNodeIndex - size.y]) &&
    //               !currenPath.Contains(nodes[currentNodeIndex - size.y])) {

    //                possibleDirection.Add(2);
    //                possibleNextNode.Add(currentNodeIndex - size.y);
    //            }
    //        }

    //        if(currentNodeY < size.y - 1) {
    //            //проверка с верху
    //            if(!completedNodes.Contains(nodes[currentNodeIndex + 1]) &&
    //               !currenPath.Contains(nodes[currentNodeIndex + 1])) {

    //                possibleDirection.Add(3);
    //                possibleNextNode.Add(currentNodeIndex + 1);
    //            }
    //        }
    //        if(currentNodeY > 0) {
    //            //проверка с низу
    //            if(!completedNodes.Contains(nodes[currentNodeIndex - 1]) &&
    //               !currenPath.Contains(nodes[currentNodeIndex - 1])) {

    //                possibleDirection.Add(4);
    //                possibleNextNode.Add(currentNodeIndex - 1);
    //            }
    //        }

    //        //Выбор следующего узла
    //        if(possibleDirection.Count > 0) {
    //            var chosenDirection = Random.Range(0, possibleDirection.Count);
    //            MazeNode chosenNode = nodes[possibleNextNode[chosenDirection]];

    //            switch(possibleDirection[chosenDirection]) { //рушим стены
    //                case 1:
    //                    chosenNode.RemoveWall(1);
    //                    currenPath[currenPath.Count - 1].RemoveWall(0);
    //                    break;
    //                case 2:
    //                    chosenNode.RemoveWall(0);
    //                    currenPath[currenPath.Count - 1].RemoveWall(1);
    //                    break;
    //                case 3:
    //                    chosenNode.RemoveWall(3);
    //                    currenPath[currenPath.Count - 1].RemoveWall(2);
    //                    break;
    //                case 4:
    //                    chosenNode.RemoveWall(2);
    //                    currenPath[currenPath.Count - 1].RemoveWall(3);
    //                    break;
    //            }

    //            currenPath.Add(chosenNode);
    //            chosenNode.SetState(NodeState.CURRENT);
    //        } else {
    //            completedNodes.Add(currenPath[currenPath.Count - 1]); // возврат

    //            currenPath[currenPath.Count - 1].SetState(NodeState.COMPLETED);
    //            currenPath.RemoveAt(currenPath.Count - 1);
    //        }

    //        yield return new WaitForSeconds(0.05f);

    //    }

    //}
}