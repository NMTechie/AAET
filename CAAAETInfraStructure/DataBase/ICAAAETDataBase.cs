using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;

namespace CAAAETInfraStructure.DataBase
{
    public interface ICAAAETDataBase
    {
        DataSet ExecuteStoredProc(string procName, params DbParameter[] procParameterList);
        DbParameter CreateParameter(string name, DbType paramType, ParameterDirection paramDirection, int size = int.MaxValue);
        
    }   
}
