using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBookApp.DAL.DAO;
using PhoneBookApp.DAL.DLL;

namespace PhoneBookApp.BLL
{
    class PhoneBookManager
    {
        PhoneBookDbGateway aBookDbGateway = new PhoneBookDbGateway();

        public string Save(PhoneBook aBook)
        {
            if (aBookDbGateway.Find(aBook.MobileNo) == null)
            {
                aBookDbGateway.Save(aBook);
                return "Successfully saved.";
            }
            else
            {
                return "Already exists!";
            }
        }

        public List<PhoneBook> GetAll()
        {
            return aBookDbGateway.GetAll();
        }
    }
}
