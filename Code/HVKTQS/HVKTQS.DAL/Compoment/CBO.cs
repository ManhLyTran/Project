using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Reflection;

namespace HVKTQS.DAL
{
    /// <summary>
    /// Lớp tùy chỉnh đối tượng nghiệp vụ đưa dữ liệu về kiểu không tường minh
    /// </summary>
    /// <remarks></remarks>
    public class CBO
    {
        //'-------------------------------------------------''
        //'Phần 1.1 làm việc với kiểu dữ liệu IDataReader
        //'-------------------------------------------------''

        /// <summary>
        /// Phương thức lấy tập các thuộc tính của một kiểu
        /// </summary>
        /// <param name="objType">Kiểu đối tượng</param>
        /// <returns>Trả lại tập các thuộc tính lưu trong ArrayList</returns>
        /// <remarks></remarks>
        public static ArrayList GetPropertyInfo(Type objType)
        {
            ArrayList objProperties = new ArrayList();
            foreach (PropertyInfo objProperty in objType.GetProperties())
            {
                objProperties.Add(objProperty);
            }
            return objProperties;
        }

        /// <summary>
        /// Phương thức lấy vị trí các cột trong IDataReader
        /// </summary>
        /// <param name="objProperties">Tập hợp các thuộc tính</param>
        /// <param name="dr">IDataReader</param>
        /// <returns>Trả lại mảng số nguyên các vị trí cột của IDataReader</returns>
        /// <remarks></remarks>
        private static int[] GetOrdinals(ArrayList objProperties, IDataReader dr)
        {
            int[] arrOrdinals = new int[objProperties.Count + 1];
            int intProperty = 0;
            if ((dr != null))
            {
                for (intProperty = 0; intProperty <= objProperties.Count - 1; intProperty++)
                {
                    arrOrdinals[intProperty] = -1;
                    try
                    {
                        arrOrdinals[intProperty] = dr.GetOrdinal(((PropertyInfo)objProperties[intProperty]).Name);
                    }
                    catch
                    {
                        // property does not exist in datareader
                    }
                }
            }
            return arrOrdinals;
        }

        /// <summary>
        /// Phương thức tạo đối tượng từ giá trị lấy từ IDataReader
        /// </summary>
        /// <param name="objType">Kiểu đối tượng</param>
        /// <param name="dr">IDataReader</param>
        /// <param name="objProperties">Mảng chứa các thuộc tính của đối tượng</param>
        /// <param name="arrOrdinals">Mảng lưu vị trí các cột</param>
        /// <returns>Trả lại một đối tượng có kiểu Object</returns>
        /// <remarks></remarks>
        private static object CreateObject(Type objType, IDataReader dr, ArrayList objProperties, int[] arrOrdinals)
        {
            object objObject = Activator.CreateInstance(objType);
            int intProperty = 0;
            // fill object with values from datareader
            for (intProperty = 0; intProperty <= objProperties.Count - 1; intProperty++)
            {
                if (((PropertyInfo)objProperties[intProperty]).CanWrite)
                {
                    if (arrOrdinals[intProperty] != -1)
                    {
                        if (Convert.IsDBNull(dr.GetValue(arrOrdinals[intProperty])))
                        {
                            // translate Null value
                            ((PropertyInfo)objProperties[intProperty]).SetValue(objObject, Null.SetNull((PropertyInfo)objProperties[intProperty]), null);
                        }
                        else
                        {
                            try
                            {
                                // try implicit conversion first
                                ((PropertyInfo)objProperties[intProperty]).SetValue(objObject, dr.GetValue(arrOrdinals[intProperty]), null);
                                // data types do not match
                            }
                            catch
                            {
                                try
                                {
                                    Type pType = ((PropertyInfo)objProperties[intProperty]).PropertyType;
                                    //need to handle enumeration conversions differently than other base types
                                    if (pType.BaseType.Equals(typeof(System.Enum)))
                                    {
                                        ((PropertyInfo)objProperties[intProperty]).SetValue(objObject, System.Enum.ToObject(pType, dr.GetValue(arrOrdinals[intProperty])), null);
                                    }
                                    else
                                    {
                                        // try explicit conversion
                                        ((PropertyInfo)objProperties[intProperty]).SetValue(objObject, Convert.ChangeType(dr.GetValue(arrOrdinals[intProperty]), pType), null);
                                    }
                                }
                                catch
                                {
                                    // error assigning a datareader value to a property
                                    ((PropertyInfo)objProperties[intProperty]).SetValue(objObject, Null.SetNull((PropertyInfo)objProperties[intProperty]), null);
                                }
                            }
                        }
                        // property does not exist in datareader
                    }
                    else
                    {
                        ((PropertyInfo)objProperties[intProperty]).SetValue(objObject, Null.SetNull((PropertyInfo)objProperties[intProperty]), null);
                    }
                }
            }
            return objObject;
        }

