﻿namespace DAL.Utils
{
    using Dapper;
    using System;
    using System.Collections.Generic;

    public abstract class BaseDao
    {
        public bool Exec(string query, object param = null)
        {
            using (var connection = SqlUtils.Connection())
            {
                connection.Open();
                if (param == null)
                {
                    connection.Execute(query);
                }
                else
                {
                    connection.Execute(query, param);
                }

                return true;
            }
        }

        public List<T> Exec<T>(string query, object param = null)
        {
            using (var connection = SqlUtils.Connection())
            {
                connection.Open();

                var result = param == null ? (List<T>)connection.Query<T>(query) : (List<T>)connection.Query<T>(query, param);

                return result;
            }
        }

        protected void CatchException(Action func)
        {
            CatchException(() =>
            {
                func();
                return true;
            });
        }

        protected T CatchException<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
