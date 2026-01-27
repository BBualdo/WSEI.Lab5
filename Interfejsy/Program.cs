using System;
using Bank;

var account = new Account(" John   ", 100.23156m);
Console.WriteLine(account.Balance == 100.2316m);
Console.WriteLine(account.Name == "John");
Console.WriteLine(!account.IsBlocked);
Console.WriteLine(account);