        /// <summary>
        /// Phương thức chuyển 1 bản ghi trong IDataReader thành một đối tượng
        /// </summary>
        /// <param name="dr">IDataReader</param>
        /// <param name="objType">Kiểu đối tượng</param>
        /// <returns>Trả lại một đối tượng</returns>
        /// <remarks></remarks>
        public static object FillObject(IDataReader dr, Type objType)
        {
            object objFillObject = null;
            // get properties for type
            ArrayList objProperties = GetPropertyInfo(objType);
            // get ordinal positions in datareader
            int[] arrOrdinals = GetOrdinals(objProperties, dr);
            // read datareader
            if (dr.Read())
            {
                // fill business object
                objFillObject = CreateObject(objType, dr, objProperties, arrOrdinals);
            }
            else
            {
                objFillObject = null;
            }
            // close datareader
            if ((dr != null))
            {
                dr.Close();
            }
            return objFillObject;
        }

        /// <summary>
        ///Phương thức chuyển 1 hoặc nhiều bản ghi của IDataReader sang thành mảng đối tượng
        /// </summary>
        /// <param name="dr">IDataReader</param>
        /// <param name="objType">Kiểu đối tượng</param>
        /// <returns>Trả về một mảng chứa tập các đối tượng</returns>
        /// <remarks></remarks>
        public static ArrayList FillCollection(IDataReader dr, Type objType)
        {
            ArrayList objFillCollection = new ArrayList();
            object objFillObject = null;
            // get properties for type
            ArrayList objProperties = GetPropertyInfo(objType);
            // get ordinal positions in datareader
            int[] arrOrdinals = GetOrdinals(objProperties, dr);
            // iterate datareader
            while (dr.Read())
            {
                // fill business object
                objFillObject = CreateObject(objType, dr, objProperties, arrOrdinals);
                // add to collection
                objFillCollection.Add(objFillObject);
            }
            // close datareader
            if ((dr != null))
            {
                dr.Close();
            }
            return objFillCollection;
        }

        /// <summary>
        /// Phương thức chuyển 1 hoặc nhiều bản ghi của IDataReader sang thành IList của tập các đối tượng
        /// </summary>
        /// <param name="dr">IDataReader</param>
        /// <param name="objType">Kiểu đối tượng</param>
        /// <param name="objToFill">Đối tượng kiểu IList</param>
        /// <returns>Trả về kiểu IList chứa tập các đối tượng</returns>
        /// <remarks></remarks>
        public static IList FillIList(IDataReader dr, Type objType, ref IList objToFill)
        {
            object objFillObject = null;
            // get properties for type
            ArrayList objProperties = GetPropertyInfo(objType);
            // get ordinal positions in datareader
            int[] arrOrdinals = GetOrdinals(objProperties, dr);
            // iterate datareader
            while (dr.Read())
            {
                // fill business object
                objFillObject = CreateObject(objType, dr, objProperties, arrOrdinals);
                // add to collection
                objToFill.Add(objFillObject);
            }
            // close datareader
            if ((dr != null))
            {
                dr.Close();
            }
            return objToFill;
        }

