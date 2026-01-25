using System;
using System.Collections.Generic;

namespace KolekcjeStandardowe.Exercises.analiza_logow;

internal class Log {
    public string Date { get; set; }
    public string Time { get; set; }
    public string Name { get; set; }
    public string IPAddress { get; set; }

    public Log(string date, string time, string name, string ipAddress) {
        Date = date;
        Time = time;
        Name = name;
        IPAddress = ipAddress;
    }
}

public class Pytanie_1 {
    public static void Analyze(string logs) {
        List<Log> logsList = ParseLogs(logs);    
        List<string> names = GetAllNames(logsList);
        Dictionary<string, List<Log>> logsByDate = GroupByDate(logsList);
        List<string> dailyLoginNames = FilterLoginNames(logsByDate, names);
        dailyLoginNames.Sort();
        
        if (dailyLoginNames.Count == 0) 
            Console.WriteLine("empty");
        else 
            Console.WriteLine(string.Join(", ", dailyLoginNames));
    }

    private static List<Log> ParseLogs(string logs) {
        List<Log> logsList = new List<Log>();
        
        string[] logLines = logs.Split('\n');

        foreach (string logLine in logLines) {
            string[] segments = logLine.Split(' ');
            Log log = new Log(segments[0], segments[1], segments[2], segments[3]);
            logsList.Add(log);
        }
        
        return logsList;
    }

    private static List<string> GetAllNames(List<Log> logs) {
        List<string> names = new List<string>();

        foreach (Log log in logs) {
            if (!names.Contains(log.Name)) names.Add(log.Name);
        }
        
        HashSet<string> namesSet = new HashSet<string>(names);
        names = new List<string>(namesSet);
        
        return names;
    }
    
    private static Dictionary<string, List<Log>> GroupByDate(List<Log> logs) {
        Dictionary<string, List<Log>> logsByDate = new Dictionary<string, List<Log>>();

        foreach (Log log in logs) {
            if (!logsByDate.ContainsKey(log.Date)) logsByDate.Add(log.Date, logs.FindAll(l => l.Date == log.Date));
        }
        
        return logsByDate;
    }

    private static List<string> FilterLoginNames(Dictionary<string, List<Log>> logsByDate, List<string> names) {
        List<string> filteredNames = new List<string>();
        
        Dictionary<string, int> nameOcurrences = new Dictionary<string, int>();

        foreach (string name in names) {
            if (!nameOcurrences.ContainsKey(name)) nameOcurrences.Add(name, 0);
        }
        
        foreach (KeyValuePair<string, List<Log>> kvp in logsByDate) {
            foreach (Log log in kvp.Value) {
                nameOcurrences[log.Name]++;
            }
        }

        foreach (KeyValuePair<string, int> kvp in nameOcurrences) {
            if (kvp.Value == logsByDate.Count) filteredNames.Add(kvp.Key);
        }
        
        return filteredNames;
    }
}