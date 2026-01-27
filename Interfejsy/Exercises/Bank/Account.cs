using System;

namespace Bank {
    public class Account : IAccount {
        private decimal _balance;

        public string Name { get; }
        public decimal Balance => Math.Round(_balance, 4);
        public bool IsBlocked { get; private set; }

        public Account(string name, decimal balance = 0) {
            Name = SetName(name);
            _balance = SetBalance(balance);
        }
    
        public void Block() {
            IsBlocked = true;
        }

        public void Unblock() {
            IsBlocked = false;
        }

        public bool Deposit(decimal amount) {
            if (IsBlocked || amount <= 0) return false;
            _balance += amount;
            return true;
        }

        public bool Withdrawal(decimal amount) {
            if (IsBlocked || amount <= 0 || amount > Balance) return false;
            _balance -= amount;
            return true;
        }

        public override string ToString() {
            string result = $"Account name: {Name}, balance: {Balance:F2}";
            if (IsBlocked) result += ", blocked";
            return result;
        }

        private string SetName(string name) {
            if (string.IsNullOrEmpty(name)) throw new ArgumentOutOfRangeException();
            name = name.Trim();
            if (name.Length < 3) throw new ArgumentException();
            return name;
        }
    
        private decimal SetBalance(decimal balance) {
            if (balance < 0) throw new ArgumentOutOfRangeException();
            return balance;
        }
    }
}