        /// <summary>
        /// Phương thức chuyển 1 hoặc nhiều bản ghi của IDataReader sang thành Danh sách các đối tượng
        /// </summary>
        /// <param name="dr">IDataReader</param>
        /// <param name="objType">Kiểu đối tượng</param>
        /// <returns>Trả lại kiểu List chứa tập các đối tượng</returns>
        /// <remarks></remarks>
        public static List<object> FillList(IDataReader dr, Type objType)
        {
            List<object> objFillCollection = new List<object>();
            object objFillObject = null;
            // get properties for type
            ArrayList objProperties = GetPropertyInfo(objType);
            // get ordinal positions in datareader
            int[] arrOrdinals = GetOrdinals(objProperties, dr);
            // iterate datareader
            while (dr.Read())
            {
                // fill business object
                objFillObject = CreateObject(objType, dr, objProperties, arrOrdinals);
                // add to collection
                objFillCollection.Add(objFillObject);
            }
            // close datareader
            if ((dr != null))
            {
                dr.Close();
            }
            return objFillCollection;
        }

        //'-------------------------------------------------''
        //'Phần 1.2 làm việc với kiểu dữ liệu DataTable
        //'-------------------------------------------------''

        /// <summary>
        /// Phương thức lấy vị trí các cột trong DataTable
        /// </summary>
        /// <param name="objProperties">Tập hợp các thuộc tính</param>
        /// <param name="dt">DataTable</param>
        /// <returns>Trả lại mảng số nguyên các vị trí cột của DataTable</returns>
        /// <remarks></remarks>
        private static int[] GetOrdinals(ArrayList objProperties, DataTable dt)
        {
            int[] arrOrdinals = new int[objProperties.Count + 1];
            int intProperty = 0;
            if ((dt != null))
            {
                for (intProperty = 0; intProperty <= objProperties.Count - 1; intProperty++)
                {
                    arrOrdinals[intProperty] = -1;
                    try
                    {
                        arrOrdinals[intProperty] = dt.Columns[((PropertyInfo)objProperties[intProperty]).Name].Ordinal;
                    }
                    catch
                    {
                        // property does not exist in datareader
                    }
                }
            }
            return arrOrdinals;
        }

        /// <summary>
        /// Phương thức tạo đối tượng từ giá trị lấy từ DataTable
        /// </summary>
        /// <param name="objType">Kiểu đối tượng</param>
        /// <param name="dt">DataTable</param>
        /// <param name="r">Vị trí bản ghi cần tạo thành đối tượng</param>
        /// <param name="objProperties">Mảng chưa các thuộc tính của đối tượng</param>
        /// <param name="arrOrdinals">Mảng chứa vị trí của DataTable</param>
        /// <returns>Trả lại đối tượng có kiểu Object</returns>
        /// <remarks></remarks>
        private static object CreateObject(Type objType, DataTable dt, int r, ArrayList objProperties, int[] arrOrdinals)
        {
            object objObject = Activator.CreateInstance(objType);
            int intProperty = 0;
            // fill object with values from datareader
            for (intProperty = 0; intProperty <= objProperties.Count - 1; intProperty++)
            {
                if (((PropertyInfo)objProperties[intProperty]).CanWrite)
                {
                    if (arrOrdinals[intProperty] != -1)
                    {
                        if (Convert.IsDBNull(dt.Rows[r][arrOrdinals[intProperty]]))
                        {
                            // translate Null value
                            ((PropertyInfo)objProperties[intProperty]).SetValue(objObject, Null.SetNull((PropertyInfo)objProperties[intProperty]), null);
                        }
                        else
                        {
                            try
                            {
                                // try implicit conversion first
                                ((PropertyInfo)objProperties[intProperty]).SetValue(objObject, dt.Rows[r][arrOrdinals[intProperty]], null);
                                // data types do not match
                            }
                            catch
                            {
                                try
                                {
                                    Type pType = ((PropertyInfo)objProperties[intProperty]).PropertyType;
                                    //need to handle enumeration conversions differently than other base types
                                    if (pType.BaseType.Equals(typeof(System.Enum)))
                                    {
                                        ((PropertyInfo)objProperties[intProperty]).SetValue(objObject, System.Enum.ToObject(pType, dt.Rows[r][arrOrdinals[intProperty]]), null);
                                    }
                                    else
                                    {
                                        // try explicit conversion
                                        ((PropertyInfo)objProperties[intProperty]).SetValue(objObject, Convert.ChangeType(dt.Rows[r][arrOrdinals[intProperty]], pType), null);
                                    }
                                }
                                catch
                                {
                                    // error assigning a datareader value to a property
                                    ((PropertyInfo)objProperties[intProperty]).SetValue(objObject, Null.SetNull((PropertyInfo)objProperties[intProperty]), null);
                                }
                            }
                        }
                        // property does not exist in datareader
                    }
                    else
                    {
                        ((PropertyInfo)objProperties[intProperty]).SetValue(objObject, Null.SetNull((PropertyInfo)objProperties[intProperty]), null);
                    }
                }
            }
            return objObject;
        }

