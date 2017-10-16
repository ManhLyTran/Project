using System;
using System.Reflection;
namespace HVKTQS.DAL
{
    public class Null
    {
        // define application encoded null values
        public static int NullInteger
        {
            get { return int.MinValue; }
        }
   
        public static System.DateTime NullDate
        {
            get { return System.DateTime.MinValue; }
        }
        public static string NullString
        {
            get { return ""; }
        }
        public static bool NullBoolean
        {
            get { return false; }
        }
        public static Guid NullGuid
        {
            get { return Guid.Empty; }
        }
        public static byte[] NullByte
        {
            get { return null; }
        }

        // sets a field to an application encoded null value ( used in Presentation layer )
        public static object SetNull(object objField)
        {
            object functionReturnValue = null;
            if ((objField != null))
            {
                if (objField is int)
                {
                    functionReturnValue = NullInteger;
                }
                else if (objField is float)
                {
                    functionReturnValue = NullInteger;
                }
                else if (objField is double)
                {
                    functionReturnValue = NullInteger;
                }
                else if (objField is decimal)
                {
                    functionReturnValue = NullInteger;
                }
                else if (objField is System.DateTime)
                {
                    functionReturnValue = NullDate;
                }
                else if (objField is string)
                {
                    functionReturnValue = NullString;
                }
                else if (objField is bool)
                {
                    functionReturnValue = NullBoolean;
                }
                else if (objField is Guid)
                {
                    functionReturnValue = NullGuid;
                }
                else if (objField is byte[])
                {
                    functionReturnValue = NullByte ;
                }
                else {
                    throw new NullReferenceException();
                }
                // assume string
            }
            else {
                functionReturnValue = NullString;
            }
            return functionReturnValue;
        }
        // sets a field to an application encoded null value ( used in BLL layer )
        public static object SetNull(PropertyInfo objPropertyInfo)
        {
            object objResult = new object();
            switch (objPropertyInfo.PropertyType.ToString())
            {
                case "System.Int16":
                case "System.Int32":
                case "System.Int64":
                case "System.Single":
                case "System.Double":
                case "System.Decimal":
                    objResult = NullInteger;
                    break;
                case "System.DateTime":
                    objResult = NullDate;
                    break;
                case "System.String":
                case "System.Char":
                    objResult = NullString;
                    break;
                case "System.Boolean":
                    objResult = NullBoolean;
                    break;
                case "System.Guid":
                    objResult = NullGuid;
                    break;
                case "System.Byte[]":
                    //objResult = NullByte ;
                    objResult=NullByte;
                    break;
                case "System.Data.SqlTypes.SqlBinary":
                    objResult = null;
                    break;
                default:
                    // Enumerations default to the first entry
                    Type pType = objPropertyInfo.PropertyType;
                    if (pType.BaseType.Equals(typeof(System.Enum)))
                    {
                        System.Array objEnumValues = System.Enum.GetValues(pType);
                        Array.Sort(objEnumValues);
                        objResult = System.Enum.ToObject(pType, objEnumValues.GetValue(0));
                    }
                    else {
                        //Throw New NullReferenceException
                    }
                    break;
            }
            return objResult;
        }

        // convert an application encoded null value to a database null value ( used in DAL )
        public static object GetNull(object objField, object objDBNull)
        {
            object functionReturnValue = objField;
            if (objField == null)
            {
                functionReturnValue = objDBNull;
            }
            else if (objField is int)
            {
                if (Convert.ToInt32(objField) == NullInteger)
                {
                    functionReturnValue = objDBNull;
                }
            }
            else if (objField is float)
            {
                if (Convert.ToSingle(objField) == NullInteger)
                {
                    functionReturnValue = objDBNull;
                }
            }
            else if (objField is double)
            {
                if (Convert.ToDouble(objField) == NullInteger)
                {
                    functionReturnValue = objDBNull;
                }
            }
            else if (objField is decimal)
            {
                if (Convert.ToDecimal(objField) == NullInteger)
                {
                    functionReturnValue = objDBNull;
                }
            }
            else if (objField is System.DateTime)
            {
                if (Convert.ToDateTime(objField) == NullDate)
                {
                    functionReturnValue = NullDate;
                }
            }
            else if (objField is string)
            {
                if (objField == null)
                {
                    functionReturnValue = objDBNull;
                }
                else {
                    if (objField.ToString() == NullString)
                    {
                        functionReturnValue = objDBNull;
                    }
                }
            }
            //else if (objField is bool)
            //{
            //    if (Convert.ToBoolean(objField) == NullBoolean)
            //    {
            //        functionReturnValue = objDBNull;
            //    }
            //}
            else if (objField is Guid)
            {
                if (((System.Guid)objField).Equals(NullGuid))
                {
                    functionReturnValue = objDBNull;
                }
            }
            else if (objField is byte[])
            {
                if (((System.Byte[])objField).Equals(NullByte) || objField ==null)
                {
                    functionReturnValue = objDBNull;
                }
            }
            else {
                //Throw New NullReferenceException
            }
            return functionReturnValue;
        }

        // checks if a field contains an application encoded null value
        public static bool IsNull(object objField)
        {
            bool functionReturnValue = false;
            if (objField.Equals(SetNull(objField)))
            {
                functionReturnValue = true;
            }
            else {
                functionReturnValue = false;
            }
            return functionReturnValue;
        }

    }
}