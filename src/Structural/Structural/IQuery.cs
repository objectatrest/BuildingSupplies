using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Structural
{
    public interface IQuery<T>
    {
        object Execute(T request);
    }

    public class Queries
    {
        public static object ExecuteQuery<T>(IQuery<T> query, T request)
        {
            return query.Execute(request);
        }
    }
}