        /// <summary>
        /// Phương thức đổ dữ liệu từ DataTable sang 1 đối tượng
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="objType">Kiểu đối tượng</param>
        /// <returns>Trả về một đối tượng</returns>
        /// <remarks></remarks>
        public static object FillObject(DataTable dt, Type objType)
        {
            object objFillObject = null;
            // get properties for type
            ArrayList objProperties = GetPropertyInfo(objType);
            // get ordinal positions in datatable
            int[] arrOrdinals = GetOrdinals(objProperties, dt);
            // read datatable
            if ((dt.Rows.Count > 0))
            {
                // fill business object
                objFillObject = CreateObject(objType, dt, 0, objProperties, arrOrdinals);
            }
            else
            {
                objFillObject = null;
            }
            return objFillObject;
        }

        /// <summary>
        /// Phương thức đổ dữ liệu từ Datatable sang ArrayList chứa tập các đối tượng
        /// </summary>
        /// <param name="dt">Datatable</param>
        /// <param name="objType">Kiểu đối tượng</param>
        /// <returns>Trả về ArrayList chưa tập các đối tượng</returns>
        /// <remarks></remarks>
        public static ArrayList FillCollection(DataTable dt, Type objType)
        {
            ArrayList objFillCollection = new ArrayList();
            object objFillObject = null;
            // get properties for type
            ArrayList objProperties = GetPropertyInfo(objType);
            // get ordinal positions in datatable
            int[] arrOrdinals = GetOrdinals(objProperties, dt);
            // iterate datatable
            for (int r = 0; r <= dt.Rows.Count - 1; r++)
            {
                // fill business object
                objFillObject = CreateObject(objType, dt, r, objProperties, arrOrdinals);
                // add to collection
                objFillCollection.Add(objFillObject);
            }
            return objFillCollection;
        }
    }

    /// <summary>
    /// Lớp tùy chỉnh đối tượng nghiệp vụ đưa dữ liệu về kiểu tường minh
    /// </summary>
    /// <typeparam name="T">Kiểu dữ liệu mẫu</typeparam>
    /// <remarks></remarks>
    public class CBO<T>
    {
        //'-------------------------------------------------''
        //'Phần 2.1 làm việc với kiểu dữ liệu IDataReader
        //'-------------------------------------------------''
        /// <summary>
        /// Phương thức lấy tập các thuộc tính của một kiểu
        /// </summary>
        /// <param name="objType">Kiểu đối tượng</param>
        /// <returns>Trả về kiểu List chứa tập các thuộc tính của kiểu</returns>
        /// <remarks></remarks>
        public static List<PropertyInfo> GetPropertyInfo(Type objType)
        {
            List<PropertyInfo> objProperties = new List<PropertyInfo>();
            foreach (PropertyInfo objProperty in objType.GetProperties())
            {
                objProperties.Add(objProperty);
            }
            return objProperties;
        }

