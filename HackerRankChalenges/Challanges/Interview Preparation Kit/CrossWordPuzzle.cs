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
            List<string> crossword;
            string words;
            GetInputs_Case6(out crossword, out words);

            return crosswordPuzzle(crossword, words).ToString();
        }

        private static void GetInputs(out List<string> crossword, out string words)
        {
            crossword = new List<string>() {   "+-++++++++",
                                                            "+-++++++++",
                                                            "+-++++++++",
                                                            "+-----++++",
                                                            "+-+++-++++",
                                                            "+-+++-++++",
                                                            "+++++-++++",
                                                            "++------++",
                                                            "+++++-++++",
                                                            "+++++-++++" };
            words = "LONDON;DELHI;ICELAND;ANKARA";
        }
                private static void GetInputs_Case6(out List<string> crossword, out string words)
        {




            crossword = new List<string>() {   "+-++++++++",
                                                    "+-------++",
                                                    "+-++-+++++",
                                                    "+-------++",
                                                    "+-++-++++-",
                                                    "+-++-++++-",
                                                    "+-++------",
                                                    "+++++++++-",
                                                    "++++++++++",
                                                    "++++++++++" };
            words = "ANDAMAN; MANIPUR; ICELAND; ALLEPY; YANGON; PUNE";
        }

        public static List<string> crosswordPuzzle(List<string> crossword, string words)
        {
            Dictionary<int, List<WordCanditate>> wordCandidateDict = GetCandidateWordDict(words);

            int width = crossword[0].Length;
            int length = crossword.Count();
            Letter[,] letterMatris = new Letter[length, width];
            List<Word> wordList = new List<Word>();
            CreateWordList(crossword, letterMatris, wordList);

            wordList = wordList.Where(w => w.IsValid).ToList();
            FillLetters(wordList, wordCandidateDict);

            List<string> result = GetResult(crossword, letterMatris);
            return result;
        }

        private static void FillLetters(List<Word> wordList, Dictionary<int, List<WordCanditate>> wordCandidateDict)
        {
            int index = 0;
            foreach (var word in wordList)
            {
                SetWord(word, wordCandidateDict, ref index);
            }
        }

        private static bool SetWord(Word word, Dictionary<int, List<WordCanditate>> wordCandidateDict, ref int index)
        {
            index++;
            if (word.FillIndex > 0 && word.FillIndex < index)//allready filled
                return true;
            foreach (var wordCandidate in wordCandidateDict[word.Letters.Count])
            {
                if (wordCandidate.UsingIndex > 0 && wordCandidate.UsingIndex < index) //an used word
                    continue;
                bool cadidateResult = true;
                List<Word> relatedWords;
                if (TryToFill(word, wordCandidate.Value, index, out relatedWords))
                {
                    word.FillIndex = index;
                    foreach (var relatedWord in relatedWords)
                    {
                        if (relatedWord.FillIndex > 0 && relatedWord.FillIndex < index)
                            continue;//allready filled


                        cadidateResult = SetWord(relatedWord, wordCandidateDict, ref index);
                        if (!cadidateResult)
                            break;//look for nexCandidate
                    }
                    if (cadidateResult)
                    {
                        wordCandidate.UsingIndex = index;
                        return true;
                    }
                }
            }
            index--;
            return false;
        }


        
        public static bool TryToFill(Word word, string s, int index, out List<Word> relatedWords)
        {
            relatedWords = new List<Word>();

            for (int i = 0; i < word.Letters.Count; i++)
            {
                Letter letter = word.Letters[i];
                if (letter.Value != new char() && letter.Value != s[i] && letter.UsingIndex < index)
                {
                    relatedWords = new List<Word>();
                    return false;
                }

                //set relatedWords
                if (word.IsVertical)
                {
                    if (letter.HorizontalWord.IsValid)
                        relatedWords.Add(letter.HorizontalWord);
                }
                else
                {
                    if (letter.VerticalWord.IsValid)
                        relatedWords.Add(letter.VerticalWord);
                }


                letter.Value = s[i];
                letter.UsingIndex = index;
            }
            return true;


        }
        private static void CreateWordList(List<string> crossword, Letter[,] letterMatris, List<Word> wordList)
        {
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
        }

        private static Dictionary<int, List<WordCanditate>> GetCandidateWordDict(string words)
        {
            string[] wordArray = words.Split(';');
            Dictionary<int, List<WordCanditate>> wordDict = new Dictionary<int, List<WordCanditate>>();
            foreach (var word in wordArray)
            {
                string w = word.Trim();
                int wordLength = w.Length;
                if (!wordDict.ContainsKey(wordLength))
                    wordDict[wordLength] = new List<WordCanditate>();
                wordDict[wordLength].Add(new WordCanditate(w));
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
                    res += (letterMatris[rowIndex, columnIndex] == null) ? '+' : letterMatris[rowIndex, columnIndex].Value;
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

        public int UsingIndex { get; set; }
        public override string ToString()
        {
            return (this.Value == '\0') ? "_" : this.Value.ToString();
        }
    }

    public class Word
    {
        public List<Letter> Letters { get; private set; }
        public int FillIndex { get; set; }

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
        public override string ToString()
        {
            string result = string.Empty;
            foreach (var item in Letters)
            {
                result += item.ToString();
            }
            return result;
        }


    }

    public class WordCanditate
    {
        public string Value { get; set; }
        public int UsingIndex { get; set; }
        public override string ToString()
        {
            return this.Value;
        }
        public WordCanditate(string value)
        {
            this.Value = value;
        }
    }
}
