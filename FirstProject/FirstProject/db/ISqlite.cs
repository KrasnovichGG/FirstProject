using System;
using System.Collections.Generic;
using System.Text;

namespace FirstProject.db
{
    public interface ISqlite
    {
        string GetDatabasePath(string filename);
    }
}