        /// <summary>
        /// Phương thức mảng chứa vị trí các cột của IDataReader
        /// </summary>
        /// <param name="objProperties">Mảng chứa các thuộc tính</param>
        /// <param name="dr">IDataReader</param>
        /// <returns>Trả về mảng số nguyên chứa vị trí các cột của IDataReader</returns>
        /// <remarks></remarks>
        private static int[] GetOrdinals(List<PropertyInfo> objProperties, IDataReader dr)
        {
            int[] arrOrdinals = new int[objProperties.Count + 1];
            int intProperty = 0;
            if ((dr != null))
            {
                for (intProperty = 0; intProperty <= objProperties.Count - 1; intProperty++)
                {
                    arrOrdinals[intProperty] = -1;
                    try
                    {
                        arrOrdinals[intProperty] = dr.GetOrdinal(objProperties[intProperty].Name);
                    }
                    catch
                    {
                        // property does not exist in datareader
                    }
                }
            }
            return arrOrdinals;
        }

        /// <summary>
        /// Phương thức tạo đối tượng từ giá trị lấy từ IDataReader
        /// </summary>
        /// <param name="objType">Kiểu dữ liệu của đối tượng</param>
        /// <param name="dr">IDataReader</param>
        /// <param name="objProperties">Danh sách chứa các thuộc tính của kiểu</param>
        /// <param name="arrOrdinals">Mảng chứa vị trí các cột của IDataReader</param>
        /// <returns>Trả về một đối tượng có kiểu T</returns>
        /// <remarks></remarks>
        private static T CreateObject(T objType, IDataReader dr, List<PropertyInfo> objProperties, int[] arrOrdinals)
        {
            T objObject = objType;
            //Activator.CreateInstance(objType)
            int intProperty = 0;
            // fill object with values from datareader
            for (intProperty = 0; intProperty <= objProperties.Count - 1; intProperty++)
            {
                if (((PropertyInfo)objProperties[intProperty]).CanWrite)
                {
                    if (arrOrdinals[intProperty] != -1)
                    {
                        if (Convert.IsDBNull(dr.GetValue(arrOrdinals[intProperty])))
                        {
                            // translate Null value
                            objProperties[intProperty].SetValue(objObject, Null.SetNull(objProperties[intProperty]), null);
                        }
                        else
                        {
                            try
                            {
                                // try implicit conversion first
                                objProperties[intProperty].SetValue(objObject, dr.GetValue(arrOrdinals[intProperty]), null);
                                // data types do not match
                            }
                            catch
                            {
                                try
                                {
                                    Type pType = objProperties[intProperty].PropertyType;
                                    //need to handle enumeration conversions differently than other base types
                                    if (pType.BaseType.Equals(typeof(System.Enum)))
                                    {
                                        objProperties[intProperty].SetValue(objObject, System.Enum.ToObject(pType, dr.GetValue(arrOrdinals[intProperty])), null);
                                    }
                                    else
                                    {
                                        // try explicit conversion
                                        objProperties[intProperty].SetValue(objObject, Convert.ChangeType(dr.GetValue(arrOrdinals[intProperty]), pType), null);
                                    }
                                }
                                catch
                                {
                                    // error assigning a datareader value to a property
                                    objProperties[intProperty].SetValue(objObject, Null.SetNull(objProperties[intProperty]), null);
                                }
                            }
                        }
                        // property does not exist in datareader
                    }
                    else
                    {
                        //objProperties[intProperty].SetValue(objObject, Null.SetNull(objProperties[intProperty]), Nothing)
                    }
                }
            }
            return objObject;
        }

