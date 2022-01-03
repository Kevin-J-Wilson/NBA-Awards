using System;
using System.IO;

namespace NBA_Awards
{

    struct nbaData
    {
        public string playerName;
        public string teamName;
        public int rookie;
        public decimal rating;
        public decimal gamesPlayed;
        public decimal minutesPerGame;
        public decimal pointsPerGame;
        public decimal reboundsPerGame;
        public decimal assistsPerGame;
        public decimal shotPercentage;
        public decimal freethrowPercentage;
    }//end struct

    class Program
    {

        static nbaData[] _players;
        static string _filePath = @"C:\Users\Kevin Wilson\Downloads\NBA_DATA.csv";

        static void Main(string[] args)
        {

            do
            {

                //DECLARE NBA DATA TYPE
                PopulatePlayerData();

                //BubbleSort(_players, "pointsPerGame");
                //for (int index = 0; index < _players.Length; index++) {
                //    Console.Write(_players[index].playerName);
                //}//end for
                //Console.WriteLine();
                //Console.WriteLine();
                //BubbleSort(_players, "minutesPerGame");
                //for (int index = 0; index < _players.Length; index++) {
                //    Console.Write(_players[index].playerName);
                //}

                Console.WriteLine("*****Prius Award*****");
                string playerName = GetPriusAward();
                Console.WriteLine(playerName);
                Console.WriteLine();
                //
                Console.WriteLine("*****Gas Guzzler Award*****");
                string playerName1 = GetGasGuzzlerAward();
                Console.WriteLine(playerName1);
                Console.WriteLine();
                //
                Console.WriteLine("*****Foul Target Award*****");
                string playerName2 = GetFoulTargetAward();
                Console.WriteLine(playerName2);
                Console.WriteLine();
                //
                Console.WriteLine("*****Overachiever Award*****");
                Console.WriteLine("The top 5 players above average award based on ratings goes to....");
                GetOverachieverAward();
                Console.WriteLine();
                //
                Console.WriteLine("*****Uncerachiever Award*****");
                Console.WriteLine("The worst of the worst award based on ratings goes to.... ");
                GetUnderachieverAward();
                Console.WriteLine();
                //
                Console.WriteLine("*****On The Fence Award*****");
                //VARIABLES
                string playerName3 = "";
                Console.WriteLine("The most average player based on ratings goes to.... ");
                Console.Write($"On The Fence Award - Average Rating - {CalcRatingAverage():F2} ");
                Console.WriteLine();
                Console.WriteLine($"{playerName3 = GetOnTheFenceAward()}");
                Console.WriteLine();
                //
                Console.WriteLine("*****Bang For Your Buck Award*****");
                string playerName4 = GetBangForYourBuckAward();
                Console.WriteLine(playerName4);
                Console.WriteLine();
                //
                Console.WriteLine("*****Gordon Gekko Award*****");
                GetGordonGekkoAward();
                Console.WriteLine();
                //

                Console.WriteLine("*****Charlie Brown Award*****");
                string[] playerName5 = GetCharlieBrownAward();
                for (int index = 0; index < playerName5.Length; index++)
                {
                    Console.WriteLine(playerName5[index]);
                }//end for
                Console.WriteLine();
                //
                Console.WriteLine("*****Tiger Uppercut Award*****");

                string[] playerName6 = GetTigerUpperCutAward();
                for (int index = 0; index < playerName6.Length; index++)
                {
                    Console.WriteLine(playerName6[index]);
                }//end for
                Console.WriteLine();


            } while (PromptLoop("Run Again [Y/N] "));//PROMPT LOOP TO RUN AGAIN

        }//end main

        //______________MAIN FUNCTIONS___________________

