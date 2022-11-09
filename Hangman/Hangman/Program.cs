using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Hanged Man";
            GameStartupMenu();

            string[] hangman = HangmanCharachter();
            string[] wordsDictionary = Dictionary();

            string randomWord;
            char[] blankSpaces, wordSplit;
            GeneratingGame(wordsDictionary, out randomWord, out blankSpaces, out wordSplit);

            bool isHanged = GameLogic(hangman, randomWord, blankSpaces, wordSplit);
            EndGameGreetings(randomWord, isHanged);
        }

        private static void EndGameGreetings(string randomWord, bool isHanged)
        {
            if (isHanged)
            {
                Console.WriteLine("\nYou died!");
                Console.WriteLine($"Your word was: {randomWord}");
            }
            else
            {
                Console.WriteLine("\nCongrats you won!");
                Console.WriteLine("Thanks for playing.");
            }
        }

        private static bool GameLogic(string[] hangman, string randomWord, char[] blankSpaces, char[] wordSplit)
        {
            int lives = 6;
            bool isHanged = false;
            List<char> guessedLetters = new List<char>();
            //Game logic
            while (lives >= 0)
            {
                bool isGuessed = false;

                if (lives == 0)
                {
                    isHanged = true;
                }

                Console.Write("\nEnter a letter: ");
                char letterGuess = char.Parse(Console.ReadLine().ToLower());

                if (guessedLetters.Contains(letterGuess))
                {
                    Console.WriteLine("\nThis letter was already guessed!");
                    Console.WriteLine("Try another one.");
                    Console.WriteLine("No lives have been taken away.\n");

                    isGuessed = true;
                }

                if (letterGuess >= 0 && letterGuess <= 64 || letterGuess >= 91 && letterGuess <= 96 || letterGuess >= 123 && letterGuess <= 127)
                {
                    Console.WriteLine("\nYour input was wrong! Only letters from the latin alphabet are allowed");
                    Console.WriteLine("Your lives remain the same.\n");
                    continue;
                }
                //Writing blank spaces/ already guessed letters
                if (wordSplit.Contains(letterGuess))
                {
                    for (int i = 0; i < randomWord.Length; i++)
                    {
                        if (wordSplit[i] == letterGuess)
                        {
                            blankSpaces[i] = letterGuess;
                        }
                    }

                    if (!isGuessed)
                    {
                        guessedLetters.Add(letterGuess);
                        Console.WriteLine(String.Join(" ", blankSpaces));
                    }
                    else
                    {
                        Console.Write("Your guessed letter are: ");
                        Console.WriteLine(String.Join(", ", guessedLetters));
                    }
                }
                else if (!wordSplit.Contains(letterGuess))
                {
                    //Drawing and taking lives out
                    switch (lives)
                    {
                        case 6:
                            Console.WriteLine(hangman[0]);
                            break;
                        case 5:
                            Console.WriteLine(hangman[1]);
                            break;
                        case 4:
                            Console.WriteLine(hangman[2]);
                            break;
                        case 3:
                            Console.WriteLine(hangman[3]);
                            break;
                        case 2:
                            Console.WriteLine(hangman[4]);
                            break;
                        case 1:
                            Console.WriteLine(hangman[5]);
                            break;
                        case 0:
                            Console.WriteLine(hangman[6]);
                            break;

                        default:
                            break;
                    }
                    lives--;
                    Console.WriteLine(String.Join(" ", blankSpaces));

                }
            }

            return isHanged;
        }

        private static void GameStartupMenu()
        {
            string input = string.Empty;
            string currentMenu = string.Empty;

            while (input != "1" || input != "Start game" || input != "5" || input != "Exit")
            {
                string welcome = "HANG - MAN";
                string creator = "MADE BY: Bozhidar Yordanov_2022";
                //Game name
                Console.SetCursorPosition((Console.WindowWidth - welcome.Length) / 2, Console.CursorTop);
                Console.WriteLine(welcome);
                //Creator
                Console.SetCursorPosition((Console.WindowWidth - creator.Length) / 2, Console.CursorTop);
                Console.WriteLine(creator);
                //Main menu
                Console.WriteLine("\n1. Start game");
                Console.WriteLine("2. Choose dificulty(not working)");
                Console.WriteLine("3. How to play?");
                Console.WriteLine("4. Music");
                Console.WriteLine("5. Settings");
                Console.WriteLine("6. Exit");

                Console.WriteLine("\n1 - Start game, 2 - How to play?, 3 - Music, 4 - Settings, 5 - Exit");
                Console.WriteLine("=====================================================================");

                input = Console.ReadLine();
                //Game start
                if (input == "1" || input == "Start game")
                {
                    Console.Clear();

                    string gameState = "IN-GAME";
                    Console.SetCursorPosition((Console.WindowWidth - gameState.Length) / 2, Console.CursorTop);
                    Console.WriteLine(gameState);

                    break;
                }
                //Choosing dificutlty(not working)
                else if (input == "2" || input == "Choose difficulty")
                {

                }
                //How to play
                else if (input == "3" || input == "How to play")
                {
                    Console.Clear();

                    Console.SetCursorPosition((Console.WindowWidth - welcome.Length) / 2, Console.CursorTop);
                    Console.WriteLine(currentMenu = "HOW TO PLAY");

                    Console.WriteLine("\nOne player thinks of a word and" +
                        "\r\nthe other tries to guess it by guessing" +
                        "\r\nletters. Each incorrect guess brings you" +
                        "\r\ncloser to being \"hanged.\" This game" +
                        "\r\nhelps to sharpen children’s spelling and\r\nword-decoding skills. ");

                    Console.WriteLine("\nPress any key to go back to main menu.");
                    Console.ReadKey();
                    Console.Clear();
                }
                //Music - To be featured
                else if (input == "4" || input == "Music")
                {

                }
                //Settings
                else if (input == "5" || input == "Settings")
                {
                    string settingCommands = string.Empty;
                    //Setting menu
                    while (settingCommands != "2" || settingCommands != "Back to main menu")
                    {
                        Console.Clear();

                        Console.SetCursorPosition((Console.WindowWidth - welcome.Length) / 2, Console.CursorTop);
                        Console.WriteLine(currentMenu = "SETTINGS");

                        Console.WriteLine("1. Choose foreground(letters) color");
                        Console.WriteLine("2. Choose background color");
                        Console.WriteLine("3. Back to main menu");

                        settingCommands = string.Empty;

                        settingCommands = Console.ReadLine();
                        //Changing foreground color
                        if (settingCommands == "1" || settingCommands == "Choose color")
                        {
                            while (true)
                            {
                                Console.Clear();

                                Console.SetCursorPosition((Console.WindowWidth - welcome.Length) / 2, Console.CursorTop);
                                Console.WriteLine(currentMenu = "FOREGROUND COLOR");

                                Console.WriteLine("1. -- Red");
                                Console.WriteLine("2. -- Green");
                                Console.WriteLine("3. -- Yellow");
                                Console.WriteLine("4. -- Dark Yellow");
                                Console.WriteLine("5. -- Cyan");
                                Console.WriteLine("6. -- White");
                                Console.WriteLine("7. -- Default");
                                Console.WriteLine("\n8. Exit");

                                string consoleColor = Console.ReadLine();

                                if (consoleColor == "8")
                                {
                                    break;
                                }

                                switch (consoleColor)
                                {
                                    case "1":
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        break;
                                    case "2":
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        break;
                                    case "3":
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        break;
                                    case "4":
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        break;
                                    case "5":
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        break;
                                    case "6":
                                        Console.ForegroundColor = ConsoleColor.White;
                                        break;
                                    case "7":
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        break;
                                    default:
                                        break;
                                }

                            }
                        }
                        //Changing background color
                        else if (settingCommands == "2" || settingCommands == "Background color")
                        {

                            while (true)
                            {
                                Console.Clear();

                                Console.SetCursorPosition((Console.WindowWidth - welcome.Length) / 2, Console.CursorTop);
                                Console.WriteLine(currentMenu = "BACKGROUND COLOR");

                                Console.WriteLine("1. -- Red");
                                Console.WriteLine("2. -- Green");
                                Console.WriteLine("3. -- Yellow");
                                Console.WriteLine("4. -- Dark Yellow");
                                Console.WriteLine("5. -- Cyan");
                                Console.WriteLine("6. -- Magenta");
                                Console.WriteLine("7. -- Dark Gray");
                                Console.WriteLine("8. -- Default");
                                Console.WriteLine("\n9. Exit");

                                string consoleColor = Console.ReadLine();

                                if (consoleColor == "9")
                                {
                                    break;
                                }

                                switch (consoleColor)
                                {
                                    case "1":
                                        Console.BackgroundColor = ConsoleColor.Red;
                                        break;
                                    case "2":
                                        Console.BackgroundColor = ConsoleColor.Green;
                                        break;
                                    case "3":
                                        Console.BackgroundColor = ConsoleColor.Yellow;
                                        break;
                                    case "4":
                                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                                        break;
                                    case "5":
                                        Console.BackgroundColor = ConsoleColor.Cyan;
                                        break;
                                    case "6":
                                        Console.BackgroundColor = ConsoleColor.Magenta;
                                        break;
                                    case "7":
                                        Console.BackgroundColor = ConsoleColor.DarkGray;
                                        break;
                                    case "8":
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        //Back to main menu
                        else if (settingCommands != "3" || settingCommands != "Back to main menu")
                        {
                            Console.Clear();
                            break;
                        }

                    }
                }
                //Exit the game
                else if (input == "6" || input == "Exit")
                {
                    System.Environment.Exit(0);
                }


            }
        }

        private static void GeneratingGame(string[] wordsDictionary, out string randomWord, out char[] blankSpaces, out char[] wordSplit)
        {
            //Generating random Word
            Random random = new Random();
            randomWord = wordsDictionary[random.Next(wordsDictionary.Length)];

            //AddingBlank spaces
            blankSpaces = new char[randomWord.Length];

            //Word Spliting to letters
            wordSplit = new char[randomWord.Length];
            for (int i = 0; i < randomWord.Length; i++)
            {
                blankSpaces[i] = '_';
                Console.Write("_ ");
                wordSplit[i] = randomWord[i];
            }
        }

        private static string[] HangmanCharachter()
        {
            return new string[] { "\r\n  +---+\r\n  |   |\r\n      |\r\n      |\r\n      |\r\n      |\r\n========= "
                ,"\r\n  +---+\r\n  |   |\r\n  O   |\r\n      |\r\n      |\r\n      |\r\n========= "
                ,"\r\n  +---+\r\n  |   |\r\n  O   |\r\n  |   |\r\n      |\r\n      |\r\n========= "
                ,"\r\n  +---+\r\n  |   |\r\n  O   |\r\n /|   |\r\n      |\r\n      |\r\n========= "
                ,"\r\n  +---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n      |\r\n      |\r\n========= "
                ,"\r\n  +---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n /    |\r\n      |\r\n========= "
                ,"\r\n  +---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n / \\  |\r\n      |\r\n=========" };
        }

        private static string[] Dictionary()
        {
            return new string[]{"able", "about","account","acid","across","act","addition"
                              + "adjustment","advertisement","after","again","against","agreement","air"
                              + "all","almost","among","amount","amusement","and","angle","angry","animal"
                              + "answer","ant","any","apparatus","apple","approval","arch","argument","arm"
                              + "army","art","as","at","attack","attempt","attention","attraction","authority"
                              + "automatic","awake","baby","back","bad","bag","balance","ball","band","base"
                              + "basin","basket","bath","be","beautiful","because","bed","bee","before","behaviour"
                              + "belief","bell","bent","berry","between","bird","birth","bit","bite","bitter","black"
                              + "blade","blood","blow","blue","board","boat","body","boiling","bone","book","boot","bottle"
                              + "box","boy","brain","brake","branch","brass","bread","breath","brick","bridge","bright","broken"
                              + "brother","brown","brush","bucket","building","bulb","burn","burst","business","but","butter","button"
                              + "by","cake","camera","canvas","card","care","carriage","cart","cat","cause","certain","chain","chalk","chance"
                              + "change","cheap","cheese","chemical","chest","chief","chin","church","circle","clean","clear","clock","cloth\r"
                              + "ncloud","coal","coat","cold","collar","colour","comb","come","comfort","committee","common","company","comparison"
                              + "competition","complete","complex","condition","connection","conscious","control","cook","copper","copy","cord","cork"
                              + "cotton","cough","country","cover","cow","crack","credit","crime","cruel","crush","cry","cup","cup","current","curtain"
                              + "curve","cushion","damage","danger","dark","daughter","day","dead","dear","death","debt","decision","deep","degree","delicate"
                              + "dependent","design","desire","destruction","detail","development","different","digestion","direction","dirty","discovery"
                              + "discussion","disease","disgust","distance","distribution","division","do","dog","door","doubt","down","drain","drawer","dress"
                              + "drink","driving","drop","dry","dust","ear","early","earth","east","edge","education","effect","egg","elastic","electric","end"
                              + "engine","enough","equal","error","even","event","ever","every","example","exchange","existence","expansion","experience","expert"
                              + "eye","face","fact","fall","false","family","far","farm","fat","father","fear","feather","feeble","feeling","female","fertile"
                              + "fiction","field","fight","finger","fire","first","fish","fixed","flag","flame","flat","flight","floor","flower","fly","fold"
                              + "food","foolish","foot","for","force","fork","form","forward","fowl","frame","free","frequent","friend","from","front","fruit"
                              + "full","future","garden","general","get","girl","give","glass","glove","go","goat","gold","good","government","grain","grass"
                              + "great","green","grey","grip","group","growth","guide","gun","hair","hammer","hand","hanging","happy","harbour","hard","harmony"
                              + "hat","hate","have","he","head","healthy","hear","hearing","heart","heat","help","high","history","hole","hollow","hook","hope"
                              + "horn","horse","hospital","hour","house","how","humour","I","ice","idea","if","ill","important","impulse","in","increase","industry"
                              + "ink","insect","instrument","insurance","interest","invention","iron","island","jelly","jewel","join","journey","judge","jump","keep"
                              + "kettle","key","kick","kind","kiss","knee","knife","knot","knowledge","land","language","last","late","laugh","law","lead","leaf","learning"
                              + "leather","left","leg","let","letter","level","library","lift","light","like","limit","line","linen","lip","liquid","list","little","living"
                              + "lock","long","look","loose","loss","loud","love","low","machine","make","male","man","manager","map","mark","market","married","mass","match"
                              + "material","may","meal","measure","meat","medical","meeting","memory","metal","middle","military","milk","mind","mine","minute","mist","mixed","money"
                              + "monkey","month","moon","morning","mother","motion","mountain","mouth","move","much","muscle","music","nail","name","narrow","nation","natural","near"
                              + "necessary","neck","need","needle","nerve","net","new","news","night","no","noise","normal","north","nose","not","note","now","number","nut","observation"
                              + "of","off","offer","office","oil","old","on","only","open","operation","opinion","opposite","or","orange","order","organization","ornament","other","out","oven"
                              + "over","owner","page","pain","paint","paper","parallel","parcel","part","past","paste","payment","peace","pen","pencil","person","physical","picture","pig","pin"
                              + "pipe","place","plane","plant","plate","play","please","pleasure","plough","pocket","point","poison","polish","political","poor","porter","position","possible","pot"
                              + "potato","powder","power","present","price","print","prison","private","probable","process","produce","profit","property","prose","protest","public","pull","pump","punishment"
                              + "purpose","push","put","quality","question","quick","quiet","quite","rail","rain","range","rat","rate","ray","reaction","reading","ready","reason","receipt","record","red","regret"
                              + "regular","relation","religion","representative","request","respect","responsible","rest","reward","rhythm","rice","right","ring","river","road","rod","roll","roof","room","root","rough"
                              + "round","rub","rule","run","sad","safe","sail","salt","same","sand","say","scale","school","science","scissors","screw","sea","seat","second","secret","secretary","see","seed","seem"
                              + "selection","self","send","sense","separate","serious","servant","sex","shade","shake","shame","sharp","sheep","shelf","ship","shirt","shock","shoe","short","shut","side","sign","silk","silver"
                              + "simple","sister","size","skin","skirt","sky","sleep","slip","slope","slow","small","smash","smell","smile","smoke","smooth","snake","sneeze","snow","so","soap","society","sock","soft","solid"
                              + "some","son","song","sort","sound","soup","south","space","spade","special","sponge","spoon","spring","square","stage","stamp","star","start","statement","station","steam","steel","stem","step"
                              + "stick","sticky","stiff","still","stitch","stocking","stomach","stone","stop","store","story","straight","strange","street","stretch","strong","structure","substance","such","sudden","sugar","suggestion"
                              + "summer","sun","support","surprise","sweet","swim","system","table","tail","take","talk","tall","taste","tax","teaching","tendency","test","than","that","the","then","theory","there","thick","thin","thing"
                              + "this","thought","thread","throat","through","through","thumb","thunder","ticket","tight","till","time","tin","tired","to","toe","together","tomorrow","tongue","tooth","top","touch","town","trade","train"
                              + "transport","tray","tree","trick","trouble","trousers","true","turn","twist","umbrella","under","unit","up","use","value","verse","very","vessel","view","violent","voice","waiting","walk","wall","war","warm"
                              + "wash","waste","watch","water","wave","wax","way","weather","week","weight","well","west","wet","wheel","when","where","while","whip","whistle","white","who","why","wide","will","wind","window","wine","wing"
                              + "winter","wire","wise","with","woman","wood","wool","word","work","worm","wound","writing","wrong","year","yellow","yes","yesterday","you","young","Bernhard","Breytenbach","Android" };
        }
    }
}

