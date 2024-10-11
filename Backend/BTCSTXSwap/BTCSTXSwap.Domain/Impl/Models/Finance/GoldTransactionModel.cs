using Core.Domain.Repository;
using BTCSTXSwap.Domain.Interfaces.Factory.Finance;
using BTCSTXSwap.Domain.Interfaces.Models.Finance;
using BTCSTXSwap.DTO.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Models.Finance
{
    public class GoldTransactionModel : IGoldTransactionModel
    {
        private readonly IGoldTransactionDomainFactory _goldFinanceFactory;
        private readonly IGoldFinanceRepository<IGoldTransactionModel, IGoldTransactionDomainFactory> _goldFinanceRepository;

        public GoldTransactionModel(IGoldTransactionDomainFactory goldFinanceFactory,
            IGoldFinanceRepository<IGoldTransactionModel, IGoldTransactionDomainFactory> goldFinanceRepository)
        {
            GoldTransaction = new GoldTransactionInfo();
            _goldFinanceFactory = goldFinanceFactory;
            _goldFinanceRepository = goldFinanceRepository;
        }

        public GoldTransactionInfo GoldTransaction { get; set; }

        public void Save()
        {
            _goldFinanceRepository.Insert(this);
        }

        public IEnumerable<IGoldTransactionModel> ListByUser(long idUser, int page, out int balance)
        {
            return _goldFinanceRepository.List(_goldFinanceFactory, idUser, page, out balance);
        }

        public decimal GetUserGoldBalance(long idUser)
        {
            return _goldFinanceRepository.GetBalance(idUser);
        }

        public decimal GetTotalGOBI()
        {
            return _goldFinanceRepository.GetTotalGOBI();
        }

        public decimal GetTotalGold()
        {
            return _goldFinanceRepository.GetTotalGold();
        }

        public IGoldTransactionModel GetLastGoldSwap(long idUser)
        {
            return _goldFinanceRepository.GetLastGoldSwap(_goldFinanceFactory, idUser);
        }

        public IGoldTransactionModel GetLastGOBISwap(long idUser)
        {
            return _goldFinanceRepository.GetLastGOBISwap(_goldFinanceFactory, idUser);
        }

        public decimal GetBalanceOfGobiSwapInTheLastDay(long idUser)
        {
            return _goldFinanceRepository.GetBalanceOfGobiSwapInTheLastDay(idUser);
        }
    }
}
