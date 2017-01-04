using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAAAETCommon.Enums;

namespace CAAAETInfraStructure.DataBase
{
    public class CAAAETDataBaseFactory
    {
        public static ICAAAETDataBase GetDataBase(CAAAETApplicationDBEnums dbChoice)
        {
            ICAAAETDataBase retDB = null;
            switch (dbChoice)
            {
                case CAAAETApplicationDBEnums.SQL:
                    retDB = new CAAAETSQLDataBase();
                    break;
                default:
                    break;
            }
            return retDB;
        }
    }
}
