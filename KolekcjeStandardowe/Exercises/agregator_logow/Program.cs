using System;
using System.Collections.Generic;
using System.Linq;

namespace KolekcjeStandardowe.Exercises.agregator_logow;

internal class Log {
    public string IPAddress { get; set; }
    public string Username { get; set; }
    public int Duration { get; set; }
}

internal class AggregatedLog {
    public string Username { get; set; }
    public int AccumulatedDuration { get; set; }
    public List<string> IPAddresses { get; set; }
}

public class Program {
    public static void Main(string[] args) {
        int logsAmount = GetLogsAmountFromInput();
        List<Log> logs = GetLogsFromInput(logsAmount);
        List<AggregatedLog> aggregatedLogs = AggregateLogs(logs);
        PrintAggregatedLogs(aggregatedLogs);
    }

    private static int GetLogsAmountFromInput() {
        return int.Parse(Console.ReadLine());
    }

    private static List<Log> GetLogsFromInput(int amount) {
        List<Log> logs = new List<Log>();

        for (int i = 0; i < amount; i++) {
            string[] logLine = Console.ReadLine().Split(' ');
            Log log = new Log {
                IPAddress = logLine[0], 
                Username = logLine[1], 
                Duration = int.Parse(logLine[2])
            };
            logs.Add(log);
        }
        
        return logs;
    }

    private static List<AggregatedLog> AggregateLogs(List<Log> logs) {
        List<AggregatedLog> aggregatedLogs = new List<AggregatedLog>();
        
        foreach (Log log in logs) {
            AggregatedLog aggregatedLog = new AggregatedLog {
                Username = log.Username,
            };

            if (aggregatedLogs.Find(al => al.Username == log.Username) == null) {
                aggregatedLogs.Add(aggregatedLog);
            }
        }

        foreach (AggregatedLog al in aggregatedLogs) {
            al.AccumulatedDuration = logs.Where(l => l.Username == al.Username)
                .Sum(l => l.Duration);
            al.IPAddresses = logs.Where(l => l.Username == al.Username)
                .Select(l => l.IPAddress)
                .Distinct()
                .OrderBy(ip => ip)
                .ToList();
        }
        
        return aggregatedLogs.OrderBy(al => al.Username).ToList();
    }

    private static void PrintAggregatedLogs(List<AggregatedLog> aggregatedLogs) {
        foreach (AggregatedLog al in aggregatedLogs) {
            Console.WriteLine($"{al.Username}: {al.AccumulatedDuration} [{string.Join(", ", al.IPAddresses)}]");
        }
    }
}