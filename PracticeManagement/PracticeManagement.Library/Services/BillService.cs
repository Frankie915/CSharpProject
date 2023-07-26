using PracticeManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.Library.Services
{
    public class BillService
    {
        private static BillService? instance;
        private static object _lock = new object();
        public static BillService Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new BillService();
                    }
                }

                return instance;
            }
        }

        private List<Bill> bills;
        private BillService()
        {
            bills = new List<Bill>();
        }

        public List<Bill> Bills
        {
            get { return bills; }
        }
    }
}
