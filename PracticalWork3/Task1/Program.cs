using Microsoft.VisualBasic.FileIO;
using System;
namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dateFormat = "yyyy-MM-dd";
            Func<string, DateTime> dateTransaction = transactionInfo => DateTime.ParseExact(transactionInfo.Split(',')[0], dateFormat, null);
            Func<string, double> amountTransaction = transactionInfo => double.Parse(transactionInfo.Split(',')[1]);
            Action<DateTime, double> showTotalAmount = (date, amount) => Console.WriteLine($"{date.ToString(dateFormat)}: {amount}");
            string path = @"E:\knute\oop\laboratory9\PracticalWork3\Task1\file.csv";
            string overwritingPath = @"E:\knute\oop\laboratory9\PracticalWork3\Task1\";
            var transactionsByDate = File.ReadAllLines(path).Skip(1).GroupBy(dateTransaction).Select(s => new { Date = s.Key, TotalMoney = s.Sum(amountTransaction) });
            int count = 0;
            StreamWriter writer = null;
            foreach (var transaction in transactionsByDate)
            {
                if (writer == null)
                {
                    count++;
                    writer?.Dispose();
                    string filename = $"{overwritingPath}{$"transaction{count}"}.csv";
                    writer = new StreamWriter(filename);
                    writer.WriteLine("Date,Total money");
                }
                writer.WriteLine($"{transaction.Date.ToString(dateFormat)},{transaction.TotalMoney}");
                showTotalAmount(transaction.Date, transaction.TotalMoney);
            }
            writer?.Dispose();
        }
    }
}