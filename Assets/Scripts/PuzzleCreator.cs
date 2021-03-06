﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PuzzleCreator : MonoBehaviour {
  public GameObject question;
  public GameObject answerPanel;
  public GameObject letterPanel;
  public GameObject answerSlotPrefab;
  public GameObject letterSlotPrefab;

  

  void Awake(){
    var question_answer = GetPuzzle(Random.Range(1,4));
    question.GetComponent<Text>().text = question_answer[0];
    var answer = question_answer[1];
    char[] answer_letters = answer.ToCharArray();
    var puzzle_word = answer; 
    PlayerPrefs.SetString("answer", answer);

    var count = 0;
    while(count < 1) {
      puzzle_word += ((char)('A' + Random.Range (0,26)));
      count++;
    }
    char[] puzzle_letters = puzzle_word.ToCharArray();

    



    for (var i = puzzle_letters.Length - 1; i > 0; i--) {
            var r = Random.Range(0,i);
            var tmp = puzzle_letters[i];
            puzzle_letters[i] = puzzle_letters[r];
            puzzle_letters[r] = tmp;
        }

    foreach (char answer_letter in answer_letters) {
      GameObject answer_slot = Instantiate(answerSlotPrefab);
      answer_slot.transform.SetParent(answerPanel.transform);
      answer_slot.transform.localScale = new Vector3( 1.0f, 1.0f, 1.0f );
      answer_slot.transform.localPosition = Vector3.zero;
    }



    foreach (char puzzle_letter in puzzle_letters) {
      GameObject letter_slot = Instantiate(letterSlotPrefab);
      letter_slot.GetComponentInChildren<Text>().text = puzzle_letter.ToString();
      letter_slot.transform.SetParent(letterPanel.transform);
      letter_slot.transform.localScale = new Vector3( 1.0f, 1.0f, 1.0f );
      letter_slot.transform.localPosition = Vector3.zero;
    }


   
    
  }

  public void Skip(){
        Application.LoadLevel(RandomFact());


  }

  string RandomFact() {
    int fact_no = Random.Range(1,4);
    string fact_level_name;
    switch(fact_no) {
      case 1:
        fact_level_name = "fact1";
        break;

      case 2:
        fact_level_name = "fact2";
        break;

      case 3:
        fact_level_name = "fact3";
        break;

      case 4:
        fact_level_name = "fact4";
        break;

      default:
        fact_level_name = "fact1";
        break;

    }
    return fact_level_name;
  }
  public string[] GetPuzzle(int id) {
    string[] ques = new string[2];
    switch(id) {
      case 1:
        ques[0] = "Dairy products are generally made from \nwhat liquid?";
        ques[1] = "MILK";
        break;
      case 2:
        ques[0] = "What fruit a day keeps the doctor's away?";
        ques[1] = "APPLE";
        break;
      case 3:
        ques[0] = "Which country is the world’s largest \nproducer of bananas?";
        ques[1] = "INDIA";
        break;
      case 4:
        ques[0] = "This fruit is rich in Vitamin C";
        ques[1] = "ORANGE";
        break;
      
      default:
        ques[0] = "Dairy products are generally made from \nwhat liquid?";
        ques[1] = "MILK";
        break;

    }
    return ques;
  }


}
