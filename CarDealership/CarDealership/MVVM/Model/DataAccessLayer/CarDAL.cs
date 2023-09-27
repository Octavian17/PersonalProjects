﻿using CarDealership.MVVM.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarDealership.MVVM.Model.DataAccessLayer
{
    class CarDAL
    {
        public void InsertCar(Car car)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertCar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramBrand = new SqlParameter("@brand", car.Brand);
                SqlParameter paramModel = new SqlParameter("@model", car.Model);
                SqlParameter paramPrice = new SqlParameter("@price", car.Price);
                SqlParameter paramYear = new SqlParameter("@year", car.FabricationYear);
                SqlParameter paramColor = new SqlParameter("@color", car.Color);
                SqlParameter paramEngine = new SqlParameter("@engine", car.Engine);
                SqlParameter paramImage = new SqlParameter("@image", car.Image);
                cmd.Parameters.Add(paramBrand);
                cmd.Parameters.Add(paramModel);
                cmd.Parameters.Add(paramPrice);
                cmd.Parameters.Add(paramYear);
                cmd.Parameters.Add(paramColor);
                cmd.Parameters.Add(paramEngine);
                cmd.Parameters.Add(paramImage);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public ObservableCollection<string> GetAllBrands()
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllBrands", con);
                ObservableCollection<string> result = new ObservableCollection<string>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(reader.GetString(0));
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public ObservableCollection<Car> FillDataGrid()
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllCars", con);
                ObservableCollection<Car> result = new ObservableCollection<Car>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Car car = new Car();
                    car.CarID = (int)reader[0];
                    car.Brand = reader.GetString(1);
                    car.Model = reader.GetString(2);
                    car.Price = (int)reader[3];
                    car.FabricationYear = reader.GetString(4);
                    car.Color = reader.GetString(5);
                    car.Engine = reader.GetString(6);
                    car.Image = reader.GetString(7);
                    if (VerifyCarInCarClient(car) == -1)
                        result.Add(car);
                }
                return result;
              
            }
            finally
            {
                con.Close();
            }
           

        }
        public void ModifyCar(Car car)
        {
            using (SqlConnection con = HelperDAL.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyCar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (car != null)
                {
                    SqlParameter paramId = new SqlParameter("@carID", car.CarID);
                    SqlParameter paramBrand = new SqlParameter("@brand", car.Brand);
                    SqlParameter paramModel = new SqlParameter("@model", car.Model);
                    SqlParameter paramPrice = new SqlParameter("@price", car.Price);
                    SqlParameter paramYear = new SqlParameter("@year", car.FabricationYear);
                    SqlParameter paramColor = new SqlParameter("@color", car.Color);
                    SqlParameter paramEngine = new SqlParameter("@engine", car.Engine);
                    SqlParameter paramImage = new SqlParameter("@image", car.Image);
                    cmd.Parameters.Add(paramId);
                    cmd.Parameters.Add(paramBrand);
                    cmd.Parameters.Add(paramModel);
                    cmd.Parameters.Add(paramPrice);
                    cmd.Parameters.Add(paramYear);
                    cmd.Parameters.Add(paramColor);
                    cmd.Parameters.Add(paramEngine);
                    cmd.Parameters.Add(paramImage);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("You have to select a car!");

                }
            }
        }
        public int VerifyCarInCarClient(Car car)
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                if (car != null)
                {
                    SqlCommand cmd = new SqlCommand("VerifyCarInCarClient", con);
                    int result = -1;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlParameter paramId = new SqlParameter("@id", car.CarID);
                    cmd.Parameters.Add(paramId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result = (int)reader[0];
                    }
                    return result;
                }
                else
                {
                    return -1;
                }
            }
            finally
            {
                con.Close();
            }
        }
        public void DeleteCar(Car car)
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                if (VerifyCarInCarClient(car) == -1)
                {
                    if (car != null)
                    {
                        SqlCommand cmd = new SqlCommand("DeleteCar", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter paramId = new SqlParameter("@id", car.CarID);
                        cmd.Parameters.Add(paramId);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("You have to select a car!");
                    }

                }
                else
                {
                    MessageBox.Show("Car was bought or loaned!");
                }
            }

            finally
            {
                con.Close();
            }
        }
        public ObservableCollection<Car> GetCarsSold()
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetCarsSold", con);
                ObservableCollection<Car> result = new ObservableCollection<Car>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Car car = new Car();
                    car.CarID = (int)reader[0];
                    car.Brand = reader.GetString(1);
                    car.Model = reader.GetString(2);
                    car.Price = (int)reader[3];
                    car.FabricationYear = reader.GetString(4);
                    car.Color = reader.GetString(5);
                    car.Engine = reader.GetString(6);
                    car.Image = reader.GetString(7);
                    result.Add(car);
                }
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public ObservableCollection<Car> GetCarsSoldUser(int? id)
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetCarsSoldUser", con);
                ObservableCollection<Car> result = new ObservableCollection<Car>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@id", id);
                cmd.Parameters.Add(paramId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Car car = new Car();
                    car.CarID = (int)reader[0];
                    car.Brand = reader.GetString(1);
                    car.Model = reader.GetString(2);
                    car.Price = (int)reader[3];
                    car.FabricationYear = reader.GetString(4);
                    car.Color = reader.GetString(5);
                    car.Engine = reader.GetString(6);
                    car.Image = reader.GetString(7);
                    result.Add(car);
                }
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public ObservableCollection<Car> GetCarsLoaned()
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetCarsLoaned", con);
                ObservableCollection<Car> result = new ObservableCollection<Car>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Car car = new Car();
                    car.CarID = (int)reader[0];
                    car.Brand = reader.GetString(1);
                    car.Model = reader.GetString(2);
                    car.Price = (int)reader[3];
                    car.FabricationYear = reader.GetString(4);
                    car.Color = reader.GetString(5);
                    car.Engine = reader.GetString(6);
                    car.Image = reader.GetString(7);
                    result.Add(car);
                }
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public ObservableCollection<Car> GetCarsLoanedUser(int? id)
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetCarsLoanedUser", con);
                ObservableCollection<Car> result = new ObservableCollection<Car>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@id", id);
                cmd.Parameters.Add(paramId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Car car = new Car();
                    car.CarID = (int)reader[0];
                    car.Brand = reader.GetString(1);
                    car.Model = reader.GetString(2);
                    car.Price = (int)reader[3];
                    car.FabricationYear = reader.GetString(4);
                    car.Color = reader.GetString(5);
                    car.Engine = reader.GetString(6);
                    car.Image = reader.GetString(7);
                    result.Add(car);
                }
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public List<string> GetDate(Car car)
        {
            SqlConnection con = HelperDAL.Connection;
            try
            {
                if (car != null)
                {
                    SqlCommand cmd = new SqlCommand("GetDate", con);
                    List<string> result = new List<string>();
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlParameter paramId = new SqlParameter("@id", car.CarID);
                    cmd.Parameters.Add(paramId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(reader[0].ToString());
                        result.Add(reader[1].ToString());
                    }
                    return result;
                }
                else
                {
                    MessageBox.Show("You have to select a car!");
                    var list = new List<string> { "Error", "Error" };
                    return list;
                }
            }
            finally
            {
                con.Close();
            }
        }
    }
}

