using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataOperations
{

    public class Operations
    {
        private string ConnectionString = @"Data Source=DESKTOP-E0ADHLC\SQLEXPRESS;Initial Catalog='Master Sheets';Integrated Security=True; MultipleActiveResultSets=True";
        public bool HasErrors { get; set; }
        public string ExceptionMessage { get; set; }

        private List<String> productNameList;
        private List<String> patternNameList;
        private List<String> colorNameList;
        private List<String> sizeNameList;
        private List<String> brandNameList;

        public Operations()
        {
            productNameList = new List<String>();
            patternNameList = new List<String>();
            colorNameList = new List<String>();
            sizeNameList = new List<String>();
            brandNameList = new List<String>();

            LoadExistingCategoryListData();

            return;
        }

        private void LoadExistingCategoryListData()
        {
            using (SqlConnection cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                cn.Open();

                using (SqlCommand cmd2 = new SqlCommand { Connection = cn })
                {
                    cmd2.CommandText = "SELECT DISTINCT PatternName FROM PatternAbrTable";
                    SqlDataReader reader = cmd2.ExecuteReader();
                    while (reader.Read())
                    {
                        patternNameList.Add(reader.GetString(0));
                    }
                    reader.Close();
                }
                using (SqlCommand cmd3 = new SqlCommand { Connection = cn })
                {
                    cmd3.CommandText = "SELECT DISTINCT ColorName FROM ColorAbrTable";
                    SqlDataReader reader = cmd3.ExecuteReader();
                    while (reader.Read())
                    {
                        colorNameList.Add(reader.GetString(0));
                    }
                }

                using (SqlCommand cmd = new SqlCommand { Connection = cn })
                {
                    cmd.CommandText = "SELECT DISTINCT ProductName FROM ProductAbrTable";
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        productNameList.Add(reader.GetString(0));
                    }
                }

                using (SqlCommand cmd4 = new SqlCommand { Connection = cn })
                {
                    cmd4.CommandText = "SELECT DISTINCT SizeName FROM SizeAbrTable";
                    SqlDataReader reader = cmd4.ExecuteReader();
                    while (reader.Read())
                    {
                        sizeNameList.Add(reader.GetString(0));
                    }
                }

                using (SqlCommand cmd5 = new SqlCommand { Connection = cn })
                {
                    cmd5.CommandText = "SELECT DISTINCT BrandName FROM BrandAbrTable";
                    SqlDataReader reader = cmd5.ExecuteReader();
                    while (reader.Read())
                    {
                        brandNameList.Add(reader.GetString(0));
                    }
                }

                cn.Close();
            }
        }


        public List<String> getNamesList(string category)
        {
            switch (category)
            {
                case "Product":
                    return getProductNameList();

                case "Pattern":
                    return getPatternNameList();

                case "Color":
                    return getColorNameList();
                    
                case "Size":
                    return getSizeNameList();
                    
                case "Brand":
                    return getBrandNameList();

                default:
                    return null;
            }

        }

        public List<String> getAbbreviationsList(string category)
        {
            List<String> abbreviationsList = new List<string>();

            using (SqlConnection cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand { Connection = cn })
                {
                    cmd.CommandText = ("SELECT DISTINCT " + category + "ABV FROM " + category + "AbrTable"); 

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        abbreviationsList.Add(reader.GetString(0));
                    }
                    reader.Close();
                }


                return abbreviationsList;
            }
        }

        public List<String> getProductNameList()
        {
            return productNameList;
        }
        public List<String> getColorNameList()
        {
            return colorNameList;
        }
        public List<String> getPatternNameList()
        {
            return patternNameList;
        }
        public List<String> getSizeNameList()
        {
            return sizeNameList;
        }
        public List<String> getBrandNameList()
        {
            return brandNameList;
        }

        public List<String> getColorAbbreviationList()
        {
            List<String> colorAbbreviationList = new List<string>();

            using (SqlConnection cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand { Connection = cn })
                {
                    cmd.CommandText = "SELECT DISTINCT ColorABV FROM ColorAbrTable";
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        colorAbbreviationList.Add(reader.GetString(0));
                    }
                    reader.Close();
                }


                return colorAbbreviationList;
            }
        }

        public int tryToAddNewModelNumberToDatabase(string shape, string pattern, string color, string size, string brand)
        {
            int numOfExistingProducts = getCountOfExistingProducts(shape, pattern, color, size, brand);

            if(numOfExistingProducts>0) {
               MessageBox.Show("Existing Product Count: "+numOfExistingProducts);
            } else {
                MessageBox.Show("Adding new model number from operations");
                addNewModelNumberToDatabase(shape, pattern, color, size, brand);
                MessageBox.Show("New Model Number Added!");
            }

            return numOfExistingProducts; 
        }
            private int getCountOfExistingProducts(string shape, string pattern, string color, string size, string brand)
        {
            int countOfSimilarProducts = -1;

            using (SqlConnection cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn })
                {
                    cmd.CommandText = "getCountOfSimilarProducts";
                    cmd.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        cmd.Parameters.AddWithValue("@shape", shape);
                        cmd.Parameters.AddWithValue("@pattern", pattern);
                        cmd.Parameters.AddWithValue("@color", color);
                        cmd.Parameters.AddWithValue("@size", size);
                        cmd.Parameters.AddWithValue("@brand", brand);

                        cmd.Parameters.AddWithValue("@count", null);
                        cmd.Parameters["@count"].Direction = ParameterDirection.Output;
                        cmd.Parameters["@count"].Size = 50;

                        cn.Open();
                        int return_code = Convert.ToInt32(cmd.ExecuteScalar());
                        cn.Close();

                        countOfSimilarProducts = Convert.ToInt32(cmd.Parameters["@count"].Value);

                        return countOfSimilarProducts;
                    }
                    catch (SqlException ex)
                    {
                        HasErrors = true;
                        ExceptionMessage = ex.Message;
                        Console.WriteLine(ExceptionMessage);
                        Console.WriteLine(ex.InnerException);
                    }
                }
            }

            return countOfSimilarProducts;
        }
            private void addNewModelNumberToDatabase(string shape, string pattern, string color, string size, string brand){
            using (SqlConnection cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn })
                {
                    cmd.CommandText = "addNewModelNumberToProductCatalog";
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        cmd.Parameters.AddWithValue("@shape", shape);
                        cmd.Parameters.AddWithValue("@pattern", pattern);
                        cmd.Parameters.AddWithValue("@color", color);
                        cmd.Parameters.AddWithValue("@size", size);
                        cmd.Parameters.AddWithValue("@brand", brand);

                        cn.Open();
                        int return_code = Convert.ToInt32(cmd.ExecuteScalar());
                        cn.Close();
                    }
                    catch (SqlException ex)
                    {
                        HasErrors = true;
                        ExceptionMessage = ex.Message;
                        Console.WriteLine(ExceptionMessage);
                        Console.WriteLine(ex.InnerException);
                    }
                }
            }
        }

        public void tryToEditCurrentModelNumber(int SKU, string shape, string pattern, string color, string size, string brand){
            
            int numOfExistingProducts = getCountOfExistingProducts(shape, pattern, color, size, brand);

            if(numOfExistingProducts>0) {
               MessageBox.Show("Existing Product Count: "+numOfExistingProducts);
            } else 
            {
                editModelNumberInDatabase(SKU, shape, pattern, color, size, brand);
                MessageBox.Show("Model Number Edited!");
            }

            return;
        }
            private void editModelNumberInDatabase(int SKU, string shape, string pattern, string color, string size, string brand){
                            using (SqlConnection cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn })
                {
                    cmd.CommandText = "editModelNumberinProductCatalog";
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        cmd.Parameters.AddWithValue("@SKU", SKU);
                        cmd.Parameters.AddWithValue("@shape", shape);
                        cmd.Parameters.AddWithValue("@pattern", pattern);
                        cmd.Parameters.AddWithValue("@color", color);
                        cmd.Parameters.AddWithValue("@size", size);
                        cmd.Parameters.AddWithValue("@brand", brand);

                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                    catch (SqlException ex)
                    {
                        HasErrors = true;
                        ExceptionMessage = ex.Message;
                        Console.WriteLine(ExceptionMessage);
                        Console.WriteLine(ex.InnerException);
                    }
                }
            }
                return;
            }    

        public void addNewCategoryIntoDatabase(string typeOfCategory, string catName, string catAbbreviation)
        {
            //typeOfCategory will be either: Brand, Color, Pattern, Product, or Size

            string databaseTable        = typeOfCategory + "AbrTable";
            string nameColumn           = typeOfCategory + "Name";
            string abbreviationColumn   = typeOfCategory + "ABV";

            string  SQLInsertCommand = "INSERT INTO " + databaseTable + "(" + nameColumn + "," + abbreviationColumn + ") ";
                    SQLInsertCommand += "VALUES (@categoryName, @categoryAbbreviation)";

            MessageBox.Show("Trying to insert into " + databaseTable);
            MessageBox.Show("Column Name is " + nameColumn);
            MessageBox.Show("abbr Column is " + abbreviationColumn);

            MessageBox.Show("with values " + catName + ", " + catAbbreviation);

            using (SqlConnection cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand { Connection = cn })
                {
                    cmd.CommandText = SQLInsertCommand;

                    cmd.Parameters.AddWithValue("@categoryName", catName);
                    cmd.Parameters.AddWithValue("@categoryAbbreviation", catAbbreviation);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
