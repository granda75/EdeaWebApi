using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace Edea.DAL
{
    /// <summary>
    /// Represents the static Utils class.
    /// </summary>
    public static class Utils
    {
        #region Fields


        #endregion


        #region Public methods

        public static IEnumerable<T> ToIEnumerable<T>(this DataTable table) where T : class
        {
            if (table != null && table.Rows != null && table.Rows.Count > 0)
            {
                return table.AsEnumerable().Select(row => row.ToEntity2<T>());
            }

            return Enumerable.Empty<T>();
        }

        private static T ToEntity2<T>(this DataRow row) where T : class
        {
            T Record = Activator.CreateInstance<T>();

            PropertyInfo[] Properties = typeof(T).GetProperties();

            foreach (PropertyInfo Property in Properties)
            {
                string ColumnName = Property.Name;

                object[] CustomAttributes = Property.GetCustomAttributes(typeof(ColumnAttribute), true);
                if (CustomAttributes.Length == 1)
                {
                    ColumnName = ((ColumnAttribute)(CustomAttributes[0])).Name;
                }

                object ColumnValue;

                if (row.Table.Columns.Contains(ColumnName) && row[ColumnName] != null && row[ColumnName] != DBNull.Value)
                {
                    if (row[ColumnName].GetType().Equals(Property.PropertyType))
                    {
                        ColumnValue = row[ColumnName];
                    }
                    else
                    {
                        ColumnValue = TypeDescriptor.GetConverter(Property.PropertyType).ConvertFromString(row[ColumnName].ToString());
                    }
                }
                else
                {
                    ColumnValue = Property.PropertyType.IsValueType ? Activator.CreateInstance(Property.PropertyType) : null; //Utils.GetDefault(Property.PropertyType);
                }

                Property.SetValue(Record, ColumnValue, null);
            }

            return Record;
        }

        #endregion
    }
}
