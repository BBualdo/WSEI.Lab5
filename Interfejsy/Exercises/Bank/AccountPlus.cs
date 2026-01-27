using System;

namespace Bank {
    public class AccountPlus : Account, IAccountWithLimit {
        private decimal _usedLimit = 0;
        
        private decimal _oneTimeDebetLimit;
        public decimal OneTimeDebetLimit { 
            get => _oneTimeDebetLimit;
            set {
                if (!IsBlocked) {
                    if (value >= 0) _oneTimeDebetLimit = value;
                }
            }
        }
        
        public decimal AvaibleFounds => Balance + (OneTimeDebetLimit - _usedLimit);

        public AccountPlus(string name, decimal initialBalance = 0, decimal initialLimit = 100) : base(name, initialBalance) {
            OneTimeDebetLimit = initialLimit;
        }

        public new bool Withdrawal(decimal amount) {
            if (amount <= 0 || IsBlocked || amount > AvaibleFounds) return false;
            
            if (amount <= Balance) {
                return base.Withdrawal(amount);
            } 
            
            decimal deficit = amount - Balance;
            base.Withdrawal(Balance);
            _usedLimit = Math.Round(_usedLimit + deficit, PRECISION);
            Block();
            return true;
        }

        public new bool Deposit(decimal amount) {
            if (amount <= 0) return false;

            if (_usedLimit > 0) {
                decimal debtRepayment = Math.Min(amount, _usedLimit);
                _usedLimit = Math.Round(_usedLimit - debtRepayment, PRECISION);
                
                decimal remainingDeposit = amount - debtRepayment;
                
                if (_usedLimit == 0) Unblock();

                if (remainingDeposit > 0) {
                    if (IsBlocked && _usedLimit == 0) Unblock();

                    return base.Deposit(remainingDeposit);
                }

                return true;
            } 
            
            if (IsBlocked) Unblock();
            return base.Deposit(amount);
        }

        public new void Unblock() {
            if (_usedLimit == 0) base.Unblock();
        }

        public override string ToString() {
            return IsBlocked
                ? $"Account name: {Name}, balance: {Balance:F2}, blocked, avaible founds: {AvaibleFounds:F2}, limit: {OneTimeDebetLimit:F2}"
                : $"Account name: {Name}, balance: {Balance:F2}, avaible founds: {AvaibleFounds:F2}, limit: {OneTimeDebetLimit:F2}";
        }
    }
}