        /// <summary>
        /// Phương thức đổ dữ liệu từ IDataReader thành đối tượng có kiểu T
        /// </summary>
        /// <param name="dr">IDataReader</param>
        /// <param name="objType">Kiểu dữ liệu của đối tượng</param>
        /// <returns>Trả về đối tượng có kiểu T</returns>
        /// <remarks></remarks>
        public static T FillObject(IDataReader dr, T objType)
        {
            T objFillObject;
            // get properties for type
            List<PropertyInfo> objProperties = GetPropertyInfo(objType.GetType());
            // get ordinal positions in datareader
            int[] arrOrdinals = GetOrdinals(objProperties, dr);
            // read datareader
            if (dr.Read())
            {
                // fill business object
                objFillObject = CreateObject(objType, dr, objProperties, arrOrdinals);
            }
            else
            {
                objFillObject = objType;
            }
            // close datareader
            if ((dr != null))
            {
                dr.Close();
            }
            return objFillObject;
        }

        /// <summary>
        /// Phương thức đổ dữ liệu từ kiểu IDataReader sang danh sách đối tượng có kiểu T
        /// </summary>
        /// <param name="dr">IDataReader</param>
        /// <param name="objType">Kiểu dữ liệu của đối tượng</param>
        /// <returns>Trả về kiểu List chứa các đối tượng có kiểu T</returns>
        /// <remarks></remarks>
        public static List<T> FillCollection(IDataReader dr, T objType)
        {
            List<T> objFillCollection = new List<T>();
            T objFillObject = default(T);
            // get properties for type
            List<PropertyInfo> objProperties = GetPropertyInfo(objType.GetType());
            // get ordinal positions in datareader
            int[] arrOrdinals = GetOrdinals(objProperties, dr);
            // iterate datareader
            while (dr.Read())
            {
                // fill business object
                objFillObject = CreateObject(objType, dr, objProperties, arrOrdinals);
                // add to collection
                objFillCollection.Add(objFillObject);
            }
            // close datareader
            if ((dr != null))
            {
                dr.Close();
            }
            return objFillCollection;
        }

        //'-------------------------------------------------''
        //'Phần 2.2 làm việc với kiểu dữ liệu DataTable
        //'-------------------------------------------------''

        /// <summary>
        /// Phương thức lấy về mảng vị trí các cột của DataTable
        /// </summary>
        /// <param name="objProperties">Danh sách chứa các thuộc tính của lớp đối tượng</param>
        /// <param name="dt">DataTable</param>
        /// <returns>Trả lại mảng số nguyên chứa vị trí các cột của DataTable </returns>
        /// <remarks></remarks>
        private static int[] GetOrdinals(List<PropertyInfo> objProperties, DataTable dt)
        {
            int[] arrOrdinals = new int[objProperties.Count + 1];
            int intProperty = 0;
            if ((dt != null))
            {
                for (intProperty = 0; intProperty <= objProperties.Count - 1; intProperty++)
                {
                    arrOrdinals[intProperty] = -1;
                    try
                    {
                        //arrOrdinals[intProperty] = dr.GetOrdinal(CType(objProperties[intProperty], PropertyInfo).Name)
                        arrOrdinals[intProperty] = dt.Columns[objProperties[intProperty].Name].Ordinal;
                    }
                    catch
                    {
                        // property does not exist in datareader
                    }
                }
            }
            return arrOrdinals;
        }

