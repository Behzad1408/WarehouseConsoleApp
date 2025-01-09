using System;

namespace WarehouseManagement
{
    enum TransactionType { Incoming, Outgoing }

    class Transaction
    {
        public string TransactionProductCode { get; set; }
        public string TransactionWarehouseCode { get; set; }
        public DateTime TransactionEntryDate { get; set; }
        public DateTime TransactionExitDate { get; set; }
        public string TransactionOperatorName { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}