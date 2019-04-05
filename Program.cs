using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace crime
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("CrimeAnalyzer <crime_csv_file_path> <report_file_path>");
                return;
            }
            List<CrimeStats> crimeStats = null;
            string in = args[0];
            string out = args[1];

            try
            {
                streamReader = new StreamReader(in);
                streamReader.ReadLine();
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    string[] parts = line.Split(",");
                    if (parts.Length < 11)
                    {
                        Console.WriteLine("Row found with invalid data, each row should have 11 elements");
                        continue;
                    }
                    int year = int32.Parse(parts[0]);
                    int population = int32.Parse(parts[1]);
                    int violentCrime = int32.Parse(parts[2]);
                    int murder = int32.Parse(parts[3]);
                    int rape = int32.Parse(parts[4]);
                    int robbery = int32.Parse(parts[5]);
                    int aggravatedAssault = int32.Parse(parts[6]);
                    int propertyCrime = int32.Parse(parts[7]);
                    int burglary = int32.Parse(parts[8]);
                    int theft = int32.Parse(parts[9]);
                    int motorTheft = int32.Parse(parts[10]);
                    CrimeStats cristat = new CrimeStats(year, population, violentCrime, murder, rape, robbery, aggravatedAssault, propertyCrime, burglary, theft, motorvehicleTheft);
                    crimeStats.Add(cristat);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine();
                return;
            }
            catch (Exception)
            {
                Console.WriteLine();
                return;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            if (crimeStats.Count > 0)
            {
                GenerateReport(crimeStats, outFile);
            }
        }
        writer.WriteLine("Crime Analyzer Report")
       
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(reportFile);

              ;

                var que = from stats in data select stats.Year;
                int high = que.high();
                int low = que.low();
                int num = que.Count();
                
                var que = from stats in data where stats.Murder < 15000 select stats.Year;

                var toWrite = "Years murders per year < 15000: ";

        var thefs = from stats in data where stats.Year <= 2004 && stats.Year >= 1999 select stats.Theft;
        var vio = from stats in data where stats.Year == 2010 select stats.ViolentCrimePerCapita;
        var motor = from stats in data orderby stats.MotorTheft descending select new { stats.Year, stats.MotorTheft };
        var average = (from crimeStats in crimeStats select crimeStats.Murder).Average();
        var rob = from stats in data where stats.Robbery > 500000 select new { stats.Year, stats.Robbery };
                toWrite = "Robberies per year > 500000: ";
               

                writer.WriteLine("Violent crime per capita rate (2010): {0}", vio.First());

                writer.WriteLine("Averate murder per year (all years): {0}", average.Average());

                average = from stats in data where stats.Year <= 1997 && stats.Year >= 1994 select stats.Murder;
                writer.WriteLine("Average murder per year (1994-1997): {0}", average.Average());

                average = from stats in data where stats.Year <= 2014 && stats.Year >= 2010 select stats.Murder;
                writer.WriteLine("Average murder per year (2010-2014): {0}", average.Average());

                writer.WriteLine("lowest thefts per year (1999-2004): {0}", thefs.low());
                writer.WriteLine("hignest thefts per year (1999-2004): {0}", thefs.high());

                writer.WriteLine("highest number of motor vehicle thefts year: {0}", motor.First().Year);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                writer.Close();
            }
        }
    }