        /// <summary>
        /// Phương thức tạo đối tượng từ DataTable
        /// </summary>
        /// <param name="objType">Kiểu dữ liệu của đối tượng</param>
        /// <param name="dt">DataTable</param>
        /// <param name="r">Vị trí bản ghi của DataTable</param>
        /// <param name="objProperties">Danh sách chứa các thuộc tính</param>
        /// <param name="arrOrdinals">Mảng số nguyên chứa vị trí các cột của DataTable</param>
        /// <returns>Trả lại đối tượng có kiểu T</returns>
        /// <remarks></remarks>
        private static T CreateObject(T objType, DataTable dt, int r, List<PropertyInfo> objProperties, int[] arrOrdinals)
        {
            T objObject = objType;
            //Activator.CreateInstance(objType)
            int intProperty = 0;

            // fill object with values from datareader
            for (intProperty = 0; intProperty <= objProperties.Count - 1; intProperty++)
            {
                if ((objProperties[intProperty].CanWrite))
                {
                    if (arrOrdinals[intProperty] != -1)
                    {
                        if (Convert.IsDBNull(dt.Rows[r][arrOrdinals[intProperty]]))
                        {
                            // translate Null value
                            objProperties[intProperty].SetValue(objObject, Null.SetNull(objProperties[intProperty]), null);
                        }
                        else
                        {
                            try
                            {
                                // try implicit conversion first
                                objProperties[intProperty].SetValue(objObject, dt.Rows[r][arrOrdinals[intProperty]], null);
                                // data types do not match
                            }
                            catch
                            {
                                try
                                {
                                    Type pType = objProperties[intProperty].PropertyType;
                                    //need to handle enumeration conversions differently than other base types
                                    if (pType.BaseType.Equals(typeof(System.Enum)))
                                    {
                                        objProperties[intProperty].SetValue(objObject, System.Enum.ToObject(pType, dt.Rows[r][arrOrdinals[intProperty]]), null);
                                    }
                                    else
                                    {
                                        // try explicit conversion
                                        objProperties[intProperty].SetValue(objObject, Convert.ChangeType(dt.Rows[r][arrOrdinals[intProperty]], pType), null);
                                    }
                                }
                                catch
                                {
                                    // error assigning a datareader value to a property
                                    objProperties[intProperty].SetValue(objObject, Null.SetNull(objProperties[intProperty]), null);
                                }
                            }
                        }
                        // property does not exist in datareader
                    }
                    else
                    {
                        objProperties[intProperty].SetValue(objObject, Null.SetNull(objProperties[intProperty]), null);
                    }
                }
            }
            return objObject;
        }

        /// <summary>
        /// Phương thức đổ dữ liệu từ DataTable sang 1 đối tượng
        /// </summary>
        /// <param name="dt">Datatable</param>
        /// <param name="objType">Kiểu dữ liệu của đối tượng</param>
        /// <returns>Trả về một đối tượng có kiểu T</returns>
        /// <remarks></remarks>
        public static T FillObject(DataTable dt, T objType)
        {
            T objFillObject;
            // get properties for type
            List<PropertyInfo> objProperties = GetPropertyInfo(objType.GetType());
            // get ordinal positions in datatable
            int[] arrOrdinals = GetOrdinals(objProperties, dt);
            // read datatable
            if ((dt.Rows.Count > 0))
            {
                // fill business object
                objFillObject = CreateObject(objType, dt, 0, objProperties, arrOrdinals);
            }
            else
            {
                objFillObject = objType;
            }
            return objFillObject;
        }

        /// <summary>
        /// Phương thức đổ dữ liệu từ DataTable sang danh sách đối tượng có kiểu T
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="objType">Kiểu đối tượng </param>
        /// <returns>Trả về kiểu List chứa tập các đối tượng có kiểu T</returns>
        /// <remarks></remarks>
        public static List<T> FillCollection(DataTable dt, T objType)
        {
            List<T> objFillCollection = new List<T>();
            T objFillObject = default(T);
            // get properties for type
            List<PropertyInfo> objProperties = GetPropertyInfo(objType.GetType());
            // get ordinal positions in datatable
            int[] arrOrdinals = GetOrdinals(objProperties, dt);
            // iterate datatable
            for (int r = 0; r <= dt.Rows.Count - 1; r++)
            {
                // fill business object
                objFillObject = CreateObject(objType, dt, r, objProperties, arrOrdinals);
                // add to collection
                objFillCollection.Add(objFillObject);
            }
            return objFillCollection;
        }
    }
}