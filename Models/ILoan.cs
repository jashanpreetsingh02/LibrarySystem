using System;

namespace LibrarySystem.Models
{
    
    public interface ILoan
    {
        void BorrowItem(Users user);
    }
}