        static string GetPriusAward()
        {

            BubbleSort(_players, "pointsPerGame");

            decimal max = _players[0].pointsPerGame;

            string playerName = "";
            decimal[] perMinuteRating = new decimal[_players.Length];

            for (int index = 0; index < _players.Length; index++)
            {
                if (_players[index].minutesPerGame != 0)
                {
                    perMinuteRating[index] = (36 * _players[index].pointsPerGame) / _players[index].minutesPerGame;
                }//end if
                if (perMinuteRating[index] > max)
                {
                    max = perMinuteRating[index];
                    playerName = _players[index].playerName;
                }//end if
                 //if (_players[index].pointsPerGame > max) {
                 //    max = _players[index].pointsPerGame;
                 //    playerName = _players[index].playerName;
                 //}//end if
            }//end for

            return playerName;

        }//end function
        static string GetGasGuzzlerAward()
        {

            BubbleSort(_players, "pointsPerGame");
            decimal min = _players[0].pointsPerGame;
            string playerName = "";
            decimal[] perMinuteRating = new decimal[_players.Length];

            for (int index = 0; index < _players.Length; index++)
            {
                if (_players[index].minutesPerGame != 0)
                {
                    perMinuteRating[index] = (36 * _players[index].pointsPerGame) / _players[index].minutesPerGame;
                }//end if
                if (perMinuteRating[index] <= min)
                {
                    min = perMinuteRating[index];
                    playerName = _players[index].playerName;
                }//end if
                 //if (_players[index].pointsPerGame <= min) {
                 //    min = _players[index].pointsPerGame;
                 //    playerName = _players[index].playerName;
                 //}//end if
            }//end for

            return playerName;

        }//end function
        static string GetFoulTargetAward()
        {
            BubbleSort(_players, "freethrowPercentage");
            decimal max = _players[0].freethrowPercentage;
            string playerName = "";

            for (int index = 0; index < _players.Length; index++)
            {
                if (_players[index].freethrowPercentage > max)
                {
                    max = _players[index].freethrowPercentage;
                    playerName = _players[index].playerName;
                }//end if
            }//end for

            return playerName;
        }//end function//IN PROGRESS
        static string GetOverachieverAward()
        {
            BubbleSort(_players, "rating");
            //VARIABLES
            string playerName = "";
            decimal medianValue = GetMedian(_players);

            for (int index = 0; index < _players.Length; index++)
            {
                if (_players[index].rating > medianValue && _players[index].rating > (decimal)80.30)
                {
                    playerName = _players[index].playerName;
                    Console.WriteLine(playerName);
                }//end if
            }//end for

            return playerName;
        }//end function
        static string GetUnderachieverAward()
        {
            BubbleSort(_players, "rating");
            //VARIABLES
            string playerName = "";
            decimal medianValue = GetMedian(_players);

            for (int index = 0; index < _players.Length; index++)
            {
                if (_players[index].rating < medianValue && _players[index].rating < (decimal)-22)
                {
                    playerName = _players[index].playerName;
                    Console.WriteLine(playerName);
                }//end if
            }//end for   

            return playerName;
        }//end function
        static string GetOnTheFenceAward()
        {
            BubbleSort(_players, "rating");
            //VARIABLES
            string playerName = "";
            decimal currentAverageRating = CalcRatingAverage();
            decimal distance = Math.Abs(_players[0].rating - currentAverageRating);
            //decimal searchValue = currentRatingAverage;            //MAKE SEPERATE ARRAY FOR RATING// DECIMAL[] CURRENTRATING = FIELDS[3];
            //decimal currentNearest = decimal.Parse(fields[3]);
            //decimal currentDifference = Math.Abs(currentNearest - searchValue);
            //
            //    decimal diff = Math.Abs(decimal.Parse(fields[3]) - searchValue);
            //    if (diff < currentDifference)
            //    {
            //        currentDifference = diff;
            //        currentNearest = decimal.Parse(fields[3]);
            //        if (currentNearest < 0)
            //        {
            //            currentNearest = currentNearest * 1;
            //        }
            //    }

            for (int index = 0; index < _players.Length; index++)
            {
                decimal currentDistance = Math.Abs(_players[index].rating - currentAverageRating);
                if (currentDistance < distance)
                {
                    distance = currentDistance;
                    playerName = _players[index].playerName;
                }//end if
            }//end for

            return playerName;

        }//end function
        static string GetGordonGekkoAward()
        {

            decimal points = 0;
            decimal atlanticTotalPoints = 0;
            decimal centralTotalPoints = 0;
            decimal southEastTotalPoints = 0;
            decimal northWestTotalPoints = 0;
            decimal pacificTotalPoints = 0;
            decimal southWestTotalPoints = 0;
            string atlanticWins = "Atlantic Region Had The Most Points";
            string pacificWins = "Pacific Region Had The Most Points";
            string centralWins = "Central Region Had The Most Points";
            string northWestWins = "North West Region Had The Most Points";
            string southEastWins = "South East Region Had The Most Points";
            string southWestWins = "South West Region Had The Most Points";



            //OPEN FILE FOR READ ACCESS VIA STREAMREADER
            StreamReader nbaData = new StreamReader(_filePath);

            //READLINE TO SKIP HEADER
            nbaData.ReadLine();

            //LOOP UNITL END OF STREAM REACHED
            while (nbaData.EndOfStream == false)
            {

                //READ RECORD "ROW" FROM FILE
                string contactRecord = nbaData.ReadLine();

                //SPLIT THE "ROW" INTO "FIELDS"
                string[] fields = contactRecord.Split(',');

                //Assign points field to variable 
                points = decimal.Parse(fields[6]);

                if (fields[1] == "BOS" || fields[1] == "NY" || fields[1] == "TOR" || fields[1] == "BKN" || fields[1] == "PHI")
                {
                    atlanticTotalPoints += points;
                }//end add to north east if statement
                else if (fields[1] == "CHI" || fields[1] == "CLE" || fields[1] == "MIL" || fields[1] == "IND" || fields[1] == "DET")
                {
                    centralTotalPoints += points;
                }//end add to north east extended if statement
                else if (fields[1] == "MIN" || fields[1] == "UTA" || fields[1] == "DEN" || fields[1] == "POR" || fields[1] == "OKC")
                {
                    northWestTotalPoints += points;
                }//end add to north west if statement
                else if (fields[1] == "ATL" || fields[1] == "WAS" || fields[1] == "MIA" || fields[1] == "CHA" || fields[1] == "ORL")
                {
                    southEastTotalPoints += points;
                }//end add to south east if statement
                else if (fields[1] == "DAL" || fields[1] == "SA" || fields[1] == "NO" || fields[1] == "MEM" || fields[1] == "HOU")
                {
                    southWestTotalPoints += points;
                }//end add to south west if statement
                else if (fields[1] == "LAL" || fields[1] == "PHO" || fields[1] == "LAC" || fields[1] == "SAC" || fields[1] == "GS")
                {
                    pacificTotalPoints += points;
                }//end add to south west extended if statement
            }//end while

            Console.WriteLine($"The Atlantic Region Total was {atlanticTotalPoints:f2}");
            Console.WriteLine($"The Central Region Total was {centralTotalPoints:f2}");
            Console.WriteLine($"The SouthEast Region Total was {southEastTotalPoints:f2}");
            Console.WriteLine($"The NorthWest Region Total was {northWestTotalPoints:f2}");
            Console.WriteLine($"The Pacific Region Total was {pacificTotalPoints:f2}");
            Console.WriteLine($"The SouthWest Region Total was {southWestTotalPoints:f2}");
            Console.WriteLine();

            if (atlanticTotalPoints > northWestTotalPoints && atlanticTotalPoints > southWestTotalPoints && atlanticTotalPoints > southEastTotalPoints && atlanticTotalPoints > centralTotalPoints && atlanticTotalPoints > pacificTotalPoints)
            {
                Console.WriteLine($"Atlantic Region Had The Most Points(per game) with a total of {atlanticTotalPoints:f2} Points(per game)");
                return atlanticWins;
            }//end atlantic wins if statement
            else if (northWestTotalPoints > atlanticTotalPoints && northWestTotalPoints > southEastTotalPoints && northWestTotalPoints > southWestTotalPoints && northWestTotalPoints > pacificTotalPoints && northWestTotalPoints > centralTotalPoints)
            {
                Console.WriteLine($"North West Region Had The Most Points(per game) with a total of {northWestTotalPoints:f2} Points(per game)");
                return northWestWins;
            }//end north west wins if statement
            else if (southWestTotalPoints > southEastTotalPoints && southWestTotalPoints > northWestTotalPoints && southWestTotalPoints > atlanticTotalPoints && southWestTotalPoints > centralTotalPoints && southWestTotalPoints > pacificTotalPoints)
            {
                Console.WriteLine($"South West Region Had The Most Points(per game) with a total of {southWestTotalPoints:f2} Points(per game)!");
                return southWestWins;
            }//end south west wins if statement
            else if (southEastTotalPoints > southWestTotalPoints && southEastTotalPoints > atlanticTotalPoints && southEastTotalPoints > northWestTotalPoints && southEastTotalPoints > centralTotalPoints && southEastTotalPoints > pacificTotalPoints)
            {
                Console.WriteLine($"South East Region Had The Most Points(per game) with a total of {southEastTotalPoints:f2} Points(per game)");
                return southEastWins;
            }//end south east wins if statement
            else if (pacificTotalPoints > centralTotalPoints && pacificTotalPoints > atlanticTotalPoints && pacificTotalPoints > southEastTotalPoints && pacificTotalPoints > southWestTotalPoints && pacificTotalPoints > northWestTotalPoints)
            {
                Console.WriteLine($"Pacific Region Had The Most Points(per game) with a total of {pacificTotalPoints:f2}");
                return pacificWins;
            }
            else if (centralTotalPoints > atlanticTotalPoints && centralTotalPoints > southEastTotalPoints && centralTotalPoints > northWestTotalPoints && centralTotalPoints > pacificTotalPoints && centralTotalPoints > southWestTotalPoints)
            {
                Console.WriteLine($"Central Region Had The Most Points(per game) with a total of {centralTotalPoints:f2}");
                return centralWins;
            }
            else
            {
                return "TIE OR NO WINNER FOUND!";
            }//end tie else statement

        }//end gordon gekko function
        static string GetBangForYourBuckAward()
        {
            BubbleSort(_players, "minutesPerGame");
            string playerName = "";
            decimal max = _players[0].minutesPerGame;

            for (int index = 0; index < _players.Length; index++)
            {
                if (_players[index].rookie != 0)
                {
                    if (_players[index].minutesPerGame > max)
                    {
                        max = _players[index].minutesPerGame;
                        playerName = _players[index].playerName;
                    }//end if

                }//end if
            }//end for
            return playerName;
        }//end function
        static string[] GetCharlieBrownAward()
        {
            string[] playerName = new string[8];

            BubbleSort(_players, "rating");
            decimal min = _players[0].rating;
            decimal min1 = _players[0].gamesPlayed;
            decimal min2 = _players[0].minutesPerGame;
            decimal min3 = _players[0].pointsPerGame;
            decimal min4 = _players[0].reboundsPerGame;
            decimal min5 = _players[0].assistsPerGame;
            decimal min6 = _players[0].shotPercentage;
            decimal min7 = _players[0].freethrowPercentage;
            for (int index = 0; index < _players.Length; index++)
            {

                if (_players[index].rating <= min)
                {
                    min = _players[index].rating;
                    playerName[0] = _players[index].playerName;
                }//end for
            }//end for

            BubbleSort(_players, "gamesPlayed");
            for (int index1 = 0; index1 < _players.Length; index1++)
            {

                if (_players[index1].gamesPlayed <= min1)
                {
                    min1 = _players[index1].gamesPlayed;
                    playerName[1] = _players[index1].playerName;
                }//end if            
            }//end for
            BubbleSort(_players, "minutesPerGame");
            for (int index2 = 0; index2 < _players.Length; index2++)
            {

                if (_players[index2].minutesPerGame <= min2)
                {
                    min2 = _players[index2].minutesPerGame;
                    playerName[2] = _players[index2].playerName;
                }//end if            
            }//end for
            BubbleSort(_players, "pointsPerGame");
            for (int index3 = 0; index3 < _players.Length; index3++)
            {

                if (_players[index3].pointsPerGame <= min3)
                {
                    min3 = _players[index3].pointsPerGame;
                    playerName[3] = _players[index3].playerName;
                }//end if            
            }//end for
            BubbleSort(_players, "reboundsPerGame");
            for (int index4 = 0; index4 < _players.Length; index4++)
            {

                if (_players[index4].reboundsPerGame <= min4)
                {
                    min4 = _players[index4].reboundsPerGame;
                    playerName[4] = _players[index4].playerName;
                }//end if            
            }//end for
            BubbleSort(_players, "assistsPerGame");
            for (int index5 = 0; index5 < _players.Length; index5++)
            {

                if (_players[index5].assistsPerGame <= min5)
                {
                    min5 = _players[index5].assistsPerGame;
                    playerName[5] = _players[index5].playerName;
                }//end if            
            }//end for
            BubbleSort(_players, "shotPercentage");
            for (int index6 = 0; index6 < _players.Length; index6++)
            {

                if (_players[index6].shotPercentage <= min6)
                {
                    min6 = _players[index6].shotPercentage;
                    playerName[6] = _players[index6].playerName;
                }//end if            
            }//end for
            BubbleSort(_players, "freethrowPercentage");
            for (int index7 = 0; index7 < _players.Length; index7++)
            {

                if (_players[index7].freethrowPercentage <= min7)
                {
                    min7 = _players[index7].freethrowPercentage;
                    playerName[7] = _players[index7].playerName;
                }//end if            
            }//end for

            return playerName;
        }//end function
        static string[] GetTigerUpperCutAward()
        {
            string[] playerName = new string[8];

            BubbleSort(_players, "rating");
            decimal max = _players[0].rating;
            decimal max1 = _players[0].gamesPlayed;
            decimal max2 = _players[0].minutesPerGame;
            decimal max3 = _players[0].pointsPerGame;
            decimal max4 = _players[0].reboundsPerGame;
            decimal max5 = _players[0].assistsPerGame;
            decimal max6 = _players[0].shotPercentage;
            decimal max7 = _players[0].freethrowPercentage;
            for (int index = 0; index < _players.Length; index++)
            {

                if (_players[index].rating > max)
                {
                    max = _players[index].rating;
                    playerName[0] = _players[index].playerName;
                }//end for
            }//end for

            BubbleSort(_players, "gamesPlayed");
            for (int index1 = 0; index1 < _players.Length; index1++)
            {

                if (_players[index1].gamesPlayed > max1)
                {
                    max1 = _players[index1].gamesPlayed;
                    playerName[1] = _players[index1].playerName;
                }//end if            
            }//end for
            BubbleSort(_players, "minutesPerGame");
            for (int index2 = 0; index2 < _players.Length; index2++)
            {

                if (_players[index2].minutesPerGame > max2)
                {
                    max2 = _players[index2].minutesPerGame;
                    playerName[2] = _players[index2].playerName;
                }//end if            
            }//end for
            BubbleSort(_players, "pointsPerGame");
            for (int index3 = 0; index3 < _players.Length; index3++)
            {

                if (_players[index3].pointsPerGame > max3)
                {
                    max3 = _players[index3].pointsPerGame;
                    playerName[3] = _players[index3].playerName;
                }//end if            
            }//end for
            BubbleSort(_players, "reboundsPerGame");
            for (int index4 = 0; index4 < _players.Length; index4++)
            {

                if (_players[index4].reboundsPerGame > max4)
                {
                    max4 = _players[index4].reboundsPerGame;
                    playerName[4] = _players[index4].playerName;
                }//end if            
            }//end for
            BubbleSort(_players, "assistsPerGame");
            for (int index5 = 0; index5 < _players.Length; index5++)
            {

                if (_players[index5].assistsPerGame > max5)
                {
                    max5 = _players[index5].assistsPerGame;
                    playerName[5] = _players[index5].playerName;
                }//end if            
            }//end for
            BubbleSort(_players, "shotPercentage");
            for (int index6 = 0; index6 < _players.Length; index6++)
            {

                if (_players[index6].shotPercentage > max6)
                {
                    max6 = _players[index6].shotPercentage;
                    playerName[6] = _players[index6].playerName;
                }//end if            
            }//end for
            BubbleSort(_players, "freethrowPercentage");
            for (int index7 = 0; index7 < _players.Length; index7++)
            {

                if (_players[index7].freethrowPercentage > max7)
                {
                    max7 = _players[index7].freethrowPercentage;
                    playerName[7] = _players[index7].playerName;
                }//end if            
            }//end for

            return playerName;
        }//end function

