using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class UserService
    {
        public List<Users> UserList { get; } = new List<Users>();

        public void AddUser(Users user)
        {
            UserList.Add(user);
        }

    }

    public class BorrowService
    {
        public List<Borrow> BorrowedList { get; } = new List<Borrow>();

        public void AddBorrow(Borrow borrow)
        {
            BorrowedList.Add(borrow);
        }
    }


}
