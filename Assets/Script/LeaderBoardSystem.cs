using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
namespace Mike_LeaderBoardSystem
{
    public class LeaderBoardSystem
    {


        private string RecordString="";
        private string dataPath = "";

        Dictionary<string, int> RecordMap = new Dictionary<string, int>();
     

        public LeaderBoardSystem(string dataPath)
        {
            this.dataPath = dataPath;
            string[] UserRecordData = File.ReadAllLines(dataPath+ "\\SaveRecord.txt");
            string[] names =new string[  UserRecordData.Length];
            int[] scores = new int[UserRecordData.Length];
            int index = 0;

            foreach (string s in UserRecordData)
            {
                string[] sSplit = s.Split(',');
                names[index] =sSplit[0];
                scores[index ] = Int32.Parse(sSplit[1]);
// RecordMap.Add(name, score);
                index++;

            }
            RecordMap= ScoreSort(names, scores);
        }

        public void setDataPath(string dataPath)
        {
            this.dataPath = dataPath;
        }
        public string getDataPath() { return dataPath; }


        
        public Dictionary<string, int> getRecordMap()
        {
            Debug.Log("HAHA");
            return RecordMap;

        }
        public void SaveScore(string name, int score)
        {
          

            using (StreamWriter sw = File.AppendText(dataPath + "\\SaveRecord.txt"))
            {
                sw.WriteLine(""+name+","+score);
            }



        }

        private Dictionary<string, int> ScoreSort(string[] names, int []  scores)
        {

            int len = names.Length;

            int[] index = new int[len];
            for (int i =0;i<len;i++)
            {
                index[i] = i;    
            }

            for (int i = 0; i < len; i++)
            {
                for (int j = i + 1; j < len; j++)
                {

                    if (scores[i] < scores[j])
                    {
                        int k = index[i];
                        index[i] = index[j];
                        index[j] = k;

                        string kS = names[i];
                        names[i] = names[j];
                        names[j] = kS;

                        k = scores[i];
                        scores[i] = scores[j];
                        scores[j] = k;
                    }

                }

            }
            for (int i =0;i<len;i++)
            {
                if (names[i] == null || scores == null) break;
                RecordMap.Add(names[i], scores[i]);

                Debug.Log("Score" + scores[i]);
            }
            
            return RecordMap;
        }






    }
}