        //_______________HELPER FUNCTIONS_________________
        static decimal CalcRatingAverage()
        {
            //VARIABLES
            decimal ratingAverageTotal = 0;
            decimal ratingAverage = 0;

            //OPEN FILE FOR READ ACCESS VIA STREAMREADER
            StreamReader nbaData = new StreamReader(_filePath);

            nbaData.ReadLine();//READLINE TO SKIP HEADER

            //LOOP UNITL END OF STREAM REACHED
            while (nbaData.EndOfStream == false)
            {

                //READ RECORD "ROW" FROM FILE
                string nbaDataRecord = nbaData.ReadLine();

                //SPLIT THE "ROW" INTO "FIELDS"
                string[] fields = nbaDataRecord.Split(',');

                ratingAverageTotal += decimal.Parse(fields[3]);//RUNNING TOTAL OF RATING AVG TOTAL FROM FIELD 3 TO GET TOTAL

            }//end while

            ratingAverage = ratingAverageTotal / 438;//RATING AVERAGE DIVIDED BY NUMBER OF PLAYERS

            //CLOSE FILE
            nbaData.Close();

            return ratingAverage;

        }//end calc average function
        static decimal GetMedian(nbaData[] array)
        {
            BubbleSort(_players, "rating");

            decimal medianValue = 0;
            int count = _players.Length;

            if (count % 2 == 0)
            {

                //COUNT IS EVEN, NEED TO GET MIDDLE TWO ELEMENTS, ADD, DIVIDE BY 2
                decimal middleElement1 = _players[(count / 2) - 1].rating;
                decimal middleElement2 = _players[(count / 2)].rating;
                medianValue = (middleElement1 + middleElement2) / 2;
            }
            else
            {
                //COUNT IS ODD, GET MIDDLE ELEMENT
                medianValue = _players[(count / 2)].rating;
            }//end if

            return medianValue;

        }//end function
        static void ReadTextFile()
        {

            //OPEN FILE FOR READ ACCESS VIA STREAMREADER
            StreamReader contactData = new StreamReader(_filePath);

            //READLINE TO SKIP HEADER
            contactData.ReadLine();

            //LOOP UNITL END OF STREAM REACHED
            while (contactData.EndOfStream == false)
            {

                //READ RECORD "ROW" FROM FILE
                string contactRecord = contactData.ReadLine();

                //SPLIT THE "ROW" INTO "FIELDS"
                string[] fields = contactRecord.Split(',');

                for (int index = 0; index < fields.Length; index++)
                {//FOR LOOP TO DISPLAY DATA
                    Console.Write($"{fields[index]} |");
                }//end for

                Console.WriteLine();//MOVE TO NEXT LINE SO WE DON'T INFINITE LOOP

            }//end while

            //CLOSE FILE
            contactData.Close();

        }//end function
        static string Prompt(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine().Trim();
        }//end prompt function
        static int PromptInt(string message)
        {
            int parsedValue = 0;

            while (int.TryParse(Prompt(message), out parsedValue) == false || parsedValue < 1 || parsedValue > 10)
            {
                Console.WriteLine("Invalid value. Try Again: ");
            }//end while

            return parsedValue;
        }//end prompt int function
        static bool PromptLoop(string message)
        {

            bool valid = false;
            string userInput;

            Console.WriteLine(message);
            while (!valid)
            {//LOOP UNTIL USER INPUTS CORRECT KEY CHARS
                userInput = Console.ReadKey(true).KeyChar.ToString().ToUpper();
                if (userInput == "Y")
                {
                    return true;
                }
                else if (userInput == "N")
                {
                    return false;
                }//end if
            }//end while         

            return false;
        }//end function 
        static void BubbleSort(nbaData[] array, string field)
        {
            //ASSUME IM NOT SORTED 
            bool swapOccured = true;

            while (swapOccured)
            {
                //NO SWAPS HAVE HAD A CHANCE TO HAPPEN YET
                swapOccured = false;

                //TRAVERSE ARRAY
                for (int index = 0; index < array.Length - 1; index++)
                {
                    //CHECK ORDER
                    bool inOrder = true;

                    switch (field)
                    {
                        case "rookie":
                            inOrder = array[index].rookie <= array[index + 1].rookie;
                            break;
                        case "rating":
                            inOrder = array[index].rating <= array[index + 1].rating;
                            break;
                        case "gamesPlayed":
                            inOrder = array[index].gamesPlayed <= array[index + 1].gamesPlayed;
                            break;
                        case "minutesPerGame":
                            inOrder = array[index].minutesPerGame <= array[index + 1].minutesPerGame;
                            break;
                        case "pointsPerGame":
                            inOrder = array[index].pointsPerGame <= array[index + 1].pointsPerGame;
                            break;
                        case "reboundsPerGame":
                            inOrder = array[index].reboundsPerGame <= array[index + 1].reboundsPerGame;
                            break;
                        case "assistsPerGame":
                            inOrder = array[index].assistsPerGame <= array[index + 1].assistsPerGame;
                            break;
                        case "shotPercentage":
                            inOrder = array[index].shotPercentage <= array[index + 1].shotPercentage;
                            break;
                        case "freethrowPercentage":
                            inOrder = array[index].freethrowPercentage <= array[index + 1].freethrowPercentage;
                            break;
                    }//end switch

                    //IF OUT OF ORDER SWAP AND RECORD A SWAP HAPPENED
                    if (!inOrder)
                    {
                        Swap(array, index, index + 1);
                        swapOccured = true;

                    }//end if
                }//end for
            }//end while

        }//end function
        static void Swap(nbaData[] array, int index1, int index2)
        {
            nbaData temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }//end swap function
        static int GetRecordCount(string fileName, bool skipHeader)
        {

            StreamReader reader = new StreamReader(_filePath);
            int recordCounter = 0;

            if (skipHeader)
            {
                reader.ReadLine();
            }//end if

            while (reader.EndOfStream == false)
            {
                reader.ReadLine();
                recordCounter += 1;
            }//end while

            reader.Close();

            return recordCounter;
        }//end record counter function
        static void PopulatePlayerData()
        {

            //VARIABLES
            int recordCount = GetRecordCount(_filePath, true);
            int recordCounter = 0;

            _players = new nbaData[recordCount];

            StreamReader playerStatReader = new StreamReader(_filePath);//NEW INSTANCE OF STREAMREADER

            playerStatReader.ReadLine();//READLINE TO SKIP HEADER

            while (playerStatReader.EndOfStream == false)
            {

                //READ A "ROW" FROM THE FILE
                string playerRecord = playerStatReader.ReadLine();

                //SPLIT THE "ROW" INTO "COLUMNS"
                string[] fields = playerRecord.Split(',');

                _players[recordCounter].playerName = fields[0];
                _players[recordCounter].teamName = fields[1];
                _players[recordCounter].rookie = int.Parse(fields[2]);
                _players[recordCounter].rating = decimal.Parse(fields[3]);
                _players[recordCounter].gamesPlayed = decimal.Parse(fields[4]);
                _players[recordCounter].minutesPerGame = decimal.Parse(fields[5]);
                _players[recordCounter].pointsPerGame = decimal.Parse(fields[6]);
                _players[recordCounter].reboundsPerGame = decimal.Parse(fields[7]);
                _players[recordCounter].assistsPerGame = decimal.Parse(fields[8]);
                _players[recordCounter].shotPercentage = decimal.Parse(fields[9]);
                _players[recordCounter].freethrowPercentage = decimal.Parse(fields[10]);

                recordCounter += 1;
            }//end while

            playerStatReader.Close();

        }//end load function

    }//end class   
}//end namespace
