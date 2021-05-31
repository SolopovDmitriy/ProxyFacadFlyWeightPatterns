using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyApp
{
    interface IDateSource<T>
    {
        T GetRow(int id);

        IEnumerable<T> GetAllRows();

        void AddRow(T data);

        void RemoveRow(int id);

        void UpdateRow(int id, T uData);
    }
}
