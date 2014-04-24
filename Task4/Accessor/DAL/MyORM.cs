using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;
using System.Configuration;
using System.Data.SqlServerCe;

using Entities;


namespace FactoriesDAL
{
    class MyORM<T>: IAccessor<T>
    {
        SqlCeConnectionStringBuilder cnStr;//строка подлключения

        Type currentType;//текущий тип Т
        TableNameAttribute tableName;//аттрибут с именем таблицы
        PropertyInfo[] objProperties;//все свойства типа

        LinkedList<Type> fieldTypes = new LinkedList<Type>();//тип полей
        LinkedList<PropertyInfo> propName = new LinkedList<PropertyInfo>();//свойства помеченный атрибутом
        LinkedList<String> fieldName = new LinkedList<string>();//название столбцов из БД

        //массивы из коллекций LinkedList
        Type[] fType;
        PropertyInfo[] pInfo;
        string[] fName;

        string sqlQuery;//строка запроса к БД

        public MyORM()
        {
            cnStr = new SqlCeConnectionStringBuilder();
            cnStr.ConnectionString = ConfigurationManager.ConnectionStrings["cnStr"].ConnectionString;
        }

        public T[] GetAll()
        {

            InitializeProperties();//инициализируем переменные

            HashSet<T> result = new HashSet<T>();

            //собираем строку запроса
            sqlQuery = "SELECT ";

            for (int i = 0; i < fName.Length;i++) 
            {
                sqlQuery += fName[i];
                if ((i + 1) != fName.Length)
                {
                    sqlQuery += ", ";
                }
                else
                {
                    sqlQuery += " ";
                }
            }

            sqlQuery += "FROM " + tableName.name;

            using (SqlCeConnection cn=new SqlCeConnection(cnStr.ConnectionString))
            {
                try
                {
                    cn.Open();
                }
                catch(SqlCeException ex) 
                {
                    NLogger.WriteErrorInLog(ex.Message);
                    throw ex;
                }

                SqlCeCommand cmd = new SqlCeCommand(sqlQuery, cn);

                using (SqlCeDataReader data=cmd.ExecuteReader())//выполняем запрос
                {
                    while (data.Read())
                    {
                        object item = Activator.CreateInstance(typeof(T));//создаем объект

                        for (int i = 0; i < pInfo.Length; i++)
                        {
                            switch (fType[i].Name)//инициализируем его свойства
                            {
                                case "Int32":
                                    int valueInt = (int)data[fName[i]];
                                    pInfo[i].SetValue(item, valueInt);
                                    break;
                                case "String":
                                    string valueString=(string)data[fName[i]];
                                    pInfo[i].SetValue(item, valueString);
                                    break;
                                default:
                                    object valueObj = data[fName[i]];
                                    pInfo[i].SetValue(item, valueObj);
                                    break;
                            }
                        }
                        result.Add((T)item);//добавляем в результирующую коллекцию

                        item = null;
                    }
                }
            }

            ClearCollection();

            return result.ToArray();
        }

        public T GetByID(int id)
        {
            InitializeProperties();//инициализируем переменные

            HashSet<T> result = new HashSet<T>();

            //собираем строку запроса
            sqlQuery = "SELECT ";

            for (int i = 0; i < fName.Length; i++)
            {
                sqlQuery += fName[i];
                if ((i + 1) != fName.Length)
                {
                    sqlQuery += ", ";
                }
                else
                {
                    sqlQuery += " ";
                }
            }

            sqlQuery += "FROM " + tableName.name+" WHERE "+tableName.idFieldName+"="+id;

            using (SqlCeConnection cn = new SqlCeConnection(cnStr.ConnectionString))
            {
                try
                {
                    cn.Open();
                }
                catch (SqlCeException ex)
                {
                    NLogger.WriteErrorInLog(ex.Message);
                    throw ex;
                }

                SqlCeCommand cmd = new SqlCeCommand(sqlQuery, cn);

                using (SqlCeDataReader data = cmd.ExecuteReader())//выполняем запрос
                {
                    while (data.Read())
                    {
                        object item = Activator.CreateInstance(typeof(T));//создаем объект

                        for (int i = 0; i < pInfo.Length; i++)
                        {
                            switch (fType[i].Name)//инициализируем его свойства
                            {
                                case "Int32":
                                    int valueInt = (int)data[fName[i]];
                                    pInfo[i].SetValue(item, valueInt);
                                    break;
                                case "String":
                                    string valueString = (string)data[fName[i]];
                                    pInfo[i].SetValue(item, valueString);
                                    break;
                                default:
                                    object valueObj = data[fName[i]];
                                    pInfo[i].SetValue(item, valueObj);
                                    break;
                            }
                        }
                        result.Add((T)item);//добавляем в результирующую коллекцию

                        item = null;
                    }
                }
            }

            ClearCollection();//очищаем коллекции для нового вызова
            if (result.Count!=0)
                return result.First();
            else
                return default(T);
        }

        public void RemoveByID(int id)
        {
            InitializeProperties();

            sqlQuery = "DELETE FROM "+tableName.name+" WHERE "+tableName.idFieldName+"="+id;

            using (SqlCeConnection cn = new SqlCeConnection(cnStr.ConnectionString))
            {
                cn.Open();

                using (SqlCeCommand cmd = new SqlCeCommand(sqlQuery, cn))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            ClearCollection();
        }

        void InitializeProperties()
        {
            currentType = typeof(T);//текущий тип

            tableName = (TableNameAttribute)currentType.GetCustomAttribute(typeof(TableNameAttribute), false);//получаем аттрибут с именем таблицы

            objProperties = currentType.GetProperties();//получаем все свойства

            foreach (PropertyInfo p in objProperties)
            {
                FieldNameAttribute fieldAttr = (FieldNameAttribute)p.GetCustomAttribute(typeof(FieldNameAttribute), false);//если свойство помечено аттрибутом
                if (fieldAttr != null)
                {
                    //то заполняем коллекции
                    fieldName.AddFirst(fieldAttr.fieldName);//имя столбца в БД
                    fieldTypes.AddFirst(fieldAttr.fieldType);//тип столбца
                    propName.AddFirst(p);//свойство, помеченное аттрибутом
                }
            }

            fType = fieldTypes.ToArray();
            pInfo = propName.ToArray();
            fName = fieldName.ToArray();
        }

        void ClearCollection()
        {
            fieldTypes.Clear();
            propName.Clear();
            fieldName.Clear();
        }
        
    }
}
