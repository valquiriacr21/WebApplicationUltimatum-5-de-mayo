//using Microsoft.Analytics.Interfaces;
//using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebApplicationUltimatum.Models;
using System.Data;


namespace WebApplicationUltimatum.Data
{
    public class ProductData
    {
        public static bool Register(Product oProduct)
        {
            using (SqlConnection oConnection = new SqlConnection(NorthwindEntitiesDBContext.RouteMapConnection))
            {
                SqlCommand oCommand = new SqlCommand("p_Products_Register", oConnection);
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.Parameters.AddWithValue("@ProductName", oProduct.ProductName);
                oCommand.Parameters.AddWithValue("@QuantityPerUnit", oProduct.QuantityPerUnit);
                oCommand.Parameters.AddWithValue("@UnitPrice", oProduct.UnitPrice);
                oCommand.Parameters.AddWithValue("@UnitsInStock", oProduct.UnitsInStock);
                oCommand.Parameters.AddWithValue("@UnitsOnOrder", oProduct.UnitsOnOrder);
                oCommand.Parameters.AddWithValue("@ReorderLevel", oProduct.ReorderLevel);
                oCommand.Parameters.AddWithValue("@Discontinued", oProduct.Discontinued);

                try
                {
                    oConnection.Open();
                    oCommand.ExecuteNonQuery();
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }


        }
        public static bool Update(Product oProduct)
        {
            using (SqlConnection oConnection = new SqlConnection(NorthwindEntitiesDBContext.RouteMapConnection))
            {
                SqlCommand oCommand = new SqlCommand("p_Products_Update", oConnection);
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.Parameters.AddWithValue("@ProductID", oProduct.ProductID);
                oCommand.Parameters.AddWithValue("@ProductName", oProduct.ProductName);
                oCommand.Parameters.AddWithValue("@QuantityPerUnit", oProduct.QuantityPerUnit);
                oCommand.Parameters.AddWithValue("@UnitPrice", oProduct.UnitPrice);
                oCommand.Parameters.AddWithValue("@UnitsInStock", oProduct.UnitsInStock);
                oCommand.Parameters.AddWithValue("@UnitsOnOrder", oProduct.UnitsOnOrder);
                oCommand.Parameters.AddWithValue("@ReorderLevel", oProduct.ReorderLevel);
                oCommand.Parameters.AddWithValue("@Discontinued", oProduct.Discontinued);

                try
                {
                    oConnection.Open();
                    oCommand.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }


        }
        public static List<Product> List()
        {
            List<Product> oList = new List<Product>();
            using (SqlConnection oConnection = new SqlConnection(NorthwindEntitiesDBContext.RouteMapConnection))
            {
                SqlCommand oCommand = new SqlCommand("p_Products_List", oConnection);
                oCommand.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConnection.Open();
                    oCommand.ExecuteNonQuery();

                    using (SqlDataReader dr=oCommand.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oList.Add(new Product()
                            {
                                ProductID=Convert.ToInt32(dr["ProductID"]),
                                ProductName=dr["ProductName"].ToString(),
                                QuantityPerUnit= dr["QuantityPerUnit"].ToString(),
                                UnitPrice= Convert.ToDecimal(dr["UnitPrice"]),
                                UnitsInStock = Convert.ToInt16(dr["UnitsInStock"]),
                                UnitsOnOrder = Convert.ToInt16(dr["UnitsOnOrder"]),
                                ReorderLevel = Convert.ToInt16(dr["ReorderLevel"]),
                                Discontinued = Convert.ToBoolean(dr["Discontinued"]),

                            });
                        }
                    }
                    return oList;
 
                }
                catch (Exception ex)
                {
                    return oList;
                }
            }


        }
        public static Product Get(int id)
        {
            Product oProduct = new Product();
            using (SqlConnection oConnection = new SqlConnection(NorthwindEntitiesDBContext.RouteMapConnection))
            {
                SqlCommand oCommand = new SqlCommand("p_Products_Get", oConnection);
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.Parameters.AddWithValue("@ProductID", id);

                try
                {
                    oConnection.Open();
                   // oCommand.ExecuteNonQuery();

                    using (SqlDataReader dr = oCommand.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oProduct=new Product()
                            {
                                ProductID = Convert.ToInt32(dr["ProductID"]),
                                ProductName = dr["ProductName"].ToString(),
                                QuantityPerUnit = dr["QuantityPerUnit"].ToString(),
                                UnitPrice = Convert.ToDecimal(dr["UnitPrice"]),
                                UnitsInStock = Convert.ToInt16(dr["UnitsInStock"]),
                                UnitsOnOrder = Convert.ToInt16(dr["UnitsOnOrder"]),
                                ReorderLevel = Convert.ToInt16(dr["ReorderLevel"]),
                                Discontinued = Convert.ToBoolean(dr["Discontinued"]),

                            };
                        }
                    }
                    return oProduct;

                }
                catch (Exception ex)
                {
                    return oProduct;
                }
            }


        }
        public static bool Delete(int id)
        {
            Product oProduct = new Product();

            using (SqlConnection oConnection = new SqlConnection(NorthwindEntitiesDBContext.RouteMapConnection))
            {
                SqlCommand oCommand = new SqlCommand("p_Products_Delete", oConnection);
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.Parameters.AddWithValue("@ProductID", id);

                try
                {
                    oConnection.Open();
                    oCommand.ExecuteNonQuery();
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
            }


        }
    }
}