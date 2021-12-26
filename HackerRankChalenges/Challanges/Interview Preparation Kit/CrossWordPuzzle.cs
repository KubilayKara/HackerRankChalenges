using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankChalenges.Challanges.Interview_Preparation_Kit
{
    class CrossWordPuzzle : Chalange
    {
        public override void SetParameters()
        {
            this.url = "https://www.hackerrank.com/challenges/crossword-puzzle/problem?isFullScreen=true&h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=recursion-backtracking&h_r=next-challenge&h_v=zen";
            this.ChalangeParameters = new List<ChalengeParameter>();
            this.ButtonText = typeof(CrossWordPuzzle).Name;
        }
        public override string Run(string[] parameters)
        {
            List<string> crossword = new List<string>() {   "+-++++++++",
                                                            "+-++++++++",
                                                            "+-++++++++",
                                                            "+-----++++",
                                                            "+-+++-++++",
                                                            "+-+++-++++",
                                                            "+++++-++++",
                                                            "++------++",
                                                            "+++++-++++",
                                                            "+++++-++++" };
            string words = "LONDON;DELHI;ICELAND;ANKARA";

            return crosswordPuzzle(crossword, words).ToString();
        }






        public static List<string> crosswordPuzzle(List<string> crossword, string words)
        {
            Dictionary<int, List<string>> wordDict = GetWordDict(words);

            int width = crossword[0].Length;
            int length = crossword.Count();
            Letter[,] letterMatris = new Letter[length, width];
            List<Word> wordList = new List<Word>();
            for (int rowIndex = 0; rowIndex < crossword.Count; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < crossword[rowIndex].Length; columnIndex++)
                {
                    if (crossword[rowIndex][columnIndex] != '-')
                    {
                        continue;
                    }

                    Letter newLetter = new Letter();
                    letterMatris[rowIndex, columnIndex] = newLetter;

                    //find and set diagonal word
                    Word horizontalWord;
                    if (columnIndex > 0 && letterMatris[rowIndex, columnIndex - 1] != null)
                    {
                        horizontalWord = letterMatris[rowIndex, columnIndex - 1].HorizontalWord;
                    }
                    else
                    {
                        horizontalWord = new Word(rowIndex, columnIndex);
                        wordList.Add(horizontalWord);
                    }
                    newLetter.HorizontalWord = horizontalWord;
                    horizontalWord.Letters.Add(newLetter);

                    //find and set vertical word
                    Word verticalWord;
                    if (rowIndex > 0 && letterMatris[rowIndex - 1, columnIndex] != null)
                    {
                        verticalWord = letterMatris[rowIndex - 1, columnIndex].VerticalWord;
                    }
                    else
                    {
                        verticalWord = new Word(rowIndex, columnIndex);
                        verticalWord.IsVertical = true;
                        wordList.Add(verticalWord);
                    }
                    newLetter.VerticalWord = verticalWord;
                    verticalWord.Letters.Add(newLetter);


                }
            }

            wordList = wordList.Where(w => w.IsValid).ToList();
            List<string> result = GetResult(crossword, letterMatris);
            return result;
        }



        private static Dictionary<int, List<string>> GetWordDict(string words)
        {
            string[] wordArray = words.Split(";");
            Dictionary<int, List<string>> wordDict = new Dictionary<int, List<string>>();
            foreach (var word in wordArray)
            {
                int wordLength = word.Length;
                if (!wordDict.ContainsKey(wordLength))
                    wordDict[wordLength] = new List<string>();
                wordDict[wordLength].Add(word);
            }
            return wordDict;
        }

        private static List<string> GetResult(List<string> crossword, Letter[,] letterMatris)
        {
            List<string> result = new List<string>();
            for (int rowIndex = 0; rowIndex < crossword.Count; rowIndex++)
            {
                string res = string.Empty;
                for (int columnIndex = 0; columnIndex < crossword[rowIndex].Length; columnIndex++)
                {
                    res += (letterMatris[rowIndex, columnIndex] == null) ? "+" : letterMatris[rowIndex, columnIndex].Value;
                }
                result.Add(res);
            }

            return result;
        }
    }

    public class Letter
    {
        public char Value { get; set; }
        public Word HorizontalWord { get; set; }
        public Word VerticalWord { get; set; }

        public override string ToString()
        {
            return this.Value.ToString(); 
        }
    }

    public class Word
    {
        public List<Letter> Letters { get; private set; }
        public int StartRow { get; set; }
        public int StartColumn { get; set; }

        public bool IsVertical { get; set; }
        public Word(int startRow, int startColumn)
        {
            StartRow = startRow;
            StartColumn = startColumn;
            this.Letters = new List<Letter>();
        }


        public bool IsValid
        {
            get
            {
                return this.Letters.Count > 1;
            }
        }

    }
}
