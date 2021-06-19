using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace RaihanFrameworkCore
{
    public class MyORM<T> : IDisposable where T : IData
    {
        private SqlBuilder _sqlBuilder;
        private SqlConnection _connection;
        private SqlCommand _command;

        public MyORM(SqlConnection connection)
        {
            _connection = connection;
            _sqlBuilder = new SqlBuilder();
            _connection.Open();
        }

        public MyORM(string connectionString) : this(new SqlConnection(connectionString))
        {
            _sqlBuilder = new SqlBuilder();
        }

        public void Insert(T item)
        {
            ParameterBinder(item, ref _command, _sqlBuilder.GetInsertSql(item));
            _command.ExecuteNonQuery();
        }

        public void Update(T item)
        {
            ParameterBinder(item, ref _command, _sqlBuilder.GetUpdateSql(item));
            _command.ExecuteNonQuery();
        }

        public void Delete(T item)
        {
            Delete(item.Id);
        }

        public void Delete(int id)
        {
            var sql = _sqlBuilder.GetDeleteSql(typeof(T));
            _command = new SqlCommand(sql, _connection);
            _command.Parameters.AddWithValue($"@Id", id);
            _command.ExecuteNonQuery();
        }

        public T GetById(int id)
        {
            var entity = Activator.CreateInstance(typeof(T));
            var sql = _sqlBuilder.GetSelectById(typeof(T));
            _command = new SqlCommand(sql, _connection);
            _command.Parameters.AddWithValue($"@Id", id);
            var reader = _command.ExecuteReader();

            while (reader.Read())
            {
                foreach (var prop in typeof(T).GetProperties())
                {
                    prop.SetValue(entity, reader[prop.Name]);
                }
            }

            return (T)entity;
        }

        public IList<T> GetAll()
        {
            var entityList = Activator.CreateInstance(typeof(List<>).MakeGenericType(typeof(T)), new object[0]);
            var sql = _sqlBuilder.GetSelectSql(typeof(T));
            _command = new SqlCommand(sql, _connection);
            var reader = _command.ExecuteReader();
            var add = entityList.GetType().GetMethod("Add", new Type[] { typeof(T) });
           
            while (reader.Read())
            {
                var entity = Activator.CreateInstance(typeof(T));

                foreach (var prop in typeof(T).GetProperties())
                {
                    prop.SetValue(entity, reader[prop.Name]);
                }

                add.Invoke(entityList, new object[] { entity });
            }

            return (IList<T>)entityList;
        }

        public void ParameterBinder(T item, ref SqlCommand _command, string sql)
        {
            var type = item.GetType();
            _command = new SqlCommand(sql, _connection);
            foreach (var parameter in type.GetProperties())
            {
                if (parameter.GetValue(item) != null)
                {
                    _command.Parameters.AddWithValue($"@{parameter.Name}", parameter.GetValue(item));
                }
            }
        }

        public void Dispose()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }
    }
}
