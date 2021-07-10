using Fields.Configurations.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Fields.Configurations.Repository
{
    public class ConfigurationRepository
    {
        /// <summary>
        /// Get Configurations
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<Products> GetConfigurations(string type)
        {
            List<Products> productConfigList = new List<Products>();
            string connString = CommonConstants.ConnectionString;
            SqlConnection sqlConn = new SqlConnection(connString);
            sqlConn.Open();
            SqlCommand cmd = new SqlCommand("GET_CONFIGURATIONS", sqlConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SOURCE", SqlDbType.VarChar).Value = type == "Default" ? "Source1" : "Source2";
            cmd.ExecuteNonQuery();
            using (SqlDataReader oReader = cmd.ExecuteReader())
            {
                Products config = new Products();
                while (oReader.Read())
                {
                    config.FieldName = oReader["FieldName"].ToString();
                    config.IsRequired = oReader["IsRequired"].ToString() == "true";
                    config.MaxLength = Convert.ToInt32(oReader["MaxLength"].ToString());
                    config.Source = oReader["Source"].ToString();
                    productConfigList.Add(config);
                }

                sqlConn.Close();
            }
            return productConfigList;
        }
        public string AddUpdateConfigurations(Products prodConfig)
        {
            string resultStatus = string.Empty;
            string connString = CommonConstants.ConnectionString;
            SqlConnection sqlConn = new SqlConnection(connString);
            sqlConn.Open();
            SqlCommand cmd = new SqlCommand("INS_UPD_CONFIGURATIONS", sqlConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FIELDNAME", SqlDbType.VarChar).Value = prodConfig.FieldName;
            cmd.Parameters.Add("@ISREQUIRED", SqlDbType.VarChar).Value = prodConfig.IsRequired.ToString();
            cmd.Parameters.Add("@MAXLENGTH", SqlDbType.Int).Value = prodConfig.MaxLength;
            cmd.Parameters.Add("@SOURCE", SqlDbType.VarChar).Value = prodConfig.Source;
            cmd.Parameters.Add("@OUTPUTVAR", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            var result = cmd.Parameters["@OUTPUTVAR"].Value.ToString();
            if (result == "0")
            {
                resultStatus = "Record inserted Successfully";
            }
            else
            {
                resultStatus = "Record Updated Successfully";
            }
            sqlConn.Close();
            return resultStatus;
        }
    }
}
