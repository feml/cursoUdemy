﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public partial class Factory : IDisposable
    {
        private bool disposed = false;
        private Security _Security;
        private BuildSelect SelectCommand;
        private InfoLibrary Info;
        public Factory(string user, string password, string ambiente)
        {
            _Security = new Security(user, password, ambiente);
            SelectCommand = new BuildSelect();
            Info = new InfoLibrary();
        }

        public DataTable getTableReader(string library, string select, string[] _nParametros, object[] _vParametros)
        {
            return GetTable(library, select, _nParametros, _vParametros);
        }
        public DataTable getTableReader(string library, string select)
        {
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[0] { };
            _vParametros = new object[0] { };
            return GetTable(library, select, _nParametros, _vParametros);
        }
        public DataTable getTable(string library, string select, string[] _nParametros, object[] _vParametros)
        {
            return GetTable(library, select, _nParametros, _vParametros);
        }
        public DataTable getTable(string library, string select)
        {
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[0] { };
            _vParametros = new object[0] { };
            return GetTable(library, select, _nParametros, _vParametros);
        }
        public int executeCommand(string library, string select, string[] _nParametros, object[] _vParametros)
        {
            return ExecuteCommand(library, select, _nParametros, _vParametros);
        }

        public void Dispose()
        {
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {

                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
    